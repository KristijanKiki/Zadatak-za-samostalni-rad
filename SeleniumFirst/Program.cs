using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumFirst
{
    class Program2
    {
        static void Main(string[] args)
        {
            Console.Write("test case started ");
            //create the reference for the browser  
            IWebDriver driver = new ChromeDriver();
            // navigate to URL  
            driver.Navigate().GoToUrl("https://www.youtube.com/");
            Thread.Sleep(5000);
            IWebElement ele1 = driver.FindElement(By.XPath("/html/body/ytd-app/ytd-consent-bump-v2-lightbox/tp-yt-paper-dialog/div[4]/div[2]/div[6]/div[1]/ytd-button-renderer[2]/yt-button-shape/button/yt-touch-feedback-shape/div/div[2]"));
            ele1.Click();
            Thread.Sleep(3000);


            IWebElement ele2 = driver.FindElement(By.XPath("/html/body/ytd-app/div[1]/div/ytd-masthead/div[3]/div[2]/ytd-searchbox/form/div[1]/div[1]/input"));
            ele2.SendKeys("Selenium coding tutorial");
            Thread.Sleep(2000);


            IWebElement ele3 = driver.FindElement(By.XPath("/html/body/ytd-app/div[1]/div/ytd-masthead/div[3]/div[2]/ytd-searchbox/button"));
            ele3.Click();
            Thread.Sleep(2000);

            //close the browser  
            driver.Close();
            Console.Write("test case ended ");
        }
    }
}
