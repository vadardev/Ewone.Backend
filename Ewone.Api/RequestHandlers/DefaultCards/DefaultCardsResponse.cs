namespace Ewone.Api.RequestHandlers.DefaultCards;

public class DefaultCardsResponse
{
    public List<DefaultCardShortItem> Cards { get; set; }
}

public class DefaultCardShortItem
{
    public Guid CardId { get; set; }
    public string Word { get; set; } = null!;
    public string Definition { get; set; } = null!;
}