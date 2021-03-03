namespace Mastrosoft.CloudConvert.Models.Tasks
{
    public class ExportS3Task : TaskBase
    {
        public override string Operation => "export/s3";
        public string Id { get; set; }
        public string AccessKeyId { get; set; }
        public string SecretAccessKey { get; set; }
        public string Bucket { get; set; }
        public string Region { get; set; }
        public string Key { get; set; }
        public string Endpoint { get; set; }
        public string SessionToken { get; set; }
        public string Acl { get; set; }
        public string CacheControl { get; set; }
        public string Metadata { get; set; }
        public string ServerSideEncryption { get; set; }
    }
}

