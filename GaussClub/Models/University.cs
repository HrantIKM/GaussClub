using System.ComponentModel.DataAnnotations;

namespace GaussClub.Models
{
    public class University
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Տվյալ դաշտը պարտադիր է")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Տվյալ դաշտը պետք է պարունակի 2-200 նիշ")]
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
