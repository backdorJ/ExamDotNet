using System.ComponentModel;

namespace DND.Domain.Enums;

/// <summary>
/// Возможные события боя
/// </summary>
public enum AttackTypes
{
    /// <summary>
    /// Критический промах
    /// </summary>
    [Description("Критический промах, повезет в следующий раз..")]
    CriticalMiss = 1,
    
    /// <summary>
    /// Промах
    /// </summary>
    [Description("Эх, вы промахнулись..")]
    Miss = 2,
    
    /// <summary>
    /// Попадание
    /// </summary>
    [Description("Это попадание!")]
    Hit = 3,
    
    /// <summary>
    /// Критическое попадание
    /// </summary>
    [Description("Это критическое попадание!")]
    CriticalHit = 4,
}