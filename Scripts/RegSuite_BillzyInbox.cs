using NUnit.Framework;
using OpenQA.Selenium;
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
    class RegSuite_BillzyInbox : Tests
    {

        [Test]
        public void BillzyInbox01_ListView_and_SIV_validation_CSVExport()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);
                SendPage SendPg = new SendPage(WebDriver);
                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                BillzyCashModal BillzyCashMlPg = new BillzyCashModal(WebDriver);
                SIVPage SIVPG1 = new SIVPage(WebDriver);
                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowpayer+raffyinbox02@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay8);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Recpg.BillzyInboxFilterCheckBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));
                bool data1 = bodyTag.Text.Contains("Young Advertising");
                bool data2 = bodyTag.Text.Contains("Pitney Bowes");
                bool data3 = bodyTag.Text.Contains("Invoices");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(data1 == true && data2 == true && data3 == true);
                Recpg.BillzyInboxFilterUncheckBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool data44 = bodyTag.Text.Contains("Invoices");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(data44 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.BillzyDealFilterCheckBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool data4 = bodyTag.Text.Contains("Offer");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                
                Assert.IsTrue(data4 == true);
                //Recpg.BillzyDealFilterUncheckBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.BillzyInboxFilterCheckBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool data55 = bodyTag.Text.Contains("No Invoices Available");
                SeleniumSetMethods.WaitOnPage(secdelay2);

                Assert.IsTrue(data55 == true);
                Recpg.BillzyInboxFilterUncheckBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.BillzyDealFilterUncheckBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                Recpg.SearchInvoiceReceived().SendKeys("Young Advertising");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.ToPayTab().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                bool data5 = bodyTag.Text.Contains("Please verify invoice");
                bool data6 = bodyTag.Text.Contains("Young Advertising");
                bool data7 = bodyTag.Text.Contains("1038");
                bool data8 = bodyTag.Text.Contains("29 Jun 17");
                bool data9 = bodyTag.Text.Contains("$6,600.00");
                bool data10 = bodyTag.Text.Contains("External Biller");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(data5 == false && data6 == true && data7 == true && data8 == true && data9 == true && data10 == false);
                Recpg.BillzyInboxFilterCheckBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
 

                IWebElement bodyTag2 = WebDriver.FindElement(By.TagName("body"));
                bool datacheck3 = bodyTag2.Text.Contains("Young Advertising");
                bool datacheck4 = bodyTag2.Text.Contains("Pitney Bowes");
                bool datacheck5 = bodyTag2.Text.Contains("Please verify invoice");
                  bool datacheck6 = bodyTag2.Text.Contains("Offer sent");
                  bool datacheck7 = bodyTag2.Text.Contains("Offer received");
                  bool datacheck8 = bodyTag2.Text.Contains("Offer declined");
                  bool datacheck9 = bodyTag2.Text.Contains("Offer accepted");
                  bool datacheck10 = bodyTag2.Text.Contains("Offer withdrawn");
                  bool datacheck11 = bodyTag2.Text.Contains("INV-004");
                  bool datacheck12 = bodyTag2.Text.Contains("External Biller");
                  string data = bodyTag2.Text;
                  Console.WriteLine(data);
                  SeleniumSetMethods.WaitOnPage(secdelay2);
                  Assert.IsTrue(datacheck3 == true && datacheck4 == true &&datacheck5 == false && datacheck6 == false && datacheck7 == false && datacheck8 == false && datacheck9 == false && datacheck10 == false && datacheck11 == false && datacheck12 == false);
                Recpg.BillzyDealFilterCheckBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                bool ddatacheck3 = bodyTag2.Text.Contains("Young Advertising");
                bool ddatacheck4 = bodyTag2.Text.Contains("Pitney Bowes");
                bool ddatacheck5 = bodyTag2.Text.Contains("Please verify invoice");
                bool ddatacheck6 = bodyTag2.Text.Contains("Offer sent");
                bool ddatacheck7 = bodyTag2.Text.Contains("Offer received");
                bool ddatacheck8 = bodyTag2.Text.Contains("Offer declined");
                bool ddatacheck9 = bodyTag2.Text.Contains("Offer accepted");
                bool ddatacheck10 = bodyTag2.Text.Contains("Offer withdrawn");
                bool ddatacheck11 = bodyTag2.Text.Contains("INV-004");
                bool ddatacheck12 = bodyTag2.Text.Contains("External Biller");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(ddatacheck3 == false && ddatacheck4 == false && ddatacheck5 == false && ddatacheck6 == false && ddatacheck7 == false && ddatacheck8 == false && ddatacheck9 == false && ddatacheck10 == false && ddatacheck11 == false && ddatacheck12 == false);
                SeleniumSetMethods.WaitOnPage(secdelay2);

                Recpg.BillzyInboxFilterUncheckBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.BillzyDealFilterUncheckBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                IWebElement bodyTag222 = WebDriver.FindElement(By.TagName("body"));
                SeleniumSetMethods.WaitOnPage(secdelay4);
                bool dddatacheck3 = bodyTag222.Text.Contains("Young Advertising");
                bool dddatacheck4 = bodyTag222.Text.Contains("Pitney Bowes");
                bool dddatacheck5 = bodyTag222.Text.Contains("Please verify invoice");
                bool dddatacheck6 = bodyTag222.Text.Contains("Offer sent");
                bool dddatacheck7 = bodyTag222.Text.Contains("Offer received");
                bool dddatacheck8 = bodyTag222.Text.Contains("Offer declined");
                bool dddatacheck9 = bodyTag222.Text.Contains("Offer accepted");
                bool dddatacheck10 = bodyTag222.Text.Contains("Offer withdrawn");
                bool dddatacheck11 = bodyTag222.Text.Contains("INV-004");
                bool dddatacheck12 = bodyTag222.Text.Contains("External Biller");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(dddatacheck3 == true && dddatacheck4 == true && dddatacheck5 == false && dddatacheck6 == true && dddatacheck7 == true && dddatacheck8 == true && dddatacheck9 == true && dddatacheck10 == true && dddatacheck11 == true && dddatacheck12 == false);
                SeleniumSetMethods.WaitOnPage(secdelay2);

                //testInfo = As Payer verify BillzyInbox Invoice functionalities in SIV
                SeleniumSetMethods.WaitOnPage(secdelay4);

                Recpg.SearchInvoiceReceived().SendKeys("Young Advertising");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                bool inboxicon = SIVPG1.BillzyInboxIcon().Displayed;
                IWebElement bodyTag4 = WebDriver.FindElement(By.TagName("body"));
                bool billoerbusname = bodyTag4.Text.Contains("Young Advertising");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(inboxicon == true && billoerbusname == true );
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool dele = SIVPG1.ActionDropdownDelete().Displayed;
                bool mark = SIVPG1.ActionDropdownMarkAsPaid().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(dele == true && mark == false);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool billerofferbtn = SIVPG1.BillerOfferADiscountBTN().Displayed;
                bool PayerOfferEarlyPaymentBTN = SIVPG1.PayerOfferEarlyPaymentBTN().Displayed;
                bool PayerVerifyBTN = SIVPG1.PayerVerifyBTN().Displayed;
                bool PayBTNNoDeal = SIVPG1.PayBTNNoDeal().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(billerofferbtn == false && PayerOfferEarlyPaymentBTN == false && PayBTNNoDeal == true && PayerVerifyBTN == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();
            }
            finally
            {
               
            }
        }
    }
}
