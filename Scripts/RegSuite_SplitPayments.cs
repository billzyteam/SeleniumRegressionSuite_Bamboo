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
    class RegSuite_SplitPayments : Tests
    {
        /*******************************************************************************************
           Scenario 1 : Split payment verfication by both valid Credit Cards
           Scenario 2 : Split payment verfication by both invalid Credit Cards
           Scenario 3 : Split payment verfication by one valid and one invalid Credit Card
           Scenario 4 : Split payment verfication by both valid Credit Card
           Scenario 5 : Split payment verfication by both valid Credit Card
       *******************************************************************************************/

        [Test]
        public void SplitPayment01__Deal_GST_Surcharge_Valid_CC()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);


                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+asplit01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay8);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);

                SendPage SendPg = new SendPage(WebDriver);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+asplit01payer");
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
                DateTime newDate = DateTime.Now.AddDays(900);
                string dtString3 = newDate.ToString("dd/MM/yyyy");
                String PaymentTerms = "30 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.DueDate().Click();

                SeleniumSetMethods.WaitOnPage(secdelay3);
                //IssueInvoicePg.DueDate().Clear();
                //IssueInvoicePg.DueDate().SendKeys(dtString3);
                IssueInvoicePg.CreateInvoice().Click();
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVSPLIT@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");

                IssueInvoicePg.LineItemAmount().SendKeys("8,816.19");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.NewTotal().SendKeys("8,816.11");

                DateTime newDate1 = DateTime.Now.AddDays(7);
                string dtString4 = newDate1.ToString("dd/MM/yyyy");

                IssueInvoicePg.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.OfferExpiry().SendKeys(dtString4);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");

                IssueInvoicePg.SurchargeCheckbox().Click();

                //issueInvoice_issueInvoicePage_totalValue.checkValueContains = @amountGst
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");

                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVSPLIT@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);


                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);



                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+asplit01payer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();

                SeleniumSetMethods.WaitOnPage(secdelay7);

                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                BillzyCashModal BillzyCashMlPg = new BillzyCashModal(WebDriver);
                PayNowPage PayNwPg = new PayNowPage(WebDriver);
                SIVPage SIVPG1 = new SIVPage(WebDriver);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVSPLIT@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay6);
                Recpg.SelectInvoiceRow01().Click();
                String paYBTNTopText = Recpg.PaYBTNTopText().Text;
                String paYBTNBottomText = Recpg.PaYBTNBottomText().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(paYBTNTopText.Contains("PAY $8,816.11") && paYBTNBottomText.Contains("PAY $8,816.11"));
                Recpg.PayBTNTop().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PayNowPage paypg = new PayNowPage(WebDriver);
                paypg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.CardRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.Row01AmountPayable().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.Row01AmountPayable().SendKeys("1204.09");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.Row01SplitBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                paypg.Row02SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.SelectCard2().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                paypg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                paypg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ReceivedHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.SearchInvoiceReceived().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().SendKeys("INVSPLIT@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                //string refnum = Recpg.BillzyInvoiceNumRow01().Text;
                string amountpaid = Recpg.AmountRow1().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(amountpaid.Contains("$8,963.34"));
                string paidstatushover = Recpg.HistoryPaidStatus().GetAttribute("data-title");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paidstatushover.Contains("paid"));

                
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+asplit01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SentHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("INVSPLIT@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                
                String Paidstatus = SIVPG1.PaidStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                
                Assert.IsTrue(Paidstatus.Contains("PAID"));
                
                SeleniumSetMethods.WaitOnPage(secdelay7);
            }
            finally
            {
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
            }
        }

        [Test]
        public void SplitPayment02_Deal_GST_Surcharge_SplitPayment_BothInvalid_CC()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);


                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+asplit01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay8);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);

                SendPage SendPg = new SendPage(WebDriver);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+asplit01payer");
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
                DateTime newDate = DateTime.Now.AddDays(900);
                string dtString3 = newDate.ToString("dd/MM/yyyy");
                String PaymentTerms = "30 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.DueDate().Click();

                SeleniumSetMethods.WaitOnPage(secdelay3);
                //IssueInvoicePg.DueDate().Clear();
                //IssueInvoicePg.DueDate().SendKeys(dtString3);
                IssueInvoicePg.CreateInvoice().Click();
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVSPLIT@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");

                IssueInvoicePg.LineItemAmount().SendKeys("8,816.19");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.NewTotal().SendKeys("8,816.11");

                DateTime newDate1 = DateTime.Now.AddDays(7);
                string dtString4 = newDate1.ToString("dd/MM/yyyy");

                IssueInvoicePg.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.OfferExpiry().SendKeys(dtString4);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");

                IssueInvoicePg.SurchargeCheckbox().Click();

                //issueInvoice_issueInvoicePage_totalValue.checkValueContains = @amountGst
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");

                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVSPLIT@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);


                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);



                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+asplit01payer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();

                SeleniumSetMethods.WaitOnPage(secdelay7);

                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                BillzyCashModal BillzyCashMlPg = new BillzyCashModal(WebDriver);
                PayNowPage PayNwPg = new PayNowPage(WebDriver);
                SIVPage SIVPG1 = new SIVPage(WebDriver);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVSPLIT@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay6);
                Recpg.SelectInvoiceRow01().Click();
                String paYBTNTopText = Recpg.PaYBTNTopText().Text;
                String paYBTNBottomText = Recpg.PaYBTNBottomText().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(paYBTNTopText.Contains("PAY $8,816.11") && paYBTNBottomText.Contains("PAY $8,816.11"));
                Recpg.PayBTNTop().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PayNowPage paypg = new PayNowPage(WebDriver);
                paypg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.CardRow05().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.Row01AmountPayable().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.Row01AmountPayable().SendKeys("1204.09");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.Row01SplitBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                paypg.Row02SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.SelectinvalidCard2().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                paypg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                paypg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().SendKeys("INVSPLIT@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //string refnum = Recpg.BillzyInvoiceNumRow01().Text;
                string invstatus = SIVPG1.InvoiceStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invstatus.Contains("UNPAID"));
                

                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+asplit01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                
                SendPg.SearchInvoiceSent().SendKeys("INVSPLIT@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                string invstatus1 = SIVPG1.InvoiceStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invstatus1.Contains("UNPAID"));

                SeleniumSetMethods.WaitOnPage(secdelay4);
            }
            finally
            {
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
            }
        }

        [Test]
        public void SplitPayment03_Deal_GST_Surcharge_ValidInvalid_CC()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay4);

                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+asplit01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay8);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);

                SendPage SendPg = new SendPage(WebDriver);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+asplit01payer");
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
                DateTime newDate = DateTime.Now.AddDays(900);
                string dtString3 = newDate.ToString("dd/MM/yyyy");
                String PaymentTerms = "30 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.DueDate().Click();

                SeleniumSetMethods.WaitOnPage(secdelay3);
                //IssueInvoicePg.DueDate().Clear();
                //IssueInvoicePg.DueDate().SendKeys(dtString3);
                IssueInvoicePg.CreateInvoice().Click();
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVSPLIT@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");

                IssueInvoicePg.LineItemAmount().SendKeys("8,816.19");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.NewTotal().SendKeys("8,816.11");

                DateTime newDate1 = DateTime.Now.AddDays(7);
                string dtString4 = newDate1.ToString("dd/MM/yyyy");

                IssueInvoicePg.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.OfferExpiry().SendKeys(dtString4);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");

                IssueInvoicePg.SurchargeCheckbox().Click();

                //issueInvoice_issueInvoicePage_totalValue.checkValueContains = @amountGst
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVSPLIT@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);


                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);



                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+asplit01payer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();

                SeleniumSetMethods.WaitOnPage(secdelay7);

                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                BillzyCashModal BillzyCashMlPg = new BillzyCashModal(WebDriver);
                PayNowPage PayNwPg = new PayNowPage(WebDriver);
                SIVPage SIVPG1 = new SIVPage(WebDriver);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVSPLIT@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay6);
                Recpg.SelectInvoiceRow01().Click();
                String paYBTNTopText = Recpg.PaYBTNTopText().Text;
                String paYBTNBottomText = Recpg.PaYBTNBottomText().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(paYBTNTopText.Contains("PAY $8,816.11") && paYBTNBottomText.Contains("PAY $8,816.11"));
                Recpg.PayBTNTop().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PayNowPage paypg = new PayNowPage(WebDriver);
                paypg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.CardRow03().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.Row01AmountPayable().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.Row01AmountPayable().SendKeys("1204.09");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.Row01SplitBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                paypg.Row02SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.SelectinvalidCard2().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                paypg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                paypg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().SendKeys("INVSPLIT@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //string refnum = Recpg.BillzyInvoiceNumRow01().Text;
                string invstatus = SIVPG1.InvoiceStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invstatus.Contains("UNPAID"));


                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+asplit01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                SendPg.SearchInvoiceSent().SendKeys("INVSPLIT@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                string invstatus1 = SIVPG1.InvoiceStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invstatus1.Contains("UNPAID"));

                SeleniumSetMethods.WaitOnPage(secdelay4);
                
                HomePg.SignOutBTN().Click();

                //Verify all email notifications
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
                gmailpg.Search().SendKeys("INVSPLIT@" + randnumber2);
                //gmailpg.Search().SendKeys("INVMTCCADEAL@187439529");
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
                IWebElement bodyTag1 = WebDriver.FindElement(By.TagName("body"));
                bool Content1 = bodyTag1.Text.Contains("Failed Payment");
                bool Content2 = bodyTag1.Text.Contains("Your payment of invoice INVSPLIT@" + randnumber2+ " was unsuccessfull.");
                bool Content3 = bodyTag1.Text.Contains("The following payment methods caused the failure of the payment.");
                bool Content4 = bodyTag1.Text.Contains("Credit card:");
                bool Content5 = bodyTag1.Text.Contains("Unfortunately we could not process your transaction. Please check your information and try again.");
                bool Content6 = bodyTag1.Text.Contains("Reason");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Content1 == true && Content2 == true && Content3 == true && Content4 == true && Content5 == true && Content6 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.profile().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.signout().Click();

            }
            finally
            {
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
               
            }
        }

        [Test]
        public void SplitPayment04_Deal_GST_Surcharge_Valid_DD()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay4);

                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+asplit01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay8);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);

                SendPage SendPg = new SendPage(WebDriver);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+asplit01payer");
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
                DateTime newDate = DateTime.Now.AddDays(900);
                string dtString3 = newDate.ToString("dd/MM/yyyy");
                String PaymentTerms = "30 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.DueDate().Click();

                SeleniumSetMethods.WaitOnPage(secdelay3);
                //IssueInvoicePg.DueDate().Clear();
                //IssueInvoicePg.DueDate().SendKeys(dtString3);
                IssueInvoicePg.CreateInvoice().Click();
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVSPLIT@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");

                IssueInvoicePg.LineItemAmount().SendKeys("8,816.19");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.NewTotal().SendKeys("8,816.11");

                DateTime newDate1 = DateTime.Now.AddDays(7);
                string dtString4 = newDate1.ToString("dd/MM/yyyy");

                IssueInvoicePg.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.OfferExpiry().SendKeys(dtString4);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");

                IssueInvoicePg.SurchargeCheckbox().Click();

                //issueInvoice_issueInvoicePage_totalValue.checkValueContains = @amountGst
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");

                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVSPLIT@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);


                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);



                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+asplit01payer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();

                SeleniumSetMethods.WaitOnPage(secdelay7);

                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                BillzyCashModal BillzyCashMlPg = new BillzyCashModal(WebDriver);
                PayNowPage PayNwPg = new PayNowPage(WebDriver);
                SIVPage SIVPG1 = new SIVPage(WebDriver);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVSPLIT@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay6);
                Recpg.SelectInvoiceRow01().Click();
                String paYBTNTopText = Recpg.PaYBTNTopText().Text;
                String paYBTNBottomText = Recpg.PaYBTNBottomText().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(paYBTNTopText.Contains("PAY $8,816.11") && paYBTNBottomText.Contains("PAY $8,816.11"));
                Recpg.PayBTNTop().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PayNowPage paypg = new PayNowPage(WebDriver);
                paypg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.CardRow02().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.Row01AmountPayable().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.Row01AmountPayable().SendKeys("1204.09");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.Row01SplitBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                paypg.Row02SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.Selectvalidbank2().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                paypg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                paypg.DoneBTN().Click();
                
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ReceivedHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.SearchInvoiceReceived().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().SendKeys("INVSPLIT@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                //string refnum = Recpg.BillzyInvoiceNumRow01().Text;
                string amountpaid = Recpg.AmountRowProcess11().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(amountpaid.Contains("$8,816.11"));


                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+asplit01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SentHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("INVSPLIT@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                String Paidstatus = SIVPG1.PaidStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);

                Assert.IsTrue(Paidstatus.Contains("PROCESSING"));

                SeleniumSetMethods.WaitOnPage(secdelay7);
            }
            finally
            {
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
            }
        }

        [Test]
        public void SplitPayment05_Deal_GST_Surcharge_BothInvalid_DD()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay4);

                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+asplit01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay8);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);

                SendPage SendPg = new SendPage(WebDriver);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+asplit01payer");
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
                DateTime newDate = DateTime.Now.AddDays(900);
                string dtString3 = newDate.ToString("dd/MM/yyyy");
                String PaymentTerms = "30 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.DueDate().Click();

                SeleniumSetMethods.WaitOnPage(secdelay3);
                //IssueInvoicePg.DueDate().Clear();
                //IssueInvoicePg.DueDate().SendKeys(dtString3);
                IssueInvoicePg.CreateInvoice().Click();
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVSPLIT@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");

                IssueInvoicePg.LineItemAmount().SendKeys("8,816.19");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.NewTotal().SendKeys("8,816.11");

                DateTime newDate1 = DateTime.Now.AddDays(7);
                string dtString4 = newDate1.ToString("dd/MM/yyyy");

                IssueInvoicePg.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.OfferExpiry().SendKeys(dtString4);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");

                IssueInvoicePg.SurchargeCheckbox().Click();

                //issueInvoice_issueInvoicePage_totalValue.checkValueContains = @amountGst
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");

                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVSPLIT@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);


                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);



                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+asplit01payer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();

                SeleniumSetMethods.WaitOnPage(secdelay7);

                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                BillzyCashModal BillzyCashMlPg = new BillzyCashModal(WebDriver);
                PayNowPage PayNwPg = new PayNowPage(WebDriver);
                SIVPage SIVPG1 = new SIVPage(WebDriver);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVSPLIT@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay6);
                Recpg.SelectInvoiceRow01().Click();
                String paYBTNTopText = Recpg.PaYBTNTopText().Text;
                String paYBTNBottomText = Recpg.PaYBTNBottomText().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(paYBTNTopText.Contains("PAY $8,816.11") && paYBTNBottomText.Contains("PAY $8,816.11"));
                Recpg.PayBTNTop().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PayNowPage paypg = new PayNowPage(WebDriver);
                paypg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.CardRow04().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.Row01AmountPayable().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.Row01AmountPayable().SendKeys("1204.09");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.Row01SplitBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                paypg.Row02SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.Selectinvalidbank3().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                paypg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                paypg.DoneBTN().Click();

                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ReceivedHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.SearchInvoiceReceived().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().SendKeys("INVSPLIT@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                //string refnum = Recpg.BillzyInvoiceNumRow01().Text;
                string amountpaid = Recpg.AmountRowProcess11().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(amountpaid.Contains("$8,816.11"));


                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+asplit01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SentHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("INVSPLIT@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                String Paidstatus = SIVPG1.PaidStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);

                Assert.IsTrue(Paidstatus.Contains("PROCESSING"));

                SeleniumSetMethods.WaitOnPage(secdelay7);
            }
            finally
            {
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
            }
        }

        [Test]
        public void SplitPayment06_Deal_GST_Surcharge_ValidInvalid_DD()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);


                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+asplit01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay8);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);

                SendPage SendPg = new SendPage(WebDriver);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+asplit01payer");
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
                DateTime newDate = DateTime.Now.AddDays(900);
                string dtString3 = newDate.ToString("dd/MM/yyyy");
                String PaymentTerms = "30 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.DueDate().Click();

                SeleniumSetMethods.WaitOnPage(secdelay3);
                //IssueInvoicePg.DueDate().Clear();
                //IssueInvoicePg.DueDate().SendKeys(dtString3);
                IssueInvoicePg.CreateInvoice().Click();
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVSPLIT@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");

                IssueInvoicePg.LineItemAmount().SendKeys("8,816.19");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.NewTotal().SendKeys("8,816.11");

                DateTime newDate1 = DateTime.Now.AddDays(7);
                string dtString4 = newDate1.ToString("dd/MM/yyyy");

                IssueInvoicePg.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.OfferExpiry().SendKeys(dtString4);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");

                IssueInvoicePg.SurchargeCheckbox().Click();

                //issueInvoice_issueInvoicePage_totalValue.checkValueContains = @amountGst
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVSPLIT@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);


                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);



                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+asplit01payer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();

                SeleniumSetMethods.WaitOnPage(secdelay7);

                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                BillzyCashModal BillzyCashMlPg = new BillzyCashModal(WebDriver);
                PayNowPage PayNwPg = new PayNowPage(WebDriver);
                SIVPage SIVPG1 = new SIVPage(WebDriver);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INVSPLIT@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay6);
                Recpg.SelectInvoiceRow01().Click();
                String paYBTNTopText = Recpg.PaYBTNTopText().Text;
                String paYBTNBottomText = Recpg.PaYBTNBottomText().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(paYBTNTopText.Contains("PAY $8,816.11") && paYBTNBottomText.Contains("PAY $8,816.11"));
                Recpg.PayBTNTop().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PayNowPage paypg = new PayNowPage(WebDriver);
                paypg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.CardRow02().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.Row01AmountPayable().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.Row01AmountPayable().SendKeys("1204.09");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.Row01SplitBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                paypg.Row02SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.Selectinvalidbank2().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                paypg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                paypg.DoneBTN().Click();

                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ReceivedHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.SearchInvoiceReceived().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().SendKeys("INVSPLIT@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                //string refnum = Recpg.BillzyInvoiceNumRow01().Text;
                string amountpaid = Recpg.AmountRowProcess11().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(amountpaid.Contains("$8,816.11"));


                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+asplit01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SentHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("INVSPLIT@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SearchedFirstRowDetailsLink().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                String Paidstatus = SIVPG1.PaidStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);

                Assert.IsTrue(Paidstatus.Contains("PROCESSING"));

                SeleniumSetMethods.WaitOnPage(secdelay7);
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
