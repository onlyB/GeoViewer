using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GeoViewer.Business;
using GeoViewer.Models;
using GeoViewer.Utils;
using GeoViewer.Views.ChartView;
using GeoViewer.Views.PictureView.Properties;
using GeoViewer.Views.TextView;
using System.Threading;

namespace GeoViewer.Views.PictureView
{
    public partial class PictureViewDetailForm : BaseWindowForm
    {
        private Models.PictureView _pictureView;
        private Models.PictureView _nextPictureView = null;
        private Models.PictureView _prePictureView = null;
        private Control currentCtrl;
        private Control currentRightClickCtrl = null;
        private PickBox pb = new PickBox();
        private bool _displayRawValue = false;

        private Bitmap _screenShoot;

        /// <summary>
        /// Constructor with required PictureView parameter
        /// </summary>
        /// <param name="pictureView">PictureView object to show</param>
        public PictureViewDetailForm(Models.PictureView pictureView, bool displayRawValue = false)
        {
            //_pictureView = entityConntext.PictureViews.SingleOrDefault(ent => ent.PictureViewID == pictureView.PictureViewID);
            _pictureView = PictureViewBLL.Current.GetByID(pictureView.PictureViewID);
            _displayRawValue = displayRawValue;

            InitializeComponent();
            // next, previous picture view
            var nextList = entityConntext.PictureViews.Where(ent => ent.ProjectID == AppContext.Current.OpenProject.ProjectID && ent.PictureViewID > _pictureView.PictureViewID).OrderBy(ent => ent.PictureViewID).Take(1).ToList();
            if (nextList.Count > 0)
            {
                _nextPictureView = nextList.First();
                nextToolStripMenuItem.Enabled = true;
            }

            var preList = entityConntext.PictureViews.Where(ent => ent.ProjectID == AppContext.Current.OpenProject.ProjectID && ent.PictureViewID < _pictureView.PictureViewID).OrderByDescending(ent => ent.PictureViewID).Take(1).ToList();
            if (preList.Count > 0)
            {
                _prePictureView = preList.First();
                previousToolStripMenuItem.Enabled = true;
            }

            //Load objects
            LoadPicture(pictureView);

        }

