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
using OpenQA.Selenium.Interactions;

namespace BillzyAutomationTestSuite.Scripts
{
    [TestFixture]
    [Parallelizable]
    class SNSValidation : Tests
    {
        /*******************************************************************************************
            Scenario 1 : SNS verification while manual direct debit from Fincon
            Scenario 2 : SNS verification while Deal Request, Deal Counter and Deal Approve
            Scenario 3 : SNS verification while Cash Request and Cash Approve
            Scenario 4 : SNS verification while payent made by Credit Card
            Scenario 5 : SNS verification while payent made by Bank Transfer
        *******************************************************************************************/

        [Test]
        public void SNS01_ManualDirectDebit_FinCon()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+2123659734@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                // HomePage HomePg = new HomePage(WebDriver);
                SendPage SendPg = new SendPage(WebDriver);
                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                BillzyCashModal BillzyCashMlPg = new BillzyCashModal(WebDriver);
                SIVPage SIVPG1 = new SIVPage(WebDriver);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("ExternalNoGST@2123659734");
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
                String PaymentTerms = "14 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("ManaulDD@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to External Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("185.25");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("ManaulDD@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string invnumber = SIVPG1.InvNumber().Text;
                string invoicenumber = invnumber.Substring(invnumber.IndexOf("Invoice ")).Replace("Invoice ", "");
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
                SeleniumSetMethods.WaitOnPage(secdelay7);
                HomePg.FCAccountName().SendKeys("DDTest"+randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.FCBSB().SendKeys("032999");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.FCAccountNumber().SendKeys("999994");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.FCAmount().SendKeys("185.25");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.FCDDInvNum().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.FCDDComment().SendKeys("DD processed against " + invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.FCDDSubmit().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                IAlert alert = WebDriver.SwitchTo().Alert();
                alert.Accept();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.FCLogout().Click();
                SeleniumSetMethods.WaitOnPage(secdelay9);
                SeleniumSetMethods.WaitOnPage(secdelay9);

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
                gmailpg.Search().SendKeys("comment: DD processed against "+ invoicenumber);
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
                IWebElement bodyTag1 = WebDriver.FindElement(By.TagName("body"));
                bool Content1 = bodyTag1.Text.Contains("The following direct debit has been entered into the system.");
                bool Content2 = bodyTag1.Text.Contains("Please check that it's valid and correct.");
                bool Content4 = bodyTag1.Text.Contains("Account Name: DDTest"+randnumber2);
                bool Content5 = bodyTag1.Text.Contains("Account Number: 999994");
                bool Content6 = bodyTag1.Text.Contains("BSB: 032999");
                bool Content7 = bodyTag1.Text.Contains("Amount: 185.25");
                bool Content8 = bodyTag1.Text.Contains("Invoice Number: "+invoicenumber);
                bool Content9 = bodyTag1.Text.Contains("If it is NOT valid click the link below");
                bool Content10 = bodyTag1.Text.Contains("If it is valid and you would like it to be processeded click the link below.");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Content1 == true && Content2 == true && Content4 == true && Content5 == true && Content6 == true && Content7 == true && Content8 == true && Content9 == true && Content10 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                var tabs = WebDriver.WindowHandles;
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
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
                string approvedmsg = gmailpg.ManualDDApprove().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(approvedmsg.Contains("DIRECT DEBIT HAS BEEN Approved"));
                WebDriver.Close();
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
                SeleniumSetMethods.WaitOnPage(secdelay4);
                gmailpg.profile().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.signout().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

            }
            finally
            {

            }
        }

        [Test]
        public void SNS02_BillzyDeal_SentMakeACounterAccept()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+2123659734@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                // HomePage HomePg = new HomePage(WebDriver);
                SendPage SendPg = new SendPage(WebDriver);
                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                BillzyCashModal BillzyCashMlPg = new BillzyCashModal(WebDriver);
                SIVPage SIVPG1 = new SIVPage(WebDriver);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+1120168103");
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
                String PaymentTerms = "14 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("DealAcc@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to External Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.NewTotal().SendKeys("90");

                DateTime newDate = DateTime.Now.AddDays(2);
                string dtString3 = newDate.ToString("dd/MM/yyyy");

                IssueInvoicePg.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
                IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");

                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("DealAcc@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string invnumber = SIVPG1.InvNumber().Text;
                string invoicenumber = invnumber.Substring(invnumber.IndexOf("Invoice ")).Replace("Invoice ", "");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+1120168103@gmail.com");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.PayerMakeACounterOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                DateTime duedate000 = DateTime.Today.AddDays(5);
                string SentPgDueDate2 = duedate000.ToString("dd/MM/yyyy");
                SIVPG1.NewTotal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.NewTotal().SendKeys("80");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                SIVPG1.Comments().SendKeys("Payer Requested a Deal");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.makeCounterOfferModalBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.SignOutBTN().Click();

                SeleniumSetMethods.WaitOnPage(secdelay4);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+2123659734@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SIVPG1.AcceptOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.AcceptTheOfferModalYesBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay9);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.SignOutBTN().Click();

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
                gmailpg.Search().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag1 = WebDriver.FindElement(By.TagName("body"));
                bool Content1 = bodyTag1.Text.Contains("A deal has been created by  the biller.");
                bool Content2 = bodyTag1.Text.Contains("biller email: madcowtesting10+2123659734@gmail.com");
                bool Content4 = bodyTag1.Text.Contains("biller company name: madcowtesting10+2123659734");
                bool Content5 = bodyTag1.Text.Contains("payer email: madcowtesting10+1120168103@gmail.com");
                bool Content6 = bodyTag1.Text.Contains("payer company name: madcowtesting10+1120168103");
                bool Content7 = bodyTag1.Text.Contains("initial invoice amount: 100.00");
                bool Content8 = bodyTag1.Text.Contains("deal amount offered 90.00");
                bool Content9 = bodyTag1.Text.Contains("deal percentage offered 10.00");
                bool Content10 = bodyTag1.Text.Contains(" invoice number: ");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Content1 == true && Content2 == true && Content4 == true && Content5 == true && Content6 == true && Content7 == true && Content8 == true && Content9 == true && Content10 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.BacktoSearchresult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowUp).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag2 = WebDriver.FindElement(By.TagName("body"));
                bool Content21 = bodyTag2.Text.Contains("A deal has been created by  the payer.");
                bool Content22 = bodyTag2.Text.Contains("biller email: madcowtesting10+2123659734@gmail.com");
                bool Content24 = bodyTag2.Text.Contains("biller company name: madcowtesting10+2123659734");
                bool Content25 = bodyTag2.Text.Contains("payer email: madcowtesting10+1120168103@gmail.com");
                bool Content26 = bodyTag2.Text.Contains("payer company name: madcowtesting10+1120168103");
                bool Content27 = bodyTag2.Text.Contains("initial invoice amount: 100.00");
                bool Content28 = bodyTag2.Text.Contains("deal amount offered 80.00");
                bool Content29 = bodyTag2.Text.Contains("deal percentage offered 20.00");
                bool Content210 = bodyTag2.Text.Contains(" invoice number: ");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Content21 == true && Content22 == true && Content24 == true && Content25 == true && Content26 == true && Content27 == true && Content28 == true && Content29 == true && Content210 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.BacktoSearchresult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                gmailpg.Search().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Search().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Search().SendKeys("and provide a discount of $20.00 for invoice DealAcc@"+randnumber2);
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
                bool Content31 = bodyTag3.Text.Contains("madcowtesting10+1120168103 has requested a new deal. If you accept, you will be paid 0 days earlier and provide a discount of $20.00");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Content31 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.BacktoSearchresult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                gmailpg.Search().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Search().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Search().SendKeys("madcowtesting10+2123659734 has accepted your deal. For you to save $20.00, you must complete payment ");
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
                bool Content41 = bodyTag4.Text.Contains("madcowtesting10+2123659734 has accepted your deal. For you to save $20.00, you must complete payment by ");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Content41 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.BacktoSearchresult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

               
                gmailpg.profile().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.signout().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

            }
            finally
            {

            }
        }

        [Test]
        public void SNS03_BillzyCash_ReqApprove()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+2123659734@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                // HomePage HomePg = new HomePage(WebDriver);
                SendPage SendPg = new SendPage(WebDriver);
                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                BillzyCashModal BillzyCashMlPg = new BillzyCashModal(WebDriver);
                SIVPage SIVPG1 = new SIVPage(WebDriver);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                Random rand = new Random();
                DateTime dt = new DateTime();
                string dtString = dt.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber1 = rand.Next();
                Random rand2 = new Random();
                DateTime dt2 = new DateTime();
                string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber2 = rand.Next();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "14 days";

                SeleniumSetMethods.WaitOnPage(secdelay5);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+1120168103");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("CashSNS" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                SendPg.SearchInvoiceSent().SendKeys("CashSNS" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string invnumber = SIVPG1.InvNumber().Text;
                string invoicenumber = invnumber.Substring(invnumber.IndexOf("Invoice ")).Replace("Invoice ", "");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                addrecord(invoicenumber, "approved", "FactorFox.csv");
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("billzydemo+financial-controller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SeleniumSetMethods.WaitOnPage(secdelay5);

                HomePg.Uploadfactorfox().SendKeys(@"C:\Users\Selenium\Desktop\SeleniumRegressionSuite_Bamboo\bin\Debug\netcoreapp3.1\FactorFox.csv");
                SeleniumSetMethods.WaitOnPage(secdelay7);
                IAlert alert = WebDriver.SwitchTo().Alert();
                alert.Accept();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                //string invoicenumber = "INV10309557";
                SeleniumSetMethods.WaitOnPage(secdelay2);
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
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SeleniumSetMethods.WaitOnPage(secdelay9);
                SeleniumSetMethods.WaitOnPage(secdelay9);

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
                gmailpg.Search().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag1 = WebDriver.FindElement(By.TagName("body"));
                bool Content1 = bodyTag1.Text.Contains("madcowtesting10+2123659734 requested billzyCash at");
                bool Content2 = bodyTag1.Text.Contains("for invoice number "+invoicenumber+", with customer reference CashSNS"+randnumber2+".");
                bool Content4 = bodyTag1.Text.Contains("This user is enabled for cash");
                bool Content5 = bodyTag1.Text.Contains("Invoice Recipient: madcowtesting10+1120168103");
                bool Content6 = bodyTag1.Text.Contains("Total Invoice Amount: $100.00");
                bool Content7 = bodyTag1.Text.Contains("Get Paid Now: $80.00");
                bool Content8 = bodyTag1.Text.Contains("Get Paid Later Up To: $15.00. Minus Late Fees.");
                bool Content9 = bodyTag1.Text.Contains("Biller Merchant Account BSB: 484799");
                bool Content10 = bodyTag1.Text.Contains("Biller Merchant Account Number: 65432111");
                bool Content3 = bodyTag1.Text.Contains("Biller Merchant Account Name: receiveAccount");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Content1 == true && Content2 == true && Content3 == true && Content4 == true && Content5 == true && Content6 == true && Content7 == true && Content8 == true && Content9 == true && Content10 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.BacktoSearchresult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowUp).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag2 = WebDriver.FindElement(By.TagName("body"));
                bool Content21 = bodyTag2.Text.Contains("The following details relate to the member who has been approved for billzy cash");
                bool Content22 = bodyTag2.Text.Contains("Billzy member: madcowtesting10+2123659734");
                bool Content24 = bodyTag2.Text.Contains("Billzy member ID: 48614");
                bool Content25 = bodyTag2.Text.Contains("Invoice recipient: madcowtesting10+1120168103 (INTERNAL)");
                bool Content26 = bodyTag2.Text.Contains("Total Invoice Amount: $100.00");
                bool Content27 = bodyTag2.Text.Contains("Get Paid Now: $80.00");
                bool Content28 = bodyTag2.Text.Contains("Get Paid Later Up To: $15.00. Minus late fees");
                bool Content29 = bodyTag2.Text.Contains("madcowtesting10+2123659734 has been approved for 80.00");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Content21 == true && Content22 == true && Content24 == true && Content25 == true && Content26 == true && Content27 == true && Content28 == true && Content29 == true );
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.BacktoSearchresult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                gmailpg.profile().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.signout().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

            }
            finally
            {

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

        [Test]
        public void SNS04_BillzyPayment_CreditCard()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+2123659734@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                // HomePage HomePg = new HomePage(WebDriver);
                SendPage SendPg = new SendPage(WebDriver);
                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                BillzyCashModal BillzyCashMlPg = new BillzyCashModal(WebDriver);
                SIVPage SIVPG1 = new SIVPage(WebDriver);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                Random rand = new Random();
                DateTime dt = new DateTime();
                string dtString = dt.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber1 = rand.Next();
                Random rand2 = new Random();
                DateTime dt2 = new DateTime();
                string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber2 = rand.Next();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "14 days";

                SeleniumSetMethods.WaitOnPage(secdelay5);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+1120168103");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("CardpaySNS" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                SendPg.SearchInvoiceSent().SendKeys("CardpaySNS" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string invnumber = SIVPG1.InvNumber().Text;
                string invoicenumber = invnumber.Substring(invnumber.IndexOf("Invoice ")).Replace("Invoice ", "");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+1120168103@gmail.com");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);

                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay5);
               
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.PAY().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //Proceed to payment
                PayNowPage PNPg = new PayNowPage(WebDriver);
                PNPg.CcDropDown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PNPg.CardRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PNPg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PNPg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.ReceivedHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();

                SeleniumSetMethods.WaitOnPage(secdelay3);
                SeleniumSetMethods.WaitOnPage(secdelay9);
                SeleniumSetMethods.WaitOnPage(secdelay9);

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
                gmailpg.Search().SendKeys("CardpaySNS"+randnumber2);
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
                IWebElement bodyTag1 = WebDriver.FindElement(By.TagName("body"));
                bool Content1 = bodyTag1.Text.Contains("madcowtesting10+1120168103 has completed a payment of $100.00 for your invoice, CardpaySNS"+randnumber2);
                
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Content1 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                
                gmailpg.BacktoSearchresult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                gmailpg.profile().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.signout().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

            }
            finally
            {

            }
        }

        [Test]
        public void SNS05_BillzyPayment_BankPay()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+2123659734@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                // HomePage HomePg = new HomePage(WebDriver);
                SendPage SendPg = new SendPage(WebDriver);
                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                BillzyCashModal BillzyCashMlPg = new BillzyCashModal(WebDriver);
                SIVPage SIVPG1 = new SIVPage(WebDriver);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                Random rand = new Random();
                DateTime dt = new DateTime();
                string dtString = dt.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber1 = rand.Next();
                Random rand2 = new Random();
                DateTime dt2 = new DateTime();
                string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber2 = rand.Next();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "14 days";

                SeleniumSetMethods.WaitOnPage(secdelay5);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+1120168103");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("BankpaySNS" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(secdelay1);

                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                SendPg.SearchInvoiceSent().SendKeys("BankpaySNS" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string invnumber = SIVPG1.InvNumber().Text;
                string invoicenumber = invnumber.Substring(invnumber.IndexOf("Invoice ")).Replace("Invoice ", "");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+1120168103@gmail.com");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);

                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                
                //Proceed to payment
                PayNowPage Paynwpg = new PayNowPage(WebDriver);

                Recpg.SelectInvoiceRow01().Click();
                SeleniumSetMethods.WaitOnPage(2);
                Recpg.PayBTNTop().Click();
                SeleniumSetMethods.WaitOnPage(2);
                Paynwpg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(3);
                Paynwpg.CardRow02().Click();
                SeleniumSetMethods.WaitOnPage(3);
                Paynwpg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                Paynwpg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
               
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.ReceivedHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();

                SeleniumSetMethods.WaitOnPage(secdelay3);
                SeleniumSetMethods.WaitOnPage(secdelay9);
                SeleniumSetMethods.WaitOnPage(secdelay9);

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
                gmailpg.Search().SendKeys("BankpaySNS"+randnumber2);
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
                IWebElement bodyTag1 = WebDriver.FindElement(By.TagName("body"));
                bool Content1 = bodyTag1.Text.Contains("madcowtesting10+1120168103 has initiated a bank transfer payment of $100.00 for your invoice, BankpaySNS"+randnumber2+". This payment is currently being processed by their financial institution");
               
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Content1 == true );
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.BacktoSearchresult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                
                gmailpg.profile().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.signout().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

            }
            finally
            {

            }
        }

    }
}
