using Libary.DataAccess;
using Libary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Libary.Services
{
    public class EntityService
    {
        private LibaryContext context;

        public EntityService(LibaryContext context)
        {
            this.context = context;
        }

        public void GetAuthors()
        {
            var authorBooks = context.BooksAuthors.Where(book => book.Book.Title == "Клатбище домашних животных").ToList();
            foreach (var author in authorBooks)
            {
                Console.WriteLine($"{author.Author.FirstName} {author.Author.LastName}");
            }
        }
        public void GetFreeBooks()
        {
            var books = context.Books.ToList();
            var bookOnHand = context.BooksOnHands.Select(book => book.Book).ToList();

            var freeBooks = books.Except(bookOnHand).ToList();

            foreach (var freeBook in freeBooks)
            {
                Console.WriteLine(freeBook.Title);
            }
        }

        public void GetBooks()
        {
            var books = context.BooksOnHands.Where(user => user.User.FirstName == "Фабио").ToList();
            foreach (var book in books)
            {
                Console.WriteLine(book.Book.Title);
            }
        }
    }
}
