using PhoneBook.Contracts;
using PhoneBook.Repositories.Data;
using System;

namespace PhoneBook.Repositories.Service
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private PhoneBookDbContext _dbContext;
        private IUserRepository _user;
        private IPhoneRepository _phone;

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_dbContext);
                }
                return _user;
            }
        }

        public IPhoneRepository Phone
        {
            get
            {
                if (_phone == null)
                {
                    _phone = new PhoneRepository(_dbContext);
                }
                return _phone;
            }
        }

        public RepositoryWrapper(PhoneBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
                this._disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
