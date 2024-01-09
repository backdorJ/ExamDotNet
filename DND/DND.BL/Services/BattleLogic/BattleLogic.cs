using DND.BL.Services.Logger;
using DND.Domain.BattleResultsDTO;
using DND.Domain.Entities;
using DND.Domain.Enums;

namespace DND.BL.Services.BattleLogic;

public class BattleLogic : IBattleLogic
{
    private readonly IBattleLogger _logger;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="logger">Логгер</param>
    public BattleLogic(IBattleLogger logger)
        => _logger = logger;

    /// <summary>
    /// Игрок
    /// </summary>
    protected Entity Player { get; set; }
    
    /// <summary>
    /// Монстер
    /// </summary>
    protected Entity Enemy { get; set; }

    /// <summary>
    /// Игрок который нападает
    /// </summary>
    protected Entity EntityWhoAttack{ get; set; }

    /// <summary>
    /// Игрок который является целью
    /// </summary>
    protected Entity EntityWhoTarget { get; set; }

    /// <summary>
    /// Победитель
    /// </summary>
    protected Entity? Winner => !Player.IsAlive ? Enemy : !Enemy.IsAlive ? Player : null;

    
    /// <inheritdoc />
    public BattleResult Run(Entity player, Entity enemy)
    {
        InitialPlayers(player, enemy);
        
        var roundNumber = 1;
        
        _logger.MeetingLog(playerName: Player.Name, enemyName: Enemy.Name);
        
        while (Winner is null)
            _logger.RoundResultLog(GetRoundResult(roundNumber++));
        
        _logger.WinnerLog(Winner == Player);
        _logger.LeftHealthRemaining(Player.Health);
        
        return _logger.GetBattleLogger();
    }
    
    /// <summary>
    /// Получить результат раунда
    /// </summary>
    /// <param name="roundNumber">Номер раунда</param>
    /// <returns>Результат раунда</returns>
    private RoundResult GetRoundResult(int roundNumber)
    {
        var round = new RoundResult
        {
            RoundNumber = roundNumber,
        };
        
        var attacksLeft = new Dictionary<Entity, int>
        {
            { Player, Player.AttackPerRound },
            { Enemy, Enemy.AttackPerRound },
        };

        EntityWhoAttack = Player;
        EntityWhoTarget = Enemy;

        while (Winner == null && attacksLeft.Values.Sum() > 0)
        {
            if (attacksLeft[EntityWhoAttack] > 0)
            {
                round.ListOfAttacksInRoundJson.Add(GetAttacksResult().ConvertToJson());
                attacksLeft[EntityWhoAttack] -= 1;
            }

            (EntityWhoAttack, EntityWhoTarget) = (EntityWhoTarget, EntityWhoAttack);
        }

        return round;
    }

    /// <summary>
    /// Получить результат атаки
    /// </summary>
    /// <returns>Результат атаки</returns>
    private AttackResult GetAttacksResult()
    {
        var attack = new AttackResult
        {
            AttackerName = EntityWhoAttack.Name,
            AttackDice = 0,
            AttackModifier = EntityWhoAttack.AttackModifier,
            ArmorClass = EntityWhoTarget.ArmorClass,
            JsonFromDamage = new DamageResult().ConvertToJson(),
        };

        var attackDice = Random.Shared.Next(1, 21);
        attack.AttackDice = attackDice;

        switch (attackDice)
        {
            case 1:
                attack.AttackTypes = AttackTypes.CriticalMiss;
                break;
            
            case 20:
                attack.AttackTypes = AttackTypes.CriticalHit;
                attack.JsonFromDamage = GetCurrentDamageForAttack(true).ConvertToJson();
                break;
            
            default:
            {
                if (attackDice + EntityWhoAttack.AttackModifier > EntityWhoTarget.ArmorClass)
                {
                    attack.AttackTypes = AttackTypes.Hit;
                    attack.JsonFromDamage = GetCurrentDamageForAttack(false).ConvertToJson();
                }
                else
                    attack.AttackTypes = AttackTypes.Miss;

                break;
            }
        }

        return attack;
    }

    /// <summary>
    /// Получить дамаг от конктретной атаки
    /// </summary>
    /// <param name="isCritical">Критический удар</param>
    /// <returns>Результат урона</returns>
    private DamageResult GetCurrentDamageForAttack(bool isCritical)
    {
        var damage = new DamageResult
        {
            IsCritical = isCritical,
            DamageModifier = EntityWhoAttack.DamageModifier,
            EnemyName = EntityWhoTarget.Name,
        };

        var damageWithDice = 0;

        for (var i = 0; i < EntityWhoAttack.DamageDiceThrowsNumber; i++)
            damageWithDice += Random.Shared.Next(1, EntityWhoAttack.DamageWithDice + 1);

        damage.DefaultDamageWithDice = damageWithDice;
        var resultDamage = (damageWithDice + EntityWhoAttack.DamageModifier + 1) * (isCritical ? 2 : 1);
        EntityWhoTarget.Health -= resultDamage;
        damage.HealthLeft = EntityWhoTarget.Health;

        return damage;
    }

    private void InitialPlayers(Entity player, Entity enemy)
    {
        Player = player;
        Enemy = enemy;
        EntityWhoAttack = player;
        EntityWhoTarget = enemy;
    }
}