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
builder.Services.AddScoped<EnderecoRepository>();
builder.Services.AddScoped<EnderecoService>();
builder.Services.AddScoped<ImovelRepository>();
builder.Services.AddScoped<ImovelService>();
builder.Services.AddScoped<AluguelRepository>();
builder.Services.AddScoped<AluguelService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();
    try
    {
        var context = services.GetRequiredService<CorretoraContext>();

        const int maxRetries = 10;
        var delayBaseMs = 1000;
        for (int attempt = 1; attempt <= maxRetries; attempt++)
        {
            try
            {
                context.Database.Migrate();
                logger.LogInformation("Database migrations applied successfully.");
                break;
            }
            catch (Exception ex) when (attempt < maxRetries)
            {
                var delay = TimeSpan.FromMilliseconds(delayBaseMs * attempt);
                logger.LogWarning(ex, "Migration attempt {Attempt}/{MaxRetries} failed. Retrying in {Delay}...", attempt, maxRetries, delay);
                Thread.Sleep(delay);
            }
        }
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred while migrating the database.");
        throw;
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
