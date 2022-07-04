using MetaDataConfiguration.Shared.Helpers;
using System.Text.Json;

namespace MetaDataUnitTest
{
    [TestClass]
    public class SourceApiUnitTest
    {
        [TestMethod]
        public void TestSource1()
        {
            string defaultFieldUrl = $"https://localhost:7041/api/DefaultFields/Product";
            var tempDefaultFieldResult = new HttpClientHelper(new HttpClient()).GetResponse(defaultFieldUrl);
            var defaultFieldResult = JsonSerializer.Deserialize<string[]>(tempDefaultFieldResult);

            var actualRes = new string[] { "Field1", "Field2" };
            CollectionAssert.AreEqual(defaultFieldResult, actualRes);
        }

        [TestMethod]
        public void TestSource2()
        {
            string customFieldUrl = $"https://localhost:7041/api/CustomFields/Product";
            var tempCustomFieldResult = new HttpClientHelper(new HttpClient()).GetResponse(customFieldUrl);
            var customFieldResult = JsonSerializer.Deserialize<string[]>(tempCustomFieldResult);

            var actualRes = new string[] { "CField1", "CField2" };
            CollectionAssert.AreEqual(customFieldResult, actualRes);
        }
    }
}