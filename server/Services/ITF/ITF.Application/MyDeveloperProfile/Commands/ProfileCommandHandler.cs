using AutoMapper;
using ITF.Domain.Entities;
using ITF.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Core.Exceptions;
using Shared.Core.Helpers;
using Shared.Core.Interfaces;

namespace ITF.Application.MyDeveloperProfile.Commands;

public class ProfileCommandHandler
    : IRequestHandler<CreateProfileCommand, Unit>,
        IRequestHandler<UpdateProfileCommand, Unit>,
        IRequestHandler<DeleteProfileCommand, Unit>,
        IRequestHandler<UpdateContactsCommand, Unit>,
        IRequestHandler<UpdateProfileStateCommand, Unit>
{
    private readonly ItfDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ICurrentUser _currentUser;

    public ProfileCommandHandler(ItfDbContext dbContext, IMapper mapper, ICurrentUser currentUser)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _currentUser = currentUser;
    }

    public async Task<Unit> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
    {
        await CheckDeveloperCategoryExists(request.DeveloperCategoryId);

        var profile = _mapper.Map<DeveloperProfile>(request);
        profile.DeveloperContacts = new DeveloperContacts();

        _dbContext.DeveloperProfiles.Add(profile);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }

    public async Task<Unit> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
    {
        await CheckDeveloperCategoryExists(request.DeveloperCategoryId);

        var profile = await GetProfile();
        _mapper.Map(request, profile);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }

    public async Task<Unit> Handle(DeleteProfileCommand request, CancellationToken cancellationToken)
    {
        var profile = await GetProfile();

        _dbContext.Remove(profile);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }

    public async Task<Unit> Handle(UpdateContactsCommand request, CancellationToken cancellationToken)
    {
        var profile = await GetProfile();

        profile.DeveloperContacts = _mapper.Map<DeveloperContacts>(request);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }

    public async Task<Unit> Handle(UpdateProfileStateCommand request, CancellationToken cancellationToken)
    {
        var profile = await GetProfile();

        profile.IsActive = request.NewState;
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }

    private async ValueTask<DeveloperProfile> GetProfile()
    {
        var profile = await _dbContext.Users
            .Where(u => u.Id == _currentUser.Id)
            .Include(u => u.DeveloperProfile)
            .ThenInclude(u => u.DeveloperContacts)
            .Select(u => u.DeveloperProfile)
            .FirstOrDefaultAsync();

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