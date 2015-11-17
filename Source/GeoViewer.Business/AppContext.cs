/* Copyright by ICEA - 2012
 * 
 * Created By Binh.N.D 06/10/2012
 * 
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoViewer.Models;

namespace GeoViewer.Business
{
    public class AppContext
    {
        private static AppContext _current = new AppContext();
        private GeoViewerEntities _entityContext = new GeoViewerEntities();
        private Project _openProject;

        public Project OpenProject
        {
            set { _openProject = value; }
            get
            {
                //if(_openProject == null)
                //{
                //    var list = EntityContext.Projects.Where(ent => ent.IsDefault);
                //    if(list.Count()>0)
                //    {
                //        _openProject = list.First();
                //    }
                //}
                return _openProject;
            }
        }

        public static AppContext Current
        {
            get { return _current; }
        }

        //public GeoViewerEntities EntityContext
        //{
        //    get { return _entityContext; }
        //}

        public Account LogedInUser
        {
            get { return AccountBLL.Current.LogedInUser; }
        }

        public AppContext()
        {
            _entityContext = new GeoViewerEntities();
        }

        //public void RefreshEntityContext()
        //{
        //    _entityContext.Dispose();
        //    _entityContext = new GeoViewerEntities();
        //    if(OpenProject != null)
        //    {
        //        OpenProject = ProjectBLL.Current.GetByID(OpenProject.ProjectID);
        //    }
        //}
    }
}
