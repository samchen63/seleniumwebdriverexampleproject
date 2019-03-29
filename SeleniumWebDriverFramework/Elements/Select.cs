//-----------------------------------------------------------------------------
// <copyright file="Select.cs" company="Planit Testing">
//      Copyright © 2019 Planit Testing.
//      All rights reserved.
// </copyright>
// <created>26/03/2019</created>
// <author>Sam Chen</author>
//-----------------------------------------------------------------------------

namespace SeleniumWebDriverFramework.Elements
{
    using System;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public class Select : Element
    {
        public Select(By identifier, IWebDriver seleniumWebDriver)
            : base(identifier, seleniumWebDriver)
        {
        }

        // Select option by option's text
        public void SelectByText(string text)
        {
            var selectElement = new SelectElement(SeleniumWebDriver.FindElement(Identifier));
            selectElement.SelectByText(text);
        }

        // Select option by option's postition 
        public void SelectByIndex(int index)
        {
            var selectElement = new SelectElement(SeleniumWebDriver.FindElement(Identifier));
            selectElement.SelectByIndex(index);
        }

        // Retrieve value of selected text
        public string GetSelectedOptionText()
        {
            var selectElement = new SelectElement(SeleniumWebDriver.FindElement(Identifier));
            return selectElement.SelectedOption.Text;
        }

        // Help method to wait for a combination of conditions (attritube value and option's text)
        public void WaitForElementAttributeValueOrSpecificSelection(By identifierType, string attribute, string value, string text)
        {
            var myWait = new WebDriverWait(SeleniumWebDriver, TimeSpan.FromSeconds(Timeout));
            myWait.Until(d => d.FindElement(identifierType).GetAttribute(attribute) == value || d.FindElement(identifierType).Text == text);
        }
    }
}
