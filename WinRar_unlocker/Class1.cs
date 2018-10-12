using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinRar_unlocker
{
    public class CaseAlternatorTask
    {
        public static List<string> AlternateCharCases(string lowercaseWord)
        {
            var result = new List<string>();
            AlternateCharCases(lowercaseWord.ToCharArray(), 0, result);
            return result;
        }

        static void AlternateCharCases(char[] word, int startIndex, List<string> result)
        {
            bool[] helper = new bool[word.Length];
            Solver(word, startIndex, result);
        }

        static void Solver(char[] word, int startIndex, List<string> result)
        {
            var subWord = word.ToArray();
            if (startIndex == word.Length)
            {
                result.Add(new string(word));
                return;
            }

            var lower = char.ToLower(word[startIndex]);
            var upper = char.ToUpper(word[startIndex]);
            word[startIndex] = lower;
            Solver(word, startIndex + 1, result);
            if (lower != upper)
            {
                word[startIndex] = upper;
                Solver(word, startIndex + 1, result);
            }
        }

        static List<string> DelTheSame(List<string> result)
        {
            for (int i = 0; i < result.ToArray().Length; i++)
            {
                for (int j = i + 1; j < result.ToArray().Length; j++)
                {
                    if (result[i] == result[j])
                    {
                        result.RemoveAt(j);
                    }
                    else continue;
                }
            }
            return result;
        }
    }
}
