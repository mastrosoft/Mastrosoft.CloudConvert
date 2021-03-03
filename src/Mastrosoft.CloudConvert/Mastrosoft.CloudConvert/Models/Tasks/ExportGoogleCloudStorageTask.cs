namespace Mastrosoft.CloudConvert.Models.Tasks
{
    public class ExportGoogleCloudStorageTask : TaskBase
    {
        public override string Operation => "export/google-cloud-storage";
        public string ProjectId { get; set; }
        public string Bucket { get; set; }
        public string ClientEmail { get; set; }
        public string PrivateKey { get; set; }
        public string File { get; set; }
        public string FilePrefix { get; set; }
    }
}

