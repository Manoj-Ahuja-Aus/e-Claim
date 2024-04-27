using Amazon.DynamoDBv2.DataModel;
using CustomerPortal.Api.Models;
using CustomerPortal.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomerPortal.Api.Controllers
{
    /// <summary>
    /// This controller is responsible for handling customer related operations.
    /// </summary>

    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IDynamoDBContext _context;
        private readonly CustomerAddressService _customerAddressService;


        /// <summary>
        /// Constructor for CustomerController class.
        /// </summary>
        /// <param name="context">The DynamoDB context.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="customerAddressService">The customer address service.</param>
        /// <returns>
        /// 
        /// </returns>
        public CustomerController(IDynamoDBContext context, ILogger<CustomerController> logger, CustomerAddressService customerAddressService)
        {
            _logger = logger;
            _context = context;
            _customerAddressService = customerAddressService;
        }

        /// <summary>
        /// Retrieves the customer address associated with the given ID.
        /// </summary>
        /// <param name="Id">The ID of the customer address to retrieve.</param>
        /// <returns>The customer address associated with the given ID.</returns>

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCustomerAddressById(int Id)
        {
            var address = await _customerAddressService.GetAddressById(Id);
            if (address == null) return NotFound();

            return Ok(address);
        }

        /// <summary>
        /// Retrieves all customer addresses from the CustomerAddressService.
        /// </summary>
        /// <returns>
        /// An OkObjectResult containing a list of customer addresses.
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> GetAllCustomerAddresses()
        {
            var addresses = await _customerAddressService.GetAllAddresses();

            return Ok(addresses);
        }

        /// <summary>
        /// Creates a new customer address
        /// </summary>
        /// <param name="customerAddressrequest">The customer address request</param>
        /// <returns>
        /// Returns the created customer address or a bad request if the customer address already exists
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> CreateCustomerAddress(CustomerAddress customerAddressrequest)
        {
            // Validate if customer address already exists
            var createdAddress = await _customerAddressService.CreateAddress(customerAddressrequest);
            if (createdAddress == null) return BadRequest($"Customer Address with Id {customerAddressrequest.Id} Already Exists");

            return Ok(createdAddress);
        }

        /// <summary>
        /// Deletes a customer address by its Id.
        /// </summary>
        /// <param name="Id">The Id of the customer address to delete.</param>
        /// <returns>No content if the customer address was successfully deleted.</returns>
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCustomerAddress(int Id)
        {
            var address = await _customerAddressService.GetAddressById(Id);
            if (address == null) return NotFound();

            await _customerAddressService.DeleteAddress(address.Id);
            return NoContent();
        }

        /// <summary>
        /// Updates a customer address based on the provided customer address request.
        /// </summary>
        /// <param name="customerAddressrequest">The customer address request.</param>
        /// <returns>The updated customer address.</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateCustomerAddress(CustomerAddress customerAddressrequest)
        {
            // Validate if customer address exists
            var updatedAddress = await _customerAddressService.UpdateAddress(customerAddressrequest);
            if (updatedAddress == null) return NotFound();

            return Ok(updatedAddress);
        }
    }
}
