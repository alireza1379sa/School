using School_Core.Models;

namespace School_Core.Repositories
{
    public interface IUserRepository : IRepositoryManager<User>
    {
        bool IsExist(string username);

        User UserIncludeStudent(int id);

        User UserIncludeTeacher(int id);

        int FindUserTitleId(string title);

        User GetUserForLogin(string username, string password);

        User FindUserById(int id);
    }
}
