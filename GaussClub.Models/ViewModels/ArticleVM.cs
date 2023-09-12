using Microsoft.AspNetCore.Mvc.Rendering;

namespace GaussClub.Models.ViewModels
{
    public class ArticleVM
    {
        public Article Article { get; set; }
        public List<int>? LabelIds { get; set; }
        public List<Label>? ArticleLabels { get; set; }
    }
}
