using PhoneBook.Contracts;
using PhoneBook.Domains;

namespace PhoneBook.Repositories.Data
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(PhoneBookDbContext dbContext) : base(dbContext)
        {

        }
    }
}
