//-----------------------------------------------------------------------------
// <copyright file="BookingPage.cs" company="Planit Testing">
//      Copyright © 2019 Planit Testing.
//      All rights reserved.
// </copyright>
// <created>26/03/2019</created>
// <author>Sam Chen</author>
//-----------------------------------------------------------------------------

namespace SeleniumWebDriverFramework.Pages
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using SeleniumWebDriverFramework.Elements;

    // Booking course and service page
    public class BookingPage : Page
    {
        private readonly Link addCourseLink;
        private readonly Select courseSelect;
        private readonly Select deliverySelect;
        private readonly Select startDateSelect;
        private readonly Button addCourseButton;
        private readonly Link bookedCourseTitleLink;
        private readonly Label bookedLocationLabel;
        private readonly Label bookedStartDateLabel;
        private readonly Link removeCourseLink;
        private readonly Label noItemAddedLabel;

        public BookingPage(IWebDriver seleniumWebDriver) : base(seleniumWebDriver)
        {
            addCourseLink = new Link(By.CssSelector("a[data-animation='fadeInUp'][data-open-form='.add-course']"), seleniumWebDriver);
            courseSelect = new Select(By.Id("p_lt_ctl03_pageplaceholder_p_lt_ctl01_pageplaceholder_p_lt_ctl04_CheckoutAddCourse_drpDwnCourse"), seleniumWebDriver);
            deliverySelect = new Select(By.Id("p_lt_ctl03_pageplaceholder_p_lt_ctl01_pageplaceholder_p_lt_ctl04_CheckoutAddCourse_drpDwnLocation"), seleniumWebDriver);
            startDateSelect = new Select(By.Id("p_lt_ctl03_pageplaceholder_p_lt_ctl01_pageplaceholder_p_lt_ctl04_CheckoutAddCourse_drpDwnDate"), seleniumWebDriver);
            addCourseButton = new Button(By.Id("p_lt_ctl03_pageplaceholder_p_lt_ctl01_pageplaceholder_p_lt_ctl04_CheckoutAddCourse_btnAddCourse"), seleniumWebDriver);
            bookedCourseTitleLink = new Link(By.CssSelector("#p_lt_ctl03_pageplaceholder_p_lt_ctl01_pageplaceholder_p_lt_ctl03_wWPZ_wWPZ_zone_wSCC_pnlCartContent > ul > li > div > div.booking_course-list_text > h4 > a"), seleniumWebDriver);
            bookedLocationLabel = new Label(By.CssSelector("#p_lt_ctl03_pageplaceholder_p_lt_ctl01_pageplaceholder_p_lt_ctl03_wWPZ_wWPZ_zone_wSCC_shoppingCartUniView_ctl01_ctl00_chooseLoaction_divLocation > span.booking_changeable-item.no-width-limit"), seleniumWebDriver);
            bookedStartDateLabel = new Label(By.CssSelector("#p_lt_ctl03_pageplaceholder_p_lt_ctl01_pageplaceholder_p_lt_ctl03_wWPZ_wWPZ_zone_wSCC_shoppingCartUniView_ctl01_ctl00_chooseLoaction_divDates > div > span"), seleniumWebDriver);
            removeCourseLink = new Link(By.Id("p_lt_ctl03_pageplaceholder_p_lt_ctl01_pageplaceholder_p_lt_ctl03_wWPZ_wWPZ_zone_wSCC_shoppingCartUniView_ctl01_ctl00_ctl00_btnRemove_hyperLink"), seleniumWebDriver);
            noItemAddedLabel = new Label(By.CssSelector("#MainSection > section > div > section > div > div.booking_top-msg.text-center.animated.fadeInUp.visible > h4"), seleniumWebDriver);
        }

        public void ClickAddCourseLinkToPopupSelectionBar()
        {
            // Wait for add course link present before clicking it
            addCourseLink.WaitForElementPresent(addCourseLink.Identifier);
            addCourseLink.Click();
        }

        public void SelectACourseByName(string courseName)
        {
            // Wait for course name drop down present before selecting an option
            courseSelect.WaitForElementPresent(courseSelect.Identifier);
            courseSelect.SelectByText(courseName);
        }

        public void SelectADeliveryLocationByName(string deliveryName)
        {
            // Wait for delivery location drop down enabled before selecting an option
            deliverySelect.WaitForElementAttributeValue(deliverySelect.Identifier, "class", "custom-select");
            deliverySelect.SelectByText(deliveryName);
        }

        public void SelectADeliveryLocationByIndex(int index)
        {
            // Wait for delivery location drop down enabled before selecting an option
            deliverySelect.WaitForElementAttributeValue(deliverySelect.Identifier, "class", "custom-select");
            deliverySelect.SelectByIndex(index);
        }

        public void SelectAStartDateByIndex(int index)
        {
            // Wait for start date drop down enabled or "Start Today" auto selected before selecting an option
            startDateSelect.WaitForElementAttributeValueOrSpecificSelection(startDateSelect.Identifier, "class", "custom-select", "Start Today");
            // Select an option if "Start Today" is not auto selected
            if (startDateSelect.GetText() != "Start Today")
            {
                startDateSelect.SelectByIndex(index);
            }
        }

        public string RetrieveDynamicStartDateFromSelectedStartDateOption()
        {
            return startDateSelect.GetSelectedOptionText();
        }

        public void ClickAddCourseButtonToAddACourseIntoCart()
        {
            // Wait for add course link present before clicking it
            addCourseButton.WaitForElementPresent(addCourseButton.Identifier);
            addCourseButton.Click();
        }

        public void VerifyBookedCourseTitle(string title)
        {
            // Wait for booked course title present before getting text from it
            bookedCourseTitleLink.WaitForElementPresent(bookedCourseTitleLink.Identifier);
            Assert.AreEqual(title, bookedCourseTitleLink.GetText());
        }

        public void VerifyBookedLocationValue(string location)
        {
            // Wait for booked location label present before getting text from it
            bookedLocationLabel.WaitForElementPresent(bookedLocationLabel.Identifier);
            Assert.AreEqual(location, bookedLocationLabel.GetText());
        }

        public void VerifyBookedStartDateValue(string startDate)
        {
            // Wait for booked start date label present before getting text from it
            bookedStartDateLabel.WaitForElementPresent(bookedStartDateLabel.Identifier);
            Assert.AreEqual(startDate, bookedStartDateLabel.GetText());
        }

        public void ClickRemoveCourseLinkToDeleteAddedCourse()
        {
            // Wait for remove course link present before clicking it
            removeCourseLink.WaitForElementPresent(removeCourseLink.Identifier);
            removeCourseLink.Click();
        }

        public void VerifyNoCourseToBeAddedIntoCart()
        {
            // If no item label appears, it means that all courses are removed
            noItemAddedLabel.WaitForElementPresent(noItemAddedLabel.Identifier);
        }
    }
}
