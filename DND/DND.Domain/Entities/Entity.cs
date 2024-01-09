using System.ComponentModel.DataAnnotations.Schema;

namespace DND.Domain.Entities;

/// <summary>
/// Сущность
/// </summary>
public class Entity
{
    /// <summary>
    /// ИД персонажа
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Имя персонажа
    /// </summary>
    public string Name { get; set; } = default!;
    
    /// <summary>
    /// Здоровье персонажа
    /// </summary>
    public int Health { get; set; }
    
    /// <summary>
    /// Класс брони
    /// </summary>
    public int ArmorClass { get; set; }

    /// <summary>
    /// Аттак за рануд
    /// </summary>
    public int AttackPerRound { get; set; }

    /// <summary>
    /// Модификатор атаки
    /// </summary>
    public int AttackModifier { get; set; }

    /// <summary>
    /// Модификатор урона
    /// </summary>
    public int DamageModifier { get; set; }

    /// <summary>
    /// Урон от кубика (диапазон)
    /// </summary>
    public int DamageWithDice { get; set; }

    /// <summary>
    /// Сколько раз бросается кубик
    /// </summary>
    public int DamageDiceThrowsNumber { get; set; }

    /// <summary>
    /// Жив ли
    /// </summary>
    [NotMapped]
    public bool IsAlive => Health > 0;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="health"></param>
    /// <param name="armorClass"></param>
    /// <param name="attackPerRound"></param>
    /// <param name="attackModifier"></param>
    /// <param name="damageModifier"></param>
    /// <param name="damageWithDice"></param>
    /// <param name="damageDiceThrowsNumber"></param>
    public Entity(
        int id,
        string name,
        int health,
        int armorClass,
        int attackPerRound,
        int attackModifier,
        int damageModifier,
        int damageWithDice,
        int damageDiceThrowsNumber)
    {
        Id = id;
        Name = name;
        Health = health;
        ArmorClass = armorClass;
        AttackPerRound = attackPerRound;
        AttackModifier = attackModifier;
        DamageModifier = damageModifier;
        DamageWithDice = damageWithDice;
        DamageDiceThrowsNumber = damageDiceThrowsNumber;
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    public Entity()
    {
    }
}