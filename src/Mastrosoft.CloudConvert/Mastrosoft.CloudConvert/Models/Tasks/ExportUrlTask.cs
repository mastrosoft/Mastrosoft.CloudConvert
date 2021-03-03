namespace Mastrosoft.CloudConvert.Models.Tasks
{
    public class ExportUrlTask : TaskBase
    {
        public override string Operation => "export/url";
        public string Input { get; set; }
        public bool ArchiveMultipleFiles { get; set; }
        public bool Inline { get; set; }
    }
}

