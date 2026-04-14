using CookBook.Domain.Base;
using CookBook.ValueObjects;

namespace CookBook.Domain
{
    public class Chef : Entity
    {
        public Username Username { get; private set; }

        public Chef(Username username)
        {
            Username = username;
        }
    }
}