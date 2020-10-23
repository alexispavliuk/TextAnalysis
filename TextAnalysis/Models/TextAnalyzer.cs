using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextAnalysis.Models
{
    public static class TextAnalyzer
    {
        public static int GetWordsCount(string text)
        {
            return text.Split(" ").Length;
        }
        public static List<char> GetListOfChars(string text)
        {
            List<char> result = new List<char>();
            foreach (char symbol in text)
            {
                if (!result.Contains(symbol))
                    result.Add(symbol);
            }
            return result;
        }
        public static int GetSentencesCount(string text)
        {
            Regex regex = new Regex(@"\w+[.?!]");
            return regex.Matches(text).Count;
        }
        public static (char, int) GetMostCommonChar(string text)
        {
            int max = 0;
            char result = '\0';
            foreach (char symbol in GetListOfChars(text))
            {
                Regex regex = new Regex($"{symbol}");
                int symbolCount = regex.Matches(text).Count;
                if (symbolCount > max)
                {
                    max = symbolCount;
                    result = symbol;
                } 
            }
            return (result, max);
        }
    }
}
