using Mastrosoft.CloudConvert.Models.Tasks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mastrosoft.CloudConvert.Models
{
    public class CreateJob
    {
        public Dictionary<string, object> Tasks { get; set; } = new System.Collections.Generic.Dictionary<string, object>();
        public string Tag { get; set; }
    }
}
