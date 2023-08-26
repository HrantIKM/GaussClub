using GaussClub.DAL.Contracts;
using GaussClub.DAL.Data;

namespace GaussClub.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IUniversityRepository UniversityRepository { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            UniversityRepository = new UniversityRepository(_context);
        }


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
