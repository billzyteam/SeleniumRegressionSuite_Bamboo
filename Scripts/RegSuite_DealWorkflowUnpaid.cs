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
    class RegSuite_DealWorkflowUnpaid : Tests
    {
        [Test]
        public void DealWorkflowUnpaid01_BillerInitiated_ExcludingGST_Surcharge_UNPAID()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal01biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay8);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+deal01payer");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SelectBusiness().Click();
                //Generate two random numbers for unique customer details and invoice
                Random rand = new Random();
                DateTime dt = new DateTime();
                string dtString = dt.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber1 = rand.Next();
                Random rand2 = new Random();
                DateTime dt2 = new DateTime();
                string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber2 = rand.Next();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "14 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer excluding GST");
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.NewTotal().SendKeys("300");
                DateTime newDate = DateTime.Now.AddDays(5);
                string dtString3 = newDate.ToString("dd/MM/yyyy");
                IssueInvoicePg.OfferExpiry().Clear();
                IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
                IssueInvoicePg.Comments().SendKeys("Deal is being offered excluding GST");
                IssueInvoicePg.SurchargeCheckbox().Click();
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INV@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string invoicestatus = SIVPG1.InvoiceStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invoicestatus.Contains("UNPAID"));
                string invnumber = SIVPG1.InvNumber().Text;
                string invoicenumber = invnumber.Substring(invnumber.IndexOf("Invoice ")).Replace("Invoice ", "");
                SIVPG1.WithdrawOfferBillerBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.WithdrawNoBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal01payer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INV@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.PostInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string PostInvoiceTitleModal = Recpg.PostInvoiceTitleModal().Text;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(PostInvoiceTitleModal.Contains("Post Invoice"));
                Recpg.PostInvoicePostBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.PayerVerifyBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                WebDriver.Navigate().GoToUrl("https://4impact-billzy-bobo-ui-uat.s3-ap-southeast-2.amazonaws.com/poc.html");
                BOBOPage Bobopg = new BOBOPage(WebDriver);
                Bobopg.Username().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.Username().SendKeys("madcowbiller+bobo_02@gmail.com");
                Bobopg.Password().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.Password().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.LoginBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Bobopg.UpdateExistingBillzyInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.SelectBusiness().SendKeys("madcowtesting10+deal01biller");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.InputInvoice().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.SearchBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string invstat = Bobopg.InvoiceStatus().Text;
                IWebElement InvDetails()
                {
                    return WebDriver.FindElement(By.XPath("//*[@id=\"row-" + invoicenumber + "\"]"));
                }
                string Verifiedstatus = InvDetails().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invstat.Contains("UNPAID") && Verifiedstatus.Contains("Verified"));
                Bobopg.UnverifyBTNEnabled().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string Verifiedstatus1 = InvDetails().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Verifiedstatus1.Contains("Unverified"));
                Bobopg.MarkAsPaidEnabled().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string invstat1 = Bobopg.InvoiceStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invstat.Contains("PAID"));
            }
            finally
            {
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                //HomePg.SignOutBTN().Click();
            }
        }

        [Test]
        public void DealWorkflowUnpaid02_BillerInitiated_IncludingGST_NoSurcharge_UNPAID()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal01biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay8);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+deal01payer");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SelectBusiness().Click();
                //Generate two random numbers for unique customer details and invoice
                Random rand = new Random();
                DateTime dt = new DateTime();
                string dtString = dt.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber1 = rand.Next();
                Random rand2 = new Random();
                DateTime dt2 = new DateTime();
                string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber2 = rand.Next();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "60 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("88.16");
                IssueInvoicePg.Message().SendKeys("Internal Payer with Deal and no surcharge");
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.NewTotal().SendKeys("80.00");

                DateTime newDate = DateTime.Now.AddDays(15);
                string dtString3 = newDate.ToString("dd/MM/yyyy");

                IssueInvoicePg.OfferExpiry().Clear();
                IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
                IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");
                //IssueInvoicePg.SurchargeCheckbox().Click();
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INV@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string invoicestatus = SIVPG1.InvoiceStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invoicestatus.Contains("UNPAID"));
                string invnumber = SIVPG1.InvNumber().Text;
                string invoicenumber = invnumber.Substring(invnumber.IndexOf("Invoice ")).Replace("Invoice ", "");
                SIVPG1.WithdrawOfferBillerBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.WithdrawNoBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal01payer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INV@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
               
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.PayerMakeACounterOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                

                SIVPG1.NewTotal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.NewTotal().SendKeys("75");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //verify discount %
                DateTime newDate2 = DateTime.Now.AddDays(15);
                string dtString4 = newDate2.ToString("dd/MM/yyyy");
                SIVPG1.OfferExpiry().Clear();
                SIVPG1.OfferExpiry().SendKeys(dtString4);
                SeleniumSetMethods.WaitOnPage(secdelay1);

                string percentage2 = SIVPG1.SIVOfferDiscountpercentage().Text;
                Assert.IsTrue(percentage2.Contains("22.66%"));
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SIVPG1.Comments().SendKeys("Payer made a counter offer");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.makeCounterOfferModalBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);



                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal01biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SendPg.SearchInvoiceSent().SendKeys("INV@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string status1 = SIVPG1.DiscountHistoryStatus01().Text;
                string status2 = SIVPG1.DiscountHistoryStatus02().Text;
                Assert.IsTrue(status1.Contains("RECEIVED") && status2.Contains("SENT"));
            }
            finally
            {
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();
            }
        }

        [Test]
        public void DealWorkflowUnpaid03_BillerInitiated_IncludingGST_Surcharge_UNPAID()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal01biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay8);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+deal01payer");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SelectBusiness().Click();
                //Generate two random numbers for unique customer details and invoice
                Random rand = new Random();
                DateTime dt = new DateTime();
                string dtString = dt.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber1 = rand.Next();
                Random rand2 = new Random();
                DateTime dt2 = new DateTime();
                string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber2 = rand.Next();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "30 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                IssueInvoicePg.Message().SendKeys("Internal Payer with Deal and  surcharge");
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.NewTotal().SendKeys("319.82");

                DateTime newDate = DateTime.Now.AddDays(15);
                string dtString3 = newDate.ToString("dd/MM/yyyy");

                IssueInvoicePg.OfferExpiry().Clear();
                IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
                IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");
                IssueInvoicePg.SurchargeCheckbox().Click();
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INV@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string invoicestatus = SIVPG1.InvoiceStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invoicestatus.Contains("UNPAID"));
                string invnumber = SIVPG1.InvNumber().Text;
                string invoicenumber = invnumber.Substring(invnumber.IndexOf("Invoice ")).Replace("Invoice ", "");
                SIVPG1.WithdrawOfferBillerBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.YesWithdrawOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                
                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string status1 = SIVPG1.DiscountHistoryStatus01().Text;
                string status2 = SIVPG1.DiscountHistoryStatus02().Text;
                Assert.IsTrue(status1.Contains("WITHDRAWN") && status2.Contains("SENT"));
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal01payer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INV@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);

                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string status3 = SIVPG1.DiscountHistoryStatus01().Text;
                string status4 = SIVPG1.DiscountHistoryStatus02().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(status3.Contains("WITHDRAWN") && status4.Contains("RECEIVED"));



                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal01biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SendPg.SearchInvoiceSent().SendKeys("INV@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.BillerOfferADiscountBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                DateTime duedate1 = DateTime.Today.AddDays(7);
                string SentPgDueDate = duedate1.ToString("dd/MM/YYYY");
                string SentPgDueDate2 = duedate1.ToString("dd MMM yy");
                SIVPG1.NewTotal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.NewTotal().SendKeys("290.82");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //verify discount %
                string percentage1 = SIVPG1.SIVOfferDiscountpercentage().Text;
                Assert.IsTrue(percentage1.Contains("17.33%"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().SendKeys(SentPgDueDate);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                SIVPG1.Comments().SendKeys("Biller Offer Deal");
                SeleniumSetMethods.WaitOnPage(secdelay3);

                SIVPG1.OfferDiscountModalBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string status5 = SIVPG1.DiscountHistoryStatus01().Text;
                string status6 = SIVPG1.DiscountHistoryStatus02().Text;
                string status7 = SIVPG1.DiscountHistoryStatus03().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(status5.Contains("SENT") && status6.Contains("WITHDRAWN") && status7.Contains("SENT"));
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal01payer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INV@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);

                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string status8 = SIVPG1.DiscountHistoryStatus01().Text;
                string status9 = SIVPG1.DiscountHistoryStatus02().Text;
                string status10 = SIVPG1.DiscountHistoryStatus03().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(status8.Contains("RECEIVED") && status9.Contains("WITHDRAWN") && status10.Contains("RECEIVED"));
                SIVPG1.PayerMakeACounterOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                SIVPG1.NewTotal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.NewTotal().SendKeys("208.82");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //verify discount %
                DateTime duedate2 = DateTime.Today.AddDays(4);
                string SentPgDueDate3 = duedate2.ToString("dd/MM/YYYY");
                SIVPG1.OfferExpiry().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().SendKeys(SentPgDueDate3);

                SeleniumSetMethods.WaitOnPage(secdelay2);
                string percentage2 = SIVPG1.SIVOfferDiscountpercentage().Text;
                Assert.IsTrue(percentage2.Contains("40.64%"));
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SIVPG1.Comments().SendKeys("Payer Requested a New Deal");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.makeCounterOfferModalBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string status11 = SIVPG1.DiscountHistoryStatus01().Text;
                string status12 = SIVPG1.DiscountHistoryStatus02().Text;
                string status13 = SIVPG1.DiscountHistoryStatus03().Text;
                string status14 = SIVPG1.DiscountHistoryStatus04().Text;
                Assert.IsTrue(status11.Contains("SENT") && status12.Contains("RECEIVED") && status13.Contains("WITHDRAWN") && status14.Contains("RECEIVED"));
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal01biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SendPg.SearchInvoiceSent().SendKeys("INV@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string status15 = SIVPG1.DiscountHistoryStatus01().Text;
                string status16 = SIVPG1.DiscountHistoryStatus02().Text;
                string status17 = SIVPG1.DiscountHistoryStatus03().Text;
                string status18 = SIVPG1.DiscountHistoryStatus04().Text;
                Assert.IsTrue(status15.Contains("RECEIVED") && status16.Contains("SENT") && status17.Contains("WITHDRAWN") && status18.Contains("SENT"));
            }
            finally
            {
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();
            }
        }

        [Test]
        public void DealWorkflowUnpaid04_GST_Surcharge_Unpaid_NotViewed()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal01biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay8);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+deal01payer");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SelectBusiness().Click();
                //Generate two random numbers for unique customer details and invoice
                Random rand = new Random();
                DateTime dt = new DateTime();
                string dtString = dt.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber1 = rand.Next();
                Random rand2 = new Random();
                DateTime dt2 = new DateTime();
                string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber2 = rand.Next();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "30 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("1,204.09");
                IssueInvoicePg.Message().SendKeys("Internal Payer with Deal and  surcharge");
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.NewTotal().SendKeys("1,175.09");

                DateTime newDate = DateTime.Now.AddDays(15);
                string dtString3 = newDate.ToString("dd/MM/yyyy");

                IssueInvoicePg.OfferExpiry().Clear();
                IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
                IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");
                IssueInvoicePg.SurchargeCheckbox().Click();
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SentOutstandingBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("INV@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.InvoiceNumColumn().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                string notviewed = SendPg.NotViewed().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(notviewed.Contains("not viewed"));
                SendPg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.PDFInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SeleniumSetMethods.WaitOnPage(secdelay3);
                var tabs = WebDriver.WindowHandles;
                if (tabs.Count > 1)
                {
                    WebDriver.SwitchTo().Window(tabs[1]);
                    WebDriver.Close();
                    WebDriver.SwitchTo().Window(tabs[0]);
                }
                SeleniumSetMethods.WaitOnPage(secdelay2);


                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal01payer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INV@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);

                bool receviedicon = Recpg.OfferRecievedIcon().Displayed;
                Assert.IsTrue(receviedicon == true);
            }
            finally
            {
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();
            }
        }
        [Test]
        public void DealWorkflowUnpaid05_GST_Surcharge_Unpaid_NotViewed()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal01biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay8);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+deal01payer");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SelectBusiness().Click();
                //Generate two random numbers for unique customer details and invoice
                Random rand = new Random();
                DateTime dt = new DateTime();
                string dtString = dt.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber1 = rand.Next();
                Random rand2 = new Random();
                DateTime dt2 = new DateTime();
                string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber2 = rand.Next();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "30 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("1,204.09");
                IssueInvoicePg.Message().SendKeys("Internal Payer with Deal and  surcharge");
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.NewTotal().SendKeys("1,175.09");

                DateTime newDate = DateTime.Now.AddDays(15);
                string dtString3 = newDate.ToString("dd/MM/yyyy");

                IssueInvoicePg.OfferExpiry().Clear();
                IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
                IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");
                IssueInvoicePg.SurchargeCheckbox().Click();
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SentOutstandingBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("INV@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.InvoiceNumColumn().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.NotViewed().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string notviewed = SendPg.NotViewed().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(notviewed.Contains("not viewed"));
                SendPg.ActionsMenu().Click();
               
                SeleniumSetMethods.WaitOnPage(secdelay2);


                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal01payer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INV@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                
                bool receviedicon = Recpg.OfferRecievedIcon().Displayed;
                string notviewd = Recpg.TopayNotViewed().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(receviedicon == true && notviewd.Contains("not viewed"));

                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
               
                string viewed = Recpg.TopayViewed().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(viewed.Contains("viewed"));
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal01biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SendPg.SearchInvoiceSent().SendKeys("INV@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.NotViewed().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                string viewed1 = SendPg.NotViewed().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(viewed1.Contains("viewed"));


            }
            finally
            {
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();
            }

        }

        [Test]
        public void DealWorkflowUnpaid06_PayerInitiated_UNPAID()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal01biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay8);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+deal01payer");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SelectBusiness().Click();
                //Generate two random numbers for unique customer details and invoice
                Random rand = new Random();
                DateTime dt = new DateTime();
                string dtString = dt.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber1 = rand.Next();
                Random rand2 = new Random();
                DateTime dt2 = new DateTime();
                string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber2 = rand.Next();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "60 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                
                IssueInvoicePg.SurchargeCheckbox().Click();
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SentOutstandingBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("INV@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.NotViewed().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string notviewed = SendPg.NotViewed().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(notviewed.Contains("not viewed"));
                

                SeleniumSetMethods.WaitOnPage(secdelay2);


                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal01payer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INV@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);

                //bool receviedicon = Recpg.OfferRecievedIcon().Displayed;
                string notviewd = Recpg.TopayNotViewed().GetAttribute("data-title");
                string unverified = Recpg.VerifystatusIcon().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(notviewd.Contains("not viewed") && unverified.Contains("unverified"));

                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SIVPG1.PayerVerifyBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                DateTime duedate1 = DateTime.Today.AddDays(15);
                string SentPgDueDate = duedate1.ToString("dd/MM/yyyy");
                string SentPgDueDate2 = duedate1.ToString("dd MMM yy");
                SIVPG1.PayerOfferEarlyPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.NewTotal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.NewTotal().SendKeys("208.82");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().SendKeys(SentPgDueDate);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                SIVPG1.Comments().SendKeys("Payer Requested a Deal");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.OfferEarlyPaymentModalBTN1().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);


                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Recpg.SearchInvoiceReceived().SendKeys("INV@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);

                string viewed = Recpg.TopayViewed().GetAttribute("data-title");
                string verified = Recpg.VerifystatusIcon().GetAttribute("data-title");
                string Notposted = Recpg.PostedIcon().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(viewed.Contains("viewed") && unverified.Contains("verified") && Notposted.Contains("viewed"));
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.PostInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.PostInvoicePostBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                bool Posted = Recpg.PostedIcon().Displayed;
                string PostedMsg = Recpg.PostedIcon().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Posted == true && PostedMsg.Contains("posted"));
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string verifymsg = SIVPG1.VerifiedTextMsg().Text;
                string postmsg = SIVPG1.postmessagepayer().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(verifymsg.Contains("You verified this invoice on ") && postmsg.Contains("You posted this invoice on "));

                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal01biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SendPg.SearchInvoiceSent().SendKeys("INV@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.NotViewed().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                string viewed1 = SendPg.NotViewed().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(viewed1.Contains("viewed"));
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string verifymsg1 = SIVPG1.VerifiedTextMsgBiller().Text;
                //bool postmsg1 = SIVPG1.postmessage().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(verifymsg1.Contains("madcowtesting10+deal01payer verified this invoice on "));


            }
            finally
            {
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();
            }

        }


    }
}
