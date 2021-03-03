using System;
using System.Collections.Generic;
using System.Text;

namespace Mastrosoft.CloudConvert.Models.Tasks
{
    public abstract class TaskBase
    {
        public abstract string Operation { get; }
        internal virtual string Method { get; } = "POST";
    }
}
