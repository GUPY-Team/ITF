using ITF.Application.DeveloperProfiles.Dtos;
using MediatR;

namespace ITF.Application.DeveloperProfiles.Queries;

public class GetPublicDeveloperProfileById : IRequest<PublicDeveloperProfileDto>
{
    public Guid Id { get; set; }
}