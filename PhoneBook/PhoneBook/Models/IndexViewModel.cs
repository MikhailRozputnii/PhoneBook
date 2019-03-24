using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Models
{
    public class IndexViewModel
    {
        public int PageSize = 5;
        public int CurrentPage { get; set; }
        public string Search { get; set; }
        public IEnumerable<PhoneViewModel> Phones { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
