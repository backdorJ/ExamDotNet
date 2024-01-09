using System.Text.Json;
using DND.BL.Data;
using DND.BL.Services.BattleLogic;
using DND.BL.Services.Logger;
using DND.Domain.Entities;
using DND.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace DND.BL.Controllers;

/// <summary>
/// Контролер который отвечает за вызов логики
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class BattleLogicController : Controller
{
    private readonly IDbContext _dbContext;
    private readonly IBattleLogic _battleLogic;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст БД</param>
    /// <param name="battleLogic">Логика игры</param>
    public BattleLogicController(IDbContext dbContext, IBattleLogic battleLogic)
    {
        _dbContext = dbContext;
        _battleLogic = battleLogic;
    }

    [HttpPost]
    public async Task<string> RunBattleLogicAsync([FromBody] Entity appelant)
    {
        var randomMonster = await _dbContext.Entities
            .FindAsync(Random.Shared.Next(1, _dbContext.Entities.Count() + 1))
            ?? throw new EntityNotFound<Entity>("Попробуйте еще раз!");


        var result = _battleLogic.Run(player: appelant, enemy: randomMonster);

        return JsonSerializer.Serialize(result);
    }
}