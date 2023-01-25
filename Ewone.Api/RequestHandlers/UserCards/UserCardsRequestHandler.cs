using Ewone.Domain.DataLayer.Card;

namespace Ewone.Api.RequestHandlers.UserCards;

public class UserCardsRequestHandler
{
    private readonly CardRepository _cardRepository;

    public UserCardsRequestHandler(CardRepository cardRepository)
    {
        _cardRepository = cardRepository;
    }

    public async Task<UserCardsResponse> Handle(Guid userId)
    {
        return new UserCardsResponse
        {
            Cards = (await _cardRepository.GetUserCards(userId)).Select(x => new UserCardShortItem
            {
                UserCardId = x.IdUserCard,
                Word = x.Word,
                Definition = x.Definition,
            }).ToList()
        };
    }
}