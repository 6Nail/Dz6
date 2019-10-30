using System;
using System.Collections.Generic;
using System.Text;

namespace Libary.Domain
{
    public class BooksOnHand : Entity
    {
        public virtual User User { get; set; }
        public virtual Book Book { get; set; }
        public DateTime ReceivingDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
