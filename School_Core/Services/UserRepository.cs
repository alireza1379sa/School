using Microsoft.EntityFrameworkCore;
using School_Core.Models;
using School_Core.Repositories;

namespace School_Core.Services
{
    public class UserRepository:GenericRepository<User>
    {
        private readonly DB db;
        public UserRepository(DB db) : base(db)
        {
            this.db = db;
        }

        public bool IsExist(string username)
        {
            User res = db.Users.SingleOrDefault(n => n.UserName == username)!;
            if(res == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public User GetUserByUsername(string username)
        {

            return db.Users.Include(n => n.UserTitle).Single(n => n.UserName == username)!;
        }

        public User UserIncludeStudent(User user)
        {
            return db.Users.Include(n=>n.Student).Single(n=>n.UserName== user.UserName);
        }
    }
}
