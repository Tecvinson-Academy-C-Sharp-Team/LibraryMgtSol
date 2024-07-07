// See https://aka.ms/new-console-template for more information

using LibraryMgt.Core.Entities;
using LibraryMgt.Service.Services;

Console.WriteLine("Hello, World!");

Console.WriteLine("Create a user");
User user = new User()
{
    Id = 1,
    Name = "Godswill David",
    Email = "godswill.david@tecvinsonacademy.com",
    IsAdmin = true,
    IsActive = true
};

UserService userService = new UserService(new LibraryService());
string userMessage = "New user created";

userService.CreateUser(user);

Console.WriteLine(userMessage);