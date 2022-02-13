namespace Shared.Core.Exceptions;

public class EntityNotValidException : DomainException
{
    public Dictionary<string, string[]>? Errors { get; }

    public EntityNotValidException(string message, Dictionary<string, string[]>? errors = null) : base(message)
    {
        Errors = errors;
    }
}