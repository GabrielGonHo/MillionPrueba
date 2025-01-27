using Million.Dominio.Entidades;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Million.Dominio.Interfaces
{
    public interface IOwnerRepository
    {
        Task<Owner> GetByIdAsync(int id);
        Task<IEnumerable<Owner>> GetAllAsync();
        Task AddAsync(Owner owner);
        Task UpdateAsync(Owner owner);
        Task DeleteAsync(int id);
    }
}
