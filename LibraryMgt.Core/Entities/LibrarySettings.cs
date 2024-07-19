using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMgt.Core.Entities
{
    public static class LibrarySettings
    {
        public static int TotalItemsBorrowed { get; private set; }
        public static string OpeningHours { get; set; } = "9 AM - 5 PM";
        public static void IncrementBorrowedItems()
        {
            TotalItemsBorrowed++;
        }
        public static void DecrementBorrowedItems()
        {
            TotalItemsBorrowed--;
        }
    }
}
