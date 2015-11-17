using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GeoViewer.Business;
using GeoViewer.Data.Properties;
using GeoViewer.Models;
using GeoViewer.Utils;

namespace GeoViewer.Data
{
    public partial class LoggersManagerForm : BaseWindowForm
    {
        private int _addEditState = 0;
        private Logger _editingLogger = null;

        public LoggersManagerForm()
        {
            InitializeComponent();
            BindingData();
            prepareToAdd();
        }

        private void LoggersManagerForm_Load(object sender, EventArgs e)
        {
            CheckRoleForView(SecurityBLL.ROLE_DATA_VIEW);
        }


        #region private function
        private void BindingData()
        {
            loggerGridView.DataSource = entityConntext.Loggers
                .Where(ent => ent.ProjectID == AppContext.Current.OpenProject.ProjectID)
                .Select(
                    ent =>
                    new
                        {
                            ent.LoggerID,
                            ent.Name,
                            ent.DataPath,
                            ent.AutomaticReadData,
                            ent.ReadInterval,
                            ent.CreatedDate,
                            ent.CreatedUser,
                            ent.LastEditedUser,
                            ent.LastEditedDate
                        }).ToList();
            //loggerGridView.DataSource = entityConntext.Loggers;
        }

        private void prepareToAdd()
        {
            _addEditState = 0;
            _editingLogger = null;
            addeditBox.Enabled = selectFileButton.Enabled = btnSelectFile.Enabled = true;
            infoBox.Enabled = false;
            nameTextBox.Focus();

            nameTextBox.Text = pathTextBox.Text = "";
            autoReadCheckBox.Checked = true;
            intervalNumeric.Value = 1800;
            delimiterTextBox.Text = ",";

            string str = "...";
            metaLabel.Text = string.Format(Resources.Label_Logger_Meta, str);
            sensorCountLabel.Text = string.Format(Resources.Label_Logger_SensorCount, str);
            recordNumberLabel.Text = string.Format(Resources.Label_Logger_RecordCount, str);
            fileSizeLabel.Text = string.Format(Resources.Label_Logger_FileSize, str);
            firstTimeLabel.Text = string.Format(Resources.Label_Logger_FirstDate, str);
            lastTimeLabel.Text = string.Format(Resources.Label_Logger_LastDate, str);
            lastModifyLabel.Text = string.Format(Resources.Label_Logger_LastModify, str);
            readStatusLabel.Text = string.Format(Resources.Label_Logger_Status, str);
            readStatusLabel.Visible = false;
        }

        private void prepareToEdit()
        {
            if (loggerGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show(Resources.Warning_NoRecordSelected);
                return;
            }
            _editingLogger = LoggerBLL.Current.GetByID(loggerGridView.SelectedRows[0].Cells[0].Value.ToInt32TryParse());
            if (_editingLogger != null)
            {
                _addEditState = 1;
                addeditBox.Enabled = infoBox.Enabled = true;
                selectFileButton.Enabled = btnSelectFile.Enabled = false;
                nameTextBox.Focus();

                nameTextBox.Text = _editingLogger.Name;
                pathTextBox.Text = _editingLogger.DataPath;
                autoReadCheckBox.Checked = _editingLogger.AutomaticReadData;
                intervalNumeric.Value = _editingLogger.ReadInterval;
                delimiterTextBox.Text = _editingLogger.Delimiter;

                string str = "...";
                metaLabel.Text = string.Format(Resources.Label_Logger_Meta, _editingLogger.Meta);
                sensorCountLabel.Text = string.Format(Resources.Label_Logger_SensorCount, _editingLogger.TotalSensor);
                recordNumberLabel.Text = string.Format(Resources.Label_Logger_RecordCount, _editingLogger.TotalRecord);
                fileSizeLabel.Text = string.Format(Resources.Label_Logger_FileSize, _editingLogger.FileSize);
                firstTimeLabel.Text = string.Format(Resources.Label_Logger_FirstDate, _editingLogger.FirstLogDatetime);
                lastTimeLabel.Text = string.Format(Resources.Label_Logger_LastDate, _editingLogger.LastLogDatetime);
                lastModifyLabel.Text = string.Format(Resources.Label_Logger_LastModify, _editingLogger.LastModifyDatetime);
                readStatusLabel.Visible = true;
            }
        }

