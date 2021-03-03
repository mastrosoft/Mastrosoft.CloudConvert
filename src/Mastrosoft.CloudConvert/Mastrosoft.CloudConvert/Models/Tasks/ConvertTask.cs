using System;
using System.Collections.Generic;
using System.Linq;

namespace Mastrosoft.CloudConvert.Models.Tasks
{
    public class ConvertTask : TaskBase
    {
        public string Input { get; set; }
        public string InputFormat { get; set; }
        public string OutputFormat { get; set; }
        public string Pages { get; set; }
        public bool OptimizePrint { get; set; }
        public override string Operation => "convert";
        public string FileName { get; set; }
        public int? Timeout { get; set; } = 60 * 60 * 5;// default 5 hours (exactly like on cloudconvert)
        public string Password { get; set; }
        public string Encryption { get; set; }
    }
}

