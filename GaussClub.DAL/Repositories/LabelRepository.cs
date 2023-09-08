using GaussClub.DAL.Contracts;
using GaussClub.DAL.Data;
using GaussClub.Models;

namespace GaussClub.DAL.Repositories
{
    public class LabelRepository : Repository<Label>, ILabelRepository
    {
        private AppDbContext _context;
        public LabelRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
