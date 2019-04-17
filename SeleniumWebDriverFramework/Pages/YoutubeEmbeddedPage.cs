//-----------------------------------------------------------------------------
// <copyright file="YoutubeEmbeddedPage.cs" company="Planit Testing">
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
    using Sikuli4Net.sikuli_REST;

    // What we do page which contains an embedded youtube video
    public class YoutubeEmbeddedPage : Page
    {
        private readonly Link QualityAcceleratedLink;
        private readonly Pattern PlayButtonPattern;
        private readonly Pattern PauseButtonPattern;
        private readonly Pattern MuteButtonPattern;
        private readonly Pattern UnmuteButtonPattern;
        private readonly Pattern SettingButtonPattern;
        private readonly Pattern QualityButtonPattern;
        private readonly Pattern FourEightZeroButtonPattern;
        private readonly Pattern FourEightZeroSelectedButtonPattern;
        private readonly Screen Screen;

        public YoutubeEmbeddedPage(IWebDriver seleniumWebDriver) : base(seleniumWebDriver)
        {
            QualityAcceleratedLink = new Link(By.CssSelector("a[class='service_second_menu-list_link js-service_second_menu-list_link'][href='#header2']"), seleniumWebDriver);
            Screen = new Screen();
            PlayButtonPattern = new Pattern(ImagePath + "\\Images\\play.png");
            PauseButtonPattern = new Pattern(ImagePath + "\\Images\\pause.png");
            MuteButtonPattern = new Pattern(ImagePath + "\\Images\\mute.png");
            UnmuteButtonPattern = new Pattern(ImagePath + "\\Images\\unmute.png");
            SettingButtonPattern = new Pattern(ImagePath + "\\Images\\setting.png");
            QualityButtonPattern = new Pattern(ImagePath + "\\Images\\quality.png");
            FourEightZeroButtonPattern = new Pattern(ImagePath + "\\Images\\480p.png");
            FourEightZeroSelectedButtonPattern = new Pattern(ImagePath + "\\Images\\480pselected.png");
        }

        public void ClickQualityAcceleratedLinkToYoutubeEmbeddedSection()
        {
            // Wait quality accelerated link present before clicking it
            QualityAcceleratedLink.WaitForElementPresent();
            QualityAcceleratedLink.Click();
        }

        public void ClickPlayButtonToPlayYoutubeVideo()
        {
            // Wait for play button and click it
            Screen.Wait(PlayButtonPattern);
		    Screen.Click(PlayButtonPattern);
	    }

        public void ClickPauseButtonToPauseYoutubeVideo()
        {
            // Wait for pause button and click it
            Screen.Wait(PauseButtonPattern);
            Screen.Click(PauseButtonPattern);
        }

        public void ClickMuteButtonToMuteYoutubeVideo()
        {
            // Wait for mute button and click it
            Screen.Wait(MuteButtonPattern);
            Screen.Click(MuteButtonPattern);
        }

        public void VerifyYoutubeVideoIsMuted()
        {
            // Assert for unmute button appearing
            Assert.IsTrue(Screen.Exists(UnmuteButtonPattern));
        }

        public void ClickSettingButtonToShowSettingMenu()
        {
            // Wait for setting button and click it
            Screen.Wait(SettingButtonPattern);
            Screen.Click(SettingButtonPattern);
        }

        public void ClickQualityButtonToShowProgressiveScanList()
        {
            // Wait for quality button and click it
            Screen.Wait(QualityButtonPattern);
            Screen.Click(QualityButtonPattern);
        }

        public void Click480pButtonToSelect480ProgressiveScan()
        {
            // Wait for 480p button and click it
            Screen.Wait(FourEightZeroButtonPattern);
            Screen.Click(FourEightZeroButtonPattern);
            // Allow mouse away from setting region
            Screen.Wait(MuteButtonPattern);
            Screen.Click(MuteButtonPattern);
        }

        public void Verify480pSelectedForQualityOfYoutubeVideo()
        {
            // Verify 480p selected as quality
            Assert.IsTrue(Screen.Exists(FourEightZeroSelectedButtonPattern));
        }
    }
}
