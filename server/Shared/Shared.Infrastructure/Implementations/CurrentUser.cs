using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Shared.Core.Interfaces;

namespace Shared.Infrastructure.Implementations;

public class CurrentUser : ICurrentUser
{
    public Guid? Id { get; }

    public CurrentUser(IHttpContextAccessor contextAccessor)
    {
        var userId = contextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
        Id = userId == null 
            ? null 
            : Guid.Parse(userId);
    }
}