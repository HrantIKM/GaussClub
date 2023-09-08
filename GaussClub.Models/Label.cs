using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace GaussClub.Models
{
    public class Label
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [ValidateNever]
        public IList<ArticleLabel>? ArticleLabels { get; set; }

    }
}
