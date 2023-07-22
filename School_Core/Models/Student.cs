using School_Core.Attributes;
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
    public class Student
    {
        public Student()
        {
            Classes = new List<Class>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = "";

        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = "";

        [StringLength(100)]
        [Major("math","physics","computer","chemistry")]
        public string Major { get; set; } = "";

        [StringLength(10)]
        [NationalCode]
        public string NationalCode { get; set; } = "";

        public int Age { get; set; }

        [MarkValidation(0,20,ErrorMessage ="Please enter valid data")]
        public int Mark { get; set; }

        public List<Class> Classes { get; set; }

        [ForeignKey("User")]
        public Nullable<int> User_id { get; set; }

        public User? User { get; set; }
    }
}
