using System;
using System.Collections.Generic;
using System.Text;

namespace Mastrosoft.CloudConvert.Models.Tasks
{
    public class MergeTask : TaskBase
    {
        public override string Operation => "merge";
        public string[] Input { get; set; }
        public string OutputFormat { get; set; }
    }
}
