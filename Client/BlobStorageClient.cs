using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Client.Interfaces;
using Client.Models;
using Client.Options;
using Microsoft.Extensions.Options;

namespace Client
{
    public class BlobStorageClient(IOptions<BlobStorageClientOptions> options): IBlobStorageClient
    {
        private readonly BlobStorageClientOptions _configuration = options.Value;

        public async Task<string> Upload(Blob blob)
        {
            try
            {
                var blockBlobClient = await blob.GetBlockBlobClient(_configuration);

                await blockBlobClient.UploadAsync(blob.Stream, blob.Options);

                return blockBlobClient.Uri.AbsoluteUri;
            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }

        public async Task<Stream> Download(Blob blob)
        {
            var blockBlobClient = await blob.GetBlockBlobClient(_configuration);
            BlobDownloadInfo downloadInfo = await blockBlobClient.DownloadAsync();
            return downloadInfo.Content;
        }

        public async Task Delete(Blob blob)
        {
            try
            {
                BlobServiceClient blobServiceClient = new BlobServiceClient(_configuration.ConnectionString);
                BlobContainerClient container = blobServiceClient.GetBlobContainerClient(blob.Container);
                var item = container.GetBlobClient(blob.Name);
                await item.DeleteIfExistsAsync();
            }
            catch (Exception e)
            {
                throw new InvalidOperationException();
            }
        }
    }
}