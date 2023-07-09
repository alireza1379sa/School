using School_Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Teacher
    {
        public Teacher()
        {
            Classes = new List<Class>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; } = "";

        [Required]
        [StringLength(100)]
        public string? Field { get; set; } = "";

        [StringLength(11)]
        [PhoneMask("09999999999")]
        public string PhoneNumber { get; set; } = "";

        public List<Class> Classes { get; set; }


        [ForeignKey("User")]
        public Nullable<int> User_id { get; set; }

        public User? User { get; set; }
    }
}
