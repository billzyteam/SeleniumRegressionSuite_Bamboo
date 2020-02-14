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
    public class RegSuite_IssueInvoice_ExternalPayer_CreateInvoice : Tests
    //class IssueInvoice_ExternalPayer_CreateInvoice : WebAppBaseTest
    {
        

        [Test]
        public void IssueInvoice01_ExternalPayer_CreateInvoice_GST_NoSurcharge()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+agstbiller@gmail.com");
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
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));
                bool errmsg1 = bodyTag.Text.Contains("For security reasons you must enter either a street address or ABN.");
                bool errmsg2 = bodyTag.Text.Contains("You must choose a valid business.");
                bool data1 = bodyTag.Text.Contains("Business Name");
                bool data2 = bodyTag.Text.Contains("ABN");
                bool data3 = bodyTag.Text.Contains("Email");
                bool data4 = bodyTag.Text.Contains("Street");
                bool data5 = bodyTag.Text.Contains("Suburb");
                bool data6 = bodyTag.Text.Contains("Postcode");
                
                bool data8 = bodyTag.Text.Contains("State");
                bool data9 = bodyTag.Text.Contains("Payment Terms");
                bool data10 = bodyTag.Text.Contains("Due Date");
                bool data11 = bodyTag.Text.Contains("PDF Invoice");
                bool data12 = bodyTag.Text.Contains("Subject");
                bool data13 = bodyTag.Text.Contains("Message");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(errmsg1 == true && errmsg2 == true && data1 == true && data2 == true && data3 == true && data4 == true && data5 == true && data6 == true && data8 == true && data9 == true && data10 == true && data11 == true && data12 == true && data13 == true);
                IssueInvoicePg.AddCustomerButton().Click();
                AddCustomerPage AddCustomerPg = new AddCustomerPage(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Random rand = new Random();
                DateTime dt = new DateTime();
                string dtString = dt.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber1 = rand.Next();
                bool data111 = bodyTag.Text.Contains("Business Name");
                bool data22 = bodyTag.Text.Contains("ABN");
                bool data33 = bodyTag.Text.Contains("Contact Email");
                bool data44 = bodyTag.Text.Contains("Street");
                bool data55 = bodyTag.Text.Contains("Suburb");
                bool data66 = bodyTag.Text.Contains("Postcode");
                bool data77 = bodyTag.Text.Contains("Country");
                bool data88 = bodyTag.Text.Contains("State");
                bool data99 = bodyTag.Text.Contains("Contact Name");
                bool data1010 = bodyTag.Text.Contains("Contact Phone Number");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(data111 == true && data22 == true && data33 == true && data44 == true && data55 == true && data66 == true && data77 == true && data88 == true && data99 == true && data1010 ==true);
                AddCustomerPg.BusinessName().Click();
                AddCustomerPg.BusinessName().SendKeys("ExternalGST@" + randnumber1);
                AddCustomerPg.Abn().SendKeys("abhushuhuhq");
                AddCustomerPg.ContactName().SendKeys("Test@" + randnumber1);
                AddCustomerPg.ContactEmail().SendKeys("test.com");
                AddCustomerPg.ContactPhoneNumber().SendKeys("12345671447");
                AddCustomerPg.Street().SendKeys("10 Miller Street");
                AddCustomerPg.Suburb().SendKeys("Murarrie");
                AddCustomerPg.Postcode().SendKeys("4172");
                AddCustomerPg.AddBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                bool errmsg11 = bodyTag.Text.Contains("The value entered was not a valid 11 digit ABN (numbers and spaces only).");
                bool errmsg22 = bodyTag.Text.Contains("The value needs to be a valid email address, e.g. something@somewhere.com");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(errmsg11 == true && errmsg22 == true);
                AddCustomerPg.Abn().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.Abn().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.Abn().SendKeys("1111111111");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.ContactEmail().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.ContactEmail().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                
                AddCustomerPg.ContactEmail().SendKeys("madcowtesting10+" + randnumber1 + "@gmail.com");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                AddCustomerPg.AddBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                bool errmsg33 = bodyTag.Text.Contains("Invalid ABN length");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(errmsg33 == true );

                AddCustomerPg.Abn().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.Abn().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.Abn().SendKeys("111111111111");
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
                AddCustomerPg.Abn().SendKeys("11111111111*");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.AddBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                bool errmsg55 = bodyTag.Text.Contains("The value entered was not a valid 11 digit ABN (numbers and spaces only).");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(errmsg44 == true);

                AddCustomerPg.Abn().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.Abn().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.Abn().SendKeys("11 111 111 111");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.AddBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                


                String PaymentTerms = "14 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("Ext-Inv@" + randnumber1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to External Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("185.12");
                IssueInvoicePg.PreviewInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                var tabs = WebDriver.WindowHandles;
                if (tabs.Count > 1)
                {
                    WebDriver.SwitchTo().Window(tabs[1]);
                    WebDriver.Close();
                    WebDriver.SwitchTo().Window(tabs[0]);
                }
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Outside().Click();
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                string subject = IssueInvoicePg.Subject().GetAttribute("value");
                string TotalGSTMsg = IssueInvoicePg.TotalGSTMsg().Text;
                string TotalValue = IssueInvoicePg.TotalValue().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(subject.Contains("madcowtesting10+agstbiller has sent you an invoice") && TotalGSTMsg.Contains("(incl. GST)") && TotalValue.Contains("$203.63"));
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
        public void IssueInvoice02_ExternalPayer_CreateInvoice_GST_Surcharge()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+agstbiller@gmail.com");
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
                IssueInvoicePg.BusinessName().SendKeys("External1");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "14 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("Ext-Inv@" + randnumber1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to External Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("1000");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                string subject = IssueInvoicePg.Subject().GetAttribute("value");
                string TotalGSTMsg = IssueInvoicePg.TotalGSTMsg().Text;
                string TotalValue = IssueInvoicePg.TotalValue().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(subject.Contains("madcowtesting10+agstbiller has sent you an invoice") && TotalGSTMsg.Contains("(incl. GST)") && TotalValue.Contains("$1,100.00"));
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
        public void IssueInvoice03_ExternalPayer_CreateInvoice_NoGST_NoSurcharge()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+anogstbiller@gmail.com");
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

                DateTime duedate1 = DateTime.Today.AddDays(30);
                string SentPgDueDate = duedate1.ToString("dd MMM yy");
                string SentPgDueDate1 = duedate1.ToString("dd/MM/yyyy");
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BusinessName().SendKeys("External1");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "30 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                bool due = bodyTag.Text.Contains(SentPgDueDate1);
                
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("Ext-Inv@" + randnumber1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to External Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("1000");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
               
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string subject = IssueInvoicePg.Subject().GetAttribute("value");
                string TotalGSTMsg = IssueInvoicePg.TotalGSTMsg().Text;
                string TotalValue = IssueInvoicePg.TotalValue().Text;
                

                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(subject.Contains("madcowtesting10+anogstbiller has sent you an invoice") && TotalGSTMsg.Contains("(excl. GST)") && TotalValue.Contains("$1,000.00"));
                
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("Ext-Inv@" + randnumber1);
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
        public void IssueInvoice04_ExternalPayer_CreateInvoice_NoGST_Surcharge()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+anogstbiller@gmail.com");
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

                DateTime duedate1 = DateTime.Today.AddDays(30);
                string SentPgDueDate = duedate1.ToString("dd MMM yy");
                string SentPgDueDate1 = duedate1.ToString("dd/MM/yyyy");
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BusinessName().SendKeys("External1");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "30 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                bool due = bodyTag.Text.Contains(SentPgDueDate1);

                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("Ext-Inv@" + randnumber1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to External Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("1000");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");

                SeleniumSetMethods.WaitOnPage(secdelay2);
                string subject = IssueInvoicePg.Subject().GetAttribute("value");
                string TotalGSTMsg = IssueInvoicePg.TotalGSTMsg().Text;
                string TotalValue = IssueInvoicePg.TotalValue().Text;


                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(subject.Contains("madcowtesting10+anogstbiller has sent you an invoice") && TotalGSTMsg.Contains("(excl. GST)") && TotalValue.Contains("$1,000.00"));
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("Ext-Inv@" + randnumber1);
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
        public void IssueInvoice05_ExternalPayer_CreateInvoice_NoGST_Surcharge_EndOfNextMonth()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+anogstbiller@gmail.com");
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

                DateTime duedate1 = DateTime.Today.AddDays(30);
                string SentPgDueDate = duedate1.ToString("dd MMM yy");
                string SentPgDueDate1 = duedate1.ToString("dd/MM/yyyy");
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BusinessName().SendKeys("External1");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "End of next month";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                bool due = bodyTag.Text.Contains(SentPgDueDate1);

                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("Ext-Inv@" + randnumber1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to External Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("1000");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");

                SeleniumSetMethods.WaitOnPage(secdelay2);
                string subject = IssueInvoicePg.Subject().GetAttribute("value");
                string TotalGSTMsg = IssueInvoicePg.TotalGSTMsg().Text;
                string TotalValue = IssueInvoicePg.TotalValue().Text;


                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(subject.Contains("madcowtesting10+anogstbiller has sent you an invoice") && TotalGSTMsg.Contains("(excl. GST)") && TotalValue.Contains("$1,000.00"));
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
        public void IssueInvoice06_ExternalPayer_CreateInvoice_NoGST_NoSurcharge_NoABN()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+anogstbiller@gmail.com");
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
                DateTime duedate1 = DateTime.Today.AddDays(30);
                string SentPgDueDate = duedate1.ToString("dd MMM yy");
                string SentPgDueDate1 = duedate1.ToString("dd/MM/yyyy");
                IssueInvoicePg.AddCustomerButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.BusinessName().Click();
                AddCustomerPg.BusinessName().SendKeys("ExternalNoABN@" + randnumber1);
                AddCustomerPg.ContactName().SendKeys("Test@" + randnumber1);
                AddCustomerPg.ContactEmail().SendKeys("madcowtesting10+" + randnumber1 + "@gmail.com");
                AddCustomerPg.ContactPhoneNumber().SendKeys("12345671447");
                AddCustomerPg.Street().SendKeys("10 Miller Street");
                AddCustomerPg.Suburb().SendKeys("Murarrie");
                AddCustomerPg.Postcode().SendKeys("4172");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.AddBTN().Click();
                SeleniumSetMethods.WaitOnPage(5 );
               
                String PaymentTerms = "30 days";
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                bool due = bodyTag.Text.Contains(SentPgDueDate1);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("Ext-Inv@" + randnumber1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to External Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("185.25");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string subject = IssueInvoicePg.Subject().GetAttribute("value");
                string TotalGSTMsg = IssueInvoicePg.TotalGSTMsg().Text;
                string TotalValue = IssueInvoicePg.TotalValue().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(subject.Contains("madcowtesting10+anogstbiller has sent you an invoice") && TotalGSTMsg.Contains("(excl. GST)") && TotalValue.Contains("$185.25"));
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
        public void IssueInvoice07_ExternalPayer_CreateInvoice_NoGST_NoSurcharge_NoAddress()
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
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+anogstbiller@gmail.com");
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

                DateTime duedate1 = DateTime.Today.AddDays(30);
                string SentPgDueDate = duedate1.ToString("dd MMM yy");
                string SentPgDueDate1 = duedate1.ToString("dd/MM/yyyy");


                IssueInvoicePg.AddCustomerButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                AddCustomerPg.BusinessName().Click();
                AddCustomerPg.BusinessName().SendKeys("ExternalNoAddress@" + randnumber1);
                AddCustomerPg.Abn().SendKeys("12345678910");
                AddCustomerPg.ContactName().SendKeys("Test@" + randnumber1);
                AddCustomerPg.ContactEmail().SendKeys("madcowtesting10+" + randnumber1 + "@gmail.com");
                AddCustomerPg.ContactPhoneNumber().SendKeys("12345671447");

                AddCustomerPg.AddBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "30 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                bool due = bodyTag.Text.Contains(SentPgDueDate1);

                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("Ext-Inv@" + randnumber1);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to External Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("185.25");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");

                SeleniumSetMethods.WaitOnPage(secdelay2);
                string subject = IssueInvoicePg.Subject().GetAttribute("value");
                string TotalGSTMsg = IssueInvoicePg.TotalGSTMsg().Text;
                string TotalValue = IssueInvoicePg.TotalValue().Text;


                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(subject.Contains("madcowtesting10+anogstbiller has sent you an invoice") && TotalGSTMsg.Contains("(excl. GST)") && TotalValue.Contains("$185.25"));
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

        
    }
}
