using GerenciadorDeCursos.API.Configurations;
using GerenciadorDeCursos.Configurations;
using GerenciadorDeCursos.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(opt => opt.SuppressAsyncSuffixInActionNames = false)
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        opt.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();
builder.Services.ConfigureRepository();
builder.Services.ConfigureApi();
builder.Services.ConfigureUseCases();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

WebApplication app = builder.Build();

ILogger<Program> logger = app.Services.GetRequiredService<ILogger<Program>>();
string environment = app.Environment.EnvironmentName;

try
{
    using (IServiceScope scope = app.Services.CreateScope())
    {
        DataContext context = scope.ServiceProvider.GetRequiredService<DataContext>();

        IEnumerable<string> pendingMigrations = await context.Database.GetPendingMigrationsAsync();
        if (pendingMigrations.Any())
        {
            logger.LogInformation("Aplicando {Count} migrations pendentes", pendingMigrations.Count());
            await context.Database.MigrateAsync();
            logger.LogInformation("Migrations aplicadas com sucesso");
        }
    }

    logger.LogInformation("API iniciada com sucesso. Ambiente: {Environment}", environment);
}
catch (Exception ex)
{
    logger.LogError(ex, "Erro fatal ao iniciar a aplicação. Ambiente: {Environment}", environment);
    throw;
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GerenciadorDeCursos.API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();