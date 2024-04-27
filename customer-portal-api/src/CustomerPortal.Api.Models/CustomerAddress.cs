
using Amazon.DynamoDBv2.DataModel;
namespace CustomerPortal.Api.Models
{
    [DynamoDBTable("CustomerAddress")]
    public class CustomerAddress
    {
        /// <summary>
        /// Property to store the Id of the entity.
        /// </summary>
        /// <param name="Id">The Id of the entity.</param>
        /// <returns>
        /// The Id of the entity.
        /// </returns>
        [DynamoDBHashKey("Id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the AddressLine1 property of the object.
        /// </summary>
        /// <param name="AddressLine1">The AddressLine1 property of the object.</param>
        /// <returns>The AddressLine1 property of the object.</returns>
        [DynamoDBProperty("AddressLine1")]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets the AddressLine2 property of the object.
        /// </summary>
        /// <param name="AddressLine2">The AddressLine2 property of the object.</param>
        /// <returns>The AddressLine2 property of the object.</returns>
        [DynamoDBProperty("AddressLine2")]
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the City property of the object.
        /// </summary>
        /// <param name="City">The City of the object.</param>
        /// <returns>The City of the object.</returns>
        [DynamoDBProperty("City")]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the State property of the object.
        /// </summary>
        /// <param name="State">The State of the object.</param>
        /// <returns>The State of the object.</returns>
        [DynamoDBProperty("State")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the PostalCode property of the object.
        /// </summary>
        /// <param name="PostalCode">The PostalCode of the object.</param>
        /// <returns>The PostalCode of the object.</returns>
        [DynamoDBProperty("PostalCode")]
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the Country property of the object.
        /// </summary>
        /// <param name="Country">The Country of the object.</param>
        /// <returns>The Country of the object.</returns>
        [DynamoDBProperty("Country")]
        public string Country { get; set; }
    }

}