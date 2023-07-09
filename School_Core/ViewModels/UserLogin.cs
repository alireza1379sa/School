using Microsoft.Build.Framework;

namespace School_Core.ViewModels
{
    public class UserLogin
    {
        [Required]
        public string UserName { get; set; } = "";
    }
}
