using AddinX.Configuration.Implementation;
using NUnit.Framework;

namespace AddinX.Configuration.UnitTest
{
    [TestFixture]
    public class ConfigurationManagerUnitTest
    {
        [Test]
        public void AppSetting_GetData()
        {
            // Prepare
            var expected = "MyValue";
            var appSettings = new ConfigurationManagerWrapper().AppSettings;

            // Act
            var value = appSettings["Mykey"];

            // Assert
            Assert.AreEqual(value, expected);
        }

        [Test]
        public void CnxString_GetFirstOne()
        {
            // Prepare
            var expected = "Data Source=ServerName;Initial Catalog=DataBaseName;Integrated Security=SSPI;";
            var cnxStrings = new  ConfigurationManagerWrapper().ConnectionStrings;

            // Act
            var value = cnxStrings["TestCnxString"];

            // Assert
            Assert.AreEqual(value.ConnectionString, expected);
        }
    }
}