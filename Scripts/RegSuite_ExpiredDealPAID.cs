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
    class RegSuite_ExpiredDealPAID : Tests
    {
        [Test]
        public void EXPDeal01_PayerBillerView_WithDeal_DealBillerInitiated_IncludingGST_Surcharge_PayCC()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);


                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowbiller+gst01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay8);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                
                SendPage SendPg = new SendPage(WebDriver);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BusinessName().SendKeys("payergst01");
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
                DateTime newDate = DateTime.Now.AddDays(900);
                string dtString3 = newDate.ToString("dd/MM/yyyy");
                String PaymentTerms = "90 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.DueDate().Click();

                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.DueDate().Clear();
                IssueInvoicePg.DueDate().SendKeys(dtString3);
                IssueInvoicePg.CreateInvoice().Click();
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("ExpiredDealCC" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                
                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.NewTotal().SendKeys("319.82");

                DateTime newDate1 = DateTime.Now;
                string dtString4 = newDate1.ToString("dd/MM/yyyy");

                IssueInvoicePg.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.OfferExpiry().SendKeys(dtString4);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");

                IssueInvoicePg.SurchargeCheckbox().Click();

                //issueInvoice_issueInvoicePage_totalValue.checkValueContains = @amountGst
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("ExpiredDealCC" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);


                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);



                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowpayer+gst01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                
                SeleniumSetMethods.WaitOnPage(secdelay7);
                
                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                BillzyCashModal BillzyCashMlPg = new BillzyCashModal(WebDriver);
                PayNowPage PayNwPg = new PayNowPage(WebDriver);
                SIVPage SIVPG1 = new SIVPage(WebDriver);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("ExpiredDealCC");
                SeleniumSetMethods.WaitOnPage(secdelay6);
                Recpg.DueColumn().Click();
                SeleniumSetMethods.WaitOnPage(secdelay6);
                string billzyrefnumber = Recpg.BillzyRefResult().Text;

                bool OfferExpiredIcon = Recpg.OfferExpiredIcon().Displayed;
                String OfferStatus = Recpg.OfferStatus().Text;
                
                SeleniumSetMethods.WaitOnPage(secdelay1);
                string OfferExpiredhover = Recpg.Expiredhovertxt().GetAttribute("data-content");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //Console.WriteLine("OfferExpiredhover" + OfferExpiredhover);
                Assert.IsTrue((OfferExpiredIcon == true) && OfferStatus.Contains("Offer expired") && OfferExpiredhover.Contains("Deal expired on:"));
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool PAY = Recpg.PAY().Displayed;
                bool PostInvoice = Recpg.PostInvoice().Displayed;
                bool VerifyExist = Recpg.VerifyInvoice().Displayed;
                bool PDFInvoice2 = Recpg.PDFInvoice().Displayed;
                bool deleteoption1 = Recpg.DeleteOption().Displayed;
                //bool dealoption = Recpg.BillzyDealOption().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                //Assert.IsTrue(VerifyExist == true && PDFInvoice2 == true && deleteoption1 == true && dealoption == true && PostInvoice == true && PAY == true);
                Assert.IsTrue(VerifyExist == true && PDFInvoice2 == true && deleteoption1 == true && PostInvoice == true && PAY == true);
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string invnumber = SIVPG1.InvNumber().Text;
                string invoicenumber = invnumber.Substring(invnumber.IndexOf("Invoice ")).Replace("Invoice ", "");
                SIVPG1.PayerVerifyBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                String Verifiedmsg = SIVPG1.VerifiedTextMsg().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
               Assert.IsTrue(Verifiedmsg.Contains("You verified this invoice on"));
                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                String discounthiststatus = SIVPG1.DiscountHistoryStatus01().Text;
                String Discounthistamount = SIVPG1.DiscountHistoryAmount01().Text;
                bool paybutton = SIVPG1.PayButtonNoDeal().Displayed;
                String PayButtonNoDealTxt = SIVPG1.PayButtonNoDeal().Text;
                // bool Paybuttondealhist = SIVPG1.PayButton().Isd;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(discounthiststatus.Contains("RECEIVED") && Discounthistamount.Contains("319.82") && paybutton == true && PayButtonNoDealTxt.Contains("PAY $351.80 (incl. GST)"));
                SIVPG1.PayButtonNoDeal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PayNowPage paypg = new PayNowPage(WebDriver);
                paypg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.CardRow03().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string amount = paypg.Row01AmountPayable().GetAttribute("value");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(amount.Contains("357.68"));
                paypg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                paypg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ReceivedHistoryBTN().Click();

                Recpg.SearchInvoiceReceived().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string refnum = Recpg.BillzyInvoiceNumRow01().Text;
                string amountpaid = Recpg.AmountRow1().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(refnum.Contains(billzyrefnumber) && amountpaid.Contains("$357.68"));
                bool OfferExpiredIcon1 = Recpg.HistOfferIcon().Displayed;
                String OfferStatus1 = Recpg.HistOfferstatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(OfferExpiredIcon1 == true && OfferStatus1.Contains("Offer expired"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowbiller+gst01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SentHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                String INVstatus = SIVPG1.VerifiedMsgstatus().Text;
                String Paidstatus = SIVPG1.PaidStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Console.WriteLine("INVstatus:" + INVstatus + "Paidstatus:" + Paidstatus);
                Assert.IsTrue(INVstatus.Contains("VERIFIED") && Paidstatus.Contains("PAID"));
                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                String discounthiststatus1 = SendPg.SentDealhistorystatus().Text;
                String Discounthistamount1 = SIVPG1.DiscountHistoryAmount01().Text;
                Assert.IsTrue(discounthiststatus1.Contains("SENT") && Discounthistamount1.Contains("319.82"));
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool OfferExpiredIcon2 = Recpg.HistOfferIcon().Displayed;
                String OfferStatus2 = Recpg.HistOfferstatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(OfferExpiredIcon2 == true && OfferStatus2.Contains("Offer expired"));
                //HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
            }
            finally
            {
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
            }
        }

        [Test]
        public void EXPDeal02_PayerBillerView_WithDeal_DealBillerInitiated_ExcludingGST_Surcharge_PayDD()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {

                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowbiller+nogst01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                SendPage SendPg = new SendPage(WebDriver);
                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                BillzyCashModal BillzyCashMlPg = new BillzyCashModal(WebDriver);
                PayNowPage PayNwPg = new PayNowPage(WebDriver);
                SIVPage SIVPG1 = new SIVPage(WebDriver);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BusinessName().SendKeys("payernogst01");
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
                DateTime newDate = DateTime.Now.AddDays(900);
                string dtString3 = newDate.ToString("dd/MM/yyyy");
                String PaymentTerms = "90 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.DueDate().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.DueDate().Clear();
                IssueInvoicePg.DueDate().SendKeys(dtString3);
                IssueInvoicePg.CreateInvoice().Click();
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("ExpiredDealDD_01" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                
                IssueInvoicePg.LineItemAmount().SendKeys("400.82");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.NewTotal().SendKeys("319.82");

                DateTime newDate1 = DateTime.Now;
                string dtString4 = newDate1.ToString("dd/MM/yyyy");

                IssueInvoicePg.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.OfferExpiry().SendKeys(dtString4);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");

                IssueInvoicePg.SurchargeCheckbox().Click();

                //issueInvoice_issueInvoicePage_totalValue.checkValueContains = @amountGst
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys(("ExpiredDealDD_01" + randnumber2));
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);



                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowpayer+nogst01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();

                SeleniumSetMethods.WaitOnPage(secdelay7);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("ExpiredDealDD_01");
                SeleniumSetMethods.WaitOnPage(secdelay6);

                Recpg.DueColumn().Click();
                SeleniumSetMethods.WaitOnPage(secdelay6);
                string billzyrefnumber = Recpg.BillzyRefResult().Text;

                bool OfferExpiredIcon = Recpg.OfferExpiredIcon().Displayed;
                String OfferStatus = Recpg.OfferStatus().Text;

                SeleniumSetMethods.WaitOnPage(secdelay1);
                string OfferExpiredhover = Recpg.Expiredhovertxt().GetAttribute("data-content");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //Console.WriteLine("OfferExpiredhover" + OfferExpiredhover);
                Assert.IsTrue((OfferExpiredIcon == true) && OfferStatus.Contains("Offer expired") && OfferExpiredhover.Contains("Deal expired on:"));
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool PAY = Recpg.PAY().Displayed;
                bool PostInvoice = Recpg.PostInvoice().Displayed;
                bool VerifyExist = Recpg.VerifyInvoice().Displayed;
                bool PDFInvoice2 = Recpg.PDFInvoice().Displayed;
                bool deleteoption1 = Recpg.DeleteOption().Displayed;
                
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(VerifyExist == true && PDFInvoice2 == true && deleteoption1 == true &&  PostInvoice == true && PAY == true);
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string invnumber = SIVPG1.InvNumber().Text;
                string invoicenumber = invnumber.Substring(invnumber.IndexOf("Invoice ")).Replace("Invoice ", "");
                //SIVPG1.PayerVerifyBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
               // String Verifiedmsg = SIVPG1.VerifiedTextMsg().Text;
                //SeleniumSetMethods.WaitOnPage(secdelay2);
               // Assert.IsTrue(Verifiedmsg.Contains("You verified this invoice on"));
                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
               // String discounthiststatus = SIVPG1.DiscountHistoryStatus01().Text;
                String Discounthistamount = SIVPG1.DiscountHistoryAmount01().Text;
                bool paybutton = SIVPG1.PayButtonNoDeal().Displayed;
                String PayButtonNoDealTxt = SIVPG1.PayButtonNoDeal().Text;
                // bool Paybuttondealhist = SIVPG1.PayButton().Isd;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                // Assert.IsTrue(discounthiststatus.Contains("RECEIVED") && Discounthistamount.Contains("319.82") && paybutton == true && PayButtonNoDealTxt.Contains("PAY $400.82 (excl. GST)"));
                Assert.IsTrue( Discounthistamount.Contains("319.82") && paybutton == true && PayButtonNoDealTxt.Contains("PAY $400.82 (excl. GST)"));
                SIVPG1.PayButtonNoDeal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PayNowPage paypg = new PayNowPage(WebDriver);
                paypg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.CardRow02().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string amount = paypg.Row01AmountPayable().GetAttribute("value");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(amount.Contains("400.82"));
                paypg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                paypg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ReceivedHistoryBTN().Click();

                Recpg.SearchInvoiceReceived().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string refnum = Recpg.BillzyInvoiceNumRow01().Text;
                string amountpaid = Recpg.AmountRowProcess1().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(refnum.Contains(billzyrefnumber) && amountpaid.Contains("$400.82"));
                bool OfferExpiredIcon1 = Recpg.HistOfferIcon().Displayed;
                String OfferStatus1 = Recpg.HistOfferstatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(OfferExpiredIcon1 == true && OfferStatus1.Contains("Offer expired"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowbiller+nogst01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SentHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                String INVstatus = SIVPG1.VerifiedMsgstatus().Text;
                String Paidstatus = SIVPG1.PaidStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Console.WriteLine("INVstatus:" + INVstatus + "Paidstatus:" + Paidstatus);
                // Assert.IsTrue(INVstatus.Contains("VERIFIED") && Paidstatus.Contains("PROCESSING"));
                Assert.IsTrue( Paidstatus.Contains("PROCESSING"));
                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                String discounthiststatus1 = SendPg.SentDealhistorystatus().Text;
                String Discounthistamount1 = SIVPG1.DiscountHistoryAmount01().Text;
                Assert.IsTrue(discounthiststatus1.Contains("SENT") && Discounthistamount1.Contains("319.82"));
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool OfferExpiredIcon2 = Recpg.HistOfferIcon().Displayed;
                String OfferStatus2 = Recpg.HistOfferstatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(OfferExpiredIcon2 == true && OfferStatus2.Contains("Offer expired"));
                //HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
            }

            finally
            {
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
            }
        }
        [Test]
        public void EXPDeal03_SIV_PayerBillerView_WithDeal_DealPayerInitiated_IncludingGST_NoSurcharge_PayCC()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);


                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowbiller+gst01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay8);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);

                SendPage SendPg = new SendPage(WebDriver);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BusinessName().SendKeys("payergst01");
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
                DateTime newDate = DateTime.Now.AddDays(900);
                string dtString3 = newDate.ToString("dd/MM/yyyy");
                String PaymentTerms = "By Due Date";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.DueDate().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.DueDate().Clear();
                IssueInvoicePg.DueDate().SendKeys(dtString3);
                IssueInvoicePg.CreateInvoice().Click();
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("PEDCC@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                
                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                

                //IssueInvoicePg.SurchargeCheckbox().Click();

                //issueInvoice_issueInvoicePage_totalValue.checkValueContains = @amountGst
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);



                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowpayer+gst01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();

                SeleniumSetMethods.WaitOnPage(secdelay7);

                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                BillzyCashModal BillzyCashMlPg = new BillzyCashModal(WebDriver);
                PayNowPage PayNwPg = new PayNowPage(WebDriver);
                SIVPage SIVPG1 = new SIVPage(WebDriver);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("PEDCC@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay6);
                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SIVPG1.PayerOfferEarlyPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.NewTotal().SendKeys("319.82");

                DateTime newDate1 = DateTime.Now;
                string dtString4 = newDate1.ToString("dd/MM/yyyy");

                SIVPG1.OfferExpiry().Clear();
                SIVPG1.OfferExpiry().SendKeys(dtString4);
                SIVPG1.Comments().SendKeys("Payer request to Offer Early Payment");
                SIVPG1.offerEarlyPaymentModalBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay6);


                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("PEDCC");
                SeleniumSetMethods.WaitOnPage(secdelay10);
                Recpg.InvoiceNumclick().Click();
                SeleniumSetMethods.WaitOnPage(secdelay6);
                string billzyrefnumber = Recpg.BillzyRefResult().Text;

                bool OfferExpiredIcon = Recpg.OfferExpiredIcon().Displayed;
                String OfferStatus = Recpg.OfferStatus().Text;

                SeleniumSetMethods.WaitOnPage(secdelay3);
                string OfferExpiredhover = Recpg.Expiredhovertxt().GetAttribute("data-content");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //Console.WriteLine("OfferExpiredhover" + OfferExpiredhover);
                Assert.IsTrue((OfferExpiredIcon == true) && OfferStatus.Contains("Offer expired") && OfferExpiredhover.Contains("Deal expired on:"));
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool PAY = Recpg.PAY().Displayed;
                bool PostInvoice = Recpg.PostInvoice().Displayed;
                bool VerifyExist = Recpg.VerifyInvoice().Displayed;
                bool PDFInvoice2 = Recpg.PDFInvoice().Displayed;
                bool deleteoption1 = Recpg.DeleteOption().Displayed;
                bool dealoption = Recpg.BillzyDealOption().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(VerifyExist == true && PDFInvoice2 == true && deleteoption1 == true && dealoption == true && PostInvoice == true && PAY == true);
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string invnumber = SIVPG1.InvNumber().Text;
                string invoicenumber = invnumber.Substring(invnumber.IndexOf("Invoice ")).Replace("Invoice ", "");
                SIVPG1.PayerVerifyBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                String Verifiedmsg = SIVPG1.VerifiedTextMsg().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Verifiedmsg.Contains("You verified this invoice on"));
                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                String discounthiststatus = SIVPG1.DiscountHistoryStatus01().Text;
                String Discounthistamount = SIVPG1.DiscountHistoryAmount01().Text;
                bool paybutton = SIVPG1.PayButtonNoDeal().Displayed;
                String PayButtonNoDealTxt = SIVPG1.PayButtonNoDeal().Text;
                // bool Paybuttondealhist = SIVPG1.PayButton().Isd;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(discounthiststatus.Contains("SENT") && paybutton == true && PayButtonNoDealTxt.Contains("PAY $351.80 (incl. GST)"));
                SIVPG1.PayButtonNoDeal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PayNowPage paypg = new PayNowPage(WebDriver);
                paypg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.CardRow03().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                paypg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                paypg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ReceivedHistoryBTN().Click();

                Recpg.SearchInvoiceReceived().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay6);
                string refnum = Recpg.BillzyInvoiceNumRow01().Text;
                
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(refnum.Contains(billzyrefnumber));
                bool OfferExpiredIcon1 = Recpg.HistOfferIcon().Displayed;
                String OfferStatus1 = Recpg.HistOfferstatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(OfferExpiredIcon1 == true && OfferStatus1.Contains("Offer expired"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowbiller+gst01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SentHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                String INVstatus = SIVPG1.VerifiedMsgstatus().Text;
                String Paidstatus = SIVPG1.PaidStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Console.WriteLine("INVstatus:" + INVstatus + "Paidstatus:" + Paidstatus);
                Assert.IsTrue(INVstatus.Contains("VERIFIED") && Paidstatus.Contains("PAID"));
                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
  
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool OfferExpiredIcon2 = Recpg.HistOfferIcon().Displayed;
                String OfferStatus2 = Recpg.HistOfferstatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(OfferExpiredIcon2 == true && OfferStatus2.Contains("Offer expired"));
                //HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
            }
            finally
            {
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
            }
        }
    }
}