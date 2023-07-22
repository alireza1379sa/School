using Entities;
using School_Core.ViewModels;

namespace School_Core.Repositories
{
    public interface IStudentRepository:IRepositoryManager<Student>
    {
        IEnumerable<WeeklySchedule> GetWeeklySchedules(int id);

        void AssignMark(Student student);

        bool ExistStudentByCode(string code);

        Student FindStudentByCode(string code);
    }
}
