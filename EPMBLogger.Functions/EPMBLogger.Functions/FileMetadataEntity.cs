using Azure;
using Azure.Data.Tables;

namespace EPMBlogger.Functions
{
    public class FileMetadataEntity : ITableEntity
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public string Status { get; set; }
        public string FileName { get; set; }
        public DateTime UploadedAt { get; set; }
        public DateTime ProcessedAt { get; set; }

        public ETag ETag { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
    }
}