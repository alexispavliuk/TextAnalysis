using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace TextAnalysis.Models
{
    public static class AnalysisOption
    {
        /// <summary>
        /// this method allows to get correct option for analysis using reflection
        /// </summary>
        /// <param name="methodName"></param>
        /// <returns>MethodInfo</returns>
        public static MethodInfo GetAnalysisMethod(string methodName)
        {
            return typeof(TextAnalyzer).GetMethod(methodName);
        }
    }
}
