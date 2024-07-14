using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LibraryMgt.Core.Entities;
using LibraryMgt.Core.IService;
using LibraryMgt.Service.Exceptions;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryMgt.Service.Services
{
    public class UserService : IUserService
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
        public void CreateUser(string name, string email)
        {
            try
            {
                // Logic here is first executed...
                if (email.Contains(".tt"))
                {
                    EmailDomainException emailDomainException =
                        new EmailDomainException("EmailDomainException: The 'Email' should not be .tt domain name.");
                    throw emailDomainException;
                }

                if (true)
                {
                    var a = 20;
                    var b = 0;

                    var c = a / b;
                    DivideByZeroException byZeroException = new DivideByZeroException("You can not divide a nummber by zero!");
                    throw byZeroException;
                }

                User user = new User()
                {
                    Id = users.Count + 1,
                    Name = name,
                    Email = email,
                    IsActive = true
                };
                users.Add(user);
            }
            catch (Exception e)
            {
                // If error with logic catch the here and handle...
                Console.WriteLine(e);
            }
            finally
            {
                // This bit of code will always  be executed.
                Console.WriteLine("Finally finally, This is executed");
            }
        }

        public void CreateUser(User user)
        {
            // add a new user to the book db
            users.Add(user);
        }

        public User GetUserById(long id)
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

            if (user is null)
                throw new ArgumentNullException("The user must be a valid user!");

            var book = _libraryService.GetBooks().FirstOrDefault(b => b.Title == title);
            if (book == null && book.IsLocked)
                throw new ArgumentNullException("The book you want to borrow is not available right now.");

            if (CanBorrowBook(user))
            {
                book.IsLocked = true;
                user.BorrowedBooks.Add(book);
                _libraryService.UpdateBook(book);
                return book;
            }

            book.IsLocked = false;
            //user.BorrowedBooks.Add(book);
            //_libraryService.UpdateBook(book);
            return book;
        }

        public Book BorrowBook(string Id, string Name, User user)
        {
            throw new NotImplementedException();
        }

        public int Add(int a, int b) => a + b;

        public double Add(double a, double b) => a + b;

        public void ReturnBorrow(Book book)
        {
            if (book is null)
                throw new ArgumentNullException("You must provide a book!");

            book.IsLocked = false;

            _libraryService.UpdateBook(book);
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase,
                    TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public static bool IsFullNameValid(string fullName)
        {
            //this was initially missing
            if (string.IsNullOrWhiteSpace(fullName))
                return false;

            try
            {
                return Regex.IsMatch(fullName,
                    @"^[a-zA-Z]{3,}(?: [a-zA-Z]{3,})+$",
                    RegexOptions.IgnoreCase,
                    TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public static bool CanBorrowBook(User user)
        {
            if (user == null)
                return false;

            var numberOfBorrowedBooks = user.BorrowedBooks.Count;
            if (numberOfBorrowedBooks <= 2)
                return true;

            return false;
        }
    }
}