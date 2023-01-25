using Ewone.Api.RequestHandlers.Login;
using Microsoft.AspNetCore.Mvc;

namespace Ewone.Api.Controllers;

[ApiController]
[Route("api/accounts")]
public class AccountController : ControllerBase
{
    private readonly LoginRequestHandler _loginRequestHandler;

    public AccountController(LoginRequestHandler loginRequestHandler)
    {
        _loginRequestHandler = loginRequestHandler;
    }

    [HttpPost("login")]
    public Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        return _loginRequestHandler.Handle(request);
    }
}