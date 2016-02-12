using System.Collections.Specialized;
using System.Configuration;
using AddinX.Configuration.Contract;

namespace AddinX.Configuration.Implementation
{
    /// <summary>
    /// <inheritdoc />
    /// </summary>
    public class ConfigurationManagerWrapper : IConfigurationManager
    {
        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public NameValueCollection AppSettings => ConfigurationManager.AppSettings;

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public IConnectionStringSettingsCollection ConnectionStrings
            => new ConnectionStringSettingsCollectionWrapper(ConfigurationManager.ConnectionStrings);
    }
}