using Azure.Storage.Blobs;
using LogHub.Application.Abstracts;

namespace LogHub.Infrastructure.Storage;

public class BlobStorageProvider : IBlobStorageProvider
{
    private readonly string? _connectionString;

    public BlobStorageProvider(string? connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<Uri> UploadAsync(string containerName, string blobName, Stream stream,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(_connectionString))
        {
            throw new ArgumentNullException(nameof(_connectionString));
        }

        var blobServiceClient = new BlobServiceClient(_connectionString);
        var blobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);
        var blobClient = blobContainerClient.GetBlobClient(blobName);
        await blobClient.UploadAsync(stream, cancellationToken);

        return blobClient.Uri;
    }

    public async Task<bool> DeleteAsync(string containerName, string blobName,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(_connectionString))
        {
            throw new ArgumentNullException(nameof(_connectionString));
        }

        var blobServiceClient = new BlobServiceClient(_connectionString);
        var blobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);
        var blobClient = blobContainerClient.GetBlobClient(blobName);
        return await blobClient.DeleteIfExistsAsync(cancellationToken: cancellationToken);
    }
}
