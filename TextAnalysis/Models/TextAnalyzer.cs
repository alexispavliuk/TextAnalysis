using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Amazon;
using Amazon.Comprehend;
using Amazon.Comprehend.Model;
using Amazon.Runtime;

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

        /// <summary>
        /// detect language of the text
        /// </summary>
        /// <param name="text">text to analyze</param>
        /// <returns>code of language</returns>
        public static string DetectLanguage(string text)
        {
            BasicAWSCredentials credentials =
                new BasicAWSCredentials("there should be secret id", "there should be secret key");
            AmazonComprehendClient amazonComprehendClient =
                new AmazonComprehendClient(credentials, RegionEndpoint.EUCentral1);

            DetectDominantLanguageRequest detectLanguageRequest = new DetectDominantLanguageRequest();
            detectLanguageRequest.Text = text;

            Task<DetectDominantLanguageResponse> lang =
                amazonComprehendClient.DetectDominantLanguageAsync(detectLanguageRequest);

            return lang.Result.Languages[0].LanguageCode;
        }

        /// <summary>
        /// get emotionality of the text
        /// </summary>
        /// <param name="text">text to analyze</param>
        /// <returns>string with results</returns>
        public static string GetEmotionality(string text)
        {
            string language = DetectLanguage(text);
            

            BasicAWSCredentials credentials =
                new BasicAWSCredentials("AKIAI4LCT7IIROLBGKWQ", "XS6xmKZpQVnRXkyAoG7K63PPe4ocoE+PQt2HGPQ/");
            AmazonComprehendClient amazonComprehendClient =
                new AmazonComprehendClient(credentials, RegionEndpoint.EUCentral1);

            DetectSentimentRequest detectSentimenteRequest = new DetectSentimentRequest();
            detectSentimenteRequest.Text = text;

            try
            {
                detectSentimenteRequest.LanguageCode = language;
                Task<DetectSentimentResponse> result =
                amazonComprehendClient.DetectSentimentAsync(detectSentimenteRequest);
                return $"Mixed:{String.Format("{0:f2}", result.Result.SentimentScore.Mixed)}\n" +
                       $"Positive:{String.Format("{0:f2}", result.Result.SentimentScore.Positive)}\n" +
                       $"Neutral:{String.Format("{0:f2}", result.Result.SentimentScore.Neutral)}\n" +
                       $"Negative:{String.Format("{0:f2}", result.Result.SentimentScore.Negative)}";
            }
            catch (Exception)
            {
                return "Language of your text is not supported yet";
            }
        }
    }
}
