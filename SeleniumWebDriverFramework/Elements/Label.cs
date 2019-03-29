//-----------------------------------------------------------------------------
// <copyright file="Label.cs" company="Planit Testing">
//      Copyright © 2019 Planit Testing.
//      All rights reserved.
// </copyright>
// <created>26/03/2019</created>
// <author>Sam Chen</author>
//-----------------------------------------------------------------------------

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
