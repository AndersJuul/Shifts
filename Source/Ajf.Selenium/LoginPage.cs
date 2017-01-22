using OpenQA.Selenium.Chrome;

namespace Ajf.Selenium
{
    public class LoginPage
    {
        public static void Go()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("test-type");
            var driver = new ChromeDriver(@"d:\selenium\", chromeOptions);

            driver.Navigate().GoToUrl("http://www.google.com");
        }
    }
}