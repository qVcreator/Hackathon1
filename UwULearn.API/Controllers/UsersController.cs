using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UwULearn.Bussines.Interfaces;
using UwULearn.Data.Enums;
using UwULearn.Data.Models;
using UwULearn2.API.Extensions;
using UwULearn2.API.Infrastructure;
using UwULearn2.API.Models.Requests;

namespace UwULearn2.API.Controllers;

[Authorize]
[ApiController]
[Produces("application/json")]
[Route("[controller]")]
public class UsersController : Controller
{

    private readonly IMapper _mapper;
    private readonly IUsersService _usersService;
    public UsersController(IMapper mapper, IUsersService usersService)
    {
        _mapper = mapper;
        _usersService = usersService;
    }

    [HttpPatch]
    [AuthorizeByRole(Role.Admin, Role.User)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> UpdatePassword([FromBody] UpdatePasswordRequest updatePasswordRequest)
    {
        await _usersService.ChangePassword(_mapper.Map<UpdatePasswordModel>(updatePasswordRequest));
        return NoContent();
    }

    [HttpPatch("cat-skin/{skinId}")]
    [AuthorizeByRole(Role.Admin, Role.User)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateCatSkin([FromRoute] int skinId)
    {
        var userId = this.GetUserId();

        if(userId is null)
            return BadRequest();
        else
            await _usersService.ChangeCatsSkin((int)userId, skinId);

        return NoContent();
    }

    
    [HttpPatch("course/{courseId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> AddCourse([FromRoute] int courseId)
    {
        var userId = this.GetUserId();

        if (userId is null)
            return BadRequest();
        else
            await _usersService.AddCourse((int)userId, courseId);

        return NoContent();
    }
}