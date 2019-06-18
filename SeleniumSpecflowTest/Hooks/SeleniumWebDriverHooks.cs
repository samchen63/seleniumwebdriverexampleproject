namespace SeleniumSpecflowTest.Hooks
{
    using System.IO;
    using System.Reflection;

    using BoDi;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using SeleniumWebDriverFramework.Pages;
    using TechTalk.SpecFlow;

    [Binding]
    public class SeleniumWebDriverHooks
    {
        public IWebDriver SeleniumWebDriver;
        public Page Page;
        private readonly IObjectContainer ObjectContainer;

        // Constructor and Register IWebdDriver as context injection
        public SeleniumWebDriverHooks(IObjectContainer objectContainer)
        {
            ObjectContainer = objectContainer;
            // Use Chrome as testing browser
            SeleniumWebDriver = new ChromeDriver(new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName);

            // Register IWebDriver
            ObjectContainer.RegisterInstanceAs<IWebDriver>(SeleniumWebDriver);
        }

        // Create selenium web driver instance and launch browser for each test case
        [BeforeScenario]
        public void BeforeScenario()
        {
            // Maximize browser after launching it
            SeleniumWebDriver.Manage().Window.Maximize();

            // Create the page object
            Page = new Page(SeleniumWebDriver);
        }

        // Release selenium web driver instance and kill the process
        [AfterScenario]
        public void AfterScenario()
        {
            SeleniumWebDriver.Close();
            SeleniumWebDriver.Dispose();
        }
    }
}
