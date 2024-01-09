using System.Text.Json;

namespace DND.Domain.BattleResultsDTO;

/// <summary>
/// Итог урона
/// </summary>
public class DamageResult
{
    /// <summary>
    /// Базовый урон
    /// </summary>
    public int DefaultDamageWithDice { get; set; }

    /// <summary>
    /// Критический урон
    /// </summary>
    public bool IsCritical { get; set; }

    /// <summary>
    /// Урон дамага
    /// </summary>
    public int DamageModifier { get; set; }

    /// <summary>
    /// Имя противника
    /// </summary>
    public string EnemyName { get; set; } = default!;

    /// <summary>
    /// Осталось здоровья
    /// </summary>
    public int HealthLeft { get; set; }

    /// <inheritdoc />
    public override string ToString()
        => IsCritical
            ? $"{DefaultDamageWithDice}(+{DamageModifier})*2 урона {(DefaultDamageWithDice + DamageModifier) * 2}" +
              $" наносит урон {EnemyName}({HealthLeft} осталось здоровья)\n"
            : $"{DefaultDamageWithDice}(+{DamageModifier})" +
              $" урона {DefaultDamageWithDice + DamageModifier} наносит урон {EnemyName}({HealthLeft} осталось здоровья)\n";

    public string ConvertToJson() => JsonSerializer.Serialize(this);
}