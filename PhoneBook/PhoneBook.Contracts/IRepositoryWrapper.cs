using System;

namespace PhoneBook.Contracts
{
    public interface IRepositoryWrapper: IDisposable
    {
        IUserRepository User { get; }
        IPhoneRepository Phone { get; }
        void Save();
    }
}
