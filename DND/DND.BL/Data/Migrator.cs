using Microsoft.EntityFrameworkCore;

namespace DND.BL.Data;

/// <summary>
/// Автоматическое применение миграций
/// </summary>
public class Migrator
{
    private readonly EfContext _efContext;
    private readonly ILogger<Migrator> _logger;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="efContext">Контекст БД</param>
    /// <param name="logger">Логгер</param>
    public Migrator(EfContext efContext, ILogger<Migrator> logger)
    {
        _efContext = efContext;
        _logger = logger;
    }

    public async Task MigrateAsync()
    {
        var operationId = Guid.NewGuid().ToString().Substring(0, 4);
        _logger.LogInformation($"UpdateDatabase: {operationId} starting...");
        try
        {
            await _efContext.Database.MigrateAsync().ConfigureAwait(false);
            _logger.LogInformation($"UpdateDatabase successfuly");
        }
        catch
        {
            _logger.LogCritical("Update database failed.");
        }
    }
}