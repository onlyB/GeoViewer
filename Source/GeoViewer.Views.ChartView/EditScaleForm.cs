using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class EditScaleForm : BaseWindowForm
    {
        public DataTable datachart;
        public List<Color> colors;
        public GraphPane pane;

        public EditScaleForm()
        {
            InitializeComponent();
        }

        private int rowindex = -1;

        private void btncolor_Click(object sender, EventArgs e)
        {
            try
            {
                if (rowindex > -1 && colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    colors[rowindex] = colorDialog1.Color;
                    btncolor.BackColor = colors[rowindex];
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        private void comboedittype_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rowindex > -1)
                {
                    string selectedcombo = comboedittype.Items[comboedittype.SelectedIndex].ToString();
                    if (selectedcombo == "Raw")
                    {
                        datachart.Rows[rowindex]["TypeofValue"] = 0;
                    }
                    if (selectedcombo == "Refine")
                    {
                        datachart.Rows[rowindex]["TypeofValue"] = 1;
                    }
                    EditScaleGridView.DataSource = datachart;
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        private void comboeditbold_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rowindex > -1)
                {

                    string selectedcombo = comboeditbold.Items[comboeditbold.SelectedIndex].ToString();
                    datachart.Rows[rowindex]["BoldLine"] = Convert.ToInt16(selectedcombo);
                    EditScaleGridView.DataSource = datachart;
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                pane.Title.Text = txtChartTitle.Text;
                pane.XAxis.Title.Text = txtXaxis.Text;
                pane.YAxis.Title.Text = txtYaxis.Text;
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void EditScaleForm_Load(object sender, EventArgs e)
        {
            try
            {
                EditScaleGridView.DataSource = datachart;
                btncolor.BackColor = Color.Gray;
                comboeditbold.Text = "";
                comboedittype.Text = "";
                txtChartTitle.Text = pane.Title.Text;
                txtXaxis.Text = pane.XAxis.Title.Text;
                txtYaxis.Text = pane.YAxis.Title.Text;
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        private void EditScaleGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                rowindex = e.RowIndex;
                //show color
                btncolor.BackColor = colors[rowindex];
                //show data type
                if (Convert.ToInt16(datachart.Rows[rowindex]["TypeofValue"]) == 0)
                {
                    comboedittype.Text = "Raw";
                }
                else comboedittype.Text = "Refine";
                //show bold line
                comboeditbold.Text = datachart.Rows[rowindex]["BoldLine"].ToString();
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        private void cbStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rowindex > -1 && cbStyle.SelectedIndex > -1)
                {
                    datachart.Rows[rowindex]["LineStyle"] = cbStyle.SelectedIndex;
                    
                    EditScaleGridView.DataSource = datachart;
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

    }
}
