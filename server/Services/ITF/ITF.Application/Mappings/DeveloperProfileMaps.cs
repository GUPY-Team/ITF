using AutoMapper;
using ITF.Application.DeveloperProfiles.Commands;
using ITF.Domain.Entities;

namespace ITF.Application.Mappings;

public class DeveloperProfileMaps : Profile
{
    public DeveloperProfileMaps()
    {
        CreateMap<CreateDeveloperProfileCommand, DeveloperProfile>(MemberList.Source);
        CreateMap<UpdateDeveloperProfileCommand, DeveloperProfile>(MemberList.Source);
        CreateMap<UpdateDeveloperContactsCommand, DeveloperContacts>(MemberList.Source);
    }
}