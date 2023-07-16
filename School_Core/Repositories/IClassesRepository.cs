using Entities;

namespace School_Core.Repositories
{
    public interface IClassesRepository:IRepositoryManager<Class>
    {
        IEnumerable<Student> GetStudents(int id);
    }
}
