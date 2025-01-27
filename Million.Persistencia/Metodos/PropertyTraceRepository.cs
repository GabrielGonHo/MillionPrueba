using Million.Dominio.Entidades;
using Million.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Million.Persistencia.Metodos
{
    public class PropertyTraceRepository : IPropertyTraceRepository
    {
        private readonly AppDbContext.AppDbContext _context;

        public PropertyTraceRepository(AppDbContext.AppDbContext context)
        {
            _context = context;
        }

        public async Task<PropertyTrace> GetByIdAsync(int id)
        {
            return await _context.PropertyTraces.FindAsync(id);
        }

        public async Task<IEnumerable<PropertyTrace>> GetAllAsync()
        {
            return await _context.PropertyTraces.ToListAsync();
        }

        public async Task AddAsync(PropertyTrace propertyTrace)
        {
            await _context.PropertyTraces.AddAsync(propertyTrace);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PropertyTrace propertyTrace)
        {
            _context.PropertyTraces.Update(propertyTrace);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var propertyTrace = await _context.PropertyTraces.FindAsync(id);
            if (propertyTrace != null)
            {
                _context.PropertyTraces.Remove(propertyTrace);
                await _context.SaveChangesAsync();
            }
        }
    }
}
