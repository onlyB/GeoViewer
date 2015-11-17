/* Copyright by ICEA - 2012
 * 
 * Created By Binh.N.D 06/10/2012
 * 
 * Update By Binh.N.D 07/10/2012
 * - Updated note
 * - Updated Note
 * Update By Binh.N.D 08/10/2012
 * - Updated note
 * - Updated Note
 *      
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using GeoViewer.Business.Properties;
using GeoViewer.Models;
using GeoViewer.Utils;
namespace GeoViewer.Business
{
    public partial class AlarmBLL
    {
        #region Instance Of Class
        private static AlarmBLL _current = new AlarmBLL();
        public static AlarmBLL Current
        {
            get { return _current; }
        }
        #endregion

        public DateTime? GetLastTime()
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                var last = entityConntext.AlarmLogs.OrderByDescending(ent => ent.StartAlarmDatetime).FirstOrDefault();
                if (last != null)
                    return last.StartAlarmDatetime;
                return null;
            }
        } 
        public AlarmLog GetByID(long id)
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                return entityConntext.AlarmLogs.SingleOrDefault(ent => ent.AlarmLogID == id);
            }
        }

        public void Validate(AlarmLog obj)
        {
            if (!obj.Title.IsValidLength(1, 200)) throw new Exception(Resources.Error_AlarmLogTitleInvalid);
            if (!obj.Note.IsValidLength(-1, 500)) throw new Exception(Resources.Error_AlarmLogNoteInvalid);
        }

        public bool Insert(AlarmLog obj)
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                Validate(obj);
                if (AppContext.Current.OpenProject != null) obj.ProjectID = AppContext.Current.OpenProject.ProjectID;
                obj.IsEnded = false;
                entityConntext.AlarmLogs.AddObject(obj);
                return entityConntext.SaveChanges() > 0;
            }
        }

        public bool Update(AlarmLog obj)
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                SecurityBLL.Current.CheckPermissionThrowException(new string[]
                                                                      {
                                                                          SecurityBLL.ROLE_ALARM_EDIT,
                                                                          SecurityBLL.ROLE_ALARM_MANAGE
                                                                      });
                Validate(obj);
                obj.LastEditedDate = DateTime.Now;
                obj.LastEditedUser = AppContext.Current.LogedInUser.Username;
                entityConntext.AttachUpdatedObject(obj);
                return entityConntext.SaveChanges() > 0;
            }
        }

        //public bool Delete(AlarmLog obj)
        //{
        //    using (var entityConntext = new GeoViewerEntities())
        //    {
        //        SecurityBLL.Current.CheckPermissionThrowException(SecurityBLL.ROLE_ALARM_MANAGE);
        //        entityConntext.AttachUpdatedObject(obj, EntityState.Deleted);
        //        return entityConntext.SaveChanges() > 0;
        //    }
        //}

        public bool Delete(long id)
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                var obj = entityConntext.AlarmLogs.SingleOrDefault(ent => ent.AlarmLogID == id);
                if (obj != null)
                {
                    entityConntext.AlarmLogs.DeleteObject(obj);
                    return entityConntext.SaveChanges() > 0;
                }
                return false;
            }
        }

        public bool Delete(long[] ids)
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                //SecurityBLL.Current.CheckPermissionThrowException(SecurityBLL.ROLE_ALARM_MANAGE);
                foreach (var id in ids)
                {
                    var obj = entityConntext.AlarmLogs.SingleOrDefault(ent => ent.AlarmLogID == id);
                    if (obj != null)
                        entityConntext.AlarmLogs.DeleteObject(obj);
                }

                return entityConntext.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// Get list of alarm logs by conditions, pass parameters null for select all (no condition)
        /// </summary>
        /// <param name="sensor">only select alarm logs for this sensor</param>
        /// <param name="startDate">select alarm logs from start date</param>
        /// <param name="endDate">select alarm logs to end date</param>
        /// <param name="isEnded">select alarm logs which marked IsEnded = true or fasle</param>
        /// <param name="start">started record</param>
        /// <param name="limit">number of record will return</param>
        /// <returns></returns>
        public List<AlarmLog> GetByConditions(Sensor sensor = null, DateTime? startDate = null, DateTime? endDate = null, bool? isEnded = null, int start = -1, int limit = -1)
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                int? sensorID = sensor == null ? null : (int?)sensor.SensorID;

                var result = entityConntext.AlarmLogs.Where(ent =>
                                                            (sensorID == null || ent.SensorID == sensorID) &&
                                                            (startDate == null || ent.StartAlarmDatetime >= startDate) &&
                                                            (endDate == null || ent.StartAlarmDatetime <= endDate) &&
                                                            (isEnded == null || ent.IsEnded == isEnded)
                    ).OrderByDescending(ent => ent.StartAlarmDatetime).ThenByDescending(ent => ent.AlarmLogID);
                if (start >= 0 && limit > 0)
                {
                    return result.Skip(start).Take(limit).ToList();
                }
                return result.ToList();
            }
        }

        /// <summary>
        /// Check sensor value and auto add alarm log if it is out of range.
        /// Non auto save changed to database, you must call entityConntext.SaveChanges() to save changed.
        /// </summary>
        /// <param name="sensorValue"></param>
        /// <returns></returns>
        public bool CheckAlarm(SensorValue sensorValue)
        {
            var sensor = sensorValue.Sensor;
            if (sensor.AlarmEnabled)
            {
                if ((sensor.MinValue != null && sensor.MinValue > sensorValue.CalcValue) || (sensor.MaxValue != null && sensor.MaxValue < sensorValue.CalcValue))
                {
                    if (sensor.AlarmFlag)
                    {
                        var lastAlarm =
                           sensor.AlarmLogs.LastOrDefault(
                               ent => !ent.IsEnded && ent.StartAlarmDatetime <= sensorValue.MeaTime);
                        if (lastAlarm == null || lastAlarm.CalcValue == sensorValue.CalcValue)
                        {
                            return false;
                        }
                    }
                    // Add Alarm
                    var alarm = new AlarmLog();
                    alarm.SensorID = sensor.SensorID;
                    // Set project ID
                    alarm.ProjectID = sensor.ProjectID;

                    alarm.CalcValue = sensorValue.CalcValue;
                    alarm.IsEnded = false;
                    alarm.StartAlarmDatetime = sensorValue.MeaTime;
                    alarm.Title = sensor.Logger.Name + " - " + sensor.Name;
                    // Edited by binhpro 23/11/2012
                    decimal range = sensor.MaxValue.Value - sensor.MinValue.Value;
                    if (range == 0) range = sensor.MaxValue.Value;

                    if (alarm.CalcValue < sensor.MinValue && range != 0)
                    {
                        alarm.Title += " - dưới ngưỡng " + Math.Round(Math.Abs((decimal)((sensor.MinValue - alarm.CalcValue) / range * 100)), 0) + " %";
                    }
                    else if (alarm.CalcValue > sensor.MaxValue && range != 0)
                    {
                        alarm.Title += " - vượt ngưỡng " + Math.Round(Math.Abs((decimal)((alarm.CalcValue - sensor.MaxValue) / range * 100)), 0) + " %";
                    }
                    alarm.Title += " - " + alarm.StartAlarmDatetime;
                    // Set Alarm Flag Of Sensor TRUE
                    sensor.AlarmFlag = true;
                    sensor.AlarmLogs.Add(alarm);
                    return true;
                }
                if (sensor.AlarmFlag)
                {
                    // Set Alarm Flag Of Sensor FALSE
                    sensor.AlarmFlag = false;
                    // Close All Alarm Log Before
                    var logs =
                        sensor.AlarmLogs.Where(ent => !ent.IsEnded && ent.StartAlarmDatetime <= sensorValue.MeaTime);
                    foreach (var alarmLog in logs)
                    {
                        alarmLog.IsEnded = true;
                        alarmLog.EndAlarmDatetime = sensorValue.MeaTime;
                    }
                    // entityConntext.SaveChanges();
                }
                return false;
            }
            return false;
        }
    }
}
