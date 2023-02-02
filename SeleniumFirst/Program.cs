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
    class Program
    {
        static void Main(string[] args)
        {
            //test 1.
            Console.Write("test case started ");
            //create the reference for the browser  
            IWebDriver driver = new ChromeDriver();
            // navigate to URL  
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            Thread.Sleep(2000);

            String title = driver.Title;
            if (title == "Swag Labs")
                Console.WriteLine("Test 1. :Uspjesno prikazana login stranica prilikom pokretanja aplikacije");

            //test 1.1.
            IWebElement ele2 = driver.FindElement(By.Name("user-name"));
            Boolean status = ele2.Enabled;
            
            String textUser = ele2.Text;
            //Console.WriteLine(status);
            //Console.WriteLine(textUser);
            if (status == true  && textUser == "")
                Console.WriteLine("Test 1.1. :Login page ima polje username i prazno je");
            Thread.Sleep(2000);

            //test 1.2.
            IWebElement ele3 = driver.FindElement(By.Name("password"));
            Boolean status1 = ele3.Enabled;

            String textPass = ele3.Text;
            //Console.WriteLine(status1);
            //Console.WriteLine(textPass);
            if (status1 == true && textPass == "")
                Console.WriteLine("Test 1.2. :Login page ima polje password i prazno je");
            Thread.Sleep(2000);

            //test 1.3.
            IWebElement ele4 = driver.FindElement(By.Name("login-button"));
            Boolean status4 = ele4.Displayed;
            ele4.Click();
            if (status4 == true)
                Console.WriteLine("Test 1.3 :Login page ima login button i moze se kliknuti");
            Thread.Sleep(2000);

            //test 1.3.1.
            IWebElement ele5 = driver.FindElement(By.ClassName("error-message-container error"));
            String textele5 = ele5.Text;
            Console.WriteLine(textele5);
            Thread.Sleep(2000);

            //close the browser  
            driver.Close();
            Console.Write("test case ended ");
        }
    }
}
