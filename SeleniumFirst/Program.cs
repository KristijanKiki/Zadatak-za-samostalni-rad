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
            IWebElement ele5 = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div[1]/div/form/div[3]"));
            String textele5 = ele5.Text;
            if (status == true && textUser == "" && textele5 == "Epic sadface: Username is required")
                Console.WriteLine("Test 1.3.1. :Ako se klikne login button a username textbox je prazan ispise se Epic sadface: Username is required");

            //test 1.3.2.
            //prvo unesemo bilo sto u username textbox
            ele2.SendKeys("bilo_koji_user");
            //kliknemo ponovo login
            ele4.Click();
            Thread.Sleep(2000);
            IWebElement ele6 = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div[1]/div/form/div[3]"));
            String textele6 = ele6.Text;
            if (status == true && textUser == "" && textele6 == "Epic sadface: Password is required")
                Console.WriteLine("Test 1.3.2. :Ako se klikne login button a username textbox je prazan ispise se Epic sadface: Password is required");

            //test 1.3.3.
            ele3.SendKeys("random_password");
            //kliknemo ponovo login
            ele4.Click();
            Thread.Sleep(2000);
            IWebElement ele7 = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div[1]/div/form/div[3]"));
            String textele7 = ele7.Text;
            if (ele3.Text != "secret_sauce" || ele2.Text != "standard_user" || ele2.Text != "performance_glitch_user" || ele2.Text != "problem_user" || ele2.Text != "locked_out_user") ;
            Console.WriteLine("Test 1.3.3. :Kada se stisne login a ili username ili password nije sa liste dobije se poruka Epic sadface: Username and password do not match any user in this service");
            Thread.Sleep(2000);

            //test 1.4.
            driver.Navigate().Refresh();

            IWebElement password = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div[1]/div/form/div[2]/input"));
            password.SendKeys("secret_sauce");
            Thread.Sleep(3000);
            IWebElement username = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div[1]/div/form/div[1]/input"));
            username.SendKeys("standard_user");
            Thread.Sleep(3000);
            IWebElement loginbutton = driver.FindElement(By.Name("login-button"));
            loginbutton.Click();
            Thread.Sleep(3000);
            IWebElement ele8 = driver.FindElement(By.XPath("/html/body/div/div/div/div[1]/div[2]"));
            String textele8 = ele8.Text;
            if (textele8.Contains("PRODUCTS"))
                Console.WriteLine("Test 1.4. :Kada se unese standardni user i ispravna lozinka otvori se products page");
            
            //test 1.4.1
            IWebElement productBackpack = driver.FindElement(By.Id("item_4_img_link"));
            Boolean statusBackpack = productBackpack.Enabled;
            IWebElement productBlackTshirt = driver.FindElement(By.Id("item_1_img_link"));
            Boolean statusBTshirt = productBlackTshirt.Enabled;
            IWebElement productRedTshirt = driver.FindElement(By.Id("item_3_img_link"));
            Boolean statusRTshirt = productRedTshirt.Enabled;
            IWebElement productJacket = driver.FindElement(By.Id("item_5_img_link"));
            Boolean statusJacket = productJacket.Enabled;
            IWebElement productBikeLight = driver.FindElement(By.Id("item_0_img_link"));
            Boolean statusBikeLight = productBikeLight.Enabled;
            IWebElement productOnesie = driver.FindElement(By.Id("item_2_img_link"));
            Boolean statusOnesie = productOnesie.Enabled;


            WebElement[] products = { (WebElement)productBackpack, (WebElement)productBikeLight, (WebElement)productBlackTshirt, (WebElement)productJacket, (WebElement)productOnesie, (WebElement)productRedTshirt};
            Console.WriteLine("Koji produkt želite kliknit (brojevi od 1-6)");
            int productInput = Convert.ToInt32(Console.ReadLine());

            if (statusBackpack && statusBTshirt && statusRTshirt && statusBikeLight && statusJacket && statusOnesie == true) 
            {
                IWebElement randomProduct = products[productInput-1];
                randomProduct.Click();
                Thread.Sleep(2500);
                IWebElement backToProducts = driver.FindElement(By.XPath("/html/body/div/div/div/div[1]/div[2]/div/button"));
                Console.WriteLine("Test 1.4.1. :Sve slike se mogu kliknuti i zoomira se slika i dobije detaljni opis produkta");
                Boolean backToProductsButton = backToProducts.Enabled;
                Thread.Sleep(3000);
                //test
                if (backToProductsButton == true)              
                {
                    Console.WriteLine("Test 1.4.1.1. :Kada je produkt zoomiran postoji back to products button koji se moze kliknuti");
                    backToProducts.Click();
                }

            }
            
            //test 1.4.1.2
            Thread.Sleep(2000);
            IWebElement shoppingCartIcon = driver.FindElement(By.XPath("/html/body/div/div/div/div[1]/div[1]/div[3]/a"));
            Boolean statusCart = shoppingCartIcon.Enabled;
            if (statusCart == true)
                shoppingCartIcon.Click();

            Thread.Sleep(1000);
            IWebElement yourCartPage = driver.FindElement(By.XPath("/html/body/div/div/div/div[1]/div[2]"));
            String yourCartTest = yourCartPage.Text;
            Console.WriteLine(yourCartTest);
            
            //test 1.4.1.3.

            if (yourCartTest.Contains ("YOUR CART"));
                Console.WriteLine("Test 1.4.1.2. shopping cart icon je clickable i kada se klikne ide se na your cart page");

            Console.Write("test case ended ");
        }
    }
}
