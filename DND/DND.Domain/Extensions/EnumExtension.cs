using System.ComponentModel;

namespace DND.Domain.Extensions;

/// <summary>
/// Класс расширения для работы с enum
/// </summary>
public static class EnumExtension
{
    /// <summary>
    /// Получить описание enum`а
    /// </summary>
    /// <param name="e">Enum</param>
    /// <returns>Описание</returns>
    public static string GetDescription(this Enum? e)
    {
        if (e is null)
            return string.Empty;

        var attribute = GetAttribute<DescriptionAttribute>(e);
        return attribute == null ? e.ToString() : attribute.Description;
    }

    private static T? GetAttribute<T>(Enum value)
        where T : Attribute
    {
        var type = value.GetType();
        var memberInfo = type.GetMember(value.ToString());
        var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
        return attributes.Length > 0
            ? (T)attributes[0]
            : null;
    }
}