using GaussClub.Models;
using System.Linq.Expressions;

namespace GaussClub.DAL.Contracts
{
    public interface IArticleRepository : IRepository<Article>
    {
        new Article? Get(Expression<Func<Article, bool>> filter);
    }
}
