using UsersApi.Data.Entites;
using UsersApi.Data.Repositories.Interfaces;

namespace UsersApi.Data.Repositories;

public class UsersRepository : BaseRepository<User>, IUsersRepository
{
    public UsersRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
    
}