using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GeoViewer.Test
{
    public partial class Form2 : Form
    {
        public string ReturnValue;
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(string text)
        {
            InitializeComponent();
            textBox1.Text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReturnValue = textBox1.Text;
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReturnValue = textBox1.Text;
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }
    }
}
