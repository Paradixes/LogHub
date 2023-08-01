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

    public async Task<Uri> UploadAsync(string containerName, string blobName, string base64Uri,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(_connectionString))
        {
            throw new ArgumentNullException(nameof(_connectionString));
        }

        var blobServiceClient = new BlobServiceClient(_connectionString);
        var blobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);
        var blobClient = blobContainerClient.GetBlobClient(blobName);

        try
        {
            await blobClient.UploadAsync(GenerateStreamFromBase64Uri(base64Uri), cancellationToken);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }


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

    private static Stream GenerateStreamFromBase64Uri(string str)
    {
        str = str.Split(',')[1];
        var imageByte = Convert.FromBase64String(str);
        var stream = new MemoryStream();
        stream.Write(imageByte, 0, imageByte.Length);
        var writer = new StreamWriter(stream);
        writer.Write(str);
        writer.Flush();
        stream.Position = 0;
        return stream;
    }
}
