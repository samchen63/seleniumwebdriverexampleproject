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
        private readonly Link bookingLink;

        public HomePage(IWebDriver seleniumWebDriver) : base(seleniumWebDriver)
        {
            bookingLink = new Link(By.Id("cartAnchorId"), seleniumWebDriver);
        }

        public BookingPage ClickCartLinkAndGoToBookingPage()
        {
            // Wait for booking link present before clicking it
            bookingLink.WaitForElementPresent(bookingLink.Identifier);
            bookingLink.Click();
            return new BookingPage(SeleniumWebDriver);
        }
    }
}
