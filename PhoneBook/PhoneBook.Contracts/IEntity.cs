﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Contracts
{
    public interface IEntity
    {
        Guid Id { get;set; }
    }
}
