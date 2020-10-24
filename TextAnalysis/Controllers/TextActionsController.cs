using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TextAnalysis.Models;

namespace TextAnalysis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextActionsController : ControllerBase
    {
        /// <summary>
        /// This method allows to get result of analysis
        /// </summary>
        /// <param name="text">text to analyze</param>
        /// <param name="optionName">name of operation</param>
        /// <returns>Json result object</returns>
        [HttpPost]
        public JsonResult GetAnalysisResult(string text, string optionName)
        {
            object result = AnalysisOption.GetAnalysisMethod(optionName).Invoke(null, new object[] { text });

            return result != null ? new JsonResult(result) : new JsonResult("Operation was not found");
        }
    }
}
