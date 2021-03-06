﻿using System;
using System.Collections.Generic;

namespace PhoneBook.Domains
{
    public class User 
    {
        public Guid Id { get; set; } 
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public string PasswordHash { get; set; }
        public bool IsDeleted { get; set; }

        public IEnumerable<Phone> Phones { get; set; }
    }
}
