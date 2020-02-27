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
    class RegSuite_DealWorkflow : Tests
    {
        [Test]
        public void BillzyDeal01_BillerAcceptedDeal()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {
                //###Login to biller account
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);
                SendPage SendPg = new SendPage(WebDriver);
                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                BillzyCashModal BillzyCashMlPg = new BillzyCashModal(WebDriver);
                SIVPage SIVPG1 = new SIVPage(WebDriver);
                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal02biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay8);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+deal02payer");
                
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
               String PaymentTerms = "90 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.LineItemAmount().SendKeys("1,204.09");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SurchargeCheckbox().Click();
                //issueInvoice_issueInvoicePage_totalValue.checkValueContains = @amountGst
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Console.WriteLine("InvoiceCreated");
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SendPg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool markAsPaidOption = SendPg.MarkAsPaidOption().Displayed;
                bool PDFInvoice2 = SendPg.PDFInvoice2().Displayed;
                bool deleteoption1 = SendPg.DeleteOption().Displayed;
                bool dealoption = SendPg.BillzyDealOption().Displayed;
                bool Cashoption = SendPg.BillzyCashOption().Displayed;             
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(markAsPaidOption == true && PDFInvoice2 == true && deleteoption1 == true && dealoption == true && Cashoption == true);
                SendPg.BillzyDealFilterCheckBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string msg = SendPg.Noinvoiceavailablemsg().Text;
                Assert.IsTrue(msg.Contains("No Invoices Available"));
                SendPg.ClearBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SendPg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyDealOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SIVPG1.BillerOfferADiscountBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool offerrequestbtn = SIVPG1.OfferDiscountModalBTN().Displayed;
                Assert.IsTrue(SIVPG1.OfferDiscountModalBTN().Displayed);
                Assert.IsTrue(offerrequestbtn == true);
                SIVPG1.CancelButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
 
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal02payer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool PAY = Recpg.PAY().Displayed;
                bool PostInvoice = Recpg.PostInvoice().Displayed;
                bool VerifyExist = Recpg.VerifyInvoice().Displayed;
                bool PDFInvoice3 = Recpg.PDFInvoice().Displayed;
                bool deleteoption3 = Recpg.DeleteOption().Displayed;
                bool dealoption3 = Recpg.BillzyDealOption().Displayed;               
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(VerifyExist == true && PDFInvoice3 == true && deleteoption3 == true && dealoption3 == true && PostInvoice == true && PAY == true);
                Recpg.BillzyDealOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsFalse(SIVPG1.BillzyCashStatusBTN().Displayed);
                String invstatus = SIVPG1.InvoiceStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invstatus.Contains("UNPAID"));
                SIVPG1.PayerVerifyBTN().Click();

                DateTime duedate1 = DateTime.Today.AddDays(15);
                string SentPgDueDate = duedate1.ToString("dd/MM/yyyy");
                string SentPgDueDate2 = duedate1.ToString("dd MMM yy");
                SIVPG1.PayerOfferEarlyPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.NewTotal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.NewTotal().SendKeys("1,008.82");
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
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                bool OfferSentIcon = Recpg.OfferSentIcon().Displayed;
                String OfferStatus = Recpg.OfferStatus().Text;
                //Recpg.OfferExpiredIcon().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                string OfferSentIconhover = Recpg.OfferSentIconhover().GetAttribute("data-content");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //Console.WriteLine("OfferExpiredhover" + OfferExpiredhover);
                Assert.IsTrue((OfferSentIcon == true) && OfferStatus.Contains("Offer sent") && OfferSentIconhover.Contains("$1,008.82</br>15 days Left"));
                Recpg.BillzyDealFilterCheckBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string invoicelist = Recpg.InvoiceList().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invoicelist.Contains("Showing"));
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal02biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                bool OfferRecievedIcon = SendPg.OfferRecievedIcon().Displayed;
                String OfferStatus1 = Recpg.OfferStatus().Text;              
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string OfferrecievedIconhover = Recpg.Offerhovertext().GetAttribute("data-content");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue((OfferRecievedIcon == true) && OfferStatus1.Contains("Offer received") && OfferrecievedIconhover.Contains("$1,008.82</br>15 days Left"));
                SendPg.BillzyDealFilterCheckBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string invoicelist1 = SendPg.Invoicelist().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invoicelist1.Contains("Showing"));
                SendPg.ClearBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SendPg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool markAsPaidOption1 = SendPg.MarkAsPaidOption().Displayed;
                bool PDFInvoice1 = SendPg.PDFInvoice2().Displayed;
                bool deleteoption2 = SendPg.DeleteOption().Displayed;
                bool dealoption2 = SendPg.BillzyDealOption().Displayed;
                bool Cashoption2 = SendPg.BillzyCashOption().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(markAsPaidOption1 == true && PDFInvoice1 == true && deleteoption2 == true && dealoption2 == true && Cashoption2 == false);
                SendPg.BillzyDealOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool acceptoffer = SIVPG1.AcceptOfferBTN().Displayed;
                bool makeacounter = SIVPG1.BillerMakeACounterOfferBTN().Displayed;
                bool declineoffer = SIVPG1.DeclineOfferBTN().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(acceptoffer == true && makeacounter == true && declineoffer == true);
                SIVPG1.AcceptOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.AcceptTheOfferModalYesBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                
                SendPg.SearchInvoiceSent().SendKeys("INVDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                bool OfferAccepteddIcon = SendPg.OfferAcceptedIcon().Displayed;
                String OfferStatus2 = SendPg.OfferStatussendpage().Text;
                SeleniumSetMethods.WaitOnPage(secdelay1);
                string OfferAccepteddIconhover = Recpg.Offerhovertext().GetAttribute("data-content");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue((OfferAccepteddIcon == true) && OfferStatus2.Contains("Offer accepted") && OfferAccepteddIconhover.Contains("$1,008.82</br>15 days Left"));
                SendPg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                bool markAsPaidOption0 = SendPg.MarkAsPaidOption().Displayed;
                bool PDFInvoice0 = SendPg.PDFInvoice2().Displayed;
                bool deleteoption0 = SendPg.DeleteOption().Displayed;
                bool dealoption0 = SendPg.BillzyDealOption().Displayed;
                bool Cashoption0 = SendPg.BillzyCashOption().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(markAsPaidOption0 == true && PDFInvoice0 == true && deleteoption0 == false && dealoption0 == false && Cashoption0 == false);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                loginPage.UserNameTextBox().Click();
                
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal02payer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                bool OfferAccepteddIcon3 = Recpg.OfferAcceptedIcon().Displayed;
                String OfferStatus3 = Recpg.OfferacceptedStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay1);
                string OfferAccepteddIconhover3 = Recpg.Offerhovertext().GetAttribute("data-content");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue((OfferAccepteddIcon3 == true) && OfferStatus3.Contains("Offer accepted") && OfferAccepteddIconhover3.Contains("$1,008.82</br>15 days Left"));
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool PAY4 = Recpg.PAY().Displayed;
                bool PostInvoice4 = Recpg.PostInvoice().Displayed;
                bool VerifyExist4 = Recpg.VerifyInvoice().Displayed;
                bool PDFInvoice4 = Recpg.PDFInvoice().Displayed;
                bool deleteoption4 = Recpg.DeleteOption().Displayed;
                bool dealoption4 = Recpg.BillzyDealOption().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(VerifyExist4 == false && PDFInvoice4 == true && deleteoption4 == false && dealoption4 == false && PostInvoice4 == true && PAY4 == true);
                Recpg.PAY().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                PayNowPage Paynwpg = new PayNowPage(WebDriver);
                Paynwpg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Paynwpg.CardRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string amount = Paynwpg.Row01AmountPayable().GetAttribute("value");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Console.WriteLine("amount" + amount);
                Assert.IsTrue(amount.Contains("1025.67"));
                Paynwpg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Paynwpg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ReceivedHistoryBTN().Click();
                
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string paidstatushover = Recpg.HistoryPaidStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover.Contains("paid"));
                bool OfferAccepteddIcon4 = Recpg.OfferAcceptedIcon().Displayed;
                String OfferStatus4 = Recpg.OfferacceptedStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay1);
                string OfferAccepteddIconhover4 = Recpg.Offerhovertext().GetAttribute("data-content");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue((OfferAccepteddIcon4 == true) && OfferStatus4.Contains("Offer accepted") && OfferAccepteddIconhover4.Contains("You saved $315.68"));
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal02biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SendPg.SentHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SearchInvoiceSent().SendKeys("INVDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                string paidstatushover1 = SendPg.HistoryPaidStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover1.Contains("paid"));
                bool OfferAccepteddIcon5 = SendPg.OfferAcceptedIcon().Displayed;
                String OfferStatus5 = SendPg.OfferStatussendpage().Text;
                SeleniumSetMethods.WaitOnPage(secdelay1);
                string OfferAccepteddIconhover5 = Recpg.Offerhovertext().GetAttribute("data-content");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue((OfferAccepteddIcon5 == true) && OfferStatus5.Contains("Offer accepted") && OfferAccepteddIconhover5.Contains("earlier"));
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
        public void BillzyDeal02_BillerAcceptedRequestDeal_IncludingGST_NoSurcharge()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {
                //###Login to biller account
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);
                SendPage SendPg = new SendPage(WebDriver);
                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                BillzyCashModal BillzyCashMlPg = new BillzyCashModal(WebDriver);
                SIVPage SIVPG1 = new SIVPage(WebDriver);
                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal02biller@gmail.com");
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
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+deal02payer");
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
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVDEAL@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                IssueInvoicePg.Message().SendKeys("Internal Payer with Deal and no surcharge");
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.NewTotal().SendKeys("319.82");

                DateTime newDate = DateTime.Now.AddDays(15);
                string dtString3 = newDate.ToString("dd/MM/yyyy");

                IssueInvoicePg.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
                IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");

                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Console.WriteLine("InvoiceCreated");
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                DateTime duedate0 = DateTime.Today;
                DateTime duedate00 = DateTime.Today.AddDays(15);
                string SentPgDueDate = duedate0.ToString("dd/MM/yyyy");
                string SentPgDueDate1 = duedate00.ToString("dd/MM/yyyy");


                String DiscountHistoryStatus01 = SIVPG1.DiscountHistoryStatus01().Text;
                String discountHistoryCreatedDate01 = SIVPG1.DiscountHistoryCreatedDate01().Text;
                String discountHistoryCreatedDate02 = SIVPG1.DiscountHistoryCreatedDate01().Text;
                String discountHistoryAmount01 = SIVPG1.DiscountHistoryAmount01().Text;
                String discountHistoryExpiryDate01 = SIVPG1.DiscountHistoryExpiryDate01().Text;
                String discountHistoryComment01 = SIVPG1.DiscountHistoryComment01().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(DiscountHistoryStatus01.Contains("SENT") && discountHistoryCreatedDate01.Contains(SentPgDueDate) && discountHistoryCreatedDate02.Contains("you offered this discount") && discountHistoryAmount01.Contains("319.82") && discountHistoryExpiryDate01.Contains(SentPgDueDate1) && discountHistoryComment01.Contains("Deal is being offered including GST") );
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();

                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal02Payer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string dealstatus = SIVPG1.DiscountHistoryStatus01().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(dealstatus.Contains("RECEIVED"));
                SIVPG1.PayerMakeACounterOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                DateTime duedate000 = DateTime.Today.AddDays(5);
                string SentPgDueDate2 = duedate000.ToString("dd/MM/yyyy");
                SIVPG1.NewTotal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.NewTotal().SendKeys("208.82");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().SendKeys(SentPgDueDate2);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                SIVPG1.Comments().SendKeys("Payer Requested a Deal");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.makeCounterOfferModalBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                bool withdraw = SIVPG1.WithdrawOfferPayerBTN().Displayed;
                bool early = SIVPG1.PayerOfferEarlyPaymentBTN().Displayed;
                bool counter = SIVPG1.PayerMakeACounterOfferBTN().Displayed;
                String dealamount = SIVPG1.PayerPendingDealAmount().Text;
                String dealmsg = SIVPG1.PayerPendingDealMessage().Text;
               String sectiontitle = SIVPG1.DiscountHistorySectionTitle().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(withdraw == true && early == false && counter == false && dealamount.Contains("208.82") && dealmsg.Contains("Offered by you (incl. GST)") && sectiontitle.Contains("DISCOUNT HISTORY"));
                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                String DiscountHistoryStatus03 = SIVPG1.DiscountHistoryStatus01().Text;
                String discountHistoryCreatedDate03 = SIVPG1.DiscountHistoryCreatedDate01().Text;
                String discountHistoryCreatedDate04 = SIVPG1.DiscountHistoryCreatedDate01().Text;
                String discountHistoryAmount03 = SIVPG1.DiscountHistoryAmount01().Text;
                String discountHistoryExpiryDate03 = SIVPG1.DiscountHistoryExpiryDate01().Text;
                String discountHistoryComment03 = SIVPG1.DiscountHistoryComment01().Text;
                String DiscountHistoryStatus04 = SIVPG1.DiscountHistoryStatus02().Text;
                String discountHistoryAmount04 = SIVPG1.DiscountHistoryAmount02().Text;
                String discountHistoryComment04 = SIVPG1.DiscountHistoryComment02().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(DiscountHistoryStatus03.Contains("SENT") && discountHistoryCreatedDate03.Contains(SentPgDueDate) && discountHistoryCreatedDate04.Contains("you sent this offer") && discountHistoryAmount03.Contains("208.82") && discountHistoryExpiryDate03.Contains(SentPgDueDate2) && discountHistoryComment03.Contains("Payer Requested a Deal") && DiscountHistoryStatus04.Contains("RECEIVED") && discountHistoryAmount04.Contains("319.82") && discountHistoryComment04.Contains("Deal is being offered including GST"));
                //SeleniumSetMethods.WaitOnPage(secdelay2);
                
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.SignOutBTN().Click();

                SeleniumSetMethods.WaitOnPage(secdelay4);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal02biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                String DiscountHistoryStatus05 = SIVPG1.DiscountHistoryStatus01().Text;
                String discountHistoryCreatedDate05 = SIVPG1.DiscountHistoryCreatedDate01().Text;
                String discountHistoryCreatedDate06 = SIVPG1.DiscountHistoryCreatedDate01().Text;
                String discountHistoryAmount05 = SIVPG1.DiscountHistoryAmount01().Text;
                String discountHistoryExpiryDate05 = SIVPG1.DiscountHistoryExpiryDate01().Text;
                String discountHistoryComment05 = SIVPG1.DiscountHistoryComment01().Text;
                String DiscountHistoryStatus06 = SIVPG1.DiscountHistoryStatus02().Text;
                String discountHistoryAmount06 = SIVPG1.DiscountHistoryAmount02().Text;
                String discountHistoryComment06 = SIVPG1.DiscountHistoryComment02().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(DiscountHistoryStatus05.Contains("RECEIVED") && discountHistoryCreatedDate05.Contains(SentPgDueDate) && discountHistoryCreatedDate06.Contains("madcowtesting10+deal02payer offered you early payment") && discountHistoryAmount05.Contains("208.82") && discountHistoryExpiryDate05.Contains(SentPgDueDate2) && discountHistoryComment05.Contains("Payer Requested a Deal") && DiscountHistoryStatus06.Contains("SENT") && discountHistoryAmount06.Contains("319.82") && discountHistoryComment06.Contains("Deal is being offered including GST"));
                bool declineoffer = SIVPG1.DeclineOfferBTN().Displayed;
                Assert.IsTrue(declineoffer == true);
                SIVPG1.AcceptOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.AcceptTheOfferModalNoBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SIVPG1.AcceptOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.AcceptTheOfferModalYesBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool decline1 = SIVPG1.DeclineOfferBTN().Displayed;
                //bool accept = SIVPG1.AcceptOfferBTN().Displayed;
                bool discount = SIVPG1.BillerOfferADiscountBTN().Displayed;
                bool counter2 = SIVPG1.BillerMakeACounterOfferBTN().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(decline1 == false && discount == false && counter2 == false);
                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                String DiscountHistoryStatus07 = SIVPG1.DiscountHistoryStatus01().Text;
                String discountHistoryCreatedDate07 = SIVPG1.DiscountHistoryCreatedDate01().Text;
                String discountHistoryCreatedDate08 = SIVPG1.DiscountHistoryCreatedDate01().Text;
                String discountHistoryAmount07 = SIVPG1.DiscountHistoryAmount01().Text;
                String discountHistoryExpiryDate06 = SIVPG1.DiscountHistoryExpiryDate01().Text;
                
                String DiscountHistoryStatus08 = SIVPG1.DiscountHistoryStatus02().Text;
                String DiscountHistoryStatus09 = SIVPG1.DiscountHistoryStatus03().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(DiscountHistoryStatus07.Contains("ACCEPTED") && discountHistoryCreatedDate07.Contains(SentPgDueDate) && discountHistoryCreatedDate08.Contains("you accepted early payment") && discountHistoryAmount07.Contains("208.82") && discountHistoryExpiryDate06.Contains(SentPgDueDate2) && DiscountHistoryStatus08.Contains("RECEIVED") && DiscountHistoryStatus09.Contains("SENT"));
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();

                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal02Payer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String DiscountHistoryStatus10 = SIVPG1.DiscountHistoryStatus01().Text;
                String DiscountHistoryStatus11 = SIVPG1.DiscountHistoryStatus02().Text;
                String DiscountHistoryStatus12 = SIVPG1.DiscountHistoryStatus03().Text;
                Assert.IsTrue(DiscountHistoryStatus10.Contains("ACCEPTED") && DiscountHistoryStatus11.Contains("SENT") && DiscountHistoryStatus12.Contains("RECEIVED"));
                SIVPG1.DealToggle().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                string ExpiryDayPayer = SIVPG1.ExpiryDayPayer().Text;
                string discPerctageValue = SIVPG1.DiscPerctageValue().Text;
                string savedInfoPayer = SIVPG1.SavedInfoPayer().Text;
                string savedInfoPayer2 = SIVPG1.SavedInfoPayer().Text;
                string expiresDateAndTime = SIVPG1.ExpiresDateAndTime().Text;
                string commentsSIV = SIVPG1.CommentsSIV().Text;
                string offeredBy = SIVPG1.OfferedBy().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(ExpiryDayPayer.Contains("5 days") && discPerctageValue.Contains("40.64%") && savedInfoPayer.Contains("142.98") &&  savedInfoPayer2.Contains("saved") && expiresDateAndTime.Contains(SentPgDueDate2) && commentsSIV.Contains("Payer Requested a Deal") && offeredBy.Contains("madcowtesting10+deal02payer"));
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);


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
        public void BillzyDeal03_BillerDeclinedDeal()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {
                //###Login to biller account
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);
                SendPage SendPg = new SendPage(WebDriver);
                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                BillzyCashModal BillzyCashMlPg = new BillzyCashModal(WebDriver);
                SIVPage SIVPG1 = new SIVPage(WebDriver);
                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal02biller@gmail.com");
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
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+deal02payer");
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

                String PaymentTerms = "90 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVDeal@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.LineItemAmount().SendKeys("1,204.09");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                //issueInvoice_issueInvoicePage_totalValue.checkValueContains = @amountGst
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                Console.WriteLine("InvoiceCreated");
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVDEAL@" + randnumber2);
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal02Payer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVDeal@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.PayerOfferEarlyPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                DateTime duedate1 = DateTime.Today.AddDays(15);
                string SentPgDueDate = duedate1.ToString("dd/MM/yyyy");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.NewTotal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.NewTotal().SendKeys("1,008.82");
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
                SeleniumSetMethods.WaitOnPage(secdelay7);
                bool withdraw = SIVPG1.WithdrawOfferPayerBTN().Displayed;
                Assert.IsTrue(withdraw == true);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVDeal@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                DateTime duedate0 = DateTime.Today.AddDays(90);
                string SentRecPgDueDate = duedate0.ToString("dd MMM yy");
                string FromRow01 = Recpg.FromRow01().Text;
                string BillzyInvoiceNumRow01 = Recpg.BillzyInvoiceNumRow01().Text;
                string DueRow01 = Recpg.DueRow01().Text;
                string AmountViewedRow1 = Recpg.AmountViewedRow1().Text;
                string BillzyRow1 = Recpg.BillzyRow1().Text;
                bool icon1 = Recpg.OfferSentIcon().Displayed;
                string OfferSentIconhover = Recpg.OfferSentIconhover().GetAttribute("data-content");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(FromRow01.Contains("madcowtesting10+dea...") && BillzyInvoiceNumRow01.Contains("INVDeal@" + randnumber2) && DueRow01.Contains(SentRecPgDueDate) && AmountViewedRow1.Contains("1,324.50") && BillzyRow1.Contains("Offer sent") && icon1 == true && OfferSentIconhover.Contains("$1,008.82</br>15 days Left"));
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.SignOutBTN().Click();

                SeleniumSetMethods.WaitOnPage(secdelay4);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal02biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVDeal@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                string status = SendPg.BillzyRow1().Text;
                bool icon = SendPg.OfferRecievedIcon().Displayed;
                string OfferrecievedIconhover = Recpg.Offerhovertext().GetAttribute("data-content");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(status.Contains("Offer received") && icon == true && OfferrecievedIconhover.Contains("$1,008.82</br>15 days Left"));

                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SIVPG1.DeclineOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.DeclineOfferModalNo().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.DeclineOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.DeclineOfferModalYes().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                DateTime duedate11 = DateTime.Today;
                string SentPgDueDate11 = duedate11.ToString("dd/MM/yyyy");
                string histstatus = SIVPG1.DiscountHistoryStatus01().Text;
                string date = SIVPG1.DiscountHistoryCreatedDate01().Text;
                string datemsg = SIVPG1.DiscountHistoryCreatedDate01().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(histstatus.Contains("DECLINED") && date.Contains(SentPgDueDate11) && datemsg.Contains("you declined early payment"));
                SIVPG1.BillerOfferADiscountBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.CancelModalBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVDeal@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                string status1 = SendPg.OfferDeclinedstatus().Text;
                bool icon3 = SendPg.OfferDeclinedIcon().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(status1.Contains("Offer declined") && icon3 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();

                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal02payer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVDeal@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string status2 = Recpg.OfferDeclinedStatus().Text;
                bool icon2 = Recpg.OfferDeclinedIcon().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(status2.Contains("Offer declined") && icon2 == true);


                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string histstatus1 = SIVPG1.DiscountHistoryStatus01().Text;
                string histstatus2 = SIVPG1.DiscountHistoryStatus02().Text;
                string date1 = SIVPG1.DiscountHistoryCreatedDate01().Text;
                string datemsg1 = SIVPG1.DiscountHistoryCreatedDate01().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(histstatus.Contains("DECLINED") && date.Contains(SentPgDueDate11) && datemsg1.Contains("madcowtesting10+deal02biller declined your offer") && histstatus2.Contains("SENT"));
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.PAY().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PayNowPage Paypg = new PayNowPage(WebDriver);
                Paypg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paypg.CardRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string amount = Paypg.Row01AmountPayable().GetAttribute("value");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(amount.Contains("1346.62"));
                Paypg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paypg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ReceivedHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVDeal@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);

                SeleniumSetMethods.WaitOnPage(secdelay3);
                string paidstatushover = Recpg.HistoryPaidStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover.Contains("paid"));
                bool declineicon = Recpg.OfferDeclinedIcon().Displayed;
                String OfferStatus = Recpg.OfferDeclinedStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay1);
                
                SeleniumSetMethods.WaitOnPage(secdelay2);
                // Assert.IsTrue((declineicon == true) && OfferStatus.Contains("Offer declined") && declinehover.Contains("You saved $315.68"));
                Assert.IsTrue((declineicon == true) && OfferStatus.Contains("Offer declined"));
                HomePg.SignOutBTN().Click();
                
                SeleniumSetMethods.WaitOnPage(secdelay3);
                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal02biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SendPg.SentHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SearchInvoiceSent().SendKeys("INVDeal@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                string paidstatushover1 = SendPg.HistoryPaidStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover1.Contains("paid"));
                bool decline2 = SendPg.OfferDeclinedIcon().Displayed;
                String OfferStatus5 = SendPg.OfferStatussendpage().Text;
                SeleniumSetMethods.WaitOnPage(secdelay1);
                //string declinehover2 = Recpg.Offerhovertext().GetAttribute("data-content");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue((decline2 == true) && OfferStatus5.Contains("Offer declined"));

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
        public void BillzyDeal04_BillerDeclinedRequestDeal_IncludingGST_NoSurcharge()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal02biller@gmail.com");
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
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+deal02payer");
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

                String PaymentTerms = "End of next month";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVDeal@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                IssueInvoicePg.Message().SendKeys("Internal Payer with Deal and  surcharge");
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.NewTotal().SendKeys("319.82");

                DateTime newDate = DateTime.Now.AddDays(15);
                string dtString3 = newDate.ToString("dd/MM/yyyy");

                IssueInvoicePg.OfferExpiry().Clear();
                IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
                IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay6);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                bool reqcash = SIVPG1.RequestBillzyCashBTN().Displayed;
                bool reqdeal = SIVPG1.RequestBillzyDealBTN().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(reqcash == false && reqdeal == false);



                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                DateTime duedate11 = DateTime.Today;
                string SentPgDueDate11 = duedate11.ToString("dd/MM/yyyy");
                string histstatus = SIVPG1.DiscountHistoryStatus01().Text;
                string date = SIVPG1.DiscountHistoryCreatedDate01().Text;
                string datemsg = SIVPG1.DiscountHistoryCreatedDate01().Text;
                string dealamount = SIVPG1.DiscountHistoryAmount01().Text;
                string dealdue = SIVPG1.DiscountHistoryExpiryDate01().Text;
                
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(histstatus.Contains("SENT") && date.Contains(SentPgDueDate11) && datemsg.Contains("you offered this discount") && dealamount.Contains("319.82") && dealdue.Contains(dtString3));




                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();

                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal02Payer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVDeal@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

                string histstatus1 = SIVPG1.DiscountHistoryStatus01().Text;
                string date1 = SIVPG1.DiscountHistoryCreatedDate01().Text;
                string datemsg1 = SIVPG1.DiscountHistoryCreatedDate01().Text;
                string dealamount1 = SIVPG1.DiscountHistoryAmount01().Text;
                string dealdue1 = SIVPG1.DiscountHistoryExpiryDate01().Text;
                
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(histstatus1.Contains("RECEIVED") && date1.Contains(SentPgDueDate11) && datemsg1.Contains("offered you this discount") && dealamount1.Contains("319.82") && dealdue1.Contains(dtString3));
                SIVPG1.PayerMakeACounterOfferBTN().Click();

                SeleniumSetMethods.WaitOnPage(secdelay5);
                DateTime duedate000 = DateTime.Today.AddDays(5);
                string SentPgDueDate2 = duedate000.ToString("dd/MM/yyyy");
                SIVPG1.NewTotal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.NewTotal().SendKeys("208.82");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().SendKeys(SentPgDueDate2);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                SIVPG1.Comments().SendKeys("Payer Requested a Deal");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.makeCounterOfferModalBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                bool withdraw = SIVPG1.WithdrawOfferPayerBTN().Displayed;
                bool early = SIVPG1.PayerOfferEarlyPaymentBTN().Displayed;
                bool counter = SIVPG1.PayerMakeACounterOfferBTN().Displayed;
                String dealamount2 = SIVPG1.PayerPendingDealAmount().Text;
                String dealmsg = SIVPG1.PayerPendingDealMessage().Text;
                String sectiontitle = SIVPG1.DiscountHistorySectionTitle().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(withdraw == true && early == false && counter == false && dealamount2.Contains("208.82") && dealmsg.Contains("Offered by you (incl. GST)") && sectiontitle.Contains("DISCOUNT HISTORY"));
                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                String DiscountHistoryStatus03 = SIVPG1.DiscountHistoryStatus01().Text;
                String discountHistoryCreatedDate03 = SIVPG1.DiscountHistoryCreatedDate01().Text;
                String discountHistoryCreatedDate04 = SIVPG1.DiscountHistoryCreatedDate01().Text;
                String discountHistoryAmount03 = SIVPG1.DiscountHistoryAmount01().Text;
                String discountHistoryExpiryDate03 = SIVPG1.DiscountHistoryExpiryDate01().Text;
                String discountHistoryComment03 = SIVPG1.DiscountHistoryComment01().Text;
                String DiscountHistoryStatus04 = SIVPG1.DiscountHistoryStatus02().Text;
                String discountHistoryAmount04 = SIVPG1.DiscountHistoryAmount02().Text;
                String discountHistoryComment04 = SIVPG1.DiscountHistoryComment02().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(DiscountHistoryStatus03.Contains("SENT") && discountHistoryCreatedDate03.Contains(SentPgDueDate11) && discountHistoryCreatedDate04.Contains("you sent this offer") && discountHistoryAmount03.Contains("208.82") && discountHistoryExpiryDate03.Contains(SentPgDueDate2) && discountHistoryComment03.Contains("Payer Requested a Deal") && DiscountHistoryStatus04.Contains("RECEIVED") && discountHistoryAmount04.Contains("319.82") && discountHistoryComment04.Contains("Deal is being offered including GST"));
                //SIVPG1.ReturnBTN().Click();

                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();

                SeleniumSetMethods.WaitOnPage(secdelay4);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal02biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVDeal@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                string status = SendPg.BillzyRow1().Text;
                bool icon = SendPg.OfferRecievedIcon().Displayed;
                string OfferrecievedIconhover = Recpg.Offerhovertext().GetAttribute("data-content");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(status.Contains("Offer received") && icon == true && OfferrecievedIconhover.Contains("$208.82</br>5 days Left"));

                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string histstatus01 = SIVPG1.DiscountHistoryStatus01().Text;
                string histstatus02 = SIVPG1.DiscountHistoryStatus02().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(histstatus01.Contains("RECEIVED") && histstatus02.Contains("SENT"));
                SIVPG1.BillerMakeACounterOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.CancelModalBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.DeclineOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.DeclineOfferModalNo().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.DeclineOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.DeclineOfferModalYes().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
              
                string histstatus03 = SIVPG1.DiscountHistoryStatus01().Text;
                string histstatus003 = SIVPG1.DiscountHistoryStatus02().Text;
                string histstatus0003 = SIVPG1.DiscountHistoryStatus03().Text;
                string date03 = SIVPG1.DiscountHistoryCreatedDate01().Text;
                string datemsg03 = SIVPG1.DiscountHistoryCreatedDate01().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(histstatus03.Contains("DECLINED") && date03.Contains(SentPgDueDate11) && datemsg03.Contains("you declined early payment") && histstatus003.Contains("RECEIVED") && histstatus0003.Contains("SENT"));
                SIVPG1.BillerOfferADiscountBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool NewTotal = SIVPG1.NewTotal().Displayed;
                bool OfferExpiry = SIVPG1.OfferExpiry().Displayed;
                bool Comments = SIVPG1.Comments().Displayed;
                bool OfferDiscountModalBTN = SIVPG1.OfferDiscountModalBTN().Displayed;
                Assert.IsTrue(NewTotal == true && OfferExpiry == true && Comments == true && OfferDiscountModalBTN == true);
                SIVPG1.CancelModalBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();

                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal02Payer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVDeal@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string histstatus04 = SIVPG1.DiscountHistoryStatus01().Text;
                string histstatus004 = SIVPG1.DiscountHistoryStatus02().Text;
                string histstatus0004 = SIVPG1.DiscountHistoryStatus03().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(histstatus04.Contains("DECLINED") && histstatus004.Contains("SENT") && histstatus0004.Contains("RECEIVED"));

                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
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
        public void BillzyDeal05_BillerWithdrawDeal()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal02biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay8);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+deal02payer");
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

                String PaymentTerms = "90 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVDEAL@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("1,204.09");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //issueInvoice_issueInvoicePage_totalValue.checkValueContains = @amountGst
                IssueInvoicePg.SendInvoiceBTN().Click();

                Console.WriteLine("InvoiceCreated");

                SeleniumSetMethods.WaitOnPage(secdelay5);

                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyDealOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SIVPG1.BillerOfferADiscountBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.NewTotal().SendKeys("");
                DateTime duedate000 = DateTime.Today.AddDays(5);
                string SentPgDueDate2 = duedate000.ToString("dd/MM/yyyy");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.NewTotal().SendKeys("990.10");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().SendKeys(SentPgDueDate2);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                SIVPG1.Comments().SendKeys("Biller created a Deal");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.OfferDiscountModalBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);



                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();

                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal02Payer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);

                bool OfferReceiveIcon11 = Recpg.OfferRecievedIcon().Displayed;
                String DealRecStatus11 = Recpg.OfferStatus().Text;
                String DealRechoverStatus11 = Recpg.OfferSentIconhover().GetAttribute("data-content");

                Assert.IsTrue(OfferReceiveIcon11 == true && DealRecStatus11.Contains("Offer received") && DealRechoverStatus11.Contains("$990.10</br>5 days Left"));

                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.BillzyDealOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.PayerMakeACounterOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.CancelButton().Click();



                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.ToggleDealHistory().Click();

                SeleniumSetMethods.WaitOnPage(secdelay3);
                string histstatus1 = SIVPG1.DiscountHistoryStatus01().Text;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(histstatus1.Contains("RECEIVED"));


                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();

                SeleniumSetMethods.WaitOnPage(secdelay4);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal02biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);

                bool OfferSentIcon11 = SendPg.OfferSentIconbiller().Displayed;
                String DealStatus11 = SendPg.DealStatus().Text;
                String DealhoverStatus11 = SendPg.OfferSenthover().GetAttribute("data-content");
                
                Assert.IsTrue(OfferSentIcon11 == true && DealStatus11.Contains("Offer sent") && DealhoverStatus11.Contains("$990.10</br>5 days Left"));

                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.WithdrawOfferBillerBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.YesWithdrawOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SIVPG1.ToggleDealHistory().Click();

                SeleniumSetMethods.WaitOnPage(secdelay3);
                string histstatus01 = SIVPG1.DiscountHistoryStatus01().Text;
                string date01 = SIVPG1.DiscountHistoryCreatedDate01().Text;
                string total01 = SIVPG1.DiscountHistoryAmount01().Text;
                string histstatus001 = SIVPG1.DiscountHistoryStatus02().Text;

                Assert.IsTrue(histstatus01.Contains("WITHDRAWN") && histstatus001.Contains("SENT") && date01.Contains("you withdrew your offer") && total01.Contains("990.10"));

                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);

                bool OfferSentIcon12 = SendPg.OfferSentIcon().Displayed;
                String DealStatus12 = SendPg.DealStatus().Text;
                Assert.IsTrue(OfferSentIcon12 == true && DealStatus12.Contains("Offer withdrawn"));
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);



                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();

                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal02Payer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);

                bool OfferSentIcon120 = Recpg.OfferWithdrawnIcon().Displayed;
                String DealStatus120 = Recpg.OfferwithdrawnpayerStatus().Text;
                Assert.IsTrue(OfferSentIcon120 == true && DealStatus120.Contains("Offer withdrawn"));

                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.PAY().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PayNowPage Paypg = new PayNowPage(WebDriver);
                Paypg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paypg.CardRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string amount = Paypg.Row01AmountPayable().GetAttribute("value");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(amount.Contains("1346.62"));
                Paypg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paypg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ReceivedHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVDeal@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                bool OfferSentIcon13 = Recpg.OfferWithdrawnIcon().Displayed;
                String DealStatus13 = Recpg.OfferwithdrawnpayerStatus().Text;
                Assert.IsTrue(OfferSentIcon13 == true && DealStatus13.Contains("Offer withdrawn"));


                string paidstatushover = Recpg.HistoryPaidStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover.Contains("paid"));

                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal02biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SendPg.SentHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SendPg.SearchInvoiceSent().SendKeys("INVDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                bool OfferSentIcon14 = SendPg.OfferWithdrawnIcon().Displayed;
                String DealStatus14 = SendPg.OfferwithdrawnbillerStatus().Text;
                Assert.IsTrue(OfferSentIcon14 == true && DealStatus14.Contains("Offer withdrawn"));


                string paidstatushover1 = SendPg.HistoryPaidStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover1.Contains("paid"));


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
        public void BillzyDeal06_PayerWithdrawDeal()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal02biller@gmail.com");
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
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+deal02payer");
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

                String PaymentTerms = "90 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVDEAL@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("1,204.09");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //issueInvoice_issueInvoicePage_totalValue.checkValueContains = @amountGst
                IssueInvoicePg.SendInvoiceBTN().Click();

                Console.WriteLine("InvoiceCreated");

                SeleniumSetMethods.WaitOnPage(secdelay5);

                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.ActionsMenu().Click();

                SeleniumSetMethods.WaitOnPage(secdelay2);



                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();

                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal02Payer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.BillzyDealOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                DateTime duedate1 = DateTime.Today.AddDays(15);
                string SentPgDueDate = duedate1.ToString("dd/MM/yyyy");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.PayerOfferEarlyPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.NewTotal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.NewTotal().SendKeys("1,008.82");
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
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SIVPG1.WithdrawOfferPayerBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.YesWithdrawOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);


                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

                string histstatus1 = SIVPG1.DiscountHistoryStatus01().Text;

                Assert.IsTrue(histstatus1.Contains("WITHDRAWN"));


                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);

                bool OfferSentIcon120 = Recpg.OfferWithdrawnIcon().Displayed;
                String DealStatus120 = Recpg.OfferwithdrawnpayerStatus().Text;
                Assert.IsTrue(OfferSentIcon120 == true && DealStatus120.Contains("Offer withdrawn"));


                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();

                SeleniumSetMethods.WaitOnPage(secdelay4);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal02biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                bool OfferSentIcon12 = SendPg.OfferSentIcon().Displayed;
                String DealStatus12 = SendPg.DealStatus().Text;
                Assert.IsTrue(OfferSentIcon12 == true && DealStatus12.Contains("Offer withdrawn"));
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.ToggleDealHistory().Click();

                SeleniumSetMethods.WaitOnPage(secdelay2);
                string histstatus01 = SIVPG1.DiscountHistoryStatus01().Text;

                Assert.IsTrue(histstatus01.Contains("WITHDRAWN"));

                SeleniumSetMethods.WaitOnPage(secdelay3);




                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);



                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();

                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal02Payer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);





                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.PAY().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                PayNowPage Paypg = new PayNowPage(WebDriver);
                Paypg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paypg.CardRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string amount = Paypg.Row01AmountPayable().GetAttribute("value");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(amount.Contains("1346.62"));
                Paypg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paypg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ReceivedHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVDeal@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);



                string paidstatushover = Recpg.HistoryPaidStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover.Contains("paid"));

                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal02biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SendPg.SentHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SearchInvoiceSent().SendKeys("INVDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                string paidstatushover1 = SendPg.HistoryPaidStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover1.Contains("paid"));


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
        public void BillzyDeal07_BillerInitiatedDealDeleteMarkasPaid()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal02biller@gmail.com");
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
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+deal02payer");
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
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVDEAL@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                IssueInvoicePg.Message().SendKeys("Internal Payer with Deal and no surcharge");
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.NewTotal().SendKeys("319.82");

                DateTime newDate = DateTime.Now.AddDays(15);
                string dtString3 = newDate.ToString("dd/MM/yyyy");

                IssueInvoicePg.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
                IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");

                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Console.WriteLine("InvoiceCreated");
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);

                // Biller Offer Sent Validation
                bool OfferSentIcon = SendPg.OfferSentIconbiller().Displayed;
                String DealStatus = SendPg.DealStatus().Text;
                Assert.IsTrue(OfferSentIcon == true && DealStatus.Contains("Offer sent"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ActionDropdownMarkAsPaid().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.MarkAsPaidBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SentHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                // Biller Markaspaid Validation in history tab for sent offer
                bool OfferIcon14 = SendPg.OfferWithdrawnIcon().Displayed;
                String DealStatus14 = SendPg.HistOfferstatus().Text;
                String amount14 = SendPg.HistMarkAspaid().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(OfferIcon14 == true && DealStatus14.Contains("Offer sent") && amount14.Contains("Marked as paid"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string paidstatushover1 = SendPg.HistoryPaidStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover1.Contains("paid"));

                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal02Payer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.ReceivedHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                // Payer Markaspaid Validation in history tab for sent offer
                bool OfferIcon15 = Recpg.HistOfferRecievedIcon().Displayed;
                String DealStatus15 = Recpg.HistOfferstatus().Text;
                String amount15 = Recpg.HistMarkAspaid().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(OfferIcon15 == true && DealStatus15.Contains("Offer received") && amount15.Contains("Marked as paid"));
                string paidstatushover = Recpg.HistoryPaidStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover.Contains("paid"));

                //Offerdeleteby biller

                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.SignOutBTN().Click();

                SeleniumSetMethods.WaitOnPage(secdelay4);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal02biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+deal02payer");
                IssueInvoicePg.SelectBusiness().Click();


                Random rand22 = new Random();
                DateTime dt22 = new DateTime();
                string dtString22 = dt22.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber22 = rand22.Next();

                SeleniumSetMethods.WaitOnPage(secdelay3);


                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVDEAL@" + randnumber22);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                IssueInvoicePg.Message().SendKeys("Internal Payer with Deal and no surcharge");
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.NewTotal().SendKeys("319.82");


                IssueInvoicePg.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
                IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");

                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Console.WriteLine("InvoiceCreated");
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVDEAL@" + randnumber22);
                
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ActionDropdownDelete().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.DeleteComment().SendKeys("The invoice is deleted for the testing purpose");
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.ConfirmDeleteBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                
                SendPg.SentHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                // Biller deleted Validation in history tab for sent offer
                bool OfferIcon16 = SendPg.OfferWithdrawnIcon().Displayed;
                String DealStatus16 = SendPg.HistoryOfferwithdrawnStatus().Text;
                String amount16 = SendPg.HistDelete().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(OfferIcon16 == true && DealStatus16.Contains("Offer withdrawn") && amount16.Contains("Deleted"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string paidstatushover11 = SendPg.HistoryDeletedStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover11.Contains("deleted"));
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal02Payer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
               
                Recpg.ReceivedHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVDEAL@" + randnumber22);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                bool OfferIcon17 = Recpg.HistOfferWithdrawnIcon().Displayed;
                String DealStatus17 = Recpg.HistOfferWithdrawndeletedstatus().Text;
                String amount17 = Recpg.HistDeleteamount().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(OfferIcon17 == true && DealStatus17.Contains("Offer withdrawn") && amount17.Contains("Deleted"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string paidstatushover17 = Recpg.HistoryDeletedStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover17.Contains("deleted"));

                //Offerdeleteby payer

                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.SignOutBTN().Click();

                SeleniumSetMethods.WaitOnPage(secdelay4);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal02biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+deal02payer");
                IssueInvoicePg.SelectBusiness().Click();


                Random rand23 = new Random();
                DateTime dt23 = new DateTime();
                string dtString23 = dt23.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber23 = rand23.Next();

                SeleniumSetMethods.WaitOnPage(secdelay3);


                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVDEAL@" + randnumber23);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                IssueInvoicePg.Message().SendKeys("Internal Payer with Deal and no surcharge");
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.NewTotal().SendKeys("319.82");


                IssueInvoicePg.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
                IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");

                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Console.WriteLine("InvoiceCreated");
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVDEAL@" + randnumber23);

                SeleniumSetMethods.WaitOnPage(secdelay7);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal02Payer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                
                
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVDEAL@" + randnumber23);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ActionDropdownDelete().Click();
                
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.DeleteComment().SendKeys("The invoice is deleted for the testing purpose");
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.ConfirmDeleteBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);


                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ReceivedHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                
                bool OfferIcon18 = Recpg.HistOfferWithdrawnIcon().Displayed;
                String DealStatus18 = Recpg.HistOfferWithdrawndeletedstatus().Text;
                String amount18 = Recpg.HistDeleteamount().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(OfferIcon18 == true && DealStatus18.Contains("Offer withdrawn") && amount18.Contains("Deleted"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string paidstatushover18 = Recpg.HistoryDeletedStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover18.Contains("deleted"));

                

                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.SignOutBTN().Click();

                SeleniumSetMethods.WaitOnPage(secdelay4);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal02biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SentHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("INVDEAL@" + randnumber23);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                // Payer deleted Validation in history tab for sent offer
                bool OfferIcon19 = SendPg.OfferWithdrawnIcon().Displayed;
                String DealStatus19 = SendPg.HistoryOfferwithdrawnStatus().Text;
                String amount19 = SendPg.HistDelete().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(OfferIcon19 == true && DealStatus19.Contains("Offer withdrawn") && amount19.Contains("Deleted"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string paidstatushover19 = SendPg.HistoryDeletedStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover19.Contains("deleted"));
                
            }
            finally
            {
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();

            }
        }

       /* [Test]
        public void BillzyDeal08_DealWorkFlow_IconLogic()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {
                //###Login to biller account
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);
                SendPage SendPg = new SendPage(WebDriver);
                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                BillzyCashModal BillzyCashMlPg = new BillzyCashModal(WebDriver);
                SIVPage SIVPG1 = new SIVPage(WebDriver);
                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal02biller@gmail.com");
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
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+deal02payer");
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
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVDEAL@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                IssueInvoicePg.Message().SendKeys("Internal Payer with Deal and no surcharge");
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.NewTotal().SendKeys("319.82");

                DateTime newDate = DateTime.Now.AddDays(15);
                string dtString3 = newDate.ToString("dd/MM/yyyy");

                IssueInvoicePg.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
                IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");

                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Console.WriteLine("InvoiceCreated");
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);

                // Biller Offer Sent Validation
                bool OfferSentIcon = SendPg.OfferSentIconbiller().Displayed;
                String DealStatus = SendPg.DealStatus().Text;
                Assert.IsTrue(OfferSentIcon == true && DealStatus.Contains("Offer sent"));
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                DateTime duedate0 = DateTime.Today;
                DateTime duedate00 = DateTime.Today.AddDays(15);
                string SentPgDueDate = duedate0.ToString("dd/MM/yyyy");
                string SentPgDueDate1 = duedate00.ToString("dd/MM/yyyy");


                String DiscountHistoryStatus01 = SIVPG1.DiscountHistoryStatus01().Text;
                String discountHistoryCreatedDate01 = SIVPG1.DiscountHistoryCreatedDate01().Text;
                String discountHistoryCreatedDate02 = SIVPG1.DiscountHistoryCreatedDate01().Text;
                String discountHistoryAmount01 = SIVPG1.DiscountHistoryAmount01().Text;
                String discountHistoryExpiryDate01 = SIVPG1.DiscountHistoryExpiryDate01().Text;
                String discountHistoryComment01 = SIVPG1.DiscountHistoryComment01().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(DiscountHistoryStatus01.Contains("SENT") && discountHistoryCreatedDate01.Contains(SentPgDueDate) && discountHistoryCreatedDate02.Contains("you offered this discount") && discountHistoryAmount01.Contains("319.82") && discountHistoryExpiryDate01.Contains(SentPgDueDate1) && discountHistoryComment01.Contains("Deal is being offered including GST"));
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();

                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal02Payer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                // Payer Offer Recieved Validation
                bool OfferrecievedIcon = Recpg.OfferRecievedIcon().Displayed;
                String DealRecStatus = Recpg.OfferStatus().Text;
                Assert.IsTrue(OfferrecievedIcon == true && DealRecStatus.Contains("Offer received"));
                SeleniumSetMethods.WaitOnPage(secdelay2);


                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string dealstatus = SIVPG1.DiscountHistoryStatus01().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(dealstatus.Contains("RECEIVED"));
                SIVPG1.PayerMakeACounterOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                DateTime duedate000 = DateTime.Today.AddDays(5);
                string SentPgDueDate2 = duedate000.ToString("dd/MM/yyyy");
                SIVPG1.NewTotal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.NewTotal().SendKeys("208.82");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().SendKeys(SentPgDueDate2);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                SIVPG1.Comments().SendKeys("Payer Requested a Deal");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.makeCounterOfferModalBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                bool withdraw = SIVPG1.WithdrawOfferPayerBTN().Displayed;
                bool early = SIVPG1.PayerOfferEarlyPaymentBTN().Displayed;
                bool counter = SIVPG1.PayerMakeACounterOfferBTN().Displayed;
                String dealamount = SIVPG1.PayerPendingDealAmount().Text;
                String dealmsg = SIVPG1.PayerPendingDealMessage().Text;
                String sectiontitle = SIVPG1.DiscountHistorySectionTitle().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(withdraw == true && early == false && counter == false && dealamount.Contains("208.82") && dealmsg.Contains("Offered by you (incl. GST)") && sectiontitle.Contains("DISCOUNT HISTORY"));
                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                String DiscountHistoryStatus03 = SIVPG1.DiscountHistoryStatus01().Text;
                String discountHistoryCreatedDate03 = SIVPG1.DiscountHistoryCreatedDate01().Text;
                String discountHistoryCreatedDate04 = SIVPG1.DiscountHistoryCreatedDate01().Text;
                String discountHistoryAmount03 = SIVPG1.DiscountHistoryAmount01().Text;
                String discountHistoryExpiryDate03 = SIVPG1.DiscountHistoryExpiryDate01().Text;
                String discountHistoryComment03 = SIVPG1.DiscountHistoryComment01().Text;
                String DiscountHistoryStatus04 = SIVPG1.DiscountHistoryStatus02().Text;
                String discountHistoryAmount04 = SIVPG1.DiscountHistoryAmount02().Text;
                String discountHistoryComment04 = SIVPG1.DiscountHistoryComment02().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(DiscountHistoryStatus03.Contains("SENT") && discountHistoryCreatedDate03.Contains(SentPgDueDate) && discountHistoryCreatedDate04.Contains("you sent this offer") && discountHistoryAmount03.Contains("208.82") && discountHistoryExpiryDate03.Contains(SentPgDueDate2) && discountHistoryComment03.Contains("Payer Requested a Deal") && DiscountHistoryStatus04.Contains("RECEIVED") && discountHistoryAmount04.Contains("319.82") && discountHistoryComment04.Contains("Deal is being offered including GST"));
                //SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                // Payer Offer Sent Validation
                bool OffersentIcon1 = Recpg.OfferSentIcon().Displayed;
                String DealStatus3 = Recpg.OfferStatus().Text;
                Assert.IsTrue(OffersentIcon1 == true && DealStatus3.Contains("Offer sent"));
                SeleniumSetMethods.WaitOnPage(secdelay2);


                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.SignOutBTN().Click();

                SeleniumSetMethods.WaitOnPage(secdelay4);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal02biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                // Biller Offer received Validation
                bool OfferSentIcon4 = SendPg.OfferRecievedIcon().Displayed;
                String DealStatus4 = SendPg.DealStatus().Text;
                Assert.IsTrue(OfferSentIcon4 == true && DealStatus4.Contains("Offer received"));
                SeleniumSetMethods.WaitOnPage(secdelay2);


                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                String DiscountHistoryStatus05 = SIVPG1.DiscountHistoryStatus01().Text;
                String discountHistoryCreatedDate05 = SIVPG1.DiscountHistoryCreatedDate01().Text;
                String discountHistoryCreatedDate06 = SIVPG1.DiscountHistoryCreatedDate01().Text;
                String discountHistoryAmount05 = SIVPG1.DiscountHistoryAmount01().Text;
                String discountHistoryExpiryDate05 = SIVPG1.DiscountHistoryExpiryDate01().Text;
                String discountHistoryComment05 = SIVPG1.DiscountHistoryComment01().Text;
                String DiscountHistoryStatus06 = SIVPG1.DiscountHistoryStatus02().Text;
                String discountHistoryAmount06 = SIVPG1.DiscountHistoryAmount02().Text;
                String discountHistoryComment06 = SIVPG1.DiscountHistoryComment02().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(DiscountHistoryStatus05.Contains("RECEIVED") && discountHistoryCreatedDate05.Contains(SentPgDueDate) && discountHistoryCreatedDate06.Contains("madcowtesting10+deal02payer offered you early payment") && discountHistoryAmount05.Contains("208.82") && discountHistoryExpiryDate05.Contains(SentPgDueDate2) && discountHistoryComment05.Contains("Payer Requested a Deal") && DiscountHistoryStatus06.Contains("SENT") && discountHistoryAmount06.Contains("319.82") && discountHistoryComment06.Contains("Deal is being offered including GST"));
                bool declineoffer = SIVPG1.DeclineOfferBTN().Displayed;
                Assert.IsTrue(declineoffer == true);
                SIVPG1.AcceptOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.AcceptTheOfferModalNoBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SIVPG1.AcceptOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.AcceptTheOfferModalYesBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));
                bool decline1 = bodyTag.Text.Contains("ACCEPT OFFER");
                bool decline11 = bodyTag.Text.Contains("MAKE A COUNTER");
                bool decline111 = bodyTag.Text.Contains("DECLINE OFFER");


                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(decline1 == false && decline11 == false && decline111 == false);
                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                String DiscountHistoryStatus07 = SIVPG1.DiscountHistoryStatus01().Text;
                String discountHistoryCreatedDate07 = SIVPG1.DiscountHistoryCreatedDate01().Text;
                String discountHistoryCreatedDate08 = SIVPG1.DiscountHistoryCreatedDate01().Text;
                String discountHistoryAmount07 = SIVPG1.DiscountHistoryAmount01().Text;
                String discountHistoryExpiryDate06 = SIVPG1.DiscountHistoryExpiryDate01().Text;

                String DiscountHistoryStatus08 = SIVPG1.DiscountHistoryStatus02().Text;
                String DiscountHistoryStatus09 = SIVPG1.DiscountHistoryStatus03().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(DiscountHistoryStatus07.Contains("ACCEPTED") && discountHistoryCreatedDate07.Contains(SentPgDueDate) && discountHistoryCreatedDate08.Contains("you accepted early payment") && discountHistoryAmount07.Contains("208.82") && discountHistoryExpiryDate06.Contains(SentPgDueDate2) && DiscountHistoryStatus08.Contains("RECEIVED") && DiscountHistoryStatus09.Contains("SENT"));
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                // Biller Offer Accepted Validation
                bool OfferSentIcon5 = SendPg.OfferAcceptedIcon().Displayed;
                String DealStatus5 = SendPg.DealStatus().Text;
                Assert.IsTrue(OfferSentIcon5 == true && DealStatus5.Contains("Offer accepted"));
                SeleniumSetMethods.WaitOnPage(secdelay2);

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+deal02payer");
                IssueInvoicePg.SelectBusiness().Click();

                //Generate two random numbers for unique customer details and invoice
                Random rand0 = new Random();
                DateTime dt0 = new DateTime();
                string dtString0 = dt0.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber10 = rand0.Next();
                Random rand20 = new Random();
                DateTime dt20 = new DateTime();
                string dtString20 = dt20.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber20 = rand0.Next();

                SeleniumSetMethods.WaitOnPage(secdelay3);

                String PaymentTerms1 = "60 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms1);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVDEAL@" + randnumber20);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                IssueInvoicePg.Message().SendKeys("Internal Payer with Deal and no surcharge");
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.NewTotal().SendKeys("319.82");


                IssueInvoicePg.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
                IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");

                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Console.WriteLine("InvoiceCreated");
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVDEAL@" + randnumber20);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                bool OfferSentIcon6 = SendPg.OfferSentIconbiller().Displayed;
                String DealStatus6 = SendPg.DealStatus().Text;
                Assert.IsTrue(OfferSentIcon6 == true && DealStatus6.Contains("Offer sent"));
                SeleniumSetMethods.WaitOnPage(secdelay2);



                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();

                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal02Payer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVDEAL@" + randnumber20);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                bool OfferrecievedIcon7 = Recpg.OfferRecievedIcon().Displayed;
                String DealRecStatus7 = Recpg.OfferStatus().Text;
                Assert.IsTrue(OfferrecievedIcon7 == true && DealRecStatus7.Contains("Offer received"));
                SeleniumSetMethods.WaitOnPage(secdelay2);


                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string dealstatus1 = SIVPG1.DiscountHistoryStatus01().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(dealstatus1.Contains("RECEIVED"));
                SIVPG1.PayerMakeACounterOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);


                SIVPG1.NewTotal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.NewTotal().SendKeys("208.82");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().SendKeys(SentPgDueDate2);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                SIVPG1.Comments().SendKeys("Payer Requested a Deal");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.makeCounterOfferModalBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);

                SIVPG1.ToggleDealHistory().Click();

                //SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVDEAL@" + randnumber20);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                bool OffersentIcon8 = Recpg.OfferSentIcon().Displayed;
                String DealStatus8 = Recpg.OfferStatus().Text;
                Assert.IsTrue(OffersentIcon8 == true && DealStatus8.Contains("Offer sent"));
                SeleniumSetMethods.WaitOnPage(secdelay2);


                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.SignOutBTN().Click();

                SeleniumSetMethods.WaitOnPage(secdelay4);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal02biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVDEAL@" + randnumber20);
                SeleniumSetMethods.WaitOnPage(secdelay7);

                bool OfferSentIcon9 = SendPg.OfferRecievedIcon().Displayed;
                String DealStatus9 = SendPg.DealStatus().Text;
                Assert.IsTrue(OfferSentIcon9 == true && DealStatus9.Contains("Offer received"));
                SeleniumSetMethods.WaitOnPage(secdelay2);


                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.DeclineOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.DeclineOfferModalYes().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);

                SIVPG1.ToggleDealHistory().Click();

                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVDEAL@" + randnumber20);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                // Biller Offer Declined Validation
                bool OfferSentIcon10 = SendPg.OfferDeclinedIcon().Displayed;
                String DealStatus10 = SendPg.DealStatus().Text;
                Assert.IsTrue(OfferSentIcon10 == true && DealStatus10.Contains("Offer declined"));
                SeleniumSetMethods.WaitOnPage(secdelay2);




                SeleniumSetMethods.WaitOnPage(secdelay2);

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+deal02payer");
                IssueInvoicePg.SelectBusiness().Click();


                Random rand21 = new Random();
                DateTime dt21 = new DateTime();
                string dtString21 = dt21.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber21 = rand21.Next();

                SeleniumSetMethods.WaitOnPage(secdelay3);


                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms1);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVDEAL@" + randnumber21);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                IssueInvoicePg.Message().SendKeys("Internal Payer with Deal and no surcharge");
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.NewTotal().SendKeys("319.82");


                IssueInvoicePg.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
                IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");

                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Console.WriteLine("InvoiceCreated");
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVDEAL@" + randnumber21);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay6);
                SIVPG1.BillerWithdrawOffer().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.YesWithdrawOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVDEAL@" + randnumber21);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                // Biller Offer withdrawn Validation
                bool OfferSentIcon11 = SendPg.OfferWithdrawnIcon().Displayed;
                String DealStatus11 = SendPg.DealStatus().Text;
                Assert.IsTrue(OfferSentIcon11 == true && DealStatus11.Contains("Offer withdrawn"));




                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();

                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal02Payer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                // Payer Offer Accepted Validation
                bool OfferrecievedIcon12 = Recpg.OfferAcceptedIcon().Displayed;
                String DealRecStatus12 = Recpg.OfferStatus().Text;
                Assert.IsTrue(OfferrecievedIcon12 == true && DealRecStatus12.Contains("Offer accepted"));
                SeleniumSetMethods.WaitOnPage(secdelay2);

                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVDEAL@" + randnumber20);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                // Payer Offer Declined Validation
                bool OfferrecievedIcon13 = Recpg.OfferDeclinedIcon().Displayed;
                String DealRecStatus13 = Recpg.OfferdeclinedStatus().Text;
                Assert.IsTrue(OfferrecievedIcon13 == true && DealRecStatus13.Contains("Offer declined"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.SignOutBTN().Click();

                SeleniumSetMethods.WaitOnPage(secdelay4);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal02biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+deal02payer");
                IssueInvoicePg.SelectBusiness().Click();


                Random rand22 = new Random();
                DateTime dt22 = new DateTime();
                string dtString22 = dt22.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber22 = rand22.Next();

                SeleniumSetMethods.WaitOnPage(secdelay3);


                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms1);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVDEAL@" + randnumber22);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                IssueInvoicePg.Message().SendKeys("Internal Payer with Deal and no surcharge");
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.NewTotal().SendKeys("319.82");


                IssueInvoicePg.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
                IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");

                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Console.WriteLine("InvoiceCreated");
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVDEAL@" + randnumber22);
                SeleniumSetMethods.WaitOnPage(secdelay7);

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+deal02payer");
                IssueInvoicePg.SelectBusiness().Click();


                Random rand23 = new Random();
                DateTime dt23 = new DateTime();
                string dtString23 = dt23.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber23 = rand23.Next();

                SeleniumSetMethods.WaitOnPage(secdelay3);


                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms1);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVDEAL@" + randnumber23);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                IssueInvoicePg.Message().SendKeys("Internal Payer with Deal and no surcharge");
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.NewTotal().SendKeys("319.82");


                IssueInvoicePg.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
                IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");

                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Console.WriteLine("InvoiceCreated");
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVDEAL@" + randnumber23);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ActionDropdownMarkAsPaid().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.MarkAsPaidBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SentHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVDEAL@" + randnumber23);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                // Biller Markaspaid Validation in history tab for sent offer
                bool OfferIcon14 = SendPg.OfferWithdrawnIcon().Displayed;
                String DealStatus14 = Recpg.HistOfferstatus().Text;
                Assert.IsTrue(OfferIcon14 == true && DealStatus14.Contains("Offer sent"));
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+deal02payer");
                IssueInvoicePg.SelectBusiness().Click();


                Random rand24 = new Random();
                DateTime dt24 = new DateTime();
                string dtString24 = dt24.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber24 = rand24.Next();

                SeleniumSetMethods.WaitOnPage(secdelay3);


                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms1);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVDEAL@" + randnumber24);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                IssueInvoicePg.Message().SendKeys("Internal Payer with Deal and no surcharge");
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.NewTotal().SendKeys("319.82");


                IssueInvoicePg.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
                IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");

                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Console.WriteLine("InvoiceCreated");
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVDEAL@" + randnumber24);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ActionDropdownDelete().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.DeleteComment().SendKeys("The invoice is deleted for the testing purpose");
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.ConfirmDeleteBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                
                SendPg.SentHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SendPg.SearchInvoiceSent().SendKeys("INVDEAL@" + randnumber24);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                // Biller deleted Validation in history tab for sent offer
                bool OfferIcon15 = SendPg.OfferWithdrawnIcon().Displayed;
                String DealStatus15 = SendPg.withdrawimgtxt().Text;
                Assert.IsTrue(OfferIcon15 == true && DealStatus15.Contains("Offer withdrawn"));
                SeleniumSetMethods.WaitOnPage(secdelay2);



                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+deal02payer");
                IssueInvoicePg.SelectBusiness().Click();


                Random rand25 = new Random();
                DateTime dt25 = new DateTime();
                string dtString25 = dt25.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber25 = rand25.Next();

                SeleniumSetMethods.WaitOnPage(secdelay3);


                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms1);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVDEAL@" + randnumber25);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                IssueInvoicePg.Message().SendKeys("Internal Payer with Deal and no surcharge");
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.NewTotal().SendKeys("319.82");


                IssueInvoicePg.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
                IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");

                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Console.WriteLine("InvoiceCreated");
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVDEAL@" + randnumber25);
                SeleniumSetMethods.WaitOnPage(secdelay3);



                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();

                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal02Payer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.ReceivedHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVDEAL@" + randnumber23);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                // Payer Markaspaid Validation in history tab for sent offer
                bool OfferIcon16 = Recpg.HistOfferRecievedIcon().Displayed;
                String DealStatus16 = Recpg.HistOfferstatus().Text;
                Assert.IsTrue(OfferIcon16 == true && DealStatus16.Contains("Offer received"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.ReceivedHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVDEAL@" + randnumber22);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                // Payer deleted Validation in history tab for sent offer
                bool OfferIcon17 = Recpg.HistOfferRecievedIcon().Displayed;
                String DealStatus17 = Recpg.HistOfferstatus().Text;
                Assert.IsTrue(OfferIcon17 == true && DealStatus17.Contains("Offer received"));
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                Recpg.SearchInvoiceReceived().SendKeys("INVDEAL@" + randnumber24);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();


            }
            finally
            {
              
            }
            
        }
        */



    }
}
