using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UwULearn.Bussines.Interfaces;
using UwULearn2.API.Models.Responses;
using AutoMapper;
using UwULearn2.API.Infrastructure;
using UwULearn.Data.Enums;
using UwULearn.Data.Entities;
using UwULearn2.API.Models.Requests;
using UwULearn2.API.Extensions;

namespace UwULearn2.API.Controllers;

[Authorize]
[ApiController]
[Produces("application/json")]
[Route("[controller]")]
public class SkinsController : Controller
{
    private readonly IMapper _mapper;
    private readonly ISkinsService _skinsService;

    public SkinsController(IMapper mapper, ISkinsService skinsService)
    {
        _mapper = mapper;
        _skinsService = skinsService;
    }

    [HttpGet("{id}")]
    [AuthorizeByRole(Role.User, Role.Admin)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<SkinResponse>> GetSkin([FromRoute] int id)
    {
        var result = await _skinsService.GetSkin(id);
        return Ok(_mapper.Map<SkinResponse>(result));
    }

    [HttpPost]
    [AuthorizeByRole(Role.Admin)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<int>> AddSkin([FromBody] AddSkinRequest newSkin)
    {
        var result = await _skinsService.AddSkin(_mapper.Map<Skin>(newSkin));
        return Created(this.GetUri(), result);
    }
}
