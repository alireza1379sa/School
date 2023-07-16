using Entities;
using School_Core.Repositories;
using School_Core.ViewModels;

namespace School_Core.Services
{
    public class StudentRepository : GenericRepository<Student>, IDisposable, IStudentRepository
    {
        private readonly DB db;
        public StudentRepository(DB db) : base(db)
        {
            this.db = db;

        }


        public IEnumerable<WeeklySchedule> GetWeeklySchedules(int id)
        {
            var result = from i in db.ClassesStudents
                         join x in db.Classes on i.ClassId equals x.Id
                         join z in db.Teachers on x.Teacher_id equals z.Id
                         where i.StudentId == id
                         select new WeeklySchedule()
                         {
                             ClassName = x.Name!,
                             Time = x.Time.ToString(),
                             DayOfWeek = x.Date.DayOfWeek.ToString(),
                             TeacherName = z.Name!,
                         };
            return result;
        }

        public void AssignMark(int id, int mark)
        {
            Student res = GetById(id);
            res.Mark = mark;
            Update(res);
            Save();
        }
    }
}
