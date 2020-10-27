using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TextAnalysis.Models;

namespace TextAnalysis.Controllers
{
    [Route("api/TextActions")]
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
        public object GetAnalysisResult([FromBody]RequestData data)
        {
            object result = AnalysisOption.GetAnalysisMethod(data.nameMethod).Invoke(null, new object[] { data.Text });

            return result ?? "Operation was not found";
        }
    }
}
