using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMgt.Core.Entities
{
    public interface IBorrowable
    {
        void Borrow(User user);
        void Return(User user);
        bool IsBorrowed { get; }
    }
}
