using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ClassesStudent
    {
        public int Id { get; set; }

        public int ClassId { get; set; }

        public int StudentId { get; set; }

        public Student? Student { get; set; }

        public Class? Class { get; set; }
    }
}


