
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using BillzyAutomationTestSuite;
using BillzyAutomationTestSuite.PageObjects;
using BillzyAutomationTestSuite.Scripts;
using System.Drawing;
using System.Net;
using OpenQA.Selenium.Remote;
using System.Net.Sockets;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using System;
using OpenQA.Selenium;

namespace BillzyAutomationTestSuite.Scripts
{
    class CardManagement : Tests
    {

        [Test]
        public void AddDeleteCards01()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {


                Console.WriteLine(WebDriver.Manage().Window.Size);
                /*

                WebDriver.Manage().Window.Size = new Size(825, 990);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Console.WriteLine(WebDriver.Manage().Window.Size);
                Console.WriteLine("Test");
                */
                

                WebDriver.Manage().Window.Maximize();

                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                
                
                LoginPage loginPage = new LoginPage(WebDriver);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+cardmanagmnt01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                CardPage CardPg = new CardPage(WebDriver);

                SendPage SendPg = new SendPage(WebDriver);
                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                BillzyCashModal BillzyCashMlPg = new BillzyCashModal(WebDriver);
                SIVPage SIVPG1 = new SIVPage(WebDriver);
                HomePg.Profile().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.CardMgmnt().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                CardPg.AddCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                //testInfo = Test 1 : Card Management - "Add Card" All Fields Displayed
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));
                bool card1 = bodyTag.Text.Contains("Add Card");
                bool card2 = bodyTag.Text.Contains("Name on Credit Card");
                bool card3 = bodyTag.Text.Contains("Credit Card Number");
                bool card4 = bodyTag.Text.Contains("Expiry Date");
                bool card5 = bodyTag.Text.Contains("Account Nickname");
                bool CardField1 = CardPg.CardName().Displayed;
                bool CardField2 = CardPg.NumberOnCard().Displayed;
                bool CardField3 = CardPg.EndMonth().Displayed;
                bool CardField4 = CardPg.EndYear().Displayed;
                bool CardField5 = CardPg.CardNickname().Displayed;
                bool CardField6 = CardPg.AddCard().Displayed;
                bool CardField7 = CardPg.Cancel().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(card1 == true && card2 == true && card3 == true && card4 == true && card5 == true && CardField1 == true && CardField2 == true && CardField3 == true && CardField4 == true && CardField5 == true && CardField6 == true && CardField7 == true);

                //Master Card
                CardPg.CardName().SendKeys("Credit Card Owner");
                CardPg.NumberOnCard().SendKeys("5454545454545454");
                CardPg.EndMonth().SendKeys("12");
                CardPg.EndYear().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                CardPg.EndYear().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                CardPg.EndYear().SendKeys("21");
                CardPg.CardCvc().SendKeys("123");
                CardPg.CardNickname().SendKeys("TestOnly");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                CardPg.AddCard2().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                CardPg.DeleteCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //Visa Card
                CardPg.AddCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                CardPg.CardName().SendKeys("Credit Card Owner");
                CardPg.NumberOnCard().SendKeys("4111111111111111");
                CardPg.EndMonth().SendKeys("12");
                CardPg.EndYear().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                CardPg.EndYear().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                CardPg.EndYear().SendKeys("21");
                CardPg.CardCvc().SendKeys("123");
                CardPg.CardNickname().SendKeys("TestOnly");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                CardPg.AddCard2().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                CardPg.DeleteCard().Click();
                //Add  invalid Card number " Credit Card Number Field Error message
                SeleniumSetMethods.WaitOnPage(secdelay2);
                CardPg.AddCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                CardPg.CardName().SendKeys("Credit Card Owner");
                CardPg.NumberOnCard().SendKeys("4111111111111199");
                CardPg.EndMonth().SendKeys("12");
                CardPg.EndYear().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                CardPg.EndYear().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                CardPg.EndYear().SendKeys("21");
                CardPg.CardCvc().SendKeys("123");
                CardPg.CardNickname().SendKeys("TestOnly");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                CardPg.AddCard2().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag1 = WebDriver.FindElement(By.TagName("body"));
                bool err1 = bodyTag1.Text.Contains("Invalid card number.");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(err1 == true);
                CardPg.AddCard().Click();
                IWebElement bodyTag11 = WebDriver.FindElement(By.TagName("body"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool refresh1 = bodyTag11.Text.Contains("Add Credit Card");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(refresh1 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().Refresh();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                IWebElement bodyTag22 = WebDriver.FindElement(By.TagName("body"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool refresh11 = bodyTag22.Text.Contains("Add Credit Card");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(refresh11 == false);
                CardPg.AddCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                CardPg.CardName().SendKeys("Credit Card Owner");
                CardPg.NumberOnCard().SendKeys("8113131313133313");
                CardPg.EndMonth().SendKeys("12");
                CardPg.EndYear().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                CardPg.EndYear().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                CardPg.EndYear().SendKeys("21");
                CardPg.CardCvc().SendKeys("123");
                CardPg.CardNickname().SendKeys("TestOnly");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                CardPg.AddCard2().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag2 = WebDriver.FindElement(By.TagName("body"));
                bool err2 = bodyTag2.Text.Contains("Only Visa and MasterCard are accepted at present.");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(err2 == true);
                CardPg.Cancel().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //Add Debit Card functionality
                DebitCardPage DebitPg = new DebitCardPage(WebDriver);
                DebitPg.DebitCardBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                DebitPg.AddBankAccountBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                DebitPg.NameofAccount().SendKeys("AddDebitAccount1");
                DebitPg.Bsb().SendKeys("123456");
                DebitPg.AccountNumber().SendKeys("123456789");
                DebitPg.BankName().SendKeys("commBank");
                DebitPg.AccountNickname().SendKeys("DebitNickName1");
                DebitPg.TCCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                DebitPg.AddDebitAccountBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                IWebElement bodyTag3 = WebDriver.FindElement(By.TagName("body"));
                bool bank1 = bodyTag3.Text.Contains("Account Nickname");
                bool bank2 = bodyTag3.Text.Contains("BSB");
                bool bank3 = bodyTag3.Text.Contains("Account Number");
                bool bank4 = bodyTag3.Text.Contains("Bank");
                bool bank5 = bodyTag3.Text.Contains("Account Name");
                bool bankField1 = bodyTag3.Text.Contains("Delete");
                bool bankField2 = bodyTag3.Text.Contains("DebitNickName1");
                bool bankField3 = bodyTag3.Text.Contains("123456");
                bool bankField4 = bodyTag3.Text.Contains("123456789");
                bool bankField5 = bodyTag3.Text.Contains("commBank");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(bank1 == true && bank2 == true && bank3 == true && bank4 == true && bank5 == true && bankField1 == true && bankField2 == true && bankField3 == true && bankField4 == true && bankField5 == true);
                DebitPg.Deleteaccount().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IWebElement bodyTag4 = WebDriver.FindElement(By.TagName("body"));
                bool bankdet1 = bodyTag4.Text.Contains("DebitNickName1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(bankdet1 == false);
                DebitPg.DebitCardBTN().Click();
                //verify the headings
                string title = CardPg.BankAccountTitles().Text;
                Console.WriteLine("title" + title);
                string data = CardPg.BankAccountData().Text;
                Console.WriteLine("data" + data);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();

            }
            finally
            {

            }

        }
    }
}
