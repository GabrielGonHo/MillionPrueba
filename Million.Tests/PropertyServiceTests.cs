using Microsoft.VisualStudio.TestTools.UnitTesting;
using Million.Aplicacion.Servicios;
using Million.Dominio.Entidades;
using Million.Dominio.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Million.Tests
{
    [TestClass]
    public class PropertyServiceTests
    {
        private Mock<IPropertyRepository> _propertyRepositoryMock;
        private Mock<IPropertyImageRepository> _propertyImageRepositoryMock;
        private PropertyService _propertyService;

        [TestInitialize]
        public void Setup()
        {
            _propertyRepositoryMock = new Mock<IPropertyRepository>();
            _propertyImageRepositoryMock = new Mock<IPropertyImageRepository>();
            _propertyService = new PropertyService(_propertyRepositoryMock.Object, _propertyImageRepositoryMock.Object);
        }

        [TestMethod]
        public async Task CreatePropertyAsync_ShouldAddProperty()
        {
            // Arrange
            var property = new Property { IdProperty = 1, Name = "Test Property" };

            // Act
            var result = await _propertyService.CreatePropertyAsync(property);

            // Assert
            _propertyRepositoryMock.Verify(repo => repo.AddAsync(property), Times.Once);
            Assert.AreEqual(property, result);
        }

        [TestMethod]
        public async Task GetPropertyByIdAsync_ShouldReturnProperty()
        {
            // Arrange
            var property = new Property { IdProperty = 1, Name = "Test Property" };
            _propertyRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(property);

            // Act
            var result = await _propertyService.GetPropertyByIdAsync(1);

            // Assert
            Assert.AreEqual(property, result);
        }

        [TestMethod]
        public async Task UpdatePropertyAsync_ShouldUpdateProperty()
        {
            // Arrange
            var property = new Property { IdProperty = 1, Name = "Test Property" };
            _propertyRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(property);

            var updatedProperty = new Property { Name = "Updated Property" };

            // Act
            await _propertyService.UpdatePropertyAsync(1, updatedProperty);

            // Assert
            _propertyRepositoryMock.Verify(repo => repo.UpdateAsync(It.Is<Property>(p => p.Name == "Updated Property")), Times.Once);
        }

        [TestMethod]
        public async Task ListPropertiesAsync_ShouldReturnProperties()
        {
            // Arrange
            var properties = new List<Property> { new Property { IdProperty = 1, Name = "Test Property" } };
            _propertyRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(properties);

            // Act
            var result = await _propertyService.ListPropertiesAsync();

            // Assert
            Assert.AreEqual(properties, result);
        }
    }
}



