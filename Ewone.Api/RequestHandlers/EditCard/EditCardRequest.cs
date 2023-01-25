using Microsoft.AspNetCore.Mvc;

namespace Ewone.Api.RequestHandlers.EditCard;

public class EditCardRequest
{
    [FromRoute(Name = "userCardId")] public Guid UserCardId { get; set; }
    [FromBody] public EditCardBody Body { get; set; }
}

public class EditCardBody
{
    public string Word { get; set; } = null!;
    public string Definition { get; set; } = null!;
    public string PictureUrl { get; set; } = null!;
    public string? Example { get; set; }
    public string? OtherExample { get; set; }
}