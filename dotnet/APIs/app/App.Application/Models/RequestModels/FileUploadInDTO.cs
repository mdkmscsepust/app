namespace App.Application.Models.RequestModels;

public class FileUploadInDTO
{
    public string FileName { get; set; } = default!;
    public byte[] FileContent { get; set; } = default!;
}