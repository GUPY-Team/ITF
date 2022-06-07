using ITF.Application.DeveloperProfiles.Dtos;
using ITF.Application.MyDeveloperProfile.Commands;
using ITF.Application.MyDeveloperProfile.Dtos;
using ITF.Application.MyDeveloperProfile.Queries;
using Microsoft.AspNetCore.Mvc;

namespace ITF.Api.Controllers;

[Route("developer-profiles/me")]
public class MyDeveloperProfileController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PublicDeveloperProfileDto>> GetProfile()
    {
        var profile = await Mediator.Send(new GetMyProfileQuery());
        return Ok(profile);
    }

    [HttpPost]
    public async Task<ActionResult> CreateProfile([FromBody] CreateProfileCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult> UpdateProfile([FromBody] UpdateProfileCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteProfile()
    {
        await Mediator.Send(new DeleteProfileCommand());
        return Ok();
    }

    [HttpPut("contacts")]
    public async Task<ActionResult> UpdateContacts([FromBody] UpdateContactsCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }

    [HttpPost("activate")]
    public async Task<ActionResult> ActivateProfile()
    {
        await Mediator.Send(new UpdateProfileStateCommand
        {
            NewState = true
        });

        return Ok();
    }

    [HttpPost("deactivate")]
    public async Task<ActionResult> DeactivateProfile()
    {
        await Mediator.Send(new UpdateProfileStateCommand
        {
            NewState = false
        });

        return Ok();
    }
}