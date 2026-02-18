using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace EPMBlogger.Functions {
    public class QueueProcessorFunction {
        private readonly ILogger<QueueProcessorFunction> _logger;

        public QueueProcessorFunction(ILogger<QueueProcessorFunction> logger) {
            _logger = logger;
        }

        [Function("QueueProcessorFunction")]
        public void Run(
            [QueueTrigger("media-processing-queue", Connection = "AzureWebJobsStorage")] string message) {
            _logger.LogInformation($"Queue message received: {message}");
        }
    }
}
