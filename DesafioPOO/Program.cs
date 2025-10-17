using Microsoft.EntityFrameworkCore;
using DesafioPOO.Data;
using DesafioPOO.Repositories;
using DesafioPOO.Services;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://*:80");

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CorretoraContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<PessoaRepository>();
builder.Services.AddScoped<PessoaService>();

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
app.UseAuthorization();
app.MapControllers();
app.Run();