        #region Load Picture
        private void LoadPicture(Models.PictureView pictureView)
        {
            try
            {
                panel.Controls.Clear();
                this.Text = pictureView.Name;
                // Linq to entities
                var objectlist = entityConntext.Objects.Where(ent => ent.PictureViewID == pictureView.PictureViewID).OrderBy(ent => ent.Z_Index);
                foreach (GeoViewer.Models.Object obj in objectlist)
                {
                    switch (obj.Type)
                    {
                        case 1: // Indicator
                            // Indicator Intitialization
                            indicator ind = new indicator();
                            ind.Location = new System.Drawing.Point(obj.X, obj.Y);
                            ind.Size = new System.Drawing.Size(obj.Width, obj.Height);
                            ind.FillColor = System.Drawing.Color.Lime;
                            ind.AccessibleName = obj.ObjectID.ToString();
                            ind.AccessibleDescription = "1";
                            // Get sensor name + unit + value
                            int sensorId = Convert.ToInt32(obj.Parameters);
                            var sensor = SensorBLL.Current.GetByID(sensorId);
                            Models.SensorValue sensorValue = new SensorValue();
                            if (sensor != null)
                            {
                                // Associate with sensor
                                // Add tooltip display description - binhpro 27/02/2013
                                if (!string.IsNullOrEmpty(sensor.Description))
                                {
                                    toolTip1.SetToolTip(ind, "Công thức: " + sensor.FormulaFunction + "\n" + sensor.Description);
                                }

                                ind.VarName = sensor.Name;
                                ind.UnitName = sensor.Unit;
                                if (entityConntext.SensorValues.
                                    Where(ent => ent.SensorID == sensorId).OrderByDescending(ent => ent.MeaTime).Count() > 0)
                                {
                                    sensorValue = entityConntext.SensorValues.
                                        Where(ent => ent.SensorID == sensorId).OrderByDescending(ent => ent.MeaTime).First();
                                    ind.Value = getDisplayValue(sensorValue);
                                    // Check if value is in alarm level
                                    if (PictureViewBLL.Current.CheckAlarmRunning(obj)) ind.FillColor = System.Drawing.Color.Red;
                                }
                            }
                            // Add to picture
                            this.panel.Controls.Add(ind);
                            ind.BringToFront();
                            break;
                        case 2: // Group Indicator
                            // Group Indicator Initialization
                            groupIndicator i = new groupIndicator();
                            i.Location = new System.Drawing.Point(obj.X, obj.Y);
                            i.Size = new System.Drawing.Size(obj.Width, obj.Height);
                            i.FillColor = System.Drawing.Color.Lime;
                            i.BackColor = System.Drawing.Color.Transparent;
                            i.AccessibleName = obj.ObjectID.ToString();
                            i.AccessibleDescription = "2";
                            // Check if value is in alarm level
                            //int idPicture = Convert.ToInt32(obj.Parameters);
                            //var subObjectList = entityConntext.Objects.
                            //    Where(ent => ent.PictureViewID == idPicture);
                            //foreach (GeoViewer.Models.Object subObject in subObjectList)
                            //{
                            //    if (PictureViewBLL.Current.CheckAlarmRunning(subObject))
                            //    {
                            //        i.FillColor = Color.Red;
                            //        break;
                            //    }
                            //}

                            //Edited By binhpro 18/10/2012
                            if (PictureViewBLL.Current.CheckAlarmRunning(obj))
                            {
                                i.FillColor = Color.Red;
                            }

                            // Add to picture  
                            this.panel.Controls.Add(i);
                            i.BringToFront();
                            break;
                        case 3: // Image
                            // Image Initialization
                            System.Windows.Forms.PictureBox newpicture = new System.Windows.Forms.PictureBox();
                            newpicture.Location = new System.Drawing.Point(obj.X, obj.Y);
                            newpicture.ImageLocation = obj.Parameters;
                            newpicture.Size = new System.Drawing.Size(obj.Width, obj.Height);
                            newpicture.SizeMode = PictureBoxSizeMode.StretchImage;
                            newpicture.AccessibleName = obj.ObjectID.ToString();
                            newpicture.AccessibleDescription = "3";
                            // Add to picture
                            this.panel.Controls.Add(newpicture);
                            newpicture.BringToFront();
                            break;
                        case 4: // Gauge
                            // Gauge Initilization
                            Dundas.Gauges.WinControl.GaugeContainer gaugeContainer = new Dundas.Gauges.WinControl.GaugeContainer();
                            Dundas.Gauges.WinControl.CircularGauge circularGauge = new Dundas.Gauges.WinControl.CircularGauge();
                            Dundas.Gauges.WinControl.CircularPointer circularPointer = new Dundas.Gauges.WinControl.CircularPointer();
                            Dundas.Gauges.WinControl.CircularScale circularScale = new Dundas.Gauges.WinControl.CircularScale();
                            Dundas.Gauges.WinControl.GaugeLabel gaugeLabel = new Dundas.Gauges.WinControl.GaugeLabel();
                            gaugeContainer.BackFrame.BackColor = System.Drawing.Color.Transparent;
                            gaugeContainer.BackFrame.BackGradientEndColor = System.Drawing.Color.Transparent;
                            gaugeContainer.BackFrame.BackGradientType = Dundas.Gauges.WinControl.GradientType.None;
                            gaugeContainer.BackFrame.FrameColor = System.Drawing.Color.Transparent;
                            gaugeContainer.BackFrame.FrameGradientEndColor = System.Drawing.Color.Transparent;
                            gaugeContainer.BackFrame.FrameGradientType = Dundas.Gauges.WinControl.GradientType.None;
                            gaugeContainer.BackFrame.FrameShape = Dundas.Gauges.WinControl.BackFrameShape.AutoShape;
                            gaugeContainer.BackFrame.FrameStyle = Dundas.Gauges.WinControl.BackFrameStyle.Edged;
                            gaugeContainer.BackFrame.FrameWidth = 0F;
                            circularGauge.BackFrame.BackColor = System.Drawing.Color.White;
                            circularGauge.BackFrame.BackGradientEndColor = System.Drawing.Color.White;
                            circularGauge.BackFrame.BackGradientType = Dundas.Gauges.WinControl.GradientType.None;
                            circularGauge.BackFrame.BorderColor = System.Drawing.Color.Gray;
                            circularGauge.BackFrame.BorderWidth = 2;
                            circularGauge.BackFrame.FrameColor = System.Drawing.Color.Transparent;
                            circularGauge.BackFrame.FrameGradientEndColor = System.Drawing.Color.Transparent;
                            circularGauge.BackFrame.FrameGradientType = Dundas.Gauges.WinControl.GradientType.None;
                            circularGauge.BackFrame.FrameShape = Dundas.Gauges.WinControl.BackFrameShape.Rectangular;
                            circularGauge.BackFrame.FrameStyle = Dundas.Gauges.WinControl.BackFrameStyle.Simple;
                            circularGauge.BackFrame.FrameWidth = 0F;
                            circularGauge.Location.X = 0F;
                            circularGauge.Location.Y = 0F;
                            circularGauge.Name = "Default";
                            circularGauge.PivotPoint.X = 50F;
                            circularGauge.PivotPoint.Y = 45F;
                            circularPointer.BorderStyle = Dundas.Gauges.WinControl.GaugeDashStyle.Solid;
                            circularPointer.BorderWidth = 0;
                            circularPointer.CapFillColor = System.Drawing.Color.DimGray;
                            circularPointer.CapFillGradientType = Dundas.Gauges.WinControl.GradientType.None;
                            circularPointer.CapWidth = 24F;
                            circularPointer.FillColor = System.Drawing.Color.Lime;
                            circularPointer.FillGradientEndColor = System.Drawing.Color.LightGray;
                            circularPointer.FillGradientType = Dundas.Gauges.WinControl.GradientType.None;
                            circularPointer.Name = "Default";
                            circularPointer.NeedleStyle = Dundas.Gauges.WinControl.NeedleStyle.NeedleStyle11;
                            circularPointer.ShadowOffset = 0F;
                            circularPointer.Width = 10F;
                            circularGauge.Pointers.Add(circularPointer);
                            circularScale.BorderColor = System.Drawing.Color.White;
                            circularScale.BorderWidth = 1;
                            circularScale.FillColor = System.Drawing.Color.Black;
                            circularScale.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.30189F);
                            circularScale.LabelStyle.RotateLabels = false;
                            circularScale.MajorTickMark.BorderWidth = 0;
                            circularScale.MajorTickMark.FillColor = System.Drawing.Color.Black;
                            circularScale.MajorTickMark.Shape = Dundas.Gauges.WinControl.MarkerStyle.Rectangle;
                            circularScale.MajorTickMark.Width = 2F;
                            circularScale.MinorTickMark.BorderWidth = 0;
                            circularScale.MinorTickMark.FillColor = System.Drawing.Color.Black;
                            circularScale.MinorTickMark.Width = 1.5F;
                            circularScale.Name = "Default";
                            circularScale.Radius = 44F;
                            circularScale.ShadowOffset = 0F;
                            circularScale.StartAngle = 30F;
                            circularScale.SweepAngle = 300F;
                            circularScale.Width = 0F;
                            circularScale.Minimum = 0D;
                            circularScale.Maximum = 100D;
                            circularGauge.Scales.Add(circularScale);
                            circularGauge.Size.Height = 100F;
                            circularGauge.Size.Width = 100F;
                            circularGauge.Pointers["Default"].Value = 0;
                            gaugeContainer.CircularGauges.Add(circularGauge);
                            gaugeContainer.InternalBackgroundPaint = false;
                            gaugeLabel.BackColor = System.Drawing.Color.Empty;
                            gaugeLabel.BackGradientEndColor = System.Drawing.Color.Empty;
                            gaugeLabel.Location.X = 19F;
                            gaugeLabel.Location.Y = 80F;
                            gaugeLabel.Name = "Default";
                            gaugeLabel.Parent = "CircularGauges.Default";
                            gaugeLabel.Size.Height = 18F;
                            gaugeLabel.Size.Width = 66F;
                            gaugeLabel.Text = "";
                            gaugeLabel.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
                            gaugeContainer.Labels.Add(gaugeLabel);

                            gaugeContainer.Location = new Point(obj.X, obj.Y);
                            gaugeContainer.Size = new System.Drawing.Size(obj.Width, obj.Height);
                            gaugeContainer.AccessibleName = obj.ObjectID.ToString();
                            gaugeContainer.AccessibleDescription = "4";
                            // Get sensor name + unit + value
                            sensorId = Convert.ToInt32(obj.Parameters);
                            sensor = SensorBLL.Current.GetByID(sensorId);
                            if (sensor != null)
                            {
                                // Associate with sensor
                                // Add tooltip display description - binhpro 27/02/2013
                                if (!string.IsNullOrEmpty(sensor.Description))
                                {
                                    toolTip1.SetToolTip(gaugeContainer, "Công thức: " + sensor.FormulaFunction + "\n" + sensor.Description);
                                }
                                gaugeLabel.Text = sensor.Name + "\n" + sensor.Unit;
                                if (sensor.MaxValue != null) circularScale.Maximum = System.Convert.ToDouble(sensor.MaxValue);
                                if (sensor.MinValue != null) circularScale.Minimum = System.Convert.ToDouble(sensor.MinValue);
                                // Read latest value (if exists)
                                if (entityConntext.SensorValues.
                                    Where(ent => ent.SensorID == sensorId).OrderByDescending(ent => ent.MeaTime).Count() != 0)
                                {
                                    sensorValue = entityConntext.SensorValues.
                                        Where(ent => ent.SensorID == sensorId).OrderByDescending(ent => ent.MeaTime).First();
                                    if (sensor.MaxValue == null)
                                        circularScale.Maximum = Math.Round(System.Convert.ToDouble(getSensorValue(sensorValue)) + 1D, 0);
                                    if (sensor.MinValue == null)
                                        circularScale.Minimum = Math.Round(System.Convert.ToDouble(getSensorValue(sensorValue)) - 1D, 0);
                                    gaugeContainer.CircularGauges["Default"].Pointers["Default"].Value = System.Convert.ToDouble(getSensorValue(sensorValue));
                                    gaugeLabel.Text = sensor.Name + "\n" + getDisplayValue(sensorValue) + " " + sensor.Unit;
                                    // Check if value is in alarm level
                                    if (PictureViewBLL.Current.CheckAlarmRunning(obj))
                                        circularPointer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                                }
                            }
                            // Add to picture
                            this.panel.Controls.Add(gaugeContainer);
                            gaugeContainer.BringToFront();
                            break;
                        case 5: // Vertical Bar
                            // Vertical Bar Initilization
                            Dundas.Gauges.WinControl.LinearGauge linearGauge1 = new Dundas.Gauges.WinControl.LinearGauge();
                            Dundas.Gauges.WinControl.LinearPointer linearPointer1 = new Dundas.Gauges.WinControl.LinearPointer();
                            Dundas.Gauges.WinControl.LinearScale linearScale1 = new Dundas.Gauges.WinControl.LinearScale();
                            Dundas.Gauges.WinControl.GaugeContainer gaugeContainer1 = new Dundas.Gauges.WinControl.GaugeContainer();
                            Dundas.Gauges.WinControl.GaugeLabel gaugeLabel1 = new Dundas.Gauges.WinControl.GaugeLabel();
                            gaugeContainer1.BackFrame.BackColor = System.Drawing.Color.White;
                            gaugeContainer1.BackFrame.BackGradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
                            gaugeContainer1.BackFrame.BackGradientType = Dundas.Gauges.WinControl.GradientType.None;
                            gaugeContainer1.BackFrame.FrameGradientEndColor = System.Drawing.Color.DimGray;
                            gaugeContainer1.BackFrame.FrameGradientType = Dundas.Gauges.WinControl.GradientType.None;
                            gaugeContainer1.BackFrame.FrameShape = Dundas.Gauges.WinControl.BackFrameShape.Rectangular;
                            gaugeContainer1.BackFrame.FrameStyle = Dundas.Gauges.WinControl.BackFrameStyle.None;
                            gaugeContainer1.BackFrame.FrameWidth = 2F;
                            gaugeContainer1.InternalBackgroundPaint = false;
                            gaugeContainer1.LinearGauges.Add(linearGauge1);
                            gaugeLabel1.BackColor = System.Drawing.Color.Empty;
                            gaugeLabel1.BackGradientEndColor = System.Drawing.Color.Empty;
                            gaugeLabel1.Location.X = 14.27777F;
                            gaugeLabel1.Location.Y = 87.39495F;
                            gaugeLabel1.Name = "Default";
                            gaugeLabel1.Parent = "LinearGauges.Default";
                            gaugeLabel1.Size.Height = 14F;
                            gaugeLabel1.Size.Width = 72F;
                            gaugeLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
                            gaugeLabel1.Text = "";
                            gaugeContainer1.Labels.Add(gaugeLabel1);
                            linearGauge1.BackFrame.BackColor = System.Drawing.Color.White;
                            linearGauge1.BackFrame.BackGradientEndColor = System.Drawing.Color.DimGray;
                            linearGauge1.BackFrame.BackGradientType = Dundas.Gauges.WinControl.GradientType.None;
                            linearGauge1.BackFrame.FrameColor = System.Drawing.Color.Silver;
                            linearGauge1.BackFrame.FrameShape = Dundas.Gauges.WinControl.BackFrameShape.Rectangular;
                            linearGauge1.BackFrame.FrameStyle = Dundas.Gauges.WinControl.BackFrameStyle.Edged;
                            linearGauge1.BackFrame.FrameWidth = 1F;
                            linearGauge1.Location.X = 0F;
                            linearGauge1.Location.Y = 0F;
                            linearGauge1.Name = "Default";
                            linearGauge1.Orientation = Dundas.Gauges.WinControl.GaugeOrientation.Vertical;
                            linearPointer1.BorderWidth = 0;
                            linearPointer1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
                            linearPointer1.FillGradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
                            linearPointer1.FillGradientType = Dundas.Gauges.WinControl.GradientType.None;
                            linearPointer1.Name = "Default";
                            linearPointer1.Placement = Dundas.Gauges.WinControl.Placement.Cross;
                            linearPointer1.ShadowOffset = 0F;
                            linearPointer1.ThermometerBackColor = System.Drawing.Color.Empty;
                            linearPointer1.ThermometerBackGradientEndColor = System.Drawing.Color.Empty;
                            linearPointer1.Type = Dundas.Gauges.WinControl.LinearPointerType.Bar;
                            linearPointer1.Width = 15F;
                            linearGauge1.Pointers.Add(linearPointer1);
                            linearScale1.Minimum = 0D;
                            linearScale1.Maximum = 100D;
                            linearScale1.EndMargin = 6F;
                            linearScale1.FillColor = System.Drawing.Color.Black;
                            linearScale1.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F);
                            linearScale1.LabelStyle.FontUnit = Dundas.Gauges.WinControl.FontUnit.Default;
                            linearScale1.MajorTickMark.BorderWidth = 0;
                            linearScale1.MajorTickMark.FillColor = System.Drawing.Color.Black;
                            linearScale1.MajorTickMark.Length = 19F;
                            linearScale1.MajorTickMark.Width = 2F;
                            linearScale1.MinorTickMark.BorderWidth = 0;
                            linearScale1.MinorTickMark.FillColor = System.Drawing.Color.Black;
                            linearScale1.MinorTickMark.Length = 10F;
                            linearScale1.MinorTickMark.Width = 1.5F;
                            linearScale1.Name = "Default";
                            linearScale1.Position = 65F;
                            linearScale1.ShadowOffset = 0F;
                            linearScale1.StartMargin = 15F;
                            linearScale1.Width = 0F;
                            linearScale1.Maximum = 100D;
                            linearScale1.Minimum = 0D;
                            linearGauge1.Scales.Add(linearScale1);
                            linearGauge1.Size.Height = 100F;
                            linearGauge1.Size.Width = 100F;
                            gaugeContainer1.LinearGauges["Default"].Pointers["Default"].Value = 0;

                            gaugeContainer1.Location = new Point(obj.X, obj.Y);
                            gaugeContainer1.Size = new System.Drawing.Size(obj.Width, obj.Height);
                            gaugeContainer1.AccessibleName = obj.ObjectID.ToString();
                            gaugeContainer1.AccessibleDescription = "5";
                            // Get sensor name + unit + value
                            sensorId = Convert.ToInt32(obj.Parameters);
                            sensor = SensorBLL.Current.GetByID(sensorId);
                            if (sensor != null)
                            {
                                // Associate with sensor
                                // Add tooltip display description - binhpro 27/02/2013
                                if (!string.IsNullOrEmpty(sensor.Description))
                                {
                                    toolTip1.SetToolTip(gaugeContainer1, "Công thức: " + sensor.FormulaFunction + "\n" + sensor.Description);
                                }
                                gaugeLabel1.Text = sensor.Name + "\n" + sensor.Unit;
                                if (sensor.MaxValue != null) linearScale1.Maximum = System.Convert.ToDouble(sensor.MaxValue);
                                if (sensor.MinValue != null) linearScale1.Minimum = System.Convert.ToDouble(sensor.MinValue);
                                // Read latest value (if exists)
                                if (entityConntext.SensorValues.
                                    Where(ent => ent.SensorID == sensorId).OrderByDescending(ent => ent.MeaTime).Count() != 0)
                                {
                                    sensorValue = entityConntext.SensorValues.
                                        Where(ent => ent.SensorID == sensorId).OrderByDescending(ent => ent.MeaTime).First();
                                    if (sensor.MaxValue == null)
                                        linearScale1.Maximum = Math.Round(System.Convert.ToDouble(getSensorValue(sensorValue)) + 1D, 0);
                                    if (sensor.MinValue == null)
                                        linearScale1.Minimum = Math.Round(System.Convert.ToDouble(getSensorValue(sensorValue)) - 1D, 0);
                                    gaugeContainer1.LinearGauges["Default"].Pointers["Default"].Value = System.Convert.ToDouble(getSensorValue(sensorValue));
                                    gaugeLabel1.Text = sensor.Name + "\n" + getSensorValue(sensorValue).ToString() + " " + sensor.Unit;
                                    // Check if value is in alarm level
                                    if (PictureViewBLL.Current.CheckAlarmRunning(obj))
                                        linearPointer1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                                }
                            }
                            // Add to picture
                            this.panel.Controls.Add(gaugeContainer1);
                            gaugeContainer1.BringToFront();
                            break;
                        case 6: // Horizontal Bar
                            // Horizontal Bar Initilization
                            linearGauge1 = new Dundas.Gauges.WinControl.LinearGauge();
                            linearPointer1 = new Dundas.Gauges.WinControl.LinearPointer();
                            linearScale1 = new Dundas.Gauges.WinControl.LinearScale();
                            gaugeContainer1 = new Dundas.Gauges.WinControl.GaugeContainer();
                            gaugeLabel1 = new Dundas.Gauges.WinControl.GaugeLabel();
                            gaugeContainer1.BackFrame.BackColor = System.Drawing.Color.White;
                            gaugeContainer1.BackFrame.BackGradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
                            gaugeContainer1.BackFrame.BackGradientType = Dundas.Gauges.WinControl.GradientType.None;
                            gaugeContainer1.BackFrame.FrameGradientEndColor = System.Drawing.Color.DimGray;
                            gaugeContainer1.BackFrame.FrameGradientType = Dundas.Gauges.WinControl.GradientType.None;
                            gaugeContainer1.BackFrame.FrameShape = Dundas.Gauges.WinControl.BackFrameShape.Rectangular;
                            gaugeContainer1.BackFrame.FrameStyle = Dundas.Gauges.WinControl.BackFrameStyle.None;
                            gaugeContainer1.BackFrame.FrameWidth = 2F;
                            gaugeContainer1.InternalBackgroundPaint = false;
                            gaugeContainer1.LinearGauges.Add(linearGauge1);
                            gaugeLabel1.BackColor = System.Drawing.Color.Empty;
                            gaugeLabel1.BackGradientEndColor = System.Drawing.Color.Empty;
                            gaugeLabel1.Location.X = 32F;
                            gaugeLabel1.Location.Y = 62F;
                            gaugeLabel1.Name = "Default";
                            gaugeLabel1.Parent = "LinearGauges.Default";
                            gaugeLabel1.Size.Height = 34F;
                            gaugeLabel1.Size.Width = 39F;
                            gaugeLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
                            gaugeLabel1.Text = "";
                            gaugeContainer1.Labels.Add(gaugeLabel1);
                            linearGauge1.BackFrame.BackColor = System.Drawing.Color.White;
                            linearGauge1.BackFrame.BackGradientEndColor = System.Drawing.Color.DimGray;
                            linearGauge1.BackFrame.BackGradientType = Dundas.Gauges.WinControl.GradientType.None;
                            linearGauge1.BackFrame.FrameColor = System.Drawing.Color.Silver;
                            linearGauge1.BackFrame.FrameShape = Dundas.Gauges.WinControl.BackFrameShape.Rectangular;
                            linearGauge1.BackFrame.FrameStyle = Dundas.Gauges.WinControl.BackFrameStyle.Edged;
                            linearGauge1.BackFrame.FrameWidth = 2F;
                            linearGauge1.Location.X = 0F;
                            linearGauge1.Location.Y = 0F;
                            linearGauge1.Name = "Default";
                            linearGauge1.Orientation = Dundas.Gauges.WinControl.GaugeOrientation.Horizontal;
                            linearPointer1.BorderWidth = 0;
                            linearPointer1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
                            linearPointer1.FillGradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
                            linearPointer1.FillGradientType = Dundas.Gauges.WinControl.GradientType.None;
                            linearPointer1.Name = "Default";
                            linearPointer1.ShadowOffset = 0F;
                            linearPointer1.ThermometerBackColor = System.Drawing.Color.Empty;
                            linearPointer1.ThermometerBackGradientEndColor = System.Drawing.Color.Empty;
                            linearPointer1.Type = Dundas.Gauges.WinControl.LinearPointerType.Bar;
                            linearPointer1.Placement = Dundas.Gauges.WinControl.Placement.Cross;
                            linearPointer1.Width = 15F;
                            linearGauge1.Pointers.Add(linearPointer1);
                            linearScale1.Minimum = 0D;
                            linearScale1.Maximum = 100D;
                            linearScale1.EndMargin = 5F;
                            linearScale1.FillColor = System.Drawing.Color.Black;
                            linearScale1.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.30189F);
                            linearScale1.MajorTickMark.BorderWidth = 0;
                            linearScale1.MajorTickMark.FillColor = System.Drawing.Color.Black;
                            linearScale1.MajorTickMark.Length = 20F;
                            linearScale1.MajorTickMark.Width = 2F;
                            linearScale1.MinorTickMark.BorderWidth = 0;
                            linearScale1.MinorTickMark.FillColor = System.Drawing.Color.Black;
                            linearScale1.MinorTickMark.Length = 12F;
                            linearScale1.MinorTickMark.Width = 1.5F;
                            linearScale1.Name = "Default";
                            linearScale1.Position = 45F;
                            linearScale1.ShadowOffset = 0F;
                            linearScale1.StartMargin = 5F;
                            linearScale1.Width = 0F;
                            linearScale1.Maximum = 100D;
                            linearScale1.Minimum = 0D;
                            linearGauge1.Scales.Add(linearScale1);
                            linearGauge1.Size.Height = 100F;
                            linearGauge1.Size.Width = 100F;
                            gaugeContainer1.LinearGauges["Default"].Pointers["Default"].Value = 0;

                            gaugeContainer1.Location = new Point(obj.X, obj.Y);
                            gaugeContainer1.Size = new System.Drawing.Size(obj.Width, obj.Height);
                            gaugeContainer1.AccessibleName = obj.ObjectID.ToString();
                            gaugeContainer1.AccessibleDescription = "6";
                            // Get sensor name + unit + value
                            sensorId = Convert.ToInt32(obj.Parameters);
                            sensor = SensorBLL.Current.GetByID(sensorId);
                            if (sensor != null)
                            {
                                // Associate with sensor
                                // Add tooltip display description - binhpro 27/02/2013
                                if (!string.IsNullOrEmpty(sensor.Description))
                                {
                                    toolTip1.SetToolTip(gaugeContainer1, "Công thức: " + sensor.FormulaFunction + "\n" + sensor.Description);
                                }
                                gaugeLabel1.Text = sensor.Name + "\n" + sensor.Unit;
                                if (sensor.MaxValue != null) linearScale1.Maximum = System.Convert.ToDouble(sensor.MaxValue);
                                if (sensor.MinValue != null) linearScale1.Minimum = System.Convert.ToDouble(sensor.MinValue);
                                // Read latest value (if exists)
                                if (entityConntext.SensorValues.
                                    Where(ent => ent.SensorID == sensorId).OrderByDescending(ent => ent.MeaTime).Count() != 0)
                                {
                                    sensorValue = entityConntext.SensorValues.
                                        Where(ent => ent.SensorID == sensorId).OrderByDescending(ent => ent.MeaTime).First();
                                    if (sensor.MaxValue == null)
                                        linearScale1.Maximum = Math.Round(System.Convert.ToDouble(getSensorValue(sensorValue)) + 1D, 0);
                                    if (sensor.MinValue == null)
                                        linearScale1.Minimum = Math.Round(System.Convert.ToDouble(getSensorValue(sensorValue)) - 1D, 0);
                                    gaugeContainer1.LinearGauges["Default"].Pointers["Default"].Value = System.Convert.ToDouble(getSensorValue(sensorValue));
                                    gaugeLabel1.Text = sensor.Name + "\n" + getSensorValue(sensorValue).ToString() + " " + sensor.Unit;
                                    // Check if value is in alarm level
                                    if (PictureViewBLL.Current.CheckAlarmRunning(obj))
                                        linearPointer1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                                }
                            }
                            // Add to picture
                            this.panel.Controls.Add(gaugeContainer1);
                            gaugeContainer1.BringToFront();
                            break;
                        case 7: // Meter
                            // Meter Initilization
                            gaugeContainer = new Dundas.Gauges.WinControl.GaugeContainer();
                            circularGauge = new Dundas.Gauges.WinControl.CircularGauge();
                            circularPointer = new Dundas.Gauges.WinControl.CircularPointer();
                            circularScale = new Dundas.Gauges.WinControl.CircularScale();
                            gaugeLabel = new Dundas.Gauges.WinControl.GaugeLabel();

                            gaugeContainer.BackFrame.BackColor = System.Drawing.Color.White;
                            gaugeContainer.BackFrame.BackGradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
                            gaugeContainer.BackFrame.BackGradientType = Dundas.Gauges.WinControl.GradientType.None;
                            gaugeContainer.BackFrame.FrameGradientEndColor = System.Drawing.Color.DimGray;
                            gaugeContainer.BackFrame.FrameGradientType = Dundas.Gauges.WinControl.GradientType.None;
                            gaugeContainer.BackFrame.FrameShape = Dundas.Gauges.WinControl.BackFrameShape.Rectangular;
                            gaugeContainer.BackFrame.FrameStyle = Dundas.Gauges.WinControl.BackFrameStyle.None;
                            gaugeContainer.BackFrame.FrameWidth = 0F;
                            circularGauge.BackFrame.BackColor = System.Drawing.Color.White;
                            circularGauge.BackFrame.BackGradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
                            circularGauge.BackFrame.BackGradientType = Dundas.Gauges.WinControl.GradientType.None;
                            circularGauge.BackFrame.BorderColor = System.Drawing.Color.Gray;
                            circularGauge.BackFrame.BorderWidth = 2;
                            circularGauge.BackFrame.FrameGradientEndColor = System.Drawing.Color.DimGray;
                            circularGauge.BackFrame.FrameGradientType = Dundas.Gauges.WinControl.GradientType.None;
                            circularGauge.BackFrame.FrameShape = Dundas.Gauges.WinControl.BackFrameShape.Rectangular;
                            circularGauge.BackFrame.FrameStyle = Dundas.Gauges.WinControl.BackFrameStyle.Edged;
                            circularGauge.BackFrame.FrameWidth = 0F;
                            circularGauge.Location.X = 0F;
                            circularGauge.Location.Y = 0F;
                            circularGauge.Name = "Default";
                            circularGauge.PivotPoint.X = 50F;
                            circularGauge.PivotPoint.Y = 263F;
                            circularPointer.BorderWidth = 0;
                            circularPointer.CapFillColor = System.Drawing.Color.Silver;
                            circularPointer.CapFillGradientType = Dundas.Gauges.WinControl.GradientType.None;
                            circularPointer.CapVisible = false;
                            circularPointer.CapWidth = 30F;
                            circularPointer.FillColor = System.Drawing.Color.Lime;
                            circularPointer.FillGradientType = Dundas.Gauges.WinControl.GradientType.None;
                            circularPointer.Name = "Default";
                            circularPointer.ShadowOffset = 0F;
                            circularPointer.Width = 6.1F;
                            circularGauge.Pointers.Add(circularPointer);
                            circularScale.BorderColor = System.Drawing.Color.White;
                            circularScale.BorderWidth = 1;
                            circularScale.FillColor = System.Drawing.Color.Black;
                            circularScale.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F);
                            circularScale.MajorTickMark.BorderWidth = 0;
                            circularScale.MajorTickMark.FillColor = System.Drawing.Color.Black;
                            circularScale.MajorTickMark.Length = 6F;
                            circularScale.MajorTickMark.Shape = Dundas.Gauges.WinControl.MarkerStyle.Rectangle;
                            circularScale.MajorTickMark.Width = 2F;
                            circularScale.MinorTickMark.BorderWidth = 0;
                            circularScale.MinorTickMark.FillColor = System.Drawing.Color.Black;
                            circularScale.MinorTickMark.Length = 4F;
                            circularScale.MinorTickMark.Width = 1F;
                            circularScale.Name = "Default";
                            circularScale.Radius = 249F;
                            circularScale.ShadowOffset = 0F;
                            circularScale.StartAngle = 150F;
                            circularScale.SweepAngle = 60F;
                            circularScale.Width = 0F;
                            circularScale.Minimum = 0D;
                            circularScale.Maximum = 100D;
                            circularGauge.Scales.Add(circularScale);
                            circularGauge.Size.Height = 100F;
                            circularGauge.Size.Width = 100F;
                            circularPointer.Value = 0;
                            gaugeContainer.CircularGauges.Add(circularGauge);
                            gaugeContainer.InternalBackgroundPaint = false;
                            gaugeLabel.BackColor = System.Drawing.Color.Empty;
                            gaugeLabel.BackGradientEndColor = System.Drawing.Color.Empty;
                            gaugeLabel.Location.X = 25F;
                            gaugeLabel.Location.Y = 68F;
                            gaugeLabel.Name = "Default";
                            gaugeLabel.Parent = "CircularGauges.Default";
                            gaugeLabel.Size.Height = 33F;
                            gaugeLabel.Size.Width = 56F;
                            gaugeLabel.Text = "";
                            gaugeLabel.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
                            gaugeContainer.Labels.Add(gaugeLabel);

