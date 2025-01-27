using Million.Dominio.Entidades;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Million.Dominio.Interfaces
{
    public interface IPropertyTraceRepository
    {
        Task<PropertyTrace> GetByIdAsync(int id);
        Task<IEnumerable<PropertyTrace>> GetAllAsync();
        Task AddAsync(PropertyTrace propertyTrace);
        Task UpdateAsync(PropertyTrace propertyTrace);
        Task DeleteAsync(int id);
    }
}
