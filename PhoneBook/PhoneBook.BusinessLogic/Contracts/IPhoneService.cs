using PhoneBook.BusinessLogic.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.BusinessLogic.Contracts
{
    public interface IPhoneService
    {
        PhoneDto Create(PhoneDto phoneDto, Guid Id);
    }
}
