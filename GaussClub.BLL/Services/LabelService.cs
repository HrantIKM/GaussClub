using GaussClub.BLL.Contracts;
using GaussClub.DAL.Contracts;
using GaussClub.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GaussClub.BLL.Services
{
    public class LabelService : ILabelService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LabelService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Label> GetAll()
        {
            return _unitOfWork.LabelRepository.GetAll().ToList();
        }
        public List<Label> GetRangeByIds(List<int> ids)
        {
            return _unitOfWork.LabelRepository.GetByQuery(l => ids.Contains(l.Id));
        }
        public IEnumerable<SelectListItem> GetForSelect()
        {
            return GetAll().Select(l => new SelectListItem
            {
                Text = l.Name,
                Value = l.Id.ToString()
            });
        }

        public Label? GetById(int? id)
        {
            return _unitOfWork.LabelRepository.Get(l => l.Id == id);
        }

        public void Add(Label label)
        {
            _unitOfWork.LabelRepository.Add(label);
            _unitOfWork.Save();
        }

        public void Update(Label label)
        {
            _unitOfWork.LabelRepository.Update(label);
            _unitOfWork.Save();
        }
        public void Remove(Label label)
        {
            _unitOfWork.LabelRepository.Remove(label);
            _unitOfWork.Save();
        }
    }
}
