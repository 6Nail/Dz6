using Libary.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Libary.Services
{
    public class DebtorService
    {
        private LibaryContext context;

        public DebtorService(LibaryContext context)
        {
            this.context = context;
        }

        public void ShowDebtor()
        {
            var users = context.Users.Where(user => user.Debtor == true).ToList();
            if (users.Count == 0)
            {
                Console.WriteLine("Должников нету");
                return;
            }
            foreach (var user in users)
            {
                Console.WriteLine($"Имя: {user.FirstName}\nФамилия: {user.LastName}\n\n");
            }
        }

        public void CheckDebtor()
        {
            var bookOnHands = context.BooksOnHands.ToList();

            var books = bookOnHands.Where(book => book.ReturnDate < DateTime.Now).ToList();
            if (books.Count == 0) return;
            books.ForEach(x => x.User.Debtor = true);
            foreach (var book in books)
            {
                context.Entry(book).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public void ZeroingDebtor()
        {
            var users = context.Users.Where(user => user.Debtor == true).ToList();
            users.ForEach(x => x.Debtor = false);

            foreach (var user in users)
            {
                context.Entry(user).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
    }
}
