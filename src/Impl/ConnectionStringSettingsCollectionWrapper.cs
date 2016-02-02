using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using AddinX.Configuration.Contract;

namespace AddinX.Configuration.Implementation
{
    /// <summary>
    ///  Contains a collection of ConnectionStringSettings Wrapper objects.
    /// </summary>
    public class ConnectionStringSettingsCollectionWrapper : IConnectionStringSettingsCollection
    {
        private readonly ConnectionStringSettingsCollection cnxSettingsCollection;

        /// <summary>
        ///  Constructor for the ConnectionStringSettings Wrapper object
        /// </summary>
        /// <param name="cnxSettingsCollection"> The ConnectionStringSettings object</param>
        public ConnectionStringSettingsCollectionWrapper(ConnectionStringSettingsCollection cnxSettingsCollection)
        {
            this.cnxSettingsCollection = cnxSettingsCollection;
        }

        /// <summary>
        /// Gets an <see cref="IEnumerator"/> which is used to iterate through the IConnectionStringSettings
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            IList<IConnectionStringSettings> col =
                    (from ConnectionStringSettings cnxSetting in cnxSettingsCollection
                     select new ConnectionStringSettingsWrapper(cnxSetting))
                     .Cast<IConnectionStringSettings>().ToList();
            return col.GetEnumerator();
        }

        /// <summary>
        /// It will throw to an <exception cref="NotImplementedException"/>.
        /// </summary>
        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the number of elements in the collection.
        /// </summary>
        public int Count => cnxSettingsCollection.Count;


        /// <summary>
        /// Gets an object used to synchronize access to the <see cref="ConfigurationElementCollectionTypeEnum" />.
        /// </summary>
        public object SyncRoot => cnxSettingsCollection.SyncRoot;

        /// <summary>
        ///  <inheritdoc />
        /// </summary>
        public bool IsSynchronized => cnxSettingsCollection.IsSynchronized;

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public ConfigurationElementCollectionTypeEnum CollectionType
            => (ConfigurationElementCollectionTypeEnum)cnxSettingsCollection.CollectionType;

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        IConnectionStringSettings IConnectionStringSettingsCollection.this[int index]
        {
            get { return new ConnectionStringSettingsWrapper(cnxSettingsCollection[index]); }
            set { cnxSettingsCollection[index] = (ConnectionStringSettings)value.GetObject(); }
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        IConnectionStringSettings IConnectionStringSettingsCollection.this[string name]
            => new ConnectionStringSettingsWrapper(cnxSettingsCollection[name]);

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public void Add(IConnectionStringSettings settings)
        {
            if (settings != null)
            {
                cnxSettingsCollection.Add((ConnectionStringSettings)settings.GetObject());
            }
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public void Clear()
        {
            cnxSettingsCollection.Clear();
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public int IndexOf(IConnectionStringSettings settings)
        {
            return settings != null ?
                cnxSettingsCollection.IndexOf(
                    (ConnectionStringSettings)settings.GetObject()) : 0;
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public bool IsReadOnly()
        {
            return cnxSettingsCollection.IsReadOnly();
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public void Remove(IConnectionStringSettings settings)
        {
            if (settings != null)
            {
                cnxSettingsCollection.Remove(
                    (ConnectionStringSettings)settings.GetObject());
            }
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public void Remove(string name)
        {
            cnxSettingsCollection.Remove(name);
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public void RemoveAt(int index)
        {
            cnxSettingsCollection.RemoveAt(index);
        }
    }
}