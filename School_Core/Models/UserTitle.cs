using System.ComponentModel.DataAnnotations;

namespace School_Core.Models
{
    public class UserTitle
    {
        public UserTitle()
        {
            Users= new List<User>();    
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = "";

        public List<User> Users { get; set; }
    }
}
