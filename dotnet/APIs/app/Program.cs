using app.Controllers;
using app.Helpers;
using app.Services;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddTransient<Func<MessageType,IMessageService>>(provider => key =>
{
    return key switch
    {
        MessageType.SMS => new SmsService(),
        MessageType.Email => new EmailService(),
        _ => throw new NotSupportedException($"Message type {key} is not supported.")
    };
});
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

app.MapControllers();
app.Run();


