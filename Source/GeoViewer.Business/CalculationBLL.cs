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
using GeoViewer.Utils;

namespace GeoViewer.Business
{
    public class CalculationBLL
    {
        #region Instance Of Class
        private static CalculationBLL _current = new CalculationBLL();
        public static CalculationBLL Current
        {
            get { return _current; }
        }
        #endregion

        public const int FORMULA_LINEAR = 0;
        public const int FORMULA_ARCTOLENGTH_DEGREE = 1;
        public const int FORMULA_ARCTOLENGTH_RADIAN = 2;
        public const int FORMULA_POLYNOMIAL = 3;
        public const int FORMULA_TEMPRATURE_COMP = 4;
        public const int FORMULA_VW_LINEAR = 5;
        public const int FORMULA_VW_POLY = 6;
        public const int FORMULA_USER_DEFINED = 7;

        public const string PARAMS_LINEAR = "{0}#{1}";
        public const string PARAMS_ARCTOLENGTH_DEGREE = "{0}";
        public const string PARAMS_ARCTOLENGTH_RADIAN = "{0}";
        public const string PARAMS_POLYNOMIAL = "{0}#{1}#{2}#{3}#{4}#{5}";
        public const string PARAMS_TEMPRATURE_COMP = "{0}#{1}#{2}#{3}#{4}#{5}#{6}#{7}#{8}";
        public const string PARAMS_VW_LINEAR = "{0}#{1}#{2}#{3}#{4}#{5}#{6}#{7}#{8}#{9}";
        public const string PARAMS_VW_POLY = "{0}#{1}#{2}#{3}#{4}#{5}#{6}#{7}#{8}#{9}#{10}";
        //public const string PARAMS_USER_DEFINED = "{0}#{1}";

        /// <summary>
        /// Calculate values of all entries of a sensor with alarm logger option
        /// Auto save changed to database
        /// </summary>
        /// <param name="sensor"></param>
        /// <param name="alarmLogger"></param>
        public void Calculating(Sensor sensor, bool alarmLogger)
        {
            foreach (var sensorValue in sensor.SensorValues)
            {
                Calculating(sensorValue);
            }
            if (alarmLogger)
            {
                foreach (var sensorValue in sensor.SensorValues)
                {
                    AlarmBLL.Current.CheckAlarm(sensorValue);
                }
            }
        }

        /// <summary>
        /// Calculate single sensor value with alarm option
        /// Non auto save changed to database, you must call entityConntext.SaveChanges() to save changed.
        /// </summary>
        /// <param name="sensorValue"></param>
        /// <param name="alarmLogger"></param>
        public void Calculating(SensorValue sensorValue, bool alarmLogger)
        {
            Calculating(sensorValue);
            if (alarmLogger)
            {
                AlarmBLL.Current.CheckAlarm(sensorValue);
            }
        }

