using Entities;

namespace School_Core.Repositories
{
    public interface ITeacherRepository:IRepositoryManager<Teacher>
    {
        List<Class> GetClasses(int id);
    }
}
