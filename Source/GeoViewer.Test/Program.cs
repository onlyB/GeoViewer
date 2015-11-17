using System;
using System.Configuration;
using System.Data;
using System.Data.Objects;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using GeoViewer.Business;
using System.Windows.Forms;
using GeoViewer.Data;
using GeoViewer.Models;
using GeoViewer.Setup;
using GeoViewer.Utils;
using GeoViewer.Views.PictureView;
using GeoViewer.Views.TextView;
using Ionic.Zip;

namespace GeoViewer.Test
{
    class Program
    {

        /*
                static void Main(string[] args)
                {
                    // Test MD5
                    // Console.WriteLine("1234567".GetMd5Hash());
                    // Test Insert Account 
                    /*var account = new Account()
                                          {
                                              Username = "binhpro2",
                                              Email = "binhpro2@gmail.com",
                                              FullName = "Duy Binh",
                                              Password = "1234567"
                                          };
                    if(AccountBLL.Current.Insert(account))
                        Console.WriteLine("Them account thanh cong");
                     #2#
                    // Test Update Account
                    /*var account = AccountBLL.Current.GetByUsername("binhpro2");
                    account.IsApproved = true;
                    account.FullName = "Updated";
                    if (AccountBLL.Current.Update(account))
                    {
                        Console.WriteLine("Sua account thanh cong");
                    }
                     #2#
                    // Test Login
                    /*if (AccountBLL.Current.LogedInUser == null)
                    {
                        Console.WriteLine("Chua Login");
                    }

                    AccountBLL.Current.Login("binhpro", "1234567");
                    if (AccountBLL.Current.LogedInUser != null)
                    {
                        Console.WriteLine("Login thanh cong: " + AccountBLL.Current.LogedInUser.Username);
                    }
                    #2#
                    // Test Role
                    // Add Roles
                    /*SecurityBLL.Current.SetRolesForUser("binhpro", new string[]{SecurityBLL.ROLE_ACCOUNT_EDIT,SecurityBLL.ROLE_ACCOUNT_MANAGE,SecurityBLL.ROLE_ACCOUNT_VIEW});
                    Console.WriteLine("Set role thanh cong");
                    Console.ReadLine();
                    if(SecurityBLL.Current.IsUserInRole("binhpro",SecurityBLL.ROLE_ACCOUNT_EDIT))
                    {
                        Console.WriteLine("SecurityBLL.ROLE_ACCOUNT_EDIT");
                        Console.ReadLine();
                    }
                    // Set roles
                    SecurityBLL.Current.SetRolesForUser("binhpro", new string[] { SecurityBLL.ROLE_ACCOUNT_EDIT, SecurityBLL.ROLE_ACCOUNT_MANAGE, SecurityBLL.ROLE_ACCOUNT_VIEW,SecurityBLL.ROLE_ALARM_EDIT });
                    Console.WriteLine("Set role thanh cong 2");
                    Console.ReadLine();#2#
                    /*if(SecurityBLL.Current.IsUserInRole(SecurityBLL.ROLE_ACCOUNT_EDIT))
                    {
                        Console.WriteLine(SecurityBLL.ROLE_ACCOUNT_EDIT);
                    }
                    else
                    {
                        Console.WriteLine("Not in " + SecurityBLL.ROLE_ACCOUNT_EDIT);
                    }
                    Console.ReadLine();
                    AccountBLL.Current.Login("binhpro","1234567");
                    if (SecurityBLL.Current.IsUserInRole(SecurityBLL.ROLE_ACCOUNT_EDIT))
                    {
                        Console.WriteLine(SecurityBLL.ROLE_ACCOUNT_EDIT);
                    }#2#

                    // Test Resource
                    /*try
                    {
                        AccountBLL.Current.Login("binhpro123","1234567");
                        Console.WriteLine("Loged In");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.ReadLine();
                    try
                    {
                        AccountBLL.Current.Login("binhpro", "1234sdfsa");
                        Console.WriteLine("Loged In");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.ReadLine();
                    try
                    {
                        AccountBLL.Current.Login("binhpro", "1234567");
                        Console.WriteLine("Loged In");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                     #1#
                    AccountBLL.Current.Login("binhpro", "1234567");
                    Console.WriteLine("Loged In");
                    //Console.ReadLine();
                    //SecurityBLL.Current.SetRolesForUser(AppContext.Current.LogedInUser,
                    //    new string[] {
                    //        SecurityBLL.ROLE_ACCOUNT_EDIT,
                    //        SecurityBLL.ROLE_ACCOUNT_MANAGE,
                    //        SecurityBLL.ROLE_ACCOUNT_VIEW,
                    //        SecurityBLL.ROLE_ALARM_EDIT,
                    //        SecurityBLL.ROLE_ALARM_MANAGE,
                    //        SecurityBLL.ROLE_ALARM_VIEW,
                    //        SecurityBLL.ROLE_DATA_EDIT,
                    //        SecurityBLL.ROLE_DATA_MANAGE,
                    //        SecurityBLL.ROLE_DATA_VIEW,
                    //        SecurityBLL.ROLE_VIEWS_EDIT,
                    //        SecurityBLL.ROLE_VIEWS_MANAGE,
                    //        SecurityBLL.ROLE_VIEWS_VIEW
                    //});
                    //Console.WriteLine("Add roles");

                    //Console.ReadLine();
                    //LoggerBLL.Current.Delete(5);
                    //Console.WriteLine("Delete Logger");

                    //Console.ReadLine();
                    //var logger1 = new Logger();
                    //logger1.Name = "Logger1";
                    //logger1.DataPath = "D:\\DL2_Logger1.dat";
                    //if (LoggerBLL.Current.Insert(logger1))
                    //    Console.WriteLine("Add Logger1 OK");
                    //var logger2 = new Logger();
                    //logger2.Name = "Logger2";
                    //logger2.DataPath = "D:\\DL2_Logger2.dat";
                    //if (LoggerBLL.Current.Insert(logger2))
                    //    Console.WriteLine("Add Logger2 OK");



                    //Console.ReadLine();
                    //var logger = LoggerBLL.Current.GetByID(5);
                    //DataReaderBLL.Current.ReadData(logger, false,true);
                    //Console.WriteLine("Read New Logger OK");

                    //string decimalStr = "8554.611";
                    //Decimal d1 = Convert.ToDecimal(decimalStr);
                    //Decimal d2 = Convert.ToDecimal(decimalStr, new CultureInfo("en-US"));
                    //Console.WriteLine(d1);
                    //Console.WriteLine(d2);

                    //DataReaderBLL.Current.InitThreads();
                    //Console.WriteLine("InitThreads OK");
                    //Console.ReadLine();
                    //DataReaderBLL.Current.StartThreads();
                    //Console.WriteLine("StartThreads OK");
                    //Console.ReadLine();
                    //DataReaderBLL.Current.StopThread(6);
                    //Console.WriteLine("StopThread(6) OK");
                    //Console.ReadLine();
                    //DataReaderBLL.Current.StopThread(7);
                    //Console.WriteLine("StopThread(7) OK");
                    string enter = "";
                    while (enter != "e")
                    {
                        DataReaderBLL.Current.ReadData();
                        enter = Console.ReadLine();
                    }
            
                    Console.ReadLine();

                }
        */

