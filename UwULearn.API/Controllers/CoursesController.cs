using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UwULearn.Bussines.Interfaces;
using UwULearn.Data.Entities;
using UwULearn.Data.Enums;
using UwULearn2.API.Extensions;
using UwULearn2.API.Infrastructure;
using UwULearn2.API.Models.Requests;
using UwULearn2.API.Models.Responses;

namespace UwULearn2.API.Controllers;

[Authorize]
[ApiController]
[Produces("application/json")]
[Route("[controller]")]
public class CoursesController : Controller
{
    private readonly IMapper _mapper;
    private readonly ICoursesService _coursesService;

    public CoursesController(IMapper mapper, ICoursesService coursesService)
    {
        _mapper = mapper;
        _coursesService = coursesService;
    }

    [HttpPost]
    [AuthorizeByRole(Role.Admin)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<ActionResult<int>> Add([FromBody] AddCourseRequest newCourse) =>
        await _coursesService.Add(_mapper.Map<Course>(newCourse));

    [HttpGet("{courseId}")]
    [AuthorizeByRole(Role.Admin, Role.User)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetCourseAllInfoResponse>> Get([FromRoute] int courseId)
    {
        var result = await _coursesService.Get(courseId);
        return Ok(_mapper.Map<GetCourseAllInfoResponse>(result));
    }

    [HttpGet()]
    [AuthorizeByRole(Role.Admin, Role.User)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<GetAllCoursesResponse>>> GetAll()
    {
        var result = await _coursesService.GetAll();
        return Ok(_mapper.Map<List<GetAllCoursesResponse>>(result));
    }

    [HttpPut("{courseId}")]
    [AuthorizeByRole(Role.Admin)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Update([FromRoute] int courseId, [FromBody] UpdateCourseRequest updateCourse)
    {
        await _coursesService.Update(courseId, _mapper.Map<Course>(updateCourse));
        return NoContent();
    }

    [HttpPatch("{courseId}/lesson/{lessonId}")]
    [AuthorizeByRole(Role.Admin)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> AddLesson([FromRoute] int courseId, [FromBody] AddLessonRequest lesson)
    {
        await _coursesService.AddLesson(courseId, _mapper.Map<Lesson>(lesson));
        return NoContent();
    }

    [HttpDelete("{courseId}/lesson/{lessonId}")]
    [AuthorizeByRole(Role.Admin)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> DeleteLesson([FromRoute]int lessonId, [FromRoute] int courseId)
    {
        await _coursesService.DeleteLesson(courseId, lessonId);
        return NoContent();
    }
}