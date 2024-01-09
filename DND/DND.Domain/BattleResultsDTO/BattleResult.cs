using System.Text.Json;

namespace DND.Domain.BattleResultsDTO;

/// <summary>
/// Итоги боя
/// </summary>
public class BattleResult
{
    /// <summary>
    /// Имя игрока
    /// </summary>
    public string PlayerName { get; set; } = default!;
    
    /// <summary>
    /// Имя мнстра
    /// </summary>
    public string MonsterName { get; set; } = default!;

    /// <summary>
    /// Оставшееся здровье игрока
    /// </summary>
    public int PlayerRemainingHealth { get; set; }

    /// <summary>
    /// Победил игрок
    /// </summary>
    public bool PlayerWin { get; set; }

    /// <summary>
    /// Игра окончена
    /// </summary>
    public bool IsFinish { get; set; }

    /// <summary>
    /// Список раундов в виде json
    /// </summary>
    public List<string> ListOfRoundsJson { get; set; } = new();

    /// <inheritdoc />
    public override string ToString()
    {
        var log = ListOfRoundsJson
            .Select(x => JsonSerializer.Deserialize<RoundResult>(x)?.ToString());

        return $"Ваш персонаж под именем ({PlayerName})! Встретился с монстром ({MonsterName})\n" +
               $" {string.Concat(log)}" +
               $" {(PlayerWin ? PlayerName : MonsterName)} Победил!";
    }
}