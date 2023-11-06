using Microsoft.EntityFrameworkCore;
using ProcurementProcess.Net6.Context;
using ProcurementProcess.Net6.Interfaces;

namespace ProcurementProcess.Net6.Services
{
   

    public class GenericService<TEntity> : IGenericInterface<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _database;

        public GenericService(ApplicationDbContext context)
        {     
            _context = context;
            _database = _context.Set<TEntity>();
            
        }


        public void CreateAsync(TEntity Tentity)
        {
            _database.Add(Tentity);
            _context.SaveChangesAsync();
        }

        public Task<TEntity> DeleteAsync(TEntity Tentity)
        {
            throw new NotImplementedException();
        }

        public TEntity GetEntity(int id)
        {
            var item = _database.Find(id);

            if(item == null)
            {
                return null;
            }
            return item;
        }

        public IEnumerable<TEntity> GetList()
        {
            return _database.ToList();
            
        }

        public void UpdateAsync(TEntity Tentity)
        {
           _database.Update(Tentity);
            _context.SaveChangesAsync();
        }
    }
}
