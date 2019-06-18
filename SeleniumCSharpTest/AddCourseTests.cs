namespace SeleniumCSharpTest
{
    using System.IO;

    using NUnit.Framework;
    using SeleniumWebDriverFramework.Pages;

    /*
     * To test functionality of adding courses from Planit Testing web site
     */
    [TestFixture]
    public class AddCourseTests : BaseTest
    {
        /* 
         * This is a scenario based test case to verify course details after adding a course on booking page 
         * by entering course name, delivery location and start date.
         */
        [Test]
        public void VerifyThatACourseCanBeAddedIntoCartOnBookingPage()
        {
            string courseName = "ISTQB Foundation Certificate";
            string location = "Sydney";

            // Open the home page
            var homePage = Page.GoToHomePage();

            // Navigate to booking page
            var bookingPage = homePage.ClickCartLinkAndGoToBookingPage();

            // Add a course by entering specific course name, delivery location and first start date
            bookingPage.ClickAddCourseLinkToPopupSelectionBar();
            bookingPage.SelectACourseByName(courseName);
            bookingPage.SelectADeliveryLocationByName(location);
            bookingPage.SelectAStartDateByIndex(1);

            // Save selected first available start date
            var selectedStartDateValue = bookingPage.RetrieveDynamicStartDateFromSelectedStartDateOption();

            // Verify details of that booked course
            bookingPage.ClickAddCourseButtonToAddACourseIntoCart();
            bookingPage.VerifyBookedCourseTitle(courseName);
            bookingPage.VerifyBookedLocationValue(location);
            bookingPage.VerifyBookedStartDateValue(selectedStartDateValue);
        }

        /*
         * This is a data driven test case to verify that all available courses can be added on booking page
         * A CSV file contains all available course names which are retrieved during test
         */
        [Test]
        public void VerifyAllAvailableCoursesFromCourseListCanBeAdded()
        {
            // Open the home page
            var homePage = Page.GoToHomePage();

            // Navigate to booking page
            var bookingPage = homePage.ClickCartLinkAndGoToBookingPage();

            // Read course name from a CSV file
            var streamReader = new StreamReader(GetWorkingDirectory() + "/TestData/CourseList.csv");

            string courseName;
            // Keep reading course name until the StreamReader reaches the end of file
            while ((courseName = streamReader.ReadLine()) != null)
            {
                // Add a course by course name from CSV file and verify course name, then delete it and repeat the cycle
                bookingPage.ClickAddCourseLinkToPopupSelectionBar();
                bookingPage.SelectACourseByName(courseName);
                bookingPage.SelectADeliveryLocationByIndex(1);
                bookingPage.SelectAStartDateByIndex(1);
                bookingPage.ClickAddCourseButtonToAddACourseIntoCart();
                bookingPage.VerifyBookedCourseTitle(courseName);
                bookingPage.ClickRemoveCourseLinkToDeleteAddedCourse();
                bookingPage.VerifyNoCourseToBeAddedIntoCart();
            }
        }
    }
}
