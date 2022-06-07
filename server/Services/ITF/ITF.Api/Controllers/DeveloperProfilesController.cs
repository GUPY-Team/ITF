using ITF.Application.DeveloperProfiles.Dtos;
using ITF.Application.DeveloperProfiles.Queries;
using ITF.Application.MyDeveloperProfile.Dtos;
using ITF.Application.MyDeveloperProfile.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITF.Api.Controllers;

[Route("developer-profiles")]
[AllowAnonymous]
public class DeveloperProfilesController : ApiControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<PublicDeveloperProfileDto>> GetProfile([FromRoute] Guid id)
    {
        var profile = await Mediator.Send(new GetPublicDeveloperProfileById
        {
            Id = id
        });

        return Ok(profile);
    }
}