using Microsoft.AspNetCore.Mvc;

namespace Ewone.Api.RequestHandlers.DeleteCard;

public class DeleteCardRequest
{
    [FromRoute(Name = "userCardId")] public Guid UserCardId { get; set; }
}