using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TextAnalysis.Models
{
    public class RequestData
    {
        [Required]
        public string Text { get; set; }
        [Required]
        public string nameMethod { get; set; }
    }
}
