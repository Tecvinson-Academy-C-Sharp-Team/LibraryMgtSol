// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using LibraryMgt.Core.Entities;
using LibraryMgt.Service.Services;


LibraryService libraryService = new LibraryService();
UserService userService = new UserService(libraryService);
User user = new User()
{
    Id = 1,
    Name = "Godswill David",
    Email = "godswill.david@tecvinsonacademy.com",
    IsAdmin = true,
    IsActive = true,
    BorrowedBooks = new List<Book>()
};

string userMessage = "\n New user created";

Book book1 = new Book()
{
    Id = 1,
    Title = "Purple Hibiscus",
    Author = "Chimamanda N",
    ISBN = "091-023",
    IsBorrow = false,
    IsLocked = false,
    Description = "A very nice book"
};

Book book2 = new Book()
{
    Id = 2,
    Title = "Things fall Apart",
    Author = "Chinua Achebe",
    ISBN = "090-023",
    IsBorrow = false,
    IsLocked = false,
    Description = "A must read for all"
};

Book book3 = new Book()
{
    Id = 3,
    Title = "A subtle art of not giving fvck",
    Author = "Masson D",
    ISBN = "089-023",
    IsBorrow = true,
    IsLocked = true,
    Description = "You cant afford to give a fvck"
};

libraryService.AddBook(book1);
libraryService.AddBook(book2);
libraryService.AddBook(book3);

user.BorrowedBooks = new List<Book>();
user.BorrowedBooks.Add(book3);

userService.CreateUser(user);

Console.WriteLine("==================================================================================");
Console.WriteLine("\r\n\r\n");

Console.WriteLine("Hi, Are you a new user of this library?\r\n\r\n");
Console.WriteLine("Enter 'Yes' or 'No'");
string newUserInput = Console.ReadLine();

User newUser;
if (newUserInput.Equals("YeS", StringComparison.OrdinalIgnoreCase))
{
    // Create user and validate user inputs
    Console.WriteLine("Create a new user.");

    string fullName;
    bool isFullNameValid;
    do
    {
        Console.WriteLine("\n Please enter your full name: ");
        fullName = Console.ReadLine();
        isFullNameValid = UserService.IsFullNameValid(fullName);
        if (!isFullNameValid)
        {
            Console.WriteLine("\n The entered full name is not valid!\r\nPlease enter your full name with at least two words, each at least three characters long.");
        }
    } while (!isFullNameValid);

    string email;
    bool isEmailValid;
    do
    {
        Console.WriteLine("Enter your email: ");
        email = Console.ReadLine();
        isEmailValid = UserService.IsValidEmail(email);
        if (!isEmailValid)
        {
            Console.WriteLine("\nThe entered email is not valid!\r\nPlease enter a valid email address (e.g example@mail.com).");
        }
    } while (!isEmailValid);

    newUser = new User()
    {
        Id = user.Id + 1,
        Name = fullName,
        Email = email,
        IsActive = true,
        IsAdmin = false,
        BorrowedBooks = new List<Book>()
    };

    userService.CreateUser(newUser);
}
else
{
    Console.WriteLine("Please enter your user Id:");
    long userId = Convert.ToInt64(Console.ReadLine());

    newUser = userService.GetUser(userId);
}

Console.WriteLine("==================================================================================");
Console.WriteLine("\r\n\r\n");
while (true)
{
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("1. Add a book to the library");
    Console.WriteLine("2. Borrow a book");
    Console.WriteLine("3. Return a book");
    Console.WriteLine("4. View users and the books they have borrowed");
    Console.WriteLine("5. View available books");
    Console.WriteLine("6. Exit");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.WriteLine("Enter the book details to add a new book.\n");

            Book newBook = new Book();

            newBook.Id = Convert.ToInt64(libraryService.books.Count + 1);

            Console.WriteLine("Enter Book Title: ");
            newBook.Title = Console.ReadLine();

            Console.WriteLine("Enter Book Author: ");
            newBook.Author = Console.ReadLine();

            Console.WriteLine("Enter Book ISBN: ");
            newBook.ISBN = Console.ReadLine();

            newBook.IsBorrow = false;
            newBook.IsLocked = false;

            Console.WriteLine("Enter Book Description: ");
            newBook.Description = Console.ReadLine();

            libraryService.AddBook(newBook);
            Console.WriteLine("Book added successfully!");
            break;

        case "2":
            var availableBooks = libraryService.GetBooks().Where(b => !b.IsBorrow).ToList();
            Console.WriteLine("Available books for borrowing:");
            foreach (var book in availableBooks)
            {
                //string availableBookss = JsonSerializer.Serialize(book);
                //Console.WriteLine(availableBookss);
                Console.WriteLine($"{book.Id}. {book.Title} by {book.Author}");
            }

            Console.WriteLine("Enter the ID of the book you want to borrow: ");
            long bookId = Convert.ToInt64(Console.ReadLine());

            var borrowedBook = libraryService.BorrowBook(bookId, newUser);
            if (borrowedBook != null)
            {
                Console.WriteLine($"You have successfully borrowed: {borrowedBook.Title}");
            }
            else
            {
                Console.WriteLine("Sorry, the book is not available.");
            }
            break;

        case "3":
            Console.WriteLine("Enter the ID of the book you want to return: ");
            long returnBookId = Convert.ToInt64(Console.ReadLine());

            var returnSuccess = libraryService.ReturnBook(returnBookId, newUser);
            if (returnSuccess != null)
            {
                Console.WriteLine($"You have successfully returned: {returnSuccess.Title}");
            }
            else
            {
                Console.WriteLine("You have not borrowed this book.");
            }
            break;

        case "4":
            var listOfUsers = userService.GetUsers();
            foreach (var u in listOfUsers)
            {
                string users = JsonSerializer.Serialize(u);
                Console.WriteLine(users);
                //Console.WriteLine($"User: {u.Name} ({u.Email})");
                if (u.BorrowedBooks.Any())
                {
                    Console.WriteLine("Borrowed Books:");
                    foreach (var b in u.BorrowedBooks)
                    {
                        string book = JsonSerializer.Serialize(b);
                        Console.WriteLine(book);
                        // Console.WriteLine($"- {b.Title} by {b.Author}");
                    }
                }
                else
                {
                    Console.WriteLine("No borrowed books.");
                }
                Console.WriteLine();
            }
            break;

        case "5":
            var availableBooksList = libraryService.GetBooks().Where(b => !b.IsBorrow).ToList();
            Console.WriteLine("\nAvailable books in the library:");
            foreach (var book in availableBooksList)
            {
                string availableBookss = JsonSerializer.Serialize(book);
                Console.WriteLine(availableBookss);
                // Console.WriteLine($"{book.Id}. {book.Title} by {book.Author}");
            }
            break;

        case "6":
            return;

        default:
            Console.WriteLine("Invalid choice.");
            break;
    }
    Console.WriteLine("==================================================================================");
    Console.WriteLine("\r\n\r\n");
}