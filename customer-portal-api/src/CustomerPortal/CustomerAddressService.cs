using CustomerPortal.Api.Models;
using CustomerPortal.Api.Persistence;
using System.ComponentModel.DataAnnotations;

namespace CustomerPortal.Api.Services
{
    /// <summary>
    /// This class provides methods for managing customer addresses.
    /// </summary>
    public class CustomerAddressService
    {
        private readonly IRepository<CustomerAddress> _repository;

        /// <summary>
        /// Constructor for CustomerAddressService class.
        /// </summary>
        /// <param name="repository">Repository of CustomerAddress type.</param>
        /// <returns>
        /// An instance of CustomerAddressService.
        /// </returns>
        public CustomerAddressService(IRepository<CustomerAddress> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Retrieves a CustomerAddress object from the repository by its Id.
        /// </summary>
        /// <param name="id">The Id of the CustomerAddress to retrieve.</param>
        /// <returns>A CustomerAddress object.</returns>
        public async Task<CustomerAddress> GetAddressById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        /// <summary>
        /// Gets all customer addresses from the repository.
        /// </summary>
        /// <returns>An enumerable of customer addresses.</returns>
        public async Task<IEnumerable<CustomerAddress>> GetAllAddresses()
        {
            return await _repository.GetAllAsync();
        }

        /// <summary>
        /// Creates a new address for a customer.
        /// </summary>
        /// <param name="address">The address to create.</param>
        /// <returns>True if the address was created successfully, false otherwise.</returns>
        public async Task<bool> CreateAddress(CustomerAddress address)
        {
            var validationResults = new List<ValidationResult>();
            if (!Validator.TryValidateObject(address, new ValidationContext(address), validationResults, true))
            {
                // Address is not valid based on the defined validation rules.
                return false;
            }

            var existingAddress = await _repository.GetByIdAsync(address.Id);
            if (existingAddress != null)
            {
                // An address with the same ID already exists.
                return false;
            }

            return await _repository.AddAsync(address);
        }

        /// <summary>
        /// Updates an existing customer address.
        /// </summary>
        /// <param name="address">The address to update.</param>
        /// <returns>True if the address was updated successfully; otherwise, false.</returns>
        public async Task<bool> UpdateAddress(CustomerAddress address)
        {
            if (!Validator.TryValidateObject(address, new ValidationContext(address), new List<ValidationResult>(), true))
            {
                // Address is not valid based on the defined validation rules.
                return false;
            }

            var existingAddress = await _repository.GetByIdAsync(address.Id);
            if (existingAddress == null)
            {
                // An address with the specified ID was not found.
                return false;
            }

            return await _repository.UpdateAsync(address);
        }

        /// <summary>
        /// Deletes an address with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the address to delete.</param>
        /// <returns>True if the address was deleted, false if an address with the specified ID was not found.</returns>
        public async Task<bool> DeleteAddress(int id)
        {
            var existingAddress = await _repository.GetByIdAsync(id);
            if (existingAddress == null)
            {
                // An address with the specified ID was not found.
                return false;
            }

            return await _repository.DeleteAsync(existingAddress);
        }
      

    }
}
