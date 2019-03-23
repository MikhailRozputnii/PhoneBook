﻿using System;

namespace PhoneBook.Domains
{
    public class Phone
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }

        public User User { get; set; }
    }
}
