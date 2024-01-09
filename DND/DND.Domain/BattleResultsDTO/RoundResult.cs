using System.Text.Json;

namespace DND.Domain.BattleResultsDTO;

/// <summary>
/// Результат раунда
/// </summary>
public class RoundResult
{
    /// <summary>
    /// Номер раунда
    /// </summary>
    public int RoundNumber { get; set; }

    /// <summary>
    /// Список результатов атак в виде json
    /// </summary>
    public List<string> ListOfAttacksInRoundJson { get; set; } = new();
    
    /// <inheritdoc />
    public override string ToString()
    {
        var attackResults = ListOfAttacksInRoundJson
            .Select(x => JsonSerializer.Deserialize<AttackResult>(x)?.ToString());

        return $"\n Раунд: {RoundNumber}: \n " + string.Concat(attackResults);
    }
}