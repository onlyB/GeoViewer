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
    public class SensorBLL
    {
        #region Instance Of Class
        private static SensorBLL _current = new SensorBLL();
        public static SensorBLL Current
        {
            get { return _current; }
        }
        #endregion

        public Sensor GetByID(int id)
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                return entityConntext.Sensors.SingleOrDefault(ent => ent.SensorID == id);
            }
        }

        public void Validate(Sensor obj)
        {
            if (obj.MinValue != null && obj.MaxValue != null && obj.MinValue >= obj.MaxValue) throw new Exception(Resources.Error_SetAlarmInvalid);
            if (obj.AlarmEnabled && obj.MaxValue == null && obj.MinValue == null) throw new Exception(Resources.Error_SetAlarmInvalid);
            if (!obj.Name.IsValidLength(1, 200)) throw new Exception(Resources.Error_SensorNameInvalid);
            if (!obj.Description.IsValidLength(-1, 500)) throw new Exception(Resources.Error_SensorDescriptionInvalid);
        }

        public bool Insert(Sensor obj)
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                SecurityBLL.Current.CheckPermissionThrowException(SecurityBLL.ROLE_DATA_MANAGE);
                Validate(obj);
                if (AppContext.Current.OpenProject != null) obj.ProjectID = AppContext.Current.OpenProject.ProjectID;
                obj.CreatedDate = obj.LastEditedDate = DateTime.Now;
                obj.CreatedUser = obj.LastEditedUser = AppContext.Current.LogedInUser.Username;
                entityConntext.Sensors.AddObject(obj);
                return entityConntext.SaveChanges() > 0;
            }
        }

        public bool Update(Sensor obj)
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                SecurityBLL.Current.CheckPermissionThrowException(new string[]
                                                                      {
                                                                          SecurityBLL.ROLE_DATA_EDIT,
                                                                          SecurityBLL.ROLE_DATA_MANAGE
                                                                      });
                Validate(obj);
                obj.LastEditedDate = DateTime.Now;
                obj.LastEditedUser = AppContext.Current.LogedInUser.Username;
                entityConntext.AttachUpdatedObject(obj);
                return entityConntext.SaveChanges() > 0;
            }
        }

        //public bool Delete(Sensor obj)
        //{
        //    SecurityBLL.Current.CheckPermissionThrowException(SecurityBLL.ROLE_DATA_MANAGE);
        //    entityConntext.Sensors.DeleteObject(obj);
        //    return entityConntext.SaveChanges() > 0;
        //}

        public bool Delete(int id)
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                var obj = entityConntext.Sensors.SingleOrDefault(ent => ent.SensorID == id);
                if(obj != null)
                {
                    entityConntext.Sensors.DeleteObject(obj);
                    return entityConntext.SaveChanges() > 0;
                }
                return false;
            }
        }

        public string GetFomullaFunction(Sensor sensor)
        {
            if (!string.IsNullOrEmpty(sensor.FormulaFunction))
            {
                return sensor.FormulaFunction;
            }
            List<String> parameters = sensor.FunctionParameters.SplitToList('#');
            switch (sensor.FormulaType)
            {
                case CalculationBLL.FORMULA_LINEAR:
                    if (parameters.Count < 2) return "";
                    return string.Format("Xo = {0} + {1}*Vi", parameters[0], parameters[1]);
                case CalculationBLL.FORMULA_ARCTOLENGTH_DEGREE:
                    break;

                case CalculationBLL.FORMULA_ARCTOLENGTH_RADIAN:
                    break;

                case CalculationBLL.FORMULA_POLYNOMIAL:
                    break;

                case CalculationBLL.FORMULA_TEMPRATURE_COMP:
                    break;

                case CalculationBLL.FORMULA_VW_LINEAR:
                    break;
                case CalculationBLL.FORMULA_VW_POLY:
                    break;
                case CalculationBLL.FORMULA_USER_DEFINED:
                    return sensor.FormulaFunction;

            }
            {

            }
            return "";
        }
    }
}
