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
            var book = books.OfType<Book>().FirstOrDefault(b => b.Id == bookId && !b.IsBorrowed);
            if (book != null)
            {
                try
                {
                    book.Borrow(user);
                    LibrarySettings.IncrementBorrowedItems();
                }
                catch (ItemAlreadyBorrowedException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Book not available for borrowing.");
            }
            return book;
        }
        public Book ReturnBook(long bookId, User user)
        {
            var book = user.BorrowedBooks.OfType<Book>().FirstOrDefault(b => b.Id == bookId);
            if (book != null)
            {
                try
                {
                    book.Return(user);
                    LibrarySettings.DecrementBorrowedItems();
                }
                catch (ItemNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("You have not borrowed this book.");
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


        //  Collection of Library items
        public List<LibraryItem> items = new List<LibraryItem>();
        
        public void AddLibraryItem(LibraryItem item)
        {
            items.Add(item);
        }
        public List<LibraryItem>
            GetLibraryItems()
        {
            return items;
        }
        public LibraryItem BorrowItem(long itemId, User user)
        {
            var item = items.FirstOrDefault(i => i.Id == itemId && i is IBorrowable && !(i as IBorrowable).IsBorrowed);
            if (item != null && item is IBorrowable borrowable)
            {
                borrowable.Borrow(user);
            }
            return item;
        }
        public LibraryItem ReturnItem(long itemId, User user)
        {
            var item = items.FirstOrDefault(i => i.Id == itemId && i is IBorrowable borrowable && borrowable.IsBorrowed);
            if (item != null && item is IBorrowable borrowable)
            {
                borrowable.Return(user);
            }
            return item;
        }
    }
}