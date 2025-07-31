
namespace app.Services;

public class FileService(IWebHostEnvironment environment) : IFileService
{
    public void DeleteFile(string filePath)
    {

        if (string.IsNullOrEmpty(filePath)) throw new ArgumentNullException(nameof(filePath));
        var contentPath = environment.ContentRootPath;
        var fullPath = Path.Combine(contentPath, "Uploads", filePath);
        if (!File.Exists(fullPath)) throw new FileNotFoundException("File not found", fullPath);
        File.Delete(fullPath);
    }

    public async Task<string> UploadFileAsync(IFormFile file)
    {
        if (file is null) throw new ArgumentNullException(nameof(file));
        var contentPath = environment.ContentRootPath;
        var uploadPath = Path.Combine(contentPath, "Uploads");
        if (!Directory.Exists(uploadPath))
        {
            Directory.CreateDirectory(uploadPath);
        }

        var ext = Path.GetExtension(file.FileName);

        var fileName = $"{Guid.NewGuid().ToString()}{ext}";
        var filePath = Path.Combine(uploadPath, fileName);
        using var stream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(stream);
        return fileName;
    }
}