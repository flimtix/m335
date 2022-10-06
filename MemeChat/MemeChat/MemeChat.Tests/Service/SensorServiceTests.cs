using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MemeChat.Service.Tests
{
    [TestClass()]
    public class SensorServiceTests
    {
        [TestMethod()]
        public void CreateBase64String_Null()
        {
            Assert.IsTrue(string.IsNullOrEmpty(SensorService.CreateBase64String(null)));
        }

        [TestMethod()]
        public void CreateBase64String_Big()
        {
            using var ms = new MemoryStream();

            ms.Write(new byte[1000000], 0, 1000000);

            Assert.IsFalse(string.IsNullOrEmpty(SensorService.CreateBase64String(ms)));
        }
    }
}