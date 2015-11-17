using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using GeoViewer.Utils;

namespace GeoViewer.Business
{
    public static class LicenceBLL
    {
        public static string GenerateKey()
        {
            int random = (new Random().Next(1, 999999)) * 99;
            string computerName = System.Environment.MachineName;
            string key = random + "#" + computerName;
            key = Encrypt(key, "binhpro");
            return key;
        }

        public static bool ValidateKey()
        {
            try
            {
                if (File.Exists("licence.bbk"))
                {
                    StreamReader reader = new StreamReader("licence.bbk");
                    string key = reader.ReadToEnd();
                    reader.Close();
                    return ValidateKey(key);
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ValidateKey(string key)
        {
            try
            {
                string computerName = System.Environment.MachineName;
                string keyDecrypt = Decrypt(key, "binhpro");
                if (keyDecrypt.Contains("#"))
                {
                    string[] strs = keyDecrypt.Split(new[] { "#" }, StringSplitOptions.None);
                    if (strs.Length >= 2)
                    {
                        bool valid1 = strs[1] == computerName;
                        bool valid2 = (strs[0].ToInt32TryParse() % 99) == 0;
                        int num = strs[0].ToInt32TryParse();
                        int num2 = num % 99;

                        if (strs[1].Equals(computerName) && (strs[0].ToInt32TryParse() % 99 == 0))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static readonly byte[] salt = Encoding.ASCII.GetBytes("binhprobinhprobinhprobinhpro");

        public static string Encrypt(string textToEncrypt, string encryptionPassword)
        {
            var algorithm = GetAlgorithm(encryptionPassword);

            byte[] encryptedBytes;
            using (ICryptoTransform encryptor = algorithm.CreateEncryptor(algorithm.Key, algorithm.IV))
            {
                byte[] bytesToEncrypt = Encoding.UTF8.GetBytes(textToEncrypt);
                encryptedBytes = InMemoryCrypt(bytesToEncrypt, encryptor);
            }
            return Convert.ToBase64String(encryptedBytes);
        }

        public static string Decrypt(string encryptedText, string encryptionPassword)
        {
            var algorithm = GetAlgorithm(encryptionPassword);

            byte[] descryptedBytes;
            using (ICryptoTransform decryptor = algorithm.CreateDecryptor(algorithm.Key, algorithm.IV))
            {
                byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
                descryptedBytes = InMemoryCrypt(encryptedBytes, decryptor);
            }
            return Encoding.UTF8.GetString(descryptedBytes);
        }

        // Performs an in-memory encrypt/decrypt transformation on a byte array.
        private static byte[] InMemoryCrypt(byte[] data, ICryptoTransform transform)
        {
            MemoryStream memory = new MemoryStream();
            using (Stream stream = new CryptoStream(memory, transform, CryptoStreamMode.Write))
            {
                stream.Write(data, 0, data.Length);
            }
            return memory.ToArray();
        }

        // Defines a RijndaelManaged algorithm and sets its key and Initialization Vector (IV) 
        // values based on the encryptionPassword received.
        private static RijndaelManaged GetAlgorithm(string encryptionPassword)
        {
            // Create an encryption key from the encryptionPassword and salt.
            var key = new Rfc2898DeriveBytes(encryptionPassword, salt);

            // Declare that we are going to use the Rijndael algorithm with the key that we've just got.
            var algorithm = new RijndaelManaged();
            int bytesForKey = algorithm.KeySize / 8;
            int bytesForIV = algorithm.BlockSize / 8;
            algorithm.Key = key.GetBytes(bytesForKey);
            algorithm.IV = key.GetBytes(bytesForIV);
            return algorithm;
        }
    }
}
