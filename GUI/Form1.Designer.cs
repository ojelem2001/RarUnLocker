﻿namespace GUI
{
    partial class Form1
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
            this.openArchDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnFileLoad = new System.Windows.Forms.Button();
            this.tbFilePath = new System.Windows.Forms.TextBox();
            this.brTotalProgress = new System.Windows.Forms.ProgressBar();
            this.lbFilePath = new System.Windows.Forms.Label();
            this.lstFormsLog = new System.Windows.Forms.TextBox();
            this.tbFindPass = new System.Windows.Forms.TextBox();
            this.lbCurpass = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMinLength = new System.Windows.Forms.TextBox();
            this.tbMaxLength = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chbDigits = new System.Windows.Forms.CheckBox();
            this.chbUpLeter = new System.Windows.Forms.CheckBox();
            this.chbLowLeter = new System.Windows.Forms.CheckBox();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.tbTotalTime = new System.Windows.Forms.TextBox();
            this.lbTotalTime = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbSpeed = new System.Windows.Forms.Label();
            this.tbExpectedTime = new System.Windows.Forms.TextBox();
            this.lbExpectedTime = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.chbSpecSymb = new System.Windows.Forms.CheckBox();
            this.tbox11 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // openArchDialog
            // 
            this.openArchDialog.FileName = "openArchDialog";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(35, 322);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(223, 36);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnFileLoad
            // 
            this.btnFileLoad.Location = new System.Drawing.Point(195, 67);
            this.btnFileLoad.Name = "btnFileLoad";
            this.btnFileLoad.Size = new System.Drawing.Size(102, 32);
            this.btnFileLoad.TabIndex = 2;
            this.btnFileLoad.Text = "Load archive";
            this.btnFileLoad.UseVisualStyleBackColor = true;
            this.btnFileLoad.Click += new System.EventHandler(this.btnFileLoad_Click);
            // 
            // tbFilePath
            // 
            this.tbFilePath.Location = new System.Drawing.Point(12, 41);
            this.tbFilePath.Name = "tbFilePath";
            this.tbFilePath.Size = new System.Drawing.Size(287, 20);
            this.tbFilePath.TabIndex = 4;
            // 
            // brTotalProgress
            // 
            this.brTotalProgress.Location = new System.Drawing.Point(12, 375);
            this.brTotalProgress.Name = "brTotalProgress";
            this.brTotalProgress.Size = new System.Drawing.Size(603, 23);
            this.brTotalProgress.TabIndex = 5;
            // 
            // lbFilePath
            // 
            this.lbFilePath.AutoSize = true;
            this.lbFilePath.Location = new System.Drawing.Point(13, 16);
            this.lbFilePath.Name = "lbFilePath";
            this.lbFilePath.Size = new System.Drawing.Size(84, 13);
            this.lbFilePath.TabIndex = 6;
            this.lbFilePath.Text = "Choose archive:";
            // 
            // lstFormsLog
            // 
            this.lstFormsLog.Location = new System.Drawing.Point(305, 41);
            this.lstFormsLog.Multiline = true;
            this.lstFormsLog.Name = "lstFormsLog";
            this.lstFormsLog.Size = new System.Drawing.Size(311, 317);
            this.lstFormsLog.TabIndex = 7;
            // 
            // tbFindPass
            // 
            this.tbFindPass.Enabled = false;
            this.tbFindPass.Location = new System.Drawing.Point(305, 410);
            this.tbFindPass.Name = "tbFindPass";
            this.tbFindPass.Size = new System.Drawing.Size(310, 20);
            this.tbFindPass.TabIndex = 8;
            // 
            // lbCurpass
            // 
            this.lbCurpass.AutoSize = true;
            this.lbCurpass.Location = new System.Drawing.Point(219, 413);
            this.lbCurpass.Name = "lbCurpass";
            this.lbCurpass.Size = new System.Drawing.Size(78, 13);
            this.lbCurpass.TabIndex = 9;
            this.lbCurpass.Text = "Password was:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Min length";
            // 
            // tbMinLength
            // 
            this.tbMinLength.Location = new System.Drawing.Point(13, 195);
            this.tbMinLength.Name = "tbMinLength";
            this.tbMinLength.Size = new System.Drawing.Size(56, 20);
            this.tbMinLength.TabIndex = 11;
            this.tbMinLength.Text = "1";
            // 
            // tbMaxLength
            // 
            this.tbMaxLength.Location = new System.Drawing.Point(94, 195);
            this.tbMaxLength.Name = "tbMaxLength";
            this.tbMaxLength.Size = new System.Drawing.Size(56, 20);
            this.tbMaxLength.TabIndex = 13;
            this.tbMaxLength.Text = "3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Max length";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "-";
            // 
            // chbDigits
            // 
            this.chbDigits.AutoSize = true;
            this.chbDigits.Checked = true;
            this.chbDigits.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbDigits.Location = new System.Drawing.Point(13, 226);
            this.chbDigits.Name = "chbDigits";
            this.chbDigits.Size = new System.Drawing.Size(76, 17);
            this.chbDigits.TabIndex = 18;
            this.chbDigits.Text = "Digits [0-9]";
            this.chbDigits.UseVisualStyleBackColor = true;
            // 
            // chbUpLeter
            // 
            this.chbUpLeter.AutoSize = true;
            this.chbUpLeter.Location = new System.Drawing.Point(13, 249);
            this.chbUpLeter.Name = "chbUpLeter";
            this.chbUpLeter.Size = new System.Drawing.Size(112, 17);
            this.chbUpLeter.TabIndex = 19;
            this.chbUpLeter.Text = "Upper letters [A-Z]";
            this.chbUpLeter.UseVisualStyleBackColor = true;
            this.chbUpLeter.CheckedChanged += new System.EventHandler(this.chbUpLeter_CheckedChanged);
            // 
            // chbLowLeter
            // 
            this.chbLowLeter.AutoSize = true;
            this.chbLowLeter.Location = new System.Drawing.Point(13, 272);
            this.chbLowLeter.Name = "chbLowLeter";
            this.chbLowLeter.Size = new System.Drawing.Size(109, 17);
            this.chbLowLeter.TabIndex = 20;
            this.chbLowLeter.Text = "Lower letters [a-z]";
            this.chbLowLeter.UseVisualStyleBackColor = true;
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(513, 3);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(102, 32);
            this.btnClearAll.TabIndex = 21;
            this.btnClearAll.Text = "Clear all";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // tbTotalTime
            // 
            this.tbTotalTime.Enabled = false;
            this.tbTotalTime.Location = new System.Drawing.Point(12, 117);
            this.tbTotalTime.Name = "tbTotalTime";
            this.tbTotalTime.Size = new System.Drawing.Size(69, 20);
            this.tbTotalTime.TabIndex = 22;
            // 
            // lbTotalTime
            // 
            this.lbTotalTime.AutoSize = true;
            this.lbTotalTime.Location = new System.Drawing.Point(9, 101);
            this.lbTotalTime.Name = "lbTotalTime";
            this.lbTotalTime.Size = new System.Drawing.Size(70, 13);
            this.lbTotalTime.TabIndex = 23;
            this.lbTotalTime.Text = "Time passed:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 413);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Speed:";
            // 
            // lbSpeed
            // 
            this.lbSpeed.AutoSize = true;
            this.lbSpeed.Location = new System.Drawing.Point(60, 413);
            this.lbSpeed.Name = "lbSpeed";
            this.lbSpeed.Size = new System.Drawing.Size(0, 13);
            this.lbSpeed.TabIndex = 25;
            // 
            // tbExpectedTime
            // 
            this.tbExpectedTime.Enabled = false;
            this.tbExpectedTime.Location = new System.Drawing.Point(94, 117);
            this.tbExpectedTime.Name = "tbExpectedTime";
            this.tbExpectedTime.Size = new System.Drawing.Size(74, 20);
            this.tbExpectedTime.TabIndex = 26;
            // 
            // lbExpectedTime
            // 
            this.lbExpectedTime.AutoSize = true;
            this.lbExpectedTime.Location = new System.Drawing.Point(91, 101);
            this.lbExpectedTime.Name = "lbExpectedTime";
            this.lbExpectedTime.Size = new System.Drawing.Size(77, 13);
            this.lbExpectedTime.TabIndex = 27;
            this.lbExpectedTime.Text = "Expected time:";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(386, 3);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(102, 32);
            this.btnStop.TabIndex = 28;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // chbSpecSymb
            // 
            this.chbSpecSymb.AutoSize = true;
            this.chbSpecSymb.Location = new System.Drawing.Point(12, 295);
            this.chbSpecSymb.Name = "chbSpecSymb";
            this.chbSpecSymb.Size = new System.Drawing.Size(101, 17);
            this.chbSpecSymb.TabIndex = 29;
            this.chbSpecSymb.Text = "Special symbols";
            this.chbSpecSymb.UseVisualStyleBackColor = true;
            // 
            // tbox11
            // 
            this.tbox11.Enabled = false;
            this.tbox11.Location = new System.Drawing.Point(195, 117);
            this.tbox11.Name = "tbox11";
            this.tbox11.Size = new System.Drawing.Size(74, 20);
            this.tbox11.TabIndex = 30;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 435);
            this.Controls.Add(this.tbox11);
            this.Controls.Add(this.chbSpecSymb);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lbExpectedTime);
            this.Controls.Add(this.tbExpectedTime);
            this.Controls.Add(this.lbSpeed);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbTotalTime);
            this.Controls.Add(this.tbTotalTime);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.chbLowLeter);
            this.Controls.Add(this.chbUpLeter);
            this.Controls.Add(this.chbDigits);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbMaxLength);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbMinLength);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbCurpass);
            this.Controls.Add(this.tbFindPass);
            this.Controls.Add(this.lstFormsLog);
            this.Controls.Add(this.lbFilePath);
            this.Controls.Add(this.brTotalProgress);
            this.Controls.Add(this.tbFilePath);
            this.Controls.Add(this.btnFileLoad);
            this.Controls.Add(this.btnRun);
            this.Name = "Form1";
            this.Text = "RarUnlocker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openArchDialog;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnFileLoad;
        private System.Windows.Forms.TextBox tbFilePath;
        private System.Windows.Forms.ProgressBar brTotalProgress;
        private System.Windows.Forms.Label lbFilePath;
        private System.Windows.Forms.TextBox lstFormsLog;
        private System.Windows.Forms.TextBox tbFindPass;
        private System.Windows.Forms.Label lbCurpass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMinLength;
        private System.Windows.Forms.TextBox tbMaxLength;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chbDigits;
        private System.Windows.Forms.CheckBox chbUpLeter;
        private System.Windows.Forms.CheckBox chbLowLeter;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.TextBox tbTotalTime;
        private System.Windows.Forms.Label lbTotalTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbSpeed;
        private System.Windows.Forms.TextBox tbExpectedTime;
        private System.Windows.Forms.Label lbExpectedTime;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.CheckBox chbSpecSymb;
        private System.Windows.Forms.TextBox tbox11;
    }
}

