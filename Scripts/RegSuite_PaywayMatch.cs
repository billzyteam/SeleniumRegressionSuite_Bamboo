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
   
   
    class RegSuite_PaywayMatch : Tests
    {
       /* [Test]
        public void Payway01_SettlementReportGeneration()
        {
            HomePage HomePg = new HomePage(WebDriver);
            LoginPage loginPage = new LoginPage(WebDriver);
            try
            {

                WebDriver.Manage().Window.Maximize();

                WebDriver.Navigate().GoToUrl("https://www.payway.com.au/sign-in");
                PaywayPage Paywaypg = new PaywayPage(WebDriver);
                Paywaypg.Username().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paywaypg.Username().SendKeys("SELENIUM01");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paywaypg.Password().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paywaypg.Password().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paywaypg.SignIn().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Paywaypg.PaymentsTab().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Random rand2 = new Random();
                DateTime dt2 = new DateTime();
                string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber2 = rand2.Next();

                var invsetMAP1 = new List<string> { "110", "111.84","66","100","80","50"};
                for (int i = invsetMAP1.Count - 1; i >= 0; i--)
                {

                    Paywaypg.CustomerRefernceNumber().SendKeys("Inv-"+ randnumber2);
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    Paywaypg.CardHolderName().SendKeys("Valid");
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    Paywaypg.CardNumber().SendKeys("5163200000000008");
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    Paywaypg.ExpiryMonth().SendKeys("08");
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    Paywaypg.ExpiryYear().SendKeys("20");
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    Paywaypg.CardVerificationNumber().SendKeys("070");
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    Paywaypg.Amount().SendKeys(invsetMAP1[i]);
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    Paywaypg.PaymentNext().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    string Errmsg = Paywaypg.ErrorMessage().Text;
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    if (Errmsg.Contains("The payment you are about to process may be a duplicate"))
                    {
                        Paywaypg.ConfirmDuplicatePayment().Click();
                        SeleniumSetMethods.WaitOnPage(secdelay5);
                    }
                    else
                    {
                        Paywaypg.ConfirmPayment().Click();
                        SeleniumSetMethods.WaitOnPage(secdelay5);
                    }
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    Paywaypg.ProcessNewTRansaction().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay4);
                }
              SeleniumSetMethods.WaitOnPage(secdelay2);
              Paywaypg.Signout().Click();
              SeleniumSetMethods.WaitOnPage(secdelay2);
            }
            finally
            {
                

            }

        }*/

        [Test]
        public void Payway01_SettlementReportDisplay()
        {
            HomePage HomePg = new HomePage(WebDriver);
            LoginPage loginPage = new LoginPage(WebDriver);
            BOBOPage Bobopg = new BOBOPage(WebDriver);
            
            try
            {

                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                
                SendPage SendPg = new SendPage(WebDriver);
                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                BillzyCashModal BillzyCashMlPg = new BillzyCashModal(WebDriver);
                SIVPage SIVPG1 = new SIVPage(WebDriver);
                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+291754929@gmail.com");
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
                IssueInvoicePg.BusinessName().SendKeys("madcowpayer+dealppp01");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "30 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("Inv-67.1" + randnumber1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to External Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("67.1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("Inv-67.1" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string invnumber1 = SIVPG1.InvNumber().Text;
                string invoicenumber1 = invnumber1.Substring(invnumber1.IndexOf("Invoice ")).Replace("Invoice ", "");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://4impact-billzy-bobo-ui-uat.s3-ap-southeast-2.amazonaws.com/poc.html");

                Bobopg.Username().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.Username().SendKeys("madcowbiller+bobo_02@gmail.com");
                Bobopg.Password().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.Password().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.LoginBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                string textcheck = Bobopg.UserWelcomeMessage().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(textcheck.Contains("Welcome, madcowbiller+bobo_02@gmail.com"));
                Bobopg.PaywayTabSelection().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.MatchButton1().Click(); ;
                SeleniumSetMethods.WaitOnPage(secdelay5);
               
                Bobopg.MatchButtonCancel().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.MatchButton1().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                IWebElement MarkAsPaidInv = WebDriver.FindElement(By.XPath("(//*[@id=\"" + invoicenumber1 + "\"])[1]"));
                SeleniumSetMethods.WaitOnPage(secdelay3);
                MarkAsPaidInv.Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                IAlert alert1 = WebDriver.SwitchTo().Alert();
                alert1.Accept();
                SeleniumSetMethods.WaitOnPage(3);

                Bobopg.MatchButtonOk().Click();
            }
            finally
            {


            }

        }

    }
}
