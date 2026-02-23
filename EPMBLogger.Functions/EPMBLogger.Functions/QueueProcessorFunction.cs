using System;
using System.Threading.Tasks;
using Azure.Data.Tables;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace EPMBlogger.Functions
{
    public class QueueProcessorFunction
    {
        private readonly ILogger<QueueProcessorFunction> _logger;

        public QueueProcessorFunction(ILogger<QueueProcessorFunction> logger)
        {
            _logger = logger;
        }

        [Function("QueueProcessorFunction")]
        public async Task Run(
            [QueueTrigger("media-processing-queue", Connection = "AzureWebJobsStorage")]
            string message)
        {
            _logger.LogInformation($"Queue message received: {message}");

            string storageConnection = Environment.GetEnvironmentVariable("AzureWebJobsStorage");

            var tableClient = new TableClient(storageConnection, "filemetadata");

            await tableClient.CreateIfNotExistsAsync();

            var entity = new FileMetadataEntity
            {
                PartitionKey = "UserFiles",
                RowKey = Guid.NewGuid().ToString(),
                FileName = message,
                Status = "Processed",
                UploadedAt = DateTime.UtcNow,
                ProcessedAt = DateTime.UtcNow
            };

            await tableClient.AddEntityAsync(entity);

            _logger.LogInformation("Metadata saved to Table Storage.");
        }
    }
}