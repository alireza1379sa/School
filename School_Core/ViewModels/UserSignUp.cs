using School_Core.Attributes;
using System.ComponentModel.DataAnnotations;

namespace School_Core.ViewModels
{
    public class UserSignUp
    {
        [MaxLength(150)]
        [Required]
        public string UserName { get; set; } = "";

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = "";

        [StringLength(10)]
        [NationalCode]
        public string NationalCode { get; set; } = "";
    }
}