                            gaugeContainer.Location = new Point(obj.X, obj.Y);
                            gaugeContainer.Size = new System.Drawing.Size(obj.Width, obj.Height);
                            gaugeContainer.AccessibleName = obj.ObjectID.ToString();
                            gaugeContainer.AccessibleDescription = "7";
                            // Get sensor name + unit + value
                            sensorId = Convert.ToInt32(obj.Parameters);
                            sensor = SensorBLL.Current.GetByID(sensorId);
                            if (sensor != null)
                            {
                                // Associate with sensor
                                // Add tooltip display description - binhpro 27/02/2013
                                if (!string.IsNullOrEmpty(sensor.Description))
                                {
                                    toolTip1.SetToolTip(gaugeContainer, "Công thức: " + sensor.FormulaFunction + "\n" + sensor.Description);
                                }
                                gaugeLabel.Text = sensor.Name + "\n" + sensor.Unit;
                                if (sensor.MaxValue != null) circularScale.Maximum = System.Convert.ToDouble(sensor.MaxValue);
                                if (sensor.MinValue != null) circularScale.Minimum = System.Convert.ToDouble(sensor.MinValue);
                                // Read latest value (if exists)
                                if (entityConntext.SensorValues.
                                    Where(ent => ent.SensorID == sensorId).OrderByDescending(ent => ent.MeaTime).Count() != 0)
                                {
                                    sensorValue = entityConntext.SensorValues.
                                        Where(ent => ent.SensorID == sensorId).OrderByDescending(ent => ent.MeaTime).First();
                                    if (sensor.MaxValue == null)
                                        circularScale.Maximum = Math.Round(System.Convert.ToDouble(getSensorValue(sensorValue)) + 1D, 0);
                                    if (sensor.MinValue == null)
                                        circularScale.Minimum = Math.Round(System.Convert.ToDouble(getSensorValue(sensorValue)) - 1D, 0);
                                    gaugeContainer.CircularGauges["Default"].Pointers["Default"].Value = System.Convert.ToDouble(getSensorValue(sensorValue));
                                    gaugeLabel.Text = sensor.Name + "\n" + getDisplayValue(sensorValue) + " " + sensor.Unit;
                                    // Check if value is in alarm level
                                    if (PictureViewBLL.Current.CheckAlarmRunning(obj))
                                        circularPointer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                                }
                            }
                            // Add to picture
                            this.panel.Controls.Add(gaugeContainer);
                            gaugeContainer.BringToFront();
                            break;
                        case 8: // Numeric Indicator
                            // Numeric Indicator Initilization
                            Dundas.Gauges.WinControl.GaugeContainer gaugeContainer2 = new Dundas.Gauges.WinControl.GaugeContainer();
                            Dundas.Gauges.WinControl.GaugeLabel gaugeLabel2 = new Dundas.Gauges.WinControl.GaugeLabel();
                            Dundas.Gauges.WinControl.NumericIndicator numericIndicator = new Dundas.Gauges.WinControl.NumericIndicator();
                            gaugeContainer2.BackFrame.BackColor = System.Drawing.Color.White;
                            gaugeContainer2.BackFrame.BackGradientEndColor = System.Drawing.Color.White;
                            gaugeContainer2.BackFrame.BackGradientType = Dundas.Gauges.WinControl.GradientType.None;
                            gaugeContainer2.BackFrame.BorderWidth = 2;
                            gaugeContainer2.BackFrame.FrameGradientEndColor = System.Drawing.Color.DimGray;
                            gaugeContainer2.BackFrame.FrameGradientType = Dundas.Gauges.WinControl.GradientType.None;
                            gaugeContainer2.BackFrame.FrameShape = Dundas.Gauges.WinControl.BackFrameShape.Rectangular;
                            gaugeContainer2.BackFrame.FrameStyle = Dundas.Gauges.WinControl.BackFrameStyle.Simple;
                            gaugeContainer2.BackFrame.FrameWidth = 0F;
                            gaugeContainer2.InternalBackgroundPaint = false;
                            gaugeContainer2.NumericIndicators.Add(numericIndicator);
                            numericIndicator.BackColor = System.Drawing.Color.Transparent;
                            numericIndicator.BackGradientType = Dundas.Gauges.WinControl.GradientType.None;
                            numericIndicator.BorderColor = System.Drawing.Color.Black;
                            numericIndicator.BorderWidth = 0;
                            numericIndicator.DecimalColor = System.Drawing.Color.Black;
                            numericIndicator.Decimals = 2;
                            numericIndicator.DigitColor = System.Drawing.Color.Black;
                            numericIndicator.IndicatorStyle = Dundas.Gauges.WinControl.NumericIndicatorStyle.Digital7Segment;
                            numericIndicator.LedDimColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
                            numericIndicator.Location.X = 0F;
                            numericIndicator.Location.Y = -20F;
                            numericIndicator.Name = "Default";
                            numericIndicator.Parent = "";
                            numericIndicator.ShowDecimalPoint = true;
                            numericIndicator.Size.Height = 99F;
                            numericIndicator.Size.Width = 99F;
                            numericIndicator.Value = 0;
                            numericIndicator.Digits = 6;
                            gaugeLabel2.BackColor = System.Drawing.Color.Empty;
                            gaugeLabel2.BackGradientEndColor = System.Drawing.Color.Empty;
                            gaugeLabel2.Location.X = 26F;
                            gaugeLabel2.Location.Y = 75F;
                            gaugeLabel2.Name = "Default";
                            gaugeLabel2.Parent = "NumericIndicators.Default";
                            gaugeLabel2.Size.Height = 50F;
                            gaugeLabel2.Size.Width = 51F;
                            gaugeLabel2.Text = "";
                            gaugeLabel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
                            gaugeContainer2.Labels.Add(gaugeLabel2);

