using GaussClub.Models;

namespace GaussClub.BLL.Contracts
{
    public interface IUniversityService
    {
        List<University> GetAll();
        University? GetById(int? id);
        void Add(University university);
        void Update(University university);
        void Remove(University university);
    }
}
