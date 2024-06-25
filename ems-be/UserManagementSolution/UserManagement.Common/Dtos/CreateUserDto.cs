using System.ComponentModel.DataAnnotations;

namespace UserManagement.Common.Dtos
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "AdB2CId is required.")]
        public string AdB2CId { get; set; }

        [Required(ErrorMessage = "FirstName is required.")]
        [StringLength(50, ErrorMessage = "FirstName can not be longer than 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="LastName is required.")]
        [StringLength(50, ErrorMessage ="LastName can not be longer than 50 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Email is required.")]
        [StringLength(50, ErrorMessage ="Email can not be longer than 50 characters.")]
        public string Email { get; set; }
    }
}
