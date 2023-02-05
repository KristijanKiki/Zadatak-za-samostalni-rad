using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;

namespace SpecFlowYoutubeSearchKiki.StepDefinitions
{
    [Binding]
    public class YoutubeSearchFeatureStepDefinitions : IDisposable
    {
        private string searchKeyword;

        private ChromeDriver chromeDriver;


        public YoutubeSearchFeatureStepDefinitions() => chromeDriver = new ChromeDriver();


        [When(@"I press the search button")]
        public void WhenIPressTheSearchButton()
        {
            var searchButton = chromeDriver.FindElement(By.XPath("/html/body/ytd-app/div[1]/div/ytd-masthead/div[3]/div[2]/ytd-searchbox/button"));
            searchButton.Click();
        }

        [Given(@"Given I have navigated youtube website")]
        public void GivenIHaveNavigatedToYoutubeWebsite()
        {
            //pojavljuju mi se kolacici cim se otvori youtube
            chromeDriver.Navigate().GoToUrl("https://www.youtube.com");
            Thread.Sleep(5000);
            var cookieButton = chromeDriver.FindElement(By.XPath("/html/body/ytd-app/ytd-consent-bump-v2-lightbox/tp-yt-paper-dialog/div[4]/div[2]/div[6]/div[1]/ytd-button-renderer[2]/yt-button-shape/button/yt-touch-feedback-shape/div/div[2]"));
            cookieButton.Click();
            Thread.Sleep(2000);
            Assert.IsTrue(chromeDriver.Title.ToLower().Contains("youtube"));
        }

        [Given(@"I have entered (.*) as search keywords")]
        public void GivenIHaveEnteredSeleniumlAsSearchKeyword(string searchString)
        {
            this.searchKeyword = searchString.ToLower();
            var searchInputBox = chromeDriver.FindElement(By.XPath("/html/body/ytd-app/div[1]/div/ytd-masthead/div[3]/div[2]/ytd-searchbox/form/div[1]/div[1]/input"));
            searchInputBox.SendKeys(searchKeyword);
            Thread.Sleep(2000);
        }

        [Then(@"I should be navigate to search results page")]
        public void ThenIShouldBeNavigateToSearchResultsPage()
        {
            System.Threading.Thread.Sleep(2000);
            Assert.IsTrue(chromeDriver.Url.ToLower().Contains(searchKeyword));
            Assert.IsTrue(chromeDriver.Title.ToLower().Contains(searchKeyword));
        }
        public void Dispose()
        {
            if (chromeDriver != null)
            {
                chromeDriver.Dispose();
                chromeDriver = null;
            }
        }
    }
}
