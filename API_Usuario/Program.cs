using API_Usuario.Context;
using API_Usuario.Models;
using API_Usuario.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connection = builder.Configuration.GetConnectionString("MySql");
builder.Services.AddDbContext<Db>(options =>
    options.UseMySql(connection, ServerVersion.AutoDetect(connection)));

builder.Services.AddScoped<AcompanhamentoServices>();
builder.Services.AddScoped<DesligamentoServices>();
builder.Services.AddScoped<FitCulturalServices>();
builder.Services.AddScoped<FuncionarioServices>();
builder.Services.AddScoped<MotivoDesligamentos>();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
