//-----------------------------------------------------------------------------
// <copyright file="Button.cs" company="Planit Testing">
//      Copyright © 2019 Planit Testing.
//      All rights reserved.
// </copyright>
// <created>26/03/2019</created>
// <author>Sam Chen</author>
//-----------------------------------------------------------------------------

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
