using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NUnit.Framework;
namespace SeleniumTest
{
    class Sample1
    {
        //create the reference for the browser  
        IWebDriver driver = new ChromeDriver();
        [SetUp]
        public void Initialize()
        {
            //navigate to URL  
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            //Maximize the browser window  
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
        }
        [Test]
        public void Test1()
        {
            //Provjerava jel na stranici 
            String title = driver.Title;
            Assert.AreEqual(true, title.Contains("Swag Labs"), "Test 1 je pao");

            //Provjerava jel postoji username textbox i jel prazan
            IWebElement userNameTextbox = driver.FindElement(By.Name("user-name"));
            Boolean status = userNameTextbox.Enabled;

            String textUser = userNameTextbox.Text;

            Assert.AreEqual(true, status == true, "Test 1.1. je pao");
            Assert.AreEqual(true, textUser == "", "Test 1.1. je pao");

            //Provjerava jel postoji password textbox i jel prazan
            IWebElement passwordTextbox = driver.FindElement(By.Name("password"));
            Boolean status1 = passwordTextbox.Enabled;

            String textPass = passwordTextbox.Text;
            Assert.AreEqual(true, status1 == true, "Test 1.2. je pao");
            Assert.AreEqual(true, textPass == "", "Test 1.2. je pao");



            //Provjerava jel postoji login button koji se moze kliknit
            IWebElement loginButton = driver.FindElement(By.Name("login-button"));
            Boolean statusLoginButton = loginButton.Displayed;
            loginButton.Click();
            Assert.AreEqual(true, statusLoginButton == true, "Test 1.3. je pao");

            //Provjerava kad se klikne login koja poruka se izbaci ako je username prazan
            loginButton.Click();
            IWebElement errorMessageWhenNoUsername = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div[1]/div/form/div[3]"));
            String errorText = errorMessageWhenNoUsername.Text;
            Assert.AreEqual(true, errorText == "Epic sadface: Username is required", "Test 1.3.1. je pao");

            //Provjerava kad se klikne login button koja poruka se izbavi ako je user unesen a password prazan
            string userName = "Kiki";
            userNameTextbox.SendKeys(userName);
            Thread.Sleep(1000);
            //kliknemo ponovo login
            loginButton.Click();
            Thread.Sleep(2000);
            IWebElement errorMessageWhenNoPassword = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div[1]/div/form/div[3]"));
            String textWhenNoPass = errorMessageWhenNoPassword.Text;
            Assert.AreEqual(true, textWhenNoPass == "Epic sadface: Password is required", "Test 1.3.2. je pao");

            //Provjera kad se klikne login a username i password nisu na listi 
            string passwordInput = "random_password";
            passwordTextbox.SendKeys(passwordInput);
            Thread.Sleep(1000);
            //kliknemo ponovo login
            loginButton.Click();
            Thread.Sleep(2000);
            IWebElement errorWhenWrongUserOrPass = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div[1]/div/form/div[3]"));
            String textWhenWrongUserOrPass = errorWhenWrongUserOrPass.Text;
            if (passwordTextbox.Text != "secret_sauce" || userNameTextbox.Text != "standard_user" || userNameTextbox.Text != "performance_glitch_user" || userNameTextbox.Text != "problem_user" || userNameTextbox.Text != "locked_out_user")
                Assert.That(textWhenWrongUserOrPass, Is.EqualTo("Epic sadface: Username and password do not match any user in this service"));
            Thread.Sleep(2000);

            //Locked out user
            driver.Navigate().Refresh();
            Thread.Sleep(1000);
            IWebElement passwordReal = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div[1]/div/form/div[2]/input"));
            passwordReal.SendKeys("secret_sauce");
            Thread.Sleep(1000);
            IWebElement lockedOutUser = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div[1]/div/form/div[1]/input"));
            lockedOutUser.SendKeys("locked_out_user");
            IWebElement loginbutton = driver.FindElement(By.Name("login-button"));
            loginbutton.Click();
            Thread.Sleep(1000);
            IWebElement errorWhenLockedOut = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div[1]/div/form/div[3]"));
            String textWhenLockedout = errorWhenLockedOut.Text;
            Assert.AreEqual(true, textWhenLockedout == "Epic sadface: Sorry, this user has been locked out.", "Pao test Locked out");


            //test 1.4.
            driver.Navigate().Refresh();

            IWebElement password = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div[1]/div/form/div[2]/input"));
            password.SendKeys("secret_sauce");
            Thread.Sleep(3000);
            IWebElement username = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div[1]/div/form/div[1]/input"));
            username.SendKeys("standard_user");
            Thread.Sleep(3000);
            IWebElement loginbutton1 = driver.FindElement(By.Name("login-button"));
            loginbutton1.Click();
            Thread.Sleep(3000);
            IWebElement productPageName = driver.FindElement(By.XPath("/html/body/div/div/div/div[1]/div[2]"));
            String productsPageTest = productPageName.Text;
            Assert.AreEqual(true, productsPageTest.Contains("PRODUCTS"));


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

            //test 1.4.1
            WebElement[] products = { (WebElement)productBackpack, (WebElement)productBikeLight, (WebElement)productBlackTshirt, (WebElement)productJacket, (WebElement)productOnesie, (WebElement)productRedTshirt };
            int productInput = 3;

            Assert.Multiple(() =>
            {
                Assert.AreEqual(true, statusJacket == true);
                Assert.AreEqual(true, statusOnesie == true);
                Assert.AreEqual(true, statusBackpack == true);
                Assert.AreEqual(true, statusBikeLight == true);
                Assert.AreEqual(true, statusBTshirt == true);
                Assert.AreEqual(true, statusRTshirt == true);

            });

            IWebElement randomProduct = products[productInput - 1];
            randomProduct.Click();
            Thread.Sleep(2500);
            IWebElement backToProducts = driver.FindElement(By.XPath("/html/body/div/div/div/div[1]/div[2]/div/button"));
            Boolean backToProductsButton = backToProducts.Enabled;
            Assert.AreEqual(true, backToProductsButton == true);
            Thread.Sleep(3000);
            backToProducts.Click();

            //test 1.4.1.2
            Thread.Sleep(2000);
            IWebElement shoppingCartIcon = driver.FindElement(By.XPath("/html/body/div/div/div/div[1]/div[1]/div[3]/a"));
            Boolean statusCart = shoppingCartIcon.Enabled;
            Assert.AreEqual(true, statusCart == true);
            if (statusCart == true)
                shoppingCartIcon.Click();

            Thread.Sleep(1000);
            IWebElement yourCartPage = driver.FindElement(By.XPath("/html/body/div/div/div/div[1]/div[2]"));
            String yourCartTest = yourCartPage.Text;
            Thread.Sleep(1000);
            Assert.AreEqual(true, yourCartTest.Contains("YOUR CART"));
            
            
        }

        [TearDown]
        public void EndTest()
        {
            //close the browser  
            driver.Close();
        }
    }
}