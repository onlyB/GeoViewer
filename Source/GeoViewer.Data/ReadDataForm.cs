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

namespace GeoViewer.Data
{
    public partial class ReadDataForm : BaseWindowForm
    {
        private Logger _logger;
        private AutomaticReadData _automaticReadData;

        public ReadDataForm(Logger logger, bool onlyNewData, bool calculateValue)
        {
            _logger = logger;
            _automaticReadData = ReaderThreadManager.Current.ReadDataByThread(logger, onlyNewData, calculateValue);
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(!_automaticReadData.IsReading)
            {
                this.Close();
            }
            if (!string.IsNullOrEmpty(_automaticReadData.ReaderProccess.CurrentFile))
            {
                if (_automaticReadData.ReaderProccess.FileReaderProccesses != null)
                {
                    lblCurrentFolder.Visible = lblFolderLineCount.Visible = lblFolder.Visible = true;
                    lblCurrentFolder.Text = _logger.DataPath;
                    lblFolderLineCount.Text = string.Format("{0} / {1} dòng", _automaticReadData.ReaderProccess.ReadRecord, _automaticReadData.ReaderProccess.TotalRecord);
                
                    if(_automaticReadData.ReaderProccess.FileReaderProccesses.Count > 0)
                    {
                        var fileReaderProcess = _automaticReadData.ReaderProccess.FileReaderProccesses.Last();
                        lblCurrentFile.Text = fileReaderProcess.CurrentFile;
                        lblFileLineCount.Text = string.Format("{0} / {1} dòng", fileReaderProcess.ReadRecord, fileReaderProcess.TotalRecord);
                        int percent = fileReaderProcess.TotalRecord > 0 ? (int) ((fileReaderProcess.ReadRecord * 100)/fileReaderProcess.TotalRecord) : 0;
                        progressReader.Value = percent > 100 ? 100 : percent;
                    }

                }
                else
                {
                    lblCurrentFile.Text = _automaticReadData.ReaderProccess.CurrentFile;
                    lblFileLineCount.Text = string.Format("{0} / {1} dòng", _automaticReadData.ReaderProccess.ReadRecord, _automaticReadData.ReaderProccess.TotalRecord);
                    int percent =  _automaticReadData.ReaderProccess.TotalRecord > 0 ? (int)((_automaticReadData.ReaderProccess.ReadRecord * 100) / _automaticReadData.ReaderProccess.TotalRecord) : 0;
                    progressReader.Value = percent > 100 ? 100 : percent;

                    lblCurrentFolder.Visible = lblFolderLineCount.Visible = lblFolder.Visible = false;

                }

            }

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            e.Cancel = _automaticReadData.IsReading;
        }
    }
}
