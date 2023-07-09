using Entities;
using School_Core.Repositories;
namespace School_Core.Services
{
    public class StudentRepository : GenericRepository<Student>, IDisposable
    {
        private readonly DB db;
        public StudentRepository(DB db) : base(db)
        {
            this.db = db;
        }
    }
}
