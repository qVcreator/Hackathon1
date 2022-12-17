using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    public CoursesController()
    {
        //di
    }

    [HttpPatch("{courseId}/lesson/{lessonId}")]
    [AuthorizeByRole(Role.Admin)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> AddLesson([FromRoute] int courseId, [FromRoute] int lessonId)
    {
        return new NoContentResult();
    }

    [HttpDelete("{courseId}/lesson/{lessonId}")]
    [AuthorizeByRole(Role.Admin)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> DeleteLesson([FromRoute]int lessonId, [FromRoute] int courseId)
    {
        return new NoContentResult();
    }

    [HttpPut("{courseId}")]
    [AuthorizeByRole(Role.Admin)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Update([FromRoute] int courseId, [FromBody] UpdateCourseRequest updateCourse)
    {
        return new NoContentResult();
    }

    [HttpPost]
    [AuthorizeByRole(Role.Admin)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<ActionResult<int>> Add([FromBody] AddCourseRequest newCourse)
    {
        return Created(this.GetUri(), 1);
    }

    [HttpGet("{couseId}")]
    [AuthorizeByRole(Role.Admin, Role.User)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetCourseAllInfoResponse>> Get([FromRoute] int courseId)
    {
        return Ok();
    }

    [HttpGet()]
    [AuthorizeByRole(Role.Admin, Role.User)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<GetAllCoursesResponse>>> GetAll()
    {
        return Ok();
    }
}