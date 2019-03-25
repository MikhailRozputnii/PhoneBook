using System;
using System.Collections.Generic;

namespace PhoneBook.BusinessLogic.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public string PasswordHash { get; set; }
        public bool IsDeleted { get; set; }
        public IEnumerable<PhoneDto> Phones { get; set; }
    }
}
