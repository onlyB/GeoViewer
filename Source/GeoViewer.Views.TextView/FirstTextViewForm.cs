using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using GeoViewer.Utils;
using GeoViewer.Models;
using GeoViewer.Business;
using System.Windows.Forms;
using System.Data;
using GeoViewer.Views.ChartView;


namespace GeoViewer.Views.TextView
{
    public partial class FirstTextViewForm : BaseWindowForm
    {


        public FirstTextViewForm()
        {
            InitializeComponent();
            LoadAllSensor();
        }


        private void LoadAllSensor()
        {
            List<Sensor> listsensor = entityConntext.Sensors.ToList();
            var list = (from ent in listsensor
                        select new { ent.SensorID, ent.Name });
            GridViewText.DataSource = list.ToList();
        }

        private void LoadGroupSensor()
        {
            List<Group> listgroup = entityConntext.Groups.ToList();
            var list = (from ent in listgroup
                        select new { ent.GroupID, ent.Name });
            GridViewText.DataSource = list.ToList();
        }

        private void LoadPictureSensor()
        {
            List<PictureView> listpicture = entityConntext.PictureViews.ToList();
            var list = (from ent in listpicture
                        select new { ent.PictureViewID, ent.Name });
            GridViewText.DataSource = list.ToList();
        }

        private void FirstTextViewForm_Load(object sender, EventArgs e)
        {
            CheckRoleForView(SecurityBLL.ROLE_VIEWS_VIEW);
        }

        //check box raw or refine data
        string typeofdata = "RawData";
        int ckbidgroup = 0;
        List<string> ckbname = new List<string>();
        List<int> ckbidsensors = new List<int>();

        private void loaddatacheckbox()
        {
            resettblvalue();
            if (selectedcombo == "All Sensors")
            {
                for (int i = 0; i < ckbidsensors.Count; i++)
                {
                    int idsensor1 = ckbidsensors[i];
                    List<SensorValue> listvalue1 = entityConntext.SensorValues.Where(ent => ent.SensorID == idsensor1).OrderByDescending(ent => ent.MeaTime).Distinct().ToList();

                    if (sensorontbl == 0)
                    {
                        setmeatime();
                    }
                    DataTable tblunit = getdatatable(listvalue1, typeofdata, ckbname[i]);
                    tblvalue = jointbl(tblvalue, tblunit);

                    ValueGridView.DataSource = tblvalue;
                    sensorontbl++;
                }
            }
            if (selectedcombo == "Group")
            {
                int idgroup = ckbidgroup;
                //get sensors in group
                var group = ChartViewBLL.Current.GetGroupByID(idgroup);
                List<Sensor> sensorsInGroup = group.Sensors.ToList();
                DataTable tbllistsensor = getdatatable(sensorsInGroup);

                int sensorcount = sensorsInGroup.Count();
                setmeatime();
                for (int i = 0; i < sensorcount; i++)
                {
                    int idsensor2 = Convert.ToInt16(tbllistsensor.Rows[i]["SensorID"]);
                    List<SensorValue> listvalue2 = entityConntext.SensorValues.Where(ent => ent.SensorID == idsensor2).OrderByDescending(ent => ent.MeaTime).Distinct().ToList();
                    DataTable tblunit2 = getdatatable(listvalue2, typeofdata, tbllistsensor.Rows[i]["Name"].ToString());
                    tblvalue = jointbl(tblvalue, tblunit2);
                    sensorontbl++;
                }
                ValueGridView.DataSource = tblvalue;
            }
        }


        private void resetcheckbox()
        {
            //reset for checkbox
            ckbidgroup = 0;
            for (int i = ckbidsensors.Count; i > 0; i--)
            {
                ckbidsensors.Remove(ckbidsensors[i - 1]);
            }

            for (int i = ckbname.Count; i > 0; i--)
            {
                ckbname.Remove(ckbname[i - 1]);
            }
            sensorontbl = 0;
        }


        DataTable tblvalue = new DataTable();  //datatable to show on grid 
        int sensorontbl = 0; //number of sensor in datatable


        //set all time in grid
        private void setmeatime()
        {
            var list = (from ent in entityConntext.SensorValues
                        where ent.SensorID != -1
                        orderby ent.MeaTime
                        select new { ent.MeaTime }).Distinct().ToList();
            ValueGridView.DataSource = list;
            tblvalue.Columns.Add("MeaTime");
            for (int i = 0; i < list.Count; i++)
            {
                DataRow tblrow = tblvalue.NewRow();
                tblrow["MeaTime"] = ValueGridView.Rows[i].Cells[0].Value;
                tblvalue.Rows.Add(tblrow);
            }
        }



        //Clear all the value show on gridvalue
        private void Clearbtn_Click(object sender, EventArgs e)
        {
            resettblvalue();
            resetcheckbox();
        }


        //reset tblvalue
        private void resettblvalue()
        {
            int countrow = tblvalue.Rows.Count;
            int countcol = tblvalue.Columns.Count;

            for (int i = 0; i < countrow; i++)
            {
                tblvalue.Rows[0].Delete();
            }

            for (int i = 0; i < countcol; i++)
            {
                tblvalue.Columns.Remove(tblvalue.Columns[0].ColumnName);
            }
            sensorontbl = 0;
            ValueGridView.DataSource = tblvalue;
        }


