using System;
using System.IO;
using System.Net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using BillzyAutomationTestSuite;
using BillzyAutomationTestSuite.PageObjects;
using BillzyAutomationTestSuite.Scripts;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace BillzyAutomationTestSuite.Scripts
{
    [TestFixture]
    [Parallelizable]
    class RegSuite_ManualTestScenarios : Tests
    {

        [Test]
        public void ManualTest01_IssueInvoice01_EmailVerification_InternalPayer()
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
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+gstbiller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);

                //Issue Invoice - Webapp - Create Invoice
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("manualtestdemob+gstpayer");
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
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVINTMTCI@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("1500.00");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Console.WriteLine("InvoiceCreated");
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPage SendPg = new SendPage(WebDriver);
                SendPg.SentOutstandingBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVINTMTCI@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                //Issue Invoice - Webapp - Upload Invoice
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("manualtestdemob+gstpayer");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.PdfUploadFileBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.uploadPDF().SendKeys(@"C:\Users\BillzyAdmin\Documents\Visual Studio 2019\Projects\BillzyAutomationTestSuite\Invoice.pdf");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.UploadAmount().SendKeys("900.90");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.UploadInvRef().SendKeys("INVINTMTUI@" + randnumber2);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.UploadSurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Console.WriteLine("InvoiceCreated");
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SentOutstandingBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVINTMTUI@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);


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
                SeleniumSetMethods.WaitOnPage(secdelay10);
                string textcheck = Bobopg.UserWelcomeMessage().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(textcheck.Contains("Welcome, madcowbiller+bobo_02@gmail.com"));
                Bobopg.BillzyBiller().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);


                //Issue Invoice - BOBO CONNECT - Create Invoice
                //Bobopg.IssueAnInvoice().Click();
                //SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.BillzyBiller().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.IssueInvoiceOnBehalfOf().SendKeys("manualtestdemob+gstbiller");
                SeleniumSetMethods.WaitOnPage(secdelay7);
                Bobopg.IssueInvoiceTo().SendKeys("b. - manualtestdemob+gstpayer");
                SeleniumSetMethods.WaitOnPage(secdelay7);
                DateTime newDate = DateTime.Now.AddDays(60);
                string Invduedate = newDate.ToString("dd/MM/yyyy");
                string Invduedate1 = newDate.ToString("dd MMM yy");
                string Invduedate2 = newDate.ToString("dd/MM/yy");
                DateTime newDate1 = DateTime.Now;
                string Issuedate = newDate1.ToString("dd/MM/yyyy");
               // Bobopg.EmailTo().SendKeys("manualtestdemob+gstpayer@gmail.com");
                Bobopg.Reference().SendKeys("INVINTMTBOBO@" + randnumber2);
                Bobopg.InvoiceDueDate().SendKeys(Invduedate);
                Bobopg.InvoiceIssueDate().SendKeys(Issuedate);
                Bobopg.TotalAmount().SendKeys("100.00");
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.Surcharge().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.RequestCash().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.PdfUpload().SendKeys(@"C:\Users\BillzyAdmin\OneDrive - Billzy\BillzyTestSuite\BillzyAutomationTestSuite\Invoice.pdf");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.Issue().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                string message2 = Bobopg.Message().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(message2.Contains("Invoice has been created"));
                Bobopg.OKBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);

                //Issue Invoice - BOBO CONNECT - TPB (INBOX) - Create Invoice
                Bobopg.ThirdPartyBiller().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.IssueInvoiceOnBehalfOfTPB().SendKeys("TPB_NewBiller@1621732626 - BSB: 650001 - AccountNumber: 123456");
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.IssueInvoiceToTPB().SendKeys("raffy2@demo.billzyinbox.com - Billzy Inbox 03");
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.EmailToTPB().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.EmailToTPB().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.EmailToTPB().SendKeys("manualtestdemob@gmail.com");
                Bobopg.ReferenceTPB().SendKeys("INVINTMTINBOX@" + randnumber2);
                Bobopg.InvoiceDueDateTPB().SendKeys(Invduedate);
                Bobopg.InvoiceIssueDateTPB().SendKeys(Issuedate);
                Bobopg.TotalAmountTPB().SendKeys("150.66");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.PdfUploadTPB().SendKeys(@"C:\Users\BillzyAdmin\OneDrive - Billzy\BillzyTestSuite\BillzyAutomationTestSuite\Invoice.pdf");
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.IssueTPB().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                string message3 = Bobopg.Message().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(message3.Contains("Invoice has been created"));
                Bobopg.OKBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                SeleniumSetMethods.WaitOnPage(secdelay4);
                
                //Verifying the Emails and PDF

                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://accounts.google.com/signin/v2/identifier?service=mail&passive=true&rm=false&continue=https%3A%2F%2Fmail.google.com%2Fmail%2F&ss=1&scc=1&ltmpl=default&ltmplcache=2&emr=1&osid=1&flowName=GlifWebSignIn&flowEntry=ServiceLogin");

                GMAILPage gmailpg = new GMAILPage(WebDriver);
                
                DateTime duedate1 = DateTime.Today.AddDays(90);
                string SentPgDueDate = duedate1.ToString("dd MMM yyyy");
                gmailpg.Username().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Username().SendKeys("manualtestdemob@gmail.com");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.UserNext().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                gmailpg.Password().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.PasswordNext().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                gmailpg.Search().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Search().SendKeys("Invoice reference : INVINTMTCI@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                gmailpg.SearchButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool logo = gmailpg.logo().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(logo == true);
                IWebElement bodyTag1 = WebDriver.FindElement(By.TagName("body"));
                bool Content1 = bodyTag1.Text.Contains("Dear manualtestdemob+gstpayer,");
                bool Content2 = bodyTag1.Text.Contains("manualtestdemob+gstbiller has sent you an invoice via billzy.");
                bool Content3 = bodyTag1.Text.Contains("Test invoice has been sent to internal payer");
                bool Content4 = bodyTag1.Text.Contains("$1,650.00");
                bool Content5 = bodyTag1.Text.Contains(SentPgDueDate);
                bool Content6 = bodyTag1.Text.Contains("INVINTMTCI@"+ randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Content1 == true && Content2 == true && Content3 == true && Content4 == true && Content5 == true && Content6 == true);
                gmailpg.PDF().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                gmailpg.SearchClear().Click();
                gmailpg.Search().SendKeys("Invoice reference: INVINTMTUI@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
               new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag2 = WebDriver.FindElement(By.TagName("body"));
                bool Content11 = bodyTag2.Text.Contains("Dear manualtestdemob+gstpayer,");
                bool Content12 = bodyTag2.Text.Contains("manualtestdemob+gstbiller has sent you an invoice via billzy.");
                bool Content13 = bodyTag2.Text.Contains("Test invoice has been sent");
                bool Content14 = bodyTag2.Text.Contains("$900.90");
                bool Content15 = bodyTag2.Text.Contains(SentPgDueDate);
                bool Content16 = bodyTag2.Text.Contains("INVINTMTUI@" + randnumber2);

                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Content11 == true && Content12 == true && Content13 == true && Content14 == true && Content15 == true && Content16 == true);
                gmailpg.PDF().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchClear().Click();
                gmailpg.Search().SendKeys("Invoice reference: INVINTMTBOBO@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag3 = WebDriver.FindElement(By.TagName("body"));
                bool Content111 = bodyTag3.Text.Contains("Dear manualtestdemob+gstpayer,");
                bool Content112 = bodyTag3.Text.Contains("manualtestdemob+gstbiller has sent you an invoice via billzy.");
                bool Content114 = bodyTag3.Text.Contains("$100.00");
                bool Content116 = bodyTag3.Text.Contains("INVINTMTBOBO@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Content111 == true && Content112 == true  && Content114 == true  && Content116 == true);
                gmailpg.PDF().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchClear().Click();
                gmailpg.Search().SendKeys("Invoice reference: INVINTMTINBOX@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag4 = WebDriver.FindElement(By.TagName("body"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string bodytag44 = bodyTag4.Text;
                bool Content41 = bodyTag4.Text.Contains("Dear Billzy Inbox 03,");
                bool Content42 = bodyTag4.Text.Contains("TPB_NewBiller@1621732626 has sent you an invoice via billzy.");
                bool Content43 = bodyTag4.Text.Contains("$150.66");
                bool Content44 = bodyTag4.Text.Contains("INVINTMTINBOX@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Content41 == true && Content42 == true  && Content43 == true && Content44 == true);
                gmailpg.PDF().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.profile().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.signout().Click();

            }
            finally
            {
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com");

            }

        }

        [Test]
        public void ManualTest02_IssueInvoice02_EmailVerification_ExternalPayer()
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
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+gstbiller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);

                //Issue Invoice - Webapp - Create Invoice
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("External1");
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
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVEXTMTCI@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("1500.00");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
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
                SendPg.SearchInvoiceSent().SendKeys("INVEXTMTCI@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                //Issue Invoice - Webapp - Upload Invoice
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("External1");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.PdfUploadFileBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.uploadPDF().SendKeys(@"C:\Users\BillzyAdmin\Documents\Visual Studio 2019\Projects\BillzyAutomationTestSuite\Invoice.pdf");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.UploadAmount().SendKeys("900.90");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.UploadInvRef().SendKeys("INVEXTMTUI@" + randnumber2);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                IssueInvoicePg.UploadSurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Console.WriteLine("InvoiceCreated");
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SentOutstandingBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVEXTMTUI@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);


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
                SeleniumSetMethods.WaitOnPage(secdelay10);
                string textcheck = Bobopg.UserWelcomeMessage().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(textcheck.Contains("Welcome, madcowbiller+bobo_02@gmail.com"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.BillzyBiller().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                DateTime newDate = DateTime.Now.AddDays(30);
                string Invduedate = newDate.ToString("dd/MM/yyyy");
                string Invduedate1 = newDate.ToString("dd MMM yy");
                string Invduedate2 = newDate.ToString("dd/MM/yy");
                DateTime newDate1 = DateTime.Now;
                string Issuedate = newDate1.ToString("dd/MM/yyyy");

                //Issue Invoice - BOBO CONNECT - Create Invoice

               
                Bobopg.IssueInvoiceOnBehalfOf().SendKeys("manualtestdemob+gstbiller");
                SeleniumSetMethods.WaitOnPage(secdelay7);
                Bobopg.IssueInvoiceTo().SendKeys("Mailcheck");
                SeleniumSetMethods.WaitOnPage(secdelay7);
                                
                
                Bobopg.InvoiceDueDate().SendKeys(Invduedate);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.InvoiceIssueDate().SendKeys(Issuedate);
                Bobopg.TotalAmount().SendKeys("100.00");
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.Surcharge().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.RequestCash().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.PdfUpload().SendKeys(@"C:\Users\BillzyAdmin\OneDrive - Billzy\BillzyTestSuite\BillzyAutomationTestSuite\Invoice.pdf");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Bobopg.Reference().SendKeys("INVEXTMTBOBO@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                Bobopg.Issue().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                string message2 = Bobopg.Message().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(message2.Contains("Invoice has been created"));
                Bobopg.OKBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                //Verifying the Emails and PDF

                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://accounts.google.com/signin/v2/identifier?service=mail&passive=true&rm=false&continue=https%3A%2F%2Fmail.google.com%2Fmail%2F&ss=1&scc=1&ltmpl=default&ltmplcache=2&emr=1&osid=1&flowName=GlifWebSignIn&flowEntry=ServiceLogin");

                GMAILPage gmailpg = new GMAILPage(WebDriver);
                
                DateTime duedate1 = DateTime.Today.AddDays(90);
                string SentPgDueDate = duedate1.ToString("dd MMM yyyy");
                gmailpg.Username().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Username().SendKeys("madcowtesting10@gmail.com");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.UserNext().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                gmailpg.Password().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.PasswordNext().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                gmailpg.Search().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
               gmailpg.Search().SendKeys("INVEXTMTCI@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool logo = gmailpg.logo().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(logo == true);
                IWebElement bodyTag1 = WebDriver.FindElement(By.TagName("body"));
                bool Content1 = bodyTag1.Text.Contains("Dear External1,");
                bool Content2 = bodyTag1.Text.Contains("manualtestdemob+gstbiller has sent you an invoice via billzy.");
                
                bool Content4 = bodyTag1.Text.Contains("$1,650.00");
                bool Content5 = bodyTag1.Text.Contains(SentPgDueDate);
                bool Content6 = bodyTag1.Text.Contains("INVEXTMTCI@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Content1 == true && Content2 == true  && Content4 == true && Content5 == true && Content6 == true);
                gmailpg.PDF().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                gmailpg.SearchClear().Click();
                gmailpg.Search().SendKeys("INVEXTMTUI@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag3 = WebDriver.FindElement(By.TagName("body"));
                bool Content111 = bodyTag3.Text.Contains("Dear External1,");
                bool Content116 = bodyTag3.Text.Contains("INVEXTMTUI@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Content111 == true  && Content116 == true);
                gmailpg.PDF().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchClear().Click();
                
               gmailpg.Search().SendKeys("INVEXTMTBOBO@" + randnumber2);
                //gmailpg.Search().SendKeys("INVEXTMTBOBO@123456789");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag4 = WebDriver.FindElement(By.TagName("body"));
                bool Content41 = bodyTag4.Text.Contains("Dear Mailcheck,");
                bool Content42 = bodyTag4.Text.Contains("manualtestdemob+gstbiller has sent you an invoice via billzy.");
                
                 bool Content44 = bodyTag4.Text.Contains("INVEXTMTBOBO@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
              
                Assert.IsTrue(Content41 == true && Content42 == true  && Content44 == true);
                gmailpg.PDF().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                var tabs = WebDriver.WindowHandles;
                gmailpg.Verify().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));
                bool bpay = bodyTag.Text.Contains("The Bpay Biller Code is created via the Billzy platform, with the Biller displaying as Billzy or your Suppliers name.");
                Console.WriteLine(bodyTag);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(bpay == true);
               gmailpg.paypageverify().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                bool verifiedmsg = gmailpg.paypageverified().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(verifiedmsg == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.CardName().SendKeys("Valid");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                gmailpg.CardNumber().SendKeys("4242424242424242");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                gmailpg.Expmon().SendKeys("12");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                gmailpg.ExpYY().SendKeys("25");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                gmailpg.CVC().SendKeys("089");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                gmailpg.PAY().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                string successmsg = gmailpg.Successmsg().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(successmsg.Contains("Successful payment"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Close();
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Search().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchButton().Click();

                DateTime today = DateTime.Today;
                string today1 = today.ToString("dd/MM/yyyy");

                SeleniumSetMethods.WaitOnPage(secdelay4);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowUp).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);


                IWebElement bodyTag1141 = WebDriver.FindElement(By.TagName("body"));
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Console.WriteLine(bodyTag1141.Text);
                string body = bodyTag1141.Text;
                Console.WriteLine(body);
                //Assert.That(bodyTag1141.Text.Contains("Invoice INVEXTMTBOBO@" + randnumber2 + " has been verified") && bodyTag1141.Text.Contains("Invoice number INVEXTMTBOBO@" + randnumber2 + " has been verified") && bodyTag1141.Text.Contains("Thank you for verifying your invoice.") && bodyTag1141.Text.Contains("If you did not verify this invoice for payment please make contact with a billzy"));
                Assert.True(bodyTag1141.Text.Contains("Invoice INVEXTMTBOBO@" + randnumber2 + " has been verified") && bodyTag1141.Text.Contains("Invoice number INVEXTMTBOBO@" + randnumber2 + " has been verified") && bodyTag1141.Text.Contains("Thank you for verifying your invoice.") && bodyTag1141.Text.Contains("If you did not verify this invoice for payment please make contact with a billzy team member.") && bodyTag1141.Text.Contains("VIEW INVOICE"));
                SeleniumSetMethods.WaitOnPage(secdelay2);


                gmailpg.BacktoSearchresult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowUp).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag114 = WebDriver.FindElement(By.TagName("body"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.True(bodyTag114.Text.Contains("Successful payment via Billzy") && bodyTag114.Text.Contains("You made a successful payment on the " + today1) && bodyTag114.Text.Contains("Payment confirmation") && bodyTag114.Text.Contains("Amount $101.67"));
                SeleniumSetMethods.WaitOnPage(secdelay2);

                gmailpg.profile().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.signout().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                gmailpg.Antotheraccount().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                gmailpg.Username().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Username().SendKeys("manualtestdemob@gmail.com");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.UserNext().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                gmailpg.Password().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.PasswordNext().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                gmailpg.Search().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Search().SendKeys("INVEXTMTBOBO@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
               
                IWebElement bodyTag101 = WebDriver.FindElement(By.TagName("body"));
                bool Content101 = bodyTag101.Text.Contains("Invoice paid");
                bool Content201 = bodyTag101.Text.Contains("Your invoice has been paid");

                bool Content401 = bodyTag101.Text.Contains("Mailcheck paid your invoice on the " + today1);
                bool Content501 = bodyTag101.Text.Contains("$101.67");
                bool Content601 = bodyTag101.Text.Contains("INVEXTMTBOBO@" + randnumber2);
                bool Content701 = bodyTag101.Text.Contains("No further action is required.");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Content101 == true && Content201 == true && Content401 == true && Content501 == true && Content601 == true && Content701 == true);


            }
            finally
            {
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com");

            }

        }
        [Test]
        public void ManualTest03_IssueInvoice03_EmailVerification_HTMLTags()
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
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+gstbiller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                SendPage SendPg = new SendPage(WebDriver);

                //Issue Invoice - Webapp - Create Invoice - Internalpayer - HTML Tags
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
                IssueInvoicePg.BusinessName().SendKeys("manualtestdemob+gstpayer");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "60 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                string invref = "script > alert(\"Hello\");</ script >";
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys(invref);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to External Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("299.10");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Message().SendKeys(invref);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                IWebElement bodyTag2 = WebDriver.FindElement(By.TagName("body"));
                bool err23 = bodyTag2.Text.Contains("Unfortunately there was an internal system error. Please contact Billzy support");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(err23 == true);
                IssueInvoicePg.InvoiceReferenceCreate().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INTMTCIHTML@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("INTMTCIHTML@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

                //Issue Invoice - Webapp - Create Invoice - Internalpayer - HTML Tags
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BusinessName().SendKeys("External1");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.PdfUploadFileBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.uploadPDF().SendKeys(@"C:\Users\BillzyAdmin\Documents\Visual Studio 2019\Projects\BillzyAutomationTestSuite\Invoice.pdf");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.UploadAmount().SendKeys("900.90");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.UploadInvRef().SendKeys(invref);
                IssueInvoicePg.Message().SendKeys(invref);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                IWebElement bodyTag3 = WebDriver.FindElement(By.TagName("body"));
                bool err33 = bodyTag3.Text.Contains("Unfortunately there was an internal system error. Please contact Billzy support");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(err33 == false);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys(invref);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

            }
            finally
            {
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com");

            }

        }

        [Test]
        public void ManualTest04_IssueInvoice04_EmailVerification_ExternalPaymentScreen()
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
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+gstbiller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                SendPage SendPg = new SendPage(WebDriver);

                //Issue Invoice - Webapp - Create Invoice - Internalpayer - HTML Tags
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
                IssueInvoicePg.BusinessName().SendKeys("External1");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "60 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                //string invref = "script > alert(\"Hello\");</ script >";
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVMTEXT@"+ randnumber1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to External Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("299.10");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Message().SendKeys("This invoice issue to external payer");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("INVMTEXT@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.SignOutBTN().Click();

                SeleniumSetMethods.WaitOnPage(secdelay4);

                //Verifying the Emails and PDF

                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://accounts.google.com/signin/v2/identifier?service=mail&passive=true&rm=false&continue=https%3A%2F%2Fmail.google.com%2Fmail%2F&ss=1&scc=1&ltmpl=default&ltmplcache=2&emr=1&osid=1&flowName=GlifWebSignIn&flowEntry=ServiceLogin");

                GMAILPage gmailpg = new GMAILPage(WebDriver);

                DateTime duedate1 = DateTime.Today.AddDays(60);
                string SentPgDueDate = duedate1.ToString("dd MMM yyyy");
                gmailpg.Username().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Username().SendKeys("madcowtesting10@gmail.com");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.UserNext().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                gmailpg.Password().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.PasswordNext().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                gmailpg.Search().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Search().SendKeys("Invoice reference : INVMTEXT@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                gmailpg.SearchButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                
                IWebElement bodyTag1 = WebDriver.FindElement(By.TagName("body"));
                bool Content1 = bodyTag1.Text.Contains("Dear External1,");
                bool Content2 = bodyTag1.Text.Contains("manualtestdemob+gstbiller has sent you an invoice via billzy.");
                bool Content3 = bodyTag1.Text.Contains("This invoice issue to external payer");
                bool Content4 = bodyTag1.Text.Contains("$329.01");
                bool Content5 = bodyTag1.Text.Contains(SentPgDueDate);
                bool Content6 = bodyTag1.Text.Contains("INVMTEXT@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Content1 == true && Content2 == true && Content3 == true && Content4 == true && Content5 == true && Content6 == true);
                gmailpg.PDF().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                var tabs = WebDriver.WindowHandles;
                gmailpg.Verify().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
                IWebElement bodyTag11 = WebDriver.FindElement(By.TagName("body"));
                bool bpay = bodyTag11.Text.Contains("The Bpay Biller Code is created via the Billzy platform, with the Biller displaying as Billzy or your Suppliers name.");
                Console.WriteLine(bodyTag);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(bpay == true);
                gmailpg.paypageverify().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                bool verifiedmsg = gmailpg.paypageverified().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(verifiedmsg == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.CardName().SendKeys("Valid");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                gmailpg.CardNumber().SendKeys("4242424242424242");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                gmailpg.Expmon().SendKeys("12");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                gmailpg.ExpYY().SendKeys("25");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                gmailpg.CVC().SendKeys("089");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                gmailpg.PAY().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                string successmsg = gmailpg.Successmsg().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(successmsg.Contains("Successful payment"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Close();
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Search().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchButton().Click();

                DateTime today = DateTime.Today;
                string today1 = today.ToString("dd/MM/yyyy");

                SeleniumSetMethods.WaitOnPage(secdelay4);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowUp).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag14 = WebDriver.FindElement(By.TagName("body"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(bodyTag14.Text.Contains("Payment confirmation") && bodyTag14.Text.Contains("You made a successful payment on the " + today1) && bodyTag14.Text.Contains("$334.50"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.BacktoSearchresult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.profile().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.signout().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                gmailpg.Antotheraccount().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                gmailpg.Username().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Username().SendKeys("manualtestdemob@gmail.com");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.UserNext().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                gmailpg.Password().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.PasswordNext().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                gmailpg.Search().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Search().SendKeys("Invoice reference : INVMTEXT@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                gmailpg.SearchButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);

                IWebElement bodyTag011 = WebDriver.FindElement(By.TagName("body"));
                bool Content011 = bodyTag011.Text.Contains("Your invoice has been paid");
                bool Content02 = bodyTag011.Text.Contains("External1 paid your invoice on the");
                bool Content03 = bodyTag011.Text.Contains("No further action is required.");
               
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Content011 == true && Content02 == true && Content03 == true );
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.BacktoSearchresult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.profile().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.signout().Click();



            }
            finally
            {
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com");

            }

        }
        [Test]
        public void ManualTest05_InvoiceWithDeal01_EmailVerification_BCreatedPCounterBAccepted()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {
                //INVMTCCADEAL - INVoice Manual Testcase Created Counter Accepted DEAL

                WebDriver.Manage().Window.Maximize();
               WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);
                SendPage SendPg = new SendPage(WebDriver);
                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                BillzyCashModal BillzyCashMlPg = new BillzyCashModal(WebDriver);
                SIVPage SIVPG1 = new SIVPage(WebDriver);
                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+gstbiller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                // Biller Created the offer
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay8);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+11111");

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

                DateTime emailcheck = DateTime.Today.AddDays(90);
                string emailcheck1 = emailcheck.ToString("dd MMM yy");


                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVMTCCADEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.NewTotal().SendKeys("319.82");

                DateTime newDate = DateTime.Now.AddDays(15);
                string dtString3 = newDate.ToString("dd/MM/yyyy");
                string newdue = newDate.ToString("dd MMM yyyy");

                IssueInvoicePg.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
                IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");
                IssueInvoicePg.SurchargeCheckbox().Click();
                //issueInvoice_issueInvoicePage_totalValue.checkValueContains = @amountGst
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Console.WriteLine("InvoiceCreated");
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVMTCCADEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SendPg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                
               
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();

                // Payer make a counter offer
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+11111@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVMTCCADEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                
                Recpg.BillzyDealOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.PayerMakeACounterOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                DateTime duedate000 = DateTime.Today.AddDays(5);
                string SentPgDueDate2 = duedate000.ToString("dd/MM/yyyy");
                string payerdue = duedate000.ToString("dd MMM yyyy");
                SIVPG1.NewTotal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.NewTotal().SendKeys("200.82");
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
             
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVMTCCADEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                bool OfferSentIcon = Recpg.OfferSentIcon().Displayed;
                String OfferStatus = Recpg.OfferStatus().Text;
                //Recpg.OfferExpiredIcon().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                string OfferSentIconhover = Recpg.OfferSentIconhover().GetAttribute("data-content");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //Console.WriteLine("OfferExpiredhover" + OfferExpiredhover);
                Assert.IsTrue((OfferSentIcon == true) && OfferStatus.Contains("Offer sent"));
                
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+gstbiller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                // Biller Accepts the offer
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVMTCCADEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                bool OfferRecievedIcon = SendPg.OfferRecievedIcon().Displayed;
                String OfferStatus1 = Recpg.OfferStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string OfferrecievedIconhover = Recpg.Offerhovertext().GetAttribute("data-content");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue((OfferRecievedIcon == true) && OfferStatus1.Contains("Offer received") );
                SendPg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyDealOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.AcceptOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.AcceptTheOfferModalYesBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.SignOutBTN().Click();

                //Verify Emails:

                //Verifying the biller Emails and PDF

                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://accounts.google.com/signin/v2/identifier?service=mail&passive=true&rm=false&continue=https%3A%2F%2Fmail.google.com%2Fmail%2F&ss=1&scc=1&ltmpl=default&ltmplcache=2&emr=1&osid=1&flowName=GlifWebSignIn&flowEntry=ServiceLogin");

                GMAILPage gmailpg = new GMAILPage(WebDriver);

                DateTime duedate1 = DateTime.Today.AddDays(90);
                DateTime duedate2 = DateTime.Today.AddDays(5);
                string SentPgDueDate = duedate1.ToString("dd MMM yyyy");
                string SentPgDueDate1 = duedate2.ToString("dd MMM yyyy");
                gmailpg.Username().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Username().SendKeys("manualtestdemob@gmail.com");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.UserNext().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                gmailpg.Password().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.PasswordNext().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                gmailpg.Search().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Search().SendKeys("Invoice reference : INVMTCCADEAL@" + randnumber2);
                //gmailpg.Search().SendKeys("Invoice reference : INVMTCCADEAL@2027114439");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                gmailpg.SearchButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
               
                IWebElement bodyTag1 = WebDriver.FindElement(By.TagName("body"));
                bool Content1 = bodyTag1.Text.Contains("Deal request from madcowtesting10+11111");
                bool Content2 = bodyTag1.Text.Contains("Dear manualtestdemob+gstbiller,");
                bool Content3 = bodyTag1.Text.Contains("madcowtesting10+11111 has sent you a deal request via billzy. Details are below.");
                bool Content4 = bodyTag1.Text.Contains("This new deal overrides any previous deal.");
                bool Content14 = bodyTag1.Text.Contains("$351.80");
                bool Content24 = bodyTag1.Text.Contains("$200.82");
                bool Content34 = bodyTag1.Text.Contains(SentPgDueDate);
                bool Content44 = bodyTag1.Text.Contains(SentPgDueDate1);
                bool Content54 = bodyTag1.Text.Contains("If you would like to view your invoice, please click the link above.");
                bool Content5 = bodyTag1.Text.Contains("Note: The full payment amount will be due after "+ SentPgDueDate1);
                bool Content6 = bodyTag1.Text.Contains("Approve or decline");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Content1 == true && Content2 == true && Content3 == true && Content4 == true && Content14 == true && Content24 == true && Content34 == true && Content44 == true && Content54 == true  && Content5 == true && Content6 == true);
               
                
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.profile().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.signout().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                //Verifying the payer Emails and PDF
                gmailpg.Antotheraccount().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                                
                DateTime duedate3 = DateTime.Today.AddDays(15);
                string SentPgDueDate3 = duedate3.ToString("dd MMM yyyy");
                gmailpg.Username().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Username().SendKeys("madcowtesting10@gmail.com");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.UserNext().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                gmailpg.Password().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.PasswordNext().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                gmailpg.Search().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Search().SendKeys("Invoice reference : INVMTCCADEAL@" + randnumber2);
                //gmailpg.Search().SendKeys("Invoice reference : INVMTCCADEAL@2027114439");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                gmailpg.SearchButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);

                IWebElement bodyTag2 = WebDriver.FindElement(By.TagName("body"));
                bool Content01 = bodyTag2.Text.Contains("Invoice from manualtestdemob+gstbiller");
                bool Content02 = bodyTag2.Text.Contains("Dear madcowtesting10+11111,");
                bool Content03 = bodyTag2.Text.Contains("manualtestdemob+gstbiller has sent you an invoice via billzy.");
                bool Content04 = bodyTag2.Text.Contains("Test invoice has been sent to internal payer");
                bool Content014 = bodyTag2.Text.Contains("$319.82");
                bool Content024 = bodyTag2.Text.Contains("$351.80");
                bool Content034 = bodyTag2.Text.Contains(SentPgDueDate3);
                bool Content054 = bodyTag2.Text.Contains("If you would like to view your invoice, please click the link above.");
                bool Content05 = bodyTag2.Text.Contains("Note: The full payment amount will be due after " + SentPgDueDate3);
                bool Content06 = bodyTag2.Text.Contains("VERIFY/PAY INVOICE");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Content01 == true && Content02 == true && Content03 == true && Content04 == true && Content014 == true && Content024 == true && Content034 == true && Content054 == true && Content05 == true && Content06 == true);
                gmailpg.PDF().Click();

                SeleniumSetMethods.WaitOnPage(secdelay2);

                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.BacktoSearchresult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowUp).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);

                IWebElement bodyTag3 = WebDriver.FindElement(By.TagName("body"));
                bool Content001 = bodyTag3.Text.Contains("Your deal request has been accepted");
                bool Content002 = bodyTag3.Text.Contains("Dear madcowtesting10+11111,");
                bool Content003 = bodyTag3.Text.Contains("manualtestdemob+gstbiller has approved your deal request");

                bool Content0014 = bodyTag3.Text.Contains("$351.80");
                bool Content0024 = bodyTag3.Text.Contains("$200.82");
                bool Content0034 = bodyTag3.Text.Contains(SentPgDueDate1);
                bool Content0054 = bodyTag3.Text.Contains("If you would like to view your invoice, please click the link above.");
                bool Content005 = bodyTag3.Text.Contains("Note: The full payment amount will be due after " + SentPgDueDate1);
                bool Content006 = bodyTag3.Text.Contains("View accepted deal");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Content001 == true && Content002 == true && Content003 == true && Content0014 == true && Content0024 == true && Content0034 == true && Content0054 == true && Content005 == true && Content006 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.profile().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.signout().Click();



               


            }
            finally
            {
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com");

            }

        }

        [Test]
        public void ManualTest06_InvoiceWithDeal02_EmailVerification_Re3questedWithdrawCounterDeclined()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {
                //INVMTCCADEAL - INVoice Manual Testcase Created Counter Accepted DEAL

                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);
                SendPage SendPg = new SendPage(WebDriver);
                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                BillzyCashModal BillzyCashMlPg = new BillzyCashModal(WebDriver);
                SIVPage SIVPG1 = new SIVPage(WebDriver);
                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+gstbiller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                // Biller Created the offer
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay8);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                
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
                DateTime newDate = DateTime.Now.AddDays(15);
                string dtString3 = newDate.ToString("dd/MM/yyyy");


                //INVMTWRDDEAL - INVoice Manual Testcase Withdrew Requested Declined DEAL


                // Biller created the deal
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+11111");

                IssueInvoicePg.SelectBusiness().Click();
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVMTWRDDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.LineItemAmount().SendKeys("1000");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.NewTotal().SendKeys("950");

                IssueInvoicePg.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
                IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");
                IssueInvoicePg.SurchargeCheckbox().Click();
                //issueInvoice_issueInvoicePage_totalValue.checkValueContains = @amountGst
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Console.WriteLine("InvoiceCreated");
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVMTWRDDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);

                //Biller Withdrew the deal
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SIVPG1.WithdrawOfferBillerBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.YesWithdrawOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string histstatus01 = SIVPG1.DiscountHistoryStatus01().Text;
                Assert.IsTrue(histstatus01.Contains("WITHDRAWN"));
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVMTWRDDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);

                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();

                //Payer Requested the deal
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+11111@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVMTWRDDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);


                Recpg.BillzyDealOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Assert.IsFalse(SIVPG1.BillzyCashStatusBTN().Displayed);
                String invstatus = SIVPG1.InvoiceStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invstatus.Contains("UNPAID"));
                SIVPG1.PayerVerifyBTN().Click();

                DateTime duedate10 = DateTime.Today.AddDays(30);
                string SentPgDueDate10 = duedate10.ToString("dd/MM/yyyy");

                SIVPG1.PayerOfferEarlyPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.NewTotal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.NewTotal().SendKeys("900");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().SendKeys(SentPgDueDate10);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                SIVPG1.Comments().SendKeys("Payer Requested a Deal");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.OfferEarlyPaymentModalBTN1().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVMTWRDDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);


                // Payer withdrew the deal
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.BillzyDealOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.WithdrawOfferPayerBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.YesWithdrawOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string histstatus1 = SIVPG1.DiscountHistoryStatus01().Text;
                Assert.IsTrue(histstatus1.Contains("WITHDRAWN"));

                ////Payer Requested the deal
                SIVPG1.PayerOfferEarlyPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.NewTotal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.NewTotal().SendKeys("900");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().SendKeys(SentPgDueDate10);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                SIVPG1.Comments().SendKeys("Payer Requested a Deal");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.OfferEarlyPaymentModalBTN1().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+gstbiller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                // Biller make a counter offer
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVMTWRDDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SIVPG1.BillerMakeACounterOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

                SIVPG1.NewTotal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.NewTotal().SendKeys("980");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().SendKeys(SentPgDueDate10);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                SIVPG1.Comments().SendKeys("Biller made a counter offer");
                SeleniumSetMethods.WaitOnPage(secdelay3);

                SIVPG1.makeCounterOfferModalBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

                //Payer counter offer the deal
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();

                // Payer make a counter offer
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+11111@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVMTWRDDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                Recpg.BillzyDealOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.PayerMakeACounterOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                DateTime duedate003 = DateTime.Today.AddDays(35);
                string SentPgDueDate33 = duedate003.ToString("dd/MM/yyyy");

                SIVPG1.NewTotal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.NewTotal().SendKeys("920");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.OfferExpiry().SendKeys(SentPgDueDate33);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                SIVPG1.Comments().SendKeys("Payer Requested a Deal");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.makeCounterOfferModalBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);

                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                //Biller declined the deal
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+gstbiller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");


                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVMTWRDDEAL@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);
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
                HomePg.SignOutBTN().Click();
                Console.WriteLine("INVMTWRDDEAL@" + randnumber2);
                

                //Verify Emails:

                //Verifying the biller Emails and PDF

                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://accounts.google.com/signin/v2/identifier?service=mail&passive=true&rm=false&continue=https%3A%2F%2Fmail.google.com%2Fmail%2F&ss=1&scc=1&ltmpl=default&ltmplcache=2&emr=1&osid=1&flowName=GlifWebSignIn&flowEntry=ServiceLogin");

                GMAILPage gmailpg = new GMAILPage(WebDriver);

                DateTime duedate1 = DateTime.Today.AddDays(90);
                DateTime duedate2 = DateTime.Today.AddDays(5);
                string SentPgDueDate = duedate1.ToString("dd MMM yyyy");
                string SentPgDueDate1 = duedate2.ToString("dd MMM yyyy");
                gmailpg.Username().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Username().SendKeys("manualtestdemob@gmail.com");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.UserNext().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                gmailpg.Password().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.PasswordNext().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                gmailpg.Search().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Search().SendKeys("Invoice reference : INVMTWRDDEAL@" + randnumber2);
                //gmailpg.Search().SendKeys("Invoice reference : INVMTWRDDEAL@1605161184");
                //gmailpg.Search().SendKeys("Invoice reference : INVMTCCADEAL@2027114439");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                gmailpg.SearchButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);

                IWebElement bodyTag1 = WebDriver.FindElement(By.TagName("body"));
                bool Content1 = bodyTag1.Text.Contains("Deal request from madcowtesting10+11111");
                bool Content2 = bodyTag1.Text.Contains("Dear manualtestdemob+gstbiller,");
                bool Content3 = bodyTag1.Text.Contains("madcowtesting10+11111 has sent you a deal request via billzy. Details are below.");
                bool Content4 = bodyTag1.Text.Contains("This new deal overrides any previous deal.");
                bool Content14 = bodyTag1.Text.Contains("$1100.00");
                bool Content24 = bodyTag1.Text.Contains("$900.00");
                bool Content54 = bodyTag1.Text.Contains("If you would like to view your invoice, please click the link above.");
                bool Content5 = bodyTag1.Text.Contains("Note: The full payment amount will be due after ");
                bool Content6 = bodyTag1.Text.Contains("Approve or decline");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Content1 == true && Content2 == true && Content3 == true && Content4 == true && Content14 == true && Content24 == true &&  Content54 == true && Content5 == true && Content6 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.BacktoSearchresult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowUp).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                IWebElement bodyTag11 = WebDriver.FindElement(By.TagName("body"));
                bool Content01 = bodyTag11.Text.Contains("Billzy deal withdrawn by madcowtesting10+11111");
                bool Content02 = bodyTag11.Text.Contains("Dear manualtestdemob+gstbiller,");
                bool Content03 = bodyTag11.Text.Contains("madcowtesting10+11111 has withdrawn their Billzy deal via billzy.");
                
                bool Content014 = bodyTag11.Text.Contains("$1100.00");
                bool Content024 = bodyTag11.Text.Contains("$900.00");
                bool Content054 = bodyTag11.Text.Contains("If you would like to view your invoice, please click the link above.");
                bool Content05 = bodyTag11.Text.Contains("Note: The full payment amount will be due after ");
                bool Content06 = bodyTag11.Text.Contains("View invoice");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Content01 == true && Content02 == true && Content03 == true &&  Content014 == true && Content024 == true && Content054 == true && Content05 == false && Content06 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                

                gmailpg.BacktoSearchresult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowUp).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag111 = WebDriver.FindElement(By.TagName("body"));
                bool Content011 = bodyTag111.Text.Contains("madcowtesting10+11111 has sent you a deal request via billzy. Details are below.");
                bool Content066 = bodyTag111.Text.Contains("Approve or decline");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Content011 == true && Content066 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
               

                gmailpg.BacktoSearchresult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowUp).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                IWebElement bodyTag112 = WebDriver.FindElement(By.TagName("body"));
                bool Content111 = bodyTag112.Text.Contains("madcowtesting10+11111 has sent you a deal request via billzy. Details are below.");
                bool Content166 = bodyTag112.Text.Contains("Approve or decline");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Content111 == true && Content166 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.BacktoSearchresult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.profile().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.signout().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                //Verifying the payer Emails and PDF
                gmailpg.Antotheraccount().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                DateTime duedate3 = DateTime.Today.AddDays(15);
                string SentPgDueDate3 = duedate3.ToString("dd MMM yyyy");
                gmailpg.Username().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Username().SendKeys("madcowtesting10@gmail.com");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.UserNext().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                gmailpg.Password().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.PasswordNext().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                gmailpg.Search().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Search().SendKeys("Invoice reference : INVMTWRDDEAL@" + randnumber2);
                //gmailpg.Search().SendKeys("Invoice reference : INVMTWRDDEAL@1605161184");
                //gmailpg.Search().SendKeys("Invoice reference : INVMTCCADEAL@2027114439");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                gmailpg.SearchButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);

                IWebElement bodyTag2 = WebDriver.FindElement(By.TagName("body"));
                bool Content101 = bodyTag2.Text.Contains("Invoice from manualtestdemob+gstbiller");
                bool Content102 = bodyTag2.Text.Contains("Dear madcowtesting10+11111,");
                bool Content103 = bodyTag2.Text.Contains("manualtestdemob+gstbiller has sent you an invoice via billzy.");
                bool Content104 = bodyTag2.Text.Contains("Test invoice has been sent to internal payer");
                bool Content1014 = bodyTag2.Text.Contains("$1,100.00");
                bool Content1024 = bodyTag2.Text.Contains("$950.00");
                
                bool Content1054 = bodyTag2.Text.Contains("If you would like to view your invoice, please click the link above.");
                bool Content105 = bodyTag2.Text.Contains("Note: The full payment amount will be due after ");
                bool Content106 = bodyTag2.Text.Contains("VERIFY/PAY INVOICE");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Content101 == true && Content102 == true && Content103 == true && Content104 == true && Content1014 == true && Content1024 == true && Content1054 == true && Content105 == true && Content106 == true);
                gmailpg.PDF().Click();

                SeleniumSetMethods.WaitOnPage(secdelay2);

                SeleniumSetMethods.WaitOnPage(secdelay2);


                gmailpg.BacktoSearchresult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowUp).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                IWebElement bodyTag201 = WebDriver.FindElement(By.TagName("body"));
                bool Content21 = bodyTag201.Text.Contains("Billzy deal withdrawn by");
                
                bool Content212 = bodyTag201.Text.Contains("manualtestdemob+gstbiller has withdrawn their Billzy deal via billzy.");
                bool Content216 = bodyTag201.Text.Contains("View invoice");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Content21 == true &&  Content212 == true && Content216 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.BacktoSearchresult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowUp).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                IWebElement bodyTag202 = WebDriver.FindElement(By.TagName("body"));
                bool Content31 = bodyTag202.Text.Contains("Deal from manualtestdemob+gstbiller");
                bool Content312 = bodyTag202.Text.Contains("manualtestdemob+gstbiller has sent you a new deal offer via billzy");
                bool Content316 = bodyTag202.Text.Contains("PAY NOW");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Content31 == true && Content312 == true && Content316 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.BacktoSearchresult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowUp).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag203 = WebDriver.FindElement(By.TagName("body"));
                bool Content41 = bodyTag203.Text.Contains("Your deal request has been declined");
                bool Content412 = bodyTag203.Text.Contains("manualtestdemob+gstbiller has declined your deal request via billzy.");
                bool Content416 = bodyTag203.Text.Contains("View invoice");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Content41 == true && Content412 == true && Content416 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);


                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.profile().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.signout().Click();


            }
            finally
            {
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com");

            }

        }

        [Test]
        public void ManualTest07_Payments01_EmailVerification_Surcharge_GST()
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
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+gstbiller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                SendPage SendPg = new SendPage(WebDriver);

                //Issue Invoice - Webapp - Create Invoice - Internalpayer - HTML Tags
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
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+11111");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "60 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVGSTSUR@" + randnumber1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to External Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("299.10");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Message().SendKeys("This invoice issue to internal payer");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string subject = IssueInvoicePg.Subject().GetAttribute("value");
                string TotalGSTMsg = IssueInvoicePg.TotalGSTMsg().Text;
                string TotalValue = IssueInvoicePg.TotalValue().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(subject.Contains("manualtestdemob+gstbiller has sent you an invoice") && TotalGSTMsg.Contains("(incl. GST)") && TotalValue.Contains("$329.01"));
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("INVGSTSUR@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPage sivpg = new SIVPage(WebDriver);
                sivpg.ReturnBTN().Click();
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IWebElement bodyTag1 = WebDriver.FindElement(By.TagName("body"));
                
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+11111");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();

                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVGSTNOSUR@" + randnumber1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to External Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("299.10");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Message().SendKeys("This invoice issue to external payer");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string subject1 = IssueInvoicePg.Subject().GetAttribute("value");
                string TotalGSTMsg1 = IssueInvoicePg.TotalGSTMsg().Text;
                string TotalValue1 = IssueInvoicePg.TotalValue().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(subject1.Contains("manualtestdemob+gstbiller has sent you an invoice") && TotalGSTMsg1.Contains("(incl. GST)") && TotalValue1.Contains("$329.01"));
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("INVGSTNOSUR@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay2);

                
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();

                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+11111@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVGSTSUR@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.PAY().Click();
                PayNowPage Paynwpg = new PayNowPage(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paynwpg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Paynwpg.Card1().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                IWebElement bodyTag2 = WebDriver.FindElement(By.TagName("body"));
                bool surmsg = bodyTag2.Text.Contains("Includes 1.67% surcharge");
                string amount1 = Paynwpg.Row01AmountPayable().GetAttribute("value");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(amount1.Contains("334.50") && surmsg == true);

                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paynwpg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Paynwpg.Bank1().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool surmsg2 = bodyTag2.Text.Contains("Includes 1.67% surcharge");
                string amount2 = Paynwpg.Row01AmountPayable().GetAttribute("value");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(amount2.Contains("329.01") && surmsg2 == false);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paynwpg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Paynwpg.Card1().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                Paynwpg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paynwpg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ReceivedHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVGSTSUR@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string paidstatushover = Recpg.HistoryPaidStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover.Contains("paid"));
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                String status2 = sivpg.InvoiceStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(status2.Contains("PAID"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag3 = WebDriver.FindElement(By.TagName("body"));
                bool details1 = bodyTag3.Text.Contains("Amount paid by CC (incl. GST)");
                bool details2 = bodyTag3.Text.Contains("$334.50");
                bool details3 = bodyTag3.Text.Contains("Incl. surcharge");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(details1 == true && details2 == true && details3 == true);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.ToPayTab().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.SearchInvoiceReceived().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().SendKeys("INVGSTNOSUR@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay3);

                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.PAY().Click();
                
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paynwpg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Paynwpg.Card1().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                IWebElement bodyTag5 = WebDriver.FindElement(By.TagName("body"));
                bool surmsg5 = bodyTag5.Text.Contains("Includes 0.00% surcharge");
                string amount5 = Paynwpg.Row01AmountPayable().GetAttribute("value");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(amount5.Contains("329.01") && surmsg5 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paynwpg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Paynwpg.Bank1().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool surmsg6 = bodyTag2.Text.Contains("Includes 1.67% surcharge");
                string amount6 = Paynwpg.Row01AmountPayable().GetAttribute("value");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(amount6.Contains("329.01") && surmsg6 == false);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paynwpg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paynwpg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ReceivedHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVGSTNOSUR@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                String status3 = sivpg.InvoiceStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(status3.Contains("PROCESSING"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag6 = WebDriver.FindElement(By.TagName("body"));
                bool details11 = bodyTag6.Text.Contains("Amount paid by CC (incl. GST)");
                bool details12 = bodyTag6.Text.Contains("$329.01");
                bool details13 = bodyTag6.Text.Contains("Total (incl. GST)");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(details11 == false && details12 == true && details13 == true);
                Console.WriteLine("INVGSTNOSUR@" + randnumber1);
                Console.WriteLine("INVGSTSUR@" + randnumber1);

                //Verify all email notifications
                WebDriver.Navigate().GoToUrl("https://accounts.google.com/signin/v2/identifier?service=mail&passive=true&rm=false&continue=https%3A%2F%2Fmail.google.com%2Fmail%2F&ss=1&scc=1&ltmpl=default&ltmplcache=2&emr=1&osid=1&flowName=GlifWebSignIn&flowEntry=ServiceLogin");

                GMAILPage gmailpg = new GMAILPage(WebDriver);
                gmailpg.Username().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Username().SendKeys("manualtestdemob@gmail.com");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.UserNext().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                gmailpg.Password().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.PasswordNext().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                gmailpg.Search().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
               gmailpg.Search().SendKeys("INVGSTNOSUR@" + randnumber1);
                //gmailpg.Search().SendKeys("INVGSTNOSUR@648913894");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag12 = WebDriver.FindElement(By.TagName("body"));
                bool Content1 = bodyTag12.Text.Contains("Payment initiated");
                bool Content2 = bodyTag12.Text.Contains("madcowtesting10+11111 has initiated a bank transfer payment. This payment is currently being processed by their financial institution.");
                bool Content3 = bodyTag12.Text.Contains("$329.01");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Content1 == true && Content2 == true && Content3 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.BacktoSearchresult().Click();

                DateTime newDate = DateTime.Now;
                string dtString3 = newDate.ToString("dd/MM/yyyy");

                gmailpg.Search().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Search().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Search().SendKeys("INVGSTSUR@" + randnumber1);
                //gmailpg.Search().SendKeys("INVGSTNOSUR@648913894");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag112 = WebDriver.FindElement(By.TagName("body"));
                bool Content11 = bodyTag112.Text.Contains("Your invoice has been paid");
                bool Content12 = bodyTag112.Text.Contains("madcowtesting10+11111 paid your invoice on the "+ dtString3);
                bool Content13 = bodyTag112.Text.Contains("$334.50");
                bool Content14 = bodyTag112.Text.Contains("No further action is required.");

                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Content11 == true && Content12 == true && Content13 == true && Content14 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.BacktoSearchresult().Click();


                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.profile().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.signout().Click();

                SeleniumSetMethods.WaitOnPage(secdelay5);

                //Verifying the payer Emails and PDF
                gmailpg.Antotheraccount().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                DateTime duedate3 = DateTime.Today.AddDays(15);
                string SentPgDueDate3 = duedate3.ToString("dd MMM yyyy");
                gmailpg.Username().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Username().SendKeys("madcowtesting10@gmail.com");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.UserNext().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                gmailpg.Password().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.PasswordNext().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                gmailpg.Search().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Search().SendKeys("Invoice reference : INVGSTSUR@" + randnumber1);
                //gmailpg.Search().SendKeys("Invoice reference : INVMTWRDDEAL@1605161184");
                //gmailpg.Search().SendKeys("Invoice reference : INVMTCCADEAL@2027114439");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                gmailpg.SearchButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag122 = WebDriver.FindElement(By.TagName("body"));
                bool Content121 = bodyTag122.Text.Contains("Payment confirmation");
                bool Content122 = bodyTag122.Text.Contains("You made a successful payment on the " + dtString3);
                bool Content123 = bodyTag122.Text.Contains("$334.50");
                
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Content121 == true && Content122 == true && Content123 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.BacktoSearchresult().Click();
                
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.profile().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.signout().Click();



            }
            finally
            {
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com");

            }

        }

        [Test]
        public void ManualTest08_Payments02_EmailVerification_Surcharge_NoGST()
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
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+nogstbiller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                SendPage SendPg = new SendPage(WebDriver);

                //Issue Invoice - Webapp - Create Invoice - Internalpayer - HTML Tags
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
                IssueInvoicePg.BusinessName().SendKeys("manualtestdemob+nogstpayer");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "60 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();

                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVNOGSTSUR@" + randnumber1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to External Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("299.10");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Message().SendKeys("This invoice issue to internal payer");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string subject = IssueInvoicePg.Subject().GetAttribute("value");
                string TotalGSTMsg = IssueInvoicePg.TotalGSTMsg().Text;
                string TotalValue = IssueInvoicePg.TotalValue().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(subject.Contains("manualtestdemob+nogstbiller has sent you an invoice") && TotalGSTMsg.Contains("(excl. GST)") && TotalValue.Contains("$299.10"));
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("INVNOGSTSUR@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPage sivpg = new SIVPage(WebDriver);
                sivpg.ReturnBTN().Click();
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IWebElement bodyTag1 = WebDriver.FindElement(By.TagName("body"));

                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BusinessName().SendKeys("manualtestdemob+nogstpayer");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();

                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVNOGSTNOSUR@" + randnumber1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to External Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("299.10");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Message().SendKeys("This invoice issue to external payer");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string subject1 = IssueInvoicePg.Subject().GetAttribute("value");
                string TotalGSTMsg1 = IssueInvoicePg.TotalGSTMsg().Text;
                string TotalValue1 = IssueInvoicePg.TotalValue().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(subject1.Contains("manualtestdemob+nogstbiller has sent you an invoice") && TotalGSTMsg1.Contains("(excl. GST)") && TotalValue1.Contains("$299.10"));
                SeleniumSetMethods.WaitOnPage(secdelay5);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SendPg.SearchInvoiceSent().SendKeys("INVNOGSTNOSUR@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();

                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+nogstpayer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVNOGSTSUR@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.PAY().Click();
                PayNowPage Paynwpg = new PayNowPage(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paynwpg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Paynwpg.Card1().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                IWebElement bodyTag2 = WebDriver.FindElement(By.TagName("body"));
                bool surmsg = bodyTag2.Text.Contains("Includes 1.67% surcharge");
                string amount1 = Paynwpg.Row01AmountPayable().GetAttribute("value");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(amount1.Contains("304.09") && surmsg == true);

                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paynwpg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Paynwpg.Bank1().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool surmsg2 = bodyTag2.Text.Contains("Includes 1.67% surcharge");
                string amount2 = Paynwpg.Row01AmountPayable().GetAttribute("value");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(amount2.Contains("299.10") && surmsg2 == false);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paynwpg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Paynwpg.Card1().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                Paynwpg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paynwpg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ReceivedHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVNOGSTSUR@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string paidstatushover = Recpg.HistoryPaidStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover.Contains("paid"));
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                String status2 = sivpg.InvoiceStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(status2.Contains("PAID"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag3 = WebDriver.FindElement(By.TagName("body"));
                bool details1 = bodyTag3.Text.Contains("Amount paid by CC");
                bool details2 = bodyTag3.Text.Contains("$304.09");
                bool details3 = bodyTag3.Text.Contains("Incl. surcharge");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(details1 == true && details2 == true && details3 == true);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.ToPayTab().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.SearchInvoiceReceived().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().SendKeys("INVNOGSTNOSUR@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay3);

                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.PAY().Click();

                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paynwpg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Paynwpg.Card1().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                IWebElement bodyTag5 = WebDriver.FindElement(By.TagName("body"));
                bool surmsg5 = bodyTag5.Text.Contains("Includes 0.00% surcharge");
                string amount5 = Paynwpg.Row01AmountPayable().GetAttribute("value");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(amount5.Contains("299.10") && surmsg5 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paynwpg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Paynwpg.Bank1().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool surmsg6 = bodyTag2.Text.Contains("Includes 1.67% surcharge");
                string amount6 = Paynwpg.Row01AmountPayable().GetAttribute("value");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(amount6.Contains("299.10") && surmsg6 == false);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paynwpg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paynwpg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ReceivedHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVNOGSTNOSUR@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                String status3 = sivpg.InvoiceStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(status3.Contains("PROCESSING"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag6 = WebDriver.FindElement(By.TagName("body"));
                bool details11 = bodyTag6.Text.Contains("Amount paid by CC");
                bool details12 = bodyTag6.Text.Contains("$299.10");
                bool details13 = bodyTag6.Text.Contains("Total (excl. GST)");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(details11 == false && details12 == true && details13 == true);

            }
            finally
            {
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com");

            }

        }

        [Test]
        public void ManualTest09_Payments03_EmailVerification_SplitPayments()
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
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+nogstbiller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                SendPage SendPg = new SendPage(WebDriver);

                //Issue Invoice - Webapp - Create Invoice - Internalpayer - HTML Tags
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
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+11111");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "60 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();

                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVSPLIT@" + randnumber1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to External Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("299.10");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Message().SendKeys("This invoice issue to internal payer");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string subject = IssueInvoicePg.Subject().GetAttribute("value");
                string TotalGSTMsg = IssueInvoicePg.TotalGSTMsg().Text;
                string TotalValue = IssueInvoicePg.TotalValue().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(subject.Contains("manualtestdemob+nogstbiller has sent you an invoice") && TotalGSTMsg.Contains("(excl. GST)") && TotalValue.Contains("$299.10"));
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("INVSPLIT@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPage sivpg = new SIVPage(WebDriver);
                sivpg.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
               
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+11111");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();

                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVSPLIT2@" + randnumber1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to External Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("299.10");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Message().SendKeys("This invoice issue to internal payer");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("INVSPLIT2@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();

                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+11111@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVSPLIT@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.PAY().Click();
                //valid and invalid card selection
                PayNowPage Paynwpg = new PayNowPage(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paynwpg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Paynwpg.Card1().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Paynwpg.Row01AmountPayable().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paynwpg.Row01AmountPayable().SendKeys("100");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paynwpg.Row01SplitBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Paynwpg.Row02SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Paynwpg.Card2().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Paynwpg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paynwpg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ReceivedHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVSPLIT@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IWebElement bodyTag4 = WebDriver.FindElement(By.TagName("body"));
                bool noinv = bodyTag4.Text.Contains("No Invoices Available");
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.ToPayTab().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.SearchInvoiceReceived().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().SendKeys("INVSPLIT2@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.PAY().Click();
                //both valid card selection
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paynwpg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Paynwpg.Card1().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Paynwpg.Row01AmountPayable().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paynwpg.Row01AmountPayable().SendKeys("100");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paynwpg.Row01SplitBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Paynwpg.Row02SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Paynwpg.Card3().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Paynwpg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paynwpg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ReceivedHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVSPLIT2@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                String status3 = sivpg.InvoiceStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(status3.Contains("PAID"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                //Verify all email notifications
                //Verify the biller side
                WebDriver.Navigate().GoToUrl("https://accounts.google.com/signin/v2/identifier?service=mail&passive=true&rm=false&continue=https%3A%2F%2Fmail.google.com%2Fmail%2F&ss=1&scc=1&ltmpl=default&ltmplcache=2&emr=1&osid=1&flowName=GlifWebSignIn&flowEntry=ServiceLogin");

                GMAILPage gmailpg = new GMAILPage(WebDriver);
                gmailpg.Username().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Username().SendKeys("manualtestdemob@gmail.com");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.UserNext().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                gmailpg.Password().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.PasswordNext().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                gmailpg.Search().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Search().SendKeys("INVSPLIT@" + randnumber1);
                //gmailpg.Search().SendKeys("INVGSTNOSUR@648913894");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                
                IWebElement bodyTag12 = WebDriver.FindElement(By.TagName("body"));
                bool Content1 = bodyTag12.Text.Contains("No messages matched your search");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Content1 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                
                DateTime newDate = DateTime.Now;
                string dtString3 = newDate.ToString("dd/MM/yyyy");

                gmailpg.Search().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Search().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Search().SendKeys("INVSPLIT2@" + randnumber1);
                //gmailpg.Search().SendKeys("INVGSTNOSUR@648913894");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag112 = WebDriver.FindElement(By.TagName("body"));
                bool Content11 = bodyTag112.Text.Contains("Your invoice has been paid");
                bool Content12 = bodyTag112.Text.Contains("madcowtesting10+11111 paid your invoice on the " + dtString3);
                bool Content13 = bodyTag112.Text.Contains("$304.09");
                bool Content14 = bodyTag112.Text.Contains("No further action is required.");

                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Content11 == true && Content12 == true && Content13 == true && Content14 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.BacktoSearchresult().Click();


                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.profile().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.signout().Click();

                SeleniumSetMethods.WaitOnPage(secdelay5);

                //Verifying the payer Emails and PDF
                gmailpg.Antotheraccount().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                DateTime duedate3 = DateTime.Today.AddDays(15);
                string SentPgDueDate3 = duedate3.ToString("dd MMM yyyy");
                gmailpg.Username().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Username().SendKeys("madcowtesting10@gmail.com");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.UserNext().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                gmailpg.Password().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.PasswordNext().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                gmailpg.Search().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Search().SendKeys("INVSPLIT@" + randnumber1);
                //gmailpg.Search().SendKeys("Invoice reference : INVMTWRDDEAL@1605161184");
                //gmailpg.Search().SendKeys("Invoice reference : INVMTCCADEAL@2027114439");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                gmailpg.SearchButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag122 = WebDriver.FindElement(By.TagName("body"));
                bool Content121 = bodyTag122.Text.Contains("Failed Payment");
                bool Content122 = bodyTag122.Text.Contains("Your payment of invoice INVSPLIT@"+ randnumber1 + " was unsuccessfull.");
                bool Content123 = bodyTag122.Text.Contains("411111...490");
                bool Content124 = bodyTag122.Text.Contains("Unfortunately we could not process your transaction. Please check your information and try again.");
                
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Content121 == true && Content122 == true && Content123 == true && Content124 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.BacktoSearchresult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Search().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Search().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Search().SendKeys("INVSPLIT2@" + randnumber1);
                //gmailpg.Search().SendKeys("INVGSTNOSUR@648913894");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag113 = WebDriver.FindElement(By.TagName("body"));
                bool Content1001 = bodyTag113.Text.Contains("Payment confirmation");
                bool Content1002 = bodyTag113.Text.Contains("You made a successful payment on the " + dtString3);
                bool Content1003 = bodyTag113.Text.Contains("$304.09");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Content1001 == true && Content1002 == true && Content1003 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.BacktoSearchresult().Click();


                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.profile().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.signout().Click();

            }
            finally
            {
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com");

            }

        }

        [Test]
        public void ManualTest10_Payments04_EmailVerification_ExpiredInvoiceDeal()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {
                //Payment against expired deal invoice and expired invoice.
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
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
                SendPage SendPg = new SendPage(WebDriver);

                //Issue Invoice - Webapp - Create Invoice - Internalpayer - HTML Tags
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
                IssueInvoicePg.BusinessName().SendKeys("manualtestdemob+gstpayer");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "60 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVEXPDEAL@" + randnumber1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to External Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("299.10");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Message().SendKeys("This invoice issue to internal payer");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.NewTotal().SendKeys("299.10");
                DateTime newDate = DateTime.Now;
                string dtString3 = newDate.ToString("dd/MM/yyyy");
                IssueInvoicePg.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
                IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("INVEXPDEAL@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPage sivpg = new SIVPage(WebDriver);
                sivpg.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BusinessName().SendKeys("manualtestdemob+gstpayer");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms1 = "BY DUE DATE";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms1);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.DueDate().SendKeys(dtString3);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVEXPINV@" + randnumber1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to External Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("299.10");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Message().SendKeys("This invoice issue to internal payer");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("INVEXPINV@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+gstpayer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVEXPINV@");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber = sivpg.InvNumber().Text;
                string invoicenumber = invnumber.Substring(invnumber.IndexOf("Invoice ")).Replace("Invoice ", "");
                IWebElement bodyTag1 = WebDriver.FindElement(By.TagName("body"));
                bool dealamt = bodyTag1.Text.Contains("$299.10");
                bool invamt = bodyTag1.Text.Contains("$329.01");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(dealamt == false && invamt == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                sivpg.PayBTNNoDeal().Click();
                //validate the amount is $329.01
                //valid and invalid card selection
                PayNowPage Paynwpg = new PayNowPage(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paynwpg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Paynwpg.CardRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SeleniumSetMethods.WaitOnPage(secdelay4);
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
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string paidstatushover = Recpg.HistoryPaidStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover.Contains("paid"));
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.ToPayTab().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.SearchInvoiceReceived().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().SendKeys("INVEXPDEAL@");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber2 = sivpg.InvNumber().Text;
                string invoicenumber2 = invnumber.Substring(invnumber.IndexOf("Invoice ")).Replace("Invoice ", "");
                IWebElement bodyTag2 = WebDriver.FindElement(By.TagName("body"));
                bool dealamt1 = bodyTag2.Text.Contains("$299.10");
                bool invamt1 = bodyTag2.Text.Contains("$329.01");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(dealamt == false && invamt == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                sivpg.PayBTNNoDeal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paynwpg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Paynwpg.CardRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Paynwpg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paynwpg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ReceivedHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                String status3 = sivpg.InvoiceStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(status3.Contains("PAID"));
                SeleniumSetMethods.WaitOnPage(secdelay2);

            }
            finally
            {
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com");

            }

        }


        [Test]
        public void ManualTest11_EmailVerification_SIVCASHREQ_SubjectLineInvRefCheck()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {
                //Payment against expired deal invoice and expired invoice.
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
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
                SendPage SendPg = new SendPage(WebDriver);

                //Issue Invoice - Webapp - Create Invoice - Internalpayer - HTML Tags
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
                IssueInvoicePg.BusinessName().SendKeys("manualtestdemob+gstpayer");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "60 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("SubjectRefCheck@" + randnumber1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to External Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("299.10");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Message().SendKeys("This invoice issue to internal payer");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("SubjectRefCheck@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SIVPage sivpg = new SIVPage(WebDriver);
                sivpg.RequestBillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                BillzyCashModal BillzyCashMlPg = new BillzyCashModal(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                BillzyCashMlPg.BillzyCashConfirmBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                sivpg.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                //Verify the subjectline in the gmail account

                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://accounts.google.com/signin/v2/identifier?service=mail&passive=true&rm=false&continue=https%3A%2F%2Fmail.google.com%2Fmail%2F&ss=1&scc=1&ltmpl=default&ltmplcache=2&emr=1&osid=1&flowName=GlifWebSignIn&flowEntry=ServiceLogin");
                GMAILPage gmailpg = new GMAILPage(WebDriver);
                DateTime duedate1 = DateTime.Today.AddDays(90);
                string SentPgDueDate = duedate1.ToString("dd MMM yyyy");
                gmailpg.Username().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Username().SendKeys("manualtestdemob@gmail.com");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.UserNext().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                gmailpg.Password().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.PasswordNext().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                gmailpg.Search().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Search().SendKeys("Invoice reference : SubjectRefCheck@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IWebElement bodyTag1 = WebDriver.FindElement(By.TagName("body"));
                bool subjectline = bodyTag1.Text.Contains("Please verify your invoice SubjectRefCheck@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(subjectline == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.profile().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.signout().Click();
                
            }
            finally
            {
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com");

            }

        }

        [Test]
        public void ManualTest12_EmailVerification_CASHAPPROVAL()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {         
                //Payment against expired deal invoice and expired invoice.
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
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
                SendPage SendPg = new SendPage(WebDriver);

                //Issue Invoice - Webapp - Create Invoice - Internalpayer - HTML Tags
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
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+11111");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "60 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("CashAPPEMAILCHECK@" + randnumber1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to External Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("299.10");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Message().SendKeys("This invoice issue to internal payer");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("CashAPPEMAILCHECK@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

              
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SIVPage SIVPG1 = new SIVPage(WebDriver);
                string invnumber = SIVPG1.InvNumber().Text;

                string invoicenumber = invnumber.Substring(invnumber.IndexOf("Invoice ")).Replace("Invoice ", "");


                SeleniumSetMethods.WaitOnPage(secdelay4);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                addrecord(invoicenumber, "approved", "FactorFox.csv");
                SeleniumSetMethods.WaitOnPage(secdelay2);


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

                HomePg.Uploadfactorfox().SendKeys(@"C:\Users\BillzyAdmin\OneDrive - Billzy\BillzyTestSuite\BillzyAutomationTestSuite\bin\Debug\netcoreapp3.0\FactorFox.csv");
                SeleniumSetMethods.WaitOnPage(secdelay10);
                IAlert alert = WebDriver.SwitchTo().Alert();
                alert.Accept();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                //string invoicenumber = "INV10309557";
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string cashapprove = HomePg.FFApproved().Text;
                bool approvebtn = HomePg.Approvebtn().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(cashapprove.Contains("FF Approved") && approvebtn == true);
                SeleniumSetMethods.WaitOnPage(secdelay5);

                IWebElement ApproveButton = WebDriver.FindElement(By.XPath("//td[text()=\"" + invoicenumber + "\"]/../td/button[text()=\"approve\"]"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ApproveButton.Click();
                //HomePg.Approvebtn().Click();

                SeleniumSetMethods.WaitOnPage(secdelay6);
                HomePg.Cashratesubmit().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                alert.Accept();
                HomePg.FCLogout().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                DateTime duedate0 = DateTime.Today;
                string ApprovalDate = duedate0.ToString("dd/MM/yyyy");
                DateTime duedate1 = DateTime.Today.AddDays(60);
                string SentPgDueDate1 = duedate1.ToString("dd/MM/yyyy");
                string pdfdate = duedate0.ToString("yyyy-M-dd");

                //Verify the subjectline in the gmail account

                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://accounts.google.com/signin/v2/identifier?service=mail&passive=true&rm=false&continue=https%3A%2F%2Fmail.google.com%2Fmail%2F&ss=1&scc=1&ltmpl=default&ltmplcache=2&emr=1&osid=1&flowName=GlifWebSignIn&flowEntry=ServiceLogin");
                GMAILPage gmailpg = new GMAILPage(WebDriver);
                
                gmailpg.Username().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Username().SendKeys("manualtestdemob@gmail.com");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.UserNext().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                gmailpg.Password().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.PasswordNext().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                gmailpg.Search().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Search().SendKeys("CashAPPEMAILCHECK@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Tab).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Tab).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Tab).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Tab).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Tab).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Tab).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Tab).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Tab).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                IWebElement bodyTag1 = WebDriver.FindElement(By.TagName("body"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string pdf = bodyTag1.Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Console.WriteLine(bodyTag1.Text);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(bodyTag1.Text.Contains("SCHEDULE FEES AND CHARGES BILLZY CASH") && bodyTag1.Text.Contains("Between manualtestdemob+gstbiller a corporation organized and existing under the laws of QLD, with its head")  && bodyTag1.Text.Contains("Office located at:") && bodyTag1.Text.Contains("370 Queen St,") && bodyTag1.Text.Contains("Brisbane QLD 4000") && bodyTag1.Text.Contains("And Billzy Pty Ltd a corporation organized and existing under the laws of QLD, with its Head office located at:") && bodyTag1.Text.Contains("1/450 Sherwood Road") && bodyTag1.Text.Contains("SHERWOOD QLD 4075") && bodyTag1.Text.Contains("Date: ") && bodyTag1.Text.Contains(SentPgDueDate1));
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(bodyTag1.Text.Contains("TOTAL INVOICE AMOUNT TOTAL INVOICE PAID NOW FACILITY FEE + GST") &&  bodyTag1.Text.Contains("CashAPPEMAI") && bodyTag1.Text.Contains("LCHECK") && bodyTag1.Text.Contains("$329.01 $263.21 $16.45") && bodyTag1.Text.Contains("TOTAL $329.01 $263.21 $16.45") && bodyTag1.Text.Contains("Upon approval of your request for finance, $263.21 of the invoice value will be paid to your nominated merchant account. $65.80 of") && bodyTag1.Text.Contains("the invoice value (The Retention Fund) will be retained until the invoice is paid out. When this occurs you will be paid the Retention") && bodyTag1.Text.Contains("Fund less applicable fees."));             
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(bodyTag1.Text.Contains("A Facility Fee of $16.45 incl. GST applies (standard term of 30 days).") && bodyTag1.Text.Contains("At all times you remain responsible for the payment of your invoice and any payments made after 30 days will accrue pro rata late")  && bodyTag1.Text.Contains("fees based on 5.0000% incl. GST.") && bodyTag1.Text.Contains("This request and funding will automatically be cancelled if payment is initiated by your debtor prior to funding by Billzy.") && bodyTag1.Text.Contains("Francis Cox") && bodyTag1.Text.Contains("contact@billzy.com") && bodyTag1.Text.Contains("1300BILLZY") && bodyTag1.Text.Contains("cashApproval_"+ pdfdate + "_"+ invoicenumber + ".pdf"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(bodyTag1.Text.Contains("Your billzy Cash request CashAPPEMAILCHECK@" + randnumber1+" is approved") && bodyTag1.Text.Contains("Within the next 24 hours your registered account will be credited for $263.21 and you should expect a payment of the remaining amount once madcowtesting10+11111 has paid the invoice."));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Tab).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Tab).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Tab).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Tab).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Tab).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                gmailpg.profile().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.signout().Click();

            }
            finally
            {
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com");

            }

        }

        [Test]
        public void ManualTest13_EmailVerification_InvoicePDFValidation()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {
                //Payment against expired deal invoice and expired invoice.
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
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
                SendPage SendPg = new SendPage(WebDriver);

                //Issue Invoice - Webapp - Create Invoice - Internalpayer - HTML Tags
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
                IssueInvoicePg.BusinessName().SendKeys("External1");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "60 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("PDFValidation@" + randnumber1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to External Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("299.10");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Message().SendKeys("This invoice issue to internal payer");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("PDFValidation@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay7);

                //Verify the subjectline in the gmail account

                DateTime duedate0 = DateTime.Today;
                string iSSUEDATE = duedate0.ToString("dd MMM yyyy");
                DateTime duedate1 = DateTime.Today.AddDays(60);
                string SentPgDueDate1 = duedate1.ToString("dd MMM yyyy");
                
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://accounts.google.com/signin/v2/identifier?service=mail&passive=true&rm=false&continue=https%3A%2F%2Fmail.google.com%2Fmail%2F&ss=1&scc=1&ltmpl=default&ltmplcache=2&emr=1&osid=1&flowName=GlifWebSignIn&flowEntry=ServiceLogin");
                GMAILPage gmailpg = new GMAILPage(WebDriver);

                gmailpg.Username().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Username().SendKeys("madcowtesting10@gmail.com");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.UserNext().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                gmailpg.Password().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.PasswordNext().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                gmailpg.Search().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //gmailpg.Search().SendKeys("PDFValidation@" + randnumber1);
                gmailpg.Search().SendKeys("PDFValidation@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Tab).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Tab).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Tab).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Tab).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Tab).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Tab).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Tab).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Tab).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Tab).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                IWebElement bodyTag1 = WebDriver.FindElement(By.TagName("body"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string pdf = bodyTag1.Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Console.WriteLine(bodyTag1.Text);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(bodyTag1.Text.Contains("manualtestdemob+gstbiller has sent you an invoice") && bodyTag1.Text.Contains("If paying via bank transfer, pay to:") && bodyTag1.Text.Contains("Account Name: Billzy Clearing") && bodyTag1.Text.Contains("BSB Number: 034 001") && bodyTag1.Text.Contains("Account Number: 589326") && bodyTag1.Text.Contains("Reference Number: PDFValidation@") && bodyTag1.Text.Contains("ABN 12345678911") && bodyTag1.Text.Contains("370 Queen St") && bodyTag1.Text.Contains("Brisbane") && bodyTag1.Text.Contains("4000"));
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(bodyTag1.Text.Contains("Ph 12345678") && bodyTag1.Text.Contains("manualtestdemob+gstbiller@gmail.com\r\nInvoice to\r\nExternal1\r\nABN 98765432101\r\nlade street\r\nbrisbane\r\nQLD 4000") && bodyTag1.Text.Contains("TAX INVOICE\r\nTOTAL DUE DUE DATE INVOICE # ISSUED\r\n$329.01 " + SentPgDueDate1) && bodyTag1.Text.Contains("DESCRIPTION AMOUNT\r\nTest Invoice issued to External Payer $299.10\r\nSubtotal (excl. GST) $299.10\r\nGST (10%) $29.91\r\nTotal amount (incl. GST) $329.01") && bodyTag1.Text.Contains("A payment processing fee applies to credit & debit card payments\r\n(VISA and MasterCard: 1.67%), inclusive of GST"));
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(bodyTag1.Text.Contains(iSSUEDATE) && bodyTag1.Text.Contains(SentPgDueDate1));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Tab).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Tab).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Tab).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Tab).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Tab).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                gmailpg.profile().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.signout().Click();

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
