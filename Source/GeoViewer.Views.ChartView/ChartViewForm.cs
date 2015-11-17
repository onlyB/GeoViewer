using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GeoViewer.Business;
using GeoViewer.Models;
using ZedGraph;

namespace GeoViewer.Views.ChartView
{
    public partial class ChartViewForm : BaseWindowForm
    {
        #region Private Field

        private Sensor _sensor;
        private Group _group;
        private PictureView _pictureView;
        private DateTime? _startDate;
        private DateTime? _endDate;
        private string _chartName;
        private string _xLabel;
        private string _yLabel;
        private bool _showCalcValue;

        #endregion

        /// <summary>
        /// Pass params to build the chart on start up, set null (is default) for nothing display
        /// </summary>
        /// <param name="sensor"></param>
        /// <param name="group"></param>
        /// <param name="pictureView"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="chartName"></param>
        /// <param name="xLabel"></param>
        /// <param name="yLabel"></param>
        /// <param name="showCalcValue"></param>
        public ChartViewForm(Sensor sensor = null, Group group = null, PictureView pictureView = null, DateTime? startDate = null,
                             DateTime? endDate = null, string chartName = "Chart View", string xLabel = "Value", string yLabel = "Datetime", bool showCalcValue = true)
        {
            // set value to private field
            _sensor = sensor;
            _group = group;
            // ...
            // continue here
            InitializeComponent();
            GraphPane myPane;
            LineItem mycurve;
            Random randomGen = new Random();
            myPane = zedChartMain.GraphPane;
            myPane.XAxis.Type = AxisType.Date;
            myPane.XAxis.Scale.Format = "HH:mm:ss\ndd-MM-yyyy";
            myPane.Title.Text = chartName;
            myPane.XAxis.Title.Text = xLabel;
            myPane.YAxis.Title.Text = yLabel;
            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MajorGrid.IsVisible = true;


            if (sensor != null)
            {
                List<SensorValue> listvalue = entityConntext.SensorValues.Where(ent => ent.SensorID == sensor.SensorID).ToList();
                DataSourcePointList dsp = new DataSourcePointList();
                dsp.DataSource = listvalue;
                if (!showCalcValue)
                {
                    dsp.YDataMember = "RawValue";
                }
                if (showCalcValue)
                {
                    dsp.YDataMember = "CalcValue";
                }
                dsp.XDataMember = "MeaTime";

                mycurve = myPane.AddCurve(sensor.Name, dsp, Color.FromArgb(randomGen.Next(255), randomGen.Next(255), randomGen.Next(255)));
                mycurve.Line.Width = 1;
            }
           

            if (group != null)
            {               
                List<Sensor> sensorsInGroup = group.Sensors.ToList();
                for (int i = 0; i < sensorsInGroup.Count; i++)
                {
                    int idsen = Convert.ToInt16(sensorsInGroup[i].SensorID);
                    List<SensorValue> listvalue = entityConntext.SensorValues.Where(ent => ent.SensorID == idsen).ToList();

                    DataSourcePointList dsp = new DataSourcePointList();
                    dsp.DataSource = listvalue;
                    if (!showCalcValue)
                    {
                        dsp.YDataMember = "RawValue";
                    }
                    if (showCalcValue)
                    {
                        dsp.YDataMember = "CalcValue";
                    }
                    dsp.XDataMember = "MeaTime";

                    mycurve = myPane.AddCurve(sensorsInGroup[i].Name, dsp, Color.FromArgb(randomGen.Next(255), randomGen.Next(255), randomGen.Next(255)));
                    mycurve.Line.Width = 1;

                }
            }

            //lenh hien thi chart
            zedChartMain.IsShowPointValues = true;
            zedChartMain.AxisChange();
            zedChartMain.Invalidate();
            zedChartMain.Refresh();

        }

        private void ChartViewForm_Load(object sender, EventArgs e)
        {
           
        }

       
    }
}
