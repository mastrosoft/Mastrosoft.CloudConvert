using System;

namespace Mastrosoft.CloudConvert.Models.Tasks
{
    public class OptimizeTask : TaskBase
    {
        public string Input { get; set; }
        public string InputFormat { get; set; }
        public string Profile { get; set; }
        public override string Operation => "optimize";
    }

}

