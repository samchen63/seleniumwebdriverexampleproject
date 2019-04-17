//-----------------------------------------------------------------------------
// <copyright file="YoutubeEmbeddedTest.cs" company="Planit Testing">
//      Copyright © 2019 Planit Testing.
//      All rights reserved.
// </copyright>
// <created>17/04/2019</created>
// <author>Sam Chen</author>
//-----------------------------------------------------------------------------
namespace SikuliTest
{
    using NUnit.Framework;
    using SeleniumWebDriverFramework.Pages;
    using SeleniumCSharpTest;

    /*
     * To test functionality of embedded youtube on planit testing web site
     */
    [TestFixture]
    public class YoutubeEmbeddedTest : BaseTest
    {
        /* 
         * Verify embedded youtube video can be muted
         */
        [Test]
        public void VerifyThatUserCanMuteYoutubeVideoOnYoutubeEmbeddedPage()
        {
            // Open the home page
            var homePage = Page.GoToHomePage();

            // Navigate to youtube embedded page
            var youtubeEmbeddedPage = homePage.ClickWhatWeDoLinkAndGoToYoutubeEmbeddedPage();

            // Navigate to embeded youtube section
            youtubeEmbeddedPage.ClickQualityAcceleratedLinkToYoutubeEmbeddedSection();
        
            // Play youtube video
            youtubeEmbeddedPage.ClickPlayButtonToPlayYoutubeVideo();
        
            // Pause youtube video
            youtubeEmbeddedPage.ClickPauseButtonToPauseYoutubeVideo();
        
            // Mute youtube video
            youtubeEmbeddedPage.ClickMuteButtonToMuteYoutubeVideo();
        
            // Verify youtube video is muted
            youtubeEmbeddedPage.VerifyYoutubeVideoIsMuted();
	    }

        /* 
        * Verify user can change progressive scan setting
        */
        [Test]
        public void verifyThatUserCanChangeProgressiveScanSettingOfYoutubeVideoOnYoutubeEmbeddedPage()
        {
            // Open the home page
            HomePage homePage = Page.GoToHomePage();

            // Navigate to youtube embedded page
            YoutubeEmbeddedPage youtubeEmbeddedPage = homePage.ClickWhatWeDoLinkAndGoToYoutubeEmbeddedPage();

            // Navigate to embeded youtube section
            youtubeEmbeddedPage.ClickQualityAcceleratedLinkToYoutubeEmbeddedSection();
        
            // Play youtube video
            youtubeEmbeddedPage.ClickPlayButtonToPlayYoutubeVideo();
        
            // Pause youtube video
            youtubeEmbeddedPage.ClickPauseButtonToPauseYoutubeVideo();
        
            // Change progressive scan to 480
            youtubeEmbeddedPage.ClickSettingButtonToShowSettingMenu();
            youtubeEmbeddedPage.ClickQualityButtonToShowProgressiveScanList();
            youtubeEmbeddedPage.Click480pButtonToSelect480ProgressiveScan();
        
            //Verify 480p is selected
            youtubeEmbeddedPage.ClickSettingButtonToShowSettingMenu();
            youtubeEmbeddedPage.Verify480pSelectedForQualityOfYoutubeVideo();
	    }
    }
}
