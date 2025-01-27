using Million.Dominio.Entidades;
using Million.Dominio.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Million.Aplicacion.Servicios
{
    public class PropertyService
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IPropertyImageRepository _propertyImageRepository;

        public PropertyService(IPropertyRepository propertyRepository, IPropertyImageRepository propertyImageRepository)
        {
            _propertyRepository = propertyRepository;
            _propertyImageRepository = propertyImageRepository;
        }

        public async Task<Property> CreatePropertyAsync(Property property)
        {
            await _propertyRepository.AddAsync(property);
            return property;
        }

        public async Task AddImageAsync(PropertyImage propertyImage)
        {
            await _propertyImageRepository.AddAsync(propertyImage);
        }

        public async Task ChangePriceAsync(int propertyId, decimal newPrice)
        {
            var property = await _propertyRepository.GetByIdAsync(propertyId);
            if (property != null)
            {
                property.Price = newPrice;
                await _propertyRepository.UpdateAsync(property);
            }
        }

        public async Task UpdatePropertyAsync(int propertyId, Property updatedProperty)
        {
            var existingProperty = await _propertyRepository.GetByIdAsync(propertyId);
            if (existingProperty == null)
            {
                throw new KeyNotFoundException("Property not found");
            }

            // Actualizar solo los campos proporcionados
            if (!string.IsNullOrEmpty(updatedProperty.Name))
            {
                existingProperty.Name = updatedProperty.Name;
            }
            if (!string.IsNullOrEmpty(updatedProperty.Address))
            {
                existingProperty.Address = updatedProperty.Address;
            }
            if (updatedProperty.Price != 0)
            {
                existingProperty.Price = updatedProperty.Price;
            }
            if (!string.IsNullOrEmpty(updatedProperty.CodeInternal))
            {
                existingProperty.CodeInternal = updatedProperty.CodeInternal;
            }
            if (updatedProperty.Year != 0)
            {
                existingProperty.Year = updatedProperty.Year;
            }
            if (updatedProperty.IdOwner != 0)
            {
                existingProperty.IdOwner = updatedProperty.IdOwner;
            }

            await _propertyRepository.UpdateAsync(existingProperty);
        }

        public async Task<IEnumerable<Property>> ListPropertiesAsync(string name = null, string address = null, decimal? minPrice = null, decimal? maxPrice = null)
        {
            var properties = await _propertyRepository.GetAllAsync();
            if (!string.IsNullOrEmpty(name))
            {
                properties = properties.Where(p => p.Name.Contains(name));
            }
            if (!string.IsNullOrEmpty(address))
            {
                properties = properties.Where(p => p.Address.Contains(address));
            }
            if (minPrice.HasValue)
            {
                properties = properties.Where(p => p.Price >= minPrice.Value);
            }
            if (maxPrice.HasValue)
            {
                properties = properties.Where(p => p.Price <= maxPrice.Value);
            }
            return properties;
        }

        public async Task<Property> GetPropertyByIdAsync(int id)
        {
            return await _propertyRepository.GetByIdAsync(id);
        }
    }
}