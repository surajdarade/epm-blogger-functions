using Azure.Messaging.EventGrid;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace EPMBlogger.Functions {
    public class BlobCreatedHandler {
        private readonly ILogger<BlobCreatedHandler> _logger;

        public BlobCreatedHandler(ILogger<BlobCreatedHandler> logger) {
            _logger = logger;
        }

        [Function("BlobCreatedHandler")]
        public void Run([EventGridTrigger] EventGridEvent eventGridEvent) {
            _logger.LogInformation($"Blob event received: {eventGridEvent.Subject}");
        }
    }
}
