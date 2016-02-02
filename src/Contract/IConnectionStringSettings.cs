
namespace AddinX.Configuration.Contract
{
    /// <summary>
    /// Represents a single, named connection string in the connection strings configuration file section.
    /// </summary>
    public interface IConnectionStringSettings
    {
        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the ConnectionStringSettings name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the provider name property.
        /// </summary>
        string ProviderName { get; set; }

        /// <summary>
        /// Gets a value indicating whether the object is read-only
        /// </summary>
        /// <returns>Return a boolean </returns>
        bool IsReadOnly();


        /// <summary>
        /// Gets the object contained by this wrapper
        /// </summary>
        /// <returns>Return an object of type ConnectionStringSettings</returns>
        object GetObject();
    }
}