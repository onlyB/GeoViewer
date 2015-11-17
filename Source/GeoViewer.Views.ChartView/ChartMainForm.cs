using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Drawing;
using GeoViewer.Utils;
using GeoViewer.Models;
using GeoViewer.Business;
using System.Windows.Forms;
using System.Data;
using ZedGraph;

namespace GeoViewer.Views.ChartView
{

    public partial class ChartMainForm : BaseWindowForm
    {
        #region private fields
        private GraphPane myPane; //mypane to chart on zedgraph
        /// <summary>
        /// Data table save the information of chartview
        /// </summary>
        private DataTable tblchart = new DataTable();   //table to save data chart
        //Color[] clchart = new Color[50];
        private List<Color> clchart = new List<Color>();
        private int sensorinchart = 0;

        private Sensor _sensor;
        private Group _group;
        private PictureView _pictureView;
        private DateTime? _startDate;
        private DateTime? _endDate;
        #endregion

        public ChartMainForm(Sensor sensor = null, Group group = null, PictureView pictureView = null, DateTime? startDate = null,
                             DateTime? endDate = null)
        {
            _sensor = sensor;
            _group = group;
            _pictureView = pictureView;
            _startDate = startDate;
            _endDate = endDate;
            InitializeComponent();
        }

        private void ChartMainForm_Load(object sender, EventArgs e)
        {
            CheckRoleForView(SecurityBLL.ROLE_VIEWS_VIEW);
            //initial mypane
            myPane = zedGraphChart.GraphPane;
            myPane.XAxis.Type = AxisType.Date;
            myPane.XAxis.Scale.Format = "HH:mm:ss\ndd-MM-yyyy";
            myPane.Title.Text = "Tiêu đề";
            myPane.XAxis.Title.Text = "Thời gian";
            myPane.YAxis.Title.Text = "Giá trị";
            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MajorGrid.IsVisible = true;
            LoadAllSensor();

            //BindingData
            fromdateTextBox.Text = _startDate != null ? ((DateTime)_startDate).ToString("dd/MM/yyyy") : "";
            todateTextBox.Text = _endDate != null ? ((DateTime)_endDate).ToString("dd/MM/yyyy") : "";
            BindingData();
        }

