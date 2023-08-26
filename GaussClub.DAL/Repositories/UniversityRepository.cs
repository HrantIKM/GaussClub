using GaussClub.DAL.Contracts;
using GaussClub.DAL.Data;
using GaussClub.Models;

namespace GaussClub.DAL.Repositories
{
    public class UniversityRepository : Repository<University>, IUniversityRepository
    {
        private AppDbContext _context;
        public UniversityRepository(AppDbContext context) : base(context)
        { 
            _context = context;
        }
    }
}
