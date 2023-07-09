using Entities;
using School_Core.Repositories;
namespace School_Core.Services
{
    public class TeacherRepository : GenericRepository<Teacher>
    {
        public TeacherRepository(DB db) : base(db)
        {

        }
    }
}
