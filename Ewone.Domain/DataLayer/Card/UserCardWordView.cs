namespace Ewone.Domain.DataLayer.Card;

public class UserCardWordView
{
    public Guid IdUserCard { get; set; }
    public string Word { get; set; } = null!;
    public string Definition { get; set; } = null!;
}