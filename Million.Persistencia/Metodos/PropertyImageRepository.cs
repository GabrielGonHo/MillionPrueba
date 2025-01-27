using Million.Dominio.Entidades;
using Million.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Million.Persistencia.Metodos
{
    public class PropertyImageRepository : IPropertyImageRepository
    {
        private readonly AppDbContext.AppDbContext _context;

        public PropertyImageRepository(AppDbContext.AppDbContext context)
        {
            _context = context;
        }

        public async Task<PropertyImage> GetByIdAsync(int id)
        {
            return await _context.PropertyImages.FindAsync(id);
        }

        public async Task<IEnumerable<PropertyImage>> GetAllAsync()
        {
            return await _context.PropertyImages.ToListAsync();
        }

        public async Task AddAsync(PropertyImage propertyImage)
        {
            await _context.PropertyImages.AddAsync(propertyImage);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PropertyImage propertyImage)
        {
            _context.PropertyImages.Update(propertyImage);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var propertyImage = await _context.PropertyImages.FindAsync(id);
            if (propertyImage != null)
            {
                _context.PropertyImages.Remove(propertyImage);
                await _context.SaveChangesAsync();
            }
        }
    }
}
