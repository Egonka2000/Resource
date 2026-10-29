using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Resources.Business;
using Resources.Data;
using System.ComponentModel.Design;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ResourceDbContext>();
builder.Services.AddScoped<IService, Service>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
