using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace EPMBlogger.Functions {
    public class Function1 {
        private readonly ILogger<Function1> _logger;

        public Function1(ILogger<Function1> logger) {
            _logger = logger;
        }

        [Function(nameof(Function1))]
        public async Task Run([BlobTrigger("images/{name}", Source = BlobTriggerSource.EventGrid, Connection = "AzureWebJobsStorage")] Stream stream, string name) {
            using var blobStreamReader = new StreamReader(stream);

            var content = await blobStreamReader.ReadToEndAsync();

            _logger.LogInformation($"Blob Processed: {name}");
        }
    }
}