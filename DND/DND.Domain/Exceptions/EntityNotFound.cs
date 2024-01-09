using DND.Domain.Entities;

namespace DND.Domain.Exceptions;

public class EntityNotFound<TEntity> : ArgumentBaseException
    where TEntity : Entity
{
    /// <inheritdoc />
    public EntityNotFound(string message)
        : base($"Монстр не найден! Сообщение {message}")
    {
    }
}