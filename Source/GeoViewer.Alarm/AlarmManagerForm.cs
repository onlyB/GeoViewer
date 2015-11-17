using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using GeoViewer.Alarm.Properties;
using GeoViewer.Business;
using GeoViewer.Models;
using GeoViewer.Utils;

namespace GeoViewer.Alarm
{
    public partial class AlarmManagerForm : BaseWindowForm
    {
        #region Private Field

        private Sensor _sensor;
        private DateTime? _startDate;
        private DateTime? _endDate;
        private bool? _isEnded;
        private AlarmLog _editingLog;
        #endregion

        /// <summary>
        /// Pass params to filter, set null (default) for no filtering
        /// </summary>
        /// <param name="sensor"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="isEnded"></param>
        public AlarmManagerForm(Sensor sensor = null, DateTime? startDate = null, DateTime? endDate = null, bool? isEnded = null)
        {
            // set value to private field
            _sensor = sensor;
            _startDate = startDate;
            _endDate = endDate;
            _isEnded = isEnded;
            // ...
            // continue here
            InitializeComponent();
            BindingData();
        }

        private void AlarmManagerForm_Load(object sender, EventArgs e)
        {
            CheckRoleForView(SecurityBLL.ROLE_ALARM_VIEW);
        }

        private void BindingData()
        {
            //logGridView.DataSource = AlarmBLL.Current.GetByConditions();

            sensorCombo.DataSource =
                entityConntext.Sensors.OrderBy(ent => ent.LoggerID).ThenBy(ent => ent.Name).Select(
                    ent => new { Value = ent.SensorID, Display = ent.Logger.Name + " | " + ent.Name });
            sensorCombo.DisplayMember = "Display";
            sensorCombo.ValueMember = "Value";

            if (_sensor != null)
            {
                sensorCombo.SelectedValue = _sensor.SensorID.ToString();
                sensorCombo.Text = _sensor.Logger.Name + " | " + _sensor.Name;
            }
            else
            {
                sensorCombo.SelectedIndex = -1;
            }

            fromdateTextBox.Text = _startDate != null ? ((DateTime)_startDate).ToString("dd/MM/yyyy") : "";
            todateTextBox.Text = _endDate != null ? ((DateTime)_endDate).ToString("dd/MM/yyyy") : "";

            if (_isEnded == true)
            {
                endedRadio.Checked = true;
                runningRadio.Checked = false;
            }
            else if (_isEnded == false)
            {
                endedRadio.Checked = false;
                runningRadio.Checked = true;
            }
            else
            {
                endedRadio.Checked = false;
                runningRadio.Checked = false;
            }

            logGridView.DataSource = AlarmBLL.Current.GetByConditions(_sensor, _startDate, _endDate, _isEnded);

        }

        private void ReloadGrid()
        {
            logGridView.DataSource = AlarmBLL.Current.GetByConditions(_sensor, _startDate, _endDate, _isEnded);
        }

        private void Searching()
        {
            _sensor = sensorCombo.SelectedIndex == -1 ? null : SensorBLL.Current.GetByID(sensorCombo.SelectedValue.ToInt32TryParse());
            _startDate = fromdateTextBox.Text.ToDateTimeTryParse(null);
            _endDate = todateTextBox.Text.ToDateTimeTryParse(null);
            if (endedRadio.Checked)
                _isEnded = true;
            else if (runningRadio.Checked)
                _isEnded = false;
            else
                _isEnded = null;
            ReloadGrid();
        }

        private void logGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            gridContextMenu.Enabled = logGridView.SelectedRows.Count > 0;
        }

        private void logGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (logGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show(Resources.Warning_NoRecordSelected);
                return;
            }
            _editingLog = AlarmBLL.Current.GetByID(logGridView.SelectedRows[0].Cells["AlarmLogID"].Value.ToInt32TryParse());
            if (_editingLog != null)
            {
                noteTextBox.Text = _editingLog.Note;
                saveButton.Enabled = true;
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            Searching();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            sensorCombo.SelectedIndex = -1;
            fromdateTextBox.Text = todateTextBox.Text = "";
            endedRadio.Checked = runningRadio.Checked = false;
            logGridView.DataSource = AlarmBLL.Current.GetByConditions();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (logGridView.SelectedRows.Count == 0)
                {
                    MessageBox.Show(Resources.Warning_NoRecordSelected);
                    return;
                }
                if (ShowConfirmMessage(string.Format(Resources.Confirm_DeleteLogs, logGridView.SelectedRows.Count)) == DialogResult.OK)
                {
                    long[] ids = new long[logGridView.SelectedRows.Count];
                    for (int i = 0; i < logGridView.SelectedRows.Count; i++)
                    {
                        ids[i] = logGridView.SelectedRows[i].Cells["AlarmLogID"].Value.ToInt64TryParse();
                    }
                    if (AlarmBLL.Current.Delete(ids))
                    {
                        ShowSuccessMessage(string.Format(Resources.Message_DeleteLogsSuccess, ids.Length));
                        ReloadGrid();
                    }
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (_editingLog != null)
            {
                _editingLog.Note = noteTextBox.Text;
                if (AlarmBLL.Current.Update(_editingLog))
                {
                    ShowSuccessMessage(Resources.Message_EditLogSuccess);
                    ReloadGrid();
                }
            }
        }

        //        private int _alarmMode = 0;
        private void logGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (e.ColumnIndex == 2)
            //{
            //    string title = (string)e.Value;
            //    Regex regex = new Regex(@"(\d)+ %");
            //    if (regex.IsMatch(title))
            //    {
            //        int percent = regex.Match(title).Value.Replace(" %", "").ToInt32TryParse();
            //        _alarmMode = percent >= 50 ? 1 : 0;
            //    }
            //}
            if (e.ColumnIndex == 5)
            {
                if ((bool)e.Value)
                {
                    e.Value = Resources.correct_24;
                }
                else
                {
                    e.Value = Resources.bell_red_24;
                }
            }

        }

