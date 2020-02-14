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
    class RegSuite_DeleteInvoice : Tests
    {
        [Test]
        public void DeleteInvoice01_Biller_ListView_withDeal_CREATED_PV()
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
                loginPage.UserNameTextBox().SendKeys("madcowbillergst+DeleteInvoice01@gmail.com");
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
                IssueInvoicePg.BusinessName().SendKeys("madcowpayergst+DeleteInvoice01");
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
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("Delete@" + randnumber2);
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
                SendPg.SearchInvoiceSent().SendKeys("Delete@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                
                string invoicestatus = SIVPG1.InvoiceStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invoicestatus.Contains("UNPAID"));
                string invnumber = SIVPG1.InvNumber().Text;
                string invoicenumber = invnumber.Substring(invnumber.IndexOf("Invoice ")).Replace("Invoice ", "");
                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ActionDropdownDelete().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                DeleteInvoicePage Delpg = new DeleteInvoicePage(WebDriver);
                bool deletetitle = SIVPG1.DeleteModalTitle().Displayed;
                bool deloinvmsg = SIVPG1.DeleteInvoiceMessage().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(deletetitle == true && deloinvmsg == true);
                SIVPG1.ConfirmDeleteBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string errmsg = SIVPG1.Deleteerrmsg().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(errmsg.Contains("A comment of at least 30 characters is required"));
                SIVPG1.DeleteCancelBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ActionDropdownDelete().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.DeleteComment().SendKeys("Biller deleted");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ConfirmDeleteBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string errmsg1 = SIVPG1.Deleteerrmsg().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(errmsg1.Contains("A comment of at least 30 characters is required"));
                SIVPG1.DeleteCancelBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.DeleteOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string deletetitle1 = SIVPG1.DeleteModalTitle().Text;
                string deloinvms1g = SIVPG1.DeleteInvoiceMessage().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(deletetitle1.Contains("Delete Invoice") && deloinvms1g.Contains("This invoice will be deleted and can no longer be paid. You will still be able to see this invoice in your invoice history."));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ConfirmDeleteBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string errmsg3 = SIVPG1.Deleteerrmsg().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(errmsg3.Contains("A comment of at least 30 characters is required"));
                SIVPG1.DeleteCancelBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);


                SendPg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.DeleteOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.DeleteComment().SendKeys("Biller deleted");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ConfirmDeleteBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string errmsg4 = SIVPG1.Deleteerrmsg().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(errmsg4.Contains("A comment of at least 30 characters is required"));
                SIVPG1.DeleteCancelBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SendPg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.DeleteOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.DeleteComment().SendKeys("Biller deleted invoice - UNPAID");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ConfirmDeleteBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                
                SendPg.SearchInvoiceSent().SendKeys("Delete@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string noinvresult = SendPg.NoInvoiceResult().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(noinvresult.Contains("No Invoices Available"));
                SendPg.SentHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.StatusDeletedRow01().Click();
                String deletedmsg = SendPg.HistDelete().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(deletedmsg.Contains("Deleted"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string paidstatushover11 = SendPg.HistoryDeletedStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover11.Contains("deleted"));
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                DateTime newDat1e = DateTime.Now;
                string dtString4 = newDat1e.ToString("dd/MM/yy");
                string invstatus = SIVPG1.InvoiceStatus().Text;
                string date = SIVPG1.InvoiceDetailsDateDeleted().Text;
                string who = SIVPG1.WhoDeletedInfo().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invstatus.Contains("DELETED") && date.Contains("Date Deleted") && date.Contains(dtString4) && who.Contains("You deleted this invoice."));
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));
                bool deletemsg = bodyTag.Text.Contains("Biller deleted invoice - UNPAID");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(deletemsg == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowpayergst+DeleteInvoice01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("Delete@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);

                string noinv = Recpg.NoInvoiceResult().Text;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(noinv.Contains("No Invoices Available"));
                Recpg.ReceivedHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.StatusDeletedRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                String deletedmsg1 = Recpg.HistDeleteamount().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(deletedmsg1.Contains("Deleted"));
                string paidstatushover17 = Recpg.HistoryDeletedStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover17.Contains("deleted"));
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                string invstatus1 = SIVPG1.InvoiceStatus().Text;
                string date1 = SIVPG1.InvoiceDetailsDateDeleted().Text;
                string who1 = SIVPG1.WhoDeletedInfo().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invstatus1.Contains("DELETED") && date1.Contains("Date Deleted") && date1.Contains(dtString4) && who1.Contains("madcowbillergst+DeleteInvoice01 deleted this invoice."));
                IWebElement bodyTag1 = WebDriver.FindElement(By.TagName("body"));
                bool deletemsg1 = bodyTag1.Text.Contains("Biller deleted invoice - UNPAID");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(deletemsg1 == true);
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
                SeleniumSetMethods.WaitOnPage(secdelay7);
                Bobopg.UpdateExistingBillzyInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.SelectBusiness().SendKeys("madcowbillergst+DeleteInvoice01");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.InputInvoice().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.SearchBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                string invstat = Bobopg.InvoiceStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invstat.Contains("DELETED"));

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
        public void DeleteInvoice02_Biller_SIV_withDeal_REQUESTED()
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
                loginPage.UserNameTextBox().SendKeys("madcowbillergst+DeleteInvoice01@gmail.com");
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
                IssueInvoicePg.BusinessName().SendKeys("madcowpayergst+DeleteInvoice01");
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
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("REQ-INV-@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                IssueInvoicePg.Message().SendKeys("Internal Payer with Deal and  surcharge");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                //IssueInvoicePg.SurchargeCheckbox().Click();
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("REQ-INV-@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowpayergst+DeleteInvoice01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("REQ-INV-@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.PayerOfferEarlyPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SIVPG1.NewTotal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.NewTotal().SendKeys("208.82");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //verify discount %
                DateTime newDate2 = DateTime.Now.AddDays(15);
                string dtString4 = newDate2.ToString("dd/MM/yyyy");
                SIVPG1.OfferExpiry().Clear();
                SIVPG1.OfferExpiry().SendKeys(dtString4);
                SeleniumSetMethods.WaitOnPage(secdelay1);

                string percentage2 = SIVPG1.SIVOfferDiscountpercentage().Text;
                Assert.IsTrue(percentage2.Contains("40.64%"));
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SIVPG1.Comments().SendKeys("Payer made a counter offer");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.OfferEarlyPaymentModalBTN1().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowbillergst+DeleteInvoice01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("REQ-INV-@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                //SendPg.BillzyRefResult().Click();
                //SeleniumSetMethods.WaitOnPage(secdelay6);
                

                SendPg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.DeleteOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.DeleteComment().SendKeys("Biller deleted invoice - UNPAID");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ConfirmDeleteBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                

                SendPg.SearchInvoiceSent().SendKeys("REQ-INV-@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string noinvresult = SendPg.NoInvoiceResult().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(noinvresult.Contains("No Invoices Available"));
                SendPg.SentHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.StatusDeletedRow01().Click();
                String deletedmsg = SendPg.HistDelete().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(deletedmsg.Contains("Deleted"));
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                DateTime newDat1e = DateTime.Now;
                string dtString5 = newDat1e.ToString("dd/MM/yy");
                string invstatus = SIVPG1.InvoiceStatus().Text;
                string date = SIVPG1.InvoiceDetailsDateDeleted().Text;
                string who = SIVPG1.WhoDeletedInfo().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invstatus.Contains("DELETED") && date.Contains("Date Deleted") && date.Contains(dtString5) && who.Contains("You deleted this invoice."));


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
        public void DeleteInvoice03_Biller_ListView_withDeal_DECLINED()
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
                loginPage.UserNameTextBox().SendKeys("madcowbillergst+DeleteInvoice01@gmail.com");
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
                IssueInvoicePg.BusinessName().SendKeys("madcowpayergst+DeleteInvoice01");
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
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("Delete@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("1,204.09");
                IssueInvoicePg.Message().SendKeys("Internal Payer with Deal and  surcharge");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                IssueInvoicePg.SurchargeCheckbox().Click();
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("Delete@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowpayergst+DeleteInvoice01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("Delete@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.PayerOfferEarlyPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SIVPG1.NewTotal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.NewTotal().SendKeys("1,008.82");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //verify discount %
                DateTime newDate2 = DateTime.Now.AddDays(15);
                string dtString4 = newDate2.ToString("dd/MM/yyyy");
                SIVPG1.OfferExpiry().Clear();
                SIVPG1.OfferExpiry().SendKeys(dtString4);
                SeleniumSetMethods.WaitOnPage(secdelay1);

                string percentage2 = SIVPG1.SIVOfferDiscountpercentage().Text;
                Assert.IsTrue(percentage2.Contains("23.83%"));
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SIVPG1.Comments().SendKeys("Payer made a counter offer");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.OfferEarlyPaymentModalBTN1().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowbillergst+DeleteInvoice01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("Delete@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.DeclineOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.DeclineOfferModalYes().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                String status = SIVPG1.DiscountHistoryStatus01().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(status.Contains("DECLINED"));
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("Delete@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.DeleteOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.DeleteComment().SendKeys("Biller deleted invoice - UNPAID");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ConfirmDeleteBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);


                SendPg.SearchInvoiceSent().SendKeys("Delete@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string noinvresult = SendPg.NoInvoiceResult().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(noinvresult.Contains("No Invoices Available"));
                SendPg.SentHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.StatusDeletedRow01().Click();
                String deletedmsg = SendPg.HistDelete().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(deletedmsg.Contains("Deleted"));



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
        public void DeleteInvoice04_Biller_SIV_withDeal_ACCEPTED()
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
                loginPage.UserNameTextBox().SendKeys("madcowpayergst+deleteinvoicenogstbiller01@gmail.com");
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
                IssueInvoicePg.BusinessName().SendKeys("madcowpayergst+DeleteInvoicenogstpayer01");
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
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("ACC-INV-@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                IssueInvoicePg.Message().SendKeys("Internal Payer with Deal and  surcharge");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
               // IssueInvoicePg.SurchargeCheckbox().Click();
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("ACC-INV-@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowpayergst+DeleteInvoicenogstpayer01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("ACC-INV-@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.PayerOfferEarlyPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SIVPG1.NewTotal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.NewTotal().SendKeys("208.82");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //verify discount %
                DateTime newDate2 = DateTime.Now.AddDays(15);
                string dtString4 = newDate2.ToString("dd/MM/yyyy");
                SIVPG1.OfferExpiry().Clear();
                SIVPG1.OfferExpiry().SendKeys(dtString4);
                SeleniumSetMethods.WaitOnPage(secdelay1);

                string percentage2 = SIVPG1.SIVOfferDiscountpercentage().Text;
                Assert.IsTrue(percentage2.Contains("34.71%"));
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SIVPG1.Comments().SendKeys("Payer made a counter offer");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.OfferEarlyPaymentModalBTN1().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowpayergst+deleteinvoicenogstbiller01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("ACC-INV-@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.AcceptOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.AcceptTheOfferModalYesBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                String status = SIVPG1.DiscountHistoryStatus01().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(status.Contains("ACCEPTED"));
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("ACC-INV-@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool deleteoption1 =   SendPg.DeleteOption().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(deleteoption1 == false);
                SeleniumSetMethods.WaitOnPage(secdelay4);

                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowpayergst+DeleteInvoicenogstpayer01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("ACC-INV-@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ActionsMenu().Click();
                bool deleteoption2 = Recpg.DeleteOption().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(deleteoption2 == false);

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
        public void DeleteInvoice05_Biller_ListView_withDeal_OVERDUE()
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
                loginPage.UserNameTextBox().SendKeys("madcowbillergst+OverDue_1@gmail.com");
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
                IssueInvoicePg.BusinessName().SendKeys("billzyBiz-130825");
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
                String PaymentTerms = "By Due Date";

                DateTime duedate1 = DateTime.Today;
                string SentPgDueDate = duedate1.ToString("dd/MM/yy");
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("OverDue@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.DueDate().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.DueDate().SendKeys(SentPgDueDate);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.NewTotal().SendKeys("128.80");
                SeleniumSetMethods.WaitOnPage(secdelay2);

                IssueInvoicePg.OfferExpiry().Clear();
                IssueInvoicePg.OfferExpiry().SendKeys(SentPgDueDate);
                IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");
                IssueInvoicePg.Message().SendKeys("Internal Payer with Deal and  surcharge");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("OverDue@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowpayergst+OverDue_1@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("OverDue");
                SeleniumSetMethods.WaitOnPage(secdelay7);
                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invoicestatus = SIVPG1.InvoiceStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Assert.IsTrue(invoicestatus.Contains("OVERDUE"));
                string invnumber = SIVPG1.InvNumber().Text;
                string invoicenumber = invnumber.Substring(invnumber.IndexOf("Invoice ")).Replace("Invoice ", "");
                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ActionDropdownDelete().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                DeleteInvoicePage Delpg = new DeleteInvoicePage(WebDriver);
                bool deletetitle = SIVPG1.DeleteModalTitle().Displayed;
                bool deloinvmsg = SIVPG1.DeleteInvoiceMessage().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(deletetitle == true && deloinvmsg == true);
                SIVPG1.ConfirmDeleteBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string errmsg = SIVPG1.Deleteerrmsg().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(errmsg.Contains("A comment of at least 30 characters is required"));
                SIVPG1.DeleteCancelBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowbillergst+OverDue_1@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay8);
                SendPg.SearchInvoiceSent().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay3);

                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.DeleteOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string deletetitle1 = SIVPG1.DeleteModalTitle().Text;
                string deloinvms1g = SIVPG1.DeleteInvoiceMessage().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(deletetitle1.Contains("Delete Invoice") && deloinvms1g.Contains("This invoice will be deleted and can no longer be paid. You will still be able to see this invoice in your invoice history."));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ConfirmDeleteBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string errmsg3 = SIVPG1.Deleteerrmsg().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(errmsg3.Contains("A comment of at least 30 characters is required"));
                SIVPG1.DeleteCancelBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);


                SendPg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.DeleteOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.DeleteComment().SendKeys("Biller deleted");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ConfirmDeleteBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string errmsg4 = SIVPG1.Deleteerrmsg().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(errmsg4.Contains("A comment of at least 30 characters is required"));
                SIVPG1.DeleteCancelBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SendPg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.DeleteOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.DeleteComment().SendKeys("Biller deleted invoice - UNPAID");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ConfirmDeleteBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                SendPg.SearchInvoiceSent().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string noinvresult = SendPg.NoInvoiceResult().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(noinvresult.Contains("No Invoices Available"));
                SendPg.SentHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.StatusDeletedRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
             

                SeleniumSetMethods.WaitOnPage(secdelay2);
                string paidstatushover11 = SendPg.HistoryDeletedStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover11.Contains("deleted"));
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                DateTime newDat1e = DateTime.Now;
                string dtString4 = newDat1e.ToString("dd/MM/yy");
                string invstatus = SIVPG1.InvoiceStatus().Text;
                string date = SIVPG1.InvoiceDetailsDateDeleted().Text;
                string who = SIVPG1.WhoDeletedInfo().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invstatus.Contains("DELETED") && date.Contains("Date Deleted") && date.Contains(dtString4) && who.Contains("You deleted this invoice."));



                SeleniumSetMethods.WaitOnPage(secdelay2);

                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowpayergst+OverDue_1@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay3);

                string noinv = Recpg.NoInvoiceResult().Text;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(noinv.Contains("No Invoices Available"));
                Recpg.ReceivedHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.StatusDeletedRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                String deletedmsg1 = Recpg.HistoverdueDeleteamount().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(deletedmsg1.Contains("Deleted"));
                string paidstatushover17 = Recpg.HistoryDeletedStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover17.Contains("deleted"));
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                string invstatus1 = SIVPG1.InvoiceStatus().Text;
                string date1 = SIVPG1.InvoiceDetailsDateDeleted().Text;
                string who1 = SIVPG1.WhoDeletedInfo().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invstatus1.Contains("DELETED") && date1.Contains("Date Deleted") && date1.Contains(dtString4) && who1.Contains("billzyBiz-108534 deleted this invoice."));
                



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
        public void DeleteInvoice06_Biller_SIV_withDeal_EXPIREDDEAL()
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
                loginPage.UserNameTextBox().SendKeys("madcowbillergst+ExpiredDeal_1@gmail.com");
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
                IssueInvoicePg.BusinessName().SendKeys("billzyBiz-458320");
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
                String PaymentTerms = "By Due Date";

                DateTime duedate1 = DateTime.Today.AddDays(180);
                string SentPgDueDate = duedate1.ToString("dd/MM/yy");
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("EXP-INV-06A@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.DueDate().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.DueDate().SendKeys(SentPgDueDate);
                SeleniumSetMethods.WaitOnPage(secdelay2);

                DateTime duedate2 = DateTime.Today;
                string SentPgDueDate2 = duedate2.ToString("dd/MM/yy");


                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.NewTotal().SendKeys("128.80");
                SeleniumSetMethods.WaitOnPage(secdelay2);

                IssueInvoicePg.OfferExpiry().Clear();
                IssueInvoicePg.OfferExpiry().SendKeys(SentPgDueDate2);
                IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");
                IssueInvoicePg.Message().SendKeys("Internal Payer with Deal and  surcharge");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("EXP-INV-06A");
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber = SIVPG1.InvNumber().Text;
                string invoicenumber = invnumber.Substring(invnumber.IndexOf("Invoice ")).Replace("Invoice ", "");
                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ActionDropdownDelete().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                DeleteInvoicePage Delpg = new DeleteInvoicePage(WebDriver);
                bool deletetitle = SIVPG1.DeleteModalTitle().Displayed;
                bool deloinvmsg = SIVPG1.DeleteInvoiceMessage().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(deletetitle == true && deloinvmsg == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.DeleteComment().SendKeys("Biller deleted invoice - UNPAID");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ConfirmDeleteBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowpayergst+ExpiredDeal_1@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay5);

                string noinv = Recpg.NoInvoiceResult().Text;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(noinv.Contains("No Invoices Available"));
                Recpg.ReceivedHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.StatusDeletedRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                String deletedmsg1 = Recpg.HistoverdueDeleteamount().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(deletedmsg1.Contains("Deleted"));
                string paidstatushover17 = Recpg.HistoryDeletedStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover17.Contains("deleted"));
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                string invstatus1 = SIVPG1.InvoiceStatus().Text;
                string date1 = SIVPG1.InvoiceDetailsDateDeleted().Text;
                string who1 = SIVPG1.WhoDeletedInfo().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invstatus1.Contains("DELETED") && date1.Contains("Date Deleted") && date1.Contains(SentPgDueDate2) && who1.Contains("billzyBiz-98471 deleted this invoice."));
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
        public void DeleteInvoice07_Biller_ListView_withoutDeal_UNPAID()
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
                loginPage.UserNameTextBox().SendKeys("madcowbillergst+DeleteInvoice01@gmail.com");
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
                IssueInvoicePg.BusinessName().SendKeys("madcowpayergst+DeleteInvoice01");
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
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("Delete@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SurchargeCheckbox().Click();

                //issueInvoice_issueInvoicePage_totalValue.checkValueContains = @amountGst
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");
                SeleniumSetMethods.WaitOnPage(secdelay5);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("Delete@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string invoicestatus = SIVPG1.InvoiceStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invoicestatus.Contains("UNPAID"));
                string invnumber = SIVPG1.InvNumber().Text;
                string invoicenumber = invnumber.Substring(invnumber.IndexOf("Invoice ")).Replace("Invoice ", "");
                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ActionDropdownDelete().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                DeleteInvoicePage Delpg = new DeleteInvoicePage(WebDriver);
                bool deletetitle = SIVPG1.DeleteModalTitle().Displayed;
                bool deloinvmsg = SIVPG1.DeleteInvoiceMessage().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(deletetitle == true && deloinvmsg == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.DeleteComment().SendKeys("Biller deleted");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                
                SIVPG1.ConfirmDeleteBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SeleniumSetMethods.WaitOnPage(secdelay2);
                string errmsg = SIVPG1.Deleteerrmsg().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(errmsg.Contains("A comment of at least 30 characters is required"));
                SIVPG1.DeleteCancelBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SendPg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.DeleteOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.DeleteComment().SendKeys("Biller deleted invoice - UNPAID");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ConfirmDeleteBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                SendPg.SearchInvoiceSent().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string noinvresult = SendPg.NoInvoiceResult().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(noinvresult.Contains("No Invoices Available"));
                SendPg.SentHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.StatusDeletedRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);


                SeleniumSetMethods.WaitOnPage(secdelay2);
                string paidstatushover11 = SendPg.HistoryDeletedStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover11.Contains("deleted"));
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                DateTime newDat1e = DateTime.Now;
                string dtString4 = newDat1e.ToString("dd/MM/yy");
                string invstatus = SIVPG1.InvoiceStatus().Text;
                string date = SIVPG1.InvoiceDetailsDateDeleted().Text;
                string who = SIVPG1.WhoDeletedInfo().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invstatus.Contains("DELETED") && date.Contains("Date Deleted") && date.Contains(dtString4) && who.Contains("You deleted this invoice."));



                SeleniumSetMethods.WaitOnPage(secdelay2);


                HomePg.SignOutBTN().Click();


                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowpayergst+DeleteInvoice01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay3);

                string noinv = Recpg.NoInvoiceResult().Text;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(noinv.Contains("No Invoices Available"));
                Recpg.ReceivedHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.StatusDeletedRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                String deletedmsg1 = Recpg.HistDeleteamount().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(deletedmsg1.Contains("Deleted"));
                string paidstatushover17 = Recpg.HistoryDeletedStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover17.Contains("deleted"));
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                string invstatus1 = SIVPG1.InvoiceStatus().Text;
                string date1 = SIVPG1.InvoiceDetailsDateDeleted().Text;
                string who1 = SIVPG1.WhoDeletedInfo().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invstatus1.Contains("DELETED") && date1.Contains("Date Deleted") && date1.Contains(dtString4) && who1.Contains("madcowbillergst+DeleteInvoice01 deleted this invoice."));
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
        public void DeleteInvoice08_Payer_SIV_withDeal_CREATED()
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
                loginPage.UserNameTextBox().SendKeys("madcowbillergst+DeleteInvoice01@gmail.com");
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
                IssueInvoicePg.BusinessName().SendKeys("madcowpayergst+DeleteInvoice01");
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
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("CRE-INV-@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.NewTotal().SendKeys("128.80");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                DateTime newDate = DateTime.Now.AddDays(15);
                string dtString3 = newDate.ToString("dd/MM/yyyy");
                IssueInvoicePg.OfferExpiry().Clear();
                IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
                IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");
                IssueInvoicePg.SurchargeCheckbox().Click();

                //issueInvoice_issueInvoicePage_totalValue.checkValueContains = @amountGst
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");
                SeleniumSetMethods.WaitOnPage(secdelay5);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("CRE-INV-@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string invoicestatus = SIVPG1.InvoiceStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invoicestatus.Contains("UNPAID"));
                string invnumber = SIVPG1.InvNumber().Text;
                string invoicenumber = invnumber.Substring(invnumber.IndexOf("Invoice ")).Replace("Invoice ", "");
                SeleniumSetMethods.WaitOnPage(secdelay2);

                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowpayergst+DeleteInvoice01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay3);
               Recpg.SearchedFirstRowDetailsLink().Click();
               SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ActionDropdownDelete().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string deletetitle1 = SIVPG1.DeleteModalTitle().Text;
                string deloinvms1g = SIVPG1.DeleteInvoiceMessage().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(deletetitle1.Contains("Delete Invoice") && deloinvms1g.Contains("This invoice will be deleted and can no longer be paid. You will still be able to see this invoice in your invoice history."));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ConfirmDeleteBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string errmsg3 = SIVPG1.Deleteerrmsg().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(errmsg3.Contains("A comment of at least 30 characters is required"));
                SIVPG1.DeleteCancelBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);


                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ActionDropdownDelete().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.DeleteComment().SendKeys("Biller deleted");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ConfirmDeleteBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string errmsg4 = SIVPG1.Deleteerrmsg().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(errmsg4.Contains("A comment of at least 30 characters is required"));
                SIVPG1.DeleteCancelBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ActionDropdownDelete().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.DeleteComment().SendKeys("Biller deleted invoice - UNPAID");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ConfirmDeleteBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string noinv = Recpg.NoInvoiceResult().Text;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(noinv.Contains("No Invoices Available"));
                Recpg.ReceivedHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.StatusDeletedRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                String deletedmsg1 = Recpg.HistDeleteamount().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(deletedmsg1.Contains("Deleted"));
                string paidstatushover17 = Recpg.HistoryDeletedStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover17.Contains("deleted"));
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                DateTime duedate1 = DateTime.Today;
                string SentPgDueDate = duedate1.ToString("dd/MM/yy");

                string invstatus1 = SIVPG1.InvoiceStatus().Text;
                string date1 = SIVPG1.InvoiceDetailsDateDeleted().Text;
                string who1 = SIVPG1.WhoDeletedInfo().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invstatus1.Contains("DELETED") && date1.Contains("Date Deleted") && date1.Contains(SentPgDueDate) && who1.Contains("You deleted this invoice."));
                SeleniumSetMethods.WaitOnPage(secdelay2);

                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowbillergst+DeleteInvoice01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SearchInvoiceSent().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string noinvresult = SendPg.NoInvoiceResult().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(noinvresult.Contains("No Invoices Available"));
                SendPg.SentHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.StatusDeletedRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);


                SeleniumSetMethods.WaitOnPage(secdelay2);
                string paidstatushover11 = SendPg.HistoryDeletedStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover11.Contains("deleted"));
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                DateTime newDat1e = DateTime.Now;
                string dtString4 = newDat1e.ToString("dd/MM/yy");
                string invstatus = SIVPG1.InvoiceStatus().Text;
                string date = SIVPG1.InvoiceDetailsDateDeleted().Text;
                string who = SIVPG1.WhoDeletedInfo().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invstatus.Contains("DELETED") && date.Contains("Date Deleted") && date.Contains(SentPgDueDate) && who.Contains("madcowpayergst+DeleteInvoice01 deleted this invoice."));



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
        public void DeleteInvoice09_Payer_ListView_withDeal_REQUESTED()
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
                loginPage.UserNameTextBox().SendKeys("madcowbillergst+DeleteInvoice01@gmail.com");
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
                IssueInvoicePg.BusinessName().SendKeys("madcowpayergst+DeleteInvoice01");
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
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("Delete@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("1,204.09");
                IssueInvoicePg.Message().SendKeys("Internal Payer with Deal and  surcharge");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                //IssueInvoicePg.SurchargeCheckbox().Click();
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("Delete@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                
                string invoicestatus = SIVPG1.InvoiceStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invoicestatus.Contains("UNPAID"));
                string invnumber = SIVPG1.InvNumber().Text;
                string invoicenumber = invnumber.Substring(invnumber.IndexOf("Invoice ")).Replace("Invoice ", "");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowpayergst+DeleteInvoice01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.PayerOfferEarlyPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SIVPG1.NewTotal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.NewTotal().SendKeys("1,008.82");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //verify discount %
                DateTime newDate2 = DateTime.Now.AddDays(15);
                string dtString4 = newDate2.ToString("dd/MM/yyyy");
                SIVPG1.OfferExpiry().Clear();
                SIVPG1.OfferExpiry().SendKeys(dtString4);
                SeleniumSetMethods.WaitOnPage(secdelay1);

                string percentage2 = SIVPG1.SIVOfferDiscountpercentage().Text;
                Assert.IsTrue(percentage2.Contains("23.83%"));
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SIVPG1.Comments().SendKeys("Payer made a counter offer");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.OfferEarlyPaymentModalBTN1().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.DeleteOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string deletetitle1 = SIVPG1.DeleteModalTitle().Text;
                string deloinvms1g = SIVPG1.DeleteInvoiceMessage().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(deletetitle1.Contains("Delete Invoice") && deloinvms1g.Contains("This invoice will be deleted and can no longer be paid. You will still be able to see this invoice in your invoice history."));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ConfirmDeleteBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string errmsg3 = SIVPG1.Deleteerrmsg().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(errmsg3.Contains("A comment of at least 30 characters is required"));
                SIVPG1.DeleteCancelBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);


                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.DeleteOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.DeleteComment().SendKeys("Biller deleted");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ConfirmDeleteBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string errmsg4 = SIVPG1.Deleteerrmsg().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(errmsg4.Contains("A comment of at least 30 characters is required"));
                SIVPG1.DeleteCancelBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                

                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.DeleteOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string deletetitle2 = SIVPG1.DeleteModalTitle().Text;
                string deloinvms1g2 = SIVPG1.DeleteInvoiceMessage().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(deletetitle2.Contains("Delete Invoice") && deloinvms1g2.Contains("This invoice will be deleted and can no longer be paid. You will still be able to see this invoice in your invoice history."));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ConfirmDeleteBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string errmsg33 = SIVPG1.Deleteerrmsg().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(errmsg33.Contains("A comment of at least 30 characters is required"));
                SIVPG1.DeleteCancelBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);


                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.DeleteOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.DeleteComment().SendKeys("Biller deleted");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ConfirmDeleteBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string errmsg44 = SIVPG1.Deleteerrmsg().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(errmsg44.Contains("A comment of at least 30 characters is required"));
                SIVPG1.DeleteCancelBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.DeleteOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.DeleteComment().SendKeys("Biller deleted invoice - UNPAID");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ConfirmDeleteBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string noinv = Recpg.NoInvoiceResult().Text;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(noinv.Contains("No Invoices Available"));
                Recpg.ReceivedHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.StatusDeletedRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                String deletedmsg1 = Recpg.HistDeleteamount().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(deletedmsg1.Contains("Deleted"));
                string paidstatushover17 = Recpg.HistoryDeletedStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover17.Contains("deleted"));
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                DateTime duedate1 = DateTime.Today;
                string SentPgDueDate = duedate1.ToString("dd/MM/yy");

                string invstatus1 = SIVPG1.InvoiceStatus().Text;
                string date1 = SIVPG1.InvoiceDetailsDateDeleted().Text;
                string who1 = SIVPG1.WhoDeletedInfo().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invstatus1.Contains("DELETED") && date1.Contains("Date Deleted") && date1.Contains(SentPgDueDate) && who1.Contains("You deleted this invoice."));
                SeleniumSetMethods.WaitOnPage(secdelay2);

                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowbillergst+DeleteInvoice01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SearchInvoiceSent().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string noinvresult = SendPg.NoInvoiceResult().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(noinvresult.Contains("No Invoices Available"));
                SendPg.SentHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.StatusDeletedRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);


                SeleniumSetMethods.WaitOnPage(secdelay2);
                string paidstatushover11 = SendPg.HistoryDeletedStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover11.Contains("deleted"));
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                DateTime newDat1e = DateTime.Now;
                string dtString5 = newDat1e.ToString("dd/MM/yy");
                string invstatus = SIVPG1.InvoiceStatus().Text;
                string date = SIVPG1.InvoiceDetailsDateDeleted().Text;
                string who = SIVPG1.WhoDeletedInfo().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invstatus.Contains("DELETED") && date.Contains("Date Deleted") && date.Contains(dtString5) && who.Contains("madcowpayergst+DeleteInvoice01 deleted this invoice."));


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
        public void DeleteInvoice10_Payer_SIV_withDeal_DECLINED()
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
                loginPage.UserNameTextBox().SendKeys("madcowbillergst+DeleteInvoice01@gmail.com");
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
                IssueInvoicePg.BusinessName().SendKeys("madcowpayergst+DeleteInvoice01");
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
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("DEC-INV@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                IssueInvoicePg.Message().SendKeys("Internal Payer with Deal and  surcharge");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                IssueInvoicePg.SurchargeCheckbox().Click();
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("DEC-INV@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowpayergst+DeleteInvoice01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("DEC-INV@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.PayerOfferEarlyPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SIVPG1.NewTotal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.NewTotal().SendKeys("208.82");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //verify discount %
                DateTime newDate2 = DateTime.Now.AddDays(15);
                string dtString4 = newDate2.ToString("dd/MM/yyyy");
                SIVPG1.OfferExpiry().Clear();
                SIVPG1.OfferExpiry().SendKeys(dtString4);
                SeleniumSetMethods.WaitOnPage(secdelay1);

                string percentage2 = SIVPG1.SIVOfferDiscountpercentage().Text;
                Assert.IsTrue(percentage2.Contains("40.64%"));
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SIVPG1.Comments().SendKeys("Payer made a counter offer");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.OfferEarlyPaymentModalBTN1().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowbillergst+DeleteInvoice01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("DEC-INV@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.DeclineOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.DeclineOfferModalYes().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                String status = SIVPG1.DiscountHistoryStatus01().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(status.Contains("DECLINED"));
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowpayergst+DeleteInvoice01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("DEC-INV@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ActionDropdownDelete().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string deletetitle1 = SIVPG1.DeleteModalTitle().Text;
                string deloinvms1g = SIVPG1.DeleteInvoiceMessage().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(deletetitle1.Contains("Delete Invoice") && deloinvms1g.Contains("This invoice will be deleted and can no longer be paid. You will still be able to see this invoice in your invoice history."));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ConfirmDeleteBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string errmsg3 = SIVPG1.Deleteerrmsg().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(errmsg3.Contains("A comment of at least 30 characters is required"));
                SIVPG1.DeleteCancelBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);


                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ActionDropdownDelete().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.DeleteComment().SendKeys("Biller deleted");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ConfirmDeleteBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string errmsg4 = SIVPG1.Deleteerrmsg().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(errmsg4.Contains("A comment of at least 30 characters is required"));
                SIVPG1.DeleteCancelBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ActionDropdownDelete().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.DeleteComment().SendKeys("Biller deleted invoice - UNPAID");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ConfirmDeleteBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);

                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("DEC-INV@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string noinv = Recpg.NoInvoiceResult().Text;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(noinv.Contains("No Invoices Available"));
                Recpg.ReceivedHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.StatusDeletedRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                String deletedmsg1 = Recpg.HistDeleteamount().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(deletedmsg1.Contains("Deleted"));
                string paidstatushover17 = Recpg.HistoryDeletedStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover17.Contains("deleted"));
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                DateTime duedate1 = DateTime.Today;
                string SentPgDueDate = duedate1.ToString("dd/MM/yy");

                string invstatus1 = SIVPG1.InvoiceStatus().Text;
                string date1 = SIVPG1.InvoiceDetailsDateDeleted().Text;
                string who1 = SIVPG1.WhoDeletedInfo().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invstatus1.Contains("DELETED") && date1.Contains("Date Deleted") && date1.Contains(SentPgDueDate) && who1.Contains("You deleted this invoice."));
                SeleniumSetMethods.WaitOnPage(secdelay2);

                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowbillergst+DeleteInvoice01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SearchInvoiceSent().SendKeys("DEC-INV@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string noinvresult = SendPg.NoInvoiceResult().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(noinvresult.Contains("No Invoices Available"));
                SendPg.SentHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.StatusDeletedRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);


                SeleniumSetMethods.WaitOnPage(secdelay2);
                string paidstatushover11 = SendPg.HistoryDeletedStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover11.Contains("deleted"));
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                DateTime newDat1e = DateTime.Now;
                string dtString5 = newDat1e.ToString("dd/MM/yy");
                string invstatus = SIVPG1.InvoiceStatus().Text;
                string date = SIVPG1.InvoiceDetailsDateDeleted().Text;
                string who = SIVPG1.WhoDeletedInfo().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invstatus.Contains("DELETED") && date.Contains("Date Deleted") && date.Contains(dtString5) && who.Contains("madcowpayergst+DeleteInvoice01 deleted this invoice."));

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
        public void DeleteInvoice11_Payer_ListView_withDeal_ACCEPTED()
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
                loginPage.UserNameTextBox().SendKeys("madcowpayergst+deleteinvoicenogstbiller01@gmail.com");
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
                IssueInvoicePg.BusinessName().SendKeys("madcowpayergst+DeleteInvoicenogstpayer01");
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
                IssueInvoicePg.LineItemAmount().SendKeys("1,204.09");
                IssueInvoicePg.Message().SendKeys("Internal Payer with Deal and  surcharge");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                IssueInvoicePg.SurchargeCheckbox().Click();
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INV@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowpayergst+DeleteInvoicenogstpayer01@gmail.com");
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
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.PayerOfferEarlyPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SIVPG1.NewTotal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.NewTotal().SendKeys("1,008.82");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //verify discount %
                DateTime newDate2 = DateTime.Now.AddDays(15);
                string dtString4 = newDate2.ToString("dd/MM/yyyy");
                SIVPG1.OfferExpiry().Clear();
                SIVPG1.OfferExpiry().SendKeys(dtString4);
                SeleniumSetMethods.WaitOnPage(secdelay1);

                string percentage2 = SIVPG1.SIVOfferDiscountpercentage().Text;
                Assert.IsTrue(percentage2.Contains("16.22%"));
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SIVPG1.Comments().SendKeys("Payer made a counter offer");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.OfferEarlyPaymentModalBTN1().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowpayergst+deleteinvoicenogstbiller01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("INV@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.AcceptOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.AcceptTheOfferModalYesBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                String status = SIVPG1.DiscountHistoryStatus01().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(status.Contains("ACCEPTED"));
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("INV@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool deleteoption1 = SendPg.DeleteOption().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(deleteoption1 == false);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool dropdown1 = SIVPG1.ActionDropdown().Displayed;
                bool DELETE0 = SIVPG1.ActionDropdownDelete().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(dropdown1 == true && DELETE0 == false);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowpayergst+DeleteInvoicenogstpayer01@gmail.com");
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
                Recpg.ActionsMenu().Click();
                bool deleteoption2 = Recpg.DeleteOption().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(deleteoption2 == false);
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool dropdown = SIVPG1.ActionDropdown().Displayed;
                
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(dropdown == false);
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
        public void DeleteInvoice12_Payer_SIV_withDeal_OVERDUE()
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
                loginPage.UserNameTextBox().SendKeys("madcowbillergst+OverDue_1@gmail.com");
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
                IssueInvoicePg.BusinessName().SendKeys("billzyBiz-130825");
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
                String PaymentTerms = "By Due Date";

                DateTime duedate1 = DateTime.Today;
                string SentPgDueDate = duedate1.ToString("dd/MM/yy");
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("OVERDUE-001@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.DueDate().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.DueDate().SendKeys(SentPgDueDate);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.NewTotal().SendKeys("319.82");
                SeleniumSetMethods.WaitOnPage(secdelay2);

                IssueInvoicePg.OfferExpiry().Clear();
                IssueInvoicePg.OfferExpiry().SendKeys(SentPgDueDate);
                IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");
                IssueInvoicePg.Message().SendKeys("Internal Payer with Deal and  surcharge");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("OVERDUE-001@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowpayergst+OverDue_1@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("OVERDUE-001");
                SeleniumSetMethods.WaitOnPage(secdelay7);
                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invoicestatus = SIVPG1.InvoiceStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Assert.IsTrue(invoicestatus.Contains("OVERDUE"));
                string invnumber = SIVPG1.InvNumber().Text;
                string invoicenumber = invnumber.Substring(invnumber.IndexOf("Invoice ")).Replace("Invoice ", "");
                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ActionDropdownDelete().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                DeleteInvoicePage Delpg = new DeleteInvoicePage(WebDriver);
                bool deletetitle = SIVPG1.DeleteModalTitle().Displayed;
                bool deloinvmsg = SIVPG1.DeleteInvoiceMessage().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(deletetitle == true && deloinvmsg == true);
                SIVPG1.ConfirmDeleteBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string errmsg = SIVPG1.Deleteerrmsg().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(errmsg.Contains("A comment of at least 30 characters is required"));
                SIVPG1.DeleteCancelBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ActionDropdownDelete().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.DeleteComment().SendKeys("Biller deleted");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ConfirmDeleteBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string errmsg2 = SIVPG1.Deleteerrmsg().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(errmsg2.Contains("A comment of at least 30 characters is required"));
                SIVPG1.DeleteCancelBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ActionDropdownDelete().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.DeleteComment().SendKeys("Biller deleted invoice with Unpaid status");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ConfirmDeleteBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay3);

                string noinv = Recpg.NoInvoiceResult().Text;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(noinv.Contains("No Invoices Available"));
                Recpg.ReceivedHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.StatusDeletedRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                String deletedmsg1 = Recpg.HistoverdueDeleteamount().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(deletedmsg1.Contains("Deleted"));
                string paidstatushover17 = Recpg.HistoryDeletedStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover17.Contains("deleted"));
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                DateTime newDat1e = DateTime.Now;
                string dtString4 = newDat1e.ToString("dd/MM/yy");
                string invstatus1 = SIVPG1.InvoiceStatus().Text;
                string date1 = SIVPG1.InvoiceDetailsDateDeleted().Text;
                string who1 = SIVPG1.WhoDeletedInfo().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invstatus1.Contains("DELETED") && date1.Contains("Date Deleted") && date1.Contains(dtString4) && who1.Contains("You deleted this invoice."));

                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowbillergst+OverDue_1@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                SendPg.SearchInvoiceSent().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string noinvresult = SendPg.NoInvoiceResult().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(noinvresult.Contains("No Invoices Available"));
                SendPg.SentHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.StatusDeletedRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);


                SeleniumSetMethods.WaitOnPage(secdelay2);
                string paidstatushover11 = SendPg.HistoryDeletedStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover11.Contains("deleted"));
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                
                
                string invstatus = SIVPG1.InvoiceStatus().Text;
                string date = SIVPG1.InvoiceDetailsDateDeleted().Text;
                string who = SIVPG1.WhoDeletedInfo().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invstatus.Contains("DELETED") && date.Contains("Date Deleted") && date.Contains(dtString4) && who.Contains("billzyBiz-130825 deleted this invoice."));



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
        public void DeleteInvoice13_Payer_ListView_withDeal_EXPIREDDEAL()
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
                loginPage.UserNameTextBox().SendKeys("madcowbillergst+ExpiredDeal_1@gmail.com");
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
                IssueInvoicePg.BusinessName().SendKeys("billzyBiz-458320");
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
                String PaymentTerms = "By Due Date";

                DateTime duedate1 = DateTime.Today.AddDays(180);
                string SentPgDueDate = duedate1.ToString("dd/MM/yy");
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("EXP-INV-13-@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.DueDate().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.DueDate().SendKeys(SentPgDueDate);
                SeleniumSetMethods.WaitOnPage(secdelay2);

                DateTime duedate2 = DateTime.Today;
                string SentPgDueDate2 = duedate2.ToString("dd/MM/yy");


                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.NewTotal().SendKeys("128.80");
                SeleniumSetMethods.WaitOnPage(secdelay2);

                IssueInvoicePg.OfferExpiry().Clear();
                IssueInvoicePg.OfferExpiry().SendKeys(SentPgDueDate2);
                IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");
                IssueInvoicePg.Message().SendKeys("Internal Payer with Deal and  surcharge");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("EXP-INV-13-");
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
               

                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowpayergst+ExpiredDeal_1@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("EXP-INV-13");
                SeleniumSetMethods.WaitOnPage(secdelay3);

                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string invnumber = SIVPG1.InvNumber().Text;
                string invoicenumber = invnumber.Substring(invnumber.IndexOf("Invoice ")).Replace("Invoice ", "");
                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ActionDropdownDelete().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string deletetitle1 = SIVPG1.DeleteModalTitle().Text;
                string deloinvms1g = SIVPG1.DeleteInvoiceMessage().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(deletetitle1.Contains("Delete Invoice") && deloinvms1g.Contains("This invoice will be deleted and can no longer be paid. You will still be able to see this invoice in your invoice history."));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ConfirmDeleteBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string errmsg3 = SIVPG1.Deleteerrmsg().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(errmsg3.Contains("A comment of at least 30 characters is required"));
                SIVPG1.DeleteCancelBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);


                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ActionDropdownDelete().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.DeleteComment().SendKeys("Biller deleted");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ConfirmDeleteBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string errmsg4 = SIVPG1.Deleteerrmsg().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(errmsg4.Contains("A comment of at least 30 characters is required"));
                SIVPG1.DeleteCancelBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ActionDropdownDelete().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.DeleteComment().SendKeys("Biller deleted invoice - UNPAID");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ConfirmDeleteBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string noinv = Recpg.NoInvoiceResult().Text;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(noinv.Contains("No Invoices Available"));
                Recpg.ReceivedHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.StatusDeletedRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                String deletedmsg1 = Recpg.HistDeleteamount().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(deletedmsg1.Contains("Deleted"));
                string paidstatushover17 = Recpg.HistoryDeletedStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover17.Contains("deleted"));
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                DateTime duedate3 = DateTime.Today;
                string SentPgDueDate3 = duedate3.ToString("dd/MM/yy");

                string invstatus1 = SIVPG1.InvoiceStatus().Text;
                string date1 = SIVPG1.InvoiceDetailsDateDeleted().Text;
                string who1 = SIVPG1.WhoDeletedInfo().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invstatus1.Contains("DELETED") && date1.Contains("Date Deleted") && date1.Contains(SentPgDueDate3) && who1.Contains("You deleted this invoice."));
                SeleniumSetMethods.WaitOnPage(secdelay2);

                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowbillergst+ExpiredDeal_1@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SearchInvoiceSent().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string noinvresult = SendPg.NoInvoiceResult().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(noinvresult.Contains("No Invoices Available"));
                SendPg.SentHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.StatusDeletedRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);


                SeleniumSetMethods.WaitOnPage(secdelay2);
                string paidstatushover11 = SendPg.HistoryDeletedStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover11.Contains("deleted"));
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                DateTime newDat1e = DateTime.Now;
                string dtString5 = newDat1e.ToString("dd/MM/yy");
                string invstatus = SIVPG1.InvoiceStatus().Text;
                string date = SIVPG1.InvoiceDetailsDateDeleted().Text;
                string who = SIVPG1.WhoDeletedInfo().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invstatus.Contains("DELETED") && date.Contains("Date Deleted") && date.Contains(dtString5) && who.Contains("billzyBiz-458320 deleted this invoice."));
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
        public void DeleteInvoice14_Payer_SIV_withoutDeal_UNPAID()
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
                loginPage.UserNameTextBox().SendKeys("madcowbillergst+DeleteInvoice01@gmail.com");
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
                IssueInvoicePg.BusinessName().SendKeys("madcowpayergst+DeleteInvoice01");
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
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("UNP-INV-@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SurchargeCheckbox().Click();

                //issueInvoice_issueInvoicePage_totalValue.checkValueContains = @amountGst
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");
                SeleniumSetMethods.WaitOnPage(secdelay5);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("UNP-INV-@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string invoicestatus = SIVPG1.InvoiceStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invoicestatus.Contains("UNPAID"));
                string invnumber = SIVPG1.InvNumber().Text;
                string invoicenumber = invnumber.Substring(invnumber.IndexOf("Invoice ")).Replace("Invoice ", "");
                
                SeleniumSetMethods.WaitOnPage(secdelay2);


                HomePg.SignOutBTN().Click();


                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowpayergst+DeleteInvoice01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invoicestatus1 = SIVPG1.InvoiceStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Assert.IsTrue(invoicestatus1.Contains("UNPAID"));
                
                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ActionDropdownDelete().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                DeleteInvoicePage Delpg = new DeleteInvoicePage(WebDriver);
                bool deletetitle = SIVPG1.DeleteModalTitle().Displayed;
                bool deloinvmsg = SIVPG1.DeleteInvoiceMessage().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(deletetitle == true && deloinvmsg == true);
                SIVPG1.ConfirmDeleteBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string errmsg = SIVPG1.Deleteerrmsg().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(errmsg.Contains("A comment of at least 30 characters is required"));
                SIVPG1.DeleteCancelBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ActionDropdownDelete().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.DeleteComment().SendKeys("Biller deleted");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ConfirmDeleteBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string errmsg2 = SIVPG1.Deleteerrmsg().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(errmsg2.Contains("A comment of at least 30 characters is required"));
                SIVPG1.DeleteCancelBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ActionDropdownDelete().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.DeleteComment().SendKeys("Biller deleted invoice with Unpaid status");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ConfirmDeleteBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay3);

                string noinv = Recpg.NoInvoiceResult().Text;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(noinv.Contains("No Invoices Available"));
                Recpg.ReceivedHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.StatusDeletedRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                String deletedmsg1 = Recpg.HistDeleteamount().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(deletedmsg1.Contains("Deleted"));
                string paidstatushover17 = Recpg.HistoryDeletedStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover17.Contains("deleted"));
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                DateTime newDat1e = DateTime.Now;
                string dtString4 = newDat1e.ToString("dd/MM/yy");
                string invstatus1 = SIVPG1.InvoiceStatus().Text;
                string date1 = SIVPG1.InvoiceDetailsDateDeleted().Text;
                string who1 = SIVPG1.WhoDeletedInfo().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invstatus1.Contains("DELETED") && date1.Contains("Date Deleted") && date1.Contains(dtString4) && who1.Contains("You deleted this invoice."));

                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowbillergst+DeleteInvoice01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                SendPg.SearchInvoiceSent().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string noinvresult = SendPg.NoInvoiceResult().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(noinvresult.Contains("No Invoices Available"));
                SendPg.SentHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.StatusDeletedRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);


                SeleniumSetMethods.WaitOnPage(secdelay2);
                string paidstatushover11 = SendPg.HistoryDeletedStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover11.Contains("deleted"));
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);


                string invstatus = SIVPG1.InvoiceStatus().Text;
                string date = SIVPG1.InvoiceDetailsDateDeleted().Text;
                string who = SIVPG1.WhoDeletedInfo().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invstatus.Contains("DELETED") && date.Contains("Date Deleted") && date.Contains(dtString4) && who.Contains("madcowpayergst+DeleteInvoice01 deleted this invoice."));



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
       
        
    }
}
