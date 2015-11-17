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
using System.Data;

namespace GeoViewer.Business
{
    public class TextViewBLL
    {
        #region Instance Of Class
        private static TextViewBLL _current = new TextViewBLL();
        public static TextViewBLL Current
        {
            get { return _current; }
        }
        #endregion

        public void ExportToFile(Sensor[] sensors, string filePath)
        {

        }

        private string GetColumnName(Sensor sensor)
        {
            return sensor.SensorID + "-" + sensor.Name + " (" + sensor.Unit + ")";
        }

        public DataTable BindToDataTable(List<Sensor> sensors, bool rawValue = true, DateTime? startDate = null, DateTime? endDate = null)
        {
            // fix datetime
            if (startDate != null)
            {
                startDate = new DateTime(startDate.Value.Year, startDate.Value.Month, startDate.Value.Day, 0, 0, 0);
            }
            if (endDate != null)
            {
                endDate = new DateTime(endDate.Value.Year, endDate.Value.Month, endDate.Value.Day, 23, 59, 59);
            }

            using (var entityContext = new GeoViewerEntities())
            {

                DataTable table = new DataTable();
                if (sensors == null) return table;
                var col = table.Columns.Add("MeaTime", typeof(DateTime));
                table.PrimaryKey = new DataColumn[] { col };

                foreach (var sensor in sensors)
                {
                    table.Columns.Add(GetColumnName(sensor), typeof(string));
                }
                foreach (var sensor in sensors)
                {
                    foreach (var value in entityContext.SensorValues.Where(ent => ent.SensorID == sensor.SensorID &&
                                                                    (startDate == null || ent.MeaTime >= startDate) &&
                                                                    (endDate == null || ent.MeaTime <= endDate)
                        ).ToList())
                    {
                        var row = table.Rows.Find(value.MeaTime);
                        if (row == null)
                        {
                            row = table.NewRow();
                            row["MeaTime"] = value.MeaTime;
                            row[GetColumnName(sensor)] = rawValue ? value.RawValue : value.CalcValue;
                            table.Rows.Add(row);
                        }
                        else
                        {
                            row[GetColumnName(sensor)] = rawValue ? value.RawValue : value.CalcValue;
                        }
                    }
                }
                return table;
            }
        }
    }
}
