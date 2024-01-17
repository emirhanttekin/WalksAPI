using System.ComponentModel.DataAnnotations;

namespace WalksAPI.Models.Domain.DTO
{
    public class UpdateRegionRequestDto
    { 
        [Required]
        [MinLength(3,ErrorMessage = "Kod en az 3 karakterden oluşmalıdır")]
        [MaxLength(3,ErrorMessage = "Kod en fazla 3 karakterden oluşmalıdır")]
        public string Code { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "İsim maksimum 100 karakterden oluşmalıdır")]
        public string Name { get; set; }

        public string? RegionImageUrl { get; set; }
    }
}
