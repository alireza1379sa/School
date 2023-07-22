using Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_Core.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string UserName { get; set; } = "";

        [Required]
        [StringLength(100)]
        public string Password { get; set; } = "";

        public Teacher? Teacher { get; set; }

        public Student? Student { get; set; }

        [ForeignKey("UserTitle")]
        public int UserTitle_id { get; set; }

        public UserTitle? UserTitle { get; set; }
    }
}
