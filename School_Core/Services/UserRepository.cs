using Entities;
using Microsoft.EntityFrameworkCore;
using School_Core.Models;
using School_Core.Repositories;

namespace School_Core.Services
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly DB db;
        public UserRepository(DB db) : base(db)
        {
            this.db = db;
        }

        public bool IsExist(string username)
        {
            User res = db.Users.SingleOrDefault(n => n.UserName == username)!;
            if (res == null)
            {
                return false;
            }
            return true;
        }

        public User UserIncludeStudent(int id)
        {
            return db.Users.Include(n => n.Student).Single(n => n.Id == id);
        }

        public User UserIncludeTeacher(int id)
        {
            return db.Users.Include(n => n.Teacher).Single(n => n.Id == id);
        }

        public int FindUserTitleId(string title)
        {
            return db.UserTitle.Single(n => n.Title == title).Id;
        }

        public User GetUserForLogin(string username, string password)
        {
            return db.Users.Include(n => n.UserTitle).SingleOrDefault(n => n.UserName == username && n.Password == password)!;
        }

        public User FindUserById(int id)
        {
            return db.Users.Include(n => n.UserTitle).Single(n => n.Id == id);
        }
    }
}
