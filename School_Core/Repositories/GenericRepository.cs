using Microsoft.EntityFrameworkCore;

namespace School_Core.Repositories
{
    public class GenericRepository<Tentity> : IRepositoryManager<Tentity> where Tentity : class
    {
        private DB db;
        private DbSet<Tentity> dbSet;

        public GenericRepository(DB db)
        {
            this.db = db;
            dbSet = db.Set<Tentity>();
        }
        public bool Delete(Tentity entity)
        {
            try
            {
                db.Entry(entity).State = EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var res = GetById(id);
                Delete(res);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<Tentity> GetAll()
        {
            return dbSet;
        }

        public Tentity GetById(int id)
        {
            return dbSet.Find(id)!;
        }

        public bool Insert(Tentity entity)
        {
            try
            {
                dbSet.Add(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public bool Update(Tentity entity)
        {
            try
            {
                db.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