        [STAThread]
        static void Main()
        {
            //Get SQL Server Instance
            //DataTable dataTable = Microsoft.SqlServer.Management.Smo.SmoApplication.EnumAvailableSqlServers("BINHPRO");

            //foreach (DataRow row in dataTable.Rows)
            //{
            //    foreach (DataColumn col in dataTable.Columns)
            //    {
            //        Console.WriteLine("{0} = {1}", col.ColumnName, row[col.ColumnName]);
            //    }
            //}
            //string myServer = Environment.MachineName;

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //try
            //{
            //    var context = new GeoViewerEntities();
            //    var list = context.Accounts.Count();
            //}
            //catch (Exception)
            //{
            //    Application.Run(new SetupDatabase());
            //}

            //Application.Run(new MainForm());
            //string key = LicenceBLL.GenerateKey();
            //bool valid = LicenceBLL.ValidateKey(key);
            //if(!File.Exists("licence.bbk"))
            //{
            //    File.Create("licence.bbk");
            //}
            //StreamWriter writer = new StreamWriter("licence.bbk");
            //writer.Write(LicenceBLL.GenerateKey());
            //writer.Flush();
            //writer.Close();
            //Console.WriteLine(LicenceBLL.ValidateKey());
            //Console.ReadLine();
            //ZipFile zip = new ZipFile();
            //zip.AddDirectory("D:\\DS1");
            //zip.Save(@"D:\DS1.zip");
            //ZipFile zip = ZipFile.Read(@"D:\DS1.zip");
            //zip.ExtractAll(@"E:\DS1");
            //Console.ReadLine();
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm());

