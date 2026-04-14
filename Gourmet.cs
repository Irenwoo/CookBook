using CookBook.Domain.Base;
using CookBook.ValueObjects;

namespace CookBook.Domain
{
    public class Gourmet : Entity
    {
        public Username Username { get; private set; }

        public Gourmet(Username username)
        {
            Username = username;
        }
    }
}