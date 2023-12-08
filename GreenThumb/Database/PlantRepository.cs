using Microsoft.EntityFrameworkCore;

namespace GreenThumb.Database
{
    internal class PlantRepository<T> where T : class
    {
        private readonly GreenThumbDbContext _context;
        private readonly DbSet<T> _dbSet;

        public PlantRepository(GreenThumbDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        // Get all results
        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        // Get by id
        public T? GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public List<T> GetByBotanicalName(string input)
        {
            return _dbSet.Where(
                entity => EF.Property<string>(entity, "BotanicalName")
                .Contains(input)).ToList();
        }

        // Add method
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        // TODO update method
        public void Update(int id, T entity)
        {

        }

        // Delete method 
        public void Delete(int id)
        {
            T? entityToDelete = GetById(id);
            if (entityToDelete != null)
            {
                _dbSet.Remove(entityToDelete);
            }
        }

        // Save method
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
