using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using BillzyAutomationTestSuite;
using BillzyAutomationTestSuite.PageObjects;
using BillzyAutomationTestSuite.Scripts;

namespace BillzyAutomationTestSuite.Scripts
{
    [TestFixture]
    [Parallelizable]
    class RegSuite_ClientManagement : Tests
    {
        [Test]
        public void ClientManagement01_TOM()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {

                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+398429851@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                ClientManagementPage clientpg = new ClientManagementPage(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                CardPage CardPg = new CardPage(WebDriver);

                SendPage SendPg = new SendPage(WebDriver);
                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                BillzyCashModal BillzyCashMlPg = new BillzyCashModal(WebDriver);
                SIVPage SIVPG1 = new SIVPage(WebDriver);
                HomePg.Profile().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                clientpg.AddCustomer().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));
                AddCustomerPage AddCustomerPg = new AddCustomerPage(WebDriver);
                Random rand = new Random();
                DateTime dt = new DateTime();
                string dtString = dt.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber1 = rand.Next();

                DateTime duedate1 = DateTime.Today;
                string SentPgDueDate = duedate1.ToString("yyMMMdd");
                string today = duedate1.ToString("dd/MM/yyyy");
                bool data111 = bodyTag.Text.Contains("Business Name");
                bool data22 = bodyTag.Text.Contains("ABN");
                bool data33 = bodyTag.Text.Contains("Contact Email");
                bool data44 = bodyTag.Text.Contains("Street");
                bool data55 = bodyTag.Text.Contains("Suburb");
                bool data66 = bodyTag.Text.Contains("Postcode");
                bool data77 = bodyTag.Text.Contains("Country");
                bool data88 = bodyTag.Text.Contains("State");
                bool data99 = bodyTag.Text.Contains("Contact Name");
                bool data1010 = bodyTag.Text.Contains("Contact Phone Number");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(data111 == true && data22 == true && data33 == true && data44 == true && data55 == true && data66 == true && data77 == true && data88 == true && data99 == true && data1010 == true);
                AddCustomerPg.BusinessName().Click();
                AddCustomerPg.BusinessName().SendKeys("1X ");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                bool data12 = bodyTag.Text.Contains("No similar Billzy businesses found.");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(data12 == true);

                AddCustomerPg.BusinessName().Click();
                AddCustomerPg.BusinessName().Clear();
                AddCustomerPg.BusinessName().SendKeys("1XZ ");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                bool data13 = bodyTag.Text.Contains("No similar Billzy businesses found.");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(data13 == true);


                AddCustomerPg.BusinessName().SendKeys("CM01-" + randnumber1);
                AddCustomerPg.Abn().SendKeys("10987654321");
                AddCustomerPg.ContactName().SendKeys("Test@" + randnumber1);
                AddCustomerPg.ContactEmail().SendKeys("madcowtesting10 + " + randnumber1 + "@gmail.com");
                AddCustomerPg.ContactPhoneNumber().SendKeys("12345671447");
                AddCustomerPg.Street().SendKeys("10 Miller Street");
                AddCustomerPg.Suburb().SendKeys("Murarrie");
                AddCustomerPg.Postcode().SendKeys("4172");
                AddCustomerPg.AddBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                AddCustomerPg.SelectCustomer().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                AddCustomerPg.EditCustomer().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                AddCustomerPg.EditBusinessName().SendKeys("CM01-" + randnumber1 + "edit");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                AddCustomerPg.SaveCustomer().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IWebElement bodyTag1 = WebDriver.FindElement(By.TagName("body"));
                bool edit = bodyTag1.Text.Contains("CM01-" + randnumber1 + "edit");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(edit == true);
                AddCustomerPg.RemoveCustomer().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                AddCustomerPg.ConfirmRemoveCustomer().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                clientpg.AddCustomer().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.BusinessName().Click();
                AddCustomerPg.BusinessName().SendKeys("madco");
                SeleniumSetMethods.WaitOnPage(secdelay3);

                IWebElement bodyTag0 = WebDriver.FindElement(By.TagName("body"));
                SeleniumSetMethods.WaitOnPage(secdelay3);
                bool data14 = bodyTag0.Text.Contains("10 similar Billzy businesses found.");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(data14 == true);
                AddCustomerPg.SelectCustomerlist().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                AddCustomerPg.AddBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
               
