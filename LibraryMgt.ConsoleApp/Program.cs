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

Console.WriteLine($"{userMessage}: {JsonSerializer.Serialize(user)}");