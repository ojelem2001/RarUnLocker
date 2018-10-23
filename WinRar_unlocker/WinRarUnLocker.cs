using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinRar_unlocker
{
    public class WinRarUnLocker
    {
        private string passDict = "/Dict";
        private string _outputFolder;
        private int totalTries;
        private string unRarExe = @"C:\Program Files\WinRAR\UnRAR.exe";

        private List<char> alphabet;
        private List<char> englishUpperChars;
        private List<char> englishLowerChars;
        private List<char> specChars;
        private List<char> numbersChars;
        private IProgress<string> _result;
        private List<string> passGenArray;

        public delegate void EventLogHandler(object sender, string e);
        public event EventLogHandler OnSomthingChanged;
        private IProgress<int> _totalProgress;
        private IProgress<int> _curPositionPassProgress;
        private CancellationTokenSource cancelTokenSource;

        public WinRarUnLocker(out string specCharsString)
        {            
            CreateAlphbet(out specCharsString);
        }

        public int Initialize(string archFileName, int minLength, int maxLength, bool isNeedDigits, bool isNeedUpLetters, bool isNeedLowLetters, bool isNeeedSpecSymb, IProgress<int> totalProgress, IProgress<int> curPositionPassProgress)
        {

            _outputFolder = Path.GetDirectoryName(archFileName);
            _curPositionPassProgress = curPositionPassProgress;
            _totalProgress = totalProgress;

            LogIt("Generating alphbet");
            GenerateAlphbet(isNeedDigits, isNeedUpLetters, isNeedLowLetters, isNeeedSpecSymb);

            //Calculate count of operations
            var t = 0;
            for (int i = minLength; i <= maxLength; i++)
                t = t * alphabet.Count() + alphabet.Count();

            LogIt("Total passwords: " + t);
            
            LogIt("Generating dictionary");
            GenerateHashArray(minLength, maxLength);
 
            LogIt("Load dictionary");
            LoadDicti();

            return t; 
        }
        public async Task<string> PickUpPassword(string archiveName, IProgress<string> result )
        {
            var tasks = new List<Task>();
            _result = result;
            cancelTokenSource = new CancellationTokenSource();

            for (int j = 0; j < passGenArray.Count-1; j++)
            {
                var SerialNumber = j + 1;
                var pass = passGenArray[j];
                tasks.Add(Task.Run(() => UnLock(archiveName, pass, _outputFolder, SerialNumber/*, token*/)));
            }            
            try
            {
                await Task.WhenAll(tasks);
                LogIt("Search completed");
            }
            catch (OperationCanceledException e)
            {
                LogIt("Failure - OperationCanceledException");
                Console.WriteLine(e.ToString());
            }
            
            return null;
        }

        private void UnLock(string fld, string pw, string outputfldr, int j/*, CancellationToken token*/)
        {
            
            if (cancelTokenSource.Token.IsCancellationRequested)
                return;

            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = unRarExe,
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
                {
                    LogIt(string.Format("Total steps {0} pass {1} ", j, pw));
                    _result.Report(pw);
                    cancelTokenSource.Cancel();
                    return;
                }
            }
            _curPositionPassProgress.Report(j);
            _totalProgress.Report(j);           
        }

        private void LogIt(string message)
        {
            OnSomthingChanged?.Invoke(this, message);
        }

        private void LoadDicti()
        {
          /*  using (StreamReader sr = new StreamReader(string.Concat(_outputFolder, passDict), System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    passGenArray.Add(line);
                }
            }*/
        }

        private void GenerateHashArray(int MinCount, int MaxCount)
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
                
                pass = prevPart + letter;
                if (iteration == maxIteration)
                    SavePassToDictionary(pass);
                else
                    RecursiceFunc(pass, iteration + 1, maxIteration);
            }
        }

        private void SavePassToDictionary(string pass)
        {
           /* using (StreamWriter sw = new StreamWriter(string.Concat(_outputFolder, passDict), true, System.Text.Encoding.Default))
            {
                sw.WriteLine(pass);
            }*/
            passGenArray.Add(pass);
        }
        private void CreateAlphbet(out string specCharsString )
        {
            
            englishUpperChars = new List<char>();
            englishLowerChars = new List<char>();
            numbersChars = new List<char>();
            specChars = new List<char>();
            specCharsString = null;

            for (int i = 65; i < 91; i++)
              englishUpperChars.Add((char)i);

            for (int i = 97; i < 122; i++)
              englishLowerChars.Add((char)i);            

            for (int i = 48; i < 58; i++)
                numbersChars.Add((char)i);
            
            foreach (char chr in new List<char> {
                (char)33, //!
                (char)35, //#
                (char)36, //$
                (char)37, //%
                (char)38, //&
                (char)58, //:
                (char)59, //;
                (char)63, //?
                (char)64 //@
            }) {             
              specChars.Add(chr);
              specCharsString += chr;
            }
        }
        private void GenerateAlphbet(bool isNeedDigits, bool isNeedUpLetters, bool isNeedLowLetters, bool isNeeedSpecSymb)
        {
            alphabet = new List<char>();
            
            if (isNeedUpLetters)
                alphabet = alphabet.Union(englishUpperChars).ToList();

            if (isNeedLowLetters)
                alphabet = alphabet.Union(englishLowerChars).ToList();

            if (isNeedDigits)
                alphabet = alphabet.Union(numbersChars).ToList();

            if (isNeeedSpecSymb)
                alphabet = alphabet.Union(specChars).ToList();
            //           alphabet = new List<char>().Union(numbersChars).Union(englishUpperChars).Union(englishLowerChars).Union(specChars).ToList();

        }
    }
}
