﻿//-----------------------------------------------------------------------------
// <copyright file="Element.cs" company="Planit Testing">
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
        public void WaitForElementPresent(By identifierType)
        {
            var myWait = new WebDriverWait(SeleniumWebDriver, TimeSpan.FromSeconds(Timeout));
            myWait.Until(d => d.FindElement(identifierType));
        }

        // Help method to wait for attribute value of element on the page
        public void WaitForElementAttributeValue(By identifierType, string attribute, string value)
        {
            var myWait = new WebDriverWait(SeleniumWebDriver, TimeSpan.FromSeconds(Timeout));
            myWait.Until(d => d.FindElement(identifierType).GetAttribute(attribute) == value);
        }

        // Help method to get text of element on the page
        public string GetText()
        {
            return SeleniumWebDriver.FindElement(Identifier).Text;
        }
    }
}
