using Mastrosoft.CloudConvert.Models.Tasks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mastrosoft.CloudConvert.Models
{
    public class ConvertTaskResponse
    {
        public DataResponse<ConvertTask> Data { get; set; }
    }

    public class OptimizeTaskResponse
    {
        public DataResponse<OptimizeTask> Data { get; set; }
    }
    public class CaptureWebsiteResponse
    {
        public DataResponse<OptimizeTask> Data { get; set; }
    }

    public class Response<T>
    {
        public DataResponse<T> Data { get; set; }
    }
    public class JobResponse
    {
        public JobDataResponse Data { get; set; }
    }

    public class CaptureWebsite : TaskBase
    {
        public Uri Url { get; set; }
        public string OutputFormat { get; set; }

        public override string Operation => "capture-website";
    }

}

