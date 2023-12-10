using GreenThumb.Models;
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

        public List<T> GetAllInstructions(int plantId)
        {
            return _dbSet.Where(s => EF.Property<int>(s, "PlantId") == plantId).ToList();
        }

        // Get by id
        public T? GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public List<T> GetByPlantName(string input)
        {
            // Fick lite hjälp av Chat GPT för att få denna metoden att fungera
            // Den söker genom både BotanicalName och Name property för match med input
            return _dbSet.Where(
                s => EF.Property<string>(s, "BotanicalName")
                .Contains(input) ||
                EF.Property<string>(s, "Name")
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
                if (entityToDelete is PlantModel plantWithInstructions)
                {
                    _context.Entry(plantWithInstructions)
                      .Collection(p => p.Instruction)
                      .Load();

                    _context.Instructions.RemoveRange(plantWithInstructions.Instruction);
                }
                _context.SaveChanges();

                _dbSet.Remove(entityToDelete);

                _context.SaveChanges();
            }
        }

        // Save method
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
