namespace ProcurementProcess.Net6.Interfaces
{
    public interface IGenericInterface<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetList();
        Task<TEntity> GetEntityAsync(int id);

        void CreateAsync(TEntity Tentity);

        Task<TEntity> UpdateAsync(TEntity Tentity);
        Task<TEntity> DeleteAsync(TEntity Tentity);
    }
}
