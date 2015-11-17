using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GeoViewer.Business.Properties;
using GeoViewer.Models;
using GeoViewer.Utils;

namespace GeoViewer.Business
{
    public class ProjectBLL
    {
        #region Instance Of Class
        private static ProjectBLL _current = new ProjectBLL();
        public static ProjectBLL Current
        {
            get { return _current; }
        }
        #endregion

        public Project GetByID(int id)
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                return entityConntext.Projects.SingleOrDefault(ent => ent.ProjectID == id);
            }
        }

        public void Validate(Project obj)
        {
            if (!obj.Name.IsValidLength(1, 255)) throw new Exception("Tên project không được bỏ trống và nhỏ hơn 255 ký tự.");
        }

        public bool Insert(Project obj)
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                SecurityBLL.Current.CheckPermissionThrowException(SecurityBLL.ROLE_DATA_MANAGE);
                Validate(obj);
                entityConntext.Projects.AddObject(obj);
                return entityConntext.SaveChanges() > 0;
            }
        }

        public bool Update(Project obj)
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                SecurityBLL.Current.CheckPermissionThrowException(new string[]
                                                                      {
                                                                          SecurityBLL.ROLE_DATA_EDIT,
                                                                          SecurityBLL.ROLE_DATA_MANAGE
                                                                      });
                Validate(obj);
                entityConntext.AttachUpdatedObject(obj);
                return entityConntext.SaveChanges() > 0;
            }
        }

        //public bool Delete(Project obj)
        //{
        //    SecurityBLL.Current.CheckPermissionThrowException(SecurityBLL.ROLE_DATA_MANAGE);
        //    // Delete all groups in this project
        //    foreach (var group in obj.Groups.ToList())
        //    {
        //        entityConntext.Groups.DeleteObject(group);
        //    }
        //    entityConntext.Projects.DeleteObject(obj);
        //    bool result = entityConntext.SaveChanges() > 0;
        //    if (result && AppContext.Current.OpenProject.ProjectID == obj.ProjectID)
        //    {
        //        CloseProject();
        //    }
        //    return result;
        //}

        public bool Delete(int id)
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                var obj = entityConntext.Projects.SingleOrDefault(ent => ent.ProjectID == id);
                if (obj != null)
                {
                    // Delete all groups in this project
                    foreach (var group in obj.Groups.ToList())
                    {
                        entityConntext.Groups.DeleteObject(group);
                    }
                    entityConntext.Projects.DeleteObject(obj);
                    bool result = entityConntext.SaveChanges() > 0;
                    if (result && AppContext.Current.OpenProject.ProjectID == obj.ProjectID)
                    {
                        CloseProject();
                    }
                    return result;
                }
                return false;
            }
        }

        public void OpenProject(int id)
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                var obj = entityConntext.Projects.SingleOrDefault(ent => ent.ProjectID == id);
                if (obj != null)
                {
                    AppContext.Current.OpenProject = obj;
                    foreach (var pro in entityConntext.Projects)
                    {
                        pro.IsDefault = false;
                    }
                    obj.IsDefault = true;
                    entityConntext.SaveChanges();
                }
            }
        }

        public void CloseProject()
        {
            AppContext.Current.OpenProject = null;
        }
    }
}
