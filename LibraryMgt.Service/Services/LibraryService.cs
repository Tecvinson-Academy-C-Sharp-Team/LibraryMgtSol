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

        public List<Book> books { get; set; } // Collection i.e Book DB...

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

        public Book GetBook(int id)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            return book;
        }

        public List<Book> GetBooks()
        {
            return books;
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
    }
}