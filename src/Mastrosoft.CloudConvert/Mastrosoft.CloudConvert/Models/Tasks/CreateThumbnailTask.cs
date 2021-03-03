namespace Mastrosoft.CloudConvert.Models.Tasks
{
    public class CreateThumbnailTask : TaskBase
    {
        public string Input { get; set; }
        public string InputFormat { get; set; }
        public string OutputFormat { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Fit { get; set; }
        public int? Count { get; set; }
        public string Filename { get; set; }
        public string Engine { get; set; }
        public string EngineVersion { get; set; }
        public int Timeout { get; set; } = 60 * 60 * 5;

        public override string Operation => "thumbnail";
    }
}

