using Million.Dominio.Entidades;
using Million.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Million.Persistencia.Metodos
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly AppDbContext.AppDbContext _context;

        public OwnerRepository(AppDbContext.AppDbContext context)
        {
            _context = context;
        }

        public async Task<Owner> GetByIdAsync(int id)
        {
            return await _context.Owners.FindAsync(id);
        }

        public async Task<IEnumerable<Owner>> GetAllAsync()
        {
            return await _context.Owners.ToListAsync();
        }

        public async Task AddAsync(Owner owner)
        {
            await _context.Owners.AddAsync(owner);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Owner owner)
        {
            _context.Owners.Update(owner);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var owner = await _context.Owners.FindAsync(id);
            if (owner != null)
            {
                _context.Owners.Remove(owner);
                await _context.SaveChangesAsync();
            }
        }
    }
}
