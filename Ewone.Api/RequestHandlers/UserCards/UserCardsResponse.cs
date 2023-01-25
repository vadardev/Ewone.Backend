namespace Ewone.Api.RequestHandlers.UserCards;

public class UserCardsResponse
{
    public List<UserCardShortItem> Cards { get; set; }
}

public class UserCardShortItem
{
    public Guid UserCardId { get; set; }
    public string Word { get; set; } = null!;
    public string Definition { get; set; } = null!;
}