                bool billzylogo = clientpg.BillzyLogoIdentifier().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(billzylogo == true);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                AddCustomerPg.SelectCustomer().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                AddCustomerPg.RemoveCustomer().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                AddCustomerPg.ConfirmRemoveCustomer().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                //Show TOM score on member settings page
                TOM tompg = new TOM(WebDriver);
                tompg.TOMicon().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IWebElement bodyTag2 = WebDriver.FindElement(By.TagName("body"));
                bool tom1 = bodyTag2.Text.Contains("TOM (Trust Our Member)");
                bool tom2 = bodyTag2.Text.Contains("Your TOM score is calculated based on a range of weighted factors, which are measured during your membership.");
                bool tom3 = bodyTag2.Text.Contains("Interactions with other members, utilising cash flow optimising products billzy Cash or Deal and concluding business within the invoice terms will result in a healthy growth of your TOM score.");
                bool tom4 = bodyTag2.Text.Contains("A lack of interaction with other members, paying invoices late and infrequent use of invoicing will result in a lower TOM score.");
                bool tom5 = bodyTag2.Text.Contains("Getting a higher TOM score can mean lower rates for Cash and access to other offers from time to time.");
                bool tom6 = bodyTag2.Text.Contains("TOM Score");
                bool tom7 = bodyTag2.Text.Contains("Member Since");
                //string tom8 = tompg.Memnbershipdate().Text;
                //string tom9 = tompg.TOMScore().Text;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(tom1 == true && tom2 == true && tom3 == true && tom4 == true && tom5 == true && tom6 == true && tom7 == true );
                //Action action = new Action(WebDriver);
                //WebDriver.FindElement(TOMinfoIcon())
                tompg.TOMinfoIcon().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                WebDriver.PageSource.Contains("22/10/2019");
                WebDriver.PageSource.Contains("0/100");
                IWebElement bodyTag3 = WebDriver.FindElement(By.TagName("body"));
                WebDriver.PageSource.Contains("A new member typically starts with a score of 24.");
                WebDriver.PageSource.Contains("As your time as a member increases and you interact with others in the community, your score will increase.");
                WebDriver.PageSource.Contains("A higher score makes other members more likely to do business with you");
                WebDriver.PageSource.Contains("A higher score also gives you access to lower rates for Cash and other special benefits from time to time.");
                WebDriver.PageSource.Contains("Raising invoices and paying them on time increases the score.");
                WebDriver.PageSource.Contains("So does using the billzy cashflow management tools such as paying by card, billzy Deal and billzy Cash.");
                WebDriver.PageSource.Contains("Paying late or raising invoices that do not get paid will lower it.");
                SeleniumSetMethods.WaitOnPage(secdelay3);
            }
            finally
            {
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
            }

        }
        [Test]
        public void ClientManagement02_LockOut()
        {
            HomePage HomePg = new HomePage(WebDriver);
            SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
            try
            {

                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);
                // Successfull login on second attempt
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+1543313477@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Password1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));
                bool err1 = bodyTag.Text.Contains("Sorry, we were not able to find a member with that Email and Password.");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(err1 == true);
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);

                // Successfull login on second attempt
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+1543313477@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Password1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IWebElement bodyTag2 = WebDriver.FindElement(By.TagName("body"));
                bool err2 = bodyTag2.Text.Contains("Sorry, we were not able to find a member with that Email and Password.");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(err2 == true);
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Password1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                bool err22 = bodyTag2.Text.Contains("Your account will be locked for 3 minutes on the next unsuccessful attempt.");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(err22 == true);
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);

                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);

                // failed login for all three attempt
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+1543313477@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Password1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IWebElement bodyTag3 = WebDriver.FindElement(By.TagName("body"));
                bool err3 = bodyTag3.Text.Contains("Sorry, we were not able to find a member with that Email and Password.");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(err3 == true);
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Password1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                bool err33 = bodyTag3.Text.Contains("Your account will be locked for 3 minutes on the next unsuccessful attempt.");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(err33 == true);
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Password1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                bool err333 = bodyTag3.Text.Contains("Sorry, your account is temporarily locked for 2 minutes. Please try again later.");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(err333 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().Refresh();
                SeleniumSetMethods.WaitOnPage(50);
                SeleniumSetMethods.WaitOnPage(50);
                SeleniumSetMethods.WaitOnPage(20);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+1543313477@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Password1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                String ActualLoginError = loginPage.loginerr().Text;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(ActualLoginError.Contains("Sorry, your account is temporarily locked for 1 minute. Please try again later."));
                SeleniumSetMethods.WaitOnPage(50);
                SeleniumSetMethods.WaitOnPage(50);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().Refresh();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+1543313477@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);

                

                
            }
            finally
            {
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();
            }

        }
    }
}
