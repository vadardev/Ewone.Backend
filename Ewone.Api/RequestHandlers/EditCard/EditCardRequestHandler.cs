using Ewone.Domain.DataLayer.Card;
using Ewone.Domain.DataLayer.Card.Entities;
using Ewone.Domain.DataLayer.UserCard;
using Ewone.Domain.DataLayer.Word;

namespace Ewone.Api.RequestHandlers.EditCard;

public class EditCardRequestHandler
{
    private readonly WordRepository _wordRepository;
    private readonly UserCardRepository _userCardRepository;
    private readonly CardRepository _cardRepository;

    public EditCardRequestHandler(WordRepository wordRepository,
        UserCardRepository userCardRepository,
        CardRepository cardRepository)
    {
        _wordRepository = wordRepository;
        _userCardRepository = userCardRepository;
        _cardRepository = cardRepository;
    }

    public async Task Handle(EditCardRequest request, Guid userId)
    {
        UserCardEntity? userCard = await _userCardRepository.GetById(request.UserCardId);

        if (userCard != null)
        {
            CardEntity? card = await _cardRepository.GetById(userCard.IdCard);

            if (card != null)
            {
                string wordName = request.Body.Word.ToLower();

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

                // если клиент редактирует свою карточку
                if (card.IdAuthor == userId)
                {
                    await _cardRepository.Edit(new CardEntity
                    {
                        Id = card.Id,
                        IdWord = word.Id,
                        Definition = request.Body.Definition,
                        PictureUrl = request.Body.PictureUrl,
                        Example = request.Body.Example,
                        OtherExample = request.Body.OtherExample,
                        IdParent = card.IdParent,
                        IdAuthor = card.IdAuthor,
                    });
                }
                else
                {
                    Guid newCardId = Guid.NewGuid();

                    await _cardRepository.Add(new CardEntity
                    {
                        Id = newCardId,
                        IdWord = word.Id,
                        Definition = request.Body.Definition,
                        PictureUrl = request.Body.PictureUrl,
                        Example = request.Body.Example,
                        OtherExample = request.Body.OtherExample,
                        IdParent = card.Id,
                        IdAuthor = userId,
                    });

                    await _userCardRepository.ChangeCardId(request.UserCardId, newCardId);
                }
            }
        }
    }
}