namespace Application.Abstracts;

public interface IBlobStorageProvider
{
    Task<Uri> UploadAsync(string containerName, string blobName, string base64Uri);

    Task<bool> DeleteAsync(string containerName, string blobName);
}
