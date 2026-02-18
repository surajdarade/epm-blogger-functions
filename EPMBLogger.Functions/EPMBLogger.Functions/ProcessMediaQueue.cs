using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace EPMBlogger.Functions {
    public class ProcessMediaQueue {
        private readonly ILogger<ProcessMediaQueue> _logger;

        public ProcessMediaQueue(ILogger<ProcessMediaQueue> logger) {
            _logger = logger;
        }

        [Function(nameof(ProcessMediaQueue))]
        public void Run(
            [QueueTrigger("media-processing-queue", Connection = "AzureWebJobsStorage")]
            string message) {
            _logger.LogInformation($"Queue message received: {message}");
        }
    }
}
