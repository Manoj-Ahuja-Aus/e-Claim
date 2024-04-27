using CustomerPortal.Api.Models;
using CustomerPortal.Api.Persistence;
using CustomerPortal.Api.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CustomerPortal.Tests.Services
{
    [TestClass]
    public class CustomerAddressServiceTests
    {
        private CustomerAddressService _service;
        private Mock<IRepository<CustomerAddress>> _repositoryMock;


        public void Setup()
        {
            _repositoryMock = new Mock<IRepository<CustomerAddress>>();
            _service = new CustomerAddressService(_repositoryMock.Object);
        }

        [TestMethod]
        public async Task GetAddressById_ValidId_ReturnsAddress()
        {
            // Arrange
            var expectedAddress = new CustomerAddress { Id = 1, AddressLine1 = "123 Main St" };
            _repositoryMock.Setup(repo => repo.GetByIdAsync(expectedAddress.Id))
                           .ReturnsAsync(expectedAddress);

            // Act
            var address = await _service.GetAddressById(expectedAddress.Id);

            // Assert
            Assert.AreEqual(expectedAddress, address);
        }

        [TestMethod]
        public async Task GetAddressById_InvalidId_ReturnsNull()
        {
            // Arrange
            _repositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                           .ReturnsAsync((CustomerAddress)null);

            // Act
            var address = await _service.GetAddressById(0);

            // Assert
            Assert.IsNull(address);
        }

        [TestMethod]
        public async Task GetAllAddresses_ReturnsAllAddresses()
        {
            // Arrange
            var expectedAddresses = new List<CustomerAddress> {
                new CustomerAddress { Id = 1, AddressLine1 = "123 Main St" },
                new CustomerAddress { Id = 2, AddressLine1 = "456 Elm St" },
                new CustomerAddress { Id = 3, AddressLine1 = "789 Oak St" }
            };
            _repositoryMock.Setup(repo => repo.GetAllAsync())
                           .ReturnsAsync(expectedAddresses);

            // Act
            var addresses = await _service.GetAllAddresses();

            // Assert
            Assert.AreEqual(expectedAddresses, addresses.ToList());
        }

        [TestMethod]
        public async Task CreateAddress_ValidAddress_CallsRepositoryAddAsync()
        {
            // Arrange
            var address = new CustomerAddress { Id = 1, AddressLine1 = "123 Main St" };
            _repositoryMock.Setup(repo => repo.GetByIdAsync(address.Id))
                           .ReturnsAsync((CustomerAddress)null);
            _repositoryMock.Setup(repo => repo.AddAsync(address))
                           .ReturnsAsync(true);

            // Act
            var result = await _service.CreateAddress(address);

            // Assert
            Assert.IsTrue(result);
            _repositoryMock.Verify(repo => repo.AddAsync(address), Times.Once);
        }

        [TestMethod]
        public async Task CreateAddress_InvalidAddress_ReturnsFalse()
        {
            // Arrange
            var address = new CustomerAddress { Id = 1, AddressLine1 = null };

            // Act
            var result = await _service.CreateAddress(address);

            // Assert
            Assert.IsFalse(result);
            _repositoryMock.Verify(repo => repo.AddAsync(address), Times.Never);
        }

        [TestMethod]
        public async Task CreateAddress_AddressAlreadyExists_ReturnsFalse()
        {
            // Arrange
            var address = new CustomerAddress { Id = 1, AddressLine1 = "123 Main St" };
            _repositoryMock.Setup(repo => repo.GetByIdAsync(address.Id))
                           .ReturnsAsync(address);

            // Act
            var result = await _service.CreateAddress(address);

            // Assert
            Assert.IsFalse(result);
            _repositoryMock.Verify(repo => repo.AddAsync(address), Times.Never);
        }

        [TestMethod]
        public async Task UpdateAddress_ValidAddress_CallsRepositoryUpdateAsync()
        {
            // Arrange
            var address = new CustomerAddress { Id = 1, AddressLine1 = "123 Main St" };
            _repositoryMock.Setup(repo => repo.GetByIdAsync(address.Id))
                           .ReturnsAsync(address);
            _repositoryMock.Setup(repo => repo.UpdateAsync(address))
                           .ReturnsAsync(true);

            // Act
            var result = await _service.UpdateAddress(address);

            // Assert
            Assert.IsTrue(result);
            _repositoryMock.Verify(repo => repo.UpdateAsync(address), Times.Once);
        }

        [TestMethod]
        public async Task UpdateAddress_InvalidAddress_ReturnsFalse()
        {
            // Arrange
            var address = new CustomerAddress { Id = 1, AddressLine1 = null };

            // Act
            var result = await _service.UpdateAddress(address);

            // Assert
            Assert.IsFalse(result);
            _repositoryMock.Verify(repo => repo.UpdateAsync(address), Times.Never);
        }

        [TestMethod]
        public async Task UpdateAddress_AddressDoesNotExist_ReturnsFalse()
        {
            // Arrange
            var address = new CustomerAddress { Id = 1, AddressLine1 = "123 Main St" };
            _repositoryMock.Setup(repo => repo.GetByIdAsync(address.Id))
                           .ReturnsAsync((CustomerAddress)null);

            // Act
            var result = await _service.UpdateAddress(address);

            // Assert
            Assert.IsFalse(result);
            _repositoryMock.Verify(repo => repo.UpdateAsync(address), Times.Never);
        }

        [TestMethod]
        public async Task DeleteAddress_ValidId_CallsRepositoryDeleteAsync()
        {
            // Arrange
            var address = new CustomerAddress { Id = 1, AddressLine1 = "123 Main St" };
            _repositoryMock.Setup(repo => repo.GetByIdAsync(address.Id))
                           .ReturnsAsync(address);
            _repositoryMock.Setup(repo => repo.DeleteAsync(address))
                           .ReturnsAsync(true);

            // Act
            var result = await _service.DeleteAddress(address.Id);

            // Assert
            Assert.IsTrue(result);
            _repositoryMock.Verify(repo => repo.DeleteAsync(address), Times.Once);
        }

        [TestMethod]
        public async Task DeleteAddress_AddressDoesNotExist_ReturnsFalse()
        {
            // Arrange
            _repositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                           .ReturnsAsync((CustomerAddress)null);

            // Act
            var result = await _service.DeleteAddress(0);

            // Assert
            Assert.IsFalse(result);
            _repositoryMock.Verify(repo => repo.DeleteAsync(It.IsAny<CustomerAddress>()), Times.Never);
        }
    }
}