            //Console.WriteLine(CalculateUtils.Infix2Postfix(@"1.123+ (x +1) *5.5 - 45 "));
            //Console.WriteLine(CalculateUtils.CalculateInfixExpression(@"1.123+ (x +1) ^5.5 - 45 ","x","10.5"));
            //Console.ReadLine();

            //Console.WriteLine(entityConntext.Connection.ConnectionString);
            // Login to system
            //AccountBLL.Current.Login("binhpro", "1234567");
            // Get Logedin User
            //Console.WriteLine("Loged In " + AppContext.Current.LogedInUser.Username + " - " + AppContext.Current.LogedInUser.Email);

            /*
                        // Enter to continue
                        Console.ReadLine();

                        // Get all sensorValues of a sensor
                        List<SensorValue> allValues = entityConntext.SensorValues.ToList();
                        Console.WriteLine("All SensorValue in database: "+ allValues.Count);
                        // Linq to entities
                        var listValues = entityConntext.SensorValues.Where(ent => ent.SensorID == 1).OrderByDescending(ent => ent.MeaTime).Skip(10).Take(10);
                        // Linq to SQL
                        var listValues2 = (from ent in entityConntext.SensorValues
                                          where ent.SensorID == 1
                                          orderby ent.MeaTime descending
                                          select ent).Skip(10).Take(10);
                        // For more example http://code.msdn.microsoft.com/101-LINQ-Samples-3fb9811b
                        // Option Parameter http://msdn.microsoft.com/en-us/library/dd264739.aspx
                        Console.WriteLine("10 SensorValues in database where SensorID = 1: " + listValues.Count());
                        // Enter to continue
                        Console.ReadLine();

                        // Call Bussiness Method For Insert Update Delete
                        // Example: insert an picture view
                        var pictureView = new PictureView();
                        pictureView.Name = "Picture View Demo 1";
                        if(PictureViewBLL.Current.Insert(pictureView))
                            Console.WriteLine("Insert Picture View Success, ID: " + pictureView.PictureViewID);
           
                        // Enter to continue
                        Console.ReadLine();
                        int id = pictureView.PictureViewID;
                        // Update this picture view
                        // First get picture vierw by id
                        var pictureView2 = PictureViewBLL.Current.GetByID(pictureView.PictureViewID);
                        // Modify
                        pictureView2.Name = "Picture View Demo 2";
                        // Update
                        if(PictureViewBLL.Current.Update(pictureView2))
                            Console.WriteLine("Updated Picture View susscess!");

                        // Enter to continue
                        Console.ReadLine();
            
                        // Delete
                        if(PictureViewBLL.Current.Delete(id))
                            Console.WriteLine("Deleted Picture View susscess!");
                        // Or Delete By this method
                        // PictureViewBLL.Current.Delete(pictureView2);


            */
            /* var list = entityConntext.SensorValues.Select(ent => new {ent.MeaTime, ent.RawValue}).ToList();
             var item = list[2].MeaTime;
             var x = new string[] {};*/
            //var list = entityConntext.SensorValues;

            //DataReaderBLL.Current.InitThreads();
            //DataReaderBLL.Current.StartThreads();
            //   Console.ReadLine();

            //var group = ChartViewBLL.Current.GetGroupByID(1);
            //var sensorsInGroup = group.Sensors;


            // Add new Group
            /* var group = new Models.Group()
                             {
                                 Name =  "new group",
                                 RawData = false
                             };
             if(ChartViewBLL.Current.InsertGroup(group))
                 Console.WriteLine("Insert ok!");
             */
            //            Application.EnableVisualStyles();
            //            Application.SetCompatibleTextRenderingDefault(false);
            //            Application.Run(new TextViewForm());
            //
            //            int result = entityConntext.ExecuteStoreCommand("BACKUP DATABASE GeoViewerV2 TO DISK = 'D:\\myDb2.BAK'",
            //                                                                 null);

