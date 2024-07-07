// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using LibraryMgt.Core.Entities;
using LibraryMgt.Service.Services;

Console.WriteLine("Create a user\n=====================================");
LibraryService libraryService = new LibraryService();
UserService userService = new UserService(libraryService);
User user = new User()
{
    Id = 1,
    Name = "Godswill David",
    Email = "godswill.david@tecvinsonacademy.com",
    IsAdmin = true,
    IsActive = true
};

string userMessage = "New user created";

Book book1 = new Book();
book1.Id = 1;
book1.Title = "Purple Hibiscus";
book1.Author = "Chimamanda N";
book1.ISBN = "091-023";
book1.IsBorrow = false;
book1.IsLocked = false;
book1.Description = "A very nice book";

Book book2 = new Book();
book2.Id = 2;
book2.Title = "Things fall Apart";
book2.Author = "Chinua Achebe";
book2.ISBN = "090-023";
book2.IsBorrow = false;
book2.IsLocked = false;
book2.Description = "A must read for all";

Book book3 = new Book();
book3.Id = 3;
book3.Title = "A subtle art of not giving fvck";
book3.Author = "Masson D";
book3.ISBN = "089-023";
book3.IsBorrow = true;
book3.IsLocked = true;
book3.Description = "You cant afford to give a fvck";

libraryService.AddBook(book1);
libraryService.AddBook(book2);
libraryService.AddBook(book3);

user.BorrowedBooks = new List<Book>();
user.BorrowedBooks.Add(book2);

userService.CreateUser(user);

var listofbooks = libraryService.GetBooks();
string data = JsonSerializer.Serialize(listofbooks);

Console.WriteLine("list of books in library");
Console.WriteLine(data);

Console.WriteLine("\r\n\r\n");

Console.WriteLine($"{userMessage}: {JsonSerializer.Serialize(user)}");

Console.WriteLine("==================================================================================");
Console.WriteLine("\r\n\r\n");

// Ask if user is new or an existing user
// if new user, get his info and create user else collect user Id.
// Ask for book of choice from user, collect book Id.
// Check if book is available, If available allow the user to borrow book, else tell him the book is not
// available.
var newUser = new User();
Console.WriteLine("Hi, Are you a new user of this library?\r\n\r\n");
Console.WriteLine("Enter 'Yes' or 'No'");
string newUserInput = Console.ReadLine();

if (newUserInput.Equals("YeS", StringComparison.OrdinalIgnoreCase))
{
    // Create user and validate user inputs
    Console.WriteLine("Create a new user.");
    Console.WriteLine("Please enter your full name: ");
    string fullName = Console.ReadLine();
    // Ensure the fullName is a valid First and last name.
    bool isFullName = UserService.IsFullNameValid(fullName);
    // Enfore FullName is valid
    Console.WriteLine("The entered fullName is not valid!\r\nPlease enter your full name: ");
    fullName = Console.ReadLine();
    Console.WriteLine("Enter your email: ");
    string email = Console.ReadLine();

    // Ensure the email is a valid email address.
    bool isEmail = UserService.IsValidEmail(email);
    Console.WriteLine("The entered email is not valid!\r\nPlease enter your email address (e.g example@mail.com) ");
    // Enforce Email is valid.
    email = Console.ReadLine();

    newUser = new User()
    {
        Id = user.Id + 1,
        Name = fullName,
        Email = email,
        IsActive = true,
        IsAdmin = false
    };

    userService.CreateUser(newUser);
}
else
{
    Console.WriteLine("Please enter your user Id:");
    long userId = Convert.ToInt64(Console.ReadLine());

    newUser = userService.GetUser(userId);
}

var listOfUsers = userService.GetUsers();
var users = JsonSerializer.Serialize(listOfUsers);
Console.WriteLine(users);

Console.WriteLine("==================================================================================");
Console.WriteLine("\r\n\r\n");

//newUser = userService.GetUser(newUser.Id);
var book = userService.BorrowBook(book2.Title, newUser);

Console.WriteLine("Book just borrowed: ", book);

listOfUsers = userService.GetUsers();
users = JsonSerializer.Serialize(listOfUsers);
Console.WriteLine(users);

Console.WriteLine("==================================================================================");
Console.WriteLine("\r\n\r\n");