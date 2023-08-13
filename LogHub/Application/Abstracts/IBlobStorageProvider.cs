namespace Application.Abstracts;

public interface IBlobStorageProvider
{
    Task<Uri?> UploadAsync(string containerName, string? base64Uri);

    Task<bool> DeleteAsync(string containerName, string? blobName);
}
