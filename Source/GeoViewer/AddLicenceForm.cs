using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GeoViewer.Business;

namespace GeoViewer
{
    public partial class AddLicenceForm : BaseWindowForm
    {
        public AddLicenceForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(LicenceBLL.ValidateKey(txtLicence.Text))
            {

                // Save licence
                StreamWriter writer = new StreamWriter("licence.bbk");
                writer.Write(LicenceBLL.GenerateKey());
                writer.Flush();
                writer.Close();

                ShowSuccessMessage("GeoDiv đã được kích hoạt thành công!");
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                ShowErrorMessage("Mã kích hoạt không hợp lệ!");
            }
        }
    }
}
