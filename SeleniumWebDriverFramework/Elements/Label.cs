namespace SeleniumWebDriverFramework.Elements
{
    using OpenQA.Selenium;

    public class Label : Element
    {
        public Label(By identifier, IWebDriver seleniumWebDriver)
            : base(identifier, seleniumWebDriver)
        {
        }
    }
}
