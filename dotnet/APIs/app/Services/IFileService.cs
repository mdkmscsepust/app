namespace app.Services;

public interface IFileService
{
    Task<string> UploadFileAsync(IFormFile file);
    void DeleteFile(string filePath);
}