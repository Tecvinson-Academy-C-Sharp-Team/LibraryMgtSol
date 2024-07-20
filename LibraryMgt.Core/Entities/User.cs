using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMgt.Core.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }

        
        public List<Book> BorrowedBooks { get; set; } = new List<Book>();
        /*
        public List<Magazine> BorrowedItems { get; set; } = new List<Magazine>();
        public List<DVD> BorrowedItems { get; set; } = new List<DVD>();
        */
        public List<LibraryItem> BorrowedItems { get; set; } = new List<LibraryItem>();
    }
}