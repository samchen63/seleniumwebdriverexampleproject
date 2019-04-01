//-----------------------------------------------------------------------------
// <copyright file="BookingPageStepDefinition.cs" company="Planit Testing">
//      Copyright © 2019 Planit Testing.
//      All rights reserved.
// </copyright>
// <created>26/03/2019</created>
// <author>Sam Chen</author>
//-----------------------------------------------------------------------------
namespace SeleniumSpecflowTest.Steps
{
    using SeleniumWebDriverFramework.Pages;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class BookingPageStepDefinition
    {
        public BookingPage BookingPage;
        public string SelectedStartDateValue;

        public BookingPageStepDefinition(BookingPage bookingPage)
        {
            BookingPage = bookingPage;
        }
        
        // Click add course link
        [When(@"I click add course link on booking page")]
        public void WhenIClickAddCourseLinkOnBookingPage()
        {
            BookingPage.ClickAddCourseLinkToPopupSelectionBar();
        }

        // Select a course from drop down by course name
        [When(@"I select a course '(.*)' on booking page")]
        public void WhenISelectACourseOnBookingPage(string coursename)
        {
            BookingPage.SelectACourseByName(coursename);
        }

        // Select a course from drop down, course name is from example table
        [When(@"I select a course (.*) from example on booking page")]
        public void WhenISelectACourseFromExampleOnBookingPage(string coursename)
        {
            BookingPage.SelectACourseByName(coursename);
        }

        // Select a delivery location from drop down by location name
        [When(@"I select a delivery location '(.*)' on booking page")]
        public void WhenISelectADeliveryLocationOnBookingPage(string location)
        {
            BookingPage.SelectADeliveryLocationByName(location);
        }

        // Select a delivery location from drop down by poistion of option
        [When(@"I select option (.*) in delivery location on booking page")]
        public void WhenISelectOptionInDeliveryLocationOnBookingPage(int index)
        {
            BookingPage.SelectADeliveryLocationByIndex(index);
        }

        // Select a start date from drop down by position of option
        // And save selected value of start date for further use
        [When(@"I select option (.*) in start date on booking page")]
        public void WhenISelectOptionInStartDateOnBookingPage(int index)
        {
            BookingPage.SelectAStartDateByIndex(index);
            SelectedStartDateValue = BookingPage.RetrieveDynamicStartDateFromSelectedStartDateOption();
        }

        // Click add course button
        [When(@"I click add course button on booking page")]
        public void WhenIClickAddCourseButtonOnBookingPage()
        {
            BookingPage.ClickAddCourseButtonToAddACourseIntoCart();
        }

        // Verify title of booked course after adding a course
        [Then(@"the booked course title should be '(.*)' on booking page")]
        public void ThenTheBookedCourseTitleShouldBeOnBookingPage(string courseName)
        {
            BookingPage.VerifyBookedCourseTitle(courseName);
        }

        // Verify title of booked course after adding a course, course name is from example table
        [Then(@"the booked course title should be (.*) from example on booking page")]
        public void ThenTheBookedCourseTitleShouldBeFromExampleOnBookingPage(string courseName)
        {
            BookingPage.VerifyBookedCourseTitle(courseName);
        }

        // Verify delivery location after adding a course
        [Then(@"the booked delivery location should be '(.*)' on booking page")]
        public void ThenTheBookedDeliveryLocationShouldBeOnBookingPage(string location)
        {
            BookingPage.VerifyBookedLocationValue(location);
        }

        // Verify selected start date by using pre-saved start date
        [Then(@"the booked start date should be first option on booking page")]
        public void ThenTheBookedStartDateShouldBeFirstOptionOnBookingPage()
        {
            BookingPage.VerifyBookedStartDateValue(SelectedStartDateValue);
        }

        // Click remove course link
        [When(@"I click remove course link on booking page")]
        public void WhenIClickRemoveCourseLinkOnBookingPage()
        {
            BookingPage.ClickRemoveCourseLinkToDeleteAddedCourse();
        }

        // Verify no added course appearing on booking page
        [Then(@"no course should be added on booking page")]
        public void ThenNoCourseShouldBeAddedOnBookingPage()
        {
            BookingPage.VerifyNoCourseToBeAddedIntoCart();
        }
    }
}
