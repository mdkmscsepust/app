using app.Controllers;
using app.Data;
using app.Helpers;
using app.Repositories;
using app.Services;
using app.Services.ProductService;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<EmailService>();
builder.Services.AddTransient<SmsService>();
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

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

app.UseHttpsRedirection();
app.UseMiddleware<RequestLoggingMiddleware>();
app.MapControllers();
app.Run();


