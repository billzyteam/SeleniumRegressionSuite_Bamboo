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
    class RegSuite_SIV_WithoutDeal_UNPAID : Tests
    {
        [Test]
        public void Invoice01_InvoiceDetails_ExcludigGST_NoSurcharge_Unpaid_Biller_Payer()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));

                loginPage.UserNameTextBox().Click();
                //loginPage.UserNameTextBox().SendKeys("madcowtesting10+asivnodealunpaidb@gmail.com");
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+asivnodealunpaidb01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay8);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);

                SendPage SendPg = new SendPage(WebDriver);
                HomePg.Profile().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.Settings().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SettingsPage settpg = new SettingsPage(WebDriver);
                settpg.GSTRegisteredNo().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                settpg.UpdateBTN().Click();

                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                //IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+asivnodealunpaidp");
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+asivnodealunpaidp01");
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
                DateTime newDate = DateTime.Now.AddDays(60);
                string dtString3 = newDate.ToString("dd/MM/yyyy");
                String PaymentTerms = "60 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.DueDate().Click();

                SeleniumSetMethods.WaitOnPage(secdelay3);
                //IssueInvoicePg.DueDate().Clear();
                //IssueInvoicePg.DueDate().SendKeys(dtString3);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV-03@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");

                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");

                SeleniumSetMethods.WaitOnPage(secdelay2);


                //issueInvoice_issueInvoicePage_totalValue.checkValueContains = @amountGst
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INV-03@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay6);
                SendPg.StatusNotViewedRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string notviewed = SendPg.StatusNotViewedRow01().GetAttribute("data-title");
                bool data1 = SendPg.ToColumn().Displayed;
                bool data2 = SendPg.InvoiceNumColumn().Displayed;
                bool data3 = SendPg.DueColumn().Displayed;
                bool data4 = SendPg.AmountColumn().Displayed;
                bool data5 = SendPg.BillzyColumn().Displayed;
                bool data6 = SendPg.ActionsColumn().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(notviewed.Contains("not viewed") && data1 == true && data2 == true && data3 == true && data4 == true && data5 == true && data6 == true);
                SendPg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool data11 = SendPg.BillzyCashOption().Displayed;
                bool data22 = SendPg.BillzyDealOption().Displayed;
                bool data33 = SendPg.PDFInvoice().Displayed;
                bool data44 = SendPg.MarkAsPaidOption().Displayed;
                bool data55 = SendPg.DeleteOption().Displayed;
                
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(data11 == true && data22 == true && data33 == true && data44 == true && data55 == true);

                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SIVPage SIVPG1 = new SIVPage(WebDriver);
                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool data111 = SIVPG1.ActionDropdownMarkAsPaid().Displayed;
                bool data222 = SIVPG1.ActionDropdownDelete().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(data111 == true && data222 == true);
                SIVPG1.ActionDropdown().Click();
                DateTime duedate1 = DateTime.Today;
                string SentPgDueDate = duedate1.ToString("dd/MM/yy");

                bool data1111 = bodyTag.Text.Contains("By selecting Verify you confirm that the supply of goods or services relevant to this invoice has been completed to your satisfaction and that you intend to pay the invoice amount");
                bool data2222 = bodyTag.Text.Contains("verified this invoice on");
                bool data3333 = bodyTag.Text.Contains(" posted this invoice on");
                bool siv1 = bodyTag.Text.Contains("madcowtesting10+asivnodealunpaidp");
                bool siv2 = bodyTag.Text.Contains("INV-03@" + randnumber2);
                bool siv3 = bodyTag.Text.Contains("UNPAID");
                bool siv4 = bodyTag.Text.Contains("Invoice Ref");
                bool siv5 = bodyTag.Text.Contains("Issue Date");
                bool siv6 = bodyTag.Text.Contains("Payment terms");
                bool siv7 = bodyTag.Text.Contains("Attachments");
                bool siv8 = bodyTag.Text.Contains(dtString3);
                bool siv9 = bodyTag.Text.Contains("INV-03@" + randnumber2 + ".pdf");
                bool siv10 = bodyTag.Text.Contains("319.82");
                bool siv11 = bodyTag.Text.Contains("A 1.67% surcharge (incl. GST) will apply to credit & debit cards");
                bool siv12 = bodyTag.Text.Contains("Due ");
                bool siv13 = bodyTag.Text.Contains("Total (excl. GST)");
                bool siv14 = bodyTag.Text.Contains("$319.82");
                bool siv15 = bodyTag.Text.Contains(SentPgDueDate);
                bool siv16 = bodyTag.Text.Contains("REQUEST CASH");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(data1111 == false && data2222 == false && data3333 == false && siv1 == true && siv2 == true && siv3 == true && siv4 == true && siv5 == true && siv6 == true && siv7 == true && siv8 == true && siv9 == true && siv10 == true && siv11 == false && siv12 == true && siv13 == true && siv14 == true && siv15 == true && siv16 == true);
                bool deal1 = SIVPG1.BillerOfferADiscountBTN().Displayed;
                bool deal2 = bodyTag.Text.Contains("MAKE A COUNTER-OFFER");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(deal1 == true && deal2 == false);
                SIVPG1.BillerOfferADiscountBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                bool deal3 = SIVPG1.NewTotal().Displayed;
                bool deal4 = SIVPG1.OfferExpiry().Displayed;
                bool deal5 = SIVPG1.Comments().Displayed;
                bool deal6 = SIVPG1.OfferDiscountModalBTN().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(deal3 == true && deal4 == true && deal5 == true && deal6 == true);

                SIVPG1.CancelButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                bool deal7 = bodyTag.Text.Contains("WITHDRAW OFFER");
                bool deal8 = bodyTag.Text.Contains("PAY");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(deal7 == false && deal8 == false);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //loginPage.UserNameTextBox().SendKeys("madcowtesting10+asivnodealunpaidp@gmail.com");
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+asivnodealunpaidp01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();

                SeleniumSetMethods.WaitOnPage(secdelay7);

                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                BillzyCashModal BillzyCashMlPg = new BillzyCashModal(WebDriver);
                PayNowPage PayNwPg = new PayNowPage(WebDriver);
                
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().SendKeys("INV-03@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string notviewedrec = Recpg.StatusNotViewedRow01().GetAttribute("data-title");
                bool rec1 = Recpg.ToColumn().Displayed;
                bool rec2 = Recpg.InvoiceNumColumn().Displayed;
                bool rec3 = Recpg.DueColumn().Displayed;
                bool rec4 = Recpg.AmountColumn().Displayed;
                bool rec5 = Recpg.BillzyColumn().Displayed;
                bool rec6 = Recpg.ActionsColumn().Displayed;
                bool rec7 = Recpg.VerifiedColumn().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(notviewedrec.Contains("not viewed") && rec1 == true && rec2 == true && rec3 == true && rec4 == true && rec5 == true && rec6 == true && rec7 == true);
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool rec11 = Recpg.PostInvoice().Displayed;
                bool rec22 = Recpg.BillzyDealOption().Displayed;
                bool rec33 = Recpg.PDFInvoice().Displayed;
                bool rec44 = Recpg.VerifyInvoice().Displayed;
                bool rec55 = Recpg.DeleteOption().Displayed;
                bool rec66 = Recpg.PAY().Displayed;

                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(rec11 == true && rec22 == true && rec33 == true && rec44 == true && rec55 == true && rec66 == true);
                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool siv1111 = SIVPG1.ActionDropdownMarkAsPaid().Displayed;
                bool siv2222 = SIVPG1.ActionDropdownDelete().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(siv1111 == false && siv2222 == true);
                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag1 = WebDriver.FindElement(By.TagName("body"));
                bool recsiv1111 = bodyTag1.Text.Contains("By selecting Verify you confirm that the supply of goods or services relevant to this invoice has been completed to your satisfaction and that you intend to pay the invoice amount");
                bool recsiv2222 = bodyTag1.Text.Contains("verified this invoice on");
                bool recsiv3333 = bodyTag1.Text.Contains(" posted this invoice on");
                bool recsiv1 = bodyTag1.Text.Contains("madcowtesting10+asivnodealunpaidb");
                bool recsiv2 = bodyTag1.Text.Contains("INV-03@" + randnumber2);
                bool recsiv3 = bodyTag1.Text.Contains("UNPAID");
                bool recsiv4 = bodyTag1.Text.Contains("Invoice Ref");
                bool recsiv5 = bodyTag1.Text.Contains("Issue Date");
                bool recsiv6 = bodyTag1.Text.Contains("Payment terms");
                bool recsiv7 = bodyTag1.Text.Contains("Attachments");
                bool recsiv8 = bodyTag1.Text.Contains(dtString3);
                bool recsiv9 = bodyTag1.Text.Contains("INV-03@" + randnumber2 + ".pdf");
                bool recsiv10 = bodyTag1.Text.Contains("319.82");
                bool recsiv11 = bodyTag1.Text.Contains("A 1.67% surcharge (incl. GST) will apply to credit & debit cards");
                bool recsiv12 = bodyTag1.Text.Contains("Due ");
                bool recsiv13 = bodyTag1.Text.Contains("(excl. GST)");
                bool recsiv14 = bodyTag1.Text.Contains("$319.82");
                bool recsiv15 = bodyTag1.Text.Contains(SentPgDueDate);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(recsiv1111 == true && recsiv2222 == false && recsiv3333 == false && recsiv1 == true && recsiv2 == true && recsiv3 == true && recsiv4 == true && recsiv5 == true && recsiv6 == true && recsiv7 == true && recsiv8 == true && recsiv9 == true && recsiv10 == true && recsiv11 == false && recsiv12 == true && recsiv13 == true && recsiv14 == true && recsiv15 == true);
                bool recsivdeal1 = bodyTag1.Text.Contains("OFFER A DISCOUNT");
                bool recsivdeal2 = bodyTag1.Text.Contains("OFFER EARLY PAYMENT");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(recsivdeal1 == false );
                SIVPG1.PayerOfferEarlyPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                bool recsivdeal3 = SIVPG1.NewTotal().Displayed;
                bool recsivdeal4 = SIVPG1.OfferExpiry().Displayed;
                bool recsivdeal5 = SIVPG1.Comments().Displayed;
                bool recsivdeal6 = SIVPG1.PayerOfferEarlyPaymentBTN().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(recsivdeal3 == true && recsivdeal4 == true && recsivdeal5 == true && recsivdeal6 == true);

                SIVPG1.CancelButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool recsivdeal7 = bodyTag1.Text.Contains("WITHDRAW OFFER");
                bool recsivdeal8 = SIVPG1.PayBTNNoDeal().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(recsivdeal7 == false && recsivdeal8 == true);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string post4 = Recpg.StatusViewedRow01().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(post4.Contains("viewed"));
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.PostInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string post1 = Recpg.PostInvoiceTitleModal().Text;
                
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(post1.Contains("Post Invoice"));
                Recpg.PostInvoiceCancelBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.PostInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                Recpg.PostInvoicePostBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                //Recpg.StatuspostedRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string post2 = Recpg.StatuspostedRow01().GetAttribute("data-title");
                string post3 = Recpg.UnverifiedInvoice1().GetAttribute("data-title");
                
                Assert.IsTrue(post2.Contains("posted") && post3.Contains("unverified"));
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool post5 = Recpg.PostInvoice().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(post5 == false);
                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SIVPG1.PayerVerifyBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool sivver11 = bodyTag1.Text.Contains("By selecting Verify you confirm that the supply of goods or services relevant to this invoice has been completed to your satisfaction and that you intend to pay the invoice amount");
                bool recsiv22 = bodyTag1.Text.Contains("verified this invoice on");
                bool recsiv33 = bodyTag1.Text.Contains(" posted this invoice on");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(sivver11 == false && recsiv22 == true && recsiv33 == true);
            }
            finally
            {
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
            }
        }

        [Test]
        public void Invoice02_InvoiceDetails_IncludigGST_Surcharge_Unpaid_Biller_Payer()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));

                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+asivnodealunpaidb01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay8);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);

                SendPage SendPg = new SendPage(WebDriver);

                HomePg.Profile().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.Settings().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SettingsPage settpg = new SettingsPage(WebDriver);
                settpg.GSTRegisteredYes().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                settpg.UpdateBTN().Click();

                SeleniumSetMethods.WaitOnPage(secdelay2);


                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+asivnodealunpaidp01");
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
                DateTime newDate = DateTime.Now.AddDays(60);
                string dtString3 = newDate.ToString("dd/MM/yyyy");
                String PaymentTerms = "60 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.DueDate().Click();

                SeleniumSetMethods.WaitOnPage(secdelay3);
                //IssueInvoicePg.DueDate().Clear();
                //IssueInvoicePg.DueDate().SendKeys(dtString3);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV-02@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");

                IssueInvoicePg.LineItemAmount().SendKeys("1204.09");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                IssueInvoicePg.SurchargeCheckbox().Click();

                SeleniumSetMethods.WaitOnPage(secdelay2);


                //issueInvoice_issueInvoicePage_totalValue.checkValueContains = @amountGst
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INV-02@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay6);
                SendPg.StatusNotViewedRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string notviewed = SendPg.StatusNotViewedRow01().GetAttribute("data-title");
                bool data1 = SendPg.ToColumn().Displayed;
                bool data2 = SendPg.InvoiceNumColumn().Displayed;
                bool data3 = SendPg.DueColumn().Displayed;
                bool data4 = SendPg.AmountColumn().Displayed;
                bool data5 = SendPg.BillzyColumn().Displayed;
                bool data6 = SendPg.ActionsColumn().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(notviewed.Contains("not viewed") && data1 == true && data2 == true && data3 == true && data4 == true && data5 == true && data6 == true);
                SendPg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool data11 = SendPg.BillzyCashOption().Displayed;
                bool data22 = SendPg.BillzyDealOption().Displayed;
                bool data33 = SendPg.PDFInvoice().Displayed;
                bool data44 = SendPg.MarkAsPaidOption().Displayed;
                bool data55 = SendPg.DeleteOption().Displayed;

                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(data11 == true && data22 == true && data33 == true && data44 == true && data55 == true);

                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SIVPage SIVPG1 = new SIVPage(WebDriver);
                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool data111 = SIVPG1.ActionDropdownMarkAsPaid().Displayed;
                bool data222 = SIVPG1.ActionDropdownDelete().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(data111 == true && data222 == true);
                SIVPG1.ActionDropdown().Click();
                DateTime duedate1 = DateTime.Today;
                string SentPgDueDate = duedate1.ToString("dd/MM/yy");

                bool data1111 = bodyTag.Text.Contains("By selecting Verify you confirm that the supply of goods or services relevant to this invoice has been completed to your satisfaction and that you intend to pay the invoice amount");
                bool data2222 = bodyTag.Text.Contains("verified this invoice on");
                bool data3333 = bodyTag.Text.Contains(" posted this invoice on");
                bool siv1 = bodyTag.Text.Contains("madcowtesting10+asivnodealunpaidp01");
                bool siv2 = bodyTag.Text.Contains("INV-02@" + randnumber2);
                bool siv3 = bodyTag.Text.Contains("UNPAID");
                bool siv4 = bodyTag.Text.Contains("Invoice Ref");
                bool siv5 = bodyTag.Text.Contains("Issue Date");
                bool siv6 = bodyTag.Text.Contains("Payment terms");
                bool siv7 = bodyTag.Text.Contains("Attachments");
                bool siv8 = bodyTag.Text.Contains(dtString3);
                bool siv9 = bodyTag.Text.Contains("INV-02@" + randnumber2 + ".pdf");
                bool siv10 = bodyTag.Text.Contains("$1,324.50");
                bool siv11 = bodyTag.Text.Contains("A 1.67% surcharge (incl. GST) will apply to credit & debit cards");
                bool siv12 = bodyTag.Text.Contains("Due ");
                bool siv13 = bodyTag.Text.Contains("Total (incl. GST)");
                bool siv14 = bodyTag.Text.Contains("$1,324.50");
                bool siv15 = bodyTag.Text.Contains(SentPgDueDate);
                bool siv16 = bodyTag.Text.Contains("REQUEST CASH");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(data1111 == false && data2222 == false && data3333 == false && siv1 == true && siv2 == true && siv3 == true && siv4 == true && siv5 == true && siv6 == true && siv7 == true && siv8 == true && siv9 == true && siv10 == true && siv11 == true && siv12 == true && siv13 == true && siv14 == true && siv15 == true && siv16 == true);
                bool deal1 = SIVPG1.BillerOfferADiscountBTN().Displayed;
                bool deal2 = bodyTag.Text.Contains("MAKE A COUNTER-OFFER");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(deal1 == true && deal2 == false);
                SIVPG1.BillerOfferADiscountBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                bool deal3 = SIVPG1.NewTotal().Displayed;
                bool deal4 = SIVPG1.OfferExpiry().Displayed;
                bool deal5 = SIVPG1.Comments().Displayed;
                bool deal6 = SIVPG1.OfferDiscountModalBTN().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(deal3 == true && deal4 == true && deal5 == true && deal6 == true);

                SIVPG1.CancelButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                bool deal7 = bodyTag.Text.Contains("WITHDRAW OFFER");
                bool deal8 = bodyTag.Text.Contains("PAY");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(deal7 == false && deal8 == false);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+asivnodealunpaidp01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();

                SeleniumSetMethods.WaitOnPage(secdelay7);

                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                BillzyCashModal BillzyCashMlPg = new BillzyCashModal(WebDriver);
                PayNowPage PayNwPg = new PayNowPage(WebDriver);

                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().SendKeys("INV-02@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string notviewedrec = Recpg.StatusNotViewedRow01().GetAttribute("data-title");
                bool rec1 = Recpg.ToColumn().Displayed;
                bool rec2 = Recpg.InvoiceNumColumn().Displayed;
                bool rec3 = Recpg.DueColumn().Displayed;
                bool rec4 = Recpg.AmountColumn().Displayed;
                bool rec5 = Recpg.BillzyColumn().Displayed;
                bool rec6 = Recpg.ActionsColumn().Displayed;
                bool rec7 = Recpg.VerifiedColumn().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(notviewedrec.Contains("not viewed") && rec1 == true && rec2 == true && rec3 == true && rec4 == true && rec5 == true && rec6 == true && rec7 == true);
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool rec11 = Recpg.PostInvoice().Displayed;
                bool rec22 = Recpg.BillzyDealOption().Displayed;
                bool rec33 = Recpg.PDFInvoice().Displayed;
                bool rec44 = Recpg.VerifyInvoice().Displayed;
                bool rec55 = Recpg.DeleteOption().Displayed;
                bool rec66 = Recpg.PAY().Displayed;

                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(rec11 == true && rec22 == true && rec33 == true && rec44 == true && rec55 == true && rec66 == true);
                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool siv1111 = SIVPG1.ActionDropdownMarkAsPaid().Displayed;
                bool siv2222 = SIVPG1.ActionDropdownDelete().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(siv1111 == false && siv2222 == true);
                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag1 = WebDriver.FindElement(By.TagName("body"));
                bool recsiv1111 = bodyTag1.Text.Contains("By selecting Verify you confirm that the supply of goods or services relevant to this invoice has been completed to your satisfaction and that you intend to pay the invoice amount");
                bool recsiv2222 = bodyTag1.Text.Contains("verified this invoice on");
                bool recsiv3333 = bodyTag1.Text.Contains(" posted this invoice on");
                bool recsiv1 = bodyTag1.Text.Contains("madcowtesting10+asivnodealunpaidb01");
                bool recsiv2 = bodyTag1.Text.Contains("INV-02@" + randnumber2);
                bool recsiv3 = bodyTag1.Text.Contains("UNPAID");
                bool recsiv4 = bodyTag1.Text.Contains("Invoice Ref");
                bool recsiv5 = bodyTag1.Text.Contains("Issue Date");
                bool recsiv6 = bodyTag1.Text.Contains("Payment terms");
                bool recsiv7 = bodyTag1.Text.Contains("Attachments");
                bool recsiv8 = bodyTag1.Text.Contains(dtString3);
                bool recsiv9 = bodyTag1.Text.Contains("INV-02@" + randnumber2 + ".pdf");
                bool recsiv10 = bodyTag1.Text.Contains("$1,324.50");
                bool recsiv11 = bodyTag1.Text.Contains("A 1.67% surcharge (incl. GST) will apply to credit & debit cards");
                bool recsiv12 = bodyTag1.Text.Contains("Due ");
                bool recsiv13 = bodyTag1.Text.Contains("(incl. GST)");
                bool recsiv14 = bodyTag1.Text.Contains("$1,324.50");
                bool recsiv15 = bodyTag1.Text.Contains(SentPgDueDate);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(recsiv1111 == true && recsiv2222 == false && recsiv3333 == false && recsiv1 == true && recsiv2 == true && recsiv3 == true && recsiv4 == true && recsiv5 == true && recsiv6 == true && recsiv7 == true && recsiv8 == true && recsiv9 == true && recsiv10 == true && recsiv11 == true && recsiv12 == true && recsiv13 == true && recsiv14 == true && recsiv15 == true);
                bool recsivdeal1 = bodyTag1.Text.Contains("OFFER A DISCOUNT");
                bool recsivdeal2 = bodyTag1.Text.Contains("OFFER EARLY PAYMENT");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(recsivdeal1 == false);
                SIVPG1.PayerOfferEarlyPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                bool recsivdeal3 = SIVPG1.NewTotal().Displayed;
                bool recsivdeal4 = SIVPG1.OfferExpiry().Displayed;
                bool recsivdeal5 = SIVPG1.Comments().Displayed;
                bool recsivdeal6 = SIVPG1.PayerOfferEarlyPaymentBTN().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(recsivdeal3 == true && recsivdeal4 == true && recsivdeal5 == true && recsivdeal6 == true);

                SIVPG1.CancelButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool recsivdeal7 = bodyTag1.Text.Contains("WITHDRAW OFFER");
                bool recsivdeal8 = SIVPG1.PayBTNNoDeal().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(recsivdeal7 == false && recsivdeal8 == true);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string post4 = Recpg.StatusViewedRow01().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(post4.Contains("viewed"));
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.PostInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string post1 = Recpg.PostInvoiceTitleModal().Text;

                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(post1.Contains("Post Invoice"));
                Recpg.PostInvoiceCancelBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.PostInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                Recpg.PostInvoicePostBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                //Recpg.StatuspostedRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string post2 = Recpg.StatuspostedRow01().GetAttribute("data-title");
                string post3 = Recpg.UnverifiedInvoice1().GetAttribute("data-title");

                Assert.IsTrue(post2.Contains("posted") && post3.Contains("unverified"));
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool post5 = Recpg.PostInvoice().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(post5 == false);
                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SIVPG1.PayerVerifyBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool sivver11 = bodyTag1.Text.Contains("By selecting Verify you confirm that the supply of goods or services relevant to this invoice has been completed to your satisfaction and that you intend to pay the invoice amount");
                bool recsiv22 = bodyTag1.Text.Contains("verified this invoice on");
                bool recsiv33 = bodyTag1.Text.Contains(" posted this invoice on");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(sivver11 == false && recsiv22 == true && recsiv33 == true);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+asivnodealunpaidb01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();

                SeleniumSetMethods.WaitOnPage(secdelay7);
              
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                IWebElement bodyTag2 = WebDriver.FindElement(By.TagName("body"));
                bool sent1 = bodyTag2.Text.Contains("invoices");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(sent1 == true);
                //# Verify Unchecked Exists
                bool check1 = SendPg.SelectAllUnchecked().Displayed;
                bool check2 = SendPg.FirstRowUnchecked().Displayed;
                bool check3 = SendPg.SecondRowUnchecked().Displayed;
                bool check4 = SendPg.ThirdRowUnchecked().Displayed;
                bool check5 = SendPg.FourthRowUnchecked().Displayed;

                bool check11 = SendPg.PdfButtonTop().Displayed;
                bool check12 = SendPg.PdfButtonButton().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(check1 == true && check2 == true && check3 == true && check4 == true && check5 == true && check11 == false && check12 == false);
                SendPg.FirstRowUnchecked().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool check13 = bodyTag2.Text.Contains("1 of ");
                bool check14 = bodyTag2.Text.Contains(" loaded invoices selected");
                bool check15 = bodyTag2.Text.Contains("1 PDF");
                SendPg.SecondRowUnchecked().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool check16 = bodyTag2.Text.Contains("2 of ");
                bool check17 = bodyTag2.Text.Contains("2 PDF's");
                SendPg.ThirdRowUnchecked().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool check18 = bodyTag2.Text.Contains("3 of ");
                bool check19 = bodyTag2.Text.Contains("3 PDF's");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(check13 == true && check14 == true && check15 == true && check16 == true && check17 == true && check18 == true && check19 == true);
                bool uncheck1 = SendPg.SelectAllUnchecked().Displayed;
                bool uncheck2 = SendPg.FirstRowUnchecked().Displayed;
                bool uncheck3 = SendPg.SecondRowUnchecked().Displayed;

                bool uncheck7 = SendPg.FirstRowChecked().Displayed;
                bool uncheck8 = SendPg.SecondRowChecked().Displayed;
                bool uncheck9 = SendPg.ThirdRowChecked().Displayed;
               
                bool uncheck11 = SendPg.PdfButtonTop().Displayed;
                bool uncheck12 = SendPg.PdfButtonButton().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(uncheck1 == true && uncheck2 == true && uncheck3 == true && uncheck7 == true && uncheck8 == true && uncheck9 == true && uncheck11 == true && uncheck12 == true);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+asivnodealunpaidp01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();

                SeleniumSetMethods.WaitOnPage(secdelay7);
                
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                IWebElement bodyTag3 = WebDriver.FindElement(By.TagName("body"));
                bool recpg11 = bodyTag3.Text.Contains("invoices");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(recpg11 == true);
                //# Verify Unchecked Exists
                bool reccheck1 = Recpg.SelectAllUnchecked().Displayed;
                bool reccheck2 = Recpg.FirstRowUnchecked().Displayed;
                bool reccheck3 = Recpg.SecondRowUnchecked().Displayed;
                bool reccheck4 = Recpg.ThirdRowUnchecked().Displayed;
                bool reccheck5 = Recpg.FourthRowUnchecked().Displayed;

                bool reccheck11 = Recpg.PdfButtonTop().Displayed;
                bool reccheck12 = Recpg.PdfButtonButton().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(reccheck1 == true && reccheck2 == true && reccheck3 == true && reccheck4 == true && reccheck5 == true  && reccheck11 == false && reccheck12 == false);
                Recpg.FirstRowUnchecked().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool reccheck13 = bodyTag3.Text.Contains("1 of ");
                bool reccheck14 = bodyTag3.Text.Contains(" loaded invoices selected");
                bool reccheck15 = bodyTag3.Text.Contains("1 PDF");
                Recpg.SecondRowUnchecked().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool reccheck16 = bodyTag3.Text.Contains("2 of ");
                bool reccheck17 = bodyTag3.Text.Contains("2 PDF's");
                Recpg.ThirdRowUnchecked().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool reccheck18 = bodyTag3.Text.Contains("3 of ");
                bool reccheck19 = bodyTag3.Text.Contains("3 PDF's");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(reccheck13 == true && reccheck14 == true && reccheck15 == true && reccheck16 == true && reccheck17 == true && reccheck18 == true && reccheck19 == true);
                bool recuncheck1 = Recpg.SelectAllUnchecked().Displayed;
                bool recuncheck2 = Recpg.FirstRowUnchecked().Displayed;
                bool recuncheck3 = Recpg.SecondRowUnchecked().Displayed;
                
                bool recuncheck7 = Recpg.FirstRowChecked().Displayed;
                bool recuncheck8 = Recpg.SecondRowChecked().Displayed;
                bool recuncheck9 = Recpg.ThirdRowChecked().Displayed;
                
                bool recuncheck11 = Recpg.PdfButtonTop().Displayed;
                bool recuncheck12 = Recpg.PdfButtonButton().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(recuncheck1 == true && recuncheck2 == true && recuncheck3 == true && recuncheck7 == true && recuncheck8 == true && recuncheck9 == true && recuncheck11 == true && recuncheck12 == true);

            }
            finally
            {
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
            }
        }

        [Test]
        public void Invoice03_NoDeal_NoGST_Surcharge()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));

                loginPage.UserNameTextBox().Click();
                //loginPage.UserNameTextBox().SendKeys("madcowtesting10+asivnodealunpaidb@gmail.com");
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+asivnodealunpaidb01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay8);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);

                SendPage SendPg = new SendPage(WebDriver);

                HomePg.Profile().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.Settings().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SettingsPage settpg = new SettingsPage(WebDriver);
                settpg.GSTRegisteredNo().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                settpg.UpdateBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                //IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+asivnodealunpaidp");
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+asivnodealunpaidp01");
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
                DateTime newDate = DateTime.Now.AddDays(60);
                string dtString3 = newDate.ToString("dd MMM yy");
                String PaymentTerms = "60 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.DueDate().Click();

                SeleniumSetMethods.WaitOnPage(secdelay3);
                //IssueInvoicePg.DueDate().Clear();
                //IssueInvoicePg.DueDate().SendKeys(dtString3);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV-03@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");

                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);


                //issueInvoice_issueInvoicePage_totalValue.checkValueContains = @amountGst
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INV-03@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay6);
                bool sum = SendPg.SentOnloadInvoiceCount_Sum().Displayed;
                bool filter1 = SendPg.Filter().Displayed;
                bool from1 = SendPg.FromDate().Displayed;
                bool to1 = SendPg.ToDate().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(sum == true &&  filter1 == true && from1 == true && to1 == true);
                string title1 = SendPg.TitlePage().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(title1.Contains("Sent Invoices"));
                string sdata1 = SendPg.ToRow01().Text;
                string sdata2 = SendPg.BillzyInvoiceNumRow01().Text;
                string sdata3 = SendPg.DueRow01().Text;
                string sdata4 = SendPg.AmountRow1().Text;

                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(sdata1.Contains("madcowtesting10+asi") && sdata2.Contains("INV-03@" + randnumber2) && sdata3.Contains(dtString3) && sdata4.Contains("319.82"));

                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //loginPage.UserNameTextBox().SendKeys("madcowtesting10+asivnodealunpaidp@gmail.com");
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+asivnodealunpaidp01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();

                SeleniumSetMethods.WaitOnPage(secdelay7);

                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                BillzyCashModal BillzyCashMlPg = new BillzyCashModal(WebDriver);
                PayNowPage PayNwPg = new PayNowPage(WebDriver);

                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().SendKeys("INV-03@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool sum1 = Recpg.ReceivedOnloadInvoiceCount_Sum().Displayed;
                string title = Recpg.TitlePage().Text;
                bool filter = Recpg.Filter().Displayed;
                bool from = Recpg.FromDate().Displayed;
                bool to = Recpg.ToDate().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(sum1 == true && title.Contains("Received Invoices") && filter == true && from == true && to == true);

                string data1 = Recpg.FromRow01().Text;
                string data2 = Recpg.BillzyInvoiceNumRow01().Text;
                string data3 = Recpg.DueRow01().Text;
                string data4 = Recpg.AmountViewedRow1().Text;
                IWebElement bodyTag2 = WebDriver.FindElement(By.TagName("body"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(data1.Contains("madcowtesting10+as") && data2.Contains("INV-03@" + randnumber2) && data3.Contains(dtString3) && data4.Contains("319.82"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool paytop = bodyTag2.Text.Contains("PAY $319.82"); 
                
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(paytop == false);

                Recpg.SelectInvoiceRow01().Click();
                

                SeleniumSetMethods.WaitOnPage(secdelay2);
                string paytop1 = Recpg.PayBTNTop().Text;
                string paybottom1 = Recpg.PayBTNBottom().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(paytop1.Contains("PAY $319.82") && paybottom1.Contains("PAY $319.82"));

            }
            finally
            {
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
            }
        }
    }
}
