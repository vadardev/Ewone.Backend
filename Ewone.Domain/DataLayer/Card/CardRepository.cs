using Ewone.Domain.DataLayer.Card.Entities;
using Ewone.Domain.DataLayer.DbMapper;

namespace Ewone.Domain.DataLayer.Card;

public class CardRepository
{
    private readonly IDbMapper _dbMapper;

    public CardRepository(IDbMapper dbMapper)
    {
        _dbMapper = dbMapper;
    }

    public Task<IEnumerable<CardWordView>> GetDefaultCards()
    {
        return _dbMapper.QueryAsync<CardWordView>(@"
select c.id as cardid, w.name as word, c.definition
from cards c
join words w on w.id = c.idword
where c.isDefault = true;
");
    }

    public Task<DefaultCardView?> GetDefaultCard(Guid cardId)
    {
        return _dbMapper.QueryFirstOrDefaultAsync<DefaultCardView?>(@"
select c.id as cardid, w.name as word, c.definition, c.pictureUrl, c.example, c.otherExample
from cards c
join words w on w.id = c.idword
where c.id = :cardId and c.isDefault = true;
", new
        {
            cardId,
        });
    }

    public Task<IEnumerable<UserCardWordView>> GetUserCards(Guid userId)
    {
        return _dbMapper.QueryAsync<UserCardWordView>(@"
select uc.id as idusercard, w.name as word, c.definition
from usercards uc
join cards c on c.id = uc.idcard
join words w on w.id = c.idword
where uc.iduser = :userid;
", new
        {
            userId,
        });
    }

    public Task<CardEntity?> GetById(Guid cardId)
    {
        return _dbMapper.QueryFirstOrDefaultAsync<CardEntity?>(@"
select *
from cards
where id = :cardId;
", new
        {
            cardId,
        });
    }

    public Task Add(CardEntity entity)
    {
        return _dbMapper.ExecuteAsync(@"
insert into cards(id, idword, definition, pictureurl, example, otherexample, idparent, idauthor)
values(:Id, :IdWord, :Definition, :PictureUrl, :Example, :OtherExample, :IdParent, :IdAuthor);
", EnumToStringMapper.Map(entity));
    }

    public Task Edit(CardEntity entity)
    {
        return _dbMapper.ExecuteAsync(@"
update cards set idword = :IdWord, definition = :Definition, pictureurl = :PictureUrl, example = :Example, otherExample = :OtherExample, idparent = :IdParent, idauthor = :IdAuthor
where id = :Id;
", EnumToStringMapper.Map(entity));
    }
}