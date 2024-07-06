﻿using System;
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

        public Book BorrowBook(string title, User user)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException("The name of the book is required!");

            if (user is not null)
                throw new ArgumentNullException("The user must be a valid user!");

            var book = GetBooks().FirstOrDefault(b => b.Title == title);
            if (book == null && book.IsLocked)
                throw new ArgumentNullException("The book you want borrow is not available right now.");

            book.IsLocked = true;
            UpdateBook(book);
            return book;
        }

        public void ReturnBorrow(Book book)
        {
            if (book is null)
                throw new ArgumentNullException("You must provide a book!");

            book.IsLocked = false;

            UpdateBook(book);
        }
    }
}