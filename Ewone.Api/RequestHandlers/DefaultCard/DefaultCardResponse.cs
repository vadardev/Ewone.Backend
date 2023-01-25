namespace Ewone.Api.RequestHandlers.DefaultCard;

public class DefaultCardResponse
{
    public Guid CardId { get; set; }
    public string Word { get; set; } = null!;
    public string Definition { get; set; } = null!;
    public string PictureUrl { get; set; } = null!;
    public string? Example { get; set; }
    public string? OtherExample { get; set; }
}