using System;
using System.Collections.Generic;

namespace PhoneBook.Domains
{
    public class User 
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool IsDeleted { get; set; }

        public IEnumerable<Phone> Phones { get; set; }
    }
}
