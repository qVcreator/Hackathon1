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
public class ChatController : Controller
{
    private readonly IMapper _mapper;
    private readonly IChatService _chatService;    

    public ChatController(IMapper mapper, IChatService chatService)
    {
        _mapper = mapper;
        _chatService = chatService;
    }

    [HttpPost]
    [AuthorizeByRole(Role.User, Role.Admin)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<ActionResult<int>> PublishMessage([FromBody] AddAllChatMessageRequest newMessage)
    {
        newMessage.From = (int)this.GetUserId()!;
        var result = await _chatService.PublishMessage(_mapper.Map<AllChatMessage>(newMessage));
        return Created(this.GetUri(), result);
    }

    [HttpGet]
    [AuthorizeByRole(Role.User, Role.Admin)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<List<AllChatMessageResponse>>> GetMessages()
    {
        var result = await _chatService.GetMessages();
        return Ok(_mapper.Map<List<AllChatMessageResponse>>(result));
    }
}
