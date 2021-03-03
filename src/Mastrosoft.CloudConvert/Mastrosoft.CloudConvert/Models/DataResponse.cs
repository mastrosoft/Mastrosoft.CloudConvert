using Mastrosoft.CloudConvert.Models.Tasks;
using System;
using System.Collections.Generic;

namespace Mastrosoft.CloudConvert.Models
{
    public class DataResponse<T>
    {
        public string Id { get; set; }
        public string Operation { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }
        public Dictionary<string,string> DependsOnTasks { get; set; }
        public string Engine { get; set; }
        public string EngineVersion { get; set; }
        public T Payload { get; set; }
        public object Result { get; set; }
    }
    public class JobDataResponse
    {
        public string Id { get; set; }

        public string Status { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }
        public List<object> Tasks { get; set; }
    }
}

