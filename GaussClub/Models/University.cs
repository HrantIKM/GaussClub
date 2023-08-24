using System.ComponentModel.DataAnnotations;

namespace GaussClub.Models
{
    public class University
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
