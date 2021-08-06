namespace Mastrosoft.CloudConvert.Models.Tasks
{
    public class ExportAzureBlobTask : TaskBase
    {
        public string Input { get; set; }
        public override string Operation => "export/azure/blob";
        public string StorageAccount { get; set; }
        public string StorageAccessKey { get; set; }
        public string SasToken { get; set; }
        public string Container { get; set; }
        public string Blob { get; set; }
        public string BlobPrefix { get; set; }
        public object Metadata { get; set; }
    }
}

