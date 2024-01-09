using DND.Domain.BattleResultsDTO;
using DND.Domain.Entities;

namespace DND.BL.Services.BattleLogic;

public interface IBattleLogic
{
    BattleResult Run(Entity player, Entity enemy);
}