using ITF.Application.DeveloperProfiles.Commands;
using Microsoft.AspNetCore.Mvc;

namespace ITF.Api.Controllers;

public class DeveloperProfileController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateProfile([FromBody] CreateDeveloperProfileCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult> UpdateProfile([FromBody] UpdateDeveloperProfileCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }

    [HttpPut("contacts")]
    public async Task<ActionResult> UpdateContacts([FromBody] UpdateDeveloperContactsCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }

    [HttpPost("activate")]
    public async Task<ActionResult> ActivateProfile()
    {
        await Mediator.Send(new UpdateDeveloperProfileActiveStateCommand
        {
            NewState = true
        });

        return Ok();
    }

    [HttpPost("deactivate")]
    public async Task<ActionResult> DeactivateProfile()
    {
        await Mediator.Send(new UpdateDeveloperProfileActiveStateCommand
        {
            NewState = false
        });

        return Ok();
    }
}