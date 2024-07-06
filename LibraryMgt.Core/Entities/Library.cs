using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMgt.Core.Entities
{
    public class Library
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public List<Book> Books { get; set; }
    }
}