using AutoMapper;
using ITF.Domain.Entities;
using ITF.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Core.Exceptions;
using Shared.Core.Helpers;
using Shared.Core.Interfaces;

namespace ITF.Application.DeveloperProfiles.Commands;

public class DeveloperProfileCommandHandler
    : IRequestHandler<CreateDeveloperProfileCommand, Unit>,
        IRequestHandler<UpdateDeveloperProfileCommand, Unit>,
        IRequestHandler<UpdateDeveloperContactsCommand, Unit>,
        IRequestHandler<UpdateDeveloperProfileActiveStateCommand, Unit>
{
    private readonly ItfDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ICurrentUser _currentUser;

    public DeveloperProfileCommandHandler(ItfDbContext dbContext, IMapper mapper, ICurrentUser currentUser)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _currentUser = currentUser;
    }

    public async Task<Unit> Handle(CreateDeveloperProfileCommand request, CancellationToken cancellationToken)
    {
        await CheckDeveloperCategoryExists(request.DeveloperCategoryId);

        var profile = new DeveloperProfile
        {
            Id = _currentUser.Id!.Value,
            DeveloperContacts = new DeveloperContacts()
        };
        _mapper.Map(request, profile);

        _dbContext.DeveloperProfiles.Add(profile);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }

    public async Task<Unit> Handle(UpdateDeveloperProfileCommand request, CancellationToken cancellationToken)
    {
        var profile = await GetProfile();

        await CheckDeveloperCategoryExists(request.DeveloperCategoryId);

        _mapper.Map(request, profile);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }

    public async Task<Unit> Handle(UpdateDeveloperContactsCommand request, CancellationToken cancellationToken)
    {
        var profile = await GetProfile();

        profile.DeveloperContacts = _mapper.Map<DeveloperContacts>(request);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
    
    public async Task<Unit> Handle(UpdateDeveloperProfileActiveStateCommand request, CancellationToken cancellationToken)
    {
        var profile = await GetProfile();

        if (profile.IsActive == request.NewState)
        {
            return Unit.Value;
        }

        profile.IsActive = request.NewState;
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }

    private async ValueTask<DeveloperProfile> GetProfile()
    {
        var profile = await _dbContext.DeveloperProfiles.FindAsync(_currentUser.Id);
        Guard.AgainstNullEntity(profile);
        return profile!;
    }

    private async ValueTask CheckDeveloperCategoryExists(Guid id)
    {
        var categoryExists = await _dbContext.DeveloperCategories.AnyAsync(dc => dc.Id == id);
        if (!categoryExists)
        {
            throw new EntityNotFoundException(nameof(DeveloperCategory));
        }
    }
}