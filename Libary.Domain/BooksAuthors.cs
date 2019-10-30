using System;

namespace Libary.Domain
{
    public class BooksAuthors : Entity
    {
        public virtual Author Author { get; set; }
        public virtual Book Book { get; set; }
    }
}