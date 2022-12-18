using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UwULearn.Bussines.Interfaces;
using UwULearn.Data.Enums;
using UwULearn2.API.Infrastructure;
using UwULearn2.API.Models.Responses;

namespace UwULearn2.API.Controllers;

[Authorize]
[ApiController]
[Produces("application/json")]
[Route("[controller]")]
public class CourseProgressesController : Controller
{
    private readonly ICourseProgressService _courseProgressService;
    private readonly IMapper _mapper;
    public CourseProgressesController(ICourseProgressService courseProgressService, IMapper mapper)
    {
        _courseProgressService = courseProgressService;
        _mapper = mapper;
    }

    [HttpGet("leader-board-top-ten")]
    [AuthorizeByRole(Role.Admin)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<List<UsersResponse>>> GetLeaderBoardTopTen()
    {
        var result = await _courseProgressService.GetLeaderBoardTopTen();
        return Ok(_mapper.Map<UsersResponse>(result));
    }

    [HttpGet("user/{id}")]
    [AuthorizeByRole(Role.Admin)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<CourseProgressResponse>> GetProgressByUserId([FromRoute] int id)
    {
        var result = await _courseProgressService.GetProgressByUserId(id);
        return Ok(_mapper.Map<CourseProgressResponse>(result));
    }
}
