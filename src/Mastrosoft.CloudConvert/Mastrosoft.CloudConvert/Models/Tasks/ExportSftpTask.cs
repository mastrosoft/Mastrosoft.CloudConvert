namespace Mastrosoft.CloudConvert.Models.Tasks
{
    public class ExportSftpTask : TaskBase
    {
        public string Input { get; set; }
        public override string Operation => "export/sftp";
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PrivateKey { get; set; }
        public string File { get; set; }
        public string Path { get; set; }
    }

}

