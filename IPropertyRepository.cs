using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Class1
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
