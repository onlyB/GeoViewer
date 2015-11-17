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
    public partial class SensorsManagerForm : BaseWindowForm
    {
        private Logger _logger;

        private Sensor _editingSensor;
        private int _addEditState = STATE_ADDING;

        /// <summary>
        /// Constructor with required Logger parameter
        /// </summary>
        /// <param name="logger">Logger contain sensors will be displayed and managed</param>
        public SensorsManagerForm(Logger logger)
        {
            // set value to private field
            _logger = logger;

            InitializeComponent();

            BindingData();

            alarmTab.Visible = SecurityBLL.Current.IsUserInRole(SecurityBLL.ROLE_ALARM_VIEW);
            alarmTab.Enabled = SecurityBLL.Current.IsUserInRole(SecurityBLL.ROLE_ALARM_EDIT);

            //userDefinedTab.Visible = false;
        }

        private void SensorsManagerForm_Load(object sender, EventArgs e)
        {
            CheckRoleForView(SecurityBLL.ROLE_DATA_VIEW);
        }

        private void sensorGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                if ((bool)e.Value)
                {
                    e.Value = Resources.warning_16;
                }
                else
                {
                    e.Value = Resources.correct_16;
                }
            }
            else if (e.ColumnIndex == 4)
            {
                if ((bool)e.Value)
                {
                    e.Value = Resources.on_16;
                }
                else
                {
                    e.Value = Resources.off_16;
                }
            }
        }

        private void setSelectedItem(ComboBox comboBox, string value)
        {
            var sensor = SensorBLL.Current.GetByID(value.ToInt32TryParse());
            if (sensor == null)
            {
                comboBox.SelectedIndex = -1;
            }
            else
            {
                comboBox.SelectedValue = value;
                comboBox.Text = sensor.Name;
            }
        }


        #region private methods
        private void BindingData()
        {
            sensorGridView.DataSource = entityConntext.Sensors.Where(ent => ent.LoggerID == _logger.LoggerID).OrderBy(ent => ent.ColumnIndex).Select(ent => new
                                                                          {
                                                                              ent.SensorID,
                                                                              ent.ColumnIndex,
                                                                              ent.Name,
                                                                              ent.Unit,
                                                                              ent.AlarmEnabled,
                                                                              ent.AlarmFlag,
                                                                              ent.CreatedDate,
                                                                              ent.CreatedUser,
                                                                              ent.LastEditedDate,
                                                                              ent.LastEditedUser
                                                                          }).ToList();

            temp_Tc.DataSource = vwLinear_Tc.DataSource = vwLinear_Bc.DataSource = vwPoly_Tc.DataSource = vwPoly_Bc.DataSource = entityConntext.Sensors.Where(ent => ent.LoggerID == _logger.LoggerID).ToList();
            temp_Tc.ValueMember = vwLinear_Tc.ValueMember = vwLinear_Bc.ValueMember = vwPoly_Tc.ValueMember = vwPoly_Bc.ValueMember = "SensorID";
            temp_Tc.DisplayMember = vwLinear_Tc.DisplayMember = vwLinear_Bc.DisplayMember = vwPoly_Tc.DisplayMember = vwPoly_Bc.DisplayMember = "Name";
        }

        private void prepareToAdd()
        {
            _addEditState = STATE_ADDING;
            _editingSensor = null;

            addEditTabs.Enabled = saveButton.Enabled = true;
            addEditTabs.SelectedTab = infoTab;
            nameTextBox.ReadOnly = columnIndexNumeric.ReadOnly = descriptionTextBox.ReadOnly = false;
            updateInfo.Visible = updateCalc.Visible = updateAlarm.Visible = false;

            nameTextBox.Text = unitTextBox.Text = descriptionTextBox.Text = unitLabel1.Text = unitLabel2.Text = "";
            columnIndexNumeric.Value = caclSelectTabs.SelectedIndex = 0;
            linear_C0.Text = linear_C1.Text = "";
            enableAlarmCheckBox.Checked = false;
            minAlarmTextBox.Text = maxAlarmTextBox.Text = "";
            nameTextBox.Focus();
        }

        private void prepareToEdit()
        {
            if (sensorGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show(Resources.Warning_NoRecordSelected);
                return;
            }
            _editingSensor = SensorBLL.Current.GetByID(sensorGridView.SelectedRows[0].Cells[0].Value.ToInt32TryParse());
            if (_editingSensor != null)
            {
                //_addEditState = 1;

                addEditTabs.Enabled = saveButton.Enabled = true;
                addEditTabs.SelectedTab = infoTab;

                columnIndexNumeric.Value = _editingSensor.ColumnIndex;
                nameTextBox.Text = _editingSensor.Name;
                descriptionTextBox.Text = _editingSensor.Description;
                unitTextBox.Text = unitLabel1.Text = unitLabel2.Text = _editingSensor.Unit;

                enableAlarmCheckBox.Checked = _editingSensor.AlarmEnabled;
                minAlarmTextBox.Text = _editingSensor.MinValue != null ? _editingSensor.MinValue.ToDecimalString() : "";
                maxAlarmTextBox.Text = _editingSensor.MaxValue != null ? _editingSensor.MaxValue.ToDecimalString() : "";

                // Load Calc Parameter
                if (!string.IsNullOrEmpty(_editingSensor.FunctionParameters))
                {
                    string[] parameters;
                    if (_editingSensor.FunctionParameters.Contains("#"))
                    {
                        parameters = _editingSensor.FunctionParameters.Split('#');
                    }
                    else
                    {
                        parameters = new string[] { _editingSensor.FunctionParameters };
                    }

                    switch (_editingSensor.FormulaType)
                    {
                        case CalculationBLL.FORMULA_LINEAR:
                            caclSelectTabs.SelectedTab = linearTab;
                            linear_C0.Text = parameters[0];
                            linear_C1.Text = parameters[1];
                            break;
                        case CalculationBLL.FORMULA_ARCTOLENGTH_DEGREE:
                            caclSelectTabs.SelectedTab = arcToLengthTab;
                            arc_Degree.Checked = true;
                            arc_Length.Text = parameters[0];
                            break;
                        case CalculationBLL.FORMULA_ARCTOLENGTH_RADIAN:
                            caclSelectTabs.SelectedTab = arcToLengthTab;
                            arc_Radian.Checked = true;
                            arc_Length.Text = parameters[0];
                            break;
                        case CalculationBLL.FORMULA_POLYNOMIAL:
                            caclSelectTabs.SelectedTab = polynomialTab;
                            poly_C0.Text = parameters[0];
                            poly_C1.Text = parameters[1];
                            poly_C2.Text = parameters[2];
                            poly_C3.Text = parameters[3];
                            poly_C4.Text = parameters[4];
                            poly_C5.Text = parameters[5];
                            break;
                        case CalculationBLL.FORMULA_TEMPRATURE_COMP:
                            caclSelectTabs.SelectedTab = temperatureCompTab;
                            temp_Tk.Text = parameters[0];
                            temp_Ti.Text = parameters[1];
                            setSelectedItem(temp_Tc, parameters[2]);//
                            temp_Tc.Text = SensorBLL.Current.GetByID(parameters[2].ToInt32TryParse()).Name;
                            temp_C0.Text = parameters[3];
                            temp_C1.Text = parameters[4];
                            temp_C2.Text = parameters[5];
                            temp_C3.Text = parameters[6];
                            temp_C4.Text = parameters[7];
                            temp_C5.Text = parameters[8];
                            break;
                        case CalculationBLL.FORMULA_VW_LINEAR:
                            caclSelectTabs.SelectedTab = vwLinearTab;
                            vwLinear_Tk.Text = parameters[0];
                            vwLinear_Ti.Text = parameters[1];
                            setSelectedItem(vwLinear_Tc, parameters[2]);//
                            vwLinear_CK.Text = parameters[3];
                            vwLinear_Li.Text = parameters[4];
                            vwLinear_Lm.Text = parameters[5];
                            vwLinear_Bi.Text = parameters[6];
                            setSelectedItem(vwLinear_Bc, parameters[7]);//
                            vwLinear_D.Text = parameters[8];
                            vwLinear_E.Text = parameters[9];
                            break;
                        case CalculationBLL.FORMULA_VW_POLY:
                            caclSelectTabs.SelectedTab = vwPoly;
                            vwPoly_Tk.Text = parameters[0];
                            vwPoly_Ti.Text = parameters[1];
                            setSelectedItem(vwPoly_Tc, parameters[2]);//
                            vwPoly_A.Text = parameters[3];
                            vwPoly_B.Text = parameters[4];
                            vwPoly_Lm.Text = parameters[5];
                            vwPoly_Bi.Text = parameters[6];
                            setSelectedItem(vwPoly_Bc, parameters[7]);//
                            vwPoly_C.Text = parameters[8];
                            vwPoly_D.Text = parameters[9];
                            vwPoly_E.Text = parameters[10];
                            break;
                        case CalculationBLL.FORMULA_USER_DEFINED:
                            break;
                    }
                }
                else if (_editingSensor.FormulaType == CalculationBLL.FORMULA_USER_DEFINED)
                {
                    caclSelectTabs.SelectedTab = tabUserDefine;
                    txtUserExpression.Text = _editingSensor.FormulaFunction;
                }
                //nameTextBox.Focus();

                // Batch Edit
                if (sensorGridView.SelectedRows.Count > 1)
                {
                    _addEditState = STATE_BATCH_EDITING;
                    nameTextBox.ReadOnly = columnIndexNumeric.ReadOnly = descriptionTextBox.ReadOnly = true;
                    updateInfo.Visible = updateCalc.Visible = updateAlarm.Visible = true;
                    updateInfo.Checked = updateCalc.Checked = updateAlarm.Checked = false;
                }
                else
                {
                    _addEditState = STATE_EDITING;
                    nameTextBox.ReadOnly = columnIndexNumeric.ReadOnly = descriptionTextBox.ReadOnly = false;
                    updateInfo.Visible = updateCalc.Visible = updateAlarm.Visible = false;
                }
            }

        }

        private void addEdit()
        {
            try
            {
                if (_addEditState == 0 || _editingSensor == null)
                {
                    _editingSensor = new Sensor();
                    _editingSensor.Logger = _logger;
                }

                string functionParameters = "";
                int formulaType = 0;

                if (caclSelectTabs.SelectedTab == linearTab)
                {
                    formulaType = CalculationBLL.FORMULA_LINEAR;
                    functionParameters = string.Format(CalculationBLL.PARAMS_LINEAR,
                                                       linear_C0.Text.ToDecimalTryParse().ToDecimalString(),
                                                       linear_C1.Text.ToDecimalTryParse().ToDecimalString());
                }
                else if (caclSelectTabs.SelectedTab == arcToLengthTab)
                {
                    formulaType = arc_Degree.Checked ? CalculationBLL.FORMULA_ARCTOLENGTH_DEGREE : CalculationBLL.FORMULA_ARCTOLENGTH_RADIAN;
                    functionParameters = string.Format(CalculationBLL.PARAMS_ARCTOLENGTH_DEGREE,
                                                       arc_Length.Text.ToDecimalTryParse().ToDecimalString()
                                                       );


                }
                else if (caclSelectTabs.SelectedTab == polynomialTab)
                {
                    formulaType = CalculationBLL.FORMULA_POLYNOMIAL;
                    functionParameters = string.Format(CalculationBLL.PARAMS_POLYNOMIAL,
                                                       poly_C0.Text.ToDecimalTryParse().ToDecimalString(),
                                                       poly_C1.Text.ToDecimalTryParse().ToDecimalString(),
                                                       poly_C2.Text.ToDecimalTryParse().ToDecimalString(),
                                                       poly_C3.Text.ToDecimalTryParse().ToDecimalString(),
                                                       poly_C4.Text.ToDecimalTryParse().ToDecimalString(),
                                                       poly_C5.Text.ToDecimalTryParse().ToDecimalString()
                                                       );

                }
                else if (caclSelectTabs.SelectedTab == temperatureCompTab)
                {
                    formulaType = CalculationBLL.FORMULA_TEMPRATURE_COMP;
                    functionParameters = string.Format(CalculationBLL.PARAMS_TEMPRATURE_COMP,
                                                       temp_Tk.Text.ToDecimalTryParse().ToDecimalString(),
                                                       temp_Ti.Text.ToDecimalTryParse().ToDecimalString(),
                                                       temp_Tc.SelectedValue,//
                                                       temp_C0.Text.ToDecimalTryParse().ToDecimalString(),
                                                       temp_C1.Text.ToDecimalTryParse().ToDecimalString(),
                                                       temp_C2.Text.ToDecimalTryParse().ToDecimalString(),
                                                       temp_C3.Text.ToDecimalTryParse().ToDecimalString(),
                                                       temp_C4.Text.ToDecimalTryParse().ToDecimalString(),
                                                       temp_C5.Text.ToDecimalTryParse().ToDecimalString()
                                                       );
                }
                else if (caclSelectTabs.SelectedTab == vwLinearTab)
                {
                    formulaType = CalculationBLL.FORMULA_VW_LINEAR;
                    functionParameters = string.Format(CalculationBLL.PARAMS_VW_LINEAR,
                                                       vwLinear_Tk.Text.ToDecimalTryParse().ToDecimalString(),
                                                       vwLinear_Ti.Text.ToDecimalTryParse().ToDecimalString(),
                                                       vwLinear_Tc.SelectedValue, //
                                                       vwLinear_CK.Text.ToDecimalTryParse().ToDecimalString(),
                                                       vwLinear_Li.Text.ToDecimalTryParse().ToDecimalString(),
                                                       vwLinear_Lm.Text.ToDecimalTryParse().ToDecimalString(),
                                                       vwLinear_Bi.Text.ToDecimalTryParse().ToDecimalString(),
                                                       vwLinear_Bc.SelectedValue,
                                                       vwLinear_D.Text.ToDecimalTryParse().ToDecimalString(),
                                                       vwLinear_E.Text.ToDecimalTryParse().ToDecimalString()
                                                       );
                }
                else if (caclSelectTabs.SelectedTab == vwPoly)
                {
                    formulaType = CalculationBLL.FORMULA_VW_POLY;
                    functionParameters = string.Format(CalculationBLL.PARAMS_VW_POLY,
                                                       vwPoly_Tk.Text.ToDecimalTryParse().ToDecimalString(),
                                                       vwPoly_Ti.Text.ToDecimalTryParse().ToDecimalString(),
                                                       vwPoly_Tc.SelectedValue, //
                                                       vwPoly_A.Text.ToDecimalTryParse().ToDecimalString(),
                                                       vwPoly_B.Text.ToDecimalTryParse().ToDecimalString(),
                                                       vwPoly_Lm.Text.ToDecimalTryParse().ToDecimalString(),
                                                       vwPoly_Bi.Text.ToDecimalTryParse().ToDecimalString(),
                                                       vwPoly_Bc.SelectedValue,
                                                       vwPoly_C.Text.ToDecimalTryParse().ToDecimalString(),
                                                       vwPoly_D.Text.ToDecimalTryParse().ToDecimalString(),
                                                       vwPoly_E.Text.ToDecimalTryParse().ToDecimalString()
                                                       );
                }
                else if (caclSelectTabs.SelectedTab == tabUserDefine)
                {
                    try
                    {
                        if (string.IsNullOrEmpty(txtUserExpression.Text)) throw new Exception();
                        double result = CalculateUtils.CalculateInfixExpression(txtUserExpression.Text, "x", 10);
                        formulaType = CalculationBLL.FORMULA_USER_DEFINED;
                        _editingSensor.FormulaFunction = txtUserExpression.Text.Trim();
                    }
                    catch (Exception)
                    {
                        throw new Exception("Biểu thức không hợp lệ!");
                    }

                }



                _editingSensor.ColumnIndex = columnIndexNumeric.Value.ToInt32TryParse();
                _editingSensor.Name = nameTextBox.Text;
                _editingSensor.Description = descriptionTextBox.Text;
                _editingSensor.Unit = unitTextBox.Text;

                _editingSensor.AlarmEnabled = enableAlarmCheckBox.Checked;
                _editingSensor.MinValue = string.IsNullOrEmpty(minAlarmTextBox.Text) ? null : (decimal?)minAlarmTextBox.Text.ToDecimalTryParse();
                _editingSensor.MaxValue = string.IsNullOrEmpty(maxAlarmTextBox.Text) ? null : (decimal?)maxAlarmTextBox.Text.ToDecimalTryParse();

                _editingSensor.FunctionParameters = functionParameters;
                _editingSensor.FormulaType = formulaType;
                // Add object
                if (_addEditState == STATE_ADDING)
                {
                    if (SensorBLL.Current.Insert(_editingSensor))
                    {
                        ShowSuccessMessage(Resources.Message_AddSensorSuccess);
                    }
                    prepareToAdd();
                    BindingData();
                    return;
                }
                // Edit object
                if (_addEditState == STATE_EDITING)
                {
                    if (SensorBLL.Current.Update(_editingSensor))
                    {
                        ShowSuccessMessage(Resources.Message_EditSensorSuccess);
                        //BindingData();
                    }
                    return;
                }
                if (_addEditState == STATE_BATCH_EDITING)
                {
                    if (ShowConfirmMessage("Bạn có muốn cập nhật đồng loạt " + sensorGridView.SelectedRows.Count +
                                           " sensors không?") == DialogResult.OK)
                    {
                        SensorBLL.Current.Validate(_editingSensor);
                        _editingSensor.LastEditedDate = DateTime.Now;
                        _editingSensor.LastEditedUser = AppContext.Current.LogedInUser.Username;
                        for (int i = 0; i < sensorGridView.SelectedRows.Count; i++)
                        {
                            int id = sensorGridView.SelectedRows[i].Cells["SensorID"].Value.ToInt32TryParse();
                            var obj = entityConntext.Sensors.SingleOrDefault(ent => ent.SensorID == id);
                            if (obj != null)
                            {
                                if (updateInfo.Checked)
                                {
                                    obj.Unit = _editingSensor.Unit;
                                }
                                if (updateCalc.Checked)
                                {
                                    obj.FunctionParameters = _editingSensor.FunctionParameters;
                                    obj.FormulaType = _editingSensor.FormulaType;
                                    obj.FormulaFunction = _editingSensor.FormulaFunction;
                                }
                                if (updateAlarm.Checked)
                                {
                                    obj.AlarmEnabled = _editingSensor.AlarmEnabled;
                                    obj.MinValue = _editingSensor.MinValue;
                                    obj.MaxValue = _editingSensor.MaxValue;
                                }
                                obj.LastEditedDate = _editingSensor.LastEditedDate;
                                obj.LastEditedUser = _editingSensor.LastEditedUser;
                            }
                        }
                        entityConntext.SaveChanges();
                        ShowSuccessMessage(Resources.Message_EditSensorSuccess);
                        BindingData();

                    }
                }
                return;
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
                if (_addEditState == 1)
                    entityConntext.Refresh(RefreshMode.StoreWins, _editingSensor);
            }
        }

        #endregion

        #region private events

        private void reloadButton_Click(object sender, EventArgs e)
        {
            BindingData();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            prepareToAdd();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (sensorGridView.SelectedRows.Count == 0)
                {
                    MessageBox.Show(Resources.Warning_NoRecordSelected);
                    return;
                }
                if (ShowConfirmMessage(string.Format(Resources.Confirm_DeleteSensors, sensorGridView.SelectedRows.Count)) == DialogResult.OK)
                {
                    int success = 0;
                    for (int i = 0; i < sensorGridView.SelectedRows.Count; i++)
                    {
                        if (SensorBLL.Current.Delete(sensorGridView.SelectedRows[i].Cells[0].Value.ToInt32TryParse()))
                        {
                            success++;
                        }
                    }
                    if (success > 0)
                    {
                        ShowSuccessMessage(string.Format(Resources.Message_DeleteSensorsSuccess, success));
                        prepareToAdd();
                    }
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        private void temp_TcClearButton_Click(object sender, EventArgs e)
        {
            temp_Tc.SelectedIndex = -1;
        }

        private void vwLinear_Tc_Clear_Click(object sender, EventArgs e)
        {
            vwLinear_Tc.SelectedIndex = -1;
        }

        private void vwLinear_Bc_Clear_Click(object sender, EventArgs e)
        {
            vwLinear_Bc.SelectedIndex = -1;
        }

        private void vwPoly_Tc_Clear_Click(object sender, EventArgs e)
        {
            vwPoly_Tc.SelectedIndex = -1;
        }

        private void vwPoly_Bc_Clear_Click(object sender, EventArgs e)
        {
            vwPoly_Bc.SelectedIndex = -1;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            addEdit();
        }

        private void unitTextBox_Leave(object sender, EventArgs e)
        {
            unitLabel1.Text = unitLabel2.Text = unitTextBox.Text;
        }

        private void sensorGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            prepareToEdit();
        }

        private void recalcButton_Click(object sender, EventArgs e)
        {
            if (sensorGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show(Resources.Warning_NoRecordSelected);
                return;
            }
            if (ShowConfirmMessage(string.Format(Resources.Confirm_CalculateSensors, sensorGridView.SelectedRows.Count)) == DialogResult.OK)
            {
                int success = 0;
                for (int i = 0; i < sensorGridView.SelectedRows.Count; i++)
                {
                    var sensor = SensorBLL.Current.GetByID(sensorGridView.SelectedRows[i].Cells[0].Value.ToInt32TryParse());
                    if (sensor != null)
                    {
                        CalculationBLL.Current.Calculating(sensor, true);
                        success++;
                    }
                }
                if (success > 0)
                {
                    ShowSuccessMessage(string.Format(Resources.Message_CalculateSensorsSuccess, success));
                    prepareToAdd();
                }
                //AppContext.Current.RefreshEntityContext();
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            prepareToEdit();
        }
        #endregion

        private void btnTestExpression_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUserExpression.Text)) throw new Exception();
                double result = CalculateUtils.CalculateInfixExpression(txtUserExpression.Text, "x", 10);
                ShowSuccessMessage("x = 10, Xo = " + result);
            }
            catch (Exception exception)
            {
                ShowErrorMessage("Biểu thức không hợp lệ!");
            }
        }



    }
}
