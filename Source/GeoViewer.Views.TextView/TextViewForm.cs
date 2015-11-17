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
using GeoViewer.Utils;
using GeoViewer.Views.ChartView;
using GeoViewer.Views.TextView.Properties;
using Microsoft.Office.Interop;

namespace GeoViewer.Views.TextView
{
    public partial class TextViewForm : BaseWindowForm
    {
        #region Private Field

        private List<Sensor> _sensors;
        private DateTime? _startDate;
        private DateTime? _endDate;
        private bool _showCalcValue;
        // Update 09/10: add PictureView Field for perpose display all sensors in the PictureView
        private PictureView _pictureView;
        private Group _group;

        #endregion

        /// <summary>
        /// Pass params to display text view data on start up, set null (is default) for nothing display
        /// </summary>
        /// <param name="sensors">List sensors will be displayed</param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="showCalcValue"></param>
        public TextViewForm(List<Sensor> sensors = null, PictureView pictureView = null, Group group = null, DateTime? startDate = null, DateTime? endDate = null, bool showCalcValue = true)
        {
            // set value to private field
            _sensors = sensors;
            _pictureView = pictureView;
            _group = group;
            _startDate = startDate;
            _endDate = endDate;
            _showCalcValue = showCalcValue;
            InitializeComponent();
            //BindingData();
            if (_group != null)
                _sensors = _group.Sensors.ToList();
            if (_pictureView != null)
                _sensors = PictureViewBLL.Current.GetSensorsInPictureView(_pictureView);
            dataGridView.DataSource = TextViewBLL.Current.BindToDataTable(_sensors, !_showCalcValue, _startDate, _endDate);
        }

        private void TextViewForm_Load(object sender, EventArgs e)
        {
            BindingData();
            //dataGridView.DataSource =
            //    TextViewBLL.Current.BindToDataTable(entityConntext.Sensors.ToList());
        }

        private void BindingData()
        {
            sensorGridView.DataSource = entityConntext.Sensors.Where(ent => ent.ProjectID == AppContext.Current.OpenProject.ProjectID).OrderBy(ent => ent.LoggerID).ThenBy(ent => ent.ColumnIndex).ThenBy(ent => ent.SensorID).Select(ent => new { ent.SensorID, SensorName = ent.Name, LoggerName = ent.Logger.Name, ent.Description }).ToList();
            groupGridView.DataSource = entityConntext.Groups.Where(ent => ent.ProjectID == AppContext.Current.OpenProject.ProjectID).Select(ent => new { ent.GroupID, ent.Name }).ToList();
            pictureGridView.DataSource = entityConntext.PictureViews.Where(ent => ent.ProjectID == AppContext.Current.OpenProject.ProjectID).Select(ent => new { ent.PictureViewID, ent.Name }).ToList();

            sensorGridView.ClearSelection();
            choiseTab.SelectedTab = groupTab;
            groupGridView.ClearSelection();
            choiseTab.SelectedTab = pictureTab;
            pictureGridView.ClearSelection();
            choiseTab.SelectedTab = sensorTab;


            //if (_sensors != null)
            //{
            //    choiseTab.SelectedTab = sensorTab;
            //    var ids = _sensors.Select(ent => ent.SensorID).ToList();
            //    foreach (DataGridViewRow row in sensorGridView.Rows)
            //    {
            //        //if (ids.Contains(row.Cells["SensorID"].Value.ToInt32TryParse()))
            //        {
            //            row.Selected = true;
            //            //sensorGridView.SelectedRows.Insert(0,row);
            //        }
            //    }
            //}

            calcRadio.Checked = _showCalcValue;
            fromdateTextBox.Text = _startDate != null ? ((DateTime)_startDate).ToString("dd/MM/yyyy") : "";
            todateTextBox.Text = _endDate != null ? ((DateTime)_endDate).ToString("dd/MM/yyyy") : "";
        }

        private void BindingGrid()
        {
            try
            {
                _startDate = fromdateTextBox.Text.ToDateTimeTryParse(null);
                _endDate = todateTextBox.Text.ToDateTimeTryParse(null);
                _showCalcValue = calcRadio.Checked;


                if (choiseTab.SelectedTab == sensorTab && sensorGridView.SelectedRows.Count > 0)
                {
                    _sensors = new List<Sensor>();
                    _group = null;
                    _pictureView = null;
                    for (int i = 0; i < sensorGridView.SelectedRows.Count; i++)
                    {
                        _sensors.Add(SensorBLL.Current.GetByID(sensorGridView.SelectedRows[sensorGridView.SelectedRows.Count - 1 - i].Cells["SensorID"].Value.ToInt32TryParse()));
                    }
                }
                else if (choiseTab.SelectedTab == groupTab)
                {
                    if (groupGridView.SelectedRows.Count > 0)
                    {
                        _group = ChartViewBLL.Current.GetGroupByID(groupGridView.SelectedRows[0].Cells["GroupID"].Value.ToInt32TryParse());
                        _pictureView = null;
                    }
                }
                else if (choiseTab.SelectedTab == pictureTab)
                {
                    if (pictureGridView.SelectedRows.Count > 0)
                    {
                        _pictureView = PictureViewBLL.Current.GetByID(pictureGridView.SelectedRows[0].Cells["PictureViewID"].Value.ToInt32TryParse());
                        _group = null;
                    }
                }
                if (_group != null)
                {
                    _sensors = entityConntext.Groups.SingleOrDefault(ent => ent.GroupID == _group.GroupID).Sensors.ToList();
                }
                if (_pictureView != null)
                {
                    _sensors = PictureViewBLL.Current.GetSensorsInPictureView(_pictureView);
                }
                if(_sensors !=null && _sensors.Count > 0)
                {
                    _sensors = _sensors.OrderBy(ent => ent.ColumnIndex).ToList();
                    dataGridView.DataSource = TextViewBLL.Current.BindToDataTable(_sensors, !_showCalcValue, _startDate, _endDate);
                }
            }
            catch (Exception exception)
            {
                //ShowErrorMessage(exception.Message);
                Console.WriteLine(exception.ToString());
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            BindingGrid();
        }

        private void editGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new GroupsManagerForm().ShowDialog();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var dialog = new SaveFileDialog();
                dialog.Title = Resources.TextViewForm_ChoiseFileToSave;
                dialog.Filter = "Excel .xls|*.xls";
                //dialog.FileName = "TextView-" + DateTime.Now.ToString("dd-MM-yyyy") + ".xls";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.ApplicationClass ExcelApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
                    ExcelApp.Application.Workbooks.Add(Type.Missing);

                    // Change properties of the Workbook 
                    ExcelApp.Columns.ColumnWidth = 20;

                    // Storing header part in Excel
                    for (int i = 1; i < dataGridView.Columns.Count + 1; i++)
                    {
                        ExcelApp.Cells[1, i] = dataGridView.Columns[i - 1].HeaderText;
                    }

                    // Storing Each row and column value to excel sheet
                    for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < dataGridView.Columns.Count; j++)
                        {
                            ExcelApp.Cells[i + 2, j + 1] = dataGridView.Rows[i].Cells[j].Value.ToString().Replace(",", ".");
                        }
                    }

                    ExcelApp.ActiveWorkbook.SaveCopyAs(dialog.FileName);
                    ExcelApp.ActiveWorkbook.Saved = true;
                    ExcelApp.Quit();
                    if (ShowConfirmMessage(Resources.Message_ExportSuccess) == DialogResult.OK)
                    {
                        // Open file
                        System.Diagnostics.Process.Start(dialog.FileName);
                    }
                }

            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }

        }

    }
}
