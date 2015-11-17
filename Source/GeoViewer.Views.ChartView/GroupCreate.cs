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
using GeoViewer.Views.ChartView.Properties;

namespace GeoViewer.Views.ChartView
{
    public partial class GroupCreate : BaseWindowForm
    {
        public GroupCreate()
        {
            InitializeComponent();
        }

        private void btncreategroup_Click(object sender, EventArgs e)
        {
            try
            {
                var group = new Group();
                group.Name = txtgroupname.Text;
                if (ChartViewBLL.Current.InsertGroup(group))
                {
                    ShowSuccessMessage(Resources.Message_CreateGroup_Success);
                }
                this.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private void GroupCreate_Load(object sender, EventArgs e)
        {

        }
    }
}
