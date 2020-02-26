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
    class RegSuite_DealFees : Tests
    {
        [Test]
        public void DealFee01_BillerAcceptedDeal()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal03biller@gmail.com");
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
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+872815244");
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
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVDealFees@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("1000");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                IssueInvoicePg.SurchargeCheckbox().Click();

                //issueInvoice_issueInvoicePage_totalValue.checkValueContains = @amountGst
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");

                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVDealFees@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                bool reqcash = SIVPG1.RequestBillzyCashBTN().Displayed;
                bool reqdeal = SIVPG1.RequestBillzyDealBTN().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(reqcash == true && reqdeal == true);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();

                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+872815244@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVDealFees@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.PayerOfferEarlyPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                DateTime duedate1 = DateTime.Today.AddDays(10);
                string SentPgDueDate = duedate1.ToString("dd/MM/yyyy");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.NewTotal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.NewTotal().SendKeys("800");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //verify discount %

                SIVPG1.OfferExpiry().Click();
                string percentage = SIVPG1.SIVOfferDiscountpercentage().Text;
                Assert.IsTrue(percentage.Contains("27.27%"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().SendKeys(SentPgDueDate);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                SIVPG1.Comments().SendKeys("Payer Requested a Deal");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.OfferEarlyPaymentModalBTN1().Click();
                SeleniumSetMethods.WaitOnPage(secdelay9);
                bool withdraw = SIVPG1.WithdrawOfferPayerBTN().Displayed;
                Assert.IsTrue(withdraw == true);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVDealFees@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ActionsMenu().Click();
                HomePg.SignOutBTN().Click();

                SeleniumSetMethods.WaitOnPage(secdelay4);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal03biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVDealFees@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                string status = SendPg.BillzyRow1().Text;
                bool icon = SendPg.OfferRecievedIcon().Displayed;
                
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(status.Contains("Offer received") && icon == true);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SIVPG1.AcceptOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.AcceptTheOfferModalYesBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

                SendPg.SearchInvoiceSent().SendKeys("INVDealFees@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                bool OfferAccepteddIcon = SendPg.OfferAcceptedIcon().Displayed;
                String OfferStatus2 = SendPg.OfferStatussendpage().Text;
                SeleniumSetMethods.WaitOnPage(secdelay1);
                string OfferAccepteddIconhover = Recpg.Offerhovertext().GetAttribute("data-content");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue((OfferAccepteddIcon == true) && OfferStatus2.Contains("Offer accepted") && OfferAccepteddIconhover.Contains("$800.00</br>10 days Left"));
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                loginPage.UserNameTextBox().Click();

                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+872815244@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVDealFees@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                bool OfferAccepteddIcon3 = Recpg.OfferAcceptedIcon().Displayed;
                String OfferStatus3 = Recpg.OfferacceptedStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay1);
                string OfferAccepteddIconhover3 = Recpg.Offerhovertext().GetAttribute("data-content");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue((OfferAccepteddIcon3 == true) && OfferStatus3.Contains("Offer accepted") && OfferAccepteddIconhover3.Contains("$800.00</br>10 days Left"));
                Recpg.ActionsMenu().Click();
                Recpg.PAY().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                PayNowPage Paynwpg = new PayNowPage(WebDriver);
                Paynwpg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Paynwpg.CardRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                
                Paynwpg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Paynwpg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ReceivedHistoryBTN().Click();

                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVDealFees@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string paidstatushover = Recpg.HistoryPaidStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover.Contains("paid"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();
            }
            finally
            {
                
            }
        }

        [Test]
        public void DealFee02_BillerCounterDeal()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal03biller@gmail.com");
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
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+872815244");
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
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVDealFees@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("1080");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                IssueInvoicePg.SurchargeCheckbox().Click();

                //issueInvoice_issueInvoicePage_totalValue.checkValueContains = @amountGst
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");

                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVDealFees@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                bool reqcash = SIVPG1.RequestBillzyCashBTN().Displayed;
                bool reqdeal = SIVPG1.RequestBillzyDealBTN().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(reqcash == true && reqdeal == true);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();

                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+872815244@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVDealFees@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.PayerOfferEarlyPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                
                SIVPG1.NewTotal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.NewTotal().SendKeys("800");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //verify discount %

               
                string percentage = SIVPG1.SIVOfferDiscountpercentage().Text;
                Assert.IsTrue(percentage.Contains("32.66%"));
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SIVPG1.Comments().SendKeys("Payer Requested a Deal");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.OfferEarlyPaymentModalBTN1().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool withdraw = SIVPG1.WithdrawOfferPayerBTN().Displayed;
                Assert.IsTrue(withdraw == true);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVDealFees@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ActionsMenu().Click();
                HomePg.SignOutBTN().Click();

                SeleniumSetMethods.WaitOnPage(secdelay4);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal03biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVDealFees@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                string status = SendPg.BillzyRow1().Text;
                bool icon = SendPg.OfferRecievedIcon().Displayed;

                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(status.Contains("Offer received") && icon == true);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SIVPG1.BillerMakeACounterOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                DateTime duedate1 = DateTime.Today.AddDays(10);
                string SentPgDueDate = duedate1.ToString("dd/MM/yyyy");
                string SentPgDueDate2 = duedate1.ToString("dd MMM yy");
                SIVPG1.NewTotal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.NewTotal().SendKeys("1000");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //verify discount %
                string percentage1 = SIVPG1.SIVOfferDiscountpercentage().Text;
                Assert.IsTrue(percentage1.Contains("15.82%"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().SendKeys(SentPgDueDate);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                SIVPG1.Comments().SendKeys("Biller made a counter offer");
                SeleniumSetMethods.WaitOnPage(secdelay3);

                SIVPG1.makeCounterOfferModalBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay9);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

                SendPg.SearchInvoiceSent().SendKeys("INVDealFees@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                
                String OfferStatus2 = SendPg.OfferStatussendpage().Text;
                
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(OfferStatus2.Contains("Offer sent"));
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                loginPage.UserNameTextBox().Click();

                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+872815244@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVDealFees@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                
                String OfferStatus3 = Recpg.OfferacceptedStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay1);

                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(OfferStatus3.Contains("Offer received"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool PayerMakeACounterOfferBTN = SIVPG1.PayerMakeACounterOfferBTN().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(PayerMakeACounterOfferBTN == true);
                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool delete = SIVPG1.ActionDropdownDelete().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(delete == true);
                SIVPG1.PayerVerifyBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);


                Recpg.ActionsMenu().Click();
                Recpg.PAY().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                PayNowPage Paynwpg = new PayNowPage(WebDriver);
                Paynwpg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Paynwpg.CardRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

                Paynwpg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Paynwpg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ReceivedHistoryBTN().Click();

                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVDealFees@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string paidstatushover = Recpg.HistoryPaidStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover.Contains("paid"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();
            }
            finally
            {
                
            }
        }
        [Test]
        public void DealFee03_BillerCounterPayerCounterDeal()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal03biller@gmail.com");
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
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+872815244");
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
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVDealFees@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("1875.12");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                IssueInvoicePg.SurchargeCheckbox().Click();

                //issueInvoice_issueInvoicePage_totalValue.checkValueContains = @amountGst
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVDealFees@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                bool reqcash = SIVPG1.RequestBillzyCashBTN().Displayed;
                bool reqdeal = SIVPG1.RequestBillzyDealBTN().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(reqcash == true && reqdeal == true);
                DateTime duedate1 = DateTime.Today.AddDays(30);
                string SentPgDueDate = duedate1.ToString("dd/MM/yyyy");
                string SentPgDueDate2 = duedate1.ToString("dd MMM yy");
                SIVPG1.BillerOfferADiscountBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.NewTotal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.NewTotal().SendKeys("1800.55");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().Click();
                string percentage = SIVPG1.SIVOfferDiscountpercentage().Text;
                Assert.IsTrue(percentage.Contains("12.71%"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().SendKeys(SentPgDueDate);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                SIVPG1.Comments().SendKeys("Biller offered a Deal");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.OfferDiscountModalBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay8);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();

                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+872815244@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVDealFees@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.PayerMakeACounterOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                SIVPG1.NewTotal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.NewTotal().SendKeys("1700");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //verify discount %


                string percentage2 = SIVPG1.SIVOfferDiscountpercentage().Text;
                Assert.IsTrue(percentage2.Contains("17.58%"));
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SIVPG1.Comments().SendKeys("Payer made a counter offer");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.makeCounterOfferModalBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool withdraw = SIVPG1.WithdrawOfferPayerBTN().Displayed;
                Assert.IsTrue(withdraw == true);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVDealFees@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ActionsMenu().Click();
                HomePg.SignOutBTN().Click();

                SeleniumSetMethods.WaitOnPage(secdelay4);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal03biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVDealFees@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                string status = SendPg.BillzyRow1().Text;
                bool icon = SendPg.OfferRecievedIcon().Displayed;

                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(status.Contains("Offer received") && icon == true);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SIVPG1.BillerMakeACounterOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                DateTime duedate3 = DateTime.Today.AddDays(15);
                string SentPgDueDate3 = duedate3.ToString("dd/MM/yyyy");
                string SentPgDueDate4 = duedate3.ToString("dd MMM yy");
                SIVPG1.NewTotal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.NewTotal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.NewTotal().SendKeys("1800");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //verify discount %
                string percentage1 = SIVPG1.SIVOfferDiscountpercentage().Text;
                Assert.IsTrue(percentage1.Contains("12.73%"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().SendKeys(SentPgDueDate3);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                SIVPG1.Comments().SendKeys("Biller made a counter offer");
                SeleniumSetMethods.WaitOnPage(secdelay3);

                SIVPG1.makeCounterOfferModalBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

                SendPg.SearchInvoiceSent().SendKeys("INVDealFees@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);

                String OfferStatus2 = SendPg.OfferStatussendpage().Text;

                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(OfferStatus2.Contains("Offer sent"));
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                loginPage.UserNameTextBox().Click();

                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+872815244@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVDealFees@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);

                String OfferStatus3 = Recpg.OfferacceptedStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay1);

                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(OfferStatus3.Contains("Offer received"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                
                SIVPG1.PayerVerifyBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);


                Recpg.ActionsMenu().Click();
                Recpg.PAY().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                PayNowPage Paynwpg = new PayNowPage(WebDriver);
                Paynwpg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Paynwpg.CardRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

                Paynwpg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Paynwpg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ReceivedHistoryBTN().Click();

                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVDealFees@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string paidstatushover = Recpg.HistoryPaidStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover.Contains("paid"));
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
