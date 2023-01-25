using Ewone.Domain.DataLayer.DbMapper;

namespace Ewone.Domain.DataLayer.UserCard;

public class UserCardRepository
{
    private readonly IDbMapper _dbMapper;

    public UserCardRepository(IDbMapper dbMapper)
    {
        _dbMapper = dbMapper;
    }

    public Task Add(UserCardEntity entity)
    {
        return _dbMapper.ExecuteAsync(@"
insert into usercards(id, iduser, idcard)
values(:id, :iduser, :idcard);
", EnumToStringMapper.Map(entity));
    }

    public Task Delete(Guid userCardId)
    {
        return _dbMapper.ExecuteAsync(@"
delete from usercards
where id = :userCardId;
", new
        {
            userCardId,
        });
    }

    public Task ChangeCardId(Guid userCardId, Guid cardId)
    {
        return _dbMapper.ExecuteAsync(@"
update userCards set idCard = :cardId
where id = :userCardId;
", new
        {
            userCardId,
            cardId,
        });
    }

    public Task<UserCardEntity?> GetById(Guid userCardId)
    {
        return _dbMapper.QueryFirstOrDefaultAsync<UserCardEntity?>(@"
select *
from userCards 
where id = :userCardId;
", new
        {
            userCardId,
        });
    }

    public Task<UserCardView?> Get(Guid userCardId)
    {
        return _dbMapper.QueryFirstOrDefaultAsync<UserCardView?>(@"
select uc.id as userCardId, w.name as word, c.definition, c.pictureUrl, c.example, c.otherExample
from userCards uc
join cards c on c.id = uc.idCard
join words w on w.id = c.idWord
where uc.id = :userCardId;
", new
        {
            userCardId,
        });
    }
}