using System.Configuration;
using AddinX.Configuration.Implementation;
using NUnit.Framework;

namespace AddinX.Configuration.UnitTest
{
    [TestFixture]
    public class ConnectionStringSettingsUnitTest
    {
        private ConnectionStringSettings cnxStringSetting1;

        [SetUp]
        public void StartUp()
        {
            cnxStringSetting1 = new ConnectionStringSettings("MyCnxString",
                "Data Source=ServerName;Initial Catalog=DataBaseName;Integrated Security=SSPI;"
                , "System.Data.SqlClient");
        }

        [Test]
        public void ConnectionString_GetValue()
        {
             // Prepare
             var cnxStringSettingWrapper = new ConnectionStringSettingsWrapper(cnxStringSetting1);   

            // Act
            var value = cnxStringSettingWrapper.ConnectionString;

            // Assert
            Assert.AreEqual(value, cnxStringSetting1.ConnectionString);
        }

        [Test]
        public void ConnectionString_SetValue()
        {
            // Prepare
            var cnxStringSettingWrapper = new ConnectionStringSettingsWrapper(cnxStringSetting1);
            var cnxStringValue = "Data Source=ServerName;Initial Catalog=UniqueDatabase;Integrated Security=SSPI;";

            // Act
            cnxStringSettingWrapper.ConnectionString= cnxStringValue;

            // Assert
            Assert.AreEqual(cnxStringSetting1.ConnectionString, cnxStringValue);
        }

        [Test]
        public void Name_GetValue()
        {
            // Prepare
            var cnxStringSettingWrapper = new ConnectionStringSettingsWrapper(cnxStringSetting1);

            // Act
            var value = cnxStringSettingWrapper.Name;

            // Assert
            Assert.AreEqual(value, cnxStringSetting1.Name);
        }

        [Test]
        public void Name_SetValue()
        {
            // Prepare
            var cnxStringSettingWrapper = new ConnectionStringSettingsWrapper(cnxStringSetting1);
            var nameCnx = "DataBaseCnx";

            // Act
            cnxStringSettingWrapper.Name = nameCnx;

            // Assert
            Assert.AreEqual(cnxStringSetting1.Name, nameCnx);
        }

        [Test]
        public void ProviderName_GetValue()
        {
            // Prepare
            var cnxStringSettingWrapper = new ConnectionStringSettingsWrapper(cnxStringSetting1);

            // Act
            var value = cnxStringSettingWrapper.ProviderName;

            // Assert
            Assert.AreEqual(value, cnxStringSetting1.ProviderName);
        }

        [Test]
        public void ProviderName_SetValue()
        {
            // Prepare
            var cnxStringSettingWrapper = new ConnectionStringSettingsWrapper(cnxStringSetting1);
            var providerName = "SQLNCLI";

            // Act
            cnxStringSettingWrapper.ProviderName = providerName;

            // Assert
            Assert.AreEqual(cnxStringSetting1.ProviderName, providerName);
        }

        [Test]
        public void IsReadOnly_GetValue()
        {
            // Prepare
            var cnxStringSettingWrapper = new ConnectionStringSettingsWrapper(cnxStringSetting1);

            // Act
            var value = cnxStringSettingWrapper.IsReadOnly();

            // Assert
            Assert.AreEqual(value, cnxStringSetting1.IsReadOnly());
        }

        [Test]
        public void GetObject_ReturnObject()
        {
            // Prepare
            var cnxStringSettingWrapper = new ConnectionStringSettingsWrapper(cnxStringSetting1);

            // Act
            var value = cnxStringSettingWrapper.GetObject();

            // Assert
            Assert.AreEqual(value, cnxStringSetting1);
        }
    }
}