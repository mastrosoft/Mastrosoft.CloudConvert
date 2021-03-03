using System;

namespace Mastrosoft.CloudConvert.Models.Tasks
{
    public class CreateWebhookTask : TaskBase
    {
        public override string Operation => "webhooks";
        public Uri Url { get; set; }
        /// <summary>
        /// Gets or sets the events.
        /// </summary>
        /// <remarks>Supported events: job.created, job.finished, job.failed</remarks>
        /// <value>
        /// The events.
        /// </value>
        public string[] Events { get; set; }
    }
}

