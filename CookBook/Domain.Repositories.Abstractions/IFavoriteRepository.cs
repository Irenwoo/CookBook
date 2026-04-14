using CookBook.Domain;
using CookBook.Domain.Repositories.Abstractions.Base;
using Domain.Repositories.Abstractions.Base;

namespace CookBook.Domain.Repositories.Abstractions.Base
{
    public interface IFavoriteRepository : IRepository<Favorite>
    {
    }
}