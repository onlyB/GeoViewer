/* Copyright by ICEA - 2012
 * 
 * Created By Binh.N.D 06/10/2012
 * 
 */

using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.IO;
using System.Linq;
using System.Text;
using GeoViewer.Business.Properties;
using GeoViewer.Models;
using GeoViewer.Utils;

namespace GeoViewer.Business
{
    public class LoggerBLL
    {
        #region Instance Of Class
        private static LoggerBLL _current = new LoggerBLL();
        public static LoggerBLL Current
        {
            get { return _current; }
        }
        #endregion

        public Logger GetByID(int id)
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                return entityConntext.Loggers.SingleOrDefault(ent => ent.LoggerID == id);
            }
        }

        public void Validate(Logger obj)
        {
            if (string.IsNullOrEmpty(obj.Delimiter)) obj.Delimiter = ",";
            if (obj.ReadInterval <= 0) obj.ReadInterval = 1800;
            if (!obj.Name.IsValidLength(1, 200)) throw new Exception(Resources.Error_LoggerNameInvalid);
            if (string.IsNullOrEmpty(obj.DataPath)) throw new Exception("Đường dẫn file data không tồn tại");
            if (!File.Exists(obj.DataPath))
            {
                if (!Directory.Exists(obj.DataPath)) throw new Exception("Đường dẫn thư mục data không tồn tại");
                if (Directory.GetFiles(obj.DataPath).Length == 0) throw new Exception("Thư mục data không có file dữ liệu nào!");
            }
        }

        public bool Insert(Logger obj)
        {
            bool result = false;
            using (var entityConntext = new GeoViewerEntities())
            {
                SecurityBLL.Current.CheckPermissionThrowException(SecurityBLL.ROLE_DATA_MANAGE);
                Validate(obj);
                obj.ProjectID = AppContext.Current.OpenProject.ProjectID;
                obj.CreatedDate = obj.LastEditedDate = DateTime.Now;
                obj.CreatedUser = obj.LastEditedUser = AppContext.Current.LogedInUser.Username;
                entityConntext.Loggers.AddObject(obj);
                result = entityConntext.SaveChanges() > 0;
            }
            // Auto Add Sensor
            if (result)
            {
                DataReaderBLL.Current.ReadHeader(obj.LoggerID);
            }
            //foreach (var sensor in obj.Sensors)
            //{
            //    obj.CreatedDate = obj.LastEditedDate = DateTime.Now;
            //    obj.CreatedUser = obj.LastEditedUser = AppContext.Current.LogedInUser.Username;
            //}
            return result;
        }

        public bool Update(Logger obj)
        {
            bool result = false;
            using (var entityConntext = new GeoViewerEntities())
            {
                SecurityBLL.Current.CheckPermissionThrowException(new[]
                                                                      {
                                                                          SecurityBLL.ROLE_DATA_EDIT,
                                                                          SecurityBLL.ROLE_DATA_MANAGE
                                                                      });
                Validate(obj);
                obj.LastEditedDate = DateTime.Now;
                obj.LastEditedUser = AppContext.Current.LogedInUser.Username;
                entityConntext.AttachUpdatedObject(obj);
                result = entityConntext.SaveChanges() > 0;
            }
            if (result)
            {
                if (!obj.AutomaticReadData)
                {
                    ReaderThreadManager.Current.RemoveThread(obj);
                }
                else
                {
                    ReaderThreadManager.Current.SaveThread(obj);
                }
            }
            return result;
        }

        //public bool Delete(Logger obj)
        //{
        //    SecurityBLL.Current.CheckPermissionThrowException(SecurityBLL.ROLE_DATA_MANAGE);
        //    entityConntext.Loggers.DeleteObject(obj);

        //    DataReaderBLL.Current.RemoveThread(obj);

        //    bool result = entityConntext.SaveChanges() > 0;
        //    return result;
        //}

        public bool Delete(int id)
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                var obj = entityConntext.Loggers.SingleOrDefault(ent => ent.LoggerID == id);
                if (obj != null)
                {
                    ReaderThreadManager.Current.RemoveThread(obj);
                    entityConntext.Loggers.DeleteObject(obj);
                    return entityConntext.SaveChanges() > 0;
                }
                return false;
            }
        }



    }
}