        private void markAsReadMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (var entityConntext = new GeoViewerEntities())
                {
                    if (logGridView.SelectedRows.Count == 0)
                    {
                        MessageBox.Show(Resources.Warning_NoRecordSelected);
                        return;
                    }
                    long id = 0;
                    for (int i = 0; i < logGridView.SelectedRows.Count; i++)
                    {
                        id = logGridView.SelectedRows[i].Cells["AlarmLogID"].Value.ToInt64TryParse();
                        var obj = entityConntext.AlarmLogs.SingleOrDefault(ent => ent.AlarmLogID == id);
                        if (obj != null)
                        {
                            obj.LastEditedDate = DateTime.Now;
                            obj.LastEditedUser = AppContext.Current.LogedInUser.Username;
                        }
                    }
                    if (entityConntext.SaveChanges() > 0)
                    {
                        ShowSuccessMessage(string.Format("Đánh dấu đã đọc thành công cho {0} cảnh báo!",
                                                         logGridView.SelectedRows.Count));
                        ReloadGrid();       
                    }
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        private void deleteMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (logGridView.SelectedRows.Count == 0)
                {
                    MessageBox.Show(Resources.Warning_NoRecordSelected);
                    return;
                }
                if (ShowConfirmMessage(string.Format(Resources.Confirm_DeleteLogs, logGridView.SelectedRows.Count)) == DialogResult.OK)
                {
                    long[] ids = new long[logGridView.SelectedRows.Count];
                    for (int i = 0; i < logGridView.SelectedRows.Count; i++)
                    {
                        ids[i] = logGridView.SelectedRows[i].Cells["AlarmLogID"].Value.ToInt64TryParse();
                    }
                    if (AlarmBLL.Current.Delete(ids))
                    {
                        ShowSuccessMessage(string.Format(Resources.Message_DeleteLogsSuccess, ids.Length));
                        ReloadGrid();
                    }
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        private void markEndedMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (var entityConntext = new GeoViewerEntities())
                {
                    if (logGridView.SelectedRows.Count == 0)
                    {
                        MessageBox.Show(Resources.Warning_NoRecordSelected);
                        return;
                    }
                    long id = 0;
                    for (int i = 0; i < logGridView.SelectedRows.Count; i++)
                    {
                        id = logGridView.SelectedRows[i].Cells["AlarmLogID"].Value.ToInt64TryParse();
                        var obj = entityConntext.AlarmLogs.SingleOrDefault(ent => ent.AlarmLogID == id);
                        if (obj != null)
                        {
                            obj.IsEnded = true;
                            obj.EndAlarmDatetime = DateTime.Now;
                        }
                    }
                    if (entityConntext.SaveChanges() > 0)
                    {
                        ShowSuccessMessage(string.Format("Đánh dấu đã kết thúc thành công cho {0} cảnh báo!",
                                                         logGridView.SelectedRows.Count));
                        ReloadGrid();
                    }
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        private void markUnendedMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (var entityConntext = new GeoViewerEntities())
                {
                    if (logGridView.SelectedRows.Count == 0)
                    {
                        MessageBox.Show(Resources.Warning_NoRecordSelected);
                        return;
                    }
                    long id = 0;
                    for (int i = 0; i < logGridView.SelectedRows.Count; i++)
                    {
                        id = logGridView.SelectedRows[i].Cells["AlarmLogID"].Value.ToInt64TryParse();
                        var obj = entityConntext.AlarmLogs.SingleOrDefault(ent => ent.AlarmLogID == id);
                        if (obj != null)
                        {
                            obj.IsEnded = false;
                            obj.EndAlarmDatetime = null;
                        }
                    }
                    if (entityConntext.SaveChanges() > 0)
                    {
                        ShowSuccessMessage(string.Format("Đánh dấu chưa kết thúc thành công cho {0} cảnh báo!",
                                                         logGridView.SelectedRows.Count));
                        ReloadGrid();
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
