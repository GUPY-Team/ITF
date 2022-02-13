using MediatR;

namespace ITF.Application.DeveloperProfiles.Commands;

public class UpdateDeveloperProfileActiveStateCommand : IRequest
{
    public bool NewState { get; set; }
}