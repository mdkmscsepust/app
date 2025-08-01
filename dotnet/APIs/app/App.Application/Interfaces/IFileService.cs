using App.Application.Models.RequestModels;

namespace App.Application.Interfaces;

public interface IFileService
{
    Task<string> UploadFileAsync(FileUploadInDTO file);
    void DeleteFile(string filePath);
}