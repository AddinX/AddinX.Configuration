using System.Collections.Specialized;

namespace AddinX.Configuration.Contract
{
    /// <summary>
    ///  <inheritdoc />
    /// </summary>
    public interface IConfigurationManager
    {
        /// <summary>
        /// Gets the AppSettings Section data for the current application's default configuration.
        /// </summary>
        NameValueCollection AppSettings { get; }

        /// <summary>
        /// Gets the <see cref="IConnectionStringSettings" /> data for the current application's default configuration.
        /// </summary>
        IConnectionStringSettingsCollection ConnectionStrings { get; }
    }
}