        private void addEdit()
        {
            try
            {
                if (_addEditState == 0 || _editingLogger == null)
                {
                    _editingLogger = new Logger();
                }
                bool flagStart = (!_editingLogger.AutomaticReadData) && autoReadCheckBox.Checked;
                bool flagStop = (_editingLogger.AutomaticReadData) && !autoReadCheckBox.Checked;

                _editingLogger.Name = nameTextBox.Text;
                _editingLogger.DataPath = pathTextBox.Text;
                _editingLogger.AutomaticReadData = autoReadCheckBox.Checked;
                _editingLogger.ReadInterval = intervalNumeric.Value.ToInt32TryParse();
                _editingLogger.Delimiter = delimiterTextBox.Text;

                if (_addEditState == 0)
                {
                    if (LoggerBLL.Current.Insert(_editingLogger))
                    {
                        ShowSuccessMessage(Resources.Message_AddLoggerSuccess);
                    }
                    prepareToAdd();
                    BindingData();
                    return;
                }
                if (_addEditState == 1)
                {

                    if (LoggerBLL.Current.Update(_editingLogger))
                    {
                        if (flagStart)
                        {
                            ShowSuccessMessage(Resources.Message_EditLoggerSuccess1);
                            return;
                        }
                        if (flagStop)
                        {
                            ShowSuccessMessage(Resources.Message_EditLoggerSuccess2);
                            return;
                        }
                        ShowSuccessMessage(Resources.Message_EditLoggerSuccess);
                        BindingData();
                    }
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
                //if (_addEditState == 1)
                //    entityConntext.Refresh(RefreshMode.StoreWins, _editingLogger);
            }
        }
        #endregion

        #region private event
        private void selectFileButton_Click(object sender, EventArgs e)
        {
            var result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                pathTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            addEdit();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_editingLogger != null)
                {
                    bool flag = false;
                    foreach (var sensor in entityConntext.Sensors.Where(ent => ent.LoggerID == _editingLogger.LoggerID).ToList())
                    {
                        if (string.IsNullOrEmpty(sensor.FormulaFunction) &&
                            string.IsNullOrEmpty(sensor.FunctionParameters))
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (flag)
                    {
                        var result =
                            MessageBox.Show(
                                Resources.Confirm_UpdateSensorParamFirst,
                                Resources.ConfirmMessageCaption, MessageBoxButtons.YesNoCancel);
                        if (result == DialogResult.Yes)
                        {
                            new SensorsManagerForm(_editingLogger).ShowDialog();
                            return;
                        }
                        if (result == DialogResult.Cancel) return;
                    }
                    infoBox.Cursor = System.Windows.Forms.Cursors.AppStarting;
                    //ReaderThreadManager.Current.ReadDataByThread(_editingLogger, readNewRadio.Checked, true);
                    new ReadDataForm(_editingLogger, readNewRadio.Checked, true).ShowDialog();

                    infoBox.Cursor = System.Windows.Forms.Cursors.Default;
                    ShowSuccessMessage(Resources.Message_ReadDataSuccess);
                    if (_editingLogger.AutomaticReadData)
                        ReaderThreadManager.Current.AddThread(_editingLogger);
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        private void reloadButton_Click(object sender, EventArgs e)
        {
            //AppContext.Current.RefreshEntityContext();
            BindingData();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            prepareToAdd();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            showSensorDialog();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

            if (loggerGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show(Resources.Warning_NoRecordSelected);
                return;
            }
            var id = loggerGridView.SelectedRows[0].Cells[0].Value.ToInt32TryParse();
            if (ShowConfirmMessage(string.Format(Resources.Message_ConfirmDeleteLogger, id)) == DialogResult.OK)
            {
                //Delete:
                try
                {
                    //AppContext.Current.RefreshEntityContext();
                    if (LoggerBLL.Current.Delete(id))
                    {
                        ShowSuccessMessage(Resources.Message_DeleteLoggerSuccess);
                        prepareToAdd();
                        BindingData();
                    }
                }
                catch (Exception exception)
                {
                    ShowErrorMessage(exception.Message);
                    //if (ShowConfirmMessage("Có lỗi xảy ra trong quá trình xóa.\nBạn có muốn thử lại không?") == DialogResult.OK)
                    //{
                    //    AppContext.Current.RefreshEntityContext();
                    //    goto Delete;
                    //}
                }
            }

        }

        private void loggerGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            showSensorDialog();
        }

        private void loggerGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            prepareToEdit();
        }

        private void updateReadStatusTimer_Tick(object sender, EventArgs e)
        {
            if (_editingLogger != null)
            {
                if (_editingLogger.LastModifyDatetime == null)
                {
                    readStatusLabel.Text = string.Format(Resources.Label_Logger_Status, "chưa đọc dữ liệu");
                    readAllRadio.Checked = true;
                    readNewRadio.Checked = false;
                    readAllRadio.Enabled = readNewRadio.Enabled = false;
                }
                else
                {
                    readAllRadio.Enabled = readNewRadio.Enabled = true;
                    if (_editingLogger.AutomaticReadData)
                    {
                        if (ReaderThreadManager.Current.ReadDataWorks.ContainsKey(_editingLogger.LoggerID))
                        {
                            var work = ReaderThreadManager.Current.ReadDataWorks[_editingLogger.LoggerID];
                            if (work.IsReading)
                            {
                                readStatusLabel.Text = string.Format(Resources.Label_Logger_Status, "đang đọc dữ liệu...");
                            }
                            else
                            {
                                readStatusLabel.Text = string.Format(Resources.Label_Logger_Status, work.TimeToNextRead + " s");
                            }
                        }
                    }
                }
            }
        }

        private void autoReadCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void showSensorDialog()
        {
            if (loggerGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show(Resources.Warning_NoRecordSelected);
                return;
            }
            var logger = LoggerBLL.Current.GetByID(loggerGridView.SelectedRows[0].Cells[0].Value.ToInt32TryParse());
            if (logger != null)
            {
                new SensorsManagerForm(logger).ShowDialog();
            }
        }

        #endregion


        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            var result = dataOpenFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                pathTextBox.Text = dataOpenFileDialog.FileName;
            }
        }

    }
}