                            gaugeContainer2.Location = new Point(obj.X, obj.Y);
                            gaugeContainer2.Size = new System.Drawing.Size(obj.Width, obj.Height);
                            gaugeContainer2.AccessibleName = obj.ObjectID.ToString();
                            gaugeContainer2.AccessibleDescription = "8";
                            // Get sensor name + unit + value
                            sensorId = Convert.ToInt32(obj.Parameters);
                            sensor = SensorBLL.Current.GetByID(sensorId);
                            if (sensor != null)
                            {
                                // Associate with sensor
                                // Add tooltip display description - binhpro 27/02/2013
                                if (!string.IsNullOrEmpty(sensor.Description))
                                {
                                    toolTip1.SetToolTip(gaugeContainer2, "Công thức: " + sensor.FormulaFunction + "\n" + sensor.Description);
                                }
                                gaugeLabel2.Text = sensor.Name + "\n" + sensor.Unit;
                                if (sensor.MaxValue != null)
                                    gaugeContainer2.NumericIndicators["Default"].Digits = System.Convert.ToInt32(System.Math.Log10(System.Convert.ToInt32(sensor.MaxValue) + 1)) + 1 + 2 + 1;
                                // Read latest value (if exists)
                                if (entityConntext.SensorValues.
                                    Where(ent => ent.SensorID == sensorId).OrderByDescending(ent => ent.MeaTime).Count() != 0)
                                {
                                    sensorValue = entityConntext.SensorValues.
                                        Where(ent => ent.SensorID == sensorId).OrderByDescending(ent => ent.MeaTime).First();
                                    if (sensor.MaxValue == null)
                                        gaugeContainer2.NumericIndicators["Default"].Digits = System.Convert.ToInt32(System.Math.Log10(System.Convert.ToInt32(getSensorValue(sensorValue)) + 1)) + 1 + 2 + 1;
                                    gaugeContainer2.NumericIndicators["Default"].Value = System.Convert.ToDouble(getSensorValue(sensorValue));
                                    gaugeLabel2.Text = sensor.Name + "\n" + getDisplayValue(sensorValue) + " " + sensor.Unit;
                                    // Check if value is in alarm level
                                    if (PictureViewBLL.Current.CheckAlarmRunning(obj))
                                    {
                                        gaugeContainer2.NumericIndicators["Default"].DigitColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                                        gaugeContainer2.NumericIndicators["Default"].DecimalColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                                        gaugeContainer2.NumericIndicators["Default"].SeparatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                                    }
                                }
                            }
                            // Add to picture
                            this.panel.Controls.Add(gaugeContainer2);
                            gaugeContainer2.BringToFront();
                            break;
                        default:
                            break;
                    }
                }
                //mainMenuStrip.BringToFront();
                MouseMoveEventRegister(this.panel.Controls);
                foreach (Control control in this.panel.Controls)
                {
                    if (control.GetType() != typeof(MenuStrip))
                        pb.WireControl(control);
                }
                pb.EditModeEnabled = false;
                if (!SecurityBLL.Current.IsUserInRoles(new string[] { SecurityBLL.ROLE_VIEWS_EDIT, SecurityBLL.ROLE_VIEWS_MANAGE, SecurityBLL.ROLE_VIEWS_VIEW }))
                {
                    this.viewModeToolStripMenuItem.Enabled = false;
                    this.editToolStripMenuItem.Enabled = false;
                }
                this.addToolStripMenuItem.Enabled = false;
                //
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }
        #endregion

        #region Moving Controls
        //
        //Moving Controls
        //
        private void MouseMoveEventRegister(System.Windows.Forms.Control.ControlCollection ctrlList)
        {
            foreach (Control ctrl in ctrlList)
            {
                ctrl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.controlMouseDownHandler);
                ctrl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.controlMouseUpHandler);
            }
            this.MouseUp += new MouseEventHandler(picture_MouseUp);
        }
        private void ControlMouseMoveEventRegister(Control ctrl)
        {
            ctrl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.controlMouseDownHandler);
            ctrl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.controlMouseUpHandler);
        }
        private void picture_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if ((pb.Resized) & (pb.EditModeEnabled))
                {
                    int idObject = Convert.ToInt32(currentCtrl.AccessibleName);
                    var obj = PictureViewBLL.Current.GetObjectByID(idObject);
                    if (obj != null)
                    {
                        obj.X = currentCtrl.Location.X;
                        obj.Y = currentCtrl.Location.Y;
                        obj.Width = currentCtrl.Size.Width;
                        obj.Height = currentCtrl.Size.Height;
                        PictureViewBLL.Current.UpdateObject(obj);
                        PictureViewBLL.Current.Update(_pictureView);
                    }
                    pb.Resized = false;
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }
        private void controlMouseDownHandler(object sender, MouseEventArgs e)
        {
            try
            {
                if ((e.Button == MouseButtons.Right) && (pb.EditModeEnabled))
                {
                    currentRightClickCtrl = (Control)sender;
                    editContextMenu.Show(currentRightClickCtrl, e.Location);
                }
                if ((e.Button == MouseButtons.Right) && (!pb.EditModeEnabled))
                {
                    currentRightClickCtrl = (Control)sender;
                    if (currentRightClickCtrl.AccessibleDescription != "3")
                    {
                        if (currentRightClickCtrl.AccessibleDescription != "2")
                            this.pictureViewToolStripMenuItem.Enabled = false;
                        else this.pictureViewToolStripMenuItem.Enabled = true;
                        viewContextMenu.Show(currentRightClickCtrl, e.Location);
                    }
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }
        private void controlMouseUpHandler(object sender, MouseEventArgs e)
        {
            try
            {
                if ((e.Button == MouseButtons.Left) && (pb.EditModeEnabled))
                {
                    if (currentCtrl == null) currentCtrl = (Control)sender;
                    int idObject = Convert.ToInt32(currentCtrl.AccessibleName);
                    var obj = PictureViewBLL.Current.GetObjectByID(idObject);
                    if (obj != null)
                    {
                        obj.X = currentCtrl.Location.X;
                        obj.Y = currentCtrl.Location.Y;
                        obj.Width = currentCtrl.Size.Width;
                        obj.Height = currentCtrl.Size.Height;
                        PictureViewBLL.Current.UpdateObject(obj);
                        PictureViewBLL.Current.Update(_pictureView);
                    }
                    this.currentCtrl = (Control)sender;
                }
                else if ((e.Button == MouseButtons.Left) && (!pb.EditModeEnabled))
                {
                    currentCtrl = (Control)sender;
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }
        #endregion
        //
        // Menu Items
        //
        // File Menu
        //
        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //_screenShoot = panel.CaptureScreen();
            printPreviewDialog.ShowDialog();
        }

        //Print current picture form
        //[System.Runtime.InteropServices.DllImport("gdi32.dll")]
        //public static extern long BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
        //private Bitmap memoryImage;
        //private void CaptureScreen()
        //{
        //    Graphics mygraphics = this.CreateGraphics();
        //    Size s = this.Size;
        //    memoryImage = new Bitmap(s.Width, s.Height, mygraphics);
        //    Graphics memoryGraphics = Graphics.FromImage(memoryImage);
        //    IntPtr dc1 = mygraphics.GetHdc();
        //    IntPtr dc2 = memoryGraphics.GetHdc();
        //    BitBlt(dc2, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height, dc1, 0, 0, 13369376);
        //    mygraphics.ReleaseHdc(dc1);
        //    memoryGraphics.ReleaseHdc(dc2);
        //}
        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {


            if (_screenShoot == null)
            {
                _screenShoot = panel.CaptureScreen();
            }
            e.Graphics.DrawImage(_screenShoot, 50, 50, 710, panel.Size.Height * 710 / (panel.Size.Width > 0 ? panel.Size.Width : 1));
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Application.Exit();
        //}

        private void switchToEditModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (pb.EditModeEnabled)
                {
                    this.swichEditModeToolStripMenuItem.Text = Resources.PictureViewDetailForm_SwichToEditMode;
                    pb.HideHandles();
                    this.addToolStripMenuItem.Enabled = false;
                    pb.EditModeEnabled = false;
                    if (currentCtrl != null)
                    {
                        int idObject = Convert.ToInt32(currentCtrl.AccessibleName);
                        var obj = PictureViewBLL.Current.GetObjectByID(idObject);
                        if (obj != null)
                        {
                            obj.X = currentCtrl.Location.X;
                            obj.Y = currentCtrl.Location.Y;
                            obj.Width = currentCtrl.Size.Width;
                            obj.Height = currentCtrl.Size.Height;
                            PictureViewBLL.Current.UpdateObject(obj);
                            PictureViewBLL.Current.Update(_pictureView);
                        }
                    }
                }
                else if (!pb.EditModeEnabled)
                {
                    this.swichEditModeToolStripMenuItem.Text = Resources.PictureViewDetailForm_SwichToViewMode;
                    pb.EditModeEnabled = true;
                    this.addToolStripMenuItem.Enabled = true;
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        //
        // Menu Edit -> Edit Information
        //
        //private void editInformationToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //using (PictureInformationForm f = new PictureInformationForm(_pictureView.Name, _pictureView.Description))
        //        //{
        //        //    f.ShowDialog();
        //        //    if (f.Submitted)
        //        //    {
        //        //        _pictureView.Name = f.PictureName;
        //        //        _pictureView.Description = f.PictureDescription;
        //        //        PictureViewBLL.Current.Update(_pictureView);
        //        //        this.Text = f.PictureName;
        //        //    }
        //        //}
        //    }
        //    catch (Exception exception)
        //    {
        //        ShowErrorMessage(exception.Message);
        //    }
        //}
        //
        // Menu Edit -> Add...
        //
        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    System.Windows.Forms.PictureBox newpicture = new System.Windows.Forms.PictureBox();
                    System.Drawing.Image image = System.Drawing.Image.FromFile(openFileDialog.FileName);

                    GeoViewer.Models.Object obj = new Models.Object();
                    obj.PictureViewID = _pictureView.PictureViewID;
                    obj.Type = 3;
                    obj.X = 50; obj.Y = 50;
                    obj.Width = image.Size.Width;
                    obj.Height = image.Size.Height;
                    obj.Parameters = openFileDialog.FileName;
                    obj.Z_Index = 1;
                    if (entityConntext.Objects.
                        Where(ent => ent.PictureViewID == _pictureView.PictureViewID).OrderByDescending(ent => ent.Z_Index).Count() > 0)
                    {
                        var topObject = entityConntext.Objects.
                            Where(ent => ent.PictureViewID == _pictureView.PictureViewID).OrderByDescending(ent => ent.Z_Index).First();
                        obj.Z_Index = topObject.Z_Index + 1;
                    }
                    obj.CreatedDate = DateTime.Now;
                    obj.CreatedUser = AppContext.Current.LogedInUser.ToString();
                    if (PictureViewBLL.Current.InsertObject(obj))
                    {
                        //Console.WriteLine("Insert Object Success, ID: " + obj.ObjectID);
                        //PictureViewBLL.Current.Update(_pictureView);

                        newpicture.Location = new System.Drawing.Point(50, 50);
                        newpicture.ImageLocation = openFileDialog.FileName;
                        newpicture.SizeMode = PictureBoxSizeMode.StretchImage;
                        newpicture.Size = image.Size;
                        newpicture.AccessibleName = obj.ObjectID.ToString();
                        newpicture.AccessibleDescription = "3";
                        this.panel.Controls.Add(newpicture);
                        newpicture.BringToFront();
                        ControlMouseMoveEventRegister(newpicture);
                        pb.WireControl(newpicture);
                        // Edited by binhpro 22/11/2012
                        //string imagePath = PictureViewBLL.Current.CopyImageFile(openFileDialog.FileName, obj.ObjectID);
                        //obj.Parameters = imagePath;
                        //PictureViewBLL.Current.UpdateObject(obj);
                    }
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }
        private void indicatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                GeoViewer.Models.Object obj = new Models.Object();
                obj.PictureViewID = _pictureView.PictureViewID;
                obj.Type = 1;
                obj.X = 50; obj.Y = 50;
                obj.Width = 50;
                obj.Height = 50;
                obj.Parameters = "0";
                obj.Z_Index = 1;
                if (entityConntext.Objects.
                    Where(ent => ent.PictureViewID == _pictureView.PictureViewID).OrderByDescending(ent => ent.Z_Index).Count() > 0)
                {
                    var topObject = entityConntext.Objects.
                        Where(ent => ent.PictureViewID == _pictureView.PictureViewID).OrderByDescending(ent => ent.Z_Index).First();
                    obj.Z_Index = topObject.Z_Index + 1;
                }
                obj.CreatedDate = DateTime.Now;
                obj.CreatedUser = AppContext.Current.LogedInUser.ToString();
                if (PictureViewBLL.Current.InsertObject(obj))
                {
                    Console.WriteLine("Insert Object Success, ID: " + obj.ObjectID);
                    PictureViewBLL.Current.Update(_pictureView);

                    indicator i = new indicator();
                    i.Size = new Size(50, 50);
                    i.Location = new Point(50, 50);
                    i.FillColor = Color.Lime;
                    i.AccessibleName = obj.ObjectID.ToString();
                    i.AccessibleDescription = "1";

                    this.panel.Controls.Add(i);
                    i.BringToFront();
                    ControlMouseMoveEventRegister(i);
                    pb.WireControl(i);
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }
        private void groupIndicatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                GeoViewer.Models.Object obj = new Models.Object();
                obj.PictureViewID = _pictureView.PictureViewID;
                obj.Type = 2;
                obj.X = 50; obj.Y = 50;
                obj.Width = 20;
                obj.Height = 20;
                obj.Parameters = "0";
                obj.Z_Index = 1;
                if (entityConntext.Objects.
                    Where(ent => ent.PictureViewID == _pictureView.PictureViewID).OrderByDescending(ent => ent.Z_Index).Count() > 0)
                {
                    var topObject = entityConntext.Objects.
                        Where(ent => ent.PictureViewID == _pictureView.PictureViewID).OrderByDescending(ent => ent.Z_Index).First();
                    obj.Z_Index = topObject.Z_Index + 1;
                }
                obj.CreatedDate = DateTime.Now;
                obj.CreatedUser = AppContext.Current.LogedInUser.ToString();
                if (PictureViewBLL.Current.InsertObject(obj))
                {
                    Console.WriteLine("Insert Object Success, ID: " + obj.ObjectID);
                    PictureViewBLL.Current.Update(_pictureView);

                    groupIndicator i = new groupIndicator();
                    i.Location = new Point(50, 50);
                    i.FillColor = Color.Lime;
                    i.BackColor = Color.Transparent;
                    i.Size = new Size(20, 20);
                    i.AccessibleName = obj.ObjectID.ToString();
                    i.AccessibleDescription = "2";

                    this.panel.Controls.Add(i);
                    i.BringToFront();
                    ControlMouseMoveEventRegister(i);
                    pb.WireControl(i);
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }
        private void gaugeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                GeoViewer.Models.Object obj = new Models.Object();
                obj.PictureViewID = _pictureView.PictureViewID;
                obj.Type = 4;
                obj.X = 50; obj.Y = 50;
                obj.Width = 100;
                obj.Height = 100;
                obj.Parameters = "0";
                obj.Z_Index = 1;
                if (entityConntext.Objects.
                    Where(ent => ent.PictureViewID == _pictureView.PictureViewID).OrderByDescending(ent => ent.Z_Index).Count() > 0)
                {
                    var topObject = entityConntext.Objects.
                        Where(ent => ent.PictureViewID == _pictureView.PictureViewID).OrderByDescending(ent => ent.Z_Index).First();
                    obj.Z_Index = topObject.Z_Index + 1;
                }
                obj.CreatedDate = DateTime.Now;
                obj.CreatedUser = AppContext.Current.LogedInUser.ToString();
                if (PictureViewBLL.Current.InsertObject(obj))
                {
                    Console.WriteLine("Insert Object Success, ID: " + obj.ObjectID);
                    PictureViewBLL.Current.Update(_pictureView);

                    Dundas.Gauges.WinControl.GaugeContainer gaugeContainer = new Dundas.Gauges.WinControl.GaugeContainer();
                    Dundas.Gauges.WinControl.CircularGauge circularGauge = new Dundas.Gauges.WinControl.CircularGauge();
                    Dundas.Gauges.WinControl.CircularPointer circularPointer = new Dundas.Gauges.WinControl.CircularPointer();
                    Dundas.Gauges.WinControl.CircularScale circularScale = new Dundas.Gauges.WinControl.CircularScale();
                    Dundas.Gauges.WinControl.GaugeLabel gaugeLabel = new Dundas.Gauges.WinControl.GaugeLabel();

                    gaugeContainer.BackFrame.BackColor = System.Drawing.Color.Transparent;
                    gaugeContainer.BackFrame.BackGradientEndColor = System.Drawing.Color.Transparent;
                    gaugeContainer.BackFrame.BackGradientType = Dundas.Gauges.WinControl.GradientType.None;
                    gaugeContainer.BackFrame.FrameColor = System.Drawing.Color.Transparent;
                    gaugeContainer.BackFrame.FrameGradientEndColor = System.Drawing.Color.Transparent;
                    gaugeContainer.BackFrame.FrameGradientType = Dundas.Gauges.WinControl.GradientType.None;
                    gaugeContainer.BackFrame.FrameShape = Dundas.Gauges.WinControl.BackFrameShape.AutoShape;
                    gaugeContainer.BackFrame.FrameStyle = Dundas.Gauges.WinControl.BackFrameStyle.Edged;
                    gaugeContainer.BackFrame.FrameWidth = 0F;
                    circularGauge.BackFrame.BackColor = System.Drawing.Color.White;
                    circularGauge.BackFrame.BackGradientEndColor = System.Drawing.Color.White;
                    circularGauge.BackFrame.BackGradientType = Dundas.Gauges.WinControl.GradientType.None;
                    circularGauge.BackFrame.BorderColor = System.Drawing.Color.Gray;
                    circularGauge.BackFrame.BorderWidth = 2;
                    circularGauge.BackFrame.FrameColor = System.Drawing.Color.Transparent;
                    circularGauge.BackFrame.FrameGradientEndColor = System.Drawing.Color.Transparent;
                    circularGauge.BackFrame.FrameGradientType = Dundas.Gauges.WinControl.GradientType.None;
                    circularGauge.BackFrame.FrameShape = Dundas.Gauges.WinControl.BackFrameShape.Rectangular;
                    circularGauge.BackFrame.FrameStyle = Dundas.Gauges.WinControl.BackFrameStyle.Simple;
                    circularGauge.BackFrame.FrameWidth = 0F;
                    circularGauge.Location.X = 0F;
                    circularGauge.Location.Y = 0F;
                    circularGauge.Name = "Default";
                    circularGauge.PivotPoint.X = 50F;
                    circularGauge.PivotPoint.Y = 45F;
                    circularPointer.BorderStyle = Dundas.Gauges.WinControl.GaugeDashStyle.Solid;
                    circularPointer.BorderWidth = 0;
                    circularPointer.CapFillColor = System.Drawing.Color.DimGray;
                    circularPointer.CapFillGradientType = Dundas.Gauges.WinControl.GradientType.None;
                    circularPointer.CapWidth = 24F;
                    circularPointer.FillColor = System.Drawing.Color.Lime;
                    circularPointer.FillGradientEndColor = System.Drawing.Color.LightGray;
                    circularPointer.FillGradientType = Dundas.Gauges.WinControl.GradientType.None;
                    circularPointer.Name = "Default";
                    circularPointer.NeedleStyle = Dundas.Gauges.WinControl.NeedleStyle.NeedleStyle11;
                    circularPointer.ShadowOffset = 0F;
                    circularPointer.Width = 10F;
                    circularPointer.Value = 0;
                    circularGauge.Pointers.Add(circularPointer);
                    circularScale.BorderColor = System.Drawing.Color.White;
                    circularScale.BorderWidth = 1;
                    circularScale.FillColor = System.Drawing.Color.Black;
                    circularScale.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.30189F);
                    circularScale.LabelStyle.RotateLabels = false;
                    circularScale.MajorTickMark.BorderWidth = 0;
                    circularScale.MajorTickMark.FillColor = System.Drawing.Color.Black;
                    circularScale.MajorTickMark.Shape = Dundas.Gauges.WinControl.MarkerStyle.Rectangle;
                    circularScale.MajorTickMark.Width = 2F;
                    circularScale.MinorTickMark.BorderWidth = 0;
                    circularScale.MinorTickMark.FillColor = System.Drawing.Color.Black;
                    circularScale.MinorTickMark.Width = 1.5F;
                    circularScale.Minimum = 0D;
                    circularScale.Maximum = 100D;
                    circularScale.Name = "Default";
                    circularScale.Radius = 44F;
                    circularScale.ShadowOffset = 0F;
                    circularScale.StartAngle = 30F;
                    circularScale.SweepAngle = 300F;
                    circularScale.Width = 0F;
                    circularGauge.Scales.Add(circularScale);
                    circularGauge.Size.Height = 100F;
                    circularGauge.Size.Width = 100F;
                    gaugeContainer.CircularGauges.Add(circularGauge);
                    gaugeContainer.InternalBackgroundPaint = false;
                    gaugeLabel.BackColor = System.Drawing.Color.Empty;
                    gaugeLabel.BackGradientEndColor = System.Drawing.Color.Empty;
                    gaugeLabel.Location.X = 19F;
                    gaugeLabel.Location.Y = 80F;
                    gaugeLabel.Name = "Default";
                    gaugeLabel.Parent = "CircularGauges.Default";
                    gaugeLabel.Size.Height = 18F;
                    gaugeLabel.Size.Width = 66F;
                    gaugeLabel.Text = "";
                    gaugeLabel.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
                    gaugeContainer.Labels.Add(gaugeLabel);
                    gaugeContainer.Location = new System.Drawing.Point(50, 50);
                    gaugeContainer.Name = obj.ObjectID.ToString();
                    gaugeContainer.Size = new System.Drawing.Size(100, 100);
                    gaugeContainer.TabIndex = 0;

                    gaugeContainer.Location = new System.Drawing.Point(50, 50);
                    gaugeContainer.Size = new Size(100, 100);
                    gaugeContainer.AccessibleName = obj.ObjectID.ToString();
                    gaugeContainer.AccessibleDescription = "4";

                    this.panel.Controls.Add(gaugeContainer);
                    gaugeContainer.BringToFront();
                    ControlMouseMoveEventRegister(gaugeContainer);
                    pb.WireControl(gaugeContainer);
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }
        private void verticalBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                GeoViewer.Models.Object obj = new Models.Object();
                obj.PictureViewID = _pictureView.PictureViewID;
                obj.Type = 5;
                obj.X = 50; obj.Y = 50;
                obj.Width = 100;
                obj.Height = 400;
                obj.Parameters = "0";
                obj.Z_Index = 1;
                if (entityConntext.Objects.
                    Where(ent => ent.PictureViewID == _pictureView.PictureViewID).OrderByDescending(ent => ent.Z_Index).Count() > 0)
                {
                    var topObject = entityConntext.Objects.
                        Where(ent => ent.PictureViewID == _pictureView.PictureViewID).OrderByDescending(ent => ent.Z_Index).First();
                    obj.Z_Index = topObject.Z_Index + 1;
                }
                obj.CreatedDate = DateTime.Now;
                obj.CreatedUser = AppContext.Current.LogedInUser.ToString();
                if (PictureViewBLL.Current.InsertObject(obj))
                {
                    Console.WriteLine("Insert Object Success, ID: " + obj.ObjectID);
                    PictureViewBLL.Current.Update(_pictureView);

                    Dundas.Gauges.WinControl.LinearGauge linearGauge1 = new Dundas.Gauges.WinControl.LinearGauge();
                    Dundas.Gauges.WinControl.LinearPointer linearPointer1 = new Dundas.Gauges.WinControl.LinearPointer();
                    Dundas.Gauges.WinControl.LinearScale linearScale1 = new Dundas.Gauges.WinControl.LinearScale();
                    Dundas.Gauges.WinControl.GaugeContainer gaugeContainer = new Dundas.Gauges.WinControl.GaugeContainer();
                    Dundas.Gauges.WinControl.GaugeLabel gaugeLabel1 = new Dundas.Gauges.WinControl.GaugeLabel();
                    gaugeContainer.BackFrame.BackColor = System.Drawing.Color.White;
                    gaugeContainer.BackFrame.BackGradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
                    gaugeContainer.BackFrame.BackGradientType = Dundas.Gauges.WinControl.GradientType.None;
                    gaugeContainer.BackFrame.FrameGradientEndColor = System.Drawing.Color.DimGray;
                    gaugeContainer.BackFrame.FrameGradientType = Dundas.Gauges.WinControl.GradientType.None;
                    gaugeContainer.BackFrame.FrameShape = Dundas.Gauges.WinControl.BackFrameShape.Rectangular;
                    gaugeContainer.BackFrame.FrameStyle = Dundas.Gauges.WinControl.BackFrameStyle.None;
                    gaugeContainer.BackFrame.FrameWidth = 2F;
                    gaugeContainer.InternalBackgroundPaint = false;
                    gaugeContainer.LinearGauges.Add(linearGauge1);
                    gaugeLabel1.BackColor = System.Drawing.Color.Empty;
                    gaugeLabel1.BackGradientEndColor = System.Drawing.Color.Empty;
                    gaugeLabel1.Location.X = 14.27777F;
                    gaugeLabel1.Location.Y = 87.39495F;
                    gaugeLabel1.Name = "Default";
                    gaugeLabel1.Parent = "LinearGauges.Default";
                    gaugeLabel1.Size.Height = 14F;
                    gaugeLabel1.Size.Width = 72F;
                    gaugeLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
                    gaugeLabel1.Text = "";
                    gaugeContainer.Labels.Add(gaugeLabel1);
                    linearGauge1.BackFrame.BackColor = System.Drawing.Color.White;
                    linearGauge1.BackFrame.BackGradientEndColor = System.Drawing.Color.DimGray;
                    linearGauge1.BackFrame.BackGradientType = Dundas.Gauges.WinControl.GradientType.None;
                    linearGauge1.BackFrame.FrameColor = System.Drawing.Color.Silver;
                    linearGauge1.BackFrame.FrameShape = Dundas.Gauges.WinControl.BackFrameShape.Rectangular;
                    linearGauge1.BackFrame.FrameStyle = Dundas.Gauges.WinControl.BackFrameStyle.Edged;
                    linearGauge1.BackFrame.FrameWidth = 1F;
                    linearGauge1.Location.X = 0F;
                    linearGauge1.Location.Y = 0F;
                    linearGauge1.Name = "Default";
                    linearGauge1.Orientation = Dundas.Gauges.WinControl.GaugeOrientation.Vertical;
                    linearPointer1.BorderWidth = 0;
                    linearPointer1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
                    System.Drawing.ColorConverter cv = new System.Drawing.ColorConverter();
                    linearPointer1.BorderWidth = 0;
                    linearPointer1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
                    linearPointer1.FillGradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
                    linearPointer1.FillGradientType = Dundas.Gauges.WinControl.GradientType.None;
                    linearPointer1.Name = "Default";
                    linearPointer1.Placement = Dundas.Gauges.WinControl.Placement.Cross;
                    linearPointer1.ShadowOffset = 0F;
                    linearPointer1.ThermometerBackColor = System.Drawing.Color.Empty;
                    linearPointer1.ThermometerBackGradientEndColor = System.Drawing.Color.Empty;
                    linearPointer1.Type = Dundas.Gauges.WinControl.LinearPointerType.Bar;
                    linearPointer1.Width = 15F;
                    linearGauge1.Pointers.Add(linearPointer1);
                    linearScale1.Minimum = 0D;
                    linearScale1.Maximum = 100D;
                    linearScale1.EndMargin = 6F;
                    linearScale1.FillColor = System.Drawing.Color.Black;
                    linearScale1.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F);
                    linearScale1.LabelStyle.FontUnit = Dundas.Gauges.WinControl.FontUnit.Default;
                    linearScale1.MajorTickMark.BorderWidth = 0;
                    linearScale1.MajorTickMark.FillColor = System.Drawing.Color.Black;
                    linearScale1.MajorTickMark.Length = 19F;
                    linearScale1.MajorTickMark.Width = 2F;
                    linearScale1.MinorTickMark.BorderWidth = 0;
                    linearScale1.MinorTickMark.FillColor = System.Drawing.Color.Black;
                    linearScale1.MinorTickMark.Length = 10F;
                    linearScale1.MinorTickMark.Width = 1.5F;
                    linearScale1.Name = "Default";
                    linearScale1.Position = 65F;
                    linearScale1.ShadowOffset = 0F;
                    linearScale1.StartMargin = 15F;
                    linearScale1.Width = 0F;
                    linearGauge1.Scales.Add(linearScale1);
                    linearGauge1.Size.Height = 100F;
                    linearGauge1.Size.Width = 100F;
                    gaugeContainer.Location = new System.Drawing.Point(50, 50);
                    gaugeContainer.Size = new System.Drawing.Size(100, 300);
                    gaugeContainer.TabIndex = 0;
                    gaugeContainer.LinearGauges["Default"].Pointers["Default"].Value = 0;
                    gaugeContainer.Name = obj.ObjectID.ToString();

                    gaugeContainer.Location = new System.Drawing.Point(50, 50);
                    gaugeContainer.Size = new System.Drawing.Size(100, 400);
                    gaugeContainer.AccessibleName = obj.ObjectID.ToString();
                    gaugeContainer.AccessibleDescription = "5";

                    this.panel.Controls.Add(gaugeContainer);
                    gaugeContainer.BringToFront();
                    ControlMouseMoveEventRegister(gaugeContainer);
                    pb.WireControl(gaugeContainer);
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }
        private void horizontalBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                GeoViewer.Models.Object obj = new Models.Object();
                obj.PictureViewID = _pictureView.PictureViewID;
                obj.Type = 6;
                obj.X = 50; obj.Y = 50;
                obj.Width = 400;
                obj.Height = 100;
                obj.Parameters = "0";
                obj.Z_Index = 1;
                if (entityConntext.Objects.
                    Where(ent => ent.PictureViewID == _pictureView.PictureViewID).OrderByDescending(ent => ent.Z_Index).Count() > 0)
                {
                    var topObject = entityConntext.Objects.
                        Where(ent => ent.PictureViewID == _pictureView.PictureViewID).OrderByDescending(ent => ent.Z_Index).First();
                    obj.Z_Index = topObject.Z_Index + 1;
                }
                obj.CreatedDate = DateTime.Now;
                obj.CreatedUser = AppContext.Current.LogedInUser.ToString();
                if (PictureViewBLL.Current.InsertObject(obj))
                {
                    Console.WriteLine("Insert Object Success, ID: " + obj.ObjectID);
                    PictureViewBLL.Current.Update(_pictureView);

                    Dundas.Gauges.WinControl.LinearGauge linearGauge1 = new Dundas.Gauges.WinControl.LinearGauge();
                    Dundas.Gauges.WinControl.LinearPointer linearPointer1 = new Dundas.Gauges.WinControl.LinearPointer();
                    Dundas.Gauges.WinControl.LinearScale linearScale1 = new Dundas.Gauges.WinControl.LinearScale();
                    Dundas.Gauges.WinControl.InputValue inputValue1 = new Dundas.Gauges.WinControl.InputValue();
                    Dundas.Gauges.WinControl.GaugeContainer gaugeContainer1 = new Dundas.Gauges.WinControl.GaugeContainer();
                    Dundas.Gauges.WinControl.GaugeLabel gaugeLabel1 = new Dundas.Gauges.WinControl.GaugeLabel();
                    gaugeContainer1.BackFrame.BackColor = System.Drawing.Color.White;
                    gaugeContainer1.BackFrame.BackGradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
                    gaugeContainer1.BackFrame.BackGradientType = Dundas.Gauges.WinControl.GradientType.None;
                    gaugeContainer1.BackFrame.FrameGradientEndColor = System.Drawing.Color.DimGray;
                    gaugeContainer1.BackFrame.FrameGradientType = Dundas.Gauges.WinControl.GradientType.None;
                    gaugeContainer1.BackFrame.FrameShape = Dundas.Gauges.WinControl.BackFrameShape.Rectangular;
                    gaugeContainer1.BackFrame.FrameStyle = Dundas.Gauges.WinControl.BackFrameStyle.None;
                    gaugeContainer1.BackFrame.FrameWidth = 2F;
                    gaugeContainer1.InternalBackgroundPaint = false;
                    gaugeContainer1.LinearGauges.Add(linearGauge1);
                    gaugeLabel1.BackColor = System.Drawing.Color.Empty;
                    gaugeLabel1.BackGradientEndColor = System.Drawing.Color.Empty;
                    gaugeLabel1.Location.X = 32F;
                    gaugeLabel1.Location.Y = 62F;
                    gaugeLabel1.Name = "Default";
                    gaugeLabel1.Parent = "LinearGauges.Default";
                    gaugeLabel1.Size.Height = 34F;
                    gaugeLabel1.Size.Width = 39F;
                    gaugeLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
                    gaugeLabel1.Text = "";
                    gaugeContainer1.Labels.Add(gaugeLabel1);
                    linearGauge1.BackFrame.BackColor = System.Drawing.Color.White;
                    linearGauge1.BackFrame.BackGradientEndColor = System.Drawing.Color.DimGray;
                    linearGauge1.BackFrame.BackGradientType = Dundas.Gauges.WinControl.GradientType.None;
                    linearGauge1.BackFrame.FrameColor = System.Drawing.Color.Silver;
                    linearGauge1.BackFrame.FrameShape = Dundas.Gauges.WinControl.BackFrameShape.Rectangular;
                    linearGauge1.BackFrame.FrameStyle = Dundas.Gauges.WinControl.BackFrameStyle.Edged;
                    linearGauge1.BackFrame.FrameWidth = 2F;
                    linearGauge1.Location.X = 0F;
                    linearGauge1.Location.Y = 0F;
                    linearGauge1.Name = "Default";
                    linearGauge1.Orientation = Dundas.Gauges.WinControl.GaugeOrientation.Horizontal;
                    linearPointer1.BorderWidth = 0;
                    linearPointer1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
                    System.Drawing.ColorConverter cv = new System.Drawing.ColorConverter();
                    linearPointer1.BorderWidth = 0;
                    linearPointer1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
                    linearPointer1.FillGradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
                    linearPointer1.FillGradientType = Dundas.Gauges.WinControl.GradientType.None;
                    linearPointer1.Name = "Default";
                    linearPointer1.ShadowOffset = 0F;
                    linearPointer1.ThermometerBackColor = System.Drawing.Color.Empty;
                    linearPointer1.ThermometerBackGradientEndColor = System.Drawing.Color.Empty;
                    linearPointer1.Type = Dundas.Gauges.WinControl.LinearPointerType.Bar;
                    linearPointer1.Placement = Dundas.Gauges.WinControl.Placement.Cross;
                    linearPointer1.Width = 15F;
                    linearGauge1.Pointers.Add(linearPointer1);
                    linearScale1.Minimum = 0D;
                    linearScale1.Maximum = 100D;
                    linearScale1.EndMargin = 5F;
                    linearScale1.FillColor = System.Drawing.Color.Black;
                    linearScale1.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.30189F);
                    linearScale1.MajorTickMark.BorderWidth = 0;
                    linearScale1.MajorTickMark.FillColor = System.Drawing.Color.Black;
                    linearScale1.MajorTickMark.Length = 20F;
                    linearScale1.MajorTickMark.Width = 2F;
                    linearScale1.MinorTickMark.BorderWidth = 0;
                    linearScale1.MinorTickMark.FillColor = System.Drawing.Color.Black;
                    linearScale1.MinorTickMark.Length = 12F;
                    linearScale1.MinorTickMark.Width = 1.5F;
                    linearScale1.Name = "Default";
                    linearScale1.Position = 45F;
                    linearScale1.ShadowOffset = 0F;
                    linearScale1.StartMargin = 5F;
                    linearScale1.Width = 0F;
                    linearGauge1.Scales.Add(linearScale1);
                    linearGauge1.Size.Height = 100F;
                    linearGauge1.Size.Width = 100F;
                    gaugeContainer1.Location = new System.Drawing.Point(50, 50);
                    gaugeContainer1.Size = new System.Drawing.Size(300, 100);
                    gaugeContainer1.TabIndex = 0;
                    this.Controls.Add(gaugeContainer1);
                    gaugeContainer1.BringToFront();
                    gaugeContainer1.LinearGauges["Default"].Pointers["Default"].Value = 0;
                    gaugeContainer1.Name = obj.ObjectID.ToString();

                    gaugeContainer1.Location = new System.Drawing.Point(50, 50);
                    gaugeContainer1.Size = new System.Drawing.Size(400, 100);
                    gaugeContainer1.AccessibleName = obj.ObjectID.ToString();
                    gaugeContainer1.AccessibleDescription = "6";

                    this.panel.Controls.Add(gaugeContainer1);
                    gaugeContainer1.BringToFront();
                    ControlMouseMoveEventRegister(gaugeContainer1);
                    pb.WireControl(gaugeContainer1);
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }
        private void meterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                GeoViewer.Models.Object obj = new Models.Object();
                obj.PictureViewID = _pictureView.PictureViewID;
                obj.Type = 7;
                obj.X = 50; obj.Y = 50;
                obj.Width = 300;
                obj.Height = 100;
                obj.Parameters = "0";
                obj.Z_Index = 1;
                if (entityConntext.Objects.
                    Where(ent => ent.PictureViewID == _pictureView.PictureViewID).OrderByDescending(ent => ent.Z_Index).Count() > 0)
                {
                    var topObject = entityConntext.Objects.
                        Where(ent => ent.PictureViewID == _pictureView.PictureViewID).OrderByDescending(ent => ent.Z_Index).First();
                    obj.Z_Index = topObject.Z_Index + 1;
                }
                obj.CreatedDate = DateTime.Now;
                obj.CreatedUser = AppContext.Current.LogedInUser.ToString();
                if (PictureViewBLL.Current.InsertObject(obj))
                {
                    Console.WriteLine("Insert Object Success, ID: " + obj.ObjectID);
                    PictureViewBLL.Current.Update(_pictureView);

                    Dundas.Gauges.WinControl.GaugeContainer gaugeContainer = new Dundas.Gauges.WinControl.GaugeContainer();
                    Dundas.Gauges.WinControl.CircularGauge circularGauge = new Dundas.Gauges.WinControl.CircularGauge();
                    Dundas.Gauges.WinControl.CircularPointer circularPointer = new Dundas.Gauges.WinControl.CircularPointer();
                    Dundas.Gauges.WinControl.CircularScale circularScale = new Dundas.Gauges.WinControl.CircularScale();
                    Dundas.Gauges.WinControl.GaugeLabel gaugeLabel = new Dundas.Gauges.WinControl.GaugeLabel();

                    gaugeContainer.BackFrame.BackColor = System.Drawing.Color.White;
                    gaugeContainer.BackFrame.BackGradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
                    gaugeContainer.BackFrame.BackGradientType = Dundas.Gauges.WinControl.GradientType.None;
                    gaugeContainer.BackFrame.FrameGradientEndColor = System.Drawing.Color.DimGray;
                    gaugeContainer.BackFrame.FrameGradientType = Dundas.Gauges.WinControl.GradientType.None;
                    gaugeContainer.BackFrame.FrameShape = Dundas.Gauges.WinControl.BackFrameShape.Rectangular;
                    gaugeContainer.BackFrame.FrameStyle = Dundas.Gauges.WinControl.BackFrameStyle.None;
                    gaugeContainer.BackFrame.FrameWidth = 0F;
                    circularGauge.BackFrame.BackColor = System.Drawing.Color.White;
                    circularGauge.BackFrame.BackGradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
                    circularGauge.BackFrame.BackGradientType = Dundas.Gauges.WinControl.GradientType.None;
                    circularGauge.BackFrame.BorderColor = System.Drawing.Color.Gray;
                    circularGauge.BackFrame.BorderWidth = 2;
                    circularGauge.BackFrame.FrameGradientEndColor = System.Drawing.Color.DimGray;
                    circularGauge.BackFrame.FrameGradientType = Dundas.Gauges.WinControl.GradientType.None;
                    circularGauge.BackFrame.FrameShape = Dundas.Gauges.WinControl.BackFrameShape.Rectangular;
                    circularGauge.BackFrame.FrameStyle = Dundas.Gauges.WinControl.BackFrameStyle.Edged;
                    circularGauge.BackFrame.FrameWidth = 0F;
                    circularGauge.Location.X = 0F;
                    circularGauge.Location.Y = 0F;
                    circularGauge.Name = "Default";
                    circularGauge.PivotPoint.X = 50F;
                    circularGauge.PivotPoint.Y = 263F;
                    circularPointer.BorderWidth = 0;
                    circularPointer.CapFillColor = System.Drawing.Color.Silver;
                    circularPointer.CapFillGradientType = Dundas.Gauges.WinControl.GradientType.None;
                    circularPointer.CapVisible = false;
                    circularPointer.CapWidth = 30F;
                    circularPointer.FillColor = System.Drawing.Color.Lime;
                    circularPointer.FillGradientType = Dundas.Gauges.WinControl.GradientType.None;
                    circularPointer.Name = "Default";
                    circularPointer.ShadowOffset = 0F;
                    circularPointer.Width = 6.1F;
                    circularGauge.Pointers.Add(circularPointer);
                    circularScale.BorderColor = System.Drawing.Color.White;
                    circularScale.BorderWidth = 1;
                    circularScale.FillColor = System.Drawing.Color.Black;
                    circularScale.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F);
                    circularScale.MajorTickMark.BorderWidth = 0;
                    circularScale.MajorTickMark.FillColor = System.Drawing.Color.Black;
                    circularScale.MajorTickMark.Length = 6F;
                    circularScale.MajorTickMark.Shape = Dundas.Gauges.WinControl.MarkerStyle.Rectangle;
                    circularScale.MajorTickMark.Width = 2F;
                    circularScale.MinorTickMark.BorderWidth = 0;
                    circularScale.MinorTickMark.FillColor = System.Drawing.Color.Black;
                    circularScale.MinorTickMark.Length = 4F;
                    circularScale.MinorTickMark.Width = 1F;
                    circularScale.Name = "Default";
                    circularScale.Radius = 249F;
                    circularScale.ShadowOffset = 0F;
                    circularScale.StartAngle = 150F;
                    circularScale.SweepAngle = 60F;
                    circularScale.Width = 0F;
                    circularGauge.Scales.Add(circularScale);
                    circularGauge.Size.Height = 100F;
                    circularGauge.Size.Width = 100F;
                    gaugeContainer.CircularGauges.Add(circularGauge);
                    gaugeContainer.InternalBackgroundPaint = false;
                    gaugeLabel.BackColor = System.Drawing.Color.Empty;
                    gaugeLabel.BackGradientEndColor = System.Drawing.Color.Empty;
                    gaugeLabel.Location.X = 25F;
                    gaugeLabel.Location.Y = 68F;
                    gaugeLabel.Name = "Default";
                    gaugeLabel.Parent = "CircularGauges.Default";
                    gaugeLabel.Size.Height = 33F;
                    gaugeLabel.Size.Width = 56F;
                    gaugeLabel.Text = "";
                    gaugeLabel.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
                    gaugeContainer.Labels.Add(gaugeLabel);
                    gaugeContainer.Name = obj.ObjectID.ToString();
                    gaugeContainer.TabIndex = 0;

                    gaugeContainer.Location = new System.Drawing.Point(50, 50);
                    gaugeContainer.Size = new Size(300, 120);
                    gaugeContainer.AccessibleName = obj.ObjectID.ToString();
                    gaugeContainer.AccessibleDescription = "7";

                    this.panel.Controls.Add(gaugeContainer);
                    gaugeContainer.BringToFront();
                    ControlMouseMoveEventRegister(gaugeContainer);
                    pb.WireControl(gaugeContainer);
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }
        private void numericIndicatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                GeoViewer.Models.Object obj = new Models.Object();
                obj.PictureViewID = _pictureView.PictureViewID;
                obj.Type = 8;
                obj.X = 50; obj.Y = 50;
                obj.Width = 300;
                obj.Height = 80;
                obj.Parameters = "0";
                obj.Z_Index = 1;
                if (entityConntext.Objects.
                    Where(ent => ent.PictureViewID == _pictureView.PictureViewID).OrderByDescending(ent => ent.Z_Index).Count() > 0)
                {
                    var topObject = entityConntext.Objects.
                        Where(ent => ent.PictureViewID == _pictureView.PictureViewID).OrderByDescending(ent => ent.Z_Index).First();
                    obj.Z_Index = topObject.Z_Index + 1;
                }
                obj.CreatedDate = DateTime.Now;
                obj.CreatedUser = AppContext.Current.LogedInUser.ToString();
                if (PictureViewBLL.Current.InsertObject(obj))
                {
                    Console.WriteLine("Insert Object Success, ID: " + obj.ObjectID);
                    PictureViewBLL.Current.Update(_pictureView);

                    Dundas.Gauges.WinControl.GaugeContainer gaugeContainer2 = new Dundas.Gauges.WinControl.GaugeContainer();
                    Dundas.Gauges.WinControl.GaugeLabel gaugeLabel2 = new Dundas.Gauges.WinControl.GaugeLabel();
                    Dundas.Gauges.WinControl.NumericIndicator numericIndicator = new Dundas.Gauges.WinControl.NumericIndicator();
                    gaugeContainer2.BackFrame.BackColor = System.Drawing.Color.White;
                    gaugeContainer2.BackFrame.BackGradientEndColor = System.Drawing.Color.White;
                    gaugeContainer2.BackFrame.BackGradientType = Dundas.Gauges.WinControl.GradientType.None;
                    gaugeContainer2.BackFrame.BorderWidth = 2;
                    gaugeContainer2.BackFrame.FrameGradientEndColor = System.Drawing.Color.DimGray;
                    gaugeContainer2.BackFrame.FrameGradientType = Dundas.Gauges.WinControl.GradientType.None;
                    gaugeContainer2.BackFrame.FrameShape = Dundas.Gauges.WinControl.BackFrameShape.Rectangular;
                    gaugeContainer2.BackFrame.FrameStyle = Dundas.Gauges.WinControl.BackFrameStyle.Simple;
                    gaugeContainer2.BackFrame.FrameWidth = 0F;
                    gaugeContainer2.InternalBackgroundPaint = false;
                    gaugeContainer2.NumericIndicators.Add(numericIndicator);
                    numericIndicator.BackColor = System.Drawing.Color.Transparent;
                    numericIndicator.BackGradientType = Dundas.Gauges.WinControl.GradientType.None;
                    numericIndicator.BorderColor = System.Drawing.Color.Black;
                    numericIndicator.BorderWidth = 0;
                    numericIndicator.DecimalColor = System.Drawing.Color.Black;
                    numericIndicator.Decimals = 2;
                    numericIndicator.DigitColor = System.Drawing.Color.Black;
                    numericIndicator.IndicatorStyle = Dundas.Gauges.WinControl.NumericIndicatorStyle.Digital7Segment;
                    numericIndicator.LedDimColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
                    numericIndicator.Location.X = 0F;
                    numericIndicator.Location.Y = -20F;
                    numericIndicator.Name = "Default";
                    numericIndicator.Parent = "";
                    numericIndicator.ShowDecimalPoint = true;
                    numericIndicator.Size.Height = 99F;
                    numericIndicator.Size.Width = 99F;
                    numericIndicator.Value = 367.12D;
                    numericIndicator.Digits = 6;
                    gaugeLabel2.BackColor = System.Drawing.Color.Empty;
                    gaugeLabel2.BackGradientEndColor = System.Drawing.Color.Empty;
                    gaugeLabel2.Location.X = 26F;
                    gaugeLabel2.Location.Y = 75F;
                    gaugeLabel2.Name = "Default";
                    gaugeLabel2.Parent = "NumericIndicators.Default";
                    gaugeLabel2.Size.Height = 50F;
                    gaugeLabel2.Size.Width = 51F;
                    gaugeLabel2.Text = "";
                    gaugeLabel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
                    gaugeContainer2.Labels.Add(gaugeLabel2);
                    gaugeContainer2.Location = new System.Drawing.Point(50, 50);
                    gaugeContainer2.Name = obj.ObjectID.ToString();
                    gaugeContainer2.Size = new System.Drawing.Size(200, 100);
                    gaugeContainer2.TabIndex = 0;

                    gaugeContainer2.NumericIndicators["Default"].Value = 0;

                    gaugeContainer2.Location = new System.Drawing.Point(50, 50);
                    gaugeContainer2.Size = new Size(300, 80);
                    gaugeContainer2.AccessibleName = obj.ObjectID.ToString();
                    gaugeContainer2.AccessibleDescription = "8";

                    this.panel.Controls.Add(gaugeContainer2);
                    gaugeContainer2.BringToFront();
                    ControlMouseMoveEventRegister(gaugeContainer2);
                    pb.WireControl(gaugeContainer2);
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }
        //
        // Edit Context Menu
        //
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int idObject = Convert.ToInt32(currentRightClickCtrl.AccessibleName);
                if (entityConntext.Objects.Where(ent => ent.ObjectID == idObject).Count() > 0)
                {
                    DialogResult result = ShowConfirmMessage("Bạn thật sự muốn xóa đối tượng này?");
                    if (result == DialogResult.OK)
                    {
                        var obj = PictureViewBLL.Current.GetObjectByID(idObject);
                        PictureViewBLL.Current.DeleteObject(obj.ObjectID);
                        PictureViewBLL.Current.Update(_pictureView);
                        this.panel.Controls.Remove(currentRightClickCtrl);
                        currentRightClickCtrl = null;
                    }
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }
        private void bringToFrontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                currentRightClickCtrl.BringToFront();
                int idObject = Convert.ToInt32(currentRightClickCtrl.AccessibleName);
                var obj = PictureViewBLL.Current.GetObjectByID(idObject);
                if (obj != null)
                {
                    var objectlist = entityConntext.Objects.Where(ent => ent.PictureViewID == _pictureView.PictureViewID);
                    foreach (GeoViewer.Models.Object obje in objectlist)
                    {
                        if ((obje.ObjectID != obj.ObjectID) && (obje.Z_Index > obj.Z_Index))
                        {
                            obje.Z_Index = obje.Z_Index - 1;
                            PictureViewBLL.Current.UpdateObject(obje);
                        }
                        objectlist = entityConntext.Objects.
                            Where(ent => ent.PictureViewID == _pictureView.PictureViewID).OrderByDescending(ent => ent.Z_Index);
                        var topObject = objectlist.First();
                        obj.Z_Index = topObject.Z_Index + 1;
                    }
                    PictureViewBLL.Current.UpdateObject(obj);
                }
                PictureViewBLL.Current.Update(_pictureView);
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }
        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            switch (currentRightClickCtrl.AccessibleDescription)
            {
                case "1":
                    editIndicator(currentRightClickCtrl);
                    break;
                case "2":
                    editGroupIndicator(currentRightClickCtrl);
                    break;
                case "3":
                    editImage(currentRightClickCtrl);
                    break;
                case "4":
                    editGauge(currentRightClickCtrl);
                    break;
                case "5":
                    editBar(currentRightClickCtrl);
                    break;
                case "6":
                    editBar(currentRightClickCtrl);
                    break;
                case "7":
                    editMeter(currentRightClickCtrl);
                    break;
                case "8":
                    editNumericIndicator(currentRightClickCtrl);
                    break;
                default:
                    break;
            }
            currentRightClickCtrl = null;
        }
        //
        // Edit methods
        //
        private void editImage(Control c)
        {
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    int idObject = Convert.ToInt32(c.AccessibleName);
                    // Edited by binhpro 22/11/2012
                    // Copy image to installed folder
                    string imagePath = PictureViewBLL.Current.CopyImageFile(openFileDialog.FileName, idObject);
                    System.Windows.Forms.PictureBox p = (PictureBox)c;
                    System.Drawing.Image image = System.Drawing.Image.FromFile(imagePath);
                    p.ImageLocation = imagePath;
                    p.Size = image.Size;
                    p.SizeMode = PictureBoxSizeMode.StretchImage;
                    pb.WireControl(p);

                    var obj = PictureViewBLL.Current.GetObjectByID(idObject);
                    if (obj != null)
                    {
                        obj.Parameters = imagePath;
                        PictureViewBLL.Current.UpdateObject(obj);
                    }
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }
        private void editIndicator(Control c)
        {
            try
            {
                int idObject = Convert.ToInt32(c.AccessibleName);
                indicator ind = (indicator)c;
                using (EditObjectForm f = new EditObjectForm(idObject))
                {
                    f.ShowDialog();
                    if (f.Submitted)
                    {
                        // Update object
                        var obj = PictureViewBLL.Current.GetObjectByID(idObject);
                        obj.Parameters = f.IDVar.ToString();
                        obj.Width = f.IndWidth;
                        obj.Height = f.IndHeight;
                        obj.X = f.IndLeft;
                        obj.Y = f.IndTop;
                        PictureViewBLL.Current.UpdateObject(obj);
                        // Update indicator on-screen
                        ind.Location = new System.Drawing.Point(f.IndLeft, f.IndTop);
                        ind.Size = new Size(f.IndWidth, f.IndHeight);
                        // Reset properties
                        ind.FillColor = System.Drawing.Color.Lime;
                        ind.VarName = "Name";
                        ind.UnitName = "Unit";
                        ind.Value = "Value";
                        // Associate with new sensor
                        var sensor = SensorBLL.Current.GetByID(f.IDVar);
                        if (sensor != null)
                        {
                            ind.VarName = sensor.Name;
                            ind.UnitName = sensor.Unit;
                            // Find value
                            if (entityConntext.SensorValues.
                                    Where(ent => ent.SensorID == sensor.SensorID).OrderByDescending(ent => ent.MeaTime).Count() > 0)
                            {
                                SensorValue sensorValue = entityConntext.SensorValues.
                                    Where(ent => ent.SensorID == sensor.SensorID).OrderByDescending(ent => ent.MeaTime).First();
                                ind.Value = getDisplayValue(sensorValue);
                                // Check if value is in alarm level
                                if (PictureViewBLL.Current.CheckAlarmRunning(obj))
                                    ind.FillColor = Color.Red;
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }
        private void editGroupIndicator(Control c)
        {
            try
            {
                int idObject = Convert.ToInt32(c.AccessibleName);
                groupIndicator ind = (groupIndicator)c;
                using (EditGroupIndicatorForm f = new EditGroupIndicatorForm(idObject))
                {
                    f.ShowDialog();
                    if (f.Submitted)
                    {
                        // Update object
                        var obj = PictureViewBLL.Current.GetObjectByID(idObject);
                        obj.Parameters = f.IDPicture.ToString();
                        obj.Width = f.IndWidth;
                        obj.Height = f.IndHeight;
                        obj.X = f.IndLeft;
                        obj.Y = f.IndTop;
                        PictureViewBLL.Current.UpdateObject(obj);
                        // Update group indicator on-screen
                        ind.Location = new System.Drawing.Point(f.IndLeft, f.IndTop);
                        ind.Size = new Size(f.IndWidth, f.IndHeight);
                        ind.FillColor = System.Drawing.Color.Lime;
                        // Check if new values is in alarm level
                        int idPicture = Convert.ToInt32(obj.Parameters);
                        var subObjectList = entityConntext.Objects.
                            Where(ent => ent.PictureViewID == idPicture);
                        foreach (GeoViewer.Models.Object subObject in subObjectList)
                        {
                            if (PictureViewBLL.Current.CheckAlarmRunning(subObject))
                            {
                                ind.FillColor = Color.Red;
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }
        private void editGauge(Control c)
        {
            try
            {
                int idObject = Convert.ToInt32(c.AccessibleName);
                Dundas.Gauges.WinControl.GaugeContainer ind = (Dundas.Gauges.WinControl.GaugeContainer)c;
                using (EditObjectForm f = new EditObjectForm(idObject))
                {
                    f.ShowDialog();
                    if (f.Submitted)
                    {
                        // Update object
                        var obj = PictureViewBLL.Current.GetObjectByID(idObject);
                        obj.Parameters = f.IDVar.ToString();
                        obj.Width = f.IndWidth;
                        obj.Height = f.IndHeight;
                        obj.X = f.IndLeft;
                        obj.Y = f.IndTop;
                        PictureViewBLL.Current.UpdateObject(obj);
                        // Update gauge on-screen
                        ind.Location = new System.Drawing.Point(f.IndLeft, f.IndTop);
                        ind.Size = new Size(f.IndWidth, f.IndHeight);
                        // Reset properties
                        ind.CircularGauges["Default"].Pointers["Default"].FillColor = System.Drawing.Color.Lime;
                        ind.CircularGauges["Default"].Scales["Default"].Minimum = 0;
                        ind.Labels["Default"].Text = "";
                        // Associate with new sensor
                        var sensor = SensorBLL.Current.GetByID(f.IDVar);
                        if (sensor != null)
                        {
                            ind.Labels["Default"].Text = sensor.Name + "\n" + sensor.Unit;
                            if (sensor.MaxValue != null) ind.CircularGauges["Default"].Scales["Default"].Maximum = System.Convert.ToDouble(sensor.MaxValue);
                            if (sensor.MinValue != null) ind.CircularGauges["Default"].Scales["Default"].Minimum = System.Convert.ToDouble(sensor.MinValue);
                            // Find value
                            if (entityConntext.SensorValues.
                                    Where(ent => ent.SensorID == sensor.SensorID).OrderByDescending(ent => ent.MeaTime).Count() > 0)
                            {
                                SensorValue sensorValue = entityConntext.SensorValues.
                                    Where(ent => ent.SensorID == sensor.SensorID).OrderByDescending(ent => ent.MeaTime).First();
                                if (sensor.MaxValue == null)
                                    ind.CircularGauges["Default"].Scales["Default"].Maximum = Math.Round(System.Convert.ToDouble(getSensorValue(sensorValue)) + 1D, 0);
                                if (sensor.MinValue == null)
                                    ind.CircularGauges["Default"].Scales["Default"].Minimum = Math.Round(System.Convert.ToDouble(getSensorValue(sensorValue)) - 1D, 0);
                                ind.CircularGauges["Default"].Pointers["Default"].Value = System.Convert.ToDouble(getSensorValue(sensorValue));
                                ind.Labels["Default"].Text = sensor.Name + "\n" + getSensorValue(sensorValue).ToString() + " " + sensor.Unit;
                                // Check if value is in alarm level
                                if (PictureViewBLL.Current.CheckAlarmRunning(obj))
                                    ind.CircularGauges["Default"].Pointers["Default"].FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                            }
                        }

                    }
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }
        private void editBar(Control c)
        {
            try
            {
                int idObject = Convert.ToInt32(c.AccessibleName);
                Dundas.Gauges.WinControl.GaugeContainer ind = (Dundas.Gauges.WinControl.GaugeContainer)c;
                using (EditObjectForm f = new EditObjectForm(idObject))
                {
                    f.ShowDialog();
                    if (f.Submitted)
                    {
                        // Update object
                        var obj = PictureViewBLL.Current.GetObjectByID(idObject);
                        obj.Parameters = f.IDVar.ToString();
                        obj.Width = f.IndWidth;
                        obj.Height = f.IndHeight;
                        obj.X = f.IndLeft;
                        obj.Y = f.IndTop;
                        PictureViewBLL.Current.UpdateObject(obj);
                        // Update indicator on-screen
                        ind.Location = new System.Drawing.Point(f.IndLeft, f.IndTop);
                        ind.Size = new Size(f.IndWidth, f.IndHeight);
                        // Reset properties
                        ind.LinearGauges["Default"].Pointers["Default"].FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
                        ind.LinearGauges["Default"].Scales["Default"].Minimum = 0;
                        ind.Labels["Default"].Text = "";
                        // Associate with new sensor
                        var sensor = SensorBLL.Current.GetByID(f.IDVar);
                        if (sensor != null)
                        {
                            ind.Labels["Default"].Text = sensor.Name + "\n" + sensor.Unit;
                            if (sensor.MaxValue != null) ind.LinearGauges["Default"].Scales["Default"].Maximum = System.Convert.ToDouble(sensor.MaxValue);
                            if (sensor.MinValue != null) ind.LinearGauges["Default"].Scales["Default"].Minimum = System.Convert.ToDouble(sensor.MinValue);
                            // Find value
                            if (entityConntext.SensorValues.
                                    Where(ent => ent.SensorID == sensor.SensorID).OrderByDescending(ent => ent.MeaTime).Count() > 0)
                            {
                                SensorValue sensorValue = entityConntext.SensorValues.
                                    Where(ent => ent.SensorID == sensor.SensorID).OrderByDescending(ent => ent.MeaTime).First();
                                if (sensor.MaxValue == null)
                                    ind.LinearGauges["Default"].Scales["Default"].Maximum = Math.Round(System.Convert.ToDouble(getSensorValue(sensorValue)) + 1D, 0);
                                if (sensor.MinValue == null)
                                    ind.LinearGauges["Default"].Scales["Default"].Minimum = Math.Round(System.Convert.ToDouble(getSensorValue(sensorValue)) - 1D, 0);
                                ind.LinearGauges["Default"].Pointers["Default"].Value = System.Convert.ToDouble(getSensorValue(sensorValue));
                                ind.Labels["Default"].Text = sensor.Name + "\n" + getSensorValue(sensorValue).ToString() + " " + sensor.Unit;
                                // Check if value is in alarm level
                                if (PictureViewBLL.Current.CheckAlarmRunning(obj))
                                    ind.LinearGauges["Default"].Pointers["Default"].FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }
        private void editMeter(Control c)
        {
            try
            {
                int idObject = Convert.ToInt32(c.AccessibleName);
                Dundas.Gauges.WinControl.GaugeContainer ind = (Dundas.Gauges.WinControl.GaugeContainer)c;
                using (EditObjectForm f = new EditObjectForm(idObject))
                {
                    f.ShowDialog();
                    if (f.Submitted)
                    {
                        // Update object
                        var obj = PictureViewBLL.Current.GetObjectByID(idObject);
                        obj.Parameters = f.IDVar.ToString();
                        obj.Width = f.IndWidth;
                        obj.Height = f.IndHeight;
                        obj.X = f.IndLeft;
                        obj.Y = f.IndTop;
                        PictureViewBLL.Current.UpdateObject(obj);
                        // Update gauge on-screen
                        ind.Location = new System.Drawing.Point(f.IndLeft, f.IndTop);
                        ind.Size = new Size(f.IndWidth, f.IndHeight);
                        // Reset properties
                        ind.Labels["Default"].Text = "";
                        ind.CircularGauges["Default"].Pointers["Default"].FillColor = System.Drawing.Color.Lime;
                        ind.CircularGauges["Default"].Scales["Default"].Minimum = 0;
                        // Associate with new sensor
                        var sensor = SensorBLL.Current.GetByID(f.IDVar);
                        if (sensor != null)
                        {
                            ind.Labels["Default"].Text = sensor.Name + "\n" + sensor.Unit;
                            if (sensor.MaxValue != null) ind.CircularGauges["Default"].Scales["Default"].Maximum = System.Convert.ToDouble(sensor.MaxValue);
                            if (sensor.MinValue != null) ind.CircularGauges["Default"].Scales["Default"].Minimum = System.Convert.ToDouble(sensor.MinValue);
                            // Find value
                            if (entityConntext.SensorValues.
                                        Where(ent => ent.SensorID == sensor.SensorID).OrderByDescending(ent => ent.MeaTime).Count() > 0)
                            {
                                SensorValue sensorValue = entityConntext.SensorValues.
                                    Where(ent => ent.SensorID == sensor.SensorID).OrderByDescending(ent => ent.MeaTime).First();
                                if (sensor.MaxValue == null)
                                    ind.CircularGauges["Default"].Scales["Default"].Maximum = Math.Round(System.Convert.ToDouble(getSensorValue(sensorValue)) + 1D, 0);
                                if (sensor.MinValue == null)
                                    ind.CircularGauges["Default"].Scales["Default"].Minimum = Math.Round(System.Convert.ToDouble(getSensorValue(sensorValue)) - 1D, 0);
                                ind.CircularGauges["Default"].Pointers["Default"].Value = System.Convert.ToDouble(getSensorValue(sensorValue));
                                ind.Labels["Default"].Text = sensor.Name + "\n" + getSensorValue(sensorValue).ToString() + " " + sensor.Unit;
                                // Check if value is in alarm level
                                if (PictureViewBLL.Current.CheckAlarmRunning(obj))
                                    ind.CircularGauges["Default"].Pointers["Default"].FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }
        private void editNumericIndicator(Control c)
        {
            try
            {
                int idObject = Convert.ToInt32(c.AccessibleName);
                Dundas.Gauges.WinControl.GaugeContainer ind = (Dundas.Gauges.WinControl.GaugeContainer)c;
                using (EditObjectForm f = new EditObjectForm(idObject))
                {
                    f.ShowDialog();
                    if (f.Submitted)
                    {
                        // Update object
                        var obj = PictureViewBLL.Current.GetObjectByID(idObject);
                        obj.Parameters = f.IDVar.ToString();
                        obj.Width = f.IndWidth;
                        obj.Height = f.IndHeight;
                        obj.X = f.IndLeft;
                        obj.Y = f.IndTop;
                        PictureViewBLL.Current.UpdateObject(obj);
                        // Update gauge on-screen
                        ind.Location = new System.Drawing.Point(f.IndLeft, f.IndTop);
                        ind.Size = new Size(f.IndWidth, f.IndHeight);
                        // Reset properties
                        ind.Labels["Default"].Text = "";
                        ind.NumericIndicators["Default"].DigitColor = Color.Black;
                        ind.NumericIndicators["Default"].DecimalColor = Color.Black;
                        ind.NumericIndicators["Default"].SeparatorColor = Color.Black;
                        ind.NumericIndicators["Default"].Value = 0;
                        // Associate with new sensor
                        var sensor = SensorBLL.Current.GetByID(f.IDVar);
                        if (sensor != null)
                        {
                            ind.Labels["Default"].Text = sensor.Name + "\n" + sensor.Unit;
                            if (sensor.MaxValue != null) ind.NumericIndicators["Default"].Digits = System.Convert.ToInt32(System.Math.Log10(System.Convert.ToInt32(sensor.MaxValue) + 1)) + 1 + 2 + 1;
                            // Find value
                            if (entityConntext.SensorValues.
                                        Where(ent => ent.SensorID == sensor.SensorID).OrderByDescending(ent => ent.MeaTime).Count() > 0)
                            {
                                SensorValue sensorValue = entityConntext.SensorValues.
                                    Where(ent => ent.SensorID == sensor.SensorID).OrderByDescending(ent => ent.MeaTime).First();
                                if (sensor.MaxValue == null)
                                    ind.NumericIndicators["Default"].Digits = System.Convert.ToInt32(System.Math.Log10(System.Convert.ToInt32(getSensorValue(sensorValue)) + 1)) + 1 + 2 + 1;
                                ind.NumericIndicators["Default"].Value = System.Convert.ToDouble(getSensorValue(sensorValue));
                                ind.Labels["Default"].Text = sensor.Name + "\n" + getSensorValue(sensorValue).ToString() + " " + sensor.Unit;
                                // Check if value is in alarm level
                                if (PictureViewBLL.Current.CheckAlarmRunning(obj))
                                {
                                    ind.NumericIndicators["Default"].DigitColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                                    ind.NumericIndicators["Default"].DecimalColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                                    ind.NumericIndicators["Default"].SeparatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }
        //
        // View Context Menu
        //
        private void chartViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var datetime = DataReaderBLL.Current.GetLastTime();
                int idObject = Convert.ToInt32(currentRightClickCtrl.AccessibleName);
                // Edit by binhpro 19/10/2012
                var obj = PictureViewBLL.Current.GetObjectByID(idObject);
                if (obj != null)
                {
                    switch (obj.Type)
                    {
                        case PictureViewBLL.OBJECT_TYPE_IMAGE:
                            break;
                        case PictureViewBLL.OBJECT_TYPE_GROUP_INDICATOR:
                            // Show group text
                            var pictureView = PictureViewBLL.Current.GetByID(obj.Parameters.ToInt32TryParse());
                            if (pictureView != null)
                            {
                                new ChartMainForm(pictureView: pictureView
                                    , startDate: datetime != null ? (DateTime?)datetime.Value.AddDays(-6) : null
                                    , endDate: datetime).Show();
                            }
                            break;
                        default:
                            int sensorId = Convert.ToInt32(obj.Parameters);
                            var sensor = SensorBLL.Current.GetByID(sensorId);
                            if (sensor != null)
                            {
                                new ChartMainForm(sensor: sensor,
                                    startDate: datetime != null ? (DateTime?)datetime.Value.AddDays(-6) : null,
                                    endDate: datetime).Show();
                            }
                            break;
                    }
                }
                else
                {
                    ShowWarningMessage(Resources.Warning_NotDataToDisplay);
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        private void textViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var datetime = DataReaderBLL.Current.GetLastTime();

                int idObject = Convert.ToInt32(currentRightClickCtrl.AccessibleName);
                // Edit by binhpro 18/10/2012
                var obj = PictureViewBLL.Current.GetObjectByID(idObject);
                if (obj != null)
                {
                    switch (obj.Type)
                    {
                        case PictureViewBLL.OBJECT_TYPE_IMAGE:
                            break;
                        case PictureViewBLL.OBJECT_TYPE_GROUP_INDICATOR:
                            // Show group text
                            var pictureView = PictureViewBLL.Current.GetByID(obj.Parameters.ToInt32TryParse());
                            if (pictureView != null)
                            {
                                new TextViewForm(pictureView: pictureView,
                                    startDate: datetime != null ? (DateTime?)datetime.Value.AddDays(-6) : null,
                                    endDate: datetime).Show();
                            }
                            break;
                        default:
                            int sensorId = Convert.ToInt32(obj.Parameters);
                            var sensor = SensorBLL.Current.GetByID(sensorId);
                            if (sensor != null)
                            {
                                new TextViewForm(sensors: new List<Sensor>() { sensor },
                                    startDate: datetime != null ? (DateTime?)datetime.Value.AddDays(-6) : null,
                                    endDate: datetime).Show();
                            }
                            break;
                    }
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        private void pictureViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int idObject = Convert.ToInt32(currentRightClickCtrl.AccessibleName);
                if (entityConntext.Objects.Where(ent => ent.ObjectID == idObject).Count() > 0)
                {
                    var obj = PictureViewBLL.Current.GetObjectByID(idObject);
                    int pictureId = Convert.ToInt32(obj.Parameters);
                    if (pictureId != 0)
                    {
                        Models.PictureView picture = PictureViewBLL.Current.GetByID(pictureId);
                        using (PictureViewDetailForm f = new PictureViewDetailForm(picture, _displayRawValue))
                        {
                            f.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        private void PictureViewDetailForm_Load(object sender, EventArgs e)
        {
            lastWidth = this.Width;
            lastHeight = this.Height;
            CheckRoleForView(SecurityBLL.ROLE_VIEWS_VIEW);
        }

        private string getDisplayValue(SensorValue sensorValue)
        {
            if (_displayRawValue) return sensorValue.RawValue.ToString();
            return sensorValue.CalcValue.ToString();
        }

        private decimal getSensorValue(SensorValue sensorValue)
        {
            if (_displayRawValue) return sensorValue.RawValue;
            return sensorValue.CalcValue;
        }

        private void swichValueMode_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1000, 750);
            if (_displayRawValue)
            {
                _displayRawValue = false;
                swichValueMode.Text = Resources.PictureViewDetailForm_swichValueMode_Raw;
            }
            else
            {
                _displayRawValue = true;
                swichValueMode.Text = Resources.PictureViewDetailForm_swichValueMode_Calc;
            }

            LoadPicture(_pictureView);
        }

        private void PictureViewDetailForm_ResizeEnd(object sender, EventArgs e)
        {
            //ResizeControl();
        }

        private int lastWidth = 1;
        private int lastHeight = 1;

        private void ResizeControl()
        {
            //MessageBox.Show(lastWidth + " - " +lastHeight+ " - "+this.Width + " - " + this.Height);
            double wZoom = this.Width / lastWidth;
            double hZoom = this.Height / lastHeight;
            foreach (Control c in panel.Controls)
            {
                //c.Size = new Size((int)(c.Size.Width * wZoom), (int)(c.Size.Height * wZoom));
                //c.Location = new Point((int)(c.Location.X * wZoom), (int)(c.Location.Y * wZoom));
                int w = c.Size.Width * this.Width / lastWidth;
                int h = c.Size.Height * this.Height / lastHeight;
                int x = c.Location.X * this.Width / lastWidth;
                int y = c.Location.Y * this.Height / lastHeight;
                c.Size = new Size(w, h);
                c.Location = new Point(x, y);

            }
            lastWidth = this.Width;
            lastHeight = this.Height;

        }

        private void nextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PictureViewDetailForm(_nextPictureView).Show();
            Close();
        }

        private void previousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PictureViewDetailForm(_prePictureView).Show();
            Close();
        }

        private void printPreviewToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            _screenShoot = panel.CaptureScreen();
        }

        private void printToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            _screenShoot = panel.CaptureScreen();
        }

        private void PictureViewDetailForm_Resize(object sender, EventArgs e)
        {
            ResizeControl();
        }


    }
}
