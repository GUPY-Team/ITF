using ITF.Application.MyDeveloperProfile.Dtos;
using MediatR;

namespace ITF.Application.MyDeveloperProfile.Queries;

public class GetMyProfileQuery : IRequest<DeveloperProfileDto>
{
}