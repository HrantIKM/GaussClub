using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace GaussClub.Models
{
    public class User : IdentityUser
    {
        [Required]
        [MaxLength(150)]
        public string? FirstName { get; set; }
        [Required]
        [MaxLength(150)]
        public string? LastName { get; set; }
        public bool IsActive { get; set; }
        [MaxLength(400)]
        public string? Bio { get; set; }
        [MaxLength(1500)]
        public string? Information { get; set; }
        public string? Skills { get; set; }
        public bool SplitSkills { get; set; }
        public string? InstagramLink { get; set; }
        public string? TelegramLink { get; set; }
        public string? FacebookLink { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? ImageUrl { get; set; }

    }
}
