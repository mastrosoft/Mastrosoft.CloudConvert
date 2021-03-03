using System;
using System.Collections.Generic;

namespace Mastrosoft.CloudConvert.Models.Tasks
{
    public class ImportUrlTask : TaskBase
    {
        public override string Operation => "import/url";
        public Uri Url { get; set; }
        public string Filename { get; set; }
        public Dictionary<string,string> Headers { get; set; }

    }
}

