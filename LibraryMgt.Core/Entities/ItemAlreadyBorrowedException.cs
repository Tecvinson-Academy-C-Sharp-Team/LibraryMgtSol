using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMgt.Core.Entities
{
    public class ItemAlreadyBorrowedException : Exception
    {
        public ItemAlreadyBorrowedException(string message) : base(message) { }
    }
}
