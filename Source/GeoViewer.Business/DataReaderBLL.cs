/* Copyright by ICEA - 2012
 * 
 * Created By Binh.N.D 06/10/2012
 * 
 * Updated 15/01/2013 By Binhpro: Read data from folder
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using GeoViewer.Models;
using GeoViewer.Utils;
using System.IO;

namespace GeoViewer.Business
{
    public class DataReaderBLL
    {
        #region Instance Of Class
        private static DataReaderBLL _current = new DataReaderBLL();
        public static DataReaderBLL Current
        {
            get { return _current; }
        }
        #endregion

        public DateTime? GetLastTime()
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                var last = entityConntext.SensorValues.OrderByDescending(ent => ent.MeaTime).FirstOrDefault();
                if (last != null)
                    return last.MeaTime;
                return null;
            }
        }

        /// <summary>
        /// Read data for logger
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="onlyNewData"></param>
        /// <param name="calculateValue"></param>
        /// <param name="refreshEntityContext"></param>
        public void ReadData(int loggerID, bool onlyNewData, bool calculateValue, ReaderProccess readerProccess)
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                Logger logger = entityConntext.Loggers.SingleOrDefault(ent => ent.LoggerID == loggerID);
                if (logger == null) return;

                // For test only
                Console.WriteLine("Thread[" + Thread.CurrentThread.ManagedThreadId + "]: Read data form logger " + logger.LoggerID);
                // End for test

                var fileInfo = new FileInfo(logger.DataPath);


                if (!fileInfo.Exists)
                {
                    readerProccess.TotalRecord = FileUtils.CountTotalFolderLines(logger.DataPath);
                    readerProccess.FileReaderProccesses = new List<ReaderProccess>();
                    readerProccess.CurrentFile = logger.DataPath;

                    var directoryInfo = new DirectoryInfo(logger.DataPath);
                    if (!directoryInfo.Exists) throw new Exception(Properties.Resources.Error_Data_FileNotFound);
                    string meta = "";
                    if (logger.Meta.LastIndexOf("#") > 0)
                    {
                        meta = logger.Meta.Substring(0, logger.Meta.LastIndexOf("#") + 1);
                    }
                    foreach (var file in directoryInfo.GetFiles())
                    {
                        ReadData(logger, file.FullName, onlyNewData, calculateValue, readerProccess);
                        meta += file.Name + ",";
                    }
                    logger.Meta = meta;
                    logger.FileSize = FileUtils.FolderSize(logger.DataPath);
                }
                else
                {
                    readerProccess.TotalRecord = FileUtils.CountTotalLines(logger.DataPath);
                    readerProccess.CurrentFile = logger.DataPath;
                    ReadData(logger, logger.DataPath, onlyNewData, calculateValue, readerProccess);
                    logger.FileSize = fileInfo.Length;
                }

                // Update last time read logger
                logger.LastModifyDatetime = DateTime.Now;
                // Update total record
                logger.TotalSensor = logger.Sensors.Count();
                Sensor sensor = null;
                if (logger.TotalSensor > 0)
                {
                    sensor = logger.Sensors.First();
                    logger.TotalRecord = sensor.SensorValues.LongCount();
                }
                else
                {
                    logger.TotalRecord = 0;
                }
                // Update first record meatime
                if (logger.TotalRecord > 0)
                {
                    logger.FirstLogDatetime = sensor.SensorValues.OrderBy(ent => ent.MeaTime).First().MeaTime;
                    logger.LastLogDatetime = sensor.SensorValues.OrderByDescending(ent => ent.MeaTime).First().MeaTime;
                }

                entityConntext.SaveChanges();

                Console.WriteLine("Thread[" + Thread.CurrentThread.ManagedThreadId + "]: End Read data form logger " + logger.LoggerID + ". Total record " + logger.TotalRecord);
            }

        }
        /// <summary>
        /// Read data from file with option onlyNewData and calculateValue
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="dataPath"></param>
        /// <param name="onlyNewData"></param>
        /// <param name="calculateValue"></param>
        /// <param name="refreshEntityContext"></param>
        public void ReadData(Logger logger, string dataPath, bool onlyNewData, bool calculateValue, ReaderProccess readerProccess)
        {
            try
            {
                Console.WriteLine("Thread[" + Thread.CurrentThread.ManagedThreadId + "]: Start read data file " + dataPath);
                ReaderProccess fileReaderProccess;
                if (readerProccess.FileReaderProccesses == null)
                {
                    fileReaderProccess = readerProccess;
                }
                else
                {
                    fileReaderProccess = new ReaderProccess();
                    fileReaderProccess.TotalRecord = FileUtils.CountTotalLines(dataPath);
                    readerProccess.FileReaderProccesses.Add(fileReaderProccess);
                }
                fileReaderProccess.CurrentFile = dataPath;

                bool readFolder = !logger.DataPath.Equals(dataPath);

                var file = new FileInfo(dataPath);

                // Only read if file is modified
                if (onlyNewData)
                {
                    if (readFolder)
                    {
                        if (logger.LastModifyDatetime >= file.LastWriteTime && logger.Meta.Contains(file.Name)) return;
                    }
                    else
                    {
                        if (logger.LastModifyDatetime >= file.LastWriteTime || logger.FileSize == file.Length) return;
                    }
                }

                var streamReader = new StreamReader(dataPath, Encoding.UTF8);
                var spiliter = new[] { logger.Delimiter };

                // read meta line
                string lineData = streamReader.ReadLine();
                fileReaderProccess.ReadRecord++;

                if (String.IsNullOrEmpty(lineData))
                {
                    Console.WriteLine("File Empty!");
                    return;
                }
                // check type of data file
                int type = 0;
                string[] firstlineCells = lineData.Split(spiliter, StringSplitOptions.None);
                if (firstlineCells[0].ToInt32TryParse() > 0 && firstlineCells[1].ToInt32TryParse() > 0)
                {
                    type = 1;
                }

                if (type == 0)
                {
                    // Ignore 4 first lines
                    for (int i = 0; i < 4; i++)
                    {
                        lineData = streamReader.ReadLine();
                        fileReaderProccess.ReadRecord++;
                    }
                }

                // Begin to read data
                var entityConntext = new GeoViewerEntities();
                var sensors = entityConntext.Sensors.Where(ent => ent.LoggerID == logger.LoggerID).OrderBy(ent => ent.ColumnIndex).ToList();
                int line = 0;
                do
                {
                    if (!string.IsNullOrEmpty(lineData.Trim()))
                    {
                        string[] cells = lineData.Split(spiliter, StringSplitOptions.None);

                        var meaTime = type == 0
                                          ? Convert.ToDateTime(CleanValue(cells[0]))
                                          : new DateTime(cells[1].ToInt32TryParse(), 1, 1).AddDays(
                                              cells[2].ToInt32TryParse()).AddMinutes(
                                                  (int)(cells[3].ToInt32TryParse() * 60 / 100));

                        // Only read new record (by time)
                        if (!(onlyNewData && !readFolder && meaTime >= logger.FirstLogDatetime &&
                            meaTime <= logger.LastLogDatetime))
                        {
                            var valuesNeedCalc = new List<SensorValue>();
                            foreach (var sensor in sensors)
                            {
                                if (cells.Length > sensor.ColumnIndex)
                                {
                                    // Check Value exist
                                    //var sensorValue = sensor.SensorValues.SingleOrDefault(ent => ent.MeaTime == meaTime);
                                    var sensorValue = entityConntext.SensorValues.SingleOrDefault(ent => ent.SensorID == sensor.SensorID && ent.MeaTime == meaTime);
                                    if (sensorValue == null)
                                    {
                                        sensorValue = new SensorValue();
                                        sensorValue.SensorID = sensor.SensorID;
                                        sensorValue.MeaTime = meaTime;
                                        sensor.SensorValues.Add(sensorValue);
                                    }
                                    sensorValue.RawValue = CleanValue(cells[sensor.ColumnIndex]).ToDecimalTryParse();
                                    valuesNeedCalc.Add(sensorValue);
                                }
                            }
                            // Calc Value & Alarm Logger
                            if (calculateValue)
                            {
                                foreach (var sensorValue in valuesNeedCalc)
                                {
                                    CalculationBLL.Current.Calculating(sensorValue, true);
                                }
                            }
                        }
                        line++;
                        if (line % 50 == 0)
                        {
                            entityConntext.SaveChanges();
                            entityConntext = new GeoViewerEntities();
                            sensors = entityConntext.Sensors.Where(ent => ent.LoggerID == logger.LoggerID).OrderBy(ent => ent.ColumnIndex).ToList();
                            Console.WriteLine("Thread[" + Thread.CurrentThread.ManagedThreadId + "]: Read success " + line + " lines in " + dataPath);
                        }
                    }

                    // go to nextline
                    lineData = streamReader.ReadLine();
                    fileReaderProccess.ReadRecord++;

                } while ((lineData != null));

                streamReader.Close();
                if (fileReaderProccess.ReadRecord > 0)
                {
                    fileReaderProccess.ReadRecord--;
                }

                if (line > 0 && line % 50 != 0)
                {
                    entityConntext.SaveChanges();
                    Console.WriteLine("Thread[" + Thread.CurrentThread.ManagedThreadId + "]: Read success " + line + " lines in " + dataPath);
                }
                Console.WriteLine("Thread[" + Thread.CurrentThread.ManagedThreadId + "]: End read data from " + dataPath);

                if (readerProccess.FileReaderProccesses != null)
                {
                    readerProccess.ReadRecord += fileReaderProccess.ReadRecord;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        /// <summary>
        /// Read header, automatic add sensors' information to database
        /// </summary>
        /// <param name="logger"></param>
        public void ReadHeader(int loggerID)
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                Logger logger = entityConntext.Loggers.SingleOrDefault(ent => ent.LoggerID == loggerID);
                if (logger == null) return;
                bool readFolder = !File.Exists(logger.DataPath);
                StreamReader streamReader;
                if (readFolder)
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(logger.DataPath);
                    if (!directoryInfo.Exists) throw new Exception(Properties.Resources.Error_Data_FileNotFound);
                    var files = directoryInfo.GetFiles();
                    if (files.Length == 0) throw new Exception(Properties.Resources.Error_Data_FileNotFound);
                    streamReader = new StreamReader(files[0].FullName, Encoding.UTF8);
                }
                else
                {
                    streamReader = new StreamReader(logger.DataPath, Encoding.UTF8);
                }

                var spiliter = new string[] { logger.Delimiter };
                // read meta line
                string firstline = streamReader.ReadLine();
                // check type of data file
                int type = 0;
                string[] cells = firstline.Split(spiliter, StringSplitOptions.None);
                if (cells[0].ToInt32TryParse() > 0 && cells[1].ToInt32TryParse() > 0)
                {
                    type = 1;
                }
                if (type == 0)
                {
                    logger.Meta = firstline;
                    // read header line
                    string header = streamReader.ReadLine();
                    // read after header line
                    string afterHeader = streamReader.ReadLine();
                    // read Units line
                    string units = streamReader.ReadLine();
                    string[] sensorNames = header.Split(spiliter, StringSplitOptions.RemoveEmptyEntries);
                    string[] sensorUnits = units.Split(spiliter, StringSplitOptions.RemoveEmptyEntries);
                    // Two colums for Timestamp and record number
                    for (int i = 2; i < sensorNames.Length; i++)
                    {
                        var sensor = new Sensor();

                        // Set project ID
                        sensor.ProjectID = logger.ProjectID;

                        sensor.Logger = logger;
                        sensor.ColumnIndex = i;
                        sensor.Name = CleanValue(sensorNames[i]);
                        sensor.Unit = sensorUnits.Length >= i ? CleanValue(sensorUnits[i]) : "";
                        sensor.CreatedDate = sensor.LastEditedDate = DateTime.Now;
                        sensor.CreatedUser = sensor.LastEditedUser = AppContext.Current.LogedInUser.Username;
                        logger.Sensors.Add(sensor);
                    }
                    logger.TotalSensor = sensorNames.Length - 2;

                }
                else if (type == 1)
                {
                    logger.Meta = "DS Index: " + cells[0] + "; IP Address: " + cells[4] + "#";
                    logger.TotalSensor = cells.Length - 5;
                    for (int i = 5; i < cells.Length; i++)
                    {
                        var sensor = new Sensor();
                        sensor.Logger = logger;
                        // Set project ID
                        sensor.ProjectID = logger.ProjectID;

                        sensor.ColumnIndex = i;
                        sensor.Name = "Column " + (i);
                        sensor.Unit = "Unit " + (i);
                        sensor.CreatedDate = sensor.LastEditedDate = DateTime.Now;
                        sensor.CreatedUser = sensor.LastEditedUser = AppContext.Current.LogedInUser.Username;
                        logger.Sensors.Add(sensor);
                    }
                }
                streamReader.Close();
                entityConntext.SaveChanges();
                //AppContext.Current.RefreshEntityContext();

            }

        }

        private string CleanValue(string str)
        {
            return str.Replace("\"", "");
        }

        /// <summary>
        /// Find all loggers which set AutomaticReadData = true and ReadData for it (only new data,calculate value)
        /// </summary>
        public void ReadData()
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                foreach (var logger in entityConntext.Loggers.Where(ent => ent.AutomaticReadData).ToList())
                {
                    int totalRecords;
                    int readRecords;
                    string currentFile;
                    ReadData(logger.LoggerID, true, true, new ReaderProccess());
                }
            }
        }

    }

    public class ReaderThreadManager
    {
        #region Instance Of Class
        private static ReaderThreadManager _current = new ReaderThreadManager();
        public static ReaderThreadManager Current
        {
            get { return _current; }
        }
        #endregion


        #region Automatic read data
        public Dictionary<int, Thread> ReadDataThreads { get; set; }
        public Dictionary<int, AutomaticReadData> ReadDataWorks { get; set; }

        public void InitThreads()
        {
            ReadDataThreads = new Dictionary<int, Thread>();
            ReadDataWorks = new Dictionary<int, AutomaticReadData>();
            foreach (var logger in new GeoViewerEntities().Loggers.Where(ent => ent.AutomaticReadData && ent.LastModifyDatetime != null).ToList())
            {
                var work = new AutomaticReadData();
                work.CurrentLogger = logger;
                Thread thread = new Thread(work.Run);
                ReadDataThreads.Add(logger.LoggerID, thread);
                ReadDataWorks.Add(logger.LoggerID, work);
            }
        }

        public void StartThreads()
        {
            foreach (var thread in ReadDataThreads.Values)
            {
                if (!thread.IsAlive) thread.Start();
            }
        }

        public void StopThread(int loggerID)
        {
            if (ReadDataThreads[loggerID].IsAlive)
            {
                if (ReadDataWorks[loggerID].IsReading)
                {
                    throw new Exception("Đang đọc dữ liệu từ logger!");
                }
                ReadDataThreads[loggerID].Abort();
            }
        }

        public void AddThread(Logger logger)
        {
            if (!ReadDataThreads.ContainsKey(logger.LoggerID))
            {
                var work = new AutomaticReadData();
                work.CurrentLogger = logger;
                Thread thread = new Thread(work.Run);
                ReadDataThreads.Add(logger.LoggerID, thread);
                ReadDataWorks.Add(logger.LoggerID, work);
            }
            if (logger.FirstLogDatetime != null && !ReadDataThreads[logger.LoggerID].IsAlive)
                ReadDataThreads[logger.LoggerID].Start();
        }

        public void RemoveThread(Logger logger)
        {
            if (ReadDataThreads.ContainsKey(logger.LoggerID))
            {
                StopThread(logger.LoggerID);
                ReadDataThreads.Remove(logger.LoggerID);
                ReadDataWorks.Remove(logger.LoggerID);
            }
        }

        public void SaveThread(Logger logger)
        {
            if (!ReadDataThreads.ContainsKey(logger.LoggerID))
            {
                var work = new AutomaticReadData();
                work.CurrentLogger = logger;
                Thread thread = new Thread(work.Run);
                ReadDataThreads.Add(logger.LoggerID, thread);
                ReadDataWorks.Add(logger.LoggerID, work);
            }
            else
            {
                ReadDataWorks[logger.LoggerID].CurrentLogger = logger;
            }
            if (logger.FirstLogDatetime != null && !ReadDataThreads[logger.LoggerID].IsAlive)
                ReadDataThreads[logger.LoggerID].Start();
        }
        #endregion

        public AutomaticReadData ReadDataByThread(Logger logger, bool onlyNewData, bool calculateValue)
        {
            var work = new AutomaticReadData()
                           {
                               CurrentLogger = logger,
                               OnlyNewData = onlyNewData,
                               CalculateValue = calculateValue,
                               Loop = false
                           };
            var thread = new Thread(work.Run);
            thread.Start();
            return work;
        }
    }

    public class AutomaticReadData
    {
        public Logger CurrentLogger { set; get; }
        public bool IsReading { private set; get; }
        public int TimeToNextRead { private set; get; }
        public ReaderProccess ReaderProccess { private set; get; }
        public bool OnlyNewData { set; get; }
        public bool CalculateValue { set; get; }
        public bool Loop { set; get; }


        public AutomaticReadData()
        {
            OnlyNewData = true;
            CalculateValue = true;
            ReaderProccess = new ReaderProccess();
            Loop = true;
        }

        public void Run()
        {
            do
            {
                try
                {
                    IsReading = true;
                    CurrentLogger = LoggerBLL.Current.GetByID(CurrentLogger.LoggerID);
                    DataReaderBLL.Current.ReadData(CurrentLogger.LoggerID, OnlyNewData, CalculateValue, ReaderProccess);
                    IsReading = false;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    IsReading = false;
                }
                // For Test Only
                Console.WriteLine("Logger " + CurrentLogger.LoggerID + " sleep " + CurrentLogger.ReadInterval);
                for (int i = CurrentLogger.ReadInterval; i > 0; i--)
                {
                    TimeToNextRead = i;
                    Thread.Sleep(1000);
                }
            } while (Loop);
        }
    }

    public class ReaderProccess
    {
        public long TotalRecord { set; get; }
        public long ReadRecord { set; get; }
        public string CurrentFile { set; get; }

        public List<ReaderProccess> FileReaderProccesses { set; get; }


    }
}
