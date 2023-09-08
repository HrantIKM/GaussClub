using GaussClub.DAL.Contracts;
using GaussClub.DAL.Data;
using GaussClub.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GaussClub.DAL.Repositories
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        private AppDbContext _context;
        internal DbSet<Article> dbSet;

        public ArticleRepository(AppDbContext context) : base(context)
        {
            _context = context;
            dbSet = _context.Set<Article>();

        }

        public override Article? Get(Expression<Func<Article, bool>> filter)
        {
            IQueryable<Article> query = dbSet;
            query = query.Where(filter).Include("ArticleLabels");

            return query.FirstOrDefault();
        }
    }
}
