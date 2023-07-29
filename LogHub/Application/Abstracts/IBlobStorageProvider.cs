namespace LogHub.Application.Abstracts;

public interface IBlobStorageProvider
{
    Task<Uri> UploadAsync(string containerName, string blobName, Stream stream,
        CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(string containerName, string blobName, CancellationToken cancellationToken = default);
}
