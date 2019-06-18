namespace SeleniumCSharpTest
{
    using System.IO;
    using System.Reflection;

    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using SeleniumWebDriverFramework.Pages;

    // Parent class for all test objects
    [TestFixture]
    public class BaseTest
    {
        protected IWebDriver SeleniumWebDriver { get; set; }
        protected Page Page { get; set; }

        // Create selenium web driver instance and launch browser
        [SetUp]
        public void SetUp()
        {
            // Use Chrome as testing browser
            SeleniumWebDriver = new ChromeDriver(GetWorkingDirectory());

            // Maximize browser after launching it
            SeleniumWebDriver.Manage().Window.Maximize();

            // Create the page object
            Page = new Page(SeleniumWebDriver);
        }

        // Release selenium web driver instance and kill the process
        [TearDown]
        public void TearDown()
        {
            SeleniumWebDriver.Close();
            SeleniumWebDriver.Dispose();
        }

        // Retrieve current working directory
        public string GetWorkingDirectory()
        {
            return new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
        }
    }
}
