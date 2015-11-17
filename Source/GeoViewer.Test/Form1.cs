using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GeoViewer.Business;
using GeoViewer.Utils;

namespace GeoViewer.Test
{
    public partial class Form1 : BaseWindowForm
    {
        public Form1()
        {
            InitializeComponent();
            ReaderThreadManager.Current.InitThreads();
            ReaderThreadManager.Current.StartThreads();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*var form2 = new Form2("Hello");
            var dialogResult = form2.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                label1.Text = form2.ReturnValue;
            }
            else if(dialogResult == DialogResult.Cancel)
            {
                label1.Text = "Cancel";
            }*/
            try
            {
                ReaderThreadManager.Current.StopThread(textBox1.Text.ToInt32TryParse());
                ShowSuccessMessage("Stop Ok");
            }
            catch(Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int id = textBox1.Text.ToInt32TryParse();
            if(id > 0)
            {
                label1.Text = ReaderThreadManager.Current.ReadDataWorks[id].TimeToNextRead.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // timer1.Start();
            var logger = LoggerBLL.Current.GetByID(textBox1.Text.ToInt32TryParse());
            logger.ReadInterval = textBox2.Text.ToInt32TryParse();
            LoggerBLL.Current.Update(logger);
        }
    }
}
