using Microsoft.AspNetCore.Mvc;
using UwULearn.Bussines.Interfaces;
using UwULearn2.API.Extensions;
using UwULearn2.API.Models.Requests;

namespace UwULearn2.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : Controller
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<string>> LoginAsync([FromBody] UserLoginRequest request)
    {
        var user = await _authService.GetUserToLogin(request.Username, request.Password);

        if (user == null)
        {
            return Unauthorized();
        }

        var userId = this.GetUserId();

        if (userId is not null && userId.Value != user.Id)
        {
            return Forbid();
        }

        return _authService.GetToken(user);
    }
}
