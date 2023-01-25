namespace Ewone.Api.RequestHandlers.AddCard;

public class AddCardRequest
{
    public string Word { get; set; } = null!;
    public string Definition { get; set; } = null!;
    public string PictureUrl { get; set; } = null!;
    public string? Example { get; set; }
    public string? OtherExample { get; set; }
}