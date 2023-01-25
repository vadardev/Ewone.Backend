using Ewone.Domain.DataLayer.Card;

namespace Ewone.Api.RequestHandlers.DefaultCards;

public class DefaultCardsRequestHandler
{
    private readonly CardRepository _cardRepository;

    public DefaultCardsRequestHandler(CardRepository cardRepository)
    {
        _cardRepository = cardRepository;
    }

    public async Task<DefaultCardsResponse> Handle()
    {
        return new DefaultCardsResponse
        {
            Cards = (await _cardRepository.GetDefaultCards()).Select(x => new DefaultCardShortItem
            {
                CardId = x.CardId,
                Word = x.Word,
                Definition = x.Definition,
            }).ToList()
        };
    }
}