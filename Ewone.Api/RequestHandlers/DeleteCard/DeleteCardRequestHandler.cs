using Ewone.Domain.DataLayer.UserCard;

namespace Ewone.Api.RequestHandlers.DeleteCard;

public class DeleteCardRequestHandler
{
    private readonly UserCardRepository _userCardRepository;

    public DeleteCardRequestHandler(UserCardRepository userCardRepository)
    {
        _userCardRepository = userCardRepository;
    }

    public Task Handle(DeleteCardRequest request)
    {
        return _userCardRepository.Delete(request.UserCardId);
    }
}