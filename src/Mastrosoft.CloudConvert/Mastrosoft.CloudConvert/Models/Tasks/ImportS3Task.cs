namespace Mastrosoft.CloudConvert.Models.Tasks
{
    public class ImportS3Task : TaskBase
    {
        public override string Operation => "import/s3";
        public string AccessKeyId { get; set; }
        public string SecretAccessKey { get; set; }
        public string Bucket { get; set; }
        public string Region { get; set; }
        public string Key { get; set; }
        public string Endpoint { get; set; }
        public string SessionToken { get; set; }
        public string Filename { get; set; }
    }
}

