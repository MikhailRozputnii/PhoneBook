using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneBook.Domains
{
    public class Phone
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }

        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
