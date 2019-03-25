using System;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Models
{
    public class PhoneViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        public long PhoneNumber { get; set; }

        [StringLength(250, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
