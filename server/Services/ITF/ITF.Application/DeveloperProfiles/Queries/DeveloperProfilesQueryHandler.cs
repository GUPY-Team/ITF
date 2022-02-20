using AutoMapper;
using ITF.Application.DeveloperProfiles.Dtos;
using ITF.Infrastructure;
using MediatR;
using Shared.Core.Helpers;

namespace ITF.Application.DeveloperProfiles.Queries;

public class DeveloperProfilesQueryHandler : IRequestHandler<GetPublicDeveloperProfileById, PublicDeveloperProfileDto>
{
    private readonly ItfDbContext _dbContext;
    private readonly IMapper _mapper;

    public DeveloperProfilesQueryHandler(ItfDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<PublicDeveloperProfileDto> Handle(
        GetPublicDeveloperProfileById request,
        CancellationToken cancellationToken)
    {
        var profile = await _dbContext.DeveloperProfiles.FindAsync(request.Id);
        Guard.AgainstNullEntity(profile);

        return _mapper.Map<PublicDeveloperProfileDto>(profile);
    }
}