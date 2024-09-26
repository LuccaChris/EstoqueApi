using Microsoft.EntityFrameworkCore;
using EstoqueApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configurando o DbContext para MySQL
builder.Services.AddDbContext<MeuDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 23))));  // Ajuste a versão do MySQL conforme necessário

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


