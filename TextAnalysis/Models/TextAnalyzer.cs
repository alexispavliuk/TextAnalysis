using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextAnalysis.Models
{
    /// <summary>
    /// static class that contains different methods for text analysis
    /// </summary>
    public static class TextAnalyzer
    {
        /// <summary>
        /// get count of words in text
        /// </summary>
        /// <param name="text">text to analyze</param>
        /// <returns>number of words</returns>
        public static int GetWordsCount(string text)
        {
            return text.Split(" ").Length;
        }

        /// <summary>
        /// get list of unique chars in text
        /// </summary>
        /// <param name="text">text to analyze</param>
        /// <returns>List of chars</returns>
        public static List<char> GetListOfChars(string text)
        {
            List<char> result = new List<char>();
            foreach (char symbol in text)
            {
                if (!result.Contains(symbol) && new Regex(@"\S").IsMatch(symbol.ToString()))
                    result.Add(symbol);
            }
            return result;
        }

        /// <summary>
        /// get count of sentences in text
        /// </summary>
        /// <param name="text">text to analyze</param>
        /// <returns>number of sentences</returns>
        public static int GetSentencesCount(string text)
        {
            Regex regex = new Regex(@"\w+[.?!]\w+");
            return regex.Matches(text).Count + 1;
        }

        /// <summary>
        /// get the most common char in text
        /// </summary>
        /// <param name="text">text to analyze</param>
        /// <returns>the most common char</returns>
        public static string GetMostCommonChar(string text)
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
            return $"{result} : {max}";
        }
    }
}
