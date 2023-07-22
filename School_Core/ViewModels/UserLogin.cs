using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace School_Core.ViewModels
{
    public class UserLogin
    {
        [MaxLength(150)]
        [System.ComponentModel.DataAnnotations.Required]
        public string UserName { get; set; } = "";

        [System.ComponentModel.DataAnnotations.Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";

        public bool RememberMe { get; set; }    
    }
}
