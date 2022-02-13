namespace Shared.Core.Exceptions;

public class EntityNotFoundException : DomainException
{
    public string EntityName { get; }

    public EntityNotFoundException(string entityName) : base($"{entityName} not found")
    {
        EntityName = entityName;
    }
}