using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GaussClub.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Տվյալ դաշտը պարտադիր է")]
        [MaxLength(300)]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Տվյալ դաշտը պարտադիր է")]
        [MaxLength(350)]
        //TODO: Make Uniqueness validation
        public string? Slug { get; set; }
        [Required(ErrorMessage = "Տվյալ դաշտը պարտադիր է")]
        public string? Content { get; set; }
        [Required(ErrorMessage = "Տվյալ դաշտը պարտադիր է")]
        public string? Author { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; } = true;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? ImageUrl { get; set; }
        [ValidateNever]
        public IList<ArticleLabel>? ArticleLabels { get; set; }
    }
}
