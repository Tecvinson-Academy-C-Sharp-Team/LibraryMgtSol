using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMgt.Core.Entities
{
    public class Book
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool IsBorrow { get; set; }
        public bool IsLocked { get; set; }

        public int DurationOfBorrow { get; set; }
        public DateTime BorrowDateTime { get; set; } = DateTime.Now;
        public DateTime BookReturnDate { get; set; }
    }
}