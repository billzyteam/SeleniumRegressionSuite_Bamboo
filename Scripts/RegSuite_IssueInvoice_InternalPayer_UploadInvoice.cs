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
    class RegSuite_IssueInvoice_InternalPayer_UploadInvoice : Tests
    {
        [Test]
        public void IssueInvoice01_InternalPayer_UploadInvoice_GST_Deal_NoSurcharge()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+IntPayUploadInvGST@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay8);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));
                AddCustomerPage AddCustomerPg = new AddCustomerPage(WebDriver);
                Random rand = new Random();
                DateTime dt = new DateTime();
                string dtString = dt.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber1 = rand.Next();
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+A");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "30 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.PdfUploadFileBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.uploadPDF().SendKeys(@"C:\Users\BillzyAdmin\Documents\Visual Studio 2019\Projects\BillzyAutomationTestSuite\Invoice.pdf");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.UploadAmount().SendKeys("900.90");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.UploadInvRef().SendKeys("Int-Inv@" + randnumber1);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                string subject = IssueInvoicePg.Subject().GetAttribute("value");
                string TotalGSTMsg = IssueInvoicePg.TotalGSTMsg().Text;
                string TotalValue = IssueInvoicePg.TotalValue().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(subject.Contains("madcowtesting10+IntPayUploadInvGST has sent you an invoice"));
                DateTime duedate2 = DateTime.Today.AddDays(30);
                string SentPgDueDate3 = duedate2.ToString("dd MMM yy");
                string SentPgDueDate33 = duedate2.ToString("dd/MM/yyyy");
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.NewTotal().SendKeys("777.12");
                IWebElement bodyTag1 = WebDriver.FindElement(By.TagName("body"));
                bool disc1 = bodyTag1.Text.Contains("13.74% discount");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(disc1 == true);
                bool disc2 = bodyTag1.Text.Contains("Due in 30 days");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(disc2 == true);
                //IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("Int-Inv@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string due11 = SendPg.DueRow01().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(due11.Contains(SentPgDueDate3));
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

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
        public void IssueInvoice02_InternalPayer_UploadInvoice_GST_Deal_Surcharge()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+IntPayUploadInvGST@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay8);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));
                AddCustomerPage AddCustomerPg = new AddCustomerPage(WebDriver);
                Random rand = new Random();
                DateTime dt = new DateTime();
                string dtString = dt.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber1 = rand.Next();
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+A");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "30 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.PdfUploadFileBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.uploadPDF().SendKeys(@"C:\Users\BillzyAdmin\Documents\Visual Studio 2019\Projects\BillzyAutomationTestSuite\Invoice.pdf");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.UploadAmount().SendKeys("900.90");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.UploadInvRef().SendKeys("Int-Inv@" + randnumber1);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                string subject = IssueInvoicePg.Subject().GetAttribute("value");
                string TotalGSTMsg = IssueInvoicePg.TotalGSTMsg().Text;
                string TotalValue = IssueInvoicePg.TotalValue().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(subject.Contains("madcowtesting10+IntPayUploadInvGST has sent you an invoice"));
                DateTime duedate2 = DateTime.Today.AddDays(30);
                string SentPgDueDate3 = duedate2.ToString("dd MMM yy");
                string SentPgDueDate33 = duedate2.ToString("dd/MM/yyyy");
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.NewTotal().SendKeys("777.12");
                IWebElement bodyTag1 = WebDriver.FindElement(By.TagName("body"));
                bool disc1 = bodyTag1.Text.Contains("13.74% discount");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(disc1 == true);
                bool disc2 = bodyTag1.Text.Contains("Due in 30 days");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(disc2 == true);
                IssueInvoicePg.Uploadsurcharge().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("Int-Inv@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string due11 = SendPg.DueRow01().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(due11.Contains(SentPgDueDate3));
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

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
        public void IssueInvoice03_InternalPayer_UploadInvoice_GST_NoDeal_NoSurcharge()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+IntPayUploadInvGST@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay8);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));
                AddCustomerPage AddCustomerPg = new AddCustomerPage(WebDriver);
                Random rand = new Random();
                DateTime dt = new DateTime();
                string dtString = dt.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber1 = rand.Next();
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+A");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "30 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.PdfUploadFileBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.uploadPDF().SendKeys(@"C:\Users\BillzyAdmin\Documents\Visual Studio 2019\Projects\BillzyAutomationTestSuite\Invoice.pdf");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.UploadAmount().SendKeys("900.90");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.UploadInvRef().SendKeys("Int-Inv@" + randnumber1);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                string subject = IssueInvoicePg.Subject().GetAttribute("value");
                string TotalGSTMsg = IssueInvoicePg.TotalGSTMsg().Text;
                string TotalValue = IssueInvoicePg.TotalValue().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(subject.Contains("madcowtesting10+IntPayUploadInvGST has sent you an invoice"));
                DateTime duedate2 = DateTime.Today.AddDays(30);
                string SentPgDueDate3 = duedate2.ToString("dd MMM yy");
                string SentPgDueDate33 = duedate2.ToString("dd/MM/yyyy");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                
                //IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("Int-Inv@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string due11 = SendPg.DueRow01().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(due11.Contains(SentPgDueDate3));
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

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
        public void IssueInvoice04_InternalPayer_UploadInvoice_GST_NoDeal_Surcharge()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+IntPayUploadInvGST@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay8);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));
                AddCustomerPage AddCustomerPg = new AddCustomerPage(WebDriver);
                Random rand = new Random();
                DateTime dt = new DateTime();
                string dtString = dt.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber1 = rand.Next();
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+A");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "30 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.PdfUploadFileBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.uploadPDF().SendKeys(@"C:\Users\BillzyAdmin\Documents\Visual Studio 2019\Projects\BillzyAutomationTestSuite\Invoice.pdf");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.UploadAmount().SendKeys("900.90");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.UploadInvRef().SendKeys("Int-Inv@" + randnumber1);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                string subject = IssueInvoicePg.Subject().GetAttribute("value");
                string TotalGSTMsg = IssueInvoicePg.TotalGSTMsg().Text;
                string TotalValue = IssueInvoicePg.TotalValue().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(subject.Contains("madcowtesting10+IntPayUploadInvGST has sent you an invoice"));
                DateTime duedate2 = DateTime.Today.AddDays(30);
                string SentPgDueDate3 = duedate2.ToString("dd MMM yy");
                string SentPgDueDate33 = duedate2.ToString("dd/MM/yyyy");
                SeleniumSetMethods.WaitOnPage(secdelay2);

                IssueInvoicePg.Uploadsurcharge().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("Int-Inv@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string due11 = SendPg.DueRow01().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(due11.Contains(SentPgDueDate3));
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

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
        public void IssueInvoice05_InternalPayer_UploadInvoice_NoGST_Deal_NoSurcharge()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+IntPayUploadInvNoGST@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay8);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));
                AddCustomerPage AddCustomerPg = new AddCustomerPage(WebDriver);
                Random rand = new Random();
                DateTime dt = new DateTime();
                string dtString = dt.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber1 = rand.Next();
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+A");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "30 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.PdfUploadFileBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.uploadPDF().SendKeys(@"C:\Users\BillzyAdmin\Documents\Visual Studio 2019\Projects\BillzyAutomationTestSuite\Invoice.pdf");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.UploadAmount().SendKeys("900.90");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.UploadInvRef().SendKeys("Int-Inv@" + randnumber1);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                string subject = IssueInvoicePg.Subject().GetAttribute("value");
                string TotalGSTMsg = IssueInvoicePg.TotalGSTMsg().Text;
                string TotalValue = IssueInvoicePg.TotalValue().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(subject.Contains("madcowtesting10+IntPayUploadInvNoGST has sent you an invoice"));
                DateTime duedate2 = DateTime.Today.AddDays(30);
                string SentPgDueDate3 = duedate2.ToString("dd MMM yy");
                string SentPgDueDate33 = duedate2.ToString("dd/MM/yyyy");
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.NewTotal().SendKeys("777.12");
                IWebElement bodyTag1 = WebDriver.FindElement(By.TagName("body"));
                bool disc1 = bodyTag1.Text.Contains("13.74% discount");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(disc1 == true);
                bool disc2 = bodyTag1.Text.Contains("Due in 30 days");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(disc2 == true);
                //IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("Int-Inv@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string due11 = SendPg.DueRow01().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(due11.Contains(SentPgDueDate3));
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

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
        public void IssueInvoice06_InternalPayer_UploadInvoice_NoGST_Deal_Surcharge()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+IntPayUploadInvNoGST@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay8);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));
                AddCustomerPage AddCustomerPg = new AddCustomerPage(WebDriver);
                Random rand = new Random();
                DateTime dt = new DateTime();
                string dtString = dt.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber1 = rand.Next();
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+A");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "30 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.PdfUploadFileBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.uploadPDF().SendKeys(@"C:\Users\BillzyAdmin\Documents\Visual Studio 2019\Projects\BillzyAutomationTestSuite\Invoice.pdf");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.UploadAmount().SendKeys("900.90");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.UploadInvRef().SendKeys("Int-Inv@" + randnumber1);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                string subject = IssueInvoicePg.Subject().GetAttribute("value");
                string TotalGSTMsg = IssueInvoicePg.TotalGSTMsg().Text;
                string TotalValue = IssueInvoicePg.TotalValue().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(subject.Contains("madcowtesting10+IntPayUploadInvNoGST has sent you an invoice"));
                DateTime duedate2 = DateTime.Today.AddDays(30);
                string SentPgDueDate3 = duedate2.ToString("dd MMM yy");
                string SentPgDueDate33 = duedate2.ToString("dd/MM/yyyy");
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.NewTotal().SendKeys("777.12");
                IWebElement bodyTag1 = WebDriver.FindElement(By.TagName("body"));
                bool disc1 = bodyTag1.Text.Contains("13.74% discount");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(disc1 == true);
                bool disc2 = bodyTag1.Text.Contains("Due in 30 days");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(disc2 == true);
                IssueInvoicePg.Uploadsurcharge().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("Int-Inv@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string due11 = SendPg.DueRow01().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(due11.Contains(SentPgDueDate3));
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

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
        public void IssueInvoice07_InternalPayer_UploadInvoice_NoGST_NoDeal_NoSurcharge()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+intpayuploadinvnogst@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay8);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));
                AddCustomerPage AddCustomerPg = new AddCustomerPage(WebDriver);
                Random rand = new Random();
                DateTime dt = new DateTime();
                string dtString = dt.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber1 = rand.Next();
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+A");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "30 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.PdfUploadFileBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.uploadPDF().SendKeys(@"C:\Users\BillzyAdmin\Documents\Visual Studio 2019\Projects\BillzyAutomationTestSuite\Invoice.pdf");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.UploadAmount().SendKeys("1212.11");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.UploadInvRef().SendKeys("Int-Inv@" + randnumber1);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                string subject = IssueInvoicePg.Subject().GetAttribute("value");
                string TotalGSTMsg = IssueInvoicePg.TotalGSTMsg().Text;
                string TotalValue = IssueInvoicePg.TotalValue().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(subject.Contains("madcowtesting10+IntPayUploadInvNoGST has sent you an invoice"));
                DateTime duedate2 = DateTime.Today.AddDays(30);
                string SentPgDueDate3 = duedate2.ToString("dd MMM yy");
                string SentPgDueDate33 = duedate2.ToString("dd/MM/yyyy");
                //IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("Int-Inv@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string due11 = SendPg.DueRow01().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(due11.Contains(SentPgDueDate3));
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

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
        public void IssueInvoice08_InternalPayer_UploadInvoice_NoGST_NoDeal_Surcharge()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+intpayuploadinvnogst@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay8);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));
                AddCustomerPage AddCustomerPg = new AddCustomerPage(WebDriver);
                Random rand = new Random();
                DateTime dt = new DateTime();
                string dtString = dt.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber1 = rand.Next();
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+A");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "30 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.PdfUploadFileBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.uploadPDF().SendKeys(@"C:\Users\BillzyAdmin\Documents\Visual Studio 2019\Projects\BillzyAutomationTestSuite\Invoice.pdf");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.UploadAmount().SendKeys("1212.11");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.UploadInvRef().SendKeys("Int-Inv@" + randnumber1);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                string subject = IssueInvoicePg.Subject().GetAttribute("value");
                string TotalGSTMsg = IssueInvoicePg.TotalGSTMsg().Text;
                string TotalValue = IssueInvoicePg.TotalValue().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(subject.Contains("madcowtesting10+IntPayUploadInvNoGST has sent you an invoice"));
                DateTime duedate2 = DateTime.Today.AddDays(30);
                string SentPgDueDate3 = duedate2.ToString("dd MMM yy");
                string SentPgDueDate33 = duedate2.ToString("dd/MM/yyyy");
                IssueInvoicePg.Uploadsurcharge().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("Int-Inv@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string due11 = SendPg.DueRow01().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(due11.Contains(SentPgDueDate3));
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

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
        public void IssueInvoice09_InternalPayer_UploadInvoice_NoGST_NoDeal_Surcharge_EndofNextMonth()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+intpayuploadinvnogst@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay8);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));
                AddCustomerPage AddCustomerPg = new AddCustomerPage(WebDriver);
                Random rand = new Random();
                DateTime dt = new DateTime();
                string dtString = dt.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber1 = rand.Next();
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+A");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "End of next month";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.PdfUploadFileBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.uploadPDF().SendKeys(@"C:\Users\BillzyAdmin\Documents\Visual Studio 2019\Projects\BillzyAutomationTestSuite\Invoice.pdf");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.UploadAmount().SendKeys("1212.11");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.UploadInvRef().SendKeys("Int-Inv@" + randnumber1);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                string subject = IssueInvoicePg.Subject().GetAttribute("value");
                string TotalGSTMsg = IssueInvoicePg.TotalGSTMsg().Text;
                string TotalValue = IssueInvoicePg.TotalValue().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(subject.Contains("madcowtesting10+IntPayUploadInvNoGST has sent you an invoice"));
                DateTime duedate2 = DateTime.Today.AddDays(30);
                string SentPgDueDate3 = duedate2.ToString("dd MMM yy");
                string SentPgDueDate33 = duedate2.ToString("dd/MM/yyyy");
                IssueInvoicePg.Uploadsurcharge().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("Int-Inv@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

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
