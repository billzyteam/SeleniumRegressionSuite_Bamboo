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
    class RegSuite_IssueInvoice_ExternalPayer_UploadInvoice : Tests
    {

        [Test]
        public void IssueInvoice01_ExternalPayer_UploadInvoice_GST_NoSurcharge()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+aagstbiller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay8);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                AddCustomerPage AddCustomerPg = new AddCustomerPage(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Random rand = new Random();
                DateTime dt = new DateTime();
                string dtString = dt.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber1 = rand.Next();
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BusinessName().SendKeys("External1");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "14 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.PdfUploadFileBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool gstmsg = IssueInvoicePg.GstValue().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(gstmsg == false);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));
                bool err1 = bodyTag.Text.Contains("Please upload a PDF File");
                bool err2 = bodyTag.Text.Contains("Invoice total must be greater than zero");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(err1 == true && err2 == true);
                IssueInvoicePg.PdfUploadFileBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.uploadPDF().SendKeys(@"C:\Users\Selenium\Desktop\SeleniumRegressionSuite_Bamboo\Invoice.pdf");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.UploadAmount().SendKeys("123.19");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.UploadInvRef().SendKeys("Ext-Inv@" + randnumber1);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                string subject = IssueInvoicePg.Subject().GetAttribute("value");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(subject.Contains("madcowtesting10+aagstbiller has sent you an invoice"));
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("Ext-Inv@" + randnumber1);
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

       /* [Test]
        public void IssueInvoice02_ExternalPayer_UploadInvoice_GST_Surcharge()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+aagstbiller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay8);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                AddCustomerPage AddCustomerPg = new AddCustomerPage(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Random rand = new Random();
                DateTime dt = new DateTime();
                string dtString = dt.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber1 = rand.Next();
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BusinessName().SendKeys("External1");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "90 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.PdfUploadFileBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool gstmsg = IssueInvoicePg.GstValue().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(gstmsg == false);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));
                bool err1 = bodyTag.Text.Contains("Please upload a PDF File");
                bool err2 = bodyTag.Text.Contains("Invoice total must be greater than zero");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(err1 == true && err2 == true);
                IssueInvoicePg.PdfUploadFileBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.uploadPDF().SendKeys(@"C:\Users\BillzyAdmin\Documents\Visual Studio 2019\Projects\BillzyAutomationTestSuite\Invoice.pdf");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.UploadAmount().SendKeys("123.19");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.UploadInvRef().SendKeys("Ext-Inv@" + randnumber1);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                string subject = IssueInvoicePg.Subject().GetAttribute("value");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(subject.Contains("madcowtesting10+aagstbiller has sent you an invoice"));
                IssueInvoicePg.Uploadsurcharge().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("Ext-Inv@" + randnumber1);
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

        [Test]
        public void IssueInvoice03_ExternalPayer_UploadInvoice_NoGST_NoSurcharge()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+aagstbiller@gmail.com");
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
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BusinessName().SendKeys("External1");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Random rand = new Random();
                DateTime dt = new DateTime();
                string dtString = dt.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber1 = rand.Next();
                String PaymentTerms = "14 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.PdfUploadFileBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool gstmsg = IssueInvoicePg.GstValue().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(gstmsg == false);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));
                bool err1 = bodyTag.Text.Contains("Please upload a PDF File");
                bool err2 = bodyTag.Text.Contains("Invoice total must be greater than zero");
                bool gstvalue = IssueInvoicePg.GstValue().Displayed;
                
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(err1 == true && err2 == true && gstvalue == false);
                IssueInvoicePg.PdfUploadFileBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.uploadPDF().SendKeys(@"C:\Users\BillzyAdmin\Documents\Visual Studio 2019\Projects\BillzyAutomationTestSuite\Invoice.pdf");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.UploadAmount().SendKeys("123.19");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.UploadInvRef().SendKeys("Ext-Inv@" + randnumber1);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                string subject = IssueInvoicePg.Subject().GetAttribute("value");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(subject.Contains("madcowtesting10+aagstbiller has sent you an invoice"));
                
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("Ext-Inv@" + randnumber1);
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

        

        [Test]
        public void IssueInvoice04_ExternalPayer_UploadInvoice_NoGST_Surcharge_EndOfNextMonth()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+aagstbiller@gmail.com");
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
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BusinessName().SendKeys("External1");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Random rand = new Random();
                DateTime dt = new DateTime();
                string dtString = dt.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber1 = rand.Next();
                String PaymentTerms = "End of next month";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.PdfUploadFileBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool gstmsg = IssueInvoicePg.GstValue().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(gstmsg == false);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));
                bool err1 = bodyTag.Text.Contains("Please upload a PDF File");
                bool err2 = bodyTag.Text.Contains("Invoice total must be greater than zero");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(err1 == true && err2 == true);
                IssueInvoicePg.PdfUploadFileBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.uploadPDF().SendKeys(@"C:\Users\BillzyAdmin\Documents\Visual Studio 2019\Projects\BillzyAutomationTestSuite\Invoice.pdf");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.UploadAmount().SendKeys("123.19");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.UploadInvRef().SendKeys("Ext-Inv@" + randnumber1);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                string subject = IssueInvoicePg.Subject().GetAttribute("value");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(subject.Contains("madcowtesting10+aagstbiller has sent you an invoice"));
                IssueInvoicePg.SurchargeCheckboxUpload().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("Ext-Inv@" + randnumber1);
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

*/       

    }
}
