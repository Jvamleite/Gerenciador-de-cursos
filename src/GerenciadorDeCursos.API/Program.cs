using GerenciadorDeCursos.Repositories.Context;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();