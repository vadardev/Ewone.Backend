using Newtonsoft.Json.Linq;

namespace Ewone.Domain.DataLayer.Card.Entities;

public class CardEntity
{
    public Guid Id { get; set; }
    public Guid IdWord { get; set; }
    public string Definition { get; set; } = null!;
    public string? PictureUrl { get; set; }
    public string? Example { get; set; }
    public string? OtherExample { get; set; }
    public Guid? IdParent { get; set; }
    public Guid? IdAuthor { get; set; }
}