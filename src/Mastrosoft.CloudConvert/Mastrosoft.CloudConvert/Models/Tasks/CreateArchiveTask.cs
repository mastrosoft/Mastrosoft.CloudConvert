namespace Mastrosoft.CloudConvert.Models.Tasks
{
    public class CreateArchiveTask : TaskBase
    {
        public string Input { get; set; }
        public string OutputFormat { get; set; }
        public string Filename { get; set; }
        public string Engine { get; set; }
        public string EngineVersion { get; set; }
        public int Timeout { get; set; } = 60 * 60 * 5;

        public override string Operation => "thumbnail";
    }
}

