namespace Mastrosoft.CloudConvert.Models.Tasks
{
    public class ImportAzureBlobTask : TaskBase
    {
        public override string Operation => "import/azure/blob";
        public string StorageAccount { get; set; }
        public string StorageAccessKey { get; set; }
        public string SasToken { get; set; }
        public string Container { get; set; }
        public string Blob { get; set; }
        public string BlobPrefix { get; set; }
        public string Filename { get; set; }
    }
}

