using AutoMapper;
using ITF.Application.MyDeveloperProfile.Dtos;
using ITF.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Core.Helpers;
using Shared.Core.Interfaces;

namespace ITF.Application.MyDeveloperProfile.Queries;

public class DeveloperProfileQueryHandler : IRequestHandler<GetMyProfileQuery, DeveloperProfileDto>
{
    private readonly ItfDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ICurrentUser _currentUser;

    public DeveloperProfileQueryHandler(ItfDbContext dbContext, IMapper mapper, ICurrentUser currentUser)
    {
        _dbContext = dbContext;
        _currentUser = currentUser;
        _mapper = mapper;
    }

    public async Task<DeveloperProfileDto> Handle(
        GetMyProfileQuery request,
        CancellationToken cancellationToken)
    {
        var profile = await _dbContext.Users
            .Where(u => u.Id == _currentUser.Id)
            .Include(u => u.DeveloperProfile)
            .ThenInclude(dp => dp!.DeveloperContacts)
            .Select(dp => dp.DeveloperProfile)
            .FirstOrDefaultAsync(cancellationToken);

        Guard.AgainstNullEntity(profile);

        return _mapper.Map<DeveloperProfileDto>(profile);
    }
}