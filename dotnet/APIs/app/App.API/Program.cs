using App.API.Helpers;
using App.Application.Enums;
using App.Application.Interfaces;
using App.Application.Services;
using App.Domain.Interfaces;
using App.Infrastructure.Data;
using App.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<EmailService>();
builder.Services.AddTransient<SmsService>();
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IProductImageRepository, ProductImageRepository>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

//builder.Services.AddScoped<IMessageServiceFactory, MessageServiceFactory>();

builder.Services.AddTransient<Func<MessageType, IMessageService>>(provider => key =>
{
    return key switch
    {
        MessageType.SMS => provider.GetRequiredService<SmsService>(),
        MessageType.Email => provider.GetRequiredService<EmailService>(),
        _ => throw new NotSupportedException($"Message type {key} is not supported.")
    };
});
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddTransient<IMessageService, EmailService>();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers(options =>
{
    options.Filters.Add<LogActionFilter>();
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
// app.UseStaticFiles(new StaticFileOptions
// {
//     FileProvider = new PhysicalFileProvider(
//         Path.Combine(builder.Environment.ContentRootPath, "Uploads")),
//     RequestPath = "/Resources"
// });

app.UseHttpsRedirection();
app.UseMiddleware<RequestLoggingMiddleware>();
app.MapControllers();
app.Run();

// Add this line to make the Program class public for the test project.
public partial class Program { }
