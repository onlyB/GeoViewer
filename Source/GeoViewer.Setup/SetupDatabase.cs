using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GeoViewer.Business;
using GeoViewer.Utils;

namespace GeoViewer.Setup
{
    public partial class SetupDatabase : BaseWindowForm
    {
        public SetupDatabase()
        {
            InitializeComponent();
            txtServer.Text = @".\SQLEXPRESS";
            txtAccount.Text = "sa";
            txtPassword.Text = "1234567";
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = string.Format("Data Source={0};User id={1};Password={2};", txtServer.Text.Trim(), txtAccount.Text.Trim(), txtPassword.Text.Trim());
            try
            {
                conn.Open();
                Console.WriteLine("Connect Success!");

                // Save connection string to .config file
                StreamReader reader = new StreamReader("config.txt", new UTF8Encoding());
                string content = string.Format(reader.ReadToEnd(), txtServer.Text.Trim(), txtAccount.Text.Trim(), txtPassword.Text.Trim());
                reader.Close();
                StreamWriter writer = new StreamWriter("GeoViewer.exe.config", false, new UTF8Encoding());
                writer.Write(content);
                writer.Flush();
                writer.Close();

                // check database exist
                string databaseName = "GeoViewerV2";
                string sqlCreateDBQuery = string.Format("SELECT database_id FROM sys.databases WHERE Name = '{0}'", databaseName);
                SqlCommand sqlCmd = new SqlCommand(sqlCreateDBQuery, conn);
                object databaseID = sqlCmd.ExecuteScalar();
                bool restoreFlag = true;
                if (databaseID == null || GeneralUtils.ToInt32TryParse(databaseID) <= 0)
                {
                    // database not exist, create database    
                    sqlCmd = new SqlCommand(string.Format("CREATE DATABASE {0}", databaseName), conn);
                    sqlCmd.ExecuteNonQuery();
                    Console.WriteLine("Created database " + databaseName);
                }
                else
                {
                    restoreFlag = false;
                    Console.WriteLine("Database exist!");
                }
                if (!restoreFlag)
                {
                    restoreFlag = ShowConfirmMessage("Database của chương trình đã tồn tại. Bạn có muốn phục hồi về database chuẩn(chưa có dữ liệu) không?") == DialogResult.OK;
                }
                if (restoreFlag)
                {
                    // restore demo database
                    FileInfo file = new FileInfo("database.bak");
                    if (!file.Exists) throw new Exception("Database mẫu không tồn tại!");
                    
                    sqlCmd = new SqlCommand(string.Format("use master restore database {0} from disk = '{1}' with replace", databaseName, file.FullName), conn);
                    sqlCmd.ExecuteNonQuery();
                    DialogResult = DialogResult.OK;
                    Console.WriteLine("Restore success!");
                    MessageBox.Show("Cài đặt database thành công! Khởi động lại phần mềm để bắt đầu sử dụng.");
                    Environment.Exit(0);
                }
                MessageBox.Show("Cài đặt kết nối tới server thành công! Khởi động lại phần mềm để bắt đầu sử dụng.");
                Environment.Exit(0);

            }
            catch (Exception ex)
            {
                //DialogResult = DialogResult.No;
                MessageBox.Show("Cài đặt database không thành công: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }

}
