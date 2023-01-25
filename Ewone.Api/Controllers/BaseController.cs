using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Ewone.Api.Controllers;

public class BaseController : ControllerBase
{
    protected Guid GetUserId()
    {
        return new Guid(User.FindFirstValue(ClaimTypes.Name));
    }
}