using Entities;
using School_Core.Repositories;
namespace School_Core.Services
{
    public class ClassesStudentRepository : GenericRepository<ClassesStudent>
    {
        public ClassesStudentRepository(DB db) : base(db)
        {

        }
    }
}
