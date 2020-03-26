using System;
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
using OpenQA.Selenium.Interactions;

namespace BillzyAutomationTestSuite.Scripts
{
    [TestFixture]
    [Parallelizable]
    class RegSuite_InvoiceVerifyPostFilter_ScrollAction_FCDD : Tests
    {

        [Test]
        public void ManualTest09_InvoiceVerification()
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
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+billerverify@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);

                //Issue Invoice Normal - Int	Surcharge

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("manualtestdemob+payerverify");
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
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("NORVER@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("200");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Console.WriteLine("InvoiceCreated");
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPage SendPg = new SendPage(WebDriver);
                SendPg.SentOutstandingBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("NORVER@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SIVPage SIVPG1 = new SIVPage(WebDriver);
                string invnumber1 = SIVPG1.InvNumber().Text;
                string invoicenumber1 = invnumber1.Substring(invnumber1.IndexOf("Invoice ")).Replace("Invoice ", "");

                //Issue Invoice -Deal - Int	Surcharge	

                SeleniumSetMethods.WaitOnPage(secdelay4);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("manualtestdemob+payerverify");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("DEALVER@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("60");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.NewTotal().SendKeys("60");
                DateTime newDate = DateTime.Now.AddDays(15);
                string dtString3 = newDate.ToString("dd/MM/yyyy");
                IssueInvoicePg.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
                IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");
                IssueInvoicePg.SurchargeCheckbox().Click();
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Console.WriteLine("InvoiceCreated");
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SentOutstandingBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("DEALVER@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber2 = SIVPG1.InvNumber().Text;
                string invoicenumber2 = invnumber2.Substring(invnumber2.IndexOf("Invoice ")).Replace("Invoice ", "");

                //Issue Invoice -Normal - Ext	Surcharge	

                SeleniumSetMethods.WaitOnPage(secdelay4);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("External1");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("EXTVER@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("200");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Console.WriteLine("InvoiceCreated");
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SentOutstandingBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("EXTVER@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber4 = SIVPG1.InvNumber().Text;
                string invoicenumber4 = invnumber4.Substring(invnumber4.IndexOf("Invoice ")).Replace("Invoice ", "");

                //Issue Invoice Cash - Int	Surcharge	

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("manualtestdemob+payerverify");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("CASHVERREQ@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("200");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Console.WriteLine("InvoiceCreated");
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SentOutstandingBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("CASHVERREQ@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber3 = SIVPG1.InvNumber().Text;
                string invoicenumber3 = invnumber3.Substring(invnumber3.IndexOf("Invoice ")).Replace("Invoice ", "");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                addrecord(invoicenumber3, "approved", "FactorFox.csv");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+payerverify@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                //Cash Requested invoices is eligible to verify the invoice

                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                ReceivedPage recpg = new ReceivedPage(WebDriver);
                recpg.SearchInvoiceReceived().SendKeys(invoicenumber3);
                SeleniumSetMethods.WaitOnPage(secdelay10);
                recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                bool verifybtn2 = SIVPG1.PayerVerifyBTN().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(verifybtn2 == true);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("billzydemo+financial-controller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                string cashapprove1 = HomePg.FFApproved().Text;
                bool approvebtn1 = HomePg.Approvebtn().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(cashapprove1.Contains("Pending Approval") && approvebtn1 == true);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                HomePg.Uploadfactorfox().SendKeys(@"C:\Users\Selenium\Desktop\SeleniumRegressionSuite_Bamboo\bin\Debug\netcoreapp3.1\FactorFox.csv");

                SeleniumSetMethods.WaitOnPage(secdelay7);
                try
                {
                    WebDriver.Navigate().GoToUrl("https://demo.billzy.com/funds");
                }
                catch (Exception e)
                {
                    if (e.ToString().Contains("org.openqa.selenium.UnhandledAlertException"))
                    {
                        IAlert alert = WebDriver.SwitchTo().Alert();
                        alert.Accept();
                    }
                }
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement ApproveButton = WebDriver.FindElement(By.XPath("//td[text()=\"" + invoicenumber3 + "\"]/../td/button[text()=\"approve\"]"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ApproveButton.Click();
                //HomePg.Approvebtn().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                HomePg.Approvebtn().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                HomePg.Cashratesubmit().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                try
                {
                    HomePg.FCLogout().Click();
                }
                catch (Exception e)
                {
                    if (e.ToString().Contains("org.openqa.selenium.UnhandledAlertException"))
                    {
                        IAlert alert = WebDriver.SwitchTo().Alert();
                        alert.Accept();
                    }
                }
                HomePg.FCLogout().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+billerverify@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SentOutstandingBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys(invoicenumber3);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool CashReqIcon1 = SendPg.CashApprovedIcon().Displayed;
                String CashReqTxt1 = SendPg.SearchedInvoiceCashStatus().Text;
                Assert.IsTrue(CashReqIcon1 == true && CashReqTxt1.Contains("Cash approved"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string sivcashstatus1 = SIVPG1.SIVCashRequestedStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(sivcashstatus1.Contains("APPROVED"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+payerverify@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);

                //Cash Approved invoices is eligible to verify the invoice

                recpg.SearchInvoiceReceived().SendKeys(invoicenumber3);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                bool verifybtn = SIVPG1.PayerVerifyBTN().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(verifybtn == true);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                recpg.PAY().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                PayNowPage PNPg = new PayNowPage(WebDriver);
                PNPg.CcDropDown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PNPg.verifyBank1().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PNPg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PNPg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                recpg.ReceivedHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

                //Cash invoices with processing status is not eligible to verify the invoice

                recpg.SearchInvoiceReceived().SendKeys(invoicenumber3);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool verifybtn1 = SIVPG1.PayerVerifyBTN().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(verifybtn1 == false);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                recpg.SearchInvoiceReceived().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                recpg.SearchInvoiceReceived().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                //Cash invoices with paid status is not eligible to verify the invoice

                recpg.SearchInvoiceReceived().SendKeys("INV10308948");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool verifybtn3 = SIVPG1.PayerVerifyBTN().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(verifybtn3 == false);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                recpg.SearchInvoiceReceived().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                recpg.SearchInvoiceReceived().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                //Deleted invoices are not eligible to verify the invoice

                recpg.SearchInvoiceReceived().SendKeys("INV10308955");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool verifybtn4 = SIVPG1.PayerVerifyBTN().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(verifybtn4 == false);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                recpg.ToPayTab().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                recpg.SearchInvoiceReceived().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                recpg.SearchInvoiceReceived().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                //Cash Declined invoices are eligible to verify the invoice

                recpg.SearchInvoiceReceived().SendKeys("INV10309417");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool verifybtn5 = SIVPG1.PayerVerifyBTN().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(verifybtn5 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                recpg.SearchInvoiceReceived().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                recpg.SearchInvoiceReceived().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                //Invoices with deal are eligible to verify the invoice

                recpg.SearchInvoiceReceived().SendKeys(invoicenumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool verifybtn6 = SIVPG1.PayerVerifyBTN().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(verifybtn6 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                recpg.SearchInvoiceReceived().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                recpg.SearchInvoiceReceived().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                //Invoices without deal and cash are eligible to verify the invoice

                recpg.SearchInvoiceReceived().SendKeys(invoicenumber1);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                recpg.VerifyInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                bool verifybtn7 = SIVPG1.PayerVerifyBTN().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(verifybtn7 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.PayerVerifyBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                bool verifiedtxt1 = SIVPG1.VerifiedTextMsg().Displayed;
                string verifiedtxt11 = SIVPG1.VerifiedTextMsg().Text;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(verifiedtxt1 == true && verifiedtxt11.Contains("You verified this invoice on"));
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+billerverify@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                //Verifying the verify text is displayed in the invoices in the SIV page of biller view

                SendPg.SentOutstandingBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys(invoicenumber1);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));
                bool vertxt = bodyTag.Text.Contains("manualtestdemob+payerverify verified this invoice on");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(vertxt == true);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                //Inbox invoices are eligible for invoice verification

                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowpayer+raffyinbox01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                recpg.ToPayTab().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                recpg.SearchInvoiceReceived().SendKeys("INVVER001");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                bool verify = SIVPG1.PayerVerifyBTN().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(verify == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
            }
            finally
            {
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com");

            }

        }

        [Test]
        public void ManualTest10_PostInvoice()
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
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+billerverify@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);

                //Issue Invoice Normal - Int	Surcharge

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("manualtestdemob+payerverify");
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
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("NORVER@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("200");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Console.WriteLine("InvoiceCreated");
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPage SendPg = new SendPage(WebDriver);
                SendPg.SentOutstandingBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("NORVER@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SIVPage SIVPG1 = new SIVPage(WebDriver);
                string invnumber1 = SIVPG1.InvNumber().Text;
                string invoicenumber1 = invnumber1.Substring(invnumber1.IndexOf("Invoice ")).Replace("Invoice ", "");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+payerverify@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                ReceivedPage recpg = new ReceivedPage(WebDriver);

                //Normal invoice is eligible to perform post invoice

                recpg.SearchInvoiceReceived().SendKeys(invoicenumber1);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string viwedsts = recpg.StatusNotViewedRow01().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(viwedsts.Contains("not viewed"));
                recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                recpg.PostInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                recpg.PostInvoicePostBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string post2 = recpg.StatuspostedRow01().GetAttribute("data-title");
                Assert.IsTrue(post2.Contains("posted"));
                recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string postmsg = SIVPG1.postmessagepayer().Text;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(postmsg.Contains("You posted this invoice on "));
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                recpg.SearchInvoiceReceived().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                recpg.SearchInvoiceReceived().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                //Cash Declined invoice is eligible to perform post invoice

                recpg.SearchInvoiceReceived().SendKeys("INV10309235");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                recpg.ActionsMenu().Click();
                bool postbtn = recpg.PostInvoice().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(postbtn == true);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                recpg.SearchInvoiceReceived().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                recpg.SearchInvoiceReceived().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                //OfferSent invoice is eligible to perform post invoice

                recpg.SearchInvoiceReceived().SendKeys("OfferSent");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                recpg.ActionsMenu().Click();
                bool postbtn2 = recpg.PostInvoice().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(postbtn2 == true);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                recpg.SearchInvoiceReceived().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                recpg.SearchInvoiceReceived().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                //OfferReceived invoice is eligible to perform post invoice

                recpg.SearchInvoiceReceived().SendKeys("OfferReceived");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                recpg.ActionsMenu().Click();
                bool postbtn3 = recpg.PostInvoice().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(postbtn3 == true);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                recpg.SearchInvoiceReceived().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                recpg.SearchInvoiceReceived().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                //OfferAccept invoice is eligible to perform post invoice

                recpg.SearchInvoiceReceived().SendKeys("OfferAccept");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                recpg.ActionsMenu().Click();
                bool postbtn4 = recpg.PostInvoice().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(postbtn4 == true);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                recpg.SearchInvoiceReceived().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                recpg.SearchInvoiceReceived().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                //OfferDecline invoice is eligible to perform post invoice

                recpg.SearchInvoiceReceived().SendKeys("OfferDecline");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                recpg.ActionsMenu().Click();
                bool postbtn5 = recpg.PostInvoice().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(postbtn5 == true);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+billerverify@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                //Verifyinh the post message is hidden in the biller view

                SendPg.SentOutstandingBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys(invoicenumber1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string viewed = SendPg.StatusViewedRow01().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(viewed.Contains("viewed"));
                SendPg.BillzyRefResult().Click();
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));
                bool siv2 = bodyTag.Text.Contains("posted");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(siv2 == false);
            }
            finally
            {
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com");

            }
        }


        [Test]
        public void ManualTest11_FinancialController_DirectDebit()
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
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+billerverify@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);

                //Issue Invoice Normal - Int	Surcharge

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("manualtestdemob+payerverify");
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
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("FCDD@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("200");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Console.WriteLine("InvoiceCreated");
                SeleniumSetMethods.WaitOnPage(secdelay5);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPage SendPg = new SendPage(WebDriver);

                SendPg.SearchInvoiceSent().SendKeys("FCDD@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SIVPage SIVPG1 = new SIVPage(WebDriver);
                string invnumber1 = SIVPG1.InvNumber().Text;
                string invoicenumber1 = invnumber1.Substring(invnumber1.IndexOf("Invoice ")).Replace("Invoice ", "");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("billzydemo+financial-controller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                HomePg.FCAccountName().SendKeys("Valid");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.FCBSB().SendKeys("032999");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.FCAccountNumber().SendKeys("999994");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.FCAmount().SendKeys("200");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.FCDDInvNum().SendKeys("INV10312493");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.FCDDComment().SendKeys("Direct Debit Processed by Billzy");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.FCDDSubmit().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                IAlert alert = WebDriver.SwitchTo().Alert();
                string alertmsg = WebDriver.SwitchTo().Alert().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(alertmsg.Contains("Error: Invoice does not exist"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                alert.Accept();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.FCDDInvNum().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.FCDDInvNum().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.FCDDInvNum().SendKeys(invoicenumber1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.FCDDSubmit().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                string alertmsg2 = WebDriver.SwitchTo().Alert().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(alertmsg2.Contains("Direct debit successfully submitted"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                alert.Accept();
                SeleniumSetMethods.WaitOnPage(secdelay3);

                IWebElement bodytag1 = WebDriver.FindElement(By.TagName("body"));
                bool PendingCRTxt1 = bodytag1.Text.Contains("There is a total of ");
                bool PendingCRTxt2 = bodytag1.Text.Contains("pending cash requests with a total invoice value of $");
                bool PendingCRTxt3 = bodytag1.Text.Contains(". Around $");
                bool PendingCRTxt4 = bodytag1.Text.Contains(" is needed to fund 80%");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(PendingCRTxt1 == true && PendingCRTxt2 == true && PendingCRTxt3 == true && PendingCRTxt4 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.FCLogout().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                
               
            }
            finally
            {
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com");

            }
        }

        [Test]
        public void ManualTest12_FilterValidation_SearchValidation()
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
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+billerverify@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                //Billzy Deal Filtercheckbox
                SendPage sendpg = new SendPage(WebDriver);
                sendpg.BillzyDealFilterCheckBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));
                bool cashinv = bodyTag.Text.Contains("Cash");
                bool dealinv = bodyTag.Text.Contains("Offer");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(cashinv == false && dealinv == true);

                //Billzy Cash Filtercheckbox
                sendpg.BillzyDealFilterUncheckBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                sendpg.BillzyCashFilterCheckBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IWebElement bodyTag1 = WebDriver.FindElement(By.TagName("body"));
                bool cashinv1 = bodyTag1.Text.Contains("Cash");
                bool dealinv1 = bodyTag1.Text.Contains("Offer");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(cashinv1 == true && dealinv1 == false);
                sendpg.BillzyCashFilterUncheckBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                //DueDate Search
                sendpg.FromDate().SendKeys("01/11/2019");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                sendpg.ToDate().SendKeys("29/11/2019");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IWebElement bodyTag2 = WebDriver.FindElement(By.TagName("body"));
                string test = bodyTag2.Text;
                bool Nov = bodyTag2.Text.Contains("Nov");
                //bool Dec = bodyTag2.Text.Contains("Dec 19");
                bool Nov29 = bodyTag2.Text.Contains("29 Nov 19");
                SeleniumSetMethods.WaitOnPage(secdelay7);
                Console.WriteLine(test);
                Assert.IsTrue(Nov == true &&  Nov29 == true);
                SeleniumSetMethods.WaitOnPage(secdelay6);
                //PDF selection Validation
                //enter
                sendpg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                sendpg.FirstRowChecked().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                sendpg.SecondRowChecked().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                
                bool pdfsele = bodyTag2.Text.Contains("2 PDF's");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Assert.IsTrue(pdfsele == true);
                sendpg.ToDate().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                sendpg.ToDate().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                sendpg.ToDate().SendKeys("29/11/2019");
                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool pdfsele1 = bodyTag2.Text.Contains("2 PDF's");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Assert.IsTrue(pdfsele1 == false);
                //enter
                sendpg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                sendpg.FirstRowChecked().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                sendpg.SecondRowChecked().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool pdfsele2 = bodyTag2.Text.Contains("2 PDF's");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Assert.IsTrue(pdfsele2 == true);

                //Clearbutton Validation
                sendpg.ClearBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                bool pdfsele4 = bodyTag2.Text.Contains("2 PDF's");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Assert.IsTrue(pdfsele4 == false);

            }
            finally
            {
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com");

            }
        }

         [Test]
        public void ManualTest13_ScrollAction_FieldValidation()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {
                //Validating the received and sent tab list views by scroll down and scroll up actions to verify the invoice selection is unchanged 
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+gstbiller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                SendPage sendpg = new SendPage(WebDriver);
                
                
                //Sent Tab Scroll Action Validation
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                sendpg.PDFSelection5().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                var PDFButtonBottom = WebDriver.FindElement(By.XPath("//div[@class = 'sent-details'] //div[contains(@class, 'pdf-download-area-bottom')] //button[@class = 'btn download-btn ladda-button']"));
                //var PDFSelection51 = WebDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[1]/div[2]/div[11]/div[51]/div[1]/div"));
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFButtonBottom);
                SeleniumSetMethods.WaitOnPage(secdelay2);
               
                sendpg.PDFSelection63().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFButtonBottom);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                sendpg.PDFSelection129().Click();
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFButtonBottom);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFButtonBottom);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFButtonBottom);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFButtonBottom);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFButtonBottom);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFButtonBottom);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFButtonBottom);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFButtonBottom);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFButtonBottom);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFButtonBottom);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFButtonBottom);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFButtonBottom);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFButtonBottom);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFButtonBottom);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFButtonBottom);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFButtonBottom);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string Totaliv = sendpg.Invoiceloaded().Text;
                string pdftext = sendpg.PdfButtonButton().Text;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(pdftext.Contains("3 PDF's"));
                string Totaliv1 = Totaliv.Substring(Totaliv.IndexOf("Showing ")).Replace("Showing ", "");
                string Totaliv2= Totaliv1.Substring(Totaliv1.IndexOf("")).Replace(" of ", "");
                string Totaliv3 = Totaliv2.Substring(Totaliv2.IndexOf("")).Replace(" invoices.", "");
                string Totaliv4 = Totaliv3.Substring(3);
                IWebElement PDFSelectionlastINV = WebDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[1]/div[2]/div[11]/div["+ Totaliv4 + "]/div[1]/div"));
                PDFSelectionlastINV.Click();
                string pdftext1 = sendpg.PdfButtonButton().Text;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(pdftext1.Contains("4 PDF's"));
                IWebElement PDFtopButoon1 = WebDriver.FindElement(By.Id("sent-download-btn"));
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFtopButoon1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFtopButoon1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFtopButoon1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFtopButoon1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFtopButoon1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFtopButoon1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string PDFTopsentText = sendpg.PdfButtonTop().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(PDFTopsentText.Contains("4 PDF's"));
                SeleniumSetMethods.WaitOnPage(secdelay1);
                sendpg.PDFSelection5().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string PDFTopsentText1 = sendpg.PdfButtonTop().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(PDFTopsentText1.Contains("3 PDF's"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string PDFbotsenttext = sendpg.PdfButtonButton().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(PDFbotsenttext.Contains("3 PDF's"));

                //Sent - History Tab Scroll Action Validation
                IWebElement cashcheckbox = WebDriver.FindElement(By.XPath("//*[@src='/assets/billzy-cash-filter-off.svg' and @id='sent-cash-filter-off-lg']"));
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", cashcheckbox);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", cashcheckbox);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", cashcheckbox);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                sendpg.SentHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                sendpg.PDFSentHistSelection5().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                var PDFButtonBottom1 = WebDriver.FindElement(By.XPath("//div[@class = 'sent-details'] //div[contains(@class, 'pdf-download-area-bottom')] //button[@class = 'btn download-btn ladda-button']"));
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFButtonBottom1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFButtonBottom1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFButtonBottom1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFButtonBottom1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFButtonBottom1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFButtonBottom1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFButtonBottom1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFButtonBottom1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFButtonBottom1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string TotalHISTiv = sendpg.Invoiceloaded().Text;
                string pdfHISTtext = sendpg.PdfButtonButton().Text;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(pdftext.Contains("3 PDF's"));
                string TotalHISTiv1 = TotalHISTiv.Substring(TotalHISTiv.IndexOf("Showing ")).Replace("Showing ", "");
                string TotalHISTiv2 = TotalHISTiv1.Substring(TotalHISTiv1.IndexOf("")).Replace(" of ", "");
                string TotalHISTiv3 = TotalHISTiv2.Substring(TotalHISTiv2.IndexOf("")).Replace(" invoices.", "");
                string TotalHISTiv4 = TotalHISTiv3.Substring(3);
                IWebElement PDFSelectionlastHISTINV = WebDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[1]/div[2]/div[11]/div[" + TotalHISTiv4 + "]/div[1]/div"));
                
                PDFSelectionlastHISTINV.Click();
                string pdfHISTtext1 = sendpg.PdfButtonButton().Text;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(pdfHISTtext1.Contains("2 PDF's"));
                IWebElement PDFtopButoon = WebDriver.FindElement(By.Id("sent-download-btn"));
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFtopButoon);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFtopButoon);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFtopButoon);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFtopButoon);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFtopButoon);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFtopButoon);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFtopButoon);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string PDFTopText = sendpg.PdfButtonTop().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(PDFTopText.Contains("2 PDF's"));
                SeleniumSetMethods.WaitOnPage(secdelay1);
                sendpg.PDFSentHistSelection5().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string PDFTopText1 = sendpg.PdfButtonTop().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(PDFTopText1.Contains("1 PDF"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string PDFbottext = sendpg.PdfButtonButton().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(PDFbottext.Contains("1 PDF"));
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                

                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+gstpayer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);



                //Received Tab Scroll Action Validation
                ReceivedPage recpg = new ReceivedPage(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                recpg.PDFSelection5().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                var PDFrecButtonBottom = WebDriver.FindElement(By.XPath("//div[@class = 'received-details'] //div[contains(@class, 'unpaid-col col-md-5 col-sm-7 no-right-padding hidden-xs pull-right right-align')]//div[contains(@class, 'pdf-download-area-bottom')] //button[@class = 'btn download-btn ladda-button']"));
                
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFrecButtonBottom);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                recpg.PDFSelection51().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFrecButtonBottom);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                recpg.PDFSelection79().Click();
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFrecButtonBottom);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFrecButtonBottom);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFrecButtonBottom);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFrecButtonBottom);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFrecButtonBottom);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFrecButtonBottom);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFrecButtonBottom);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string Totalrecinv = recpg.Invoiceloaded().Text;
                string pdftextrec = PDFrecButtonBottom.Text;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(pdftextrec.Contains("3 PDF's"));
                string Totalrecinv1 = Totalrecinv.Substring(Totalrecinv.IndexOf("Showing ")).Replace("Showing ", "");
                string Totalrecinv2 = Totalrecinv1.Substring(Totalrecinv1.IndexOf("")).Replace(" of ", "");
                string Totalrecinv3 = Totalrecinv2.Substring(Totalrecinv2.IndexOf("")).Replace(" invoices.", "");
                string Totalrecinv4 = Totalrecinv3.Substring(3);
                IWebElement PDFSelectionlastINVrec = WebDriver.FindElement(By.XPath("//*[@id=\"row-unpaidRow-" + Totalrecinv4 + "\"]/div[1]/div[1]"));
                
                PDFSelectionlastINVrec.Click();
                string pdftextrec1 = PDFrecButtonBottom.Text;
                string payamount = recpg.PayBTNBottom().Text;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(pdftextrec1.Contains("4 PDF's") && payamount.Contains("PAY $"));
                IWebElement PDFtopButoonrec = WebDriver.FindElement(By.XPath("//*[@id=\"receivedUnpaid-download-btn\"]"));
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFtopButoonrec);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFtopButoonrec);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFtopButoonrec);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFtopButoonrec);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFtopButoonrec);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFtopButoonrec);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFtopButoonrec);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFtopButoonrec);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFtopButoonrec);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFtopButoonrec);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string PDFToprecText = PDFtopButoonrec.Text;
                string payamounttop = recpg.PayBTNTop().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(PDFToprecText.Contains("4 PDF's") && payamounttop.Contains("PAY $"));
                SeleniumSetMethods.WaitOnPage(secdelay1);
                recpg.PDFSelection5().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string PDFToprecText1 = recpg.PdfButtonTop().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(PDFToprecText1.Contains("3 PDF's"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string PDFbottomrecText = recpg.PdfButtonButton().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(PDFbottomrecText.Contains("3 PDF's"));

               
                //int hist5row = Totalrecinv4.in() + 5;
                //Received - History Tab Scroll Action Validation
                IWebElement inboxcheckbox = WebDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[4]/div[2]/h2"));
               
                //*[@id="row-unpaidRow-85"]/div[1]/div[1]
                SeleniumSetMethods.WaitOnPage(secdelay2);
                
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", inboxcheckbox);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", inboxcheckbox);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", inboxcheckbox);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", inboxcheckbox);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                recpg.ReceivedHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                int hist5row = Convert.ToInt32(Totalrecinv4) + 5;
                IWebElement hist5row05 = WebDriver.FindElement(By.XPath("//*[@id=\"row-unpaidRow-"+hist5row+"\"]/div[1]/div[1]"));
                hist5row05.Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement PDFBottomRecHist = WebDriver.FindElement(By.XPath("//div[@class = 'received-details'] //div[contains(@class, 'pdf-download-area-bottom')] //button[@id = 'download-btn']"));
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFBottomRecHist);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFBottomRecHist);
                SeleniumSetMethods.WaitOnPage(secdelay2);

                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFBottomRecHist);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", PDFBottomRecHist);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string TotalHISTivrec = recpg.Invoiceloaded().Text;
                string pdfHISTtextrec = PDFBottomRecHist.Text;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(pdfHISTtextrec.Contains("1 PDF"));
                string TotalHISTivrec1 = TotalHISTivrec.Substring(TotalHISTivrec.IndexOf("Showing ")).Replace("Showing ", "");
                string TotalHISTivrec2 = TotalHISTivrec1.Substring(TotalHISTivrec1.IndexOf("")).Replace(" of ", "");
                string TotalHISTivrec3 = TotalHISTivrec2.Substring(TotalHISTivrec2.IndexOf("")).Replace(" invoices.", "");
                string TotalHISTivrec4 = TotalHISTivrec3.Substring(3);
                int hist5rowrechist = Convert.ToInt32(TotalHISTivrec4) + Convert.ToInt32(Totalrecinv4);
                IWebElement PDFSelectionlastrecHISTINV = WebDriver.FindElement(By.XPath("//*[@id=\"row-unpaidRow-"+hist5rowrechist+"\"]/div[1]/div[1]"));
                
                PDFSelectionlastrecHISTINV.Click();
                string pdfHISTtext11 = PDFBottomRecHist.Text;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(pdfHISTtext11.Contains("2 PDF's"));
                //IWebElement PDFtopButoon = WebDriver.FindElement(By.Id("sent-download-btn"));
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", inboxcheckbox);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", inboxcheckbox);
                SeleniumSetMethods.WaitOnPage(secdelay2);

                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", inboxcheckbox);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", inboxcheckbox);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement TopPDF = WebDriver.FindElement(By.XPath("//*[@id=\"receivedPaid-download-btn\"]/span[2]"));

                string PDFTopText12 = TopPDF.Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(PDFTopText12.Contains("2 PDF's"));
                SeleniumSetMethods.WaitOnPage(secdelay1);
                hist5row05.Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string PDFTopText13 = TopPDF.Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(PDFTopText13.Contains("1 PDF"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string PDFbottext11 = TopPDF.Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(PDFbottext11.Contains("1 PDF"));
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);


            }
            finally
            {
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com");

            }

        }

        [Test]
        public void ManualTest14_ABNValidation_AddEditCustomerPg_IssueInvPg()
        {
            HomePage HomePg = new HomePage(WebDriver);
            AddCustomerPage AddCustomerPg = new AddCustomerPage(WebDriver);
            try
            {

                DateTime dt2 = new DateTime();
                Random rand = new Random();
                string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber2 = rand.Next();
                //Validating the received and sent tab list views by scroll down and scroll up actions to verify the invoice selection is unchanged 
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                LoginPage loginPage = new LoginPage(WebDriver);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+gstbiller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                SendPage sendpg = new SendPage(WebDriver);
                HomePg.Profile().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                //Settings page
                HomePg.Settings().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SettingsPage settingspg = new SettingsPage(WebDriver);
                settingspg.BillzyABN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                settingspg.BillzyABN().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //less than 11 digit
                settingspg.BillzyABN().SendKeys("1234567890");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                settingspg.UpdateBTN().Click();
                IWebElement bodyTag0 = WebDriver.FindElement(By.TagName("body"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool updatemsg1 = bodyTag0.Text.Contains("Your billzy details have been updated.");
                bool errormsg1 = bodyTag0.Text.Contains("Invalid ABN length");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(updatemsg1 == false && errormsg1 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //more than 11 digit
                settingspg.BillzyABN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                settingspg.BillzyABN().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                settingspg.BillzyABN().SendKeys("1234567890123");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                settingspg.UpdateBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool updatemsg2 = bodyTag0.Text.Contains("Your billzy details have been updated.");
                bool errormsg2 = bodyTag0.Text.Contains("Invalid ABN length");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(updatemsg2 == false && errormsg2 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                // letters
                settingspg.BillzyABN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                settingspg.BillzyABN().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                settingspg.BillzyABN().SendKeys("dsfsdfsdfsdfsdf");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                settingspg.UpdateBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool updatemsg3 = bodyTag0.Text.Contains("Your billzy details have been updated.");
                bool errormsg3 = bodyTag0.Text.Contains("The value entered was not a valid 11 digit ABN (numbers and spaces only).");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(updatemsg3 == false && errormsg3 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //digits and letters
                settingspg.BillzyABN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                settingspg.BillzyABN().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                settingspg.BillzyABN().SendKeys("122542bhdgchdh");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                settingspg.UpdateBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool updatemsg4 = bodyTag0.Text.Contains("Your billzy details have been updated.");
                bool errormsg4 = bodyTag0.Text.Contains("The value entered was not a valid 11 digit ABN (numbers and spaces only).");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(updatemsg4 == false && errormsg4 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //digits and special characters
                
                settingspg.BillzyABN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                settingspg.BillzyABN().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                settingspg.BillzyABN().SendKeys("!@##xfcbgvx1344");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                settingspg.UpdateBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool updatemsg5 = bodyTag0.Text.Contains("Your billzy details have been updated.");
                bool errormsg5 = bodyTag0.Text.Contains("The value entered was not a valid 11 digit ABN (numbers and spaces only).");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(updatemsg5 == false && errormsg5 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //only spaces
                settingspg.BillzyABN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                settingspg.BillzyABN().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                settingspg.BillzyABN().SendKeys("      ");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                settingspg.UpdateBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool updatemsg6 = bodyTag0.Text.Contains("Your billzy details have been updated.");
                bool errormsg6 = bodyTag0.Text.Contains("Invalid ABN length");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(updatemsg6 == false && errormsg6 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                // without abn
                settingspg.BillzyABN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                settingspg.BillzyABN().Clear();
             
                SeleniumSetMethods.WaitOnPage(secdelay2);
                settingspg.UpdateBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool updatemsg7 = bodyTag0.Text.Contains("Your billzy details have been updated.");
                bool errormsg7 = bodyTag0.Text.Contains("Invalid ABN length");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(updatemsg7 == true && errormsg7 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //abn with spaces
                settingspg.BillzyABN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                settingspg.BillzyABN().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                settingspg.BillzyABN().SendKeys("123 456 789 11");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                settingspg.UpdateBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool updatemsg8 = bodyTag0.Text.Contains("Your billzy details have been updated.");
                bool errormsg8 = bodyTag0.Text.Contains("Invalid ABN length");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(updatemsg8 == true && errormsg8 == false);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //abn without spaces
                settingspg.BillzyABN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                settingspg.BillzyABN().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                settingspg.BillzyABN().SendKeys("12345678911");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                settingspg.UpdateBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool updatemsg9 = bodyTag0.Text.Contains("Your billzy details have been updated.");
                bool errormsg9 = bodyTag0.Text.Contains("Invalid ABN length");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(updatemsg9 == true && errormsg9 == false);

                //Add Customer Page
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.AddCustTab().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.AddCustBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.BusinessName().Click();
                AddCustomerPg.BusinessName().SendKeys("ABNTest01"+ randnumber2);
                AddCustomerPg.Abn().SendKeys("abhushuhuhq");
                AddCustomerPg.ContactName().SendKeys("ABNTest01" + randnumber2);
                AddCustomerPg.ContactEmail().SendKeys(randnumber2 +"@gmail.com");
                AddCustomerPg.ContactPhoneNumber().SendKeys("12345671447");
                AddCustomerPg.Street().SendKeys("10 Miller Street");
                AddCustomerPg.Suburb().SendKeys("Murarrie");
                AddCustomerPg.Postcode().SendKeys("4172");
                AddCustomerPg.AddBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool errmsg11 = bodyTag.Text.Contains("The value entered was not a valid 11 digit ABN (numbers and spaces only).");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(errmsg11 == true);
                
                AddCustomerPg.Abn().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.Abn().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.Abn().SendKeys("1111111111");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.AddBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                bool errmsg33 = bodyTag.Text.Contains("Invalid ABN length");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(errmsg33 == true);

                AddCustomerPg.Abn().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.Abn().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.Abn().SendKeys("123 123 123 123");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.AddBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                bool errmsg44 = bodyTag.Text.Contains("Invalid ABN length");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(errmsg44 == true);
                AddCustomerPg.Abn().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.Abn().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.Abn().SendKeys("            ");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.AddBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                bool errmsg55 = bodyTag.Text.Contains("Invalid ABN length");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(errmsg55 == true);
                AddCustomerPg.Abn().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.Abn().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.Abn().SendKeys("11 111 111 111*");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.AddBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                bool errmsg66 = bodyTag.Text.Contains("The value entered was not a valid 11 digit ABN (numbers and spaces only).");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(errmsg66 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.Abn().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.Abn().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.Abn().SendKeys("11 111 111 111");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.AddBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                AddCustomerPg.Customer3().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                AddCustomerPg.EditCustomer().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                AddCustomerPg.EditPgABN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.EditPgABN().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.EditPgABN().SendKeys("abhushuhuhq");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.EditPgSaveBtn().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IWebElement bodyTag1 = WebDriver.FindElement(By.TagName("body"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool errmsg323 = bodyTag1.Text.Contains("The value entered was not a valid 11 digit ABN (numbers and spaces only).");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(errmsg323 == true);
                AddCustomerPg.EditPgABN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.EditPgABN().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.EditPgABN().SendKeys("1111111111");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.EditPgSaveBtn().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                bool errmsg333 = bodyTag1.Text.Contains("Invalid ABN length");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(errmsg333 == true);
                AddCustomerPg.EditPgABN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.EditPgABN().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.EditPgABN().SendKeys("123 123 123 123");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.EditPgSaveBtn().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                bool errmsg444 = bodyTag1.Text.Contains("Invalid ABN length");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(errmsg444 == true);
                AddCustomerPg.EditPgABN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.EditPgABN().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.EditPgABN().SendKeys("            ");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.EditPgSaveBtn().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                bool errmsg555 = bodyTag1.Text.Contains("Invalid ABN length");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(errmsg555 == true);
                AddCustomerPg.EditPgABN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.EditPgABN().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.EditPgABN().SendKeys("11 111 111 111*");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.EditPgSaveBtn().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                bool errmsg666 = bodyTag1.Text.Contains("The value entered was not a valid 11 digit ABN (numbers and spaces only).");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(errmsg666 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.EditPgABN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.EditPgABN().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.EditPgABN().SendKeys("11 111 111 111");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.EditPgSaveBtn().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                AddCustomerPg.RemoveCustomer().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                AddCustomerPg.ConfirmRemoveCustomer().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
               // abn with 11 letters
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("External2");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.PaymentTerms().SendKeys("30 days");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Abn().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Abn().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Abn().SendKeys("abhushuhuhq");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("TestABN" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IWebElement bodyTag2 = WebDriver.FindElement(By.TagName("body"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool errmsg4 = bodyTag2.Text.Contains("The value entered was not a valid 11 digit ABN (numbers and spaces only)");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(errmsg4 == true);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", IssueInvoicePg.IssueInvoiceTxt());
                SeleniumSetMethods.WaitOnPage(secdelay1);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", IssueInvoicePg.IssueInvoiceTxt());
                SeleniumSetMethods.WaitOnPage(secdelay1);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", IssueInvoicePg.IssueInvoiceTxt());
                SeleniumSetMethods.WaitOnPage(secdelay1);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", IssueInvoicePg.IssueInvoiceTxt());
                SeleniumSetMethods.WaitOnPage(secdelay1);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", IssueInvoicePg.IssueInvoiceTxt());
                SeleniumSetMethods.WaitOnPage(secdelay1);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", IssueInvoicePg.IssueInvoiceTxt());
                SeleniumSetMethods.WaitOnPage(secdelay1);
                // abn with less than 11 numbers
                IssueInvoicePg.Abn().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Abn().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Abn().SendKeys("123465123");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                bool errmsg5 = bodyTag2.Text.Contains("Invalid ABN length");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(errmsg5 == true);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", IssueInvoicePg.IssueInvoiceTxt());
                SeleniumSetMethods.WaitOnPage(secdelay1);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", IssueInvoicePg.IssueInvoiceTxt());
                SeleniumSetMethods.WaitOnPage(secdelay1);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", IssueInvoicePg.IssueInvoiceTxt());
                SeleniumSetMethods.WaitOnPage(secdelay1);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", IssueInvoicePg.IssueInvoiceTxt());
                SeleniumSetMethods.WaitOnPage(secdelay1);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", IssueInvoicePg.IssueInvoiceTxt());
                SeleniumSetMethods.WaitOnPage(secdelay1);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", IssueInvoicePg.IssueInvoiceTxt());
                SeleniumSetMethods.WaitOnPage(secdelay1);
                // abn with more than 11 numbers
                IssueInvoicePg.Abn().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Abn().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Abn().SendKeys("123123123123");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                bool errmsg6 = bodyTag2.Text.Contains("Invalid ABN length");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(errmsg6 == true);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", IssueInvoicePg.IssueInvoiceTxt());
                SeleniumSetMethods.WaitOnPage(secdelay1);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", IssueInvoicePg.IssueInvoiceTxt());
                SeleniumSetMethods.WaitOnPage(secdelay1);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", IssueInvoicePg.IssueInvoiceTxt());
                SeleniumSetMethods.WaitOnPage(secdelay1);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", IssueInvoicePg.IssueInvoiceTxt());
                SeleniumSetMethods.WaitOnPage(secdelay1);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", IssueInvoicePg.IssueInvoiceTxt());
                SeleniumSetMethods.WaitOnPage(secdelay1);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", IssueInvoicePg.IssueInvoiceTxt());
                SeleniumSetMethods.WaitOnPage(secdelay1);
                // abn with digits and letters
                IssueInvoicePg.Abn().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Abn().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Abn().SendKeys("gvbdf123456");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                bool errmsg7 = bodyTag2.Text.Contains("The value entered was not a valid 11 digit ABN (numbers and spaces only)");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(errmsg7 == true);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", IssueInvoicePg.IssueInvoiceTxt());
                SeleniumSetMethods.WaitOnPage(secdelay1);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", IssueInvoicePg.IssueInvoiceTxt());
                SeleniumSetMethods.WaitOnPage(secdelay1);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", IssueInvoicePg.IssueInvoiceTxt());
                SeleniumSetMethods.WaitOnPage(secdelay1);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", IssueInvoicePg.IssueInvoiceTxt());
                SeleniumSetMethods.WaitOnPage(secdelay1);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", IssueInvoicePg.IssueInvoiceTxt());
                SeleniumSetMethods.WaitOnPage(secdelay1);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", IssueInvoicePg.IssueInvoiceTxt());
                SeleniumSetMethods.WaitOnPage(secdelay1);
                // abn with digits and special characters
                IssueInvoicePg.Abn().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Abn().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Abn().SendKeys("456465/*456/*");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                bool errmsg8 = bodyTag2.Text.Contains("The value entered was not a valid 11 digit ABN (numbers and spaces only)");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(errmsg8 == true);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", IssueInvoicePg.IssueInvoiceTxt());
                SeleniumSetMethods.WaitOnPage(secdelay1);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", IssueInvoicePg.IssueInvoiceTxt());
                SeleniumSetMethods.WaitOnPage(secdelay1);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", IssueInvoicePg.IssueInvoiceTxt());
                SeleniumSetMethods.WaitOnPage(secdelay1);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", IssueInvoicePg.IssueInvoiceTxt());
                SeleniumSetMethods.WaitOnPage(secdelay1);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", IssueInvoicePg.IssueInvoiceTxt());
                SeleniumSetMethods.WaitOnPage(secdelay1);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", IssueInvoicePg.IssueInvoiceTxt());
                SeleniumSetMethods.WaitOnPage(secdelay1);
                // abn without abn and street adress
                IssueInvoicePg.Abn().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Abn().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Abn().SendKeys("");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Street().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Street().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Suburb().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Suburb().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Postcode().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Postcode().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IWebElement bodyTag3 = WebDriver.FindElement(By.TagName("body"));
                SeleniumSetMethods.WaitOnPage(secdelay3);
                bool errmsg19 = bodyTag3.Text.Contains("For security reasons you must enter either a street address or ABN.");
                bool errmsg29 = bodyTag3.Text.Contains("Street Address must be entered as ABN field is empty");
                bool errmsg39 = bodyTag3.Text.Contains("Suburb must be entered as ABN field is empty");
                bool errmsg49 = bodyTag3.Text.Contains("Post Code must be entered as ABN field is empty");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(errmsg19 == true && errmsg29 == true && errmsg39 == true && errmsg49 == true);
                // abn with abn and no street address
                IssueInvoicePg.Abn().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Abn().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Abn().SendKeys("123 123 123   12");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                sendpg.SearchInvoiceSent().Click();
                
                // abn without abn and with street adress
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("External1");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.PaymentTerms().SendKeys("30 days");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Abn().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Abn().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("TestPostalAddress" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                sendpg.SearchInvoiceSent().Click();
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);


            }
            finally
            {
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com");

            }

        }



        public static void addrecord(string ID, string status, string filepath)
        {
            try
            {

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filepath, true))
                {
                    file.WriteLine(ID + "," + status);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("This program not working:", ex);
            }

        }
    }
}
