/* Copyright by ICEA - 2012
 * 
 * Created By Binh.N.D 06/10/2012
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoViewer.Business.Properties;
using GeoViewer.Models;
using GeoViewer.Utils;

namespace GeoViewer.Business
{
    public class ChartViewBLL
    {
        #region Instance Of Class
        private static ChartViewBLL _current = new ChartViewBLL();
        public static ChartViewBLL Current
        {
            get { return _current; }
        }
        #endregion

        #region Sensor Group
        public Group GetGroupByID(int id)
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                return entityConntext.Groups.SingleOrDefault(ent => ent.GroupID == id);
            }
        }
        public Group GetGroupByID(int id, GeoViewerEntities entitiesContext)
        {

            return entitiesContext.Groups.SingleOrDefault(ent => ent.GroupID == id);

        }
        public void ValidateGroup(Group obj)
        {
            if (!obj.Name.IsValidLength(1, 200)) throw new Exception(Resources.Error_GroupNameInvalid);
        }

        public bool InsertGroup(Group obj)
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                SecurityBLL.Current.CheckPermissionThrowException(SecurityBLL.ROLE_VIEWS_MANAGE);
                ValidateGroup(obj);
                obj.ProjectID = AppContext.Current.OpenProject.ProjectID;
                obj.CreatedDate = obj.LastEditedDate = DateTime.Now;
                obj.CreatedUser = obj.LastEditedUser = AppContext.Current.LogedInUser.Username;
                entityConntext.Groups.AddObject(obj);
                return entityConntext.SaveChanges() > 0;
            }
        }

        public bool UpdateGroup(Group obj)
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                SecurityBLL.Current.CheckPermissionThrowException(new string[]
                                                                      {
                                                                          SecurityBLL.ROLE_VIEWS_EDIT,
                                                                          SecurityBLL.ROLE_VIEWS_MANAGE
                                                                      });
                ValidateGroup(obj);
                obj.LastEditedDate = DateTime.Now;
                obj.LastEditedUser = AppContext.Current.LogedInUser.Username;
                entityConntext.AttachUpdatedObject(obj);
                return entityConntext.SaveChanges() > 0;
            }
        }

        //public bool DeleteGroup(Group obj)
        //{
        //    using (var entityConntext = new GeoViewerEntities())
        //    {
        //        SecurityBLL.Current.CheckPermissionThrowException(SecurityBLL.ROLE_VIEWS_MANAGE);
        //        entityConntext.Groups.DeleteObject(obj);
        //        return entityConntext.SaveChanges() > 0;
        //    }
        //}

        public bool DeleteGroup(int id)
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                var obj = entityConntext.Groups.SingleOrDefault(ent => ent.GroupID == id);
                if (obj != null)
                {
                    entityConntext.Groups.DeleteObject(obj);
                    return entityConntext.SaveChanges() > 0;
                }
                return false;
            }
        }
        #endregion
    }
}
