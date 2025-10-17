using Microsoft.EntityFrameworkCore;
using DesafioPOO.Data;
using DesafioPOO.Repositories;
using DesafioPOO.Services;

var builder = WebApplication.CreateBuilder(args);

// PostgreSQL connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CorretoraContext>(options =>
    options.UseNpgsql(connectionString));

// Services & Repositories
builder.Services.AddScoped<PessoaRepository>();
builder.Services.AddScoped<PessoaService>();

// Controllers & Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
