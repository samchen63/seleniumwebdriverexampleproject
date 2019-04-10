//-----------------------------------------------------------------------------
// <copyright file="Page.cs" company="Planit Testing">
//      Copyright © 2019 Planit Testing.
//      All rights reserved.
// </copyright>
// <created>26/03/2019</created>
// <author>Sam Chen</author>
//-----------------------------------------------------------------------------
namespace SeleniumWebDriverFramework.Pages
{
    using OpenQA.Selenium;

    // Parent class for all page objects
    public class Page
    {
        // Base url for the entire web site
        private const string BaseUrl = "https://www.planittesting.com";

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
    }
}
