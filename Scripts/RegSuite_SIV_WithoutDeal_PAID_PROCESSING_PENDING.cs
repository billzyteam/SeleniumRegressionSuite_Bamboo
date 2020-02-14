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
    class RegSuite_SIV_WithoutDeal_PAID_PROCESSING_PENDING : Tests
    {
        [Test]
        public void InvoiceNoDeal01_ExcludigGST_NoSurcharge_Paid_Biller_Payer()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));

                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+asivnodealunpaidb@gmail.com");
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
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+asivnodealunpaidp");
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
                DateTime newDate = DateTime.Now.AddDays(60);
                string dtString3 = newDate.ToString("dd/MM/yyyy");
                String PaymentTerms = "60 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.DueDate().Click();

                SeleniumSetMethods.WaitOnPage(secdelay3);
                //IssueInvoicePg.DueDate().Clear();
                //IssueInvoicePg.DueDate().SendKeys(dtString3);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV-06_1@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");

                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");

                SeleniumSetMethods.WaitOnPage(secdelay2);


                //issueInvoice_issueInvoicePage_totalValue.checkValueContains = @amountGst
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");

                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INV-06_1@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay6);
                SIVPage SIVPG1 = new SIVPage(WebDriver);

                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber = SIVPG1.InvNumber().Text;
                string invoicenumber = invnumber.Substring(invnumber.IndexOf("Invoice ")).Replace("Invoice ", "");
                
                
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+asivnodealunpaidp@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();

                SeleniumSetMethods.WaitOnPage(secdelay7);

                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                BillzyCashModal BillzyCashMlPg = new BillzyCashModal(WebDriver);
                PayNowPage PayNwPg = new PayNowPage(WebDriver);

                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay5);
               
                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.PayBTNNoDeal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PayNowPage paypg = new PayNowPage(WebDriver);
                paypg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                paypg.CardRow03().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string amount1 = paypg.Row01AmountPayable().GetAttribute("value");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(amount1.Contains("319.82"));
                paypg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.DoneBTN().Click();
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+asivnodealunpaidb@gmail.com");
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
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(amount3.Contains("$319.82"));
            }
            finally
            {
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
            }
        }

        [Test]
        public void InvoiceNoDeal02_ExcludigGST_NoSurcharge_Processing_Biller_Payer()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));

                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+asivnodealunpaidb@gmail.com");
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
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+asivnodealunpaidp");
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
                DateTime newDate = DateTime.Now.AddDays(60);
                string dtString3 = newDate.ToString("dd/MM/yyyy");
                String PaymentTerms = "60 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.DueDate().Click();

                SeleniumSetMethods.WaitOnPage(secdelay3);
                //IssueInvoicePg.DueDate().Clear();
                //IssueInvoicePg.DueDate().SendKeys(dtString3);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV-06_2@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");

                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");

                SeleniumSetMethods.WaitOnPage(secdelay2);


                //issueInvoice_issueInvoicePage_totalValue.checkValueContains = @amountGst
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");

                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INV-06_2@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay6);
                SIVPage SIVPG1 = new SIVPage(WebDriver);

                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber = SIVPG1.InvNumber().Text;
                string invoicenumber = invnumber.Substring(invnumber.IndexOf("Invoice ")).Replace("Invoice ", "");


                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+asivnodealunpaidp@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();

                SeleniumSetMethods.WaitOnPage(secdelay7);

                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                BillzyCashModal BillzyCashMlPg = new BillzyCashModal(WebDriver);
                PayNowPage PayNwPg = new PayNowPage(WebDriver);

                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay5);

                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.PayBTNNoDeal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PayNowPage paypg = new PayNowPage(WebDriver);
                paypg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                paypg.CardRow02().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string amount1 = paypg.Row01AmountPayable().GetAttribute("value");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(amount1.Contains("319.82"));
                paypg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.DoneBTN().Click();
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+asivnodealunpaidb@gmail.com");
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
                Assert.IsTrue(dealmsg.Contains("PROCESSING"));
            }
            finally
            {
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
            }
        }

        [Test]
        public void InvoiceNoDeal03_IncludingGST_Surcharge_Paid_Biller_Payer()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));

                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+anodealgstb01@gmail.com");
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
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+anodealgstp01");
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
                DateTime newDate = DateTime.Now.AddDays(60);
                string dtString3 = newDate.ToString("dd/MM/yyyy");
                String PaymentTerms = "60 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.DueDate().Click();

                SeleniumSetMethods.WaitOnPage(secdelay3);
                //IssueInvoicePg.DueDate().Clear();
                //IssueInvoicePg.DueDate().SendKeys(dtString3);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV-06_3@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");

                IssueInvoicePg.LineItemAmount().SendKeys("1204.09");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                IssueInvoicePg.SurchargeCheckbox().Click();

                SeleniumSetMethods.WaitOnPage(secdelay2);


                //issueInvoice_issueInvoicePage_totalValue.checkValueContains = @amountGst
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");

                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INV-06_3@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay6);
                SIVPage SIVPG1 = new SIVPage(WebDriver);

                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber = SIVPG1.InvNumber().Text;
                string invoicenumber = invnumber.Substring(invnumber.IndexOf("Invoice ")).Replace("Invoice ", "");


                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+anodealgstp01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();

                SeleniumSetMethods.WaitOnPage(secdelay7);

                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                BillzyCashModal BillzyCashMlPg = new BillzyCashModal(WebDriver);
                PayNowPage PayNwPg = new PayNowPage(WebDriver);

                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay5);

                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.PayBTNNoDeal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                PayNowPage paypg = new PayNowPage(WebDriver);
                paypg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                paypg.CardRow03().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string amount1 = paypg.Row01AmountPayable().GetAttribute("value");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(amount1.Contains("1346.62"));
                paypg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.DoneBTN().Click();
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+anodealgstb01@gmail.com");
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
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(amount3.Contains("$1,346.62"));
            }
            finally
            {
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
            }
        }

        [Test]
        public void InvoiceNoDeal04_IncludingGST_Surcharge_Processing_Biller_Payer()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));

                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+anodealgstb01@gmail.com");
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
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+anodealgstp01");
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
                DateTime newDate = DateTime.Now.AddDays(60);
                string dtString3 = newDate.ToString("dd/MM/yyyy");
                String PaymentTerms = "60 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.DueDate().Click();

                SeleniumSetMethods.WaitOnPage(secdelay3);
                //IssueInvoicePg.DueDate().Clear();
                //IssueInvoicePg.DueDate().SendKeys(dtString3);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV-06_4@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");

                IssueInvoicePg.LineItemAmount().SendKeys("1204.09");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                IssueInvoicePg.SurchargeCheckbox().Click();

                SeleniumSetMethods.WaitOnPage(secdelay2);


                //issueInvoice_issueInvoicePage_totalValue.checkValueContains = @amountGst
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");

                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INV-06_4@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay6);
                SIVPage SIVPG1 = new SIVPage(WebDriver);

                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber = SIVPG1.InvNumber().Text;
                string invoicenumber = invnumber.Substring(invnumber.IndexOf("Invoice ")).Replace("Invoice ", "");


                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+anodealgstp01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();

                SeleniumSetMethods.WaitOnPage(secdelay7);

                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                BillzyCashModal BillzyCashMlPg = new BillzyCashModal(WebDriver);
                PayNowPage PayNwPg = new PayNowPage(WebDriver);

                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay5);

                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.PayBTNNoDeal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PayNowPage paypg = new PayNowPage(WebDriver);
                paypg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                paypg.CardRow02().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string amount1 = paypg.Row01AmountPayable().GetAttribute("value");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(amount1.Contains("1324.50"));
                paypg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.DoneBTN().Click();
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+anodealgstb01@gmail.com");
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
                Assert.IsTrue(dealmsg.Contains("PROCESSING"));
            }
            finally
            {
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
            }
        }

        [Test]
        public void InvoiceNoDeal05_IncludingGST_NoSurcharge_Paid_Biller_Payer()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));

                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+anodealgstb01@gmail.com");
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
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+anodealgstp01");
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
                DateTime newDate = DateTime.Now.AddDays(60);
                string dtString3 = newDate.ToString("dd/MM/yyyy");
                String PaymentTerms = "60 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.DueDate().Click();

                SeleniumSetMethods.WaitOnPage(secdelay3);
                //IssueInvoicePg.DueDate().Clear();
                //IssueInvoicePg.DueDate().SendKeys(dtString3);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV-06_5@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");

                IssueInvoicePg.LineItemAmount().SendKeys("1204.09");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                

                SeleniumSetMethods.WaitOnPage(secdelay2);


                //issueInvoice_issueInvoicePage_totalValue.checkValueContains = @amountGst
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");

                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INV-06_5@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay6);
                SIVPage SIVPG1 = new SIVPage(WebDriver);

                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber = SIVPG1.InvNumber().Text;
                string invoicenumber = invnumber.Substring(invnumber.IndexOf("Invoice ")).Replace("Invoice ", "");


                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+anodealgstp01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();

                SeleniumSetMethods.WaitOnPage(secdelay7);

                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                BillzyCashModal BillzyCashMlPg = new BillzyCashModal(WebDriver);
                PayNowPage PayNwPg = new PayNowPage(WebDriver);

                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay5);

                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.PayBTNNoDeal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PayNowPage paypg = new PayNowPage(WebDriver);
                paypg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                paypg.CardRow03().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string amount1 = paypg.Row01AmountPayable().GetAttribute("value");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(amount1.Contains("1324.50"));
                paypg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.DoneBTN().Click();
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+anodealgstb01@gmail.com");
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
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(amount3.Contains("$1,324.50"));
            }
            finally
            {
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
            }
        }

        [Test]
        public void InvoiceNoDeal06_IncludingGST_NoSurcharge_Processing_Biller_Payer()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));

                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+anodealgstb01@gmail.com");
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
                SeleniumSetMethods.WaitOnPage(secdelay4);
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+anodealgstp01");
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
                DateTime newDate = DateTime.Now.AddDays(60);
                string dtString3 = newDate.ToString("dd/MM/yyyy");
                String PaymentTerms = "60 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.DueDate().Click();

                SeleniumSetMethods.WaitOnPage(secdelay3);
                //IssueInvoicePg.DueDate().Clear();
                //IssueInvoicePg.DueDate().SendKeys(dtString3);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV-06_6@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");

                IssueInvoicePg.LineItemAmount().SendKeys("1204.09");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                //IssueInvoicePg.SurchargeCheckbox().Click();

                SeleniumSetMethods.WaitOnPage(secdelay2);


                //issueInvoice_issueInvoicePage_totalValue.checkValueContains = @amountGst
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");

                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INV-06_6@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay6);
                SIVPage SIVPG1 = new SIVPage(WebDriver);

                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber = SIVPG1.InvNumber().Text;
                string invoicenumber = invnumber.Substring(invnumber.IndexOf("Invoice ")).Replace("Invoice ", "");


                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+anodealgstp01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();

                SeleniumSetMethods.WaitOnPage(secdelay7);

                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                BillzyCashModal BillzyCashMlPg = new BillzyCashModal(WebDriver);
                PayNowPage PayNwPg = new PayNowPage(WebDriver);

                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay5);

                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.PayBTNNoDeal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PayNowPage paypg = new PayNowPage(WebDriver);
                paypg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                paypg.CardRow02().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string amount1 = paypg.Row01AmountPayable().GetAttribute("value");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(amount1.Contains("1324.50"));
                paypg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.DoneBTN().Click();
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+anodealgstb01@gmail.com");
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
                Assert.IsTrue(dealmsg.Contains("PROCESSING"));
            }
            finally
            {
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
            }
        }

        [Test]
        public void InvoiceNoDeal07_IncludingGST_NoSurcharge_Unpaid_Biller_Payer()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));

                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+anodealgstb01@gmail.com");
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
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+anodealgstp01");
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
                DateTime newDate = DateTime.Now.AddDays(60);
                string dtString3 = newDate.ToString("dd/MM/yyyy");
                String PaymentTerms = "60 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.DueDate().Click();

                SeleniumSetMethods.WaitOnPage(secdelay3);
                //IssueInvoicePg.DueDate().Clear();
                //IssueInvoicePg.DueDate().SendKeys(dtString3);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV-06_7@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");

                IssueInvoicePg.LineItemAmount().SendKeys("1204.09");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                //IssueInvoicePg.SurchargeCheckbox().Click();

                SeleniumSetMethods.WaitOnPage(secdelay2);


                //issueInvoice_issueInvoicePage_totalValue.checkValueContains = @amountGst
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");

                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INV-06_7@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay6);
                SIVPage SIVPG1 = new SIVPage(WebDriver);

                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber = SIVPG1.InvNumber().Text;
                string invoicenumber = invnumber.Substring(invnumber.IndexOf("Invoice ")).Replace("Invoice ", "");
                String status1 = SIVPG1.InvoiceStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(status1.Contains("UNPAID"));
                SeleniumSetMethods.WaitOnPage(secdelay2);

                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+anodealgstp01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();

                SeleniumSetMethods.WaitOnPage(secdelay7);

                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                BillzyCashModal BillzyCashMlPg = new BillzyCashModal(WebDriver);
                PayNowPage PayNwPg = new PayNowPage(WebDriver);

                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay5);

                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                
                String status2 = SIVPG1.InvoiceStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(status2.Contains("UNPAID"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                
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