            //var context = entityConntext;
            //string connectionName = entityConntext.Connection.ConnectionString;
            //Console.WriteLine(connectionName);
            //string connString = ConfigurationManager.ConnectionStrings[connectionName.Replace("name=", "")].ConnectionString;
            ////Regex re = new Regex("Initial Catalog=GeoViewerV2;");

            //System.Data.SqlClient.SqlConnectionStringBuilder connBuilder = new SqlConnectionStringBuilder(connString);
            //Console.WriteLine(connBuilder.InitialCatalog);

            // var sensor = new Sensor();

            //sensor.AlarmEnabled && sensor.AlarmFlag;

            // Test unzip file
            //BackupRestoreBLL.Current.ExtractZipFile(@"E:/zip.zip", @"E:/zip");
            //BackupRestoreBLL.Current.RestoreFromFile(@"E:/GeoViewer_17_10_2012_12_58_41_6kn4.zip");
            //Console.ReadLine();

            //            string databaseName = "databaseName";
            //            string query = @"BACKUP DATABASE ";
            //            query += databaseName;
            //            query += "TO DISK = 'D:\\myDb2.BAK'";
            //
            //            Int32[] array = new int[] { 1, 2, 3, 4, 5 };
            //            Int32 count = 0;
            //            while (count < array.Length)
            //            {
            //                Console.WriteLine(array[count].ToString());
            //                count++;
            //            }
            //            bool enable = GetConfiguration("ENABLE_UPDATE");
            //            if (enable)
            //            {
            //                for (int i = 0; i < array.Length; i++)
            //                {
            //                    update(array[i]);
            //                }
            //            }
            //
            //            try
            //            {
            //                SqlConnection conn = new SqlConnection();
            //                conn.open();
            //                // Do something here
            //            }
            //            catch (Exception exception)
            //            {
            //                Console.WriteLine(exception.Message);
            //            }
            //            finally
            //            {
            //                conn.close();
            //            }
            //            Int32 firstNum = 10000000, secondNum = 10000000;
            //            Int32 produit = firstNum*secondNum;
            //            String path = "";
            //            path += "D:\Demo\Backup.bak";
            //var sc = new MSScriptControl.ScriptControlClass();
            //sc.Language = "VBScript";
            //var result = sc.Eval("22+22+(2*2");
            //var entityConntext = new GeoViewerEntities();
            //var entityConntext2 = new GeoViewerEntities();
            //var logger = entityConntext.Loggers.FirstOrDefault();
            //entityConntext.Dispose();
            //logger.Name = "binh test2142";
            //Console.WriteLine(logger.EntityState);
            ////ObjectStateEntry state;
            ////bool exist = entityConntext2.ObjectStateManager.TryGetObjectStateEntry(logger,out state);
            ////if(!exist || state == null ||state.State == EntityState.Detached)
            ////{
            ////    entityConntext2.Loggers.Attach(logger);
            ////    entityConntext2.ObjectStateManager.ChangeObjectState(logger, EntityState.Modified);
            ////}
            //entityConntext2.AttachUpdatedObject(logger);
            //entityConntext2.SaveChanges();
            //entityConntext.Dispose();
            //var logger2 = new GeoViewerEntities().Loggers.FirstOrDefault();
            //Console.WriteLine(logger2.Name);
            //AccountBLL.Current.Login("RootAdmin","1234567");
            //var entityConntext = new GeoViewerEntities();
            //Console.WriteLine(entityConntext.Accounts.Count());

            //var user = new Account()
            //               {
            //                   Username = "test1234",
            //                   Email = "email124242@abc.com",
            //                   FullName = "bvinh",
            //                   Password = "1234567",
            //               };
            //AccountBLL.Current.Insert(user);
            //Console.WriteLine(entityConntext.Accounts.Count());

            //user.FullName = "changed";
            //AccountBLL.Current.Update(user);
            //Console.WriteLine(AccountBLL.Current.GetByUsername(user.Username).FullName);

            //AccountBLL.Current.Delete(user.Username);
            //Console.WriteLine(entityConntext.Accounts.Count());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

            Console.ReadLine();
        }
    }
}
