/* Copyright by ICEA - 2012
 * 
 * Created By Binh.N.D 06/10/2012
 * 
 * update by Trong 16/10/2012
 * update note
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Text;
using System.IO.Compression;
using System.Windows.Forms;
using GeoViewer.Business.Properties;
using GeoViewer.Models;
using GeoViewer.Utils;
using Ionic.Zip;

namespace GeoViewer.Business
{
    public class BackupRestoreBLL
    {
        #region Instance Of Class
        private static BackupRestoreBLL _current = new BackupRestoreBLL();
        public static BackupRestoreBLL Current
        {
            get { return _current; }
        }
        #endregion

        private string databaseName = "GeoViewerV2";

        public string GetDefaultBackupFolder()
        {
            DirectoryInfo defaultDir = new DirectoryInfo("Backups");
            if (!defaultDir.Exists)
            {
                defaultDir.Create();
            }
            return defaultDir.FullName;
        }

        /// <summary>
        /// Back up to file
        /// </summary>
        /// <param name="folderPath">folder will contain backup file</param>
        /// <returns></returns>
        public string BackupToFile(string folderPath)
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                SecurityBLL.Current.CheckPermissionThrowException(SecurityBLL.ROLE_DATA_MANAGE);
                // Make backup folder name
                string backupFolder = folderPath + @"\GeoViewer_" + DateTime.Now.ToString("ddMMyyyy-hhmm") + "_" +
                                      GeneralUtils.GenerateRandomString(4);
                // Create temp folder
                Directory.CreateDirectory(backupFolder);

                // Copy files data
                foreach (var obj in entityConntext.Loggers)
                {
                    // Copy data files
                    FileInfo file = new FileInfo(obj.DataPath);
                    if (file.Exists)
                    {
                        File.Copy(obj.DataPath, backupFolder + @"\" + obj.LoggerID + file.Extension, true);
                    }
                    else
                    {
                        CopyFolder(obj.DataPath, backupFolder + @"\" + obj.LoggerID);
                    }
                }
                // Back up database
                entityConntext.ExecuteStoreCommand(
                    "backup database " + databaseName + "  to disk = '" + backupFolder + @"\database.bak'",
                    null);

                // Copy Pictures folder
                CopyFolder("Pictures", backupFolder + @"\Pictures");

                // Zip to file
                ZipFile zip = new ZipFile();
                zip.AddDirectory(backupFolder);
                zip.Save(backupFolder + ".zip");

                // Delete file after zipped
                DeleteFolder(backupFolder);

                return backupFolder + ".zip";
            }
        }

        /// <summary>
        /// Restore from file
        /// </summary>
        /// <param name="filePath">Backup file to restore</param>
        public void RestoreFromFile(string filePath)
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                SecurityBLL.Current.CheckPermissionThrowException(SecurityBLL.ROLE_DATA_MANAGE);
                // Check the file exist
                FileInfo fileInfo = new FileInfo(filePath);
                if (!fileInfo.Exists) throw new Exception(Resources.Error_BackupFileNotExist);

                // First extract the backup zip file
                string folder = fileInfo.FullName.Substring(0, fileInfo.FullName.LastIndexOf("."));
                if (Directory.Exists(folder)) DeleteFolder(folder);
                ZipFile zip = ZipFile.Read(filePath);
                zip.ExtractAll(folder);
                Console.WriteLine("Extract temp file to folder " + folder);

                // Restore the database
                string databasePath = folder + @"\database.bak";
                if (!File.Exists(databasePath)) throw new Exception(Resources.Error_DatabaseNotExist);
                entityConntext.ExecuteStoreCommand("use master restore database " + databaseName + "  from disk = '" +
                                                   databasePath + "'");
                Console.WriteLine("Restore database ok!");
                // Refresh data
                //AppContext.Current.RefreshEntityContext();
                AccountBLL.Current.Logout();
                AppContext.Current.OpenProject = null;

                // Overwrite data files
                foreach (var obj in entityConntext.Loggers)
                {
                    if (!obj.DataPath.Contains("."))
                    {
                        // Copy folder
                        if (Directory.Exists(folder + @"\" + obj.LoggerID))
                            CopyFolder(folder + @"\" + obj.LoggerID, obj.DataPath);
                        Console.WriteLine("Copy folder to " + obj.DataPath);
                    }
                    else
                    {
                        // Copy file
                        string sourceFile = folder + @"\" + obj.LoggerID +
                                            obj.DataPath.Substring(obj.DataPath.LastIndexOf("."));
                        if (File.Exists(sourceFile))
                        {
                            File.Copy(sourceFile, obj.DataPath, true);
                            Console.WriteLine("Copy file to " + obj.DataPath);
                        }
                    }


                }
                // Overwrite picture
                CopyFolder(folder + @"\Pictures", "Pictures");

                // Delete temp file and folder
                DeleteFolder(folder);
                Console.WriteLine("Delete folder " + folder);
            }
        }

        public void CopyFolder(string sourceFolder, string destFolder)
        {
            DirectoryInfo sourceDir = new DirectoryInfo(sourceFolder);
            if (sourceDir.Exists)
            {
                if (!Directory.Exists(destFolder))
                {
                    Directory.CreateDirectory(destFolder);
                }
                // copy all file in this folder
                foreach (var file in sourceDir.GetFiles())
                {
                    file.CopyTo(destFolder + "/" + file.Name, true);
                }
                // copy all subfolder
                foreach (var subDir in sourceDir.GetDirectories())
                {
                    CopyFolder(subDir.FullName, destFolder + "/" + subDir.Name);
                }
            }
        }

        public void DeleteFolder(string folder)
        {
            DirectoryInfo dir = new DirectoryInfo(folder);
            if (dir.Exists)
            {
                foreach (var file in dir.GetFiles())
                {
                    file.Delete();
                }
                foreach (var subDir in dir.GetDirectories())
                {
                    DeleteFolder(subDir.FullName);
                }
                dir.Delete();
            }
        }
    }
}
