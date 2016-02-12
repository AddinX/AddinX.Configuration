using System.Configuration;
using AddinX.Configuration.Contract;

namespace AddinX.Configuration.Implementation
{
    /// <summary>
    ///  <inheritdoc />  
    /// </summary>
    public class ConnectionStringSettingsWrapper : IConnectionStringSettings
    {
        private readonly ConnectionStringSettings cnxSettings;

        /// <summary>
        ///  <inheritdoc />
        /// </summary>
        public ConnectionStringSettingsWrapper(ConnectionStringSettings cnxSettings)
        {
            this.cnxSettings = cnxSettings;
        }

        /// <summary>
        ///  <inheritdoc />
        /// </summary>
        public string ConnectionString
        {
            get { return cnxSettings.ConnectionString; }
            set { cnxSettings.ConnectionString = value; }
        }

        /// <summary>
        ///  <inheritdoc />
        /// </summary>
        public string Name
        {
            get { return cnxSettings.Name; }
            set { cnxSettings.Name = value; }
        }

        /// <summary>
        ///  <inheritdoc />
        /// </summary>
        public string ProviderName
        {
            get { return cnxSettings.ProviderName; }
            set { cnxSettings.ProviderName = value; }
        }

        /// <summary>
        ///  <inheritdoc />
        /// </summary>
        public bool IsReadOnly()
        {
            return cnxSettings.IsReadOnly();
        }

        /// <summary>
        ///  <inheritdoc />
        /// </summary>
        public object GetObject()
        {
            return cnxSettings;
        }
    }
}