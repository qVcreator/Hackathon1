using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UwULearn.Data.Entities;

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

    [HttpPatch]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> AddLesson([FromRoute] int lessonId)
    {
        return new NoContentResult();
    }

    [HttpDelete("{courseId}/lesson/{lessonId}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> DeleteLesson([FromRoute]int lessonId, [FromRoute] int courseId)
    {
        
    }

    public async Task<ActionResult> Update([FromRoute] int courseId)
    {
        
    }

    public async Task<ActionResult> Add()
    {
        
    } // course req model


    public async Task<ActionResult<Course>> Get([FromRoute] int courseId)
    {
        
    }

    public async Task<ActionResult<List<Course>>> GetAll()
    {
        
    }
    

}