        #region binding data
        private void BindingData()
        {
            try
            {
                resetchart();
                var sensorsToDisplay = new List<Sensor>();
                if (_sensor != null)
                {
                    sensorsToDisplay.Add(_sensor);
                    myPane.YAxis.Title.Text = _sensor.Unit;
                    myPane.Title.Text = _sensor.Name;
                }
                else if (_group != null)
                {
                    sensorsToDisplay = entityConntext.Sensors.Where(ent => ent.Groups.Any(g => g.GroupID == _group.GroupID)).ToList();
                    myPane.Title.Text = _group.Name;
                }
                else if (_pictureView != null)
                {
                    sensorsToDisplay = PictureViewBLL.Current.GetSensorsInPictureView(_pictureView);
                    myPane.Title.Text = _pictureView.Name;
                }
                gettblchart(sensorsToDisplay);
                chartview(tblchart, clchart);
                //myPane.

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private void LoadAllSensor()
        {
            ChartGridView.Columns[0].DataPropertyName = "SensorID";
            ChartGridView.Columns[1].DataPropertyName = "Name";
            //ChartGridView.Columns[2].DataPropertyName = "LoggerName";
            ChartGridView.Columns[2].Visible = ChartGridView.Columns[3].Visible = true;
            ChartGridView.DataSource = entityConntext.Sensors.Where(ent => ent.ProjectID == AppContext.Current.OpenProject.ProjectID).OrderBy(ent => ent.LoggerID).ThenBy(ent => ent.ColumnIndex).ThenBy(ent => ent.SensorID).Select(ent => new { ent.SensorID, ent.Name, LoggerName = ent.Logger.Name,ent.Description }).ToList();
        }

        private void LoadGroupSensor()
        {
            List<Group> listgroup = entityConntext.Groups.Where(ent => ent.ProjectID == AppContext.Current.OpenProject.ProjectID).ToList();
            var list = (from ent in listgroup
                        select new { ent.GroupID, ent.Name, LoggerName = "",Description ="" });
            ChartGridView.Columns[0].DataPropertyName = "GroupID";
            ChartGridView.Columns[1].DataPropertyName = "Name";
            ChartGridView.Columns[2].Visible = ChartGridView.Columns[3].Visible = false;

            ChartGridView.DataSource = list.ToList();

        }

        private void LoadPictureSensor()
        {
            List<PictureView> listpicture = entityConntext.PictureViews.Where(ent => ent.ProjectID == AppContext.Current.OpenProject.ProjectID).ToList();
            var list = (from ent in listpicture
                        select new { ent.PictureViewID, ent.Name, LoggerName = "",Description = "" });
            ChartGridView.Columns[0].DataPropertyName = "PictureViewID";
            ChartGridView.Columns[1].DataPropertyName = "Name";
            ChartGridView.Columns[2].Visible = ChartGridView.Columns[3].Visible = false;
            ChartGridView.DataSource = list.ToList();
        }
        #endregion

        #region build chart
        private void gettblchart(List<Sensor> listsensor)
        {
            resettblchart();
            tblchart.Columns.Add("SensorID");
            tblchart.Columns.Add("SensorName");
            tblchart.Columns.Add("TypeofValue");
            tblchart.Columns.Add("BoldLine");
            tblchart.Columns.Add("LineStyle");
            Random randomGen = new Random();
            for (int i = 0; i < listsensor.Count; i++)
            {
                DataRow tblrow = tblchart.NewRow();
                tblrow["SensorID"] = listsensor[i].SensorID;
                tblrow["SensorName"] = listsensor[i].Name;
                tblrow["TypeofValue"] = 1;
                tblrow["BoldLine"] = 1;
                tblrow["LineStyle"] = 0;
                tblchart.Rows.Add(tblrow);

                //clchart[i] = Color.FromArgb(randomGen.Next(255), randomGen.Next(255), randomGen.Next(255));
                clchart.Add(Color.FromArgb(randomGen.Next(255), randomGen.Next(255), randomGen.Next(255)));
            }
            sensorinchart = listsensor.Count;
        }

        private void resettblchart()
        {
            int countrow = tblchart.Rows.Count;
            int countcol = tblchart.Columns.Count;
            //reset table chart
            for (int i = 0; i < countrow; i++)
            {
                tblchart.Rows[0].Delete();
            }

            for (int i = 0; i < countcol; i++)
            {
                tblchart.Columns.Remove(tblchart.Columns[0].ColumnName);
            }

            //reset color chart
            for (int i = sensorinchart; i > 0; i--)
            {
                clchart.Remove(clchart[i - 1]);
            }
            sensorinchart = 0;
        }

        public void chartview(DataTable tablechart, List<Color> colorchart)
        {
            // Edit by binhpro 19/10/2012
            _startDate = fromdateTextBox.Text.ToDateTimeTryParse(null);
            _endDate = todateTextBox.Text.ToDateTimeTryParse(null);
            // fix datetime
            if (_startDate != null)
            {
                _startDate = new DateTime(_startDate.Value.Year, _startDate.Value.Month, _startDate.Value.Day, 0, 0, 0);
            }
            if(_endDate != null)
            {
                _endDate = new DateTime(_endDate.Value.Year, _endDate.Value.Month, _endDate.Value.Day,23,59,59);
            }



            for (int i = 0; i < sensorinchart; i++)
            {
                int idsen = Convert.ToInt16(tablechart.Rows[i]["SensorID"]);
                List<SensorValue> listvalue = entityConntext.SensorValues.Where(ent =>
                    ent.SensorID == idsen &&
                    (_startDate == null || ent.MeaTime >= _startDate) &&
                    (_endDate == null || ent.MeaTime <= _endDate)
                    ).OrderBy(ent => ent.MeaTime).ToList();

                DataSourcePointList dsp = new DataSourcePointList();
                dsp.DataSource = listvalue;
                if (Convert.ToInt16(tablechart.Rows[i]["TypeofValue"]) == 0)
                {
                    dsp.YDataMember = "RawValue";
                }
                if (Convert.ToInt16(tablechart.Rows[i]["TypeofValue"]) == 1)
                {
                    dsp.YDataMember = "CalcValue";
                }
                dsp.XDataMember = "MeaTime";

                LineItem mycurve = myPane.AddCurve(Convert.ToString(tablechart.Rows[i]["SensorName"]), dsp, colorchart[i], SymbolType.Circle);
                mycurve.Line.Width = tablechart.Rows[i]["BoldLine"].ToInt32TryParse();

                switch (tablechart.Rows[i]["LineStyle"].ToInt32TryParse())
                {
                    case 0:
                        mycurve.Line.Style = DashStyle.Solid;
                        break;
                    case 1:
                        mycurve.Line.Style = DashStyle.Dot;
                        break;
                    case 2:
                        mycurve.Line.Style = DashStyle.Dash;
                        break;
                    case 3:
                        mycurve.Line.Style = DashStyle.DashDot;
                        break;
                    case 4:
                        mycurve.Line.Style = DashStyle.DashDotDot;
                        break;
                }
                //mycurve.Line.Style = (DashStyle)tablechart.Rows[i]["LineStyle"];


            }
            //myPane.
            zedGraphChart.IsShowPointValues = true;

            //lenh hien thi chart
            zedGraphChart.AxisChange();
            zedGraphChart.Invalidate();
            zedGraphChart.Refresh();

        }

        private void resetchart()
        {
            //reset zedgraph
            zedGraphChart.GraphPane.CurveList.Clear();
            // scale to default
            zedGraphChart.GraphPane.XAxis.Scale.MinAuto = true;
            zedGraphChart.GraphPane.XAxis.Scale.MaxAuto = true;
            zedGraphChart.GraphPane.YAxis.Scale.MinAuto = true;
            zedGraphChart.GraphPane.YAxis.Scale.MaxAuto = true;

            zedGraphChart.AxisChange();
            zedGraphChart.Refresh();
            zedGraphChart.PanButtons = MouseButtons.Left;
            zedGraphChart.PanModifierKeys = Keys.None;
            //zedGraphChart.
        }
        #endregion

        #region Deleted
        ////////////////////////////////////////Form edit scale///////////////////////////////////////////////////////
        /*
        Form editform = new Form();

        System.Windows.Forms.Label label1 = new System.Windows.Forms.Label();
        System.Windows.Forms.Label label2 = new System.Windows.Forms.Label();
        System.Windows.Forms.Label label3 = new System.Windows.Forms.Label();
        TextBox txtcharttitle = new TextBox();
        TextBox txtxaxistitle = new TextBox();
        TextBox txtyaxistitle = new TextBox();
        DataGridView EditScaleGridView = new DataGridView();
        System.Windows.Forms.Label label4 = new System.Windows.Forms.Label();
        System.Windows.Forms.Label label5 = new System.Windows.Forms.Label();
        Button btncolor = new Button();
        System.Windows.Forms.Label label6 = new System.Windows.Forms.Label();
        ComboBox comboedittype = new ComboBox();
        System.Windows.Forms.Label label7 = new System.Windows.Forms.Label();
        ComboBox comboeditbold = new ComboBox();
        Button btnOK = new Button();
        Button btnCancel = new Button();
        ColorDialog colorDialog1 = new ColorDialog();
        public void initeditscale()
        {
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 23);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(55, 13);
            label1.TabIndex = 0;
            label1.Text = "Tiêu đề Chart";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(11, 49);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(56, 13);
            label2.TabIndex = 1;
            label2.Text = "XAxis Title";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(12, 75);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(56, 13);
            label3.TabIndex = 2;
            label3.Text = "YAxis Title";
            // 
            // textBox1
            // 
            txtcharttitle.Location = new System.Drawing.Point(73, 20);
            txtcharttitle.Name = "txtcharttitle";
            txtcharttitle.Size = new System.Drawing.Size(140, 20);
            txtcharttitle.TabIndex = 3;
            txtcharttitle.Text = myPane.Title.Text;
            txtcharttitle.TextChanged += new EventHandler(txtcharttitle_TextChanged);
            // 
            // textBox2
            // 
            txtxaxistitle.Location = new System.Drawing.Point(73, 46);
            txtxaxistitle.Name = "txtxaxistitle";
            txtxaxistitle.Size = new System.Drawing.Size(140, 20);
            txtxaxistitle.TabIndex = 4;
            txtxaxistitle.Text = myPane.XAxis.Title.Text;
            txtxaxistitle.TextChanged += new EventHandler(txtxaxistitle_TextChanged);
            // 
            // textBox3
            // 
            txtyaxistitle.Location = new System.Drawing.Point(74, 72);
            txtyaxistitle.Name = "txtyaxistitle";
            txtyaxistitle.Size = new System.Drawing.Size(139, 20);
            txtyaxistitle.TabIndex = 5;
            txtyaxistitle.Text = myPane.YAxis.Title.Text;
            txtyaxistitle.TextChanged += new EventHandler(txtyaxistitle_TextChanged);
            // 
            // EditScaleGridView
            // 
            EditScaleGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            EditScaleGridView.Location = new System.Drawing.Point(12, 146);
            EditScaleGridView.Name = "Tùy chỉnh";
            EditScaleGridView.Size = new System.Drawing.Size(201, 214);
            EditScaleGridView.TabIndex = 6;
            EditScaleGridView.CellContentClick += new DataGridViewCellEventHandler(EditScaleGridView_CellContentClick);
            // 
            // label4
            //            
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(12, 121);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(88, 13);
            label4.TabIndex = 7;
            label4.Text = "Các Sensors hiển thị";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(267, 151);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(31, 13);
            label5.TabIndex = 8;
            label5.Text = "Màu vẽ";
            // 
            // btncolor
            // 
            btncolor.Location = new System.Drawing.Point(304, 146);
            btncolor.Name = "btncolor";
            btncolor.Size = new System.Drawing.Size(68, 23);
            btncolor.BackColor = Color.Gray;
            btncolor.TabIndex = 9;
            btncolor.UseVisualStyleBackColor = true;
            btncolor.Click += new EventHandler(btncolor_Click);
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(229, 190);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(69, 13);
            label6.TabIndex = 10;
            label6.Text = "Kiểu dữ liệu";
            // 
            // comboedittype
            // 
            comboedittype.FormattingEnabled = true;
            comboedittype.Items.AddRange(new object[] {
            "Raw",
            "Refine"});
            comboedittype.Location = new System.Drawing.Point(304, 187);
            comboedittype.Name = "comboedittype";
            comboedittype.Size = new System.Drawing.Size(68, 21);
            comboedittype.TabIndex = 11;
            comboedittype.SelectedIndexChanged += new EventHandler(comboedittype_SelectedIndexChanged);
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(235, 230);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(63, 13);
            label7.TabIndex = 12;
            label7.Text = "Nét vẽ đậm";
            // 
            // comboeditbold
            // 
            comboeditbold.FormattingEnabled = true;
            comboeditbold.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            comboeditbold.Location = new System.Drawing.Point(304, 230);
            comboeditbold.Name = "comboeditbold";
            comboeditbold.Size = new System.Drawing.Size(68, 21);
            comboeditbold.TabIndex = 13;
            comboeditbold.SelectedIndexChanged += new EventHandler(comboeditbold_SelectedIndexChanged);
            // 
            // btnOK
            // 
            btnOK.Location = new System.Drawing.Point(304, 298);
            btnOK.Name = "btnOK";
            btnOK.Size = new System.Drawing.Size(68, 23);
            btnOK.TabIndex = 14;
            btnOK.Text = "Lưu";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += new EventHandler(btnOK_Click);
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(304, 327);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(68, 23);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "Bỏ qua";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // EditScaleForm
            // 
            editform.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            editform.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            editform.ClientSize = new System.Drawing.Size(391, 361);
            editform.Controls.Add(this.btnCancel);
            editform.Controls.Add(this.btnOK);
            editform.Controls.Add(this.comboeditbold);
            editform.Controls.Add(this.label7);
            editform.Controls.Add(this.comboedittype);
            editform.Controls.Add(this.label6);
            editform.Controls.Add(this.btncolor);
            editform.Controls.Add(this.label5);
            editform.Controls.Add(this.label4);
            editform.Controls.Add(this.EditScaleGridView);
            editform.Controls.Add(this.txtyaxistitle);
            editform.Controls.Add(this.txtxaxistitle);
            editform.Controls.Add(this.txtcharttitle);
            editform.Controls.Add(this.label3);
            editform.Controls.Add(this.label2);
            editform.Controls.Add(this.label1);
            editform.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            editform.Name = "EditScaleForm";
            editform.Text = "EditScaleForm";
            EditScaleGridView.DataSource = tblchart;

        }

        void txtyaxistitle_TextChanged(object sender, EventArgs e)
        {
            myPane.YAxis.Title.Text = txtyaxistitle.Text;
        }

        void txtxaxistitle_TextChanged(object sender, EventArgs e)
        {
            myPane.XAxis.Title.Text = txtxaxistitle.Text;
        }

        void txtcharttitle_TextChanged(object sender, EventArgs e)
        {
            myPane.Title.Text = txtcharttitle.Text;
        }

        int rowindex = -1;
        void EditScaleGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            rowindex = e.RowIndex;
            //show color
            btncolor.BackColor = clchart[rowindex];
            //show data type
            if (Convert.ToInt16(tblchart.Rows[rowindex]["TypeofValue"]) == 0)
            {
                comboedittype.Text = "Raw";
            }
            else comboedittype.Text = "Refine";
            //show bold line
            comboeditbold.Text = tblchart.Rows[rowindex]["BoldLine"].ToString();
        }

        void btncolor_Click(object sender, EventArgs e)
        {
            if (rowindex >= 0)
            {
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        clchart[rowindex] = colorDialog1.Color;
                        btncolor.BackColor = clchart[rowindex];
                    }
                    catch (Exception exception)
                    {
                        ShowErrorMessage(exception.Message);
                    }
                }
            }
        }

        void comboedittype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rowindex >= 0)
            {
                try
                {
                    string selectedcombo = comboedittype.Items[comboedittype.SelectedIndex].ToString();
                    if (selectedcombo == "Raw")
                    {
                        tblchart.Rows[rowindex]["TypeofValue"] = 0;
                    }
                    if (selectedcombo == "Refine")
                    {
                        tblchart.Rows[rowindex]["TypeofValue"] = 1;
                    }
                    EditScaleGridView.DataSource = tblchart;
                }
                catch (Exception exception)
                {
                    ShowErrorMessage(exception.Message);
                }

            }
        }

        void comboeditbold_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedcombo = comboeditbold.Items[comboeditbold.SelectedIndex].ToString();
                tblchart.Rows[rowindex]["BoldLine"] = Convert.ToInt16(selectedcombo);
                EditScaleGridView.DataSource = tblchart;
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                rowindex = -1;
                btncolor.BackColor = Color.Gray;
                comboeditbold.Text = "";
                comboedittype.Text = "";
                txtcharttitle.Text = myPane.Title.Text;
                txtxaxistitle.Text = myPane.XAxis.Title.Text;
                txtyaxistitle.Text = myPane.YAxis.Title.Text;
                editform.Close();
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }
        */
        #endregion

        #region Menu
        private void scaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //editform.ShowDialog();
            var edit = new EditScaleForm();
            edit.pane = myPane;
            edit.datachart = tblchart;
            edit.colors = clchart;
            if (edit.ShowDialog() == DialogResult.OK)
            {
                //chart after edit
                resetchart();
                chartview(tblchart, clchart);
            }
        }

        private void groupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GroupsManagerForm editgroupform = new GroupsManagerForm();
            editgroupform.ShowDialog();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //printPreviewDialog1.ShowDialog();
            zedGraphChart.DoPrintPreview();
        }
        #endregion

