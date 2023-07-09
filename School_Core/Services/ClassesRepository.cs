using Entities;
using School_Core.Repositories;
namespace School_Core.Services
{
    public class ClassesRepository : GenericRepository<Class>
    {
        public ClassesRepository(DB db) : base(db)
        {

        }
    }
}
