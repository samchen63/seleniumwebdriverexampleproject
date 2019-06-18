namespace SeleniumWebDriverFramework.Pages
{
    using System.IO;
    using System.Reflection;

    using OpenQA.Selenium;

    // Parent class for all page objects
    public class Page
    {
        // Base url for the entire web site
        private const string BaseUrl = "https://www.planittesting.com";
        public string ImagePath = GetWorkingDirectory();

        public IWebDriver SeleniumWebDriver { get; set; }

        public Page(IWebDriver seleniumWebDriver)
        {
            SeleniumWebDriver = seleniumWebDriver;
        }

        public HomePage GoToHomePage()
        {
            // Navigate to Planit Testing Australian home page
            SeleniumWebDriver.Navigate().GoToUrl(BaseUrl + "/au/Home");
            return new HomePage(SeleniumWebDriver);
        }

        // Retrieve current working directory
        private static string GetWorkingDirectory()
        {
            return new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
        }
    }
}
