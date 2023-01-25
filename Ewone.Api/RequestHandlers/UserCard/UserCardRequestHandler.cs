using Ewone.Domain.DataLayer.UserCard;

namespace Ewone.Api.RequestHandlers.UserCard;

public class UserCardRequestHandler
{
    private readonly UserCardRepository _userCardRepository;

    public UserCardRequestHandler(UserCardRepository userCardRepository)
    {
        _userCardRepository = userCardRepository;
    }

    public async Task<UserCardResponse> Handle(UserCardRequest request, Guid userId)
    {
        UserCardView? card = await _userCardRepository.Get(request.UserCardId);

        return new UserCardResponse
        {
            UserCardId = card.UserCardId,
            Word = card.Word,
            Definition = card.Definition,
            PictureUrl = card.PictureUrl,
            Example = card.Example,
            OtherExample = card.OtherExample,
        };
    }
}