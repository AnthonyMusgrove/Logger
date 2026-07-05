namespace LoggerDemo
{
    partial class frmTestStatus
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtLog = new TextBox();
            btnStopTest = new Button();
            btnOpenLogDirectoryInExplorer = new Button();
            SuspendLayout();
            // 
            // txtLog
            // 
            txtLog.BackColor = Color.White;
            txtLog.BorderStyle = BorderStyle.None;
            txtLog.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLog.Location = new Point(6, 7);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.Size = new Size(519, 506);
            txtLog.TabIndex = 0;
            // 
            // btnStopTest
            // 
            btnStopTest.FlatStyle = FlatStyle.Flat;
            btnStopTest.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStopTest.Location = new Point(427, 520);
            btnStopTest.Name = "btnStopTest";
            btnStopTest.Size = new Size(75, 32);
            btnStopTest.TabIndex = 21;
            btnStopTest.Text = "Stop Test";
            btnStopTest.UseVisualStyleBackColor = true;
            btnStopTest.Click += btnStopTest_Click;
            // 
            // btnOpenLogDirectoryInExplorer
            // 
            btnOpenLogDirectoryInExplorer.FlatStyle = FlatStyle.Flat;
            btnOpenLogDirectoryInExplorer.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOpenLogDirectoryInExplorer.Location = new Point(193, 520);
            btnOpenLogDirectoryInExplorer.Name = "btnOpenLogDirectoryInExplorer";
            btnOpenLogDirectoryInExplorer.Size = new Size(228, 32);
            btnOpenLogDirectoryInExplorer.TabIndex = 22;
            btnOpenLogDirectoryInExplorer.Text = "Open Log Directory in Explorer";
            btnOpenLogDirectoryInExplorer.UseVisualStyleBackColor = true;
            btnOpenLogDirectoryInExplorer.Click += btnOpenLogDirectoryInExplorer_Click;
            // 
            // frmTestStatus
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(528, 561);
            Controls.Add(btnOpenLogDirectoryInExplorer);
            Controls.Add(btnStopTest);
            Controls.Add(txtLog);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmTestStatus";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Test Status";
            FormClosing += frmTestStatus_FormClosing;
            Load += frmTestStatus_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtLog;
        private Button btnStopTest;
        private Button btnOpenLogDirectoryInExplorer;
    }
}