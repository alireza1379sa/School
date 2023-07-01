using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        [StringLength(100)]
        public string? FieldOfStudy { get; set; } = "";

        public int Age { get; set; }

        public List<Class> Classes { get; set; }
    }
}
