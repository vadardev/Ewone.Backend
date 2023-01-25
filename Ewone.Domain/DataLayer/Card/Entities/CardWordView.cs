namespace Ewone.Domain.DataLayer.Card.Entities;

public class CardWordView
{
    public Guid CardId { get; set; }
    public string Word { get; set; } = null!;
    public string Definition { get; set; } = null!;
}