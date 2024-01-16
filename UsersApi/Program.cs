using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using UsersApi.DependencyInjections;
using UsersApi.MiddleWares;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAppData(builder.Configuration);
builder.Services.AddMapster();
builder.Services.AddAppServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();



app.UseCors(x =>
{
    x.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
});


app.UseMiddleware<ExceptionMiddleware>();
app.UseRouting();
app.MapControllers();

app.Run();