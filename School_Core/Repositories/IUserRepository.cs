using School_Core.Models;

namespace School_Core.Repositories
{
    public interface IUserRepository:IRepositoryManager<User>
    {
        bool IsExist(string username);

        User GetUserByUsername(string username);

        User UserIncludeStudent(int id);

        User UserIncludeTeacher(int id);
    }
}
