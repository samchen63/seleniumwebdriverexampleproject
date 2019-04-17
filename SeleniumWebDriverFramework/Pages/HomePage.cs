//-----------------------------------------------------------------------------
// <copyright file="HomePage.cs" company="Planit Testing">
//      Copyright © 2019 Planit Testing.
//      All rights reserved.
// </copyright>
// <created>26/03/2019</created>
// <author>Sam Chen</author>
//-----------------------------------------------------------------------------
namespace SeleniumWebDriverFramework.Pages
{
    using OpenQA.Selenium;
    using SeleniumWebDriverFramework.Elements;

    // Planit Testing Australian home page
    public class HomePage : Page
    {
        private readonly Link BookingLink;
        private readonly Link WhatWeDoLink;

        public HomePage(IWebDriver seleniumWebDriver) : base(seleniumWebDriver)
        {
            BookingLink = new Link(By.Id("cartAnchorId"), seleniumWebDriver);
            WhatWeDoLink = new Link(By.Id("p_lt_ctl02_MegaMenu_whatWeDoLink"), seleniumWebDriver);
        }

        public BookingPage ClickCartLinkAndGoToBookingPage()
        {
            // Wait for booking link present before clicking it
            BookingLink.WaitForElementPresent();
            BookingLink.Click();
            return new BookingPage(SeleniumWebDriver);
        }

        public YoutubeEmbeddedPage ClickWhatWeDoLinkAndGoToYoutubeEmbeddedPage()
        {
            // Wait for what we do link present before clicking it
            WhatWeDoLink.WaitForElementPresent();
            WhatWeDoLink.Click();
            return new YoutubeEmbeddedPage(SeleniumWebDriver);
        }
    }
}
