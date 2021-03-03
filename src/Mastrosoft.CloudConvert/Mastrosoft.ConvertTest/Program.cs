using System;
using System.Configuration;
using System.Threading.Tasks;
using Mastrosoft.CloudConvert;
using Mastrosoft.CloudConvert.Models.Tasks;
using Microsoft.Extensions.Configuration;

namespace Mastrosoft.ConvertTest
{
    class Program
    {
        private static string api_key = ConfigurationManager.AppSettings["API_KEY"];
        static void Main(string[] args)

        {
            IConfigurationBuilder builder = new ConfigurationBuilder();

                builder.AddUserSecrets(typeof(Program).Assembly,false);
            var dom = builder.Build();
            CloudConvertClient client = new CloudConvertClient(apiKey: dom["API_KEY"], sandbox: true);
            Task.Run(async () =>
            {
                var importResult = await client.CreateTask(new ImportUrlTask { Url = new Uri("http://www.africau.edu/images/default/sample.pdf") });
                var convertJob = await client.CreateTask(new ConvertTask
                {
                    Input = importResult.Id,
                    InputFormat = "pdf",
                    OptimizePrint = true,
                    OutputFormat = "pdf",
                    Pages = "1"
                });
                var outputResult = await client.CreateTask(new ExportUrlTask { Input = convertJob.Id });

                var createjob = new CloudConvert.Models.CreateJob
                {
                    Tag = "test_" + Guid.NewGuid(),
                    Tasks = new System.Collections.Generic.Dictionary<string, object>()
                };
                createjob.Tasks.Add(createjob.Tag + "_import_file", new ImportUrlTask { Url = new Uri("http://www.africau.edu/images/default/sample.pdf") });
                createjob.Tasks.Add(createjob.Tag + "_convert_file", new ConvertTask
                {
                    Input = importResult.Id,
                    InputFormat = "pdf",
                    OptimizePrint = true,
                    OutputFormat = "pdf",
                    Pages = "1-2"
                });
                createjob.Tasks.Add(createjob.Tag + "_export_urlconvert", new ExportUrlTask { Input = createjob.Tag + "_convert_file" });

                var result = await client.CreateJob(createjob);

                var mergejob = new CloudConvert.Models.CreateJob
                {
                    Tag = "test_" + Guid.NewGuid(),
                    
                };
                mergejob.Tasks.Add(mergejob.Tag+"_import_file", new ImportUrlTask { Url = new Uri("http://www.africau.edu/images/default/sample.pdf") });
                mergejob.Tasks.Add(mergejob.Tag + "_import_file2", new ImportUrlTask { Url = new Uri("https://www.w3.org/WAI/ER/tests/xhtml/testfiles/resources/pdf/dummy.pdf") });
                mergejob.Tasks.Add(mergejob.Tag + "_mergefiles", new MergeTask
                {
                    Input = new[] { mergejob.Tag+"_import_file", mergejob.Tag+"_import_file2" },
                    OutputFormat="pdf"
                });
                mergejob.Tasks.Add(mergejob.Tag + "_export_urlmerge", new ExportUrlTask { Input = mergejob.Tag + "_mergefiles" });
                var resultMerge = await client.CreateJob(mergejob);
            }).Wait();
            
        }
    }
}
