using System.Collections;

namespace AddinX.Configuration.Contract
{
    /// <summary>
    /// Contains a collection of <see cref="IConnectionStringSettings" /> objects
    /// </summary>
    public interface IConnectionStringSettingsCollection : ICollection
    {
        /// <summary>
        /// Gets the type of the ConfigurationElementCollection/>
        /// </summary>
        ConfigurationElementCollectionTypeEnum CollectionType { get; }

        /// <summary>
        /// Gets or sets the connection string at the specified index in the collection.
        /// </summary>
        /// <param name="index">The index of a <see cref="IConnectionStringSettings"/> object in the collection.</param>
        /// <returns>The <see cref="IConnectionStringSettings"/> object at the specified index.</returns>
        IConnectionStringSettings this[int index] { get; set; }

        /// <summary>
        /// Gets or sets the ConnectionStringSettings object with the specified name in the collection.
        /// </summary>
        /// <param name="name">The name of a <see cref="IConnectionStringSettings"/> object in the collection.</param>
        /// <returns>he <see cref="IConnectionStringSettings"/> object with the specified name; otherwise, null.</returns>
        IConnectionStringSettings this[string name] { get; }

        /// <summary>
        /// Adds a <see cref="IConnectionStringSettings"/> object to the collection.
        /// </summary>
        /// <param name="settings">A <see cref="IConnectionStringSettings"/> object to add to the collection.</param>
        void Add(IConnectionStringSettings settings);

        /// <summary>
        /// Removes all the <see cref="IConnectionStringSettings"/> objects from the collection.
        /// </summary>
        void Clear();

        /// <summary>
        /// Returns the collection index of the passed <see cref="IConnectionStringSettings"/> object.
        /// </summary>
        /// <param name="settings">A <see cref="IConnectionStringSettings"/> object in the collection.</param>
        /// <returns>The collection index of the specified ConnectionStringSettingsCollection object.</returns>
        int IndexOf(IConnectionStringSettings settings);

        /// <summary>
        /// Indicates whether the ConfigurationElementCollection object is read only.
        /// </summary>
        /// <returns>true if the ConfigurationElementCollection object is read only; otherwise, false.</returns>
        bool IsReadOnly();

        /// <summary>
        /// Removes the specified <see cref="IConnectionStringSettings"/> object from the collection.
        /// </summary>
        /// <param name="settings">A <see cref="IConnectionStringSettings"/> object in the collection.</param>
        void Remove(IConnectionStringSettings settings);

        /// <summary>
        /// Removes the specified <see cref="IConnectionStringSettings"/> object from the collection.
        /// </summary>
        /// <param name="name">The name of a <see cref="IConnectionStringSettings"/> object in the collection.</param>
        void Remove(string name);

        /// <summary>
        /// Removes the specified <see cref="IConnectionStringSettings"/> object from the collection.
        /// </summary>
        /// <param name="index">The index of a <see cref="IConnectionStringSettings"/> object in the collection.</param>
        void RemoveAt(int index);
    }
}