using Microsoft.AspNetCore.Mvc;

namespace Ewone.Api.RequestHandlers.UserCard;

public class UserCardRequest
{
    [FromRoute(Name = "userCardId")] public Guid UserCardId { get; set; }
}