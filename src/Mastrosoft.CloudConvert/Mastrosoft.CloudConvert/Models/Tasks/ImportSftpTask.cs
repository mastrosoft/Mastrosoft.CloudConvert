namespace Mastrosoft.CloudConvert.Models.Tasks
{
    public class ImportSftpTask : TaskBase
    {
        public override string Operation => "import/sftp";
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PrivateKey { get; set; }
        public string File { get; set; }
        public string Path { get; set; }
        public string Filename { get; set; }
    }

}

