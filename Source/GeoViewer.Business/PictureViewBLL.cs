/* Copyright by ICEA - 2012
 * 
 * Created By Binh.N.D 06/10/2012
 * 
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using GeoViewer.Business.Properties;
using GeoViewer.Models;
using GeoViewer.Utils;

namespace GeoViewer.Business
{
    public class PictureViewBLL
    {
        #region Instance Of Class
        private static PictureViewBLL _current = new PictureViewBLL();
        public static PictureViewBLL Current
        {
            get { return _current; }
        }
        #endregion

        #region contanst values
        public const int OBJECT_TYPE_INDICATOR = 1;
        public const int OBJECT_TYPE_GAUGE = 4;
        public const int OBJECT_TYPE_VERTICAL_BAR = 5;
        public const int OBJECT_TYPE_HORIZONTAL_BAR = 6;
        public const int OBJECT_TYPE_GROUP_INDICATOR = 2;
        public const int OBJECT_TYPE_IMAGE = 3;
        public const int OBJECT_TYPE_METTER = 7;
        public const int OBJECT_TYPE_NUMERIC_INDICATOR = 8;
        #endregion

        #region Validate, Insert,Update,Delete PictureView

        public PictureView GetByID(int id)
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                return entityConntext.PictureViews.SingleOrDefault(ent => ent.PictureViewID == id);
            }
        }

        public void Validate(PictureView obj)
        {
            if (!obj.Name.IsValidLength(1, 200)) throw new Exception(Resources.Error_PictureNameInvalid);
            if (!obj.Description.IsValidLength(-1, 500)) throw new Exception(Resources.Error_PictureDescriptionInvalid);
        }

        public bool Insert(PictureView obj)
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                SecurityBLL.Current.CheckPermissionThrowException(SecurityBLL.ROLE_VIEWS_MANAGE);
                Validate(obj);
                obj.ProjectID = AppContext.Current.OpenProject.ProjectID;
                obj.CreatedDate = obj.LastEditedDate = DateTime.Now;
                obj.CreatedUser = obj.LastEditedUser = AppContext.Current.LogedInUser.Username;
                entityConntext.PictureViews.AddObject(obj);
                return entityConntext.SaveChanges() > 0;
            }
        }

        public bool Update(PictureView obj)
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                SecurityBLL.Current.CheckPermissionThrowException(new string[]
                                                                      {
                                                                          SecurityBLL.ROLE_VIEWS_EDIT,
                                                                          SecurityBLL.ROLE_VIEWS_MANAGE
                                                                      });
                Validate(obj);
                obj.LastEditedDate = DateTime.Now;
                obj.LastEditedUser = AppContext.Current.LogedInUser.Username;
                entityConntext.AttachUpdatedObject(obj);
                return entityConntext.SaveChanges() > 0;
            }
        }

        //public bool Delete(PictureView obj)
        //{
        //    SecurityBLL.Current.CheckPermissionThrowException(SecurityBLL.ROLE_VIEWS_MANAGE);
        //    entityConntext.PictureViews.DeleteObject(obj);
        //    return entityConntext.SaveChanges() > 0;
        //}

        public bool Delete(int id)
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                var obj = entityConntext.PictureViews.SingleOrDefault(ent => ent.PictureViewID == id);
                if (obj != null)
                {
                    entityConntext.PictureViews.DeleteObject(obj);
                    return entityConntext.SaveChanges() > 0;
                }
                return false;
            }
        }

        #endregion

        #region PictureView Object
        public Models.Object GetObjectByID(int id)
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                return entityConntext.Objects.SingleOrDefault(ent => ent.ObjectID == id);
            }
        }

        public void ValidateObject(Models.Object obj)
        {
            if (obj.Width <= 0) obj.Width = 100;
            if (obj.Height <= 0) obj.Height = 100;
        }

        public bool InsertObject(Models.Object obj)
        {
            bool result = false;
            using (var entityConntext = new GeoViewerEntities())
            {
                SecurityBLL.Current.CheckPermissionThrowException(SecurityBLL.ROLE_VIEWS_MANAGE);
                ValidateObject(obj);
                obj.CreatedDate = obj.LastEditedDate = DateTime.Now;
                obj.CreatedUser = obj.LastEditedUser = AppContext.Current.LogedInUser.Username;
                entityConntext.Objects.AddObject(obj);
                result = entityConntext.SaveChanges() > 0;
            }
            if (obj.Type == OBJECT_TYPE_IMAGE && obj.ObjectID > 0)
            {
                string imagePath = PictureViewBLL.Current.CopyImageFile(obj.Parameters, obj.ObjectID);
                obj.Parameters = imagePath;
                UpdateObject(obj);
            }
            return result;
        }

        public bool UpdateObject(Models.Object obj)
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                SecurityBLL.Current.CheckPermissionThrowException(new string[]
                                                                      {
                                                                          SecurityBLL.ROLE_VIEWS_EDIT,
                                                                          SecurityBLL.ROLE_VIEWS_MANAGE
                                                                      });
                ValidateObject(obj);
                obj.LastEditedDate = DateTime.Now;
                obj.LastEditedUser = AppContext.Current.LogedInUser.Username;
                entityConntext.AttachUpdatedObject(obj);
                return entityConntext.SaveChanges() > 0;
            }
        }

        //public bool DeleteObject(Models.Object obj)
        //{
        //    SecurityBLL.Current.CheckPermissionThrowException(SecurityBLL.ROLE_VIEWS_MANAGE);
        //    entityConntext.Objects.DeleteObject(obj);
        //    int result = entityConntext.SaveChanges();
        //    if (result > 0 && obj.Type == OBJECT_TYPE_IMAGE)
        //    {
        //        // Delete image file
        //        if (File.Exists(obj.Parameters))
        //        {
        //            File.Delete(obj.Parameters);
        //        }
        //    }
        //    return result > 0;
        //}

        public bool DeleteObject(int id)
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                bool result = false;
                var obj = entityConntext.Objects.SingleOrDefault(ent => ent.ObjectID == id);
                if (obj != null)
                {
                    entityConntext.Objects.DeleteObject(obj);
                    result = entityConntext.SaveChanges() > 0;
                }

                if (result && obj.Type == OBJECT_TYPE_IMAGE)
                {
                    // Delete image file
                    if (File.Exists(obj.Parameters))
                    {
                        File.Delete(obj.Parameters);
                    }
                }
                return result;
            }
        }
        #endregion

        /// <summary>
        /// Check the sensor corressponding to picture view object has running alarm?  
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool CheckAlarmRunning(Models.Object obj)
        {
            using (var entityContext = new GeoViewerEntities())
            {
                if (obj.Type == OBJECT_TYPE_IMAGE) return false;
                if (obj.Type != OBJECT_TYPE_GROUP_INDICATOR)
                {
                    // Parameters contain id of sensor which will be displayed
                    int sensorID = obj.Parameters.ToInt32TryParse();
                    var sensor = entityContext.Sensors.SingleOrDefault(ent => ent.SensorID == sensorID);
                    if (sensor == null) return false;
                    return sensor.AlarmEnabled && sensor.AlarmFlag;
                }
                // Get picture view corressponding to this object (type OBJECT_TYPE_GROUP_INDICATOR)
                int pictureID = obj.Parameters.ToInt32TryParse();
                var pictureView = entityContext.PictureViews.SingleOrDefault(ent => ent.PictureViewID == pictureID);
                if (pictureView != null)
                {
                    foreach (var viewObject in pictureView.Objects)
                    {
                        // Fix circle recursive
                        if (viewObject.ObjectID == obj.ObjectID) return false;

                        if (CheckAlarmRunning(viewObject))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// Get list of sensors which displayed in this picture view
        /// </summary>
        /// <param name="pictureView"></param>
        /// <returns></returns>
        public List<Sensor> GetSensorsInPictureView(PictureView pictureView)
        {
            using (var entityContext = new GeoViewerEntities())
            {
                var sensors = new List<Sensor>();
                foreach (var obj in entityContext.Objects.Where(ent => ent.PictureViewID == pictureView.PictureViewID && ent.Type != OBJECT_TYPE_GROUP_INDICATOR && ent.Type != OBJECT_TYPE_IMAGE))
                {
                    var sensor = SensorBLL.Current.GetByID(obj.Parameters.ToInt32TryParse());
                    if (sensor != null && !sensors.Contains(sensor)) sensors.Add(sensor);
                }
                return sensors;
            }
        }

        public List<int> GetParentPictureIDs(PictureView pictureView)
        {
            var parentIDs = new List<int>();

            return parentIDs;
        }

        public string CopyImageFile(string sourceFile, int imageID)
        {
            string extention = sourceFile.Substring(sourceFile.LastIndexOf("."));
            DirectoryInfo defaultDir = new DirectoryInfo("Pictures");
            if (!defaultDir.Exists)
            {
                defaultDir.Create();
            }
            string destinaitonPath = defaultDir.FullName + "/" + imageID + extention;
            File.Copy(sourceFile, destinaitonPath, true);
            return destinaitonPath;
        }
    }
}
