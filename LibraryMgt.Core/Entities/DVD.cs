using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMgt.Core.Entities
{
    public class DVD : LibraryItem, IBorrowable
    {
        public string Duration { get; set; }
        public bool IsBorrowed { get; set; }
        public string Director { get; set; }
        public override string GetDetails()
        {
            return $"{Title} directed by {Director}, \nDuration: {Duration}";
        }
        public void Borrow(User user)
        {
            if (IsBorrowed) throw new ItemAlreadyBorrowedException("This DVD is already borrowed.");
            IsBorrowed = true;
            user.BorrowedItems.Add(this);
        }
        public void Return(User user)
        {
            if (!IsBorrowed) throw new ItemNotFoundException("This DVD is not borrowed.");
            IsBorrowed = false;
            user.BorrowedItems.Remove(this);
        }
    }
}
