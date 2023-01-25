using Microsoft.AspNetCore.Mvc;

namespace Ewone.Api.RequestHandlers.DefaultCard;

public class DefaultCardRequest
{
    [FromRoute(Name = "cardId")] public Guid CardId { get; set; }
}