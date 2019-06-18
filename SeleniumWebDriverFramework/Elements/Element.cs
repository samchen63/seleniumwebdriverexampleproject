namespace SeleniumWebDriverFramework.Elements
{
    using System;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    // Parent class for all element objects
    public class Element
    {
        protected const int Timeout = 30;

        public IWebDriver SeleniumWebDriver { get; private set; }
        public By Identifier { get; private set; }

        public Element(By identifier, IWebDriver seleniumWebDriver)
        {
            SeleniumWebDriver = seleniumWebDriver;
            Identifier = identifier;
        }

        // Help method to wait for element present on the page
        public void WaitForElementPresent()
        {
            var myWait = new WebDriverWait(SeleniumWebDriver, TimeSpan.FromSeconds(Timeout));
            myWait.Until(d => d.FindElement(Identifier));
        }

        // Help method to wait for attribute value of element on the page
        public void WaitForElementAttributeValue(string attribute, string value)
        {
            var myWait = new WebDriverWait(SeleniumWebDriver, TimeSpan.FromSeconds(Timeout));
            myWait.Until(d => d.FindElement(Identifier).GetAttribute(attribute) == value);
        }

        // Help method to get text of element on the page
        public string GetText()
        {
            return SeleniumWebDriver.FindElement(Identifier).Text;
        }
    }
}
