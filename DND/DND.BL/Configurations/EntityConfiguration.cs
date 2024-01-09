using DND.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DND.BL.Configurations;

/// <summary>
/// Конфигурация сущности
/// </summary>
public class EntityConfiguration : IEntityTypeConfiguration<Entity>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Entity> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .Property(p => p.Name)
            .IsRequired();

        builder
            .Property(p => p.ArmorClass)
            .IsRequired();

        builder
            .Property(p => p.DamageDiceThrowsNumber)
            .IsRequired();

        builder
            .Property(p => p.Health)
            .IsRequired();

        builder
            .Property(p => p.DamageModifier)
            .IsRequired();

        builder
            .Property(p => p.AttackPerRound)
            .IsRequired();

        builder
            .Property(p => p.DamageWithDice)
            .IsRequired();

        builder
            .Property(p => p.AttackModifier)
            .IsRequired();
    }
}