        #region private events
        private void combochart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combochart.SelectedIndex == 0)
            {
                LoadAllSensor();
                ChartGridView.MultiSelect = true;
            }
            else if (combochart.SelectedIndex == 1)
            {
                LoadGroupSensor();
                ChartGridView.MultiSelect = false;
            }
            else if (combochart.SelectedIndex == 2)
            {
                LoadPictureSensor();
                ChartGridView.MultiSelect = false;
            }
        }

        private void ChartGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            // Modify by binhpro 19/10/2012
            int id = ChartGridView.Rows[e.RowIndex].Cells[0].Value.ToInt32TryParse();
            if (combochart.SelectedIndex == 0)
            {
                _sensor = SensorBLL.Current.GetByID(id);
                _group = null;
                _pictureView = null;
            }
            else if (combochart.SelectedIndex == 1)
            {
                _group = ChartViewBLL.Current.GetGroupByID(id);
                _sensor = null;
                _pictureView = null;

            }
            else if (combochart.SelectedIndex == 2)
            {
                _pictureView =
                    PictureViewBLL.Current.GetByID(id);
                _sensor = null;
                _group = null;
            }
            BindingData();
        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            BindingData();
        }
        #endregion

        //Print current picture form
        //[System.Runtime.InteropServices.DllImport("gdi32.dll")]
        //public static extern long BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
        //private Bitmap memoryImage;
        //private void CaptureScreen()
        //{
        //    Graphics mygraphics = zedGraphChart.CreateGraphics();
        //    Size s = zedGraphChart.Size;
        //    memoryImage = new Bitmap(s.Width, s.Height, mygraphics);
        //    Graphics memoryGraphics = Graphics.FromImage(memoryImage);
        //    IntPtr dc1 = mygraphics.GetHdc();
        //    IntPtr dc2 = memoryGraphics.GetHdc();
        //    BitBlt(dc2, 0, 0, zedGraphChart.ClientRectangle.Width, zedGraphChart.ClientRectangle.Height, dc1, 0, 0, 13369376);
        //    mygraphics.ReleaseHdc(dc1);
        //    memoryGraphics.ReleaseHdc(dc2);
        //}

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(zedGraphChart.CaptureScreen(), 0, 0);
        }

        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //if (printDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    printDocument1.Print();
            //}
            zedGraphChart.DoPrint();
        }
    }
}
