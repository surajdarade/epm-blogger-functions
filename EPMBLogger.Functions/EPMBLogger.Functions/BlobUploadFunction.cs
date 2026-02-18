using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace EPMBlogger.Functions {
    public class BlobUploadFunction {
        private readonly ILogger<BlobUploadFunction> _logger;

        public BlobUploadFunction(ILogger<BlobUploadFunction> logger) {
            _logger = logger;
        }

        [Function("BlobUploadFunction")]
        [QueueOutput("media-processing-queue")]
        public string Run(
            [BlobTrigger("images/{name}", Connection = "AzureWebJobsStorage")] Stream stream,
            string name) {
            _logger.LogInformation($"Blob uploaded: {name}");

            // message pushed to queue
            return name;
        }
    }
}
