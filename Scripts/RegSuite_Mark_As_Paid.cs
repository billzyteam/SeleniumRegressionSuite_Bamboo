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
    class RegSuite_Mark_As_Paid : Tests
    {

        [Test]
        public void InvoiceWithDeal01_GST_Surcharge_MarkAsPaid_Paid()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+amarkaspaidgstb01@gmail.com");
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
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+amarkaspaidgstp01");
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

                DateTime newDate = DateTime.Now.AddDays(15);
                string dtString3 = newDate.ToString("dd/MM/yyyy");
                string dtString4 = newDate.ToString("dd/MM/yy");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "30 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV-09@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                SeleniumSetMethods.WaitOnPage(secdelay1);
    


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
                SendPg.SearchInvoiceSent().SendKeys("INV-09@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber = SIVPG1.InvNumber().Text;
                string invoicenumber = invnumber.Substring(invnumber.IndexOf("Invoice ")).Replace("Invoice ", "");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+amarkaspaidgstp01@gmail.com");
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
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));
                bool siv2 = bodyTag.Text.Contains("Mark As Paid");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(siv2 == false);
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.ActionDropdown().Click();
                bool siv3 = bodyTag.Text.Contains("Mark As Paid");
                bool siv4  = bodyTag.Text.Contains("Delete");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(siv3 == false && siv4 == true);
                
                SIVPG1.ReturnBTN().Click();
                
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+amarkaspaidgstb01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
               
                SendPg.SearchInvoiceSent().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SendPg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                bool mark = SendPg.MarkAsPaidOption().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(mark == true);
                SendPg.MarkAsPaidOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string expirydays = SIVPG1.ExpiresXDays().Text;
                string xPercentDisc = SIVPG1.XPercentDisc().Text;
                string expiresDateAndTime = SIVPG1.ExpiresDateAndTime().Text;
                string offeredBy = SIVPG1.OfferedBy().Text;
                string commentsSIV = SIVPG1.CommentsSIV().Text;
                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag1 = WebDriver.FindElement(By.TagName("body"));
                SIVPG1.ActionDropdownMarkAsPaid().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool mark1 = SIVPG1.MarkAsPaidBTN().Displayed;
                bool mark2 = SIVPG1.MarkAsPaidCancelBTN().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(mark1 == true && mark2 == true);
                bool siv5 = bodyTag1.Text.Contains("This invoice will be considered paid and complete.");
                bool siv6 = bodyTag1.Text.Contains("Please ensure the invoice has been fully paid through other means first.");
                SIVPG1.MarkAsPaidBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SentOutstandingBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                
                SendPg.SearchInvoiceSent().SendKeys(invoicenumber);

                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool emptybox = SendPg.EmptyBoxIcon().Displayed;
                string noinv = SendPg.NoInvoiceResult().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                
                Assert.IsTrue(emptybox == true && noinv.Contains("No Invoices Available"));
                SendPg.SentPaidBTN().Click();
                IWebElement bodyTag11 = WebDriver.FindElement(By.TagName("body"));
                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool siv7 = bodyTag11.Text.Contains("Marked as paid");

                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(siv7 == true);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                IWebElement bodyTag111 = WebDriver.FindElement(By.TagName("body"));
                bool expirydays1 = bodyTag111.Text.Contains(expirydays);
                bool xPercentDisc1 = bodyTag111.Text.Contains(xPercentDisc);
                bool expiresDateAndTime1 = bodyTag111.Text.Contains(expiresDateAndTime);
                bool offeredBy1 = bodyTag111.Text.Contains(offeredBy);
                bool commentsSIV1 = bodyTag111.Text.Contains(commentsSIV);
                bool markmsg = bodyTag111.Text.Contains("You marked this invoice as paid.");
                
                bool surmsg = bodyTag111.Text.Contains("Incl. surcharge");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(markmsg == true &&  surmsg == true && expirydays1 == false && xPercentDisc1 == false );
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+amarkaspaidgstp01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                bool emptybox1 = Recpg.EmptyBoxIcon().Displayed;
                string noinv1= Recpg.NoInvoiceResult().Text;
                SeleniumSetMethods.WaitOnPage(secdelay5);

                Assert.IsTrue(emptybox1 == true && noinv1.Contains("No Invoices Available"));
                Recpg.ReceivedHistoryBTN().Click();
                IWebElement bodyTag22 = WebDriver.FindElement(By.TagName("body"));
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                bool siv8 = bodyTag22.Text.Contains("Marked as paid");

                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(siv8 == true);
                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invstatus = SIVPG1.InvoiceStatus().Text;
                bool markmsg1 = bodyTag22.Text.Contains("madcowtesting10+amarkaspaidgstb01 marked this invoice as paid.");
                
                bool surmsg1 = bodyTag22.Text.Contains("Incl. surcharge");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invstatus.Contains("PAID") && markmsg1 == true && surmsg1 == true);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
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
                SeleniumSetMethods.WaitOnPage(secdelay10);
                Bobopg.UpdateExistingBillzyInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.SelectBusiness().SendKeys("madcowtesting10+amarkaspaidgstb01");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.InputInvoice().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.SearchBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                IWebElement bodyTag2 = WebDriver.FindElement(By.TagName("body"));
                bool bobo1 = bodyTag2.Text.Contains("false");
                bool bobo2 = bodyTag2.Text.Contains("Unverified");
                bool bobo3 = bodyTag2.Text.Contains("PAID");
                bool bobo4 = bodyTag2.Text.Contains("351.8");
                bool bobo5 = bodyTag2.Text.Contains(invoicenumber);
                bool bobo6 = bodyTag2.Text.Contains("madcowtesting10+amarkaspaidgstb01");
                bool bobo7 = bodyTag2.Text.Contains("madcowtesting10+amarkaspaidgstp01");
                bool bobo8 = Bobopg.MarkAsPaidDisabled().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(bobo1 == true && bobo2 == true && bobo3 == true && bobo4 == true && bobo5 == true && bobo6 == true && bobo7 == true && bobo8 == true );

            }
            finally
            {
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay4);
             
            }
        }

        [Test]
        public void InvoiceWithDeal02_NoGST_Surcharge_MarkAsPaid_Paid()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+amarkaspaidnogstb01@gmail.com");
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
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+amarkaspaidnogstp01");
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

                DateTime newDate = DateTime.Now.AddDays(15);
                string dtString3 = newDate.ToString("dd/MM/yyyy");
                string dtString4 = newDate.ToString("dd/MM/yy");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "30 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV-09@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                SeleniumSetMethods.WaitOnPage(secdelay1);



                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer excluding GST");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.NewTotal().SendKeys("300.00");
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
                SendPg.SearchInvoiceSent().SendKeys("INV-09@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber = SIVPG1.InvNumber().Text;
                string invoicenumber = invnumber.Substring(invnumber.IndexOf("Invoice ")).Replace("Invoice ", "");
                SeleniumSetMethods.WaitOnPage(secdelay2);
             
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string expirydays = SIVPG1.ExpiresXDays().Text;
                string xPercentDisc = SIVPG1.XPercentDisc().Text;
               
                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag1 = WebDriver.FindElement(By.TagName("body"));
                SIVPG1.ActionDropdownMarkAsPaid().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool mark1 = SIVPG1.MarkAsPaidBTN().Displayed;
                bool mark2 = SIVPG1.MarkAsPaidCancelBTN().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(mark1 == true && mark2 == true);
                bool siv5 = bodyTag1.Text.Contains("This invoice will be considered paid and complete.");
                bool siv6 = bodyTag1.Text.Contains("Please ensure the invoice has been fully paid through other means first.");
                SIVPG1.MarkAsPaidBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SentOutstandingBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                SendPg.SearchInvoiceSent().SendKeys(invoicenumber);

                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool emptybox = SendPg.EmptyBoxIcon().Displayed;
                string noinv = SendPg.NoInvoiceResult().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);

                Assert.IsTrue(emptybox == true && noinv.Contains("No Invoices Available"));
                SendPg.SentPaidBTN().Click();
                IWebElement bodyTag11 = WebDriver.FindElement(By.TagName("body"));
                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool siv7 = bodyTag11.Text.Contains("Marked as paid");

                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(siv7 == true);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                IWebElement bodyTag111 = WebDriver.FindElement(By.TagName("body"));
                bool expirydays1 = bodyTag111.Text.Contains(expirydays);
                bool xPercentDisc1 = bodyTag111.Text.Contains(xPercentDisc);
             
                bool markmsg = bodyTag111.Text.Contains("You marked this invoice as paid.");

                bool surmsg = bodyTag111.Text.Contains("Incl. surcharge");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(markmsg == true && surmsg == true && expirydays1 == false && xPercentDisc1 == false);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+amarkaspaidnogstp01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                bool emptybox1 = Recpg.EmptyBoxIcon().Displayed;
                string noinv1 = Recpg.NoInvoiceResult().Text;
                SeleniumSetMethods.WaitOnPage(secdelay5);

                Assert.IsTrue(emptybox1 == true && noinv1.Contains("No Invoices Available"));
                Recpg.ReceivedHistoryBTN().Click();
                IWebElement bodyTag22 = WebDriver.FindElement(By.TagName("body"));
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                bool siv8 = bodyTag22.Text.Contains("Marked as paid");

                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(siv8 == true);
                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invstatus = SIVPG1.InvoiceStatus().Text;
                bool markmsg1 = bodyTag22.Text.Contains("madcowtesting10+amarkaspaidnogstb01 marked this invoice as paid.");

                bool surmsg1 = bodyTag22.Text.Contains("Incl. surcharge");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invstatus.Contains("PAID") && markmsg1 == true && surmsg1 == true);
               

            }
            finally
            {
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay4);

            }
        }

        [Test]
        public void InvoiceWithoutDeal03_NoGST_NoSurcharge_MarkAsPaid()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+amarkaspaidnogstb01@gmail.com");
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
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+amarkaspaidnogstp01");
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

                DateTime newDate = DateTime.Now.AddDays(15);
                string dtString3 = newDate.ToString("dd/MM/yyyy");
                string dtString4 = newDate.ToString("dd/MM/yy");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "60 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV-09@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                SeleniumSetMethods.WaitOnPage(secdelay1);



                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer excluding GST");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Console.WriteLine("InvoiceCreated");
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INV-09@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber = SIVPG1.InvNumber().Text;
                string invoicenumber = invnumber.Substring(invnumber.IndexOf("Invoice ")).Replace("Invoice ", "");
                SeleniumSetMethods.WaitOnPage(secdelay2);



                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag1 = WebDriver.FindElement(By.TagName("body"));
                SIVPG1.ActionDropdownMarkAsPaid().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool mark1 = SIVPG1.MarkAsPaidBTN().Displayed;
                bool mark2 = SIVPG1.MarkAsPaidCancelBTN().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(mark1 == true && mark2 == true);
                bool siv5 = bodyTag1.Text.Contains("This invoice will be considered paid and complete.");
                bool siv6 = bodyTag1.Text.Contains("Please ensure the invoice has been fully paid through other means first.");
                SIVPG1.MarkAsPaidBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SentOutstandingBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                SendPg.SearchInvoiceSent().SendKeys(invoicenumber);

                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool emptybox = SendPg.EmptyBoxIcon().Displayed;
                string noinv = SendPg.NoInvoiceResult().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);

                Assert.IsTrue(emptybox == true && noinv.Contains("No Invoices Available"));
                SendPg.SentPaidBTN().Click();
                IWebElement bodyTag11 = WebDriver.FindElement(By.TagName("body"));
                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool siv7 = bodyTag11.Text.Contains("Marked as paid");

                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(siv7 == true);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                IWebElement bodyTag111 = WebDriver.FindElement(By.TagName("body"));

  
                bool markmsg = bodyTag111.Text.Contains("You marked this invoice as paid.");

                bool surmsg = bodyTag111.Text.Contains("Incl. surcharge");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(markmsg == true && surmsg == false );
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+amarkaspaidnogstp01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                bool emptybox1 = Recpg.EmptyBoxIcon().Displayed;
                string noinv1 = Recpg.NoInvoiceResult().Text;
                SeleniumSetMethods.WaitOnPage(secdelay5);

                Assert.IsTrue(emptybox1 == true && noinv1.Contains("No Invoices Available"));
                Recpg.ReceivedHistoryBTN().Click();
                IWebElement bodyTag22 = WebDriver.FindElement(By.TagName("body"));
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                bool siv8 = bodyTag22.Text.Contains("Marked as paid");

                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(siv8 == true);
                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invstatus = SIVPG1.InvoiceStatus().Text;
                bool markmsg1 = bodyTag22.Text.Contains("madcowtesting10+amarkaspaidnogstb01 marked this invoice as paid.");

                bool surmsg1 = bodyTag22.Text.Contains("Incl. surcharge");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invstatus.Contains("PAID") && markmsg1 == true && surmsg1 == false);


            }
            finally
            {
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay4);

            }
        }
        [Test]
        public void InvoiceWithoutDeal04_GST_NoSurcharge_MarkAsPaid()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+amarkaspaidgstb01@gmail.com");
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
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+amarkaspaidgstp01");
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

                DateTime newDate = DateTime.Now.AddDays(15);
                string dtString3 = newDate.ToString("dd/MM/yyyy");
                string dtString4 = newDate.ToString("dd/MM/yy");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "60 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV-09@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                SeleniumSetMethods.WaitOnPage(secdelay1);



                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer excluding GST");
                SeleniumSetMethods.WaitOnPage(secdelay1);

                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Console.WriteLine("InvoiceCreated");
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INV-09@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber = SIVPG1.InvNumber().Text;
                string invoicenumber = invnumber.Substring(invnumber.IndexOf("Invoice ")).Replace("Invoice ", "");
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag1 = WebDriver.FindElement(By.TagName("body"));
                SIVPG1.ActionDropdownMarkAsPaid().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool mark1 = SIVPG1.MarkAsPaidBTN().Displayed;
                bool mark2 = SIVPG1.MarkAsPaidCancelBTN().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(mark1 == true && mark2 == true);
                bool siv5 = bodyTag1.Text.Contains("This invoice will be considered paid and complete.");
                bool siv6 = bodyTag1.Text.Contains("Please ensure the invoice has been fully paid through other means first.");
                SIVPG1.MarkAsPaidBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SentOutstandingBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                SendPg.SearchInvoiceSent().SendKeys(invoicenumber);

                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool emptybox = SendPg.EmptyBoxIcon().Displayed;
                string noinv = SendPg.NoInvoiceResult().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);

                Assert.IsTrue(emptybox == true && noinv.Contains("No Invoices Available"));
                SendPg.SentPaidBTN().Click();
                IWebElement bodyTag11 = WebDriver.FindElement(By.TagName("body"));
                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool siv7 = bodyTag11.Text.Contains("Marked as paid");

                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(siv7 == true);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                IWebElement bodyTag111 = WebDriver.FindElement(By.TagName("body"));
    
                bool markmsg = bodyTag111.Text.Contains("You marked this invoice as paid.");

                bool surmsg = bodyTag111.Text.Contains("Incl. surcharge");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(markmsg == true && surmsg == false );
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+amarkaspaidgstp01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                bool emptybox1 = Recpg.EmptyBoxIcon().Displayed;
                string noinv1 = Recpg.NoInvoiceResult().Text;
                SeleniumSetMethods.WaitOnPage(secdelay5);

                Assert.IsTrue(emptybox1 == true && noinv1.Contains("No Invoices Available"));
                Recpg.ReceivedHistoryBTN().Click();
                IWebElement bodyTag22 = WebDriver.FindElement(By.TagName("body"));
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                bool siv8 = bodyTag22.Text.Contains("Marked as paid");

                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(siv8 == true);
                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invstatus = SIVPG1.InvoiceStatus().Text;
                bool markmsg1 = bodyTag22.Text.Contains("madcowtesting10+amarkaspaidgstb01 marked this invoice as paid.");

                bool surmsg1 = bodyTag22.Text.Contains("Incl. surcharge");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invstatus.Contains("PAID") && markmsg1 == true && surmsg1 == false);


            }
            finally
            {
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay4);

            }
        }

        [Test]
        public void InvoiceWithoutDeal05_JLLPayer_NoSurcharge_MarkAsPaid_3Invs()
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
                loginPage.UserNameTextBox().SendKeys("rafie00+JLLBiller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay8);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);

                //IssueInvoice #1
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("JLLPayer");
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
                DateTime newDate = DateTime.Now.AddDays(60);
                string dtString3 = newDate.ToString("dd/MM/yyyy");
                string dtString4 = newDate.ToString("dd/MM/yy");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "60 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV-01@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.LineItemAmount().SendKeys("100.00");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer excluding GST");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Console.WriteLine("InvoiceCreated");
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INV-01@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber = SIVPG1.InvNumber().Text;
                string invoicenumber1 = invnumber.Substring(invnumber.IndexOf("Invoice ")).Replace("Invoice ", "");
                SeleniumSetMethods.WaitOnPage(secdelay2);

                //IssueInvoice #2
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("JLLPayer");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV-02@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.LineItemAmount().SendKeys("150.00");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer excluding GST");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Console.WriteLine("InvoiceCreated");
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INV-02@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber2 = SIVPG1.InvNumber().Text;
                string invoicenumber2 = invnumber2.Substring(invnumber2.IndexOf("Invoice ")).Replace("Invoice ", "");
                SeleniumSetMethods.WaitOnPage(secdelay2);

                //IssueInvoice #3
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("JLLPayer");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV-03@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.LineItemAmount().SendKeys("180.00");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer excluding GST");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Console.WriteLine("InvoiceCreated");
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INV-03@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber3 = SIVPG1.InvNumber().Text;
                string invoicenumber3 = invnumber3.Substring(invnumber3.IndexOf("Invoice ")).Replace("Invoice ", "");
                SeleniumSetMethods.WaitOnPage(secdelay2);

                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("rafie00+JLLPayer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber1);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool markaspaid = Recpg.MarkAsPaidOptionJLL().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(markaspaid == true);
                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool markaspaid1 = SIVPG1.ActionDropdownMarkAsPaid().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(markaspaid1 == false);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
               Recpg.MarkAsPaidOptionJLL().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                Recpg.SearchInvoiceReceived().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.MarkAsPaidOptionJLL().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                Recpg.SearchInvoiceReceived().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber3);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.MarkAsPaidOptionJLL().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                Recpg.ReceivedHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber1);
                SeleniumSetMethods.WaitOnPage(secdelay10);
                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));
                bool mark = bodyTag.Text.Contains("You marked this invoice as paid.");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(mark == true);
                SIVPG1.ReturnBTN().Click();

                Recpg.SearchInvoiceReceived().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber2);
                SeleniumSetMethods.WaitOnPage(secdelay10);
                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                
                bool mark1 = bodyTag.Text.Contains("You marked this invoice as paid.");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(mark1 == true);
                SIVPG1.ReturnBTN().Click();

                Recpg.SearchInvoiceReceived().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber3);
                SeleniumSetMethods.WaitOnPage(secdelay10);
                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                bool mark2 = bodyTag.Text.Contains("You marked this invoice as paid.");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(mark2 == true);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();

                SeleniumSetMethods.WaitOnPage(secdelay3);
                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("rafie00+JLLBiller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SentHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                SendPg.SearchInvoiceSent().SendKeys(invoicenumber1);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string amount = SendPg.SentAmountColumnRow01().Text;
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Assert.IsTrue(amount.Contains("Marked as paid"));
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                IWebElement bodyTag2 = WebDriver.FindElement(By.TagName("body"));
                bool mark3 = bodyTag2.Text.Contains("JLLPayer marked this invoice as paid.");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(mark3 == true);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys(invoicenumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string amount2 = SendPg.SentAmountColumnRow01().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(amount2.Contains("Marked as paid"));
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                bool mark4 = bodyTag2.Text.Contains("JLLPayer marked this invoice as paid.");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(mark4 == true);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys(invoicenumber3);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string amount3 = SendPg.SentAmountColumnRow01().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(amount3.Contains("Marked as paid"));
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                bool mark5 = bodyTag2.Text.Contains("JLLPayer marked this invoice as paid.");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(mark5 == true);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);


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
        public void InvoiceWithDeal06_JLLPayer_MarkAsPaid()
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
                loginPage.UserNameTextBox().SendKeys("rafie00+JLLBiller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay8);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);

                //IssueInvoice #1
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("JLLPayer");
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
                DateTime newDate = DateTime.Now.AddDays(15);
                string dtString3 = newDate.ToString("dd/MM/yyyy");
                string dtString4 = newDate.ToString("dd/MM/yy");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "30 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV-JLL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer excluding GST");
                SeleniumSetMethods.WaitOnPage(secdelay1);

                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.NewTotal().SendKeys("285.82");
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
                SendPg.SearchInvoiceSent().SendKeys("INV-JLL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber = SIVPG1.InvNumber().Text;
                string invoicenumber1 = invnumber.Substring(invnumber.IndexOf("Invoice ")).Replace("Invoice ", "");
                SeleniumSetMethods.WaitOnPage(secdelay2);

                

                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("rafie00+JLLPayer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber1);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool markaspaid = Recpg.MarkAsPaidOptionJLL().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(markaspaid == true);
                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool markaspaid1 = SIVPG1.ActionDropdownMarkAsPaid().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(markaspaid1 == false);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.MarkAsPaidOptionJLL().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                

                Recpg.ReceivedHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber1);
                SeleniumSetMethods.WaitOnPage(secdelay10);
                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));
                bool mark = bodyTag.Text.Contains("You marked this invoice as paid.");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(mark == true);
                SIVPG1.ReturnBTN().Click();

                
                HomePg.SignOutBTN().Click();

                SeleniumSetMethods.WaitOnPage(secdelay3);
                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("rafie00+JLLBiller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SentHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                SendPg.SearchInvoiceSent().SendKeys(invoicenumber1);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string amount = SendPg.SentAmountColumnRow01().Text;
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Assert.IsTrue(amount.Contains("Marked as paid"));
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                IWebElement bodyTag2 = WebDriver.FindElement(By.TagName("body"));
                bool mark3 = bodyTag2.Text.Contains("JLLPayer marked this invoice as paid.");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(mark3 == true);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                


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
