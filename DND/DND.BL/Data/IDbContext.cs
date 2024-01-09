using DND.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DND.BL.Data;

/// <summary>
/// Контекст БД
/// </summary>
public interface IDbContext
{
    /// <summary>
    /// Сущность модели
    /// </summary>
    DbSet<Entity> Entities { get; set; }
    
    /// <summary>
    /// Созранить изменения
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Число</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}