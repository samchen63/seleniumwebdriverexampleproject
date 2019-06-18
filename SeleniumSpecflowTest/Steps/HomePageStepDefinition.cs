namespace SeleniumSpecflowTest.Steps
{
    using SeleniumWebDriverFramework.Pages;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class HomePageStepDefinition
    {
        public Page Page;
        public HomePage HomePage;
        public BookingPage BookingPage;

        // Constructor
        public HomePageStepDefinition(Page page)
        {
           Page = page;
        }

        // Navigate to home page
        [Given(@"I have navigated to home page")]
        public void GivenIHaveNavigatedToHomePage()
        {
            HomePage = Page.GoToHomePage();
        }

        // Click cart link and navigate to booking page
        [Given(@"I click cart link and go to booking page")]
        public void GivenIClickCartLinkAndGoToBookingPage()
        {
            BookingPage = HomePage.ClickCartLinkAndGoToBookingPage();
        }
    }
}
