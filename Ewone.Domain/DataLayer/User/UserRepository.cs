using Ewone.Domain.DataLayer.DbMapper;

namespace Ewone.Domain.DataLayer.User;

public class UserRepository
{
    private readonly IDbMapper _dbMapper;

    public UserRepository(IDbMapper dbMapper)
    {
        _dbMapper = dbMapper;
    }

    public Task<UserEntity?> GetByEmail(string email)
    {
        return _dbMapper.QueryFirstOrDefaultAsync<UserEntity?>(@"
select *
from users
where email = :email;
", new
        {
            email,
        });
    }

    public Task Add(UserEntity entity)
    {
        return _dbMapper.ExecuteAsync(@"
insert into users(id, email, name, createdate)
values(:Id, :Email, :Name, :CreateDate);
", EnumToStringMapper.Map(entity));
    }
}