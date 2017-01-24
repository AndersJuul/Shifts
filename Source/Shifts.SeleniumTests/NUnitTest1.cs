using Ajf.Selenium;
using NUnit.Framework;

namespace Shifts.SeleniumTests
{
    [TestFixture]
    public class NUnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            LoginPage.Go();
        }
    }
}