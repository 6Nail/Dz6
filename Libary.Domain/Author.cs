using System.Collections.Generic;

namespace Libary.Domain
{
    public class Author : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual List<BooksAuthors> Books { get; set; } = new List<BooksAuthors>();
    }
}
