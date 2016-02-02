using System;
using System.Configuration;
using System.Reflection;
using AddinX.Configuration.Contract;
using AddinX.Configuration.Implementation;
using NUnit.Framework;

namespace AddinX.Configuration.UnitTest
{
    [TestFixture]
    public class ConnectionStringSettingsCollectionUnitTest
    {
        private IConnectionStringSettingsCollection cnxStringWrapper;
        private ConnectionStringSettings cnxStringSetting1;
        private ConnectionStringSettings cnxStringSetting2;

        [SetUp]
        public void StartUp()
        {
            cnxStringSetting1 = new ConnectionStringSettings("MyCnxString",
                "Data Source=ServerName;Initial Catalog=DataBaseName;Integrated Security=SSPI;"
                , "System.Data.SqlClient");

            cnxStringSetting2 = new ConnectionStringSettings("MyCnxStringTest",
                "Data Source=ServerName;Initial Catalog=DataBaseName;Integrated Security=SSPI;"
                , "System.Data.SqlClient");

            // Create an set of ConnectionString
            var cnxString = ConfigurationManager.ConnectionStrings;
            var field = typeof(ConfigurationElementCollection).GetField("bReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
            field.SetValue(cnxString, false);
            
            cnxString.Clear();
            cnxString.Add(cnxStringSetting1);
            cnxString.Add(cnxStringSetting2);
            cnxStringWrapper = new ConnectionStringSettingsCollectionWrapper(cnxString);
        }

        [Test]
        public void CopyTo_ThrowNotImplementedException()
        {
            // CopyTo Should throw an exception
            Assert.Throws<NotImplementedException>(() => cnxStringWrapper.CopyTo(new object[] { }, 1));
        }

        [Test]
        public void Remove_ByName()
        {
            // Prepare
            var count = cnxStringWrapper.Count;

            // Act
            cnxStringWrapper.Remove("MyCnxString");

            // Check
            Assert.IsTrue(cnxStringWrapper.Count == count - 1);
        }

        [Test]
        public void Remove_ByName_NotExisting()
        {
            // Prepare
            var count = cnxStringWrapper.Count;

            // Act
            cnxStringWrapper.Remove("MyCnxString2");

            // Check
            Assert.IsTrue(cnxStringWrapper.Count == count);
        }

        [Test]
        public void Remove_BySetting()
        {

            // Prepare
            var cnxSettingWrapper = new ConnectionStringSettingsWrapper(cnxStringSetting1);
            var count = cnxStringWrapper.Count;

            // Act
            cnxStringWrapper.Remove(cnxSettingWrapper);

            // Check
            Assert.IsTrue(cnxStringWrapper.Count == count - 1);
        }

        [Test]
        public void RemoveAt_FirstOne()
        {
            // Prepare
            var count = cnxStringWrapper.Count;

            // Act
            cnxStringWrapper.RemoveAt(0);

            // Check
            Assert.IsTrue(cnxStringWrapper.Count == count - 1);
        }

        [Test]
        public void IsReadOnly_ReturnFalse()
        {
            // Act - Asset
            Assert.IsTrue(!cnxStringWrapper.IsReadOnly());
        }

        [Test]
        public void IndexOf_CorrectPosition()
        {
            // Prepare
            var expected = 1;
            var cnxSettingWrapper = new ConnectionStringSettingsWrapper(cnxStringSetting2);

            // Act
            var result = cnxStringWrapper.IndexOf(cnxSettingWrapper);

            // Check
            Assert.True(result == expected);
        }

        [Test]
        public void Clear_CollectionIsEmpty()
        {
            // Prepare
            var expected = 0;


            // Act
            cnxStringWrapper.Clear();

            // Check
            Assert.True(cnxStringWrapper.Count == expected);
        }

        [Test]
        public void Add_AddOneElement()
        {
            // Prepare
            var expected = 1;
            var cnxStringSetting = new ConnectionStringSettingsWrapper(cnxStringSetting1);
            cnxStringWrapper.Clear();

            // Act
            cnxStringWrapper.Add(cnxStringSetting);

            // Check
            Assert.True(cnxStringWrapper.Count == expected);
            Assert.True(cnxStringWrapper[0].Name == cnxStringSetting1.Name);
        }

        [Test]
        public void GetElement_ByIndex()
        {
            // Prepare
            var expected = new ConnectionStringSettingsWrapper(cnxStringSetting1);

            // Act
            var item = cnxStringWrapper[0];

            // Check
            Assert.True(item.Name == expected.Name);
            Assert.True(item.ProviderName == expected.ProviderName);
            Assert.True(item.ConnectionString == expected.ConnectionString);
        }

        [Test]
        public void GetElement_ByName()
        {
            // Prepare
            var expected = new ConnectionStringSettingsWrapper(cnxStringSetting2);

            // Act
            var item = cnxStringWrapper["MyCnxStringTest"];

            // Check
            Assert.True(item.Name == expected.Name);
            Assert.True(item.ProviderName == expected.ProviderName);
            Assert.True(item.ConnectionString == expected.ConnectionString);
        }

        [Test]
        public void Count()
        {
            // Prepare
            var expected = 2;

            // Act
            var result = cnxStringWrapper.Count;

            // Check
            Assert.True(result == expected);
        }

        [Test]
        public void CollectionType_CheckValue()
        {
            // Prepare
            var expected = ConfigurationElementCollectionTypeEnum.AddRemoveClearMapAlternate;

            // Act
            var item = cnxStringWrapper.CollectionType;

            // Check
            Assert.AreEqual(item, expected);
        }

        [Test]
        public void GetEnumeartor()
        {
            // Prepare
            var expected = new ConnectionStringSettingsWrapper(cnxStringSetting1);

            // Act
            var item = cnxStringWrapper.GetEnumerator();
            item.MoveNext();
            var firstItem = (ConnectionStringSettingsWrapper)item.Current;

            // Check
            Assert.AreEqual(firstItem.Name, expected.Name);
        }
    }
}
