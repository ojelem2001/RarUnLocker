using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using WinRar_unlocker;

namespace GUI
{
    public partial class Form1 : Form
    {
        private WinRarUnLocker WinRarUnLocker;
        private delegate void SetTextCallback(string Message);

        private string archFileName;
        private string outputFolder;
        private int _curPositionPass;
        private int prevPositionPass;
        private int passGenLength;
        private TimeSpan timeCounter;
        private DateTime initial_time;
        private ManualResetEvent stopWorkEvent;
        

        public Form1()
        {
            string specCharsString;
            InitializeComponent();

            //get spec chars for label
            WinRarUnLocker = new WinRarUnLocker(out specCharsString);

            chbSpecSymb.Text += string.Concat("[", specCharsString, "]");

            WinRarUnLocker.OnSomthingChanged += LogIt;

            openArchDialog.Filter = "Rar Files *.rar |*.rar"; 
        }
 
        private void SetText(string Message)
        {
 
            if (lstFormsLog.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                Invoke(d, new object[] { Message });
            }
            else
            {
                lstFormsLog.Text += Message;
            }
        }
        private void LogIt(object sender, string e)
        {
            SetText(string.Concat(e, "\r\n"));
        }
        private void btnFileLoad_Click(object sender, EventArgs e)
        {
            if (openArchDialog.ShowDialog() == DialogResult.Cancel)
                return;    
            archFileName = openArchDialog.FileName;
            //string archFileText = System.IO.File.ReadAllText(filename);
            tbFilePath.Text = archFileName;
            LogIt(this, string.Format("File {0} open", archFileName));
        }


        private void btnClearAll_Click(object sender, EventArgs e)
        {
            lstFormsLog.Text = "";
        }
        private async void btnRun_Click(object sender, EventArgs e)
        {
            btnClearAll_Click(this, new EventArgs());

            if (string.IsNullOrEmpty(tbFilePath.Text))
            {
                SetText("File path is null");                
                return;
            } 

            btnRun.Enabled = false;
            StartSearch();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
           FinishSearch();
        }

        public async void StartSearch()
        {
            brTotalProgress.Value = brTotalProgress.Minimum;
            StartTimeCounter();

            var curPositionPassProgress = new Progress<int>(s => _curPositionPass = s);
            var progress = new Progress<int>(s => brTotalProgress.Value = s);
            var result = new Progress<string>(s => tbFindPass.Text = s);
            var c = new Progress<string>(s => tbFindPass.Text = s);

            passGenLength = WinRarUnLocker.Initialize(
                archFileName,
                int.Parse(tbMinLength.Text),
                int.Parse(tbMaxLength.Text),
                chbDigits.Checked,
                chbUpLeter.Checked,
                chbLowLeter.Checked,
                chbSpecSymb.Checked,
                progress,
                curPositionPassProgress);
            brTotalProgress.Maximum = passGenLength;
            
            await WinRarUnLocker.PickUpPassword(archFileName, result);

            FinishSearch();
        }

        public void FinishSearch()
        {
            brTotalProgress.Value = brTotalProgress.Maximum;
            DeInitializeTimeCount();

            btnRun.Enabled = true;
        }

        private async void StartTimeCounter()
        {
            var timeProgress = new Progress<string>(s => tbTotalTime.Text = s);
            var speedProgress = new Progress<string>(s => lbSpeed.Text = s);
            var timeExpetedProgress = new Progress<string>(s => tbExpectedTime.Text = s);

            await Task.Run(() => InitializeTimeCount(timeProgress, speedProgress, timeExpetedProgress));
        }
        public void InitializeTimeCount(IProgress<string> timeProgress, IProgress<string> speedProgress, IProgress<string> timeExpectedProgress)
        {
            string timeTick;
            int curSpeed;
            string curSpeedString;
            int expectedTime;
            string expectedTimeString = "";

            stopWorkEvent = new ManualResetEvent(false);
            
            initial_time = DateTime.Now;
             
            do
            {
                //time 
                timeCounter = DateTime.Now - initial_time;
                timeTick = timeCounter.Hours.ToString("D2") + ":" + timeCounter.Minutes.ToString("D2") + ":" + timeCounter.Seconds.ToString("D2");
                timeProgress.Report(timeTick);

                //speed
                curSpeed = _curPositionPass - prevPositionPass;
                prevPositionPass = _curPositionPass;
                curSpeedString = curSpeed + " Pass/Sec";
                speedProgress.Report(curSpeedString);

                //expectedTime
                if (curSpeed > 0)
                {
                    expectedTime = (passGenLength / curSpeed);
                    expectedTimeString = TimeSpan.FromSeconds(expectedTime).ToString();
                }
                timeExpectedProgress.Report(expectedTimeString);

            }
            while (WaitHandle.WaitAny(new WaitHandle[] { stopWorkEvent }, 1000) != 0);

            //  return timeTick;
        }
        public void DeInitializeTimeCount()
        {
            stopWorkEvent.Set();
        }

        private void chbUpLeter_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
