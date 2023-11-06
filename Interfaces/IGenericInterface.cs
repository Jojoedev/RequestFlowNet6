namespace ProcurementProcess.Net6.Interfaces
{
    public interface IGenericInterface<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetList();
        TEntity GetEntity(int id);

        void CreateAsync(TEntity Tentity);

        void UpdateAsync(TEntity Tentity);
        Task<TEntity> DeleteAsync(TEntity Tentity);
    }
}
