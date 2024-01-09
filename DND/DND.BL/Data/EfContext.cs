using DND.BL.Configurations;
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

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region  Entity

        var entities = new List<Entity>
        {
            new()
            {
                Id = 1,
                Name = "Enchanter",
                Health = 50,
                ArmorClass = 10,
                AttackPerRound = 1,
                AttackModifier = 3,
                DamageModifier = 6,
                DamageWithDice = 6,
                DamageDiceThrowsNumber = 6
            },
            new()
            {
                Id = 2,
                Name = "Swarm of ravens",
                Health = 24,
                ArmorClass = 12,
                AttackPerRound = 4,
                AttackModifier = 2,
                DamageModifier = 2,
                DamageWithDice = 8,
                DamageDiceThrowsNumber = 1
            },
            new()
            {
                Id = 3,
                Name = "Enormous Tentacle",
                Health = 60,
                ArmorClass = 12,
                AttackPerRound = 1,
                AttackModifier = 2,
                DamageModifier = 12,
                DamageWithDice = 7,
                DamageDiceThrowsNumber = 8
            }
        };

        #endregion

        modelBuilder.ApplyConfiguration(new EntityConfiguration());
        modelBuilder.Entity<Entity>().HasData(entities);
        
        base.OnModelCreating(modelBuilder);
    }
}