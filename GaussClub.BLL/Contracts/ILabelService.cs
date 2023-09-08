using GaussClub.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GaussClub.BLL.Contracts
{
    public interface ILabelService
    {
        List<Label> GetAll();
        List<Label> GetRangeByIds(List<int> ids);
        IEnumerable<SelectListItem> GetForSelect();
        Label? GetById(int? id);
        void Add(Label label);
        void Update(Label label);
        void Remove(Label label);
    }
}
