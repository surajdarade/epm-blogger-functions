using System.IO;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace EPMBlogger.Functions
{
    public class BlobUploadFunction
    {
        private readonly ILogger<BlobUploadFunction> _logger;

        public BlobUploadFunction(ILogger<BlobUploadFunction> logger)
        {
            _logger = logger;
        }

        [Function("BlobProcessor")]
        [QueueOutput("media-processing-queue", Connection = "AzureWebJobsStorage")]
        public string Run(
            [BlobTrigger("images/{name}", Connection = "AzureWebJobsStorage")]
            Stream stream,
            string name)
        {
            _logger.LogInformation($"Blob processed: {name}");

            return name; // This becomes queue message
        }
    }
}