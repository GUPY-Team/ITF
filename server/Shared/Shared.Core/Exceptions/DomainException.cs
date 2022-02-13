namespace Shared.Core.Exceptions;

public abstract class DomainException : ApplicationException
{
    public DomainException(string message) : base(message)
    {
    }
}