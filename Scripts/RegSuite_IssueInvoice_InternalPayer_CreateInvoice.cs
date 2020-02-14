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
    class RegSuite_IssueInvoice_InternalPayer_CreateInvoice : Tests
    {
        [Test]
        public void IssueInvoice01_InternalPayer_CreateInvoice_2LineItems_GST_Deal_Surcharge()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+intpaycreateinv@gmail.com");
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
                IssueInvoicePg.CreateInvoice().Click();
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("Ext-Inv@" + randnumber1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to External Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("200.15");
                IssueInvoicePg.AddLineItem().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.LineItem2().SendKeys("100.00");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                string subject = IssueInvoicePg.Subject().GetAttribute("value");
                string TotalGSTMsg = IssueInvoicePg.TotalGSTMsg().Text;
                string TotalValue = IssueInvoicePg.TotalValue().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(subject.Contains("madcowtesting10+IntPayCreateInv has sent you an invoice") && TotalGSTMsg.Contains("(incl. GST)") && TotalValue.Contains("$330.17"));
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.NewTotal().SendKeys("229");
                IWebElement bodyTag1 = WebDriver.FindElement(By.TagName("body"));
                bool disc1 = bodyTag1.Text.Contains("30.64% discount");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(disc1 == true);
                bool disc2 = bodyTag1.Text.Contains("Due in 30 days");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(disc2 == true);
                IssueInvoicePg.SurchargeCheckbox().Click();
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
        public void IssueInvoice02_InternalPayer_CreateInvoice_2LineItems_GST_Deal_N0Surcharge_WithHTMLTagsValues()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+intpaycreateinv@gmail.com");
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
                String PaymentTerms = "60 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                string invref = "script > alert(\"Hello\");</ script >";
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys(invref);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to External Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("299.10");
               
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Message().SendKeys(invref);
                string subject = IssueInvoicePg.Subject().GetAttribute("value");
                string TotalGSTMsg = IssueInvoicePg.TotalGSTMsg().Text;
                string TotalValue = IssueInvoicePg.TotalValue().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(subject.Contains("madcowtesting10+IntPayCreateInv has sent you an invoice") && TotalGSTMsg.Contains("(incl. GST)") && TotalValue.Contains("$329.01"));
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.NewTotal().SendKeys("200");
                IssueInvoicePg.Comments().SendKeys(invref);
                IWebElement bodyTag1 = WebDriver.FindElement(By.TagName("body"));
                bool disc1 = bodyTag1.Text.Contains("39.21% discount");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(disc1 == true);
                bool disc2 = bodyTag1.Text.Contains("Due in 60 days");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(disc2 == true);
               // IssueInvoicePg.SurchargeCheckbox().Click();
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
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("Int-Inv@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("Int-Inv@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.ToggleDealHistory().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                
                //string invref1 = "script>alert(\"Hello\")";
                string commvalue = SIVPG1.DiscountHistoryComment01().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(commvalue.Contains(invref));

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
        public void IssueInvoice03_InternalPayer_CreateInvoice_GST_NoDeal_NoSurcharge()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+intpaycreateinv@gmail.com");
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
                String PaymentTerms = "14 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("Int-Inv@" + randnumber1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to External Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("200.15");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                string subject = IssueInvoicePg.Subject().GetAttribute("value");
                string TotalGSTMsg = IssueInvoicePg.TotalGSTMsg().Text;
                string TotalValue = IssueInvoicePg.TotalValue().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(subject.Contains("madcowtesting10+IntPayCreateInv has sent you an invoice") && TotalGSTMsg.Contains("(incl. GST)") && TotalValue.Contains("$220.17"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("Int-Inv@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                DateTime duedate1 = DateTime.Today.AddDays(14);
                string SentPgDueDate = duedate1.ToString("dd MMM yy");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string due11 = SendPg.DueRow01().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(due11.Contains(SentPgDueDate));
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
        public void IssueInvoice04_InternalPayer_CreateInvoice_GST_NoDeal_Surcharge()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+intpaycreateinv@gmail.com");
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
                String PaymentTerms = "90 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("Int-Inv@" + randnumber1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to External Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("812.66");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                string subject = IssueInvoicePg.Subject().GetAttribute("value");
                string TotalGSTMsg = IssueInvoicePg.TotalGSTMsg().Text;
                string TotalValue = IssueInvoicePg.TotalValue().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(subject.Contains("madcowtesting10+IntPayCreateInv has sent you an invoice") && TotalGSTMsg.Contains("(incl. GST)") && TotalValue.Contains("$893.93"));
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("Int-Inv@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                DateTime duedate1 = DateTime.Today.AddDays(90);
                string SentPgDueDate = duedate1.ToString("dd MMM yy");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string due11 = SendPg.DueRow01().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(due11.Contains(SentPgDueDate));
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
        public void IssueInvoice05_InternalPayer_CreateInvoice_NoGST_Deal_NoSurcharge()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+IntPayCreateInvNOGST@gmail.com");
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
                String PaymentTerms = "90 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("Int-Inv@" + randnumber1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to External Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("1089.29");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                string subject = IssueInvoicePg.Subject().GetAttribute("value");
                string TotalGSTMsg = IssueInvoicePg.TotalGSTMsg().Text;
                string TotalValue = IssueInvoicePg.TotalValue().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(subject.Contains("madcowtesting10+IntPayCreateInvNOGST has sent you an invoice") && TotalGSTMsg.Contains("(excl. GST)") && TotalValue.Contains("$1,089.29"));
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.NewTotal().SendKeys("925.12");
                IssueInvoicePg.Comments().SendKeys("Deal is being offered excluding GST");
                IWebElement bodyTag1 = WebDriver.FindElement(By.TagName("body"));
                bool disc1 = bodyTag1.Text.Contains("15.07% discount");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(disc1 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //IssueInvoicePg.NewTotal().Click();
                //SeleniumSetMethods.WaitOnPage(secdelay3);
                //IssueInvoicePg.NewTotal().Clear();
  
                //IssueInvoicePg.NewTotal().SendKeys("900");
                //SeleniumSetMethods.WaitOnPage(secdelay2);
                //bool disc2 = bodyTag1.Text.Contains("17.38% discount");
                //SeleniumSetMethods.WaitOnPage(secdelay2);
                bool disc3 = bodyTag1.Text.Contains("Due in 90 days");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(disc3 == true);
                DateTime duedate2 = DateTime.Today.AddDays(19);
                string SentPgDueDate3 = duedate2.ToString("dd MMM yy");
                string SentPgDueDate33 = duedate2.ToString("dd/MM/yyyy");
                IssueInvoicePg.OfferExpiry().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.OfferExpiry().SendKeys(SentPgDueDate33);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.NewTotal().Click();
                bool dis4 = bodyTag1.Text.Contains("Due in 19 days");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(dis4 == true);
                // IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("Int-Inv@" + randnumber1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
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
        public void IssueInvoice06_InternalPayer_CreateInvoice_NoGST_Deal_Surcharge()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+IntPayCreateInvNOGST@gmail.com");
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
                String PaymentTerms = "90 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("Int-Inv@" + randnumber1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to External Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("1089.29");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                string subject = IssueInvoicePg.Subject().GetAttribute("value");
                string TotalGSTMsg = IssueInvoicePg.TotalGSTMsg().Text;
                string TotalValue = IssueInvoicePg.TotalValue().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(subject.Contains("madcowtesting10+IntPayCreateInvNOGST has sent you an invoice") && TotalGSTMsg.Contains("(excl. GST)") && TotalValue.Contains("$1,089.29"));
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.NewTotal().SendKeys("925.12");
                IssueInvoicePg.Comments().SendKeys("Deal is being offered excluding GST");
                IWebElement bodyTag1 = WebDriver.FindElement(By.TagName("body"));
                bool disc1 = bodyTag1.Text.Contains("15.07% discount");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(disc1 == true);
                //IssueInvoicePg.NewTotal().Click();
                //SeleniumSetMethods.WaitOnPage(secdelay2);
                //IssueInvoicePg.NewTotal().Clear();
                //SeleniumSetMethods.WaitOnPage(secdelay2);
                //IssueInvoicePg.NewTotal().SendKeys("900");
                //SeleniumSetMethods.WaitOnPage(secdelay2);
                //bool disc2 = bodyTag1.Text.Contains("17.38% discount");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool disc3 = bodyTag1.Text.Contains("Due in 90 days");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(disc3 == true);
                DateTime duedate2 = DateTime.Today.AddDays(19);
                string SentPgDueDate3 = duedate2.ToString("dd MMM yy");
                string SentPgDueDate33 = duedate2.ToString("dd/MM/yyyy");
                IssueInvoicePg.OfferExpiry().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.OfferExpiry().SendKeys(SentPgDueDate33);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.NewTotal().Click();
                bool dis4 = bodyTag1.Text.Contains("Due in 19 days");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(dis4 == true);
                IssueInvoicePg.SurchargeCheckbox().Click();
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
        public void IssueInvoice07_InternalPayer_CreateInvoice_NoGST_NoDeal_NoSurcharge()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+IntPayCreateInvNOGST@gmail.com");
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
                IssueInvoicePg.CreateInvoice().Click();
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("Int-Inv@" + randnumber1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to External Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("185.25");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                string subject = IssueInvoicePg.Subject().GetAttribute("value");
                string TotalGSTMsg = IssueInvoicePg.TotalGSTMsg().Text;
                string TotalValue = IssueInvoicePg.TotalValue().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(subject.Contains("madcowtesting10+IntPayCreateInvNOGST has sent you an invoice") && TotalGSTMsg.Contains("(excl. GST)") && TotalValue.Contains("$185.25"));
               
                DateTime duedate2 = DateTime.Today.AddDays(30);
                string SentPgDueDate3 = duedate2.ToString("dd MMM yy");
                string SentPgDueDate33 = duedate2.ToString("dd/MM/yyyy");
               
               
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
        public void IssueInvoice08_InternalPayer_CreateInvoice_NoGST_NoDeal_Surcharge()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+IntPayCreateInvNOGST@gmail.com");
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
                IssueInvoicePg.CreateInvoice().Click();
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("Int-Inv@" + randnumber1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to External Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("185.25");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                string subject = IssueInvoicePg.Subject().GetAttribute("value");
                string TotalGSTMsg = IssueInvoicePg.TotalGSTMsg().Text;
                string TotalValue = IssueInvoicePg.TotalValue().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(subject.Contains("madcowtesting10+IntPayCreateInvNOGST has sent you an invoice") && TotalGSTMsg.Contains("(excl. GST)") && TotalValue.Contains("$185.25"));

                DateTime duedate2 = DateTime.Today.AddDays(30);
                string SentPgDueDate3 = duedate2.ToString("dd MMM yy");
                string SentPgDueDate33 = duedate2.ToString("dd/MM/yyyy");

                IssueInvoicePg.SurchargeCheckbox().Click();
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
        public void IssueInvoice09_InternalPayer_CreateInvoice_NoGST_NoDeal_Surcharge_EndofNextMonth()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+IntPayCreateInvNOGST@gmail.com");
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
                IssueInvoicePg.CreateInvoice().Click();
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("Int-Inv@" + randnumber1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to External Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("185.25");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                string subject = IssueInvoicePg.Subject().GetAttribute("value");
                string TotalGSTMsg = IssueInvoicePg.TotalGSTMsg().Text;
                string TotalValue = IssueInvoicePg.TotalValue().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(subject.Contains("madcowtesting10+IntPayCreateInvNOGST has sent you an invoice") && TotalGSTMsg.Contains("(excl. GST)") && TotalValue.Contains("$185.25"));
                IssueInvoicePg.SurchargeCheckbox().Click();
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
