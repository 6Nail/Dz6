namespace Libary.Domain
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Debtor { get; set; } = false;
    }
}