        /// <summary>
        /// Calculate value of a sensor entry
        /// </summary>
        /// <param name="sensorValue"></param>
        /// <returns></returns>
        public decimal? Calculating(SensorValue sensorValue)
        {
            int formulaType = sensorValue.Sensor.FormulaType;
            if (formulaType == FORMULA_USER_DEFINED && !string.IsNullOrEmpty(sensorValue.Sensor.FormulaFunction))
            {
                sensorValue.CalcValue = CalculateUtils.CalculateInfixExpression(sensorValue.Sensor.FormulaFunction, "x",
                                                                                sensorValue.RawValue.ToString().Replace(",",".")).ToDecimalTryParse();
            }
            else
            {
                if (string.IsNullOrEmpty(sensorValue.Sensor.FunctionParameters)) return null;
                string[] parameters;
                parameters = sensorValue.Sensor.FunctionParameters.Contains("#") ? sensorValue.Sensor.FunctionParameters.Split('#') : new string[] { sensorValue.Sensor.FunctionParameters };
                // Calculate value
                if (formulaType == FORMULA_LINEAR)
                {
                    if (parameters.Length < 2) return null;
                    sensorValue.CalcValue = CalculateUtils.Linear(sensorValue.RawValue,
                                                                  parameters[0].ToDecimalTryParse(),
                                                                  parameters[1].ToDecimalTryParse());
                }
                else if (formulaType == FORMULA_ARCTOLENGTH_DEGREE)
                {
                    if (parameters.Length < 1) return null;
                    sensorValue.CalcValue =
                        CalculateUtils.ArcToLengthDegree(sensorValue.RawValue.ToDoubleTryParse(),
                                                         parameters[0].ToDoubleTryParse()).ToDecimalTryParse();
                }
                else if (formulaType == FORMULA_ARCTOLENGTH_RADIAN)
                {
                    if (parameters.Length < 1) return null;
                    sensorValue.CalcValue =
                        CalculateUtils.ArcToLengthRadian(sensorValue.RawValue.ToDoubleTryParse(),
                                                         parameters[0].ToDoubleTryParse()).ToDecimalTryParse();
                }
                else if (formulaType == FORMULA_POLYNOMIAL)
                {
                    if (parameters.Length < 6) return null;

                    sensorValue.CalcValue =
                        CalculateUtils.Polynomial(sensorValue.RawValue.ToDoubleTryParse(),
                                                  parameters[0].ToDoubleTryParse(),
                                                  parameters[1].ToDoubleTryParse(),
                                                  parameters[2].ToDoubleTryParse(),
                                                  parameters[3].ToDoubleTryParse(),
                                                  parameters[4].ToDoubleTryParse(),
                                                  parameters[5].ToDoubleTryParse()).
                            ToDecimalTryParse();
                }
                else if (formulaType == FORMULA_TEMPRATURE_COMP)
                {
                    if (parameters.Length < 9) return null;

                    var tcSensor = SensorBLL.Current.GetByID(parameters[2].ToInt32TryParse());
                    if (tcSensor == null) return null;
                    var tcValue = tcSensor.SensorValues.SingleOrDefault(ent => ent.MeaTime == sensorValue.MeaTime);
                    if (tcValue == null) return null;

                    sensorValue.CalcValue = CalculateUtils.TemperatureComp(
                        sensorValue.RawValue.ToDoubleTryParse(),
                        parameters[0].ToDoubleTryParse(),
                        parameters[1].ToDoubleTryParse(),
                        tcValue.RawValue.ToDoubleTryParse(), // Raw value or calc value???
                        parameters[3].ToDoubleTryParse(),
                        parameters[4].ToDoubleTryParse(),
                        parameters[5].ToDoubleTryParse(),
                        parameters[6].ToDoubleTryParse(),
                        parameters[7].ToDoubleTryParse(),
                        parameters[8].ToDoubleTryParse()
                        ).ToDecimalTryParse();

                }
                else if (formulaType == FORMULA_VW_LINEAR)
                {
                    if (parameters.Length < 10) return null;

                    var tcSensor = SensorBLL.Current.GetByID(parameters[2].ToInt32TryParse());
                    if (tcSensor == null) return null;
                    var bcSensor = SensorBLL.Current.GetByID(parameters[7].ToInt32TryParse());
                    if (bcSensor == null) return null;
                    var tcValue = tcSensor.SensorValues.SingleOrDefault(ent => ent.MeaTime == sensorValue.MeaTime);
                    if (tcValue == null) return null;
                    var bcValue = bcSensor.SensorValues.SingleOrDefault(ent => ent.MeaTime == sensorValue.MeaTime);
                    if (bcValue == null) return null;
                    sensorValue.CalcValue = CalculateUtils.VwLinear(
                        parameters[0].ToDoubleTryParse(),
                        parameters[1].ToDoubleTryParse(),
                        tcValue.RawValue.ToDoubleTryParse(), // Raw value of Tc Sensor
                        parameters[3].ToDoubleTryParse(),
                        parameters[4].ToDoubleTryParse(),
                        parameters[5].ToDoubleTryParse(),
                        sensorValue.RawValue.ToDoubleTryParse(), // Raw value of current sensor (Lc)
                        parameters[6].ToDoubleTryParse(),
                        bcValue.RawValue.ToDoubleTryParse(), // Raw value of Bc Sensor
                        parameters[8].ToDoubleTryParse(),
                        parameters[9].ToDoubleTryParse()
                        ).ToDecimalTryParse();
                }
                else if (formulaType == FORMULA_VW_POLY)
                {
                    if (parameters.Length < 11) return null;

                    var tcSensor = SensorBLL.Current.GetByID(parameters[2].ToInt32TryParse());
                    if (tcSensor == null) return null;
                    var bcSensor = SensorBLL.Current.GetByID(parameters[7].ToInt32TryParse());
                    if (bcSensor == null) return null;
                    var tcValue = tcSensor.SensorValues.SingleOrDefault(ent => ent.MeaTime == sensorValue.MeaTime);
                    if (tcValue == null) return null;
                    var bcValue = bcSensor.SensorValues.SingleOrDefault(ent => ent.MeaTime == sensorValue.MeaTime);
                    if (bcValue == null) return null;
                    sensorValue.CalcValue = CalculateUtils.VwPoly(
                        parameters[0].ToDoubleTryParse(),
                        parameters[1].ToDoubleTryParse(),
                        tcValue.RawValue.ToDoubleTryParse(), // Raw value of Tc Sensor
                        parameters[3].ToDoubleTryParse(),
                        parameters[4].ToDoubleTryParse(),
                        parameters[5].ToDoubleTryParse(),
                        sensorValue.RawValue.ToDoubleTryParse(), // Raw value of current sensor (Lc)
                        parameters[6].ToDoubleTryParse(),
                        bcValue.RawValue.ToDoubleTryParse(), // Raw value of Bc Sensor
                        parameters[8].ToDoubleTryParse(),
                        parameters[9].ToDoubleTryParse(),
                        parameters[10].ToDoubleTryParse()
                        ).ToDecimalTryParse();
                }
            }

            return sensorValue.CalcValue;
        }
    }
}
