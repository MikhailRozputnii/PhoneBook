using PhoneBook.BusinessLogic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBook.BusinessLogic.Contracts
{
    public interface IPhoneService
    {
        PhoneDto Create(PhoneDto phoneDto, Guid userId);
        (IEnumerable<PhoneDto>, int) GetPhones(ref int curentPage, int pageSize, string search, Guid userId);
    }
}
