using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMgt.Core.Entities
{
    public class Magazine : LibraryItem, IBorrowable
    {
        public string IssueNumber { get; set; }
        public bool IsBorrowed { get; set; }
        public override string GetDetails()
        {
            return $"{Title} by {Author}, Issue: {IssueNumber}";
        }
        public void Borrow(User user)
        {
            if (IsBorrowed) throw new ItemAlreadyBorrowedException("This magazine is already borrowed.");
            IsBorrowed = true;
            user.BorrowedItems.Add(this);
        }
        public void Return(User user)
        {
            if (!IsBorrowed) throw new ItemNotFoundException("This magazine is not borrowed.");
            IsBorrowed = false;
            user.BorrowedItems.Remove(this);
        }
    }
}