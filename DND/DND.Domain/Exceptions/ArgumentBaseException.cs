namespace DND.Domain.Exceptions;

public class ArgumentBaseException : Exception
{
    public ArgumentBaseException(string message)
        : base(message)
    {
    }
}