using System.Text.Json;
using DND.Domain.Enums;
using DND.Domain.Extensions;

namespace DND.Domain.BattleResultsDTO;

/// <summary>
/// Результат атаки
/// </summary>
public class AttackResult
{
    /// <summary>
    /// Тот кто производит атаку
    /// </summary>
    public string AttackerName { get; set; } = default!;

    /// <summary>
    /// Тип атаки
    /// </summary>
    public AttackTypes AttackTypes { get; set; }

    /// <summary>
    /// Урон от числа кубика
    /// </summary>
    public int AttackDice { get; set; }

    /// <summary>
    /// Урок от атаки
    /// </summary>
    public int AttackModifier { get; set; }

    /// <summary>
    /// Единицы брони (target)
    /// </summary>
    public int ArmorClass { get; set; }

    /// <summary>
    /// Результат урона атаки
    /// </summary>
    public string JsonFromDamage { get; set; } = default!;

    /// <inheritdoc />
    public override string ToString()
    {
        var resultDamage = JsonSerializer.Deserialize<DamageResult>(JsonFromDamage);

        return $"{AttackerName}\n" + AttackTypes switch
        {
            AttackTypes.CriticalMiss => $"{AttackDice}(+{AttackModifier}) {AttackTypes.CriticalMiss.GetDescription()}\n",
            AttackTypes.Miss => $"{AttackDice}(+{AttackModifier}) {AttackTypes.Miss.GetDescription()}\n",
            AttackTypes.Hit => $"{AttackDice}(+{AttackModifier}) {AttackTypes.Hit.GetDescription()} {resultDamage}\n",
            AttackTypes.CriticalHit => $"{AttackDice}(+{AttackModifier}) {AttackTypes.CriticalHit.GetDescription()} {resultDamage}\n",
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public string ConvertToJson() => JsonSerializer.Serialize(this);
}