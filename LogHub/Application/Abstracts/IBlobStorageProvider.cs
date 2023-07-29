namespace LogHub.Application.Abstracts;

public interface IBlobStorageProvider
{
    Task<Uri> UploadAsync(string containerName, string blobName, string base64Uri,
        CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(string containerName, string blobName, CancellationToken cancellationToken = default);
}