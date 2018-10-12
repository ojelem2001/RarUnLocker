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

namespace GUI
{
    public partial class Form1 : Form
    {
        private string archFileName;
        private string outputFolder;
        private int totalTries;
        private int curPositionPass;
        private int prevPositionPass;
        private List<char> alphabet;
        private List<string> passGenArray;
        private delegate void SetTextCallback(string Message);
        private TimeSpan timeCounter;
        private DateTime initial_time;
        private ManualResetEvent stopWorkEvent;

        public Form1()
        {
            InitializeComponent();
            openArchDialog.Filter = "Rar Files *.rar |*.rar"; 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void SetText(string Message)
        {
            Message = string.Concat(Message, "\r\n");
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
        private void btnFileLoad_Click(object sender, EventArgs e)
        {
            if (openArchDialog.ShowDialog() == DialogResult.Cancel)
                return;    
            archFileName = openArchDialog.FileName;
            //string archFileText = System.IO.File.ReadAllText(filename);
            tbFilePath.Text = archFileName;
            outputFolder = Path.GetDirectoryName(archFileName);
            SetText(string.Format("File {0} open", archFileName));
        }

        private bool UNLOCK(string fld, string pw, string outputfldr)
        {
            bool result = false;
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = @"C:\Program Files\WinRAR\UnRAR.exe",
                    Arguments = string.Format("x -o+ -p{0} {1} {2}", pw, fld, outputfldr),
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            proc.Start();
            while (!proc.StandardOutput.EndOfStream)
            {
                string lines = proc.StandardOutput.ReadLine();
                if (lines.Contains("All OK"))                    
                   result = true;
                
            }
            return result;
        }
        private async void PickUpPassword(string archiveName)
        {
            string pass=null;

            for (int j = 0; j < passGenArray.Count; j++)
            {
                curPositionPass = j;
                brTotalProgress.Value = j;
                bool result = await Task.Factory.StartNew<bool>(
                    () => UNLOCK(archiveName, passGenArray[j], outputFolder),
                    TaskCreationOptions.LongRunning);
                if (result)
                {
                    pass = passGenArray[j];
                    SetText(string.Format("Total steps {0} pass {1} ", j, pass));
                    FinishSuccessSearch(pass);
                    FinishSearch();
                    return; ;
                }
            }
            FinishSearch();
            SetText("Failure...");
        }


        private void btnRun_Click(object sender, EventArgs e)
        {
            btnClearAll_Click(this, new EventArgs());
            btnRun.Enabled = false;
            GenerateAlphbet(chbDigits.Checked,chbUpLeter.Checked, chbLowLeter.Checked);
            GenerateHashArray(Int32.Parse(tbMinLength.Text), Int32.Parse(tbMaxLength.Text),alphabet);
            SetText("Starting");
            brTotalProgress.Maximum = passGenArray.Count;
            SetText("Total passwords: " + passGenArray.Count);
 
            StartTimeCounter();
            PickUpPassword(archFileName); 
            
        }
        private void GenerateHashArray(int MinCount, int MaxCount, List<char> abc)
        {
            passGenArray = new List<string>();

            for (int c = MinCount; c <= MaxCount; c++)
            {
                RecursiceFunc(null, MinCount, c);
            }
        }
        private void RecursiceFunc(string prevPart, int iteration, int maxIteration)
        {
            string letter = null;
            string pass = null;

            for (int j = 0; j < alphabet.Count; j++)
            {
                letter = alphabet[j].ToString();
                pass = string.Concat(prevPart, letter);
                if (iteration == maxIteration)
                {
                    passGenArray.Add(pass);
                }
                else { 
                    RecursiceFunc(pass, iteration + 1, maxIteration);
                }
            }
        }
        private void GenerateAlphbet(bool isNeedDigits, bool isNeedUpLetters, bool isNeedLowLetters)
        {
            alphabet = new List<char>();
            if (isNeedUpLetters)
            {
                for (int i = 65; i < 91; i++)
                {
                    alphabet.Add((char)i);
                }
            }
            if (isNeedLowLetters)
            {
                for (int i = 97; i < 122; i++)
                {
                    alphabet.Add((char)i);
                }
            }
            if (isNeedDigits)
            {
                for (int i = 48; i < 58; i++)
                {
                    alphabet.Add((char)i);
                }
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
             lstFormsLog.Text = "";
        }
        
        private void FinishSuccessSearch(string pass)
        {
            brTotalProgress.Value = brTotalProgress.Maximum;
            tbCurpass.Text = pass;
            SetText("Success!");
            DeInitializeTimeCount();
        }
        private void FinishSearch()
        {
            btnRun.Enabled = true;
        }
        private async void StartTimeCounter()
        {
            var progress = new Progress<string>(s => tbTotalTime.Text = s);
            string result = await Task.Factory.StartNew<string>(
                () =>  InitializeTimeCount(progress),
                TaskCreationOptions.LongRunning);
            tbTotalTime.Text = result;
           // lbSpeed.Text = (curPositionPass - prevPositionPass).ToString();
         //   prevPositionPass = curPositionPass;
        }
        public string InitializeTimeCount(IProgress<string> progress)
        {
            stopWorkEvent = new ManualResetEvent(false);
            initial_time = DateTime.Now;
            string timeTick;


            do
            {
                timeTick = timer_Tick();
                progress.Report(timeTick);
            }
            while (WaitHandle.WaitAny(new WaitHandle[] { stopWorkEvent }, 1) != 0);

            return timeTick;
        }
        public void DeInitializeTimeCount()
        {
            stopWorkEvent.Set();
        }
        private string timer_Tick()
        {
            DateTime current_time = DateTime.Now;
            timeCounter = current_time - initial_time;
            return timeCounter.Hours.ToString("D2") + ":" + timeCounter.Minutes.ToString("D2") + ":" + timeCounter.Seconds.ToString("D2");
        } 
    }
}
