using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMgt.Core.Entities
{
    public class Book : LibraryItem, IBorrowable
    {
        public bool IsBorrowed { get; set; }
        public override string GetDetails()
        {
            return $"{Title} by {Author}, ISBN: {ISBN}";
        }
        public void Borrow(User user)
        {
            if (!IsBorrowed)
            {
                IsBorrowed = true;
                user.BorrowedBooks.Add(this);
            }
            else
            {
                throw new ItemAlreadyBorrowedException($"{Title} is already borrowed.");
            }
        }
        public void Return(User user)
        {
            if (IsBorrowed)
            {
                IsBorrowed = false;
                user.BorrowedBooks.Remove(this);
            }
            else
            {
                throw new
                    ItemNotFoundException($"{Title} was not borrowed.");
            }
        }
        public bool IsLocked {  get; set; }
        public bool IsBorrow { get; set; }
    }
}