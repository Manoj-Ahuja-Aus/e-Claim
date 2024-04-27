using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

namespace CustomerPortal.Api.Persistence
{
    /// <summary>
    /// Represents a DynamoDbRepository class which implements IRepository interface and provides methods for performing CRUD operations on DynamoDb. 
    /// </summary>
    public class DynamoDbRepository<T> : IRepository<T> where T : class
    {
        private readonly IDynamoDBContext _dynamoDBContext;

        /// <summary>
        /// Constructor for DynamoDbRepository class.
        /// </summary>
        /// <param name="dynamoDBClient">An instance of IAmazonDynamoDB.</param>
        /// <returns>
        /// An instance of DynamoDbRepository.
        /// </returns>
        public DynamoDbRepository(IAmazonDynamoDB dynamoDBClient)
        {
            _dynamoDBContext = new DynamoDBContext(dynamoDBClient);
        }

        /// <summary>
        /// Retrieves an item from DynamoDB by its id.
        /// </summary>
        /// <param name="id">The id of the item to retrieve.</param>
        /// <returns>The item with the specified id.</returns>
        // Asynchronous method to get an item from DynamoDB by its ID
        public async Task<T> GetByIdAsync(int id)
        {
            // Use the DynamoDB context to asynchronously load the item with the given ID
            return await _dynamoDBContext.LoadAsync<T>(id);
        }

        /// <summary>
        /// Retrieves all items from the DynamoDB table asynchronously.
        /// </summary>
        /// <returns>
        /// An enumerable of type T containing all items from the DynamoDB table.
        /// </returns>
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            // Scan the DynamoDB table for all items
            var scanResult = await _dynamoDBContext.ScanAsync<T>(new List<ScanCondition>()).GetNextSetAsync();

            // Return the items as an enumerable
            return scanResult.AsEnumerable();
        }

        /// <summary>
        /// Asynchronously adds an entity to the DynamoDB table.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>A boolean indicating whether the entity was successfully added.</returns>
        public async Task<bool> AddAsync(T entity)
        {
            // Try to save the entity to DynamoDB
            try
            {
                await _dynamoDBContext.SaveAsync(entity);
                // Return true if successful
                return true;
            }
            // Catch any errors
            catch
            {
                // Return false if unsuccessful
                return false;
            }
        }


        /// <summary>
        /// Updates an entity in DynamoDB
        /// </summary>
        /// <param name="entity">The entity to update</param>
        /// <returns>True if successful, false otherwise</returns>
        public async Task<bool> UpdateAsync(T entity)
        {
            // Try to save the entity to DynamoDB
            try
            {
                await _dynamoDBContext.SaveAsync(entity);
                // Return true if successful
                return true;
            }
            // Catch any errors
            catch
            {
                // Return false if unsuccessful
                return false;
            }
        }

        /// <summary>
        /// Asynchronously deletes an entity from the DynamoDB table.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        /// <returns>A boolean indicating whether the delete was successful.</returns>
        public async Task<bool> DeleteAsync(T entity)
        {
            // Try to delete the entity from DynamoDB
            try
            {
                await _dynamoDBContext.DeleteAsync<T>(entity);
                // Return true if successful
                return true;
            }
            // Catch any errors
            catch
            {
                // Return false if unsuccessful
                return false;
            }
        }

    }
}