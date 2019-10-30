using System.Collections.Generic;

namespace Libary.Domain
{
    public class Book : Entity
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public virtual List<BooksAuthors> Authors { get; set; } = new List<BooksAuthors>();
    }
}
