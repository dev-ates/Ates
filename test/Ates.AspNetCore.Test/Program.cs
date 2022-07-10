using Ates.AspNetCore.JWToken;
using Ates.AspNetCore.Test.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var key = "De n eme ola rak yazilm is keydir sdf df";
builder.Services.AddSingleton<JWTAuthenticationManager>(new JWTAuthenticationManager(key));

builder.Services.JWTAddServices(key);

builder.Services.Configure<MailServiceSettings>(
    builder.Configuration.GetSection("MailServiceSettings"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
