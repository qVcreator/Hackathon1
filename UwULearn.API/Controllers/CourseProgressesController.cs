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
public class CourseProgressesController : Controller
{
    private readonly ICourseProgressService _courseProgressService;
    public CourseProgressesController(ICourseProgressService courseProgressService)
    {
        _courseProgressService = courseProgressService;
    }

    [HttpGet("leader-board-top-ten")]
    [AuthorizeByRole(Role.Admin)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> GetLeaderBoardTopTen()
    {
        var result = await _courseProgressService.GetLeaderBoardTopTen();
        return Ok(result);
    }

    [HttpGet("user/{id}")]
    [AuthorizeByRole(Role.Admin)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> GetProgressByUserId([FromRoute] int id)
    {
        var result = await _courseProgressService.GetProgressByUserId(id);
        return Ok(result);
    }
}
