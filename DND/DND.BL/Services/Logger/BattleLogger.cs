using System.Text.Json;
using DND.Domain.BattleResultsDTO;

namespace DND.BL.Services.Logger;

public class BattleLogger : IBattleLogger
{
    private readonly BattleResult _source;

    public BattleLogger(BattleResult source)
    {
        _source = source;
    }
    
    /// <summary>
    /// Логер встречи
    /// </summary>
    /// <param name="playerName">Имя игрока</param>
    /// <param name="enemyName">Имя противника</param>
    public void MeetingLog(string playerName, string enemyName)
        => (_source.PlayerName, _source.MonsterName) = (playerName, enemyName);

    /// <summary>
    /// Логгер выйгрыша
    /// </summary>
    /// <param name="playerWin">Победиль игрок</param>
    public void WinnerLog(bool playerWin)
        => _source.PlayerWin = playerWin;

    /// <summary>
    /// Логгер раунда
    /// </summary>
    /// <param name="roundResult">Итоги раунда</param>
    public void RoundResultLog(RoundResult roundResult)
        => _source.ListOfRoundsJson.Add(JsonSerializer.Serialize(roundResult));

    /// <summary>
    /// Осталось здоровья у игрока
    /// </summary>
    public BattleResult GetBattleLogger()
        => _source;

    /// <inheritdoc />
    public void LeftHealthRemaining(int playerHealth)
        => _source.PlayerRemainingHealth = playerHealth;
    
}