using GaussClub.BLL.Contracts;
using GaussClub.DAL.Contracts;
using GaussClub.Models;

namespace GaussClub.BLL.Services
{
    public class UniversityService : IUniversityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UniversityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<University> GetAll()
        {
            return _unitOfWork.UniversityRepository.GetAll().ToList();
        }

        public University? GetById(int? id) { 
            return _unitOfWork.UniversityRepository.Get(u => u.Id == id);
        }

        public void Add(University university)
        {
            _unitOfWork.UniversityRepository.Add(university);
            _unitOfWork.Save();
        }

        public void Update(University university)
        {
            _unitOfWork.UniversityRepository.Update(university);
            _unitOfWork.Save();
        }
        public void Remove(University university)
        {
            _unitOfWork.UniversityRepository.Remove(university);
            _unitOfWork.Save();
        }
    }
}
