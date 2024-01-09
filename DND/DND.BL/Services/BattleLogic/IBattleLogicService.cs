using DND.Domain.BattleResultsDTO;
using DND.Domain.Entities;

namespace DND.BL.Services.BattleLogic;

public interface IBattleLogicService
{
    BattleResult Run(Entity player, Entity enemy);
}