using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMgt.Core.Entities
{
    // Base class
    public class BaseUser
    {
        public long Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public List<Book> BorrowedBooks { get; set; } = new List<Book>();
    }
}