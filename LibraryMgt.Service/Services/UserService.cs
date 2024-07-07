using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryMgt.Core.Entities;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryMgt.Service.Services
{
    public class UserService
    {
        public List<User> users = new List<User>();
        private readonly LibraryService _libraryService;

        public UserService(LibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        // Create CRUD
        // Create
        // Read
        // Update
        // Delete
        public void CreateUser(User user)
        {
            // add a new user to the book db
            users.Add(user);
        }

        public User GetUser(int id)
        {
            var user = users.FirstOrDefault(x => x.Id == id);
            return user;
        }

        public List<User> GetUsers()
        {
            return users;
        }

        public Book BorrowBook(string title, User user)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException("The name of the book is required!");

            if (user is not null)
                throw new ArgumentNullException("The user must be a valid user!");

            var book = _libraryService.GetBooks().FirstOrDefault(b => b.Title == title);
            if (book == null && book.IsLocked)
                throw new ArgumentNullException("The book you want borrow is not available right now.");

            book.IsLocked = true;
            _libraryService.UpdateBook(book);
            return book;
        }

        public void ReturnBorrow(Book book)
        {
            if (book is null)
                throw new ArgumentNullException("You must provide a book!");

            book.IsLocked = false;

            _libraryService.UpdateBook(book);
        }
    }
}