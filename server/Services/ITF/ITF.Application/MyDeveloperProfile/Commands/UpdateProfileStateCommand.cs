using MediatR;

namespace ITF.Application.MyDeveloperProfile.Commands;

public class UpdateProfileStateCommand : IRequest
{
    public bool NewState { get; set; }
}