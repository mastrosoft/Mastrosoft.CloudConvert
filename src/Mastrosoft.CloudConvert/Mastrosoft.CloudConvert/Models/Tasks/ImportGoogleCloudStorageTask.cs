namespace Mastrosoft.CloudConvert.Models.Tasks
{
    public class ImportGoogleCloudStorageTask : TaskBase
    {
        public string Input { get; set; }
        public override string Operation => "import/google-cloud-storage";
        public string ProjectId { get; set; }
        public string Bucket { get; set; }
        public string ClientEmail { get; set; }
        public string PrivateKey { get; set; }
        public string File { get; set; }
        public string FilePrefix { get; set; }
        public string Filename { get; set; }
    }
}

