using DND.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DND.BL.Data;

/// <summary>
/// Входная точка для бд
/// </summary>
public class EfContext : DbContext, IDbContext
{
    public EfContext(DbContextOptions<EfContext> options)
        : base(options)
    {
    }
    
    /// <inheritdoc />
    public DbSet<Entity> Entities { get; set; } = default!;
}