using System.IO;
using System.Net;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using BillzyAutomationTestSuite;
using BillzyAutomationTestSuite.PageObjects;
using BillzyAutomationTestSuite.Scripts;
using System;
using OpenQA.Selenium.Interactions;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BillzyAutomationTestSuite.Scripts
{
    [TestFixture]
    [Parallelizable]
    class RegSuite_FeatureToggling : Tests
    {

        [Test]
        public void FeatureToggle01_NoDealNoCashNoCardAccess_IssueInvocieSIV()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {

                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                LoginPage loginPage = new LoginPage(WebDriver);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+billerwithoutaccess@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);

                //Issue Invoice - Webapp - Create Invoice
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("manualtestdemob+payerwithaccess");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Random rand = new Random();
                DateTime dt = new DateTime();
                string dtString = dt.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber1 = rand.Next();
                Random rand2 = new Random();
                DateTime dt2 = new DateTime();
                string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber2 = rand.Next();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "90 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVINTMTCI@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("10.00");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                //Verifying the deal and cash acess in issue invoice page
                bool cashbanned = IssueInvoicePg.CashBannedImg().Displayed;
                bool dealbanned = IssueInvoicePg.DealBannedImg().Displayed;
                IssueInvoicePg.CashBannedImg().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag11 = WebDriver.FindElement(By.TagName("body"));

                bool cashbannedmsg1 = bodyTag11.Text.Contains("To find out more contact us on");
                bool cashbannedmsg11 = bodyTag11.Text.Contains("contact@billzy.com");
                bool cashbannedmsg2 = bodyTag11.Text.Contains("Billzy Cash is not activated yet");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(cashbanned == true && dealbanned == true && cashbannedmsg1 == true && cashbannedmsg2 == true && cashbannedmsg11 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.DealBannedImg().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag12 = WebDriver.FindElement(By.TagName("body"));
                bool dealbannedmsg1 = bodyTag12.Text.Contains("To find out more contact us on");
                bool dealbannedmsg11 = bodyTag12.Text.Contains("contact@billzy.com");
                bool dealbannedmsg2 = bodyTag12.Text.Contains("Billzy Deal is not activated yet");

                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(dealbannedmsg1 == true && dealbannedmsg2 == true && dealbannedmsg11 == true);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                IssueInvoicePg.CashBannedInfoIcon().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));
                bool Cashdetails = bodyTag.Text.Contains("Cash flow is critical in any business. With the help of billzy Cash, businesses of all sizes are");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Cashdetails == true);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                SeleniumSetMethods.WaitOnPage(secdelay4);

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("manualtestdemob+payerwithaccess");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);

                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVINTMTCI@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("10.00");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.DealBannedInfoIcon().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                IWebElement bodyTag1 = WebDriver.FindElement(By.TagName("body"));
                bool Dealdetails = bodyTag1.Text.Contains("Whether you are sending or receiving invoices billzy Deal can speed up payment to grow your");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Dealdetails == true);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                SeleniumSetMethods.WaitOnPage(secdelay4);

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("manualtestdemob+payerwithaccess");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);

                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("FeatureTest01@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("100.00");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Console.WriteLine("InvoiceCreated");
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPage SendPg = new SendPage(WebDriver);
                SendPg.SentOutstandingBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("FeatureTest01@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SIVPage sivpg = new SIVPage(WebDriver);
                //Verifying the deal and cash access in SIV
                bool cashbannedsiv = sivpg.CashBannedImg().Displayed;
                bool dealbannedsiv = sivpg.DealBannedImg().Displayed;
                string cashbannedmsg1siv = sivpg.CashBannedImg().GetAttribute("data-content");
                string cashbannedmsg2siv = sivpg.CashBannedImg().GetAttribute("data-original-title");
                string dealbannedmsg1siv = sivpg.DealBannedImg().GetAttribute("data-content");
                string dealbannedmsg2siv = sivpg.DealBannedImg().GetAttribute("data-original-title");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(cashbannedsiv == true && dealbannedsiv == true && cashbannedmsg1siv.Contains("To find out more contact us on 1300 BILLZY") && cashbannedmsg2siv.Contains("Billzy Cash is not activated yet") && dealbannedmsg1siv.Contains("To find out more contact us on 1300 BILLZY") && dealbannedmsg2siv.Contains("Billzy Deal is not activated yet"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                sivpg.CashBannedInfoIcon().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                IWebElement bodyTag3 = WebDriver.FindElement(By.TagName("body"));
                bool Cashdetailssiv = bodyTag3.Text.Contains("Cash flow is critical in any business. With the help of billzy Cash, businesses of all sizes are");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Cashdetailssiv == true);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                SeleniumSetMethods.WaitOnPage(secdelay4);

                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SentOutstandingBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("FeatureTest01@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                sivpg.DealBannedInfoIcon().Click();
                SeleniumSetMethods.WaitOnPage(secdelay6);
                IWebElement bodyTag4 = WebDriver.FindElement(By.TagName("body"));
                bool Dealdetailssiv = bodyTag4.Text.Contains("Whether you are sending or receiving invoices billzy Deal can speed up payment to grow your");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Dealdetailssiv == true);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                SeleniumSetMethods.WaitOnPage(secdelay4);

                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                // Payer make a counter offer
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+payerwithaccess@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("FeatureTest01@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                DateTime duedate1 = DateTime.Today.AddDays(30);
                string SentPgDueDate = duedate1.ToString("dd/MM/yyyy");

                sivpg.PayerOfferEarlyPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                sivpg.NewTotal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                sivpg.NewTotal().SendKeys("80");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                sivpg.OfferExpiry().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                sivpg.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                sivpg.OfferExpiry().SendKeys(SentPgDueDate);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                sivpg.Comments().SendKeys("Payer Requested a Deal");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                sivpg.OfferEarlyPaymentModalBTN1().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("FeatureTest01@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+billerwithoutaccess@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                // Biller is currenly able to offer deal for this invoice
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("FeatureTest01@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                bool BillerMakeACounterOfferBTN = sivpg.BillerMakeACounterOfferBTN().Displayed;
                bool DeclineOfferBTN = sivpg.DeclineOfferBTN().Displayed;
                bool AcceptOfferBTN = sivpg.AcceptOfferBTN().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(BillerMakeACounterOfferBTN == true && DeclineOfferBTN == true && AcceptOfferBTN == true);
                sivpg.AcceptOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                sivpg.AcceptTheOfferModalYesBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                sivpg.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SeleniumSetMethods.WaitOnPage(secdelay4);

                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                // Payer make a counter offer
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+payerwithaccess@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("FeatureTest01@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.PAY().Click();
                PayNowPage Paynwpg = new PayNowPage(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string cardmsg = Paynwpg.Row01SelectCard().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(cardmsg.Contains("Payment Method - Cards Disabled"));
                SeleniumSetMethods.WaitOnPage(secdelay4);

                HomePg.SignOutBTN().Click();


            }
            finally
            {
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com");

            }
        }




        [Test]
        public void FeatureToggle02_MarkasPaidAccess_ListSIV()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {

                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                LoginPage loginPage = new LoginPage(WebDriver);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+payerwithaccess@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);

                //Issue Invoice - Webapp - Create Invoice
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("manualtestdemob+billerwithaccess");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Random rand = new Random();
                DateTime dt = new DateTime();
                string dtString = dt.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber1 = rand.Next();
                Random rand2 = new Random();
                DateTime dt2 = new DateTime();
                string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber2 = rand.Next();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "90 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVMarkasPaid@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("10.00");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Console.WriteLine("InvoiceCreated");
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPage SendPg = new SendPage(WebDriver);
                SendPg.SentOutstandingBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVMarkasPaid@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SIVPage sivpg = new SIVPage(WebDriver);
                sivpg.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool markaspaid = sivpg.ActionDropdownMarkAsPaid().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(markaspaid == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+billerwithaccess@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVMarkasPaid@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.MarkAsPaidOptionJLL().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));
                bool noinv = bodyTag.Text.Contains("No Invoices Available");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(noinv == true);
                //User without access

                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+payerwithaccess@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
              
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("manualtestdemob+billerwithoutaccess");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVNoMarkasPaid@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("10.00");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Console.WriteLine("InvoiceCreated");
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                
                SendPg.SentOutstandingBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVNoMarkasPaid@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                sivpg.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                bool markaspaid2 = sivpg.ActionDropdownMarkAsPaid().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(markaspaid2 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);


                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
               
                
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+billerwithoutaccess@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVNoMarkasPaid@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool markaspaid4 = Recpg.MarkAsPaidOptionJLL().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(markaspaid4 == false);
                HomePg.SignOutBTN().Click();



            }
            finally
            {
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com");

            }

        }

        [Test]
        public void FeatureToggle03_BPAY_IssueInvoiceSIV()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {

                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                LoginPage loginPage = new LoginPage(WebDriver);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+billerwithoutaccess@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);

                //Issue Invoice - Webapp - Create Invoice
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("External1");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Random rand = new Random();
                DateTime dt = new DateTime();
                string dtString = dt.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber1 = rand.Next();
                Random rand2 = new Random();
                DateTime dt2 = new DateTime();
                string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber2 = rand.Next();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "90 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVBPAYFT@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("10.00");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                IssueInvoicePg.PreviewInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));
                //bool Previewdet = bodyTag.Text.Contains("TAX INVOICE");
                //SeleniumSetMethods.WaitOnPage(secdelay2);
               // Assert.IsTrue(Previewdet == true);

                var tabs = WebDriver.WindowHandles;
                if (tabs.Count > 1)
                {
                    WebDriver.SwitchTo().Window(tabs[1]);
                    WebDriver.Close();
                    WebDriver.SwitchTo().Window(tabs[0]);
                }
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Outside().Click();

                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Console.WriteLine("InvoiceCreated");
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPage SendPg = new SendPage(WebDriver);
                SendPg.SentOutstandingBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVBPAYFT@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SIVPage sivpg = new SIVPage(WebDriver);
                sivpg.SIVPDFIcon().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                IWebElement bodyTag2 = WebDriver.FindElement(By.TagName("body"));
                // bool Previewdet2 = bodyTag2.Text.Contains("TAX INVOICE");
                // SeleniumSetMethods.WaitOnPage(secdelay2);
                // Assert.IsTrue(Previewdet2 == true);

                WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
                SeleniumSetMethods.WaitOnPage(secdelay4);

                WebDriver.Close();
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
                SeleniumSetMethods.WaitOnPage(secdelay4);

               /* if (tabs.Count > 1)
                {
                    WebDriver.SwitchTo().Window(tabs[1]);
                    WebDriver.Close();
                    WebDriver.SwitchTo().Window(tabs[0]);
                }
                SeleniumSetMethods.WaitOnPage(secdelay4);*/


                HomePg.SignOutBTN().Click();



            }
            finally
            {
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com");

            }

        }

        [Test]
        public void FeatureToggle04_PaywayAccount()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {
                //User with payway account and with  cash and  payway permissions
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                LoginPage loginPage = new LoginPage(WebDriver);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+payway01withoutpwa1@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                CardPage CardPg = new CardPage(WebDriver);
                HomePg.Profile().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.CardMgmnt().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                CardPg.BillzyAccountTab().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string bsb = CardPg.Pawaybsb().GetAttribute("value");
                string accountno = CardPg.Pawayaccnumber().GetAttribute("value");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(bsb.Contains("032001") && accountno.Contains("123456"));

                //Issue Invoice - Webapp - Create Invoice No Cash
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("External1");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Random rand = new Random();
                DateTime dt = new DateTime();
                string dtString = dt.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber1 = rand.Next();
                Random rand2 = new Random();
                DateTime dt2 = new DateTime();
                string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber2 = rand.Next();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "90 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("Paywaycheck@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("10.00");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to external payer");
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Console.WriteLine("InvoiceCreated");
                SeleniumSetMethods.WaitOnPage(secdelay4);

                //With Cash

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("External1");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("CashPaywaycheck@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("10.00");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to external payer");
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Console.WriteLine("InvoiceCreated");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                //User with payway account and with no cash and no payway permissions
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+payway01withoutpwa2@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                HomePg.Profile().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.CardMgmnt().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                CardPg.BillzyAccountTab().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string bsb1 = CardPg.Pawaybsb().GetAttribute("value");
                string accountno1 = CardPg.Pawayaccnumber().GetAttribute("value");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(bsb1.Contains("032001") && accountno1.Contains("356278"));

                //Issue Invoice - Webapp - Create Invoice
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("External1");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("Nopaywaycheck@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("10.00");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to external payer");
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Console.WriteLine("InvoiceCreated");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                //User with payway account and with  cash and no payway permissions
               
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+MFA003@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                HomePg.Profile().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.CardMgmnt().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                CardPg.BillzyAccountTab().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string bsb2 = CardPg.Pawaybsb().GetAttribute("value");
                string accountno2 = CardPg.Pawayaccnumber().GetAttribute("value");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(bsb2.Contains("032563") && accountno2.Contains("142536"));

                //Issue Invoice - Webapp - Create Invoice
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("External1");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("CashNoPayway@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("10.00");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to external payer");
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Console.WriteLine("InvoiceCreated");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();

                //Verifying the Emails for payway account
                //string randnumber2 = "1635974563";
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://accounts.google.com/signin/v2/identifier?service=mail&passive=true&rm=false&continue=https%3A%2F%2Fmail.google.com%2Fmail%2F&ss=1&scc=1&ltmpl=default&ltmplcache=2&emr=1&osid=1&flowName=GlifWebSignIn&flowEntry=ServiceLogin");
                GMAILPage gmailpg = new GMAILPage(WebDriver);
                gmailpg.Username().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Username().SendKeys("madcowtesting10@gmail.com");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.UserNext().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                gmailpg.Password().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.PasswordNext().Click();
                SeleniumSetMethods.WaitOnPage(secdelay8);
                gmailpg.Search().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Search().SendKeys("Invoice reference : CashNoPayway@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                gmailpg.SearchButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag111 = WebDriver.FindElement(By.TagName("body"));
                bool Content111 = bodyTag111.Text.Contains("Dear External1,");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Content111 == true);
                gmailpg.Verify().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
                IWebElement bodyTag22 = WebDriver.FindElement(By.TagName("body"));
                bool payway21 = bodyTag22.Text.Contains("Bank Transfer Details");
                bool payway22 = bodyTag22.Text.Contains("Account Name: Billzy Clearing");
                bool payway23 = bodyTag22.Text.Contains("BSB: 034001");
                bool payway24 = bodyTag22.Text.Contains("Account Number: 589326");
                bool payway25 = bodyTag22.Text.Contains("Reference: CashNoPayway");
                bool payway26 = bodyTag22.Text.Contains("TOTAL (AUD excl. GST): ");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(payway21 == true && payway22 == true && payway23 == true && payway24 == true && payway25 == true && payway26 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Close();
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Search().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Search().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                gmailpg.Search().SendKeys("Invoice reference : CashPaywaycheck@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Verify().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
                IWebElement bodyTag32 = WebDriver.FindElement(By.TagName("body"));
                bool payway31 = bodyTag32.Text.Contains("Bank Transfer Details");
                bool payway32 = bodyTag32.Text.Contains("Account Name: madcowtesting10+p-Billzy");
                bool payway33 = bodyTag32.Text.Contains("BSB: 032001");
                bool payway34 = bodyTag32.Text.Contains("Account Number: 123456");
                bool payway35 = bodyTag32.Text.Contains("Reference: CashPayway");
                bool payway36 = bodyTag32.Text.Contains("TOTAL (AUD excl. GST): ");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(payway31 == true && payway32 == true && payway33 == true && payway34 == true && payway35 == true && payway36 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Close();
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Search().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Search().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                gmailpg.Search().SendKeys("Invoice reference : Paywaycheck@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Verify().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));
                bool payway1 = bodyTag.Text.Contains("Bank Transfer Details");
                bool payway2 = bodyTag.Text.Contains("Account Name: madcowtesting10+p-Billzy");
                bool payway3 = bodyTag.Text.Contains("BSB: 032001");
                bool payway4 = bodyTag.Text.Contains("Account Number: 123456");
                bool payway5 = bodyTag.Text.Contains("Reference: Paywaycheck");
                bool payway6 = bodyTag.Text.Contains("TOTAL (AUD excl. GST): ");
                Console.WriteLine(bodyTag);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(payway1 == true && payway2 == true && payway3 == true && payway4 == true && payway5 == true && payway6 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Close();
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Search().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Search().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                gmailpg.Search().SendKeys("Invoice reference : Nopaywaycheck@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Verify().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
                IWebElement bodyTag0 = WebDriver.FindElement(By.TagName("body"));
                bool payway11 = bodyTag0.Text.Contains("Bank Transfer Details");
                bool payway12 = bodyTag0.Text.Contains("Account Name: receiveAccount");
                bool payway13 = bodyTag0.Text.Contains("BSB: 484799");
                bool payway14 = bodyTag0.Text.Contains("Account Number: 65432111");
                bool payway15 = bodyTag0.Text.Contains("Reference: Nopaywaycheck");
                bool payway16 = bodyTag0.Text.Contains("TOTAL (AUD excl. GST): ");
                Console.WriteLine(bodyTag);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(payway11 == true && payway12 == true && payway13 == true && payway14 == true && payway15 == true && payway16 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Close();
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.profile().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.signout().Click();


            }
            finally
            {
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com");

            }

        }

    }
}
