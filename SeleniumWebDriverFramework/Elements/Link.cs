namespace SeleniumWebDriverFramework.Elements
{
    using OpenQA.Selenium;

    public class Link : Element
    {

        public Link(By identifier, IWebDriver seleniumWebDriver)
            : base(identifier, seleniumWebDriver)
        {
        }

        // Click the link
        public void Click()
        {
            SeleniumWebDriver.FindElement(Identifier).Click();
        }
    }
}
