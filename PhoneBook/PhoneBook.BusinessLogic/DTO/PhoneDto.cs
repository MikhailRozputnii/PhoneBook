using System;

namespace PhoneBook.BusinessLogic.DTO
{
    public class PhoneDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public UserDto User { get; set; }
    }
}