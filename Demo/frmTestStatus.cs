using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace LoggerDemo
{
    public partial class frmTestStatus : Form
    {
        public frmTestStatus()
        {
            InitializeComponent();
        }

        public void addToTestOutput(String Data)
        {
            txtLog.AppendText($"{DateTime.Now}: {Data}{Environment.NewLine}");
        }

        private void frmTestStatus_Load(object sender, EventArgs e)
        {
        }

        private void btnOpenLogDirectoryInExplorer_Click(object sender, EventArgs e)
        {
            frmMain? _frmMain = this.Owner as frmMain;

            if (_frmMain == null)
            {
                MessageBox.Show("eek.");
                return;
            }

            if (_frmMain?.getLoggerInstance() is Labworx.Logger logger && Directory.Exists(logger.LogFilePath))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = logger.LogFilePath,
                    UseShellExecute = true
                });
            }
        }

        private void btnStopTest_Click(object sender, EventArgs e)
        {
            frmMain? _frmMain = this.Owner as frmMain;

            if (_frmMain == null)
            {
                MessageBox.Show("Eeek!");
                return;
            }

            _frmMain.StopTest();
        }

        public void TestStopped()
        {
            this.btnStopTest.Enabled = false;
            this.addToTestOutput("Test Stopped.");
        }

        public void TestStarted()
        {
            this.btnStopTest.Enabled = true;
            this.addToTestOutput("Test Started.");
        }

        private void frmTestStatus_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMain? _frmMain = this.Owner as frmMain;

            if (_frmMain == null)
            {
                MessageBox.Show("Eeek!");
                return;
            }

            _frmMain.StopTest();
        }
    }
}
