using PhoneBook.Contracts;
using PhoneBook.Domains;

namespace PhoneBook.Repositories.Data
{
    public class PhoneRepository : BaseRepository<Phone>, IPhoneRepository
    {
        public PhoneRepository(PhoneBookDbContext dbContext) : base(dbContext)
        {
        }
    }
}
