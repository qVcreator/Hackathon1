﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UwULearn.Bussines.Interfaces;
using UwULearn.Data.Entities;
using UwULearn.Data.Enums;
using UwULearn2.API.Extensions;
using UwULearn2.API.Infrastructure;
using UwULearn2.API.Models.Requests;

namespace UwULearn2.API.Controllers;

[Authorize]
[ApiController]
[Produces("application/json")]
[Route("[controller]")]
public class LessonsController : Controller
{
    private readonly IMapper _mapper;
    private readonly ILessonsService _lessonsService;

    public LessonsController(IMapper mapper, ILessonsService lessonsService)
    {
        _mapper = mapper;
        _lessonsService = lessonsService;
    }

    [HttpPost]
    [AuthorizeByRole(Role.Admin)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<ActionResult<int>> CreateLesson([FromBody] AddLessonRequest newLesson)
    {
        var result = await _lessonsService.CreateLesson(_mapper.Map<Lesson>(newLesson));
        return Created(this.GetUri(), result);
    }

    [HttpPut("{id}")]
    [AuthorizeByRole(Role.Admin)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<ActionResult> UpdateLesson([FromRoute] int id, [FromBody] UpdateLessonRequest updateLessonRequest)
    {
        await _lessonsService.UpdateLesson(id, _mapper.Map<Lesson>(updateLessonRequest));
        return NoContent();
    }

    [HttpDelete("{id}")]
    [AuthorizeByRole(Role.Admin)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult> DeleteLesson([FromRoute] int id)
    {
        await _lessonsService.DeleteLesson(id);
        return NoContent();
    }
}
