using Ewone.Domain.DataLayer.Card;
using Ewone.Domain.DataLayer.Card.Entities;
using Ewone.Domain.DataLayer.UserCard;
using Ewone.Domain.DataLayer.Word;

namespace Ewone.Api.RequestHandlers.AddCard;

public class AddCardRequestHandler
{
    private readonly WordRepository _wordRepository;
    private readonly UserCardRepository _userCardRepository;
    private readonly CardRepository _cardRepository;

    public AddCardRequestHandler(WordRepository wordRepository,
        UserCardRepository userCardRepository,
        CardRepository cardRepository)
    {
        _wordRepository = wordRepository;
        _userCardRepository = userCardRepository;
        _cardRepository = cardRepository;
    }

    public async Task Handle(AddCardRequest request, Guid userId)
    {
        string wordName = request.Word.ToLower();

        WordEntity? word = await _wordRepository.GetByName(wordName);

        if (word == null)
        {
            word = new WordEntity
            {
                Id = Guid.NewGuid(),
                Name = wordName,
            };

            await _wordRepository.Add(word);
        }

        Guid newCardId = Guid.NewGuid();

        await _cardRepository.Add(new CardEntity
        {
            Id = newCardId,
            IdWord = word.Id,
            Definition = request.Definition,
            PictureUrl = request.PictureUrl,
            Example = request.Example,
            OtherExample = request.OtherExample,
            IdParent = null,
            IdAuthor = userId,
        });

        await _userCardRepository.Add(new UserCardEntity
        {
            Id = Guid.NewGuid(),
            IdUser = userId,
            IdCard = newCardId,
        });
    }
}