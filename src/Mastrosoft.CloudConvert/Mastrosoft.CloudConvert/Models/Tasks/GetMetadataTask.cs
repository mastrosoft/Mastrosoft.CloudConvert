namespace Mastrosoft.CloudConvert.Models.Tasks
{
    public class GetMetadataTask : TaskBase
    {
        public string Input { get; set; }
        public string InputFormat { get; set; }
        public string Engine { get; set; }
        public string EngineVersion { get; set; }
        public int Timeout { get; set; } = 60 * 60 * 5;
        public override string Operation => "metadata";
    }
}

