using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryMgt.Core.Entities;

namespace LibraryMgt.Service.Services
{
    public class LibraryService
    {
        public LibraryService()
        { }

        /**
         * Create methods in the Library class to:
             - Add a new book to the library.
             - Borrow a book from the library.
             - Return a book to the library.
             - View all available books in the library.
            Ensure proper handling of cases where a book cannot be borrowed or returned (e.g., book is already borrowed or not found in the library).
         */

        public List<Book> books = new List<Book>(); // Collection i.e Book DB...

        // Create CRUD
        // Create
        // Read
        // Update
        // Delete
        public void AddBook(Book book)
        {
            // add a new book to the book db
            books.Add(book);
        }

        public List<Book> GetBooks()
        {
            return books;
        }

        public Book BorrowBook(long bookId, User user)
        {
            var book = books.FirstOrDefault(b => b.Id == bookId && !b.IsBorrow);
            if (book != null)
            {
                book.IsBorrow = true;
                user.BorrowedBooks.Add(book);
            }
            return book;
        }


        public void UpdateBook(Book book)
        {
            books.Remove(book);
            books.Add(book);
        }

        public void DeleteBook(int id)
        {
            books.RemoveAt(id);
        }

        public Book ReturnBook(long bookId, User user)
        {
            var book = user.BorrowedBooks.FirstOrDefault(b => b.Id == bookId);
            if (book != null)
            {
                book.IsBorrow = false;
                user.BorrowedBooks.Remove(book);
            }
            return book;
        }
    }
}