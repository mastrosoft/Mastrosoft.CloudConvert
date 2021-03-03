using System;

namespace Mastrosoft.CloudConvert.Models.Tasks
{
    public class ImportUploadTask : TaskBase
    {
        public override string Operation => "import/upload";
        public Uri Redirect { get; set; }
    }
}

