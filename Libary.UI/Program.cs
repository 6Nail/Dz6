using Libary.DataAccess;
using Libary.Domain;
using Libary.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;

namespace Libary.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json", false, true);
            IConfigurationRoot configurationRoot = builder.Build();
            var connectionString = configurationRoot.GetConnectionString("MyConnectionString");

            using (var context = new LibaryContext(connectionString))
            {
                #region Add
                //var userFirst = new User
                //{
                //    FirstName = "Антонио",
                //    LastName = "Фебучи"
                //};
                //var userSecond = new User
                //{
                //    FirstName = "Фабио",
                //    LastName = "Перули"
                //};
                //var authorFirst = new Author
                //{
                //    FirstName = "Стивен",
                //    LastName = "Кинг"
                //};

                //var bookFirst = new Book
                //{
                //    Title = "Клатбище домашних животных"
                //};

                //var booksAuthorsFirst = new BooksAuthors
                //{
                //    Author = authorFirst,
                //    Book = bookFirst
                //};

                //var booksAuthorsSecond = new BooksAuthors
                //{
                //    Author = new Author
                //    {
                //        FirstName = "Пауло",
                //        LastName = "Коэльо"
                //    },
                //    Book = new Book
                //    {
                //        Title = "На пропостью во ржи",
                //        Price = 2000
                //    }
                //};

                //var booksAuthorsThree = new BooksAuthors
                //{
                //    Author = context.Authors.SingleOrDefault(author => author.FirstName == "Пауло"),
                //    Book = new Book
                //    {
                //        Title = "Алхимик",
                //        Price = 1200
                //    }
                //};

                //var booksAuthorsFourth = new BooksAuthors
                //{
                //    Author = new Author
                //    {
                //        FirstName = "Мария",
                //        LastName = "Ремарк"
                //    },
                //    Book = new Book
                //    {
                //        Title = "Три товарища",
                //        Price = 1800
                //    }
                //};
                //var booksAuthorsFive = new BooksAuthors
                //{
                //    Author = context.Authors.SingleOrDefault(author => author.FirstName == "Мария"),
                //    Book = new Book
                //    {
                //        Title = "Жизнь взаймы",
                //        Price = 1200
                //    }
                //};

                //var bookOnHandFirst = new BooksOnHand
                //{
                //    User = context.Users.SingleOrDefault(user => user.FirstName == "Антонио"),
                //    Book = context.Books.SingleOrDefault(book => book.Title == "Алхимик"),
                //    ReceivingDate = DateTime.Now,
                //    ReturnDate = DateTime.Now
                //};
                //var bookOnHandSecond = new BooksOnHand
                //{
                //    User = context.Users.SingleOrDefault(user => user.FirstName == "Фабио"),
                //    Book = context.Books.SingleOrDefault(book => book.Title == "Клатбище домашних животных"),
                //    ReceivingDate = DateTime.Now
                //};

                //var booksAuthorsSix = new BooksAuthors
                //{
                //    Author = new Author
                //    {
                //        FirstName = "Кто-то левый",
                //        LastName = "Кто это?"
                //    },
                //    Book = context.Books.SingleOrDefault(book => book.Title == "Клатбище домашних животных")
                //};

                //context.Add(booksAuthorsSix);
                //context.SaveChanges();
                #endregion
                var isExit = false;
                DebtorService debtorService = new DebtorService(context);
                EntityService entityService = new EntityService(context);
                while (!isExit)
                {
                    Console.Clear();
                    Console.WriteLine($"1 - Список должников");
                    Console.WriteLine($"2 - Выявить должников");
                    Console.WriteLine($"3 - Список авторов книги №3");
                    Console.WriteLine($"4 - Список книг, которые доступны в данный момент");
                    Console.WriteLine($"5 - Список книг, которые на руках у пользователя №2");
                    Console.WriteLine($"6 - Обнулите задолженности всех должников");
                    Console.WriteLine($"7 - Выход");
                    Console.Write("Выберите пункт меню: ");
                    if (int.TryParse(Console.ReadLine(), out var choose))
                    {
                        switch (choose)
                        {
                            case 1: debtorService.ShowDebtor(); Console.Read(); break;
                            case 2: debtorService.CheckDebtor(); break;
                            case 3: entityService.GetAuthors(); Console.Read(); break;
                            case 4: entityService.GetFreeBooks(); Console.Read(); break;
                            case 5: entityService.GetBooks(); Console.Read(); break;
                            case 6: debtorService.ZeroingDebtor(); break;
                            case 7: isExit = true; break;
                            default: Console.WriteLine("Нет такого пункта!"); Console.Read(); break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Выбран не верный пункт меню");
                    }
                }
            }
        }
    }
}
