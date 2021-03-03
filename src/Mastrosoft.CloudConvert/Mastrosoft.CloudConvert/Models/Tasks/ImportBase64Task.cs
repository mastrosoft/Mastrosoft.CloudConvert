namespace Mastrosoft.CloudConvert.Models.Tasks
{
    public class ImportBase64Task : TaskBase
    {
        public override string Operation => "import/base64";
        public string File { get; set; }
        public string Filename { get; set; }
    }
}

