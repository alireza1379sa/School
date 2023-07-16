using Entities;
using School_Core.Repositories;
namespace School_Core.Services
{
    public class ClassesRepository : GenericRepository<Class>,IClassesRepository
    {
        private readonly DB db;
        public ClassesRepository(DB db) : base(db)
        {
            this.db = db;
        }

        public IEnumerable<Student> GetStudents(int id)
        {
            var res = from cls in db.ClassesStudents
                      join clas in db.Classes on cls.ClassId equals clas.Id
                      join student in db.Students
                    on cls.StudentId equals student.Id where clas.Id==id
                      select new Student()
                      {
                          Id = student.Id,
                          NationalCode = student.NationalCode,
                          FirstName = student.FirstName,
                          Age = student.Age,
                          LastName = student.LastName,
                          Major = student.Major,
                          Mark= student.Mark,
                      };
            return res;
        }
    }
}
