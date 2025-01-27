using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Million.Aplicacion.Servicios;
using Million.Dominio.Entidades;

namespace Million.Servicio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PropertyController : ControllerBase
    {
        private readonly PropertyService _propertyService;

        public PropertyController(PropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProperty([FromBody] Property property)
        {
            var createdProperty = await _propertyService.CreatePropertyAsync(property);
            return CreatedAtAction(nameof(GetPropertyById), new { id = createdProperty.IdProperty }, createdProperty);
        }

        [HttpPost("{propertyId}/images")]
        public async Task<IActionResult> AddImage(int propertyId, [FromBody] PropertyImage propertyImage)
        {
            propertyImage.IdProperty = propertyId;
            await _propertyService.AddImageAsync(propertyImage);
            return NoContent();
        }

        [HttpPut("{propertyId}/price")]
        public async Task<IActionResult> ChangePrice(int propertyId, [FromBody] decimal newPrice)
        {
            await _propertyService.ChangePriceAsync(propertyId, newPrice);
            return NoContent();
        }

        [HttpPut("{propertyId}")]
        public async Task<IActionResult> UpdateProperty(int propertyId, [FromBody] Property property)
        {
            try
            {
                await _propertyService.UpdatePropertyAsync(propertyId, property);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> ListProperties([FromQuery] string name, [FromQuery] string address, [FromQuery] decimal? minPrice, [FromQuery] decimal? maxPrice)
        {
            var properties = await _propertyService.ListPropertiesAsync(name, address, minPrice, maxPrice);
            return Ok(properties);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPropertyById(int id)
        {
            var property = await _propertyService.GetPropertyByIdAsync(id);
            if (property == null)
            {
                return NotFound();
            }
            return Ok(property);
        }
    }
}



