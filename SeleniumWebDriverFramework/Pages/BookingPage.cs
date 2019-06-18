namespace SeleniumWebDriverFramework.Pages
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using SeleniumWebDriverFramework.Elements;

    // Booking course and service page
    public class BookingPage : Page
    {
        private readonly Link AddCourseLink;
        private readonly Select CourseSelect;
        private readonly Select DeliverySelect;
        private readonly Select StartDateSelect;
        private readonly Button AddCourseButton;
        private readonly Link BookedCourseTitleLink;
        private readonly Label BookedLocationLabel;
        private readonly Label BookedStartDateLabel;
        private readonly Link RemoveCourseLink;
        private readonly Label NoItemAddedLabel;

        public BookingPage(IWebDriver seleniumWebDriver) : base(seleniumWebDriver)
        {
            AddCourseLink = new Link(By.CssSelector("a[data-animation='fadeInUp'][data-open-form='.add-course']"), seleniumWebDriver);
            CourseSelect = new Select(By.Id("p_lt_ctl03_pageplaceholder_p_lt_ctl01_pageplaceholder_p_lt_ctl04_CheckoutAddCourse_drpDwnCourse"), seleniumWebDriver);
            DeliverySelect = new Select(By.Id("p_lt_ctl03_pageplaceholder_p_lt_ctl01_pageplaceholder_p_lt_ctl04_CheckoutAddCourse_drpDwnLocation"), seleniumWebDriver);
            StartDateSelect = new Select(By.Id("p_lt_ctl03_pageplaceholder_p_lt_ctl01_pageplaceholder_p_lt_ctl04_CheckoutAddCourse_drpDwnDate"), seleniumWebDriver);
            AddCourseButton = new Button(By.Id("p_lt_ctl03_pageplaceholder_p_lt_ctl01_pageplaceholder_p_lt_ctl04_CheckoutAddCourse_btnAddCourse"), seleniumWebDriver);
            BookedCourseTitleLink = new Link(By.CssSelector("#p_lt_ctl03_pageplaceholder_p_lt_ctl01_pageplaceholder_p_lt_ctl03_wWPZ_wWPZ_zone_wSCC_pnlCartContent > ul > li > div > div.booking_course-list_text > h4 > a"), seleniumWebDriver);
            BookedLocationLabel = new Label(By.CssSelector("#p_lt_ctl03_pageplaceholder_p_lt_ctl01_pageplaceholder_p_lt_ctl03_wWPZ_wWPZ_zone_wSCC_shoppingCartUniView_ctl01_ctl00_chooseLoaction_divLocation > span.booking_changeable-item.no-width-limit"), seleniumWebDriver);
            BookedStartDateLabel = new Label(By.CssSelector("#p_lt_ctl03_pageplaceholder_p_lt_ctl01_pageplaceholder_p_lt_ctl03_wWPZ_wWPZ_zone_wSCC_shoppingCartUniView_ctl01_ctl00_chooseLoaction_divDates > div > span"), seleniumWebDriver);
            RemoveCourseLink = new Link(By.Id("p_lt_ctl03_pageplaceholder_p_lt_ctl01_pageplaceholder_p_lt_ctl03_wWPZ_wWPZ_zone_wSCC_shoppingCartUniView_ctl01_ctl00_ctl00_btnRemove_hyperLink"), seleniumWebDriver);
            NoItemAddedLabel = new Label(By.CssSelector("#MainSection > section > div > section > div > div.booking_top-msg.text-center.animated.fadeInUp.visible > h4"), seleniumWebDriver);
        }

        public void ClickAddCourseLinkToPopupSelectionBar()
        {
            // Wait for add course link present before clicking it
            AddCourseLink.WaitForElementPresent();
            AddCourseLink.Click();
        }

        public void SelectACourseByName(string courseName)
        {
            // Wait for course name drop down present before selecting an option
            CourseSelect.WaitForElementPresent();
            CourseSelect.SelectByText(courseName);
        }

        public void SelectADeliveryLocationByName(string deliveryName)
        {
            // Wait for delivery location drop down enabled before selecting an option
            DeliverySelect.WaitForElementPresent();
            DeliverySelect.WaitForElementAttributeValue("class", "custom-select");
            DeliverySelect.SelectByText(deliveryName);
        }

        public void SelectADeliveryLocationByIndex(int index)
        {
            // Wait for delivery location drop down enabled before selecting an option
            DeliverySelect.WaitForElementPresent();
            DeliverySelect.WaitForElementAttributeValue("class", "custom-select");
            DeliverySelect.WaitForFirstOptionAvailable();
            DeliverySelect.SelectByIndex(index);
        }

        public void SelectAStartDateByIndex(int index)
        {
            // Wait for start date drop down enabled or "Start Today" auto selected before selecting an option
            StartDateSelect.WaitForElementPresent();
            StartDateSelect.WaitForElementAttributeValueOrSpecificSelection("class", "custom-select", "Start Today");
            // Select an option if "Start Today" is not auto selected
            if (StartDateSelect.GetText() != "Start Today")
            {
                StartDateSelect.WaitForFirstOptionAvailable();
                StartDateSelect.SelectByIndex(index);
            }
        }

        public string RetrieveDynamicStartDateFromSelectedStartDateOption()
        {
            return StartDateSelect.GetSelectedOptionText();
        }

        public void ClickAddCourseButtonToAddACourseIntoCart()
        {
            // Wait for add course link present before clicking it
            AddCourseButton.WaitForElementPresent();
            AddCourseButton.Click();
        }

        public void VerifyBookedCourseTitle(string title)
        {
            // Wait for booked course title present before getting text from it
            BookedCourseTitleLink.WaitForElementPresent();
            Assert.AreEqual(title, BookedCourseTitleLink.GetText());
        }

        public void VerifyBookedLocationValue(string location)
        {
            // Wait for booked location label present before getting text from it
            BookedLocationLabel.WaitForElementPresent();
            Assert.AreEqual(location, BookedLocationLabel.GetText());
        }

        public void VerifyBookedStartDateValue(string startDate)
        {
            // Wait for booked start date label present before getting text from it
            BookedStartDateLabel.WaitForElementPresent();
            Assert.AreEqual(startDate, BookedStartDateLabel.GetText());
        }

        public void ClickRemoveCourseLinkToDeleteAddedCourse()
        {
            // Wait for remove course link present before clicking it
            RemoveCourseLink.WaitForElementPresent();
            RemoveCourseLink.Click();
        }

        public void VerifyNoCourseToBeAddedIntoCart()
        {
            // If no item label appears, it means that all courses are removed
            NoItemAddedLabel.WaitForElementPresent();
        }
    }
}
