using System.ComponentModel.DataAnnotations;

namespace UserManagement.Common.Dtos
{
    public class GenerateTokenDto
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
