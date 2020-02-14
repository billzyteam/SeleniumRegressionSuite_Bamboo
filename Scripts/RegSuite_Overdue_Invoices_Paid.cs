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
    class RegSuite_Overdue_Invoices_Paid : Tests
    {

        [Test]
        public void InvoiceWithDeal01_GST_Overdue_Paid_CC()
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
                loginPage.UserNameTextBox().SendKeys("svc-madcowbillergst@4impact.com.au");
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
                IssueInvoicePg.BusinessName().SendKeys("BillzyPayGST");
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

                DateTime newDate = DateTime.Now;
                string dtString3 = newDate.ToString("dd/MM/yyyy");
                string dtString4 = newDate.ToString("dd/MM/yy");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "By Due Date";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("OverDueInvoice1_@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.DueDate().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.DueDate().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.DueDate().SendKeys(dtString3);


                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer excluding GST");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.NewTotal().SendKeys("319.82");
                SeleniumSetMethods.WaitOnPage(secdelay1);

                IssueInvoicePg.OfferExpiry().Clear();
                IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Comments().SendKeys("Biller created deal");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Console.WriteLine("InvoiceCreated");
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("OverDueInvoice1_@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("svc-madcowpayergst@4impact.com.au");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("OverDueInvoice1");
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string invnumber = SIVPG1.InvNumber().Text;
                string invoicenumber = invnumber.Substring(invnumber.IndexOf("Invoice ")).Replace("Invoice ", "");
                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string dealsts = SIVPG1.DiscountHistoryStatus01().Text;
                string amount = SIVPG1.PayButtonNoDeal().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(dealsts.Contains("RECEIVED") && amount.Contains("PAY $351.80 (incl. GST)"));

                SIVPG1.PayerVerifyBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.ReturnBTN().Click();
                Recpg.SearchInvoiceReceived().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Recpg.ActionsMenu().Click();
                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                SIVPG1.PayBTNNoDeal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PayNowPage Paynwpg = new PayNowPage(WebDriver);
                Paynwpg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paynwpg.CardRow03().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));
                
                
                string amount1 = Paynwpg.Row01AmountPayable().GetAttribute("value");
                bool siv2 = bodyTag.Text.Contains("Includes 1.67% surcharge");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(amount1.Contains("357.68") && siv2 ==true);
                Paynwpg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paynwpg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ReceivedHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string paidstatushover = Recpg.HistoryPaidStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover.Contains("paid"));
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                String status2 = SIVPG1.InvoiceStatus().Text;
                String paymentMethodText = SIVPG1.PaymentMethodUsed().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(status2.Contains("PAID") && paymentMethodText.Contains("Amount paid by CC"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("svc-madcowbillergst@4impact.com.au ");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SendPg.SentHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SearchInvoiceSent().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                string paidstatushover1 = SendPg.HistoryPaidStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover1.Contains("paid"));
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                string amount3 = SIVPG1.InvoiceDetailsPayPanel().Text;
                string paiddate = SIVPG1.InvoiceDetailsDatePaid().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(amount3.Contains("$357.68") && paiddate.Contains(dtString4));
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
        public void InvoiceWithDeal02_NoGST_Overdue_Processing_DD()
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
                loginPage.UserNameTextBox().SendKeys("svc-madcowbillernogst@4impact.com.au");
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
                IssueInvoicePg.BusinessName().SendKeys("PayNoGST");
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

                DateTime newDate = DateTime.Now;
                string dtString3 = newDate.ToString("dd/MM/yyyy");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "By Due Date";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("OverDueInvoice2_@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.DueDate().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.DueDate().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.DueDate().SendKeys(dtString3);


                IssueInvoicePg.LineItemAmount().SendKeys("400.82");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer excluding GST");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.NewTotal().SendKeys("319.82");
                SeleniumSetMethods.WaitOnPage(secdelay1);

                IssueInvoicePg.OfferExpiry().Clear();
                IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Comments().SendKeys("Biller created deal");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Console.WriteLine("InvoiceCreated");
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("OverDueInvoice2_@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("svc-madcowpayernogst@4impact.com.au");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("OverDueInvoice2");
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string invnumber = SIVPG1.InvNumber().Text;
                string invoicenumber = invnumber.Substring(invnumber.IndexOf("Invoice ")).Replace("Invoice ", "");
                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string dealsts = SIVPG1.DiscountHistoryStatus01().Text;
                string amount = SIVPG1.PayButtonNoDeal().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(dealsts.Contains("RECEIVED") && amount.Contains("PAY $400.82 (excl. GST)"));

                SIVPG1.PayerVerifyBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.ReturnBTN().Click();
                Recpg.SearchInvoiceReceived().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Recpg.ActionsMenu().Click();
                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                SIVPG1.PayBTNNoDeal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PayNowPage Paynwpg = new PayNowPage(WebDriver);
                Paynwpg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paynwpg.CardRow02().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));


                string amount1 = Paynwpg.Row01AmountPayable().GetAttribute("value");
                bool siv2 = bodyTag.Text.Contains("Includes 1.67% surcharge");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(amount1.Contains("400.82") && siv2 == false);
                Paynwpg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paynwpg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ReceivedHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string paidstatushover = Recpg.HistoryProcessingStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover.Contains("processing"));
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                String status2 = SIVPG1.InvoiceStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(status2.Contains("PROCESSING"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("svc-madcowbillernogst@4impact.com.au");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SendPg.SentHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SearchInvoiceSent().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                string paidstatushover1 = SendPg.HistoryProcessingStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover1.Contains("processing"));
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string dealmsg = SendPg.SIVProcessingStatus().Text;
                string invref = SIVPG1.InvoiceDetailsInvoiceRef().Text;
                string paidamount = SIVPG1.InvoiceDetailsInvoiceAmount().Text;

                Assert.IsTrue(dealmsg.Contains("PROCESSING") && invref.Contains("OverDue") && paidamount.Contains("$400.82"));
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
