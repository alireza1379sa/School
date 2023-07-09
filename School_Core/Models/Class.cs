using School_Core.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Class
    {
        public Class()
        {
            Students= new List<Student>(); 
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; } = "";


        [DataType(dataType:DataType.Date)]
        public DateTime Date { get; set; }

        [Time]
        public TimeSpan Time { get; set; }

        [ForeignKey("Teacher")]
        public Nullable<int> Teacher_id { get; set; }

        public Teacher? Teacher { get; set; }

        public List<Student> Students { get; set; }
    }
}
