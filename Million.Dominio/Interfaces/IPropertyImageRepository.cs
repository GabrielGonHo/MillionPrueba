using Million.Dominio.Entidades;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Million.Dominio.Interfaces
{
    public interface IPropertyImageRepository
    {
        Task<PropertyImage> GetByIdAsync(int id);
        Task<IEnumerable<PropertyImage>> GetAllAsync();
        Task AddAsync(PropertyImage propertyImage);
        Task UpdateAsync(PropertyImage propertyImage);
        Task DeleteAsync(int id);
    }
}
