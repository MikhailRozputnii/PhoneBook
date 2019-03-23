using PhoneBook.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Domains
{
    public class User : IEntity
    {
        public Guid Id { get; set; }
        public string Email {get;set;}
        public string PasswordHash { get; set; }
        public bool IsDeleted { get; set; }

        public IEnumerable<Phone> Phones { get; set; }
    }
}
