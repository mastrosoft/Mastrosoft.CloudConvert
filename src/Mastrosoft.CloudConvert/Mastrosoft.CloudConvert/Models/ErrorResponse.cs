using System;
using System.Collections.Generic;
using System.Text;

namespace Mastrosoft.CloudConvert.Models
{
    public class ErrorResponse
    {
        public string Message { get; set; }
        public string Code { get; set; }
        public Dictionary<string,string[]> Errors { get; set; }
    }
}
