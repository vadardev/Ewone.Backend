using Ewone.Domain.DataLayer.DbMapper;

namespace Ewone.Domain.DataLayer.Word;

public class WordRepository
{
    private readonly IDbMapper _dbMapper;

    public WordRepository(IDbMapper dbMapper)
    {
        _dbMapper = dbMapper;
    }

    public Task<WordEntity?> GetByName(string name)
    {
        return _dbMapper.QueryFirstOrDefaultAsync<WordEntity?>(@"
select *
from words
where name = :name;
", new
        {
            name
        });
    }

    public Task Add(WordEntity entity)
    {
        return _dbMapper.ExecuteAsync(@"
insert into words(id, name)
values (:id, :name)", EnumToStringMapper.Map(entity));
    }
}