namespace School_Core.Repositories
{
    public interface IRepositoryManager<Tentity>:IDisposable where Tentity:class
    {
        bool Insert(Tentity entity);

        bool Update(Tentity entity);

        bool Delete(Tentity entity);

        bool Delete(int id);

        Tentity GetById(int id);

        IEnumerable<Tentity> GetAll();

        void Save();

    }
}
