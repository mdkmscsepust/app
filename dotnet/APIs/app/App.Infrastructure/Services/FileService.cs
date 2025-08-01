
using App.Application.Interfaces;
using App.Application.Models.RequestModels;

namespace App.Infrastructure.Services;

public class FileService: IFileService
{
    public void DeleteFile(string filePath)
    {
        if (!File.Exists(filePath)) throw new FileNotFoundException("File not found", filePath);
        File.Delete(filePath);
    }

    public async Task<string> UploadFileAsync(FileUploadInDTO file)
    {
        var path = Path.Combine("wwwroot/uploads", file.FileName);
        await File.WriteAllBytesAsync(path, file.FileContent);
        return path;
    }
}