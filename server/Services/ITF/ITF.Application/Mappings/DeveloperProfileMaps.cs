using AutoMapper;
using ITF.Application.DeveloperProfiles.Dtos;
using ITF.Application.MyDeveloperProfile.Commands;
using ITF.Application.MyDeveloperProfile.Dtos;
using ITF.Domain.Entities;

namespace ITF.Application.Mappings;

public class DeveloperProfileMaps : Profile
{
    public DeveloperProfileMaps()
    {
        CreateMap<CreateProfileCommand, DeveloperProfile>(MemberList.Source);
        CreateMap<UpdateProfileCommand, DeveloperProfile>(MemberList.Source);
        CreateMap<UpdateContactsCommand, DeveloperContacts>(MemberList.Source);

        CreateMap<DeveloperProfile, DeveloperProfileDto>(MemberList.Destination);
        CreateMap<DeveloperProfile, PublicDeveloperProfileDto>(MemberList.Destination);
        CreateMap<DeveloperContacts, DeveloperContactsDto>(MemberList.Destination);
    }
}