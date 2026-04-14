using CookBook.Domain;
using CookBook.ValueObjects;

// Создаём Username и Chef
var username = new Username("GordonRamsay");
var chef = new Chef(username);  

Console.WriteLine($"Шеф: {chef.Username.Value}");  
Console.WriteLine($"ID: {chef.Id}");