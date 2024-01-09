using DND.Domain.BattleResultsDTO;

namespace DND.BL.Services.Logger;

public interface IBattleLoggerService
{
    void MeetingLog(string playerName, string enemyName);
    void WinnerLog(bool isPlayerWin);
    void RoundResultLog(RoundResult roundResult);
    BattleResult GetBattleLogger();
    void LeftHealthRemaining(int playerHealth);
}