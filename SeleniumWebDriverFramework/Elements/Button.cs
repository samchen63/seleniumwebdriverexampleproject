namespace SeleniumWebDriverFramework.Elements
{
    using OpenQA.Selenium;

    public class Button : Element
    {
        public Button(By identifier, IWebDriver seleniumWebDriver)
            : base(identifier, seleniumWebDriver)
        {
        }

        // Click the button
        public void Click()
        {
            SeleniumWebDriver.FindElement(Identifier).Click();
        }
    }
}
