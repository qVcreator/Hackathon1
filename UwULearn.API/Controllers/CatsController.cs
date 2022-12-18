using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UwULearn.Bussines.Interfaces;
using UwULearn.Data.Enums;
using UwULearn2.API.Infrastructure;

namespace UwULearn2.API.Controllers;

[Authorize]
[ApiController]
[Produces("application/json")]
[Route("[controller]")]
public class CatsController : Controller
{
    private readonly IMapper _mapper;
    private readonly ICatsService _catsService;

    public CatsController(IMapper mapper, ICatsService catsService)
    {
        _mapper = mapper;
        _catsService = catsService;
    }

    [HttpPatch("{catId}/name")]
    [AuthorizeByRole(Role.User, Role.Admin)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult> RenameCat([FromRoute] int catId, [FromBody] string newName)
    {
        await _catsService.Rename(catId, newName);
        return NoContent();
    }


    [HttpPatch("{catId}/health")]
    [AuthorizeByRole(Role.Admin)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> HealthUpdate([FromRoute] int catId, [FromBody] int newHealth)
    {
        await _catsService.HealthUpdate(catId, newHealth);
        return NoContent();
    }

    [HttpGet("{catId}")]
    [AuthorizeByRole(Role.Admin, Role.User)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<int>> GetHealth([FromRoute] int catId)
    {
        var result = await _catsService.GetHealth(catId);
        return Ok(result);
    }
}
