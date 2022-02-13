using Shared.Core.Exceptions;

namespace Shared.Core.Helpers;

public static class Guard
{
    public static void AgainstNullEntity<TEntity>(TEntity entity)
    {
        if (entity == null)
        {
            throw new EntityNotFoundException(typeof(TEntity).Name);
        }
    }
}