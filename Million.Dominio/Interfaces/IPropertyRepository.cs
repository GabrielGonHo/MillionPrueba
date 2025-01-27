using Million.Dominio.Entidades;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Million.Dominio.Interfaces
{
    public interface IPropertyRepository
    {
        Task<Property> GetByIdAsync(int id);
        Task<IEnumerable<Property>> GetAllAsync();
        Task AddAsync(Property property);
        Task UpdateAsync(Property property);
        Task DeleteAsync(int id);
    }
}
