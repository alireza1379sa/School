using Entities;
using Microsoft.EntityFrameworkCore;
using School_Core.Repositories;
namespace School_Core.Services
{
    public class TeacherRepository : GenericRepository<Teacher>
    {
        private readonly DB _db;
        public TeacherRepository(DB db) : base(db)
        {
            _db= db;
        }

        public List<Class> GetClasses(int id)
        {
            return _db.Teachers.Include(n=>n.Classes).Single(n=>n.Id==id).Classes;
        }
    }
}