        //join many data value in one tbale
        private DataTable jointbl(DataTable tbl1, DataTable tbl2)
        {
            foreach (DataColumn col in tbl1.Columns)
            {
                if (col.ColumnName == tbl2.Columns[1].ColumnName) return tbl1;
            }

            string colname = tbl2.Columns[1].ColumnName.ToString();
            tbl1.Columns.Add(colname);

            //gan gia tri cho bang tuong ung voi cot Meatime
            int indexrow1 = 0;
            foreach (DataRow row1 in tbl1.Rows)
            {
                int indexrow2 = 0;
                foreach (DataRow row2 in tbl2.Rows)
                {
                    if ((row1["MeaTime"].ToString()).Equals(row2["MeaTime"].ToString()))
                    {
                        row1[colname] = row2[colname];
                    }
                    indexrow2++;
                }
                indexrow1++;
            }
            return tbl1;
        }



        //getdatablevalue from list of value and Meatime
        private DataTable getdatatable(List<SensorValue> listvalue, string typedata, string sensorname)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("MeaTime");
            if (typedata == "RawData")
            {
                dt.Columns.Add("Raw value of " + sensorname);
                for (int i = 0; i < listvalue.Count; i++)
                {
                    DataRow tblrow = dt.NewRow();
                    tblrow["MeaTime"] = Convert.ToDateTime(listvalue[i].MeaTime);
                    tblrow["Raw value of " + sensorname] = listvalue[i].RawValue;
                    dt.Rows.Add(tblrow);
                }
            }
            if (typedata == "RefineData")
            {
                dt.Columns.Add("Refine value of " + sensorname);
                for (int i = 0; i < listvalue.Count; i++)
                {
                    DataRow tblrow = dt.NewRow();
                    tblrow["MeaTime"] = Convert.ToDateTime(listvalue[i].MeaTime);
                    tblrow["Refine value of " + sensorname] = listvalue[i].CalcValue;
                    dt.Rows.Add(tblrow);
                }
            }
            return dt;
        }

        private DataTable getdatatable(List<Sensor> listsensor)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("SensorID");
            dt.Columns.Add("Name");
            for (int i = 0; i < listsensor.Count; i++)
            {
                DataRow tblrow = dt.NewRow();
                tblrow["SensorID"] = listsensor[i].SensorID;
                tblrow["Name"] = listsensor[i].Name;
                dt.Rows.Add(tblrow);
            }
            return dt;
        }


        //select combobox
        string selectedcombo = "All Sensors";
        private void combotext_SelectedIndexChanged(object sender, EventArgs e)
        {
            resettblvalue();
            resetcheckbox();
            selectedcombo = combotext.Items[combotext.SelectedIndex].ToString();
            if (selectedcombo == "All Sensors")
            {
                LoadAllSensor();
            }

            if (selectedcombo == "Group")
            {
                LoadGroupSensor();
            }

            if (selectedcombo == "Picture")
            {
                LoadPictureSensor();
            }
        }

        //edit group
        private void editFroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GroupsManagerForm editgroupform = new GroupsManagerForm();
            editgroupform.ShowDialog();
        }

        private void rawValueRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (calcRadio.Checked)
            {
                typeofdata = "RefineData";
            }
            else
            {
                typeofdata = "RawData";
            }
            loaddatacheckbox();
        }

        private void GridViewText_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                DataGridViewRow rowgrid = GridViewText.Rows[e.RowIndex];

                if (selectedcombo == "All Sensors")     //Neu datagrid bieu dien all sensor
                {
                    int idsensor1 = Convert.ToInt16(rowgrid.Cells[0].Value.ToString());
                    List<SensorValue> listvalue1 = entityConntext.SensorValues.Where(ent => ent.SensorID == idsensor1).OrderByDescending(ent => ent.MeaTime).Distinct().ToList();

                    if (sensorontbl == 0)
                    {
                        setmeatime();
                    }
                    DataTable tblunit = getdatatable(listvalue1, typeofdata, rowgrid.Cells[1].Value.ToString());
                    tblvalue = jointbl(tblvalue, tblunit);

                    ValueGridView.DataSource = tblvalue;
                    ckbidsensors.Add(idsensor1); //save for checkbox
                    ckbname.Add(rowgrid.Cells[1].Value.ToString());

                    sensorontbl++;
                    return;
                }

                if (selectedcombo == "Group")
                {
                    resettblvalue();
                    int idgroup = Convert.ToInt16(rowgrid.Cells[0].Value.ToString());
                    //get sensors in group
                    var group = ChartViewBLL.Current.GetGroupByID(idgroup);
                    List<Sensor> sensorsInGroup = group.Sensors.ToList();
                    DataTable tbllistsensor = getdatatable(sensorsInGroup);

                    int sensorcount = sensorsInGroup.Count();
                    setmeatime();
                    for (int i = 0; i < sensorcount; i++)
                    {
                        int idsensor2 = Convert.ToInt16(tbllistsensor.Rows[i]["SensorID"]);
                        List<SensorValue> listvalue2 = entityConntext.SensorValues.Where(ent => ent.SensorID == idsensor2).OrderByDescending(ent => ent.MeaTime).Distinct().ToList();
                        DataTable tblunit2 = getdatatable(listvalue2, typeofdata, tbllistsensor.Rows[i]["Name"].ToString());
                        tblvalue = jointbl(tblvalue, tblunit2);
                        sensorontbl++;
                    }
                    ValueGridView.DataSource = tblvalue;

                    ckbidgroup = idgroup;//save for checkbox
                }

                if (selectedcombo == "Picture")
                {

                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }





    }
}
