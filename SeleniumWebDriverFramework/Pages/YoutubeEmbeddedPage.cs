namespace SeleniumWebDriverFramework.Pages
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using SeleniumWebDriverFramework.Elements;
    using SikuliSharp;

    // What we do page which contains an embedded youtube video
    public class YoutubeEmbeddedPage : Page
    {
        private readonly Link QualityAcceleratedLink;
        private readonly IPattern PlayButtonPattern;
        private readonly IPattern PauseButtonPattern;
        private readonly IPattern MuteButtonPattern;
        private readonly IPattern UnmuteButtonPattern;
        private readonly IPattern SettingButtonPattern;
        private readonly IPattern QualityButtonPattern;
        private readonly IPattern FourEightZeroButtonPattern;
        private readonly IPattern FourEightZeroSelectedButtonPattern;
        private readonly ISikuliSession Screen;

        public YoutubeEmbeddedPage(IWebDriver seleniumWebDriver) : base(seleniumWebDriver)
        {
            QualityAcceleratedLink = new Link(By.CssSelector("a[class='service_second_menu-list_link js-service_second_menu-list_link'][href='#header2']"), seleniumWebDriver);
            Screen = Sikuli.CreateSession();
            PlayButtonPattern = Patterns.FromFile(ImagePath + "\\Images\\play.png");
            PauseButtonPattern = Patterns.FromFile(ImagePath + "\\Images\\pause.png");
            MuteButtonPattern = Patterns.FromFile(ImagePath + "\\Images\\mute.png");
            UnmuteButtonPattern = Patterns.FromFile(ImagePath + "\\Images\\unmute.png");
            SettingButtonPattern = Patterns.FromFile(ImagePath + "\\Images\\setting.png");
            QualityButtonPattern = Patterns.FromFile(ImagePath + "\\Images\\quality.png");
            FourEightZeroButtonPattern = Patterns.FromFile(ImagePath + "\\Images\\480p.png");
            FourEightZeroSelectedButtonPattern = Patterns.FromFile(ImagePath + "\\Images\\480pselected.png");
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
            Screen.Hover(MuteButtonPattern);
        }

        public void Verify480pSelectedForQualityOfYoutubeVideo()
        {
            // Verify 480p selected as quality
            Assert.IsTrue(Screen.Exists(FourEightZeroSelectedButtonPattern));
        }
    }
}
