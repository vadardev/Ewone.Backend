using Ewone.Domain.DataLayer.Card;
using Ewone.Domain.DataLayer.Card.Entities;

namespace Ewone.Api.RequestHandlers.DefaultCard;

public class DefaultCardRequestHandler
{
    private readonly CardRepository _cardRepository;

    public DefaultCardRequestHandler(CardRepository cardRepository)
    {
        _cardRepository = cardRepository;
    }

    public async Task<DefaultCardResponse> Handle(DefaultCardRequest request)
    {
        DefaultCardView? card = await _cardRepository.GetDefaultCard(request.CardId);

        return new DefaultCardResponse
        {
            CardId = card.CardId,
            Word = card.Word,
            Definition = card.Definition,
            PictureUrl = card.PictureUrl,
            Example = card.Example,
            OtherExample = card.OtherExample,
        };
    }
}