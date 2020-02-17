
using System;
using MySql.Data.MySqlClient;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using BillzyAutomationTestSuite.PageObjects;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualBasic;
using System.Net;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using BillzyAutomationTestSuite;

using BillzyAutomationTestSuite.Scripts;

namespace BillzyAutomationTestSuite.Scripts
{
    class CDR_FDR_Validation : Tests
    {
        [Test]
        public void StartReport()
        {

            try
            {
                string awsid = "";
                string awsuname = "";
                string bamboouname = "";
                string ilinkuname = "";
                string awspassword = "";
                string bamboopassword = "";
                string ilinkpassword = "";
                

                string connstring10 = "SERVER=ua1499yt8dheg18.coyhkhf2vwwc.ap-southeast-2.rds.amazonaws.com;DATABASE=billzy;USERNAME=AutoTest;PASSWORD=MEtZA9e1SJvMm0d4ukLk;";
                MySqlConnection conn = new MySqlConnection(connstring10);
                MySqlCommand command = conn.CreateCommand();
                string folderdate = DateTime.Now.ToString("ddMMyyyHHmmss");
                var chromeOptions = new ChromeOptions();
                var downloadDirectory = @"C:\Users\BillzyAdmin\OneDrive-Billzy\BillzyTestSuite\BillzyAutomationTestSuite\bin\Debug\netcoreapp3.0\Files" + folderdate;
                chromeOptions.AddUserProfilePreference("download.default_directory", downloadDirectory);
                chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
                chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");

                var WebDriver = new ChromeDriver(chromeOptions);
                HomePage HomePg = new HomePage(WebDriver);
                BambooPage Bampg = new BambooPage(WebDriver);
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                SendPage SendPg = new SendPage(WebDriver);
                SIVPage SIVPG1 = new SIVPage(WebDriver);
                PayNowPage Paynwpg = new PayNowPage(WebDriver);
                AWSNonProdPage awspg = new AWSNonProdPage(WebDriver);
                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                LoginPage loginPg = new LoginPage(WebDriver);
                ILinkPage ilinkpg = new ILinkPage(WebDriver);
                BOBOPage Bobopg = new BOBOPage(WebDriver);
                GMAILPage gmailpg = new GMAILPage(WebDriver);
                IWebElement bodyTag1 = WebDriver.FindElement(By.TagName("body"));

                /* string invoicenumber1 = "INV10362242";
                 string invoicenumber2 = "INV10362259";
                 string invoicenumber3 = "INV10362267";

                 string invoicenumber4 = "INV10362275";
                 string invoicenumber5 = "INV10362283";
                 string invoicenumber6 = "INV10362291";
                 string invoicenumber7 = "INV10362309";
                 string invoicenumber8 = "INV10362317";
                 string invoicenumber9 = "INV10362325";
                 string invoicenumber10 = "INV10362333";
                 string invoicenumber11 = "INV10362341";
                 string invoicenumber12 = "INV10362358";
                 string invoicenumber13 = "INV10362366";
                 string invoicenumber14 = "INV10362374";
                 string invoicenumber15 = "INV10362382";
                 string invoicenumber16 = "INV10362390";
                 string invoicenumber17 = "INV10362408";
                 string invoicenumber18 = "INV10362416";
                 string invoicenumber19 = "INV10362424";
                 string invoicenumber20 = "INV10362432";
                 string invoicenumber21 = "INV10362440";
                 string invoicenumber22 = "INV10362457";
                 string invoicenumber23 = "INV10362465";
                 string invoicenumber24 = "INV10362473";
                 string invoicenumber25 = "INV10362481";
                 string invoicenumber26 = "INV10362499";
                 string invoicenumber27 = "INV10362507";
                 string invoicenumber28 = "INV10362515";
                 string invoicenumber29 = "INV10362523";
                 string invoicenumber30 = "INV10362531";
                 string invoicenumber31 = "INV10362549";
                 string invoicenumber32 = "INV10362556";
                 string invoicenumber33 = "INV10362564";
                 string invoicenumber34 = "INV10362572";
                 string invoicenumber40 = "INV10362580";
                 string invoicenumber41 = "INV10362598";
                 string invoicenumber42 = "INV10362606";
                 string invoicenumber43 = "INV10362614";
                 string invoicenumber44 = "INV10362622";
                 string invoicenumber45 = "INV10362630";
                 string invoicenumber46 = "INV10362648";
                 string invoicenumber47 = "INV10362655";
                 string invoicenumber48 = "INV10362663";
                 string invoicenumber49 = "INV10362671";
                 string invoicenumber50 = "INV10362689";
                 string invoicenumber51 = "INV10362697";
                 string invoicenumber52 = "INV10362705";
                 string randnumber2 = "1869675348";
                 */

                //string randnumber2 = "1869675348";

                DateTime duedate1 = DateTime.Today;
                string SentPgDueDate = duedate1.ToString("dd MMM yyyy");


                Random rand = new Random();
                DateTime dt = new DateTime();
                string dtString = dt.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber1 = rand.Next();
                Random rand2 = new Random();
                DateTime dt2 = new DateTime();
                string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber2 = rand.Next();
                String PaymentTerms = "90 days";
                string randnumbervalue = randnumber2.ToString();

                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                SeleniumSetMethods.WaitOnPage(4);
                loginPg.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                loginPg.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(2);
                loginPg.UserNameTextBox().SendKeys("madcowtesting10+cdrfdrbiller@gmail.com");
                loginPg.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                loginPg.PasswordTextBox().SendKeys("Cognito1");
                loginPg.LoginButton().Click();
                Console.WriteLine(randnumber2);
                SeleniumSetMethods.WaitOnPage(7);

                //Internal Cash    Yes Requested   CC 01INTSURCASHREQCC@

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+cdrfdrpayer");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("001INTSURCASHREQCC@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.SearchInvoiceSent().SendKeys("001INTSURCASHREQCC@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(5);
                string invnumber1 = SIVPG1.InvNumber().Text;
                string invoicenumber1 = invnumber1.Substring(invnumber1.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber1, "001INTSURCASHREQCC@" + randnumber2, "FDRInvoiceslist2.csv");
                InvList("randnumbervalue", randnumbervalue, "stringlist.txt");
                InvList("invoicenumber1", invoicenumber1, "stringlist.txt");
                SeleniumSetMethods.WaitOnPage(2);

                //Internal Cash    No Requested   Bank 02INTNOSURCASHREQDD@

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+cdrfdrpayer");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("002INTNOSURCASHREQDD@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                //IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.SearchInvoiceSent().SendKeys("002INTNOSURCASHREQDD@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(5);
                string invnumber2 = SIVPG1.InvNumber().Text;
                string invoicenumber2 = invnumber2.Substring(invnumber2.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber2, "002INTNOSURCASHREQDD@" + randnumber2, "FDRInvoiceslist2.csv");
                SeleniumSetMethods.WaitOnPage(2);
                InvList("invoicenumber2", invoicenumber2, "stringlist.txt");
                //Internal Cash    Yes Approved    CC  03INTSURCASHAPPCC@

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+cdrfdrpayer");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("003INTSURCASHAPPCC@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.SearchInvoiceSent().SendKeys("003INTSURCASHAPPCC@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(5);
                string invnumber3 = SIVPG1.InvNumber().Text;
                string invoicenumber3 = invnumber3.Substring(invnumber3.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber3, "003INTSURCASHAPPCC@" + randnumber2, "FDRInvoiceslist2.csv");
                SeleniumSetMethods.WaitOnPage(2);
                addrecord(invoicenumber3, "approved", "FDRFactorFox.csv");
                InvList("invoicenumber3", invoicenumber3, "stringlist.txt");
                SeleniumSetMethods.WaitOnPage(1);

                //Internal Cash    No Approved    Bank    04INTNOSURCASHAPPDD@

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+cdrfdrpayer");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("004INTNOSURCASHAPPDD@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                //IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.SearchInvoiceSent().SendKeys("004INTNOSURCASHAPPDD@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(5);
                string invnumber4 = SIVPG1.InvNumber().Text;
                string invoicenumber4 = invnumber4.Substring(invnumber4.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber4, "004INTNOSURCASHAPPDD@" + randnumber2, "FDRInvoiceslist2.csv");
                SeleniumSetMethods.WaitOnPage(2);
                addrecord(invoicenumber4, "approved", "FDRFactorFox.csv");
                SeleniumSetMethods.WaitOnPage(1);
                InvList("invoicenumber4", invoicenumber4, "stringlist.txt");
                //Internal Cash    Yes Batched CC  05INTSURCASHBATCC@

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+cdrfdrpayer");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("005INTSURCASHBATCC@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.SearchInvoiceSent().SendKeys("005INTSURCASHBATCC@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(5);
                string invnumber5 = SIVPG1.InvNumber().Text;
                string invoicenumber5 = invnumber5.Substring(invnumber5.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber5, "005INTSURCASHBATCC@" + randnumber2, "FDRInvoiceslist2.csv");
                SeleniumSetMethods.WaitOnPage(2);
                addrecord(invoicenumber5, "approved", "FDRFactorFox.csv");
                SeleniumSetMethods.WaitOnPage(1);
                InvList("invoicenumber5", invoicenumber5, "stringlist.txt");
                //Internal Cash    No Batched Bank    06INTNOSURCASHBATDD@

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+cdrfdrpayer");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("006INTNOSURCASHBATDD@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                //IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.SearchInvoiceSent().SendKeys("006INTNOSURCASHBATDD@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(5);
                string invnumber6 = SIVPG1.InvNumber().Text;
                string invoicenumber6 = invnumber6.Substring(invnumber6.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber6, "006INTNOSURCASHBATDD@" + randnumber2, "FDRInvoiceslist2.csv");
                SeleniumSetMethods.WaitOnPage(2);
                addrecord(invoicenumber6, "approved", "FDRFactorFox.csv");
                SeleniumSetMethods.WaitOnPage(1);
                InvList("invoicenumber6", invoicenumber6, "stringlist.txt");
                //Internal Cash    Yes Funded  CC  07INTSURCASHFUNCC@
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+cdrfdrpayer");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("007INTSURCASHFUNCC@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.SearchInvoiceSent().SendKeys("007INTSURCASHFUNCC@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(5);
                string invnumber7 = SIVPG1.InvNumber().Text;
                string invoicenumber7 = invnumber7.Substring(invnumber7.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber7, "007INTSURCASHFUNCC@" + randnumber2, "FDRInvoiceslist2.csv");
                SeleniumSetMethods.WaitOnPage(2);
                addrecord(invoicenumber7, "approved", "FDRFactorFox.csv");
                SeleniumSetMethods.WaitOnPage(1);
                InvList("invoicenumber7", invoicenumber7, "stringlist.txt");
                //Internal Cash    No Funded  Bank    08INTNOSURCASHFUNDD@

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+cdrfdrpayer");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("008INTNOSURCASHFUNDD@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                //IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.SearchInvoiceSent().SendKeys("008INTNOSURCASHFUNDD@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(5);
                string invnumber8 = SIVPG1.InvNumber().Text;
                string invoicenumber8 = invnumber8.Substring(invnumber8.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber8, "008INTNOSURCASHFUNDD@" + randnumber2, "FDRInvoiceslist2.csv");
                SeleniumSetMethods.WaitOnPage(2);
                addrecord(invoicenumber8, "approved", "FDRFactorFox.csv");
                SeleniumSetMethods.WaitOnPage(1);
                InvList("invoicenumber8", invoicenumber8, "stringlist.txt");
                //Internal Cash    Yes Declined    CC  09INTSURCASHDECCC@

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+cdrfdrpayer");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("009INTSURCASHDECCC@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.SearchInvoiceSent().SendKeys("009INTSURCASHDECCC@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(5);
                string invnumber9 = SIVPG1.InvNumber().Text;
                string invoicenumber9 = invnumber9.Substring(invnumber9.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber9, "009INTSURCASHDECCC@" + randnumber2, "FDRInvoiceslist2.csv");
                SeleniumSetMethods.WaitOnPage(2);
                InvList("invoicenumber9", invoicenumber9, "stringlist.txt");
                //Internal Cash    No Declined    Bank    10INTNOSURCASHDECDD@

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+cdrfdrpayer");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("010INTNOSURCASHDECDD@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                //IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.SearchInvoiceSent().SendKeys("010INTNOSURCASHDECDD@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(5);
                string invnumber10 = SIVPG1.InvNumber().Text;
                string invoicenumber10 = invnumber10.Substring(invnumber10.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber10, "010INTNOSURCASHDECDD@" + randnumber2, "FDRInvoiceslist2.csv");
                SeleniumSetMethods.WaitOnPage(2);
                InvList("invoicenumber10", invoicenumber10, "stringlist.txt");
                //Internal Cash    No FFApproved  CC  11INTSURCASHFFACC@

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+cdrfdrpayer");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("011INTSURCASHFFACC@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.SearchInvoiceSent().SendKeys("011INTSURCASHFFACC@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(5);
                string invnumber11 = SIVPG1.InvNumber().Text;
                string invoicenumber11 = invnumber11.Substring(invnumber11.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber11, "011INTSURCASHFFACC@" + randnumber2, "FDRInvoiceslist2.csv");
                SeleniumSetMethods.WaitOnPage(2);
                addrecord(invoicenumber11, "approved", "FDRFactorFox.csv");
                SeleniumSetMethods.WaitOnPage(1);
                InvList("invoicenumber11", invoicenumber11, "stringlist.txt");
                //Internal Cash    No PayerVerified   Bank    12INTNOSURCASHPVERDD@

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+cdrfdrpayer");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("012INTNOSURCASHPVERDD@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                //IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.SearchInvoiceSent().SendKeys("012INTNOSURCASHPVERDD@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(5);
                string invnumber12 = SIVPG1.InvNumber().Text;
                string invoicenumber12 = invnumber12.Substring(invnumber12.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber12, "012INTNOSURCASHPVERDD@" + randnumber2, "FDRInvoiceslist2.csv");
                SeleniumSetMethods.WaitOnPage(2);
                SeleniumSetMethods.WaitOnPage(2);
                addrecord(invoicenumber12, "approved", "FDRFactorFox.csv");
                SeleniumSetMethods.WaitOnPage(1);
                InvList("invoicenumber12", invoicenumber12, "stringlist.txt");
                //Internal Cash    Yes Requested   MAP 13INTSURCASHREQMAP@

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+cdrfdrpayer");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("013INTSURCASHREQMAP@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.SearchInvoiceSent().SendKeys("013INTSURCASHREQMAP@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(5);
                string invnumber13 = SIVPG1.InvNumber().Text;
                string invoicenumber13 = invnumber13.Substring(invnumber13.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber13, "013INTSURCASHREQMAP@" + randnumber2, "FDRInvoiceslist2.csv");
                SeleniumSetMethods.WaitOnPage(2);
                InvList("invoicenumber13", invoicenumber13, "stringlist.txt");
                //Internal Cash    Yes Approved    MAP BOBO    14INTSURCASHAPPMAPBOBO@

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+cdrfdrpayer");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("014INTSURCASHAPPMAPBOBO@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.SearchInvoiceSent().SendKeys("014INTSURCASHAPPMAPBOBO@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(5);
                string invnumber14 = SIVPG1.InvNumber().Text;
                string invoicenumber14 = invnumber14.Substring(invnumber14.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber14, "014INTSURCASHAPPMAPBOBO@" + randnumber2, "FDRInvoiceslist2.csv");
                SeleniumSetMethods.WaitOnPage(2);
                addrecord(invoicenumber14, "approved", "FDRFactorFox.csv");
                SeleniumSetMethods.WaitOnPage(1);
                InvList("invoicenumber14", invoicenumber14, "stringlist.txt");
                //Internal Cash    Yes Batched MAP BOBO    15INTSURCASHBATMAPBOBO@

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+cdrfdrpayer");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("015INTSURCASHBATMAPBOBO@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.SearchInvoiceSent().SendKeys("015INTSURCASHBATMAPBOBO@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(5);
                string invnumber15 = SIVPG1.InvNumber().Text;
                string invoicenumber15 = invnumber15.Substring(invnumber15.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber15, "015INTSURCASHBATMAPBOBO@" + randnumber2, "FDRInvoiceslist2.csv");
                SeleniumSetMethods.WaitOnPage(2);
                addrecord(invoicenumber15, "approved", "FDRFactorFox.csv");
                SeleniumSetMethods.WaitOnPage(1);
                InvList("invoicenumber15", invoicenumber15, "stringlist.txt");

                //Internal Cash    Yes Funded  MAP BOBO    16INTSURCASHFUNMAPBOBO@

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+cdrfdrpayer");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("016INTSURCASHFUNMAPBOBO@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.SearchInvoiceSent().SendKeys("016INTSURCASHFUNMAPBOBO@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(5);
                string invnumber16 = SIVPG1.InvNumber().Text;
                string invoicenumber16 = invnumber16.Substring(invnumber16.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber16, "016INTSURCASHFUNMAPBOBO@" + randnumber2, "FDRInvoiceslist2.csv");
                SeleniumSetMethods.WaitOnPage(2);
                addrecord(invoicenumber16, "approved", "FDRFactorFox.csv");
                SeleniumSetMethods.WaitOnPage(1);
                InvList("invoicenumber16", invoicenumber16, "stringlist.txt");

                //Internal Cash    Yes Declined    MAP BOBO    17INTSURCASHDECMAPBOBO@

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+cdrfdrpayer");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("017INTSURCASHDECMAPBOBO@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.SearchInvoiceSent().SendKeys("017INTSURCASHDECMAPBOBO@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(5);
                string invnumber17 = SIVPG1.InvNumber().Text;
                string invoicenumber17 = invnumber17.Substring(invnumber17.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber17, "017INTSURCASHDECMAPBOBO@" + randnumber2, "FDRInvoiceslist2.csv");
                SeleniumSetMethods.WaitOnPage(2);
                InvList("invoicenumber17", invoicenumber17, "stringlist.txt");
                //Internal Cash    Yes FFApproved  MAP BOBO    18INTSURCASHFFAMAPBOBO@

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+cdrfdrpayer");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("018INTSURCASHFFAMAPBOBO@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.SearchInvoiceSent().SendKeys("018INTSURCASHFFAMAPBOBO@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(4);
                string invnumber18 = SIVPG1.InvNumber().Text;
                string invoicenumber18 = invnumber18.Substring(invnumber18.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber18, "018INTSURCASHFFAMAPBOBO@" + randnumber2, "FDRInvoiceslist2.csv");
                SeleniumSetMethods.WaitOnPage(2);
                addrecord(invoicenumber18, "approved", "FDRFactorFox.csv");
                SeleniumSetMethods.WaitOnPage(1);
                InvList("invoicenumber18", invoicenumber18, "stringlist.txt");
                //External Cash    Yes Requested   CC  19EXTSURCASHREQCC@

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("External1");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("019EXTSURCASHREQCC@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.SearchInvoiceSent().SendKeys("019EXTSURCASHREQCC@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(4);
                string invnumber19 = SIVPG1.InvNumber().Text;
                string invoicenumber19 = invnumber19.Substring(invnumber19.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber19, "019EXTSURCASHREQCC@" + randnumber2, "FDRInvoiceslist2.csv");
                SeleniumSetMethods.WaitOnPage(2);
                InvList("invoicenumber19", invoicenumber19, "stringlist.txt");
                //External Cash    No Requested   BPAY    20EXTNOSURCASHREQBPAY@

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("External1");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("020EXTNOSURCASHREQBPAY@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                //IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.SearchInvoiceSent().SendKeys("020EXTNOSURCASHREQBPAY@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(4);
                string invnumber20 = SIVPG1.InvNumber().Text;
                string invoicenumber20 = invnumber20.Substring(invnumber20.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber20, "020EXTNOSURCASHREQBPAY@" + randnumber2, "FDRInvoiceslist2.csv");
                SeleniumSetMethods.WaitOnPage(2);
                InvList("invoicenumber20", invoicenumber20, "stringlist.txt");
                //External Cash    Yes Approved    CC  21EXTSURCASHAPPCC@

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("External1");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("021EXTSURCASHAPPCC@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.SearchInvoiceSent().SendKeys("021EXTSURCASHAPPCC@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(4);
                string invnumber21 = SIVPG1.InvNumber().Text;
                string invoicenumber21 = invnumber21.Substring(invnumber21.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber21, "021EXTSURCASHAPPCC@" + randnumber2, "FDRInvoiceslist2.csv");
                SeleniumSetMethods.WaitOnPage(2);
                addrecord(invoicenumber21, "approved", "FDRFactorFox.csv");
                SeleniumSetMethods.WaitOnPage(1);
                InvList("invoicenumber21", invoicenumber21, "stringlist.txt");
                //External Cash    No Approved    BPAY    22EXTNOSURCASHAPPBPAY@

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("External1");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("022EXTNOSURCASHAPPBPAY@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                //IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.SearchInvoiceSent().SendKeys("022EXTNOSURCASHAPPBPAY@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(4);
                string invnumber22 = SIVPG1.InvNumber().Text;
                string invoicenumber22 = invnumber22.Substring(invnumber22.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber22, "022EXTNOSURCASHAPPBPAY@" + randnumber2, "FDRInvoiceslist2.csv");
                SeleniumSetMethods.WaitOnPage(2);
                addrecord(invoicenumber22, "approved", "FDRFactorFox.csv");
                SeleniumSetMethods.WaitOnPage(1);
                InvList("invoicenumber22", invoicenumber22, "stringlist.txt");
                //External Cash    Yes Batched CC  23EXTSURCASHBATCC@

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("External1");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("023EXTSURCASHBATCC@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.SearchInvoiceSent().SendKeys("023EXTSURCASHBATCC@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(4);
                string invnumber23 = SIVPG1.InvNumber().Text;
                string invoicenumber23 = invnumber23.Substring(invnumber23.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber23, "023EXTSURCASHBATCC@" + randnumber2, "FDRInvoiceslist2.csv");
                SeleniumSetMethods.WaitOnPage(2);
                addrecord(invoicenumber23, "approved", "FDRFactorFox.csv");
                SeleniumSetMethods.WaitOnPage(1);
                InvList("invoicenumber23", invoicenumber23, "stringlist.txt");
                //External Cash    No Batched BPAY    24EXTNOSURCASHBATBPAY@

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("External1");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("024EXTNOSURCASHBATBPAY@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                //IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.SearchInvoiceSent().SendKeys("024EXTNOSURCASHBATBPAY@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(4);
                string invnumber24 = SIVPG1.InvNumber().Text;
                string invoicenumber24 = invnumber24.Substring(invnumber24.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber24, "024EXTNOSURCASHBATBPAY@" + randnumber2, "FDRInvoiceslist2.csv");
                SeleniumSetMethods.WaitOnPage(2);
                addrecord(invoicenumber24, "approved", "FDRFactorFox.csv");
                SeleniumSetMethods.WaitOnPage(1);
                InvList("invoicenumber24", invoicenumber24, "stringlist.txt");
                //External Cash    Yes Funded  CC  25EXTSURCASHFUNCC@

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("External1");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("025EXTSURCASHFUNCC@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.SearchInvoiceSent().SendKeys("025EXTSURCASHFUNCC@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(4);
                string invnumber25 = SIVPG1.InvNumber().Text;
                string invoicenumber25 = invnumber25.Substring(invnumber25.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber25, "025EXTSURCASHFUNCC@" + randnumber2, "FDRInvoiceslist2.csv");
                SeleniumSetMethods.WaitOnPage(2);
                addrecord(invoicenumber25, "approved", "FDRFactorFox.csv");
                SeleniumSetMethods.WaitOnPage(1);
                InvList("invoicenumber25", invoicenumber25, "stringlist.txt");

                //External Cash    No Funded  BPAY    26EXTSNOSURCASHFUNBPAY@

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("External1");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("026EXTSNOSURCASHFUNBPAY@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                //IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.SearchInvoiceSent().SendKeys("026EXTSNOSURCASHFUNBPAY@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(4);
                string invnumber26 = SIVPG1.InvNumber().Text;
                string invoicenumber26 = invnumber26.Substring(invnumber26.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber26, "026EXTSNOSURCASHFUNBPAY@" + randnumber2, "FDRInvoiceslist2.csv");
                SeleniumSetMethods.WaitOnPage(2);
                addrecord(invoicenumber26, "approved", "FDRFactorFox.csv");
                SeleniumSetMethods.WaitOnPage(1);
                InvList("invoicenumber26", invoicenumber26, "stringlist.txt");
                //External Cash    Yes Declined    CC  27EXTSURCASHDECCC@

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("External1");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("027EXTSURCASHDECCC@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.SearchInvoiceSent().SendKeys("027EXTSURCASHDECCC@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(4);
                string invnumber27 = SIVPG1.InvNumber().Text;
                string invoicenumber27 = invnumber27.Substring(invnumber27.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber27, "027EXTSURCASHDECCC@" + randnumber2, "FDRInvoiceslist2.csv");
                SeleniumSetMethods.WaitOnPage(2);
                InvList("invoicenumber27", invoicenumber27, "stringlist.txt");

                //External Cash    No Declined    BPAY    28EXTNOSURCASHDECBPAY@

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("External1");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("028EXTNOSURCASHDECBPAY@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                //IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.SearchInvoiceSent().SendKeys("028EXTNOSURCASHDECBPAY@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(4);
                string invnumber28 = SIVPG1.InvNumber().Text;
                string invoicenumber28 = invnumber28.Substring(invnumber28.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber28, "028EXTNOSURCASHDECBPAY@" + randnumber2, "FDRInvoiceslist2.csv");
                SeleniumSetMethods.WaitOnPage(2);
                InvList("invoicenumber28", invoicenumber28, "stringlist.txt");
                //External Cash    Yes Requested   MAP BOBO    29EXTSURCASHREQMAPBOBO@

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("External1");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("029EXTSURCASHREQMAPBOBO@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.SearchInvoiceSent().SendKeys("029EXTSURCASHREQMAPBOBO@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(4);
                string invnumber29 = SIVPG1.InvNumber().Text;
                string invoicenumber29 = invnumber29.Substring(invnumber29.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber29, "029EXTSURCASHREQMAPBOBO@" + randnumber2, "FDRInvoiceslist2.csv");
                SeleniumSetMethods.WaitOnPage(2);
                InvList("invoicenumber29", invoicenumber29, "stringlist.txt");
                //External Cash    Yes Approved    MAP BOBO    30EXTSURCASHAPPMAPBOBO@

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("External1");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("030EXTSURCASHAPPMAPBOBO@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.SearchInvoiceSent().SendKeys("030EXTSURCASHAPPMAPBOBO@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(4);
                string invnumber30 = SIVPG1.InvNumber().Text;
                string invoicenumber30 = invnumber30.Substring(invnumber30.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber30, "030EXTSURCASHAPPMAPBOBO@" + randnumber2, "FDRInvoiceslist2.csv");
                SeleniumSetMethods.WaitOnPage(2);
                addrecord(invoicenumber30, "approved", "FDRFactorFox.csv");
                SeleniumSetMethods.WaitOnPage(1);
                InvList("invoicenumber30", invoicenumber30, "stringlist.txt");

                //External Cash    Yes Batched MAP BOBO    31EXTSURCASHBATMAPBOBO@

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("External1");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("031EXTSURCASHBATMAPBOBO@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.SearchInvoiceSent().SendKeys("031EXTSURCASHBATMAPBOBO@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(4);
                string invnumber31 = SIVPG1.InvNumber().Text;
                string invoicenumber31 = invnumber31.Substring(invnumber31.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber31, "031EXTSURCASHBATMAPBOBO@" + randnumber2, "FDRInvoiceslist2.csv");
                SeleniumSetMethods.WaitOnPage(2);
                addrecord(invoicenumber31, "approved", "FDRFactorFox.csv");
                SeleniumSetMethods.WaitOnPage(1);
                InvList("invoicenumber31", invoicenumber31, "stringlist.txt");
                //External Cash    Yes Funded  MAP BOBO    32EXTSURCASHFUNMAPBOBO@

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("External1");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("032EXTSURCASHFUNMAPBOBO@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.SearchInvoiceSent().SendKeys("032EXTSURCASHFUNMAPBOBO@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(4);
                string invnumber32 = SIVPG1.InvNumber().Text;
                string invoicenumber32 = invnumber32.Substring(invnumber32.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber32, "032EXTSURCASHFUNMAPBOBO@" + randnumber2, "FDRInvoiceslist2.csv");
                SeleniumSetMethods.WaitOnPage(2);
                addrecord(invoicenumber32, "approved", "FDRFactorFox.csv");
                SeleniumSetMethods.WaitOnPage(1);
                InvList("invoicenumber32", invoicenumber32, "stringlist.txt");
                //External Cash    Yes Declined    MAP BOBO    33EXTSURCASHDECMAPBOBO@

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("External1");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("033EXTSURCASHDECMAPBOBO@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.SearchInvoiceSent().SendKeys("033EXTSURCASHDECMAPBOBO@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(4);
                string invnumber33 = SIVPG1.InvNumber().Text;
                string invoicenumber33 = invnumber33.Substring(invnumber33.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber33, "033EXTSURCASHDECMAPBOBO@" + randnumber2, "FDRInvoiceslist2.csv");
                SeleniumSetMethods.WaitOnPage(2);
                InvList("invoicenumber33", invoicenumber33, "stringlist.txt");
                //External Cash    Yes FFApproved  MAP BOBO    34EXTSURCASHFFAMAPBOBO@

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("External1");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("034EXTSURCASHFFAMAPBOBO@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.SearchInvoiceSent().SendKeys("034EXTSURCASHFFAMAPBOBO@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(4);
                string invnumber34 = SIVPG1.InvNumber().Text;
                string invoicenumber34 = invnumber34.Substring(invnumber34.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber34, "034EXTSURCASHFFAMAPBOBO@" + randnumber2, "FDRInvoiceslist2.csv");
                SeleniumSetMethods.WaitOnPage(2);
                addrecord(invoicenumber34, "approved", "FDRFactorFox.csv");
                SeleniumSetMethods.WaitOnPage(1);
                InvList("invoicenumber34", invoicenumber34, "stringlist.txt");
                //Issue Invoice Normal - Int	Surcharge	Card	NORINTSURCC

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+cdrfdrpayer");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("040NORINTSURCC@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("200");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Console.WriteLine("InvoiceCreated");
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                SendPg.SentOutstandingBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                SendPg.SearchInvoiceSent().SendKeys("040NORINTSURCC@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(4);
                string ffinvnumber1 = SIVPG1.InvNumber().Text;
                string invoicenumber40 = ffinvnumber1.Substring(ffinvnumber1.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber40, "040NORINTSURCC@" + randnumber2, "FDRInvoiceslist2.csv");
                SeleniumSetMethods.WaitOnPage(4);
                InvList("invoicenumber40", invoicenumber40, "stringlist.txt");
                //Issue Invoice - Normal - Int	No Surcharge	Card	NORINTNOSURCC

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+cdrfdrpayer");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("041NORINTNOSURCC@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Console.WriteLine("InvoiceCreated");
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                SendPg.SentOutstandingBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                SendPg.SearchInvoiceSent().SendKeys("041NORINTNOSURCC@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(4);
                string ffinvnumber2 = SIVPG1.InvNumber().Text;
                string invoicenumber41 = ffinvnumber2.Substring(ffinvnumber2.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber41, "041NORINTNOSURCC@" + randnumber2, "FDRInvoiceslist2.csv");
                InvList("invoicenumber41", invoicenumber41, "stringlist.txt");

                //Issue Invoice - Normal - Int	Surcharge	Bank	NORINTSURDD
                SeleniumSetMethods.WaitOnPage(4);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+cdrfdrpayer");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("042NORINTSURDD@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("60");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Console.WriteLine("InvoiceCreated");
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                SendPg.SentOutstandingBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                SendPg.SearchInvoiceSent().SendKeys("042NORINTSURDD@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(4);
                string ffinvnumber3 = SIVPG1.InvNumber().Text;
                string invoicenumber42 = ffinvnumber3.Substring(ffinvnumber3.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber42, "042NORINTSURDD@" + randnumber2, "FDRInvoiceslist2.csv");
                InvList("invoicenumber42", invoicenumber42, "stringlist.txt");

                //Issue Invoice -Normal - Int	No Surcharge	Bank	NORINTNOSURDD
                SeleniumSetMethods.WaitOnPage(4);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+cdrfdrpayer");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("043NORINTNOSURDD@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("50");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Console.WriteLine("InvoiceCreated");
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                SendPg.SentOutstandingBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                SendPg.SearchInvoiceSent().SendKeys("043NORINTNOSURDD@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(4);
                string ffinvnumber4 = SIVPG1.InvNumber().Text;
                string invoicenumber43 = ffinvnumber4.Substring(ffinvnumber4.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber43, "043NORINTNOSURDD@" + randnumber2, "FDRInvoiceslist2.csv");
                InvList("invoicenumber43", invoicenumber43, "stringlist.txt");

                //Issue Invoice -Normal - Ext	Surcharge	Card	NOREXTSURCC
                SeleniumSetMethods.WaitOnPage(4);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("External1");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("044NOREXTSURCC@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("200");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Console.WriteLine("InvoiceCreated");
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                SendPg.SentOutstandingBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                SendPg.SearchInvoiceSent().SendKeys("044NOREXTSURCC@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(4);
                string ffinvnumber5 = SIVPG1.InvNumber().Text;
                string invoicenumber44 = ffinvnumber5.Substring(ffinvnumber5.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber44, "044NOREXTSURCC@" + randnumber2, "FDRInvoiceslist2.csv");
                SeleniumSetMethods.WaitOnPage(4);
                InvList("invoicenumber44", invoicenumber44, "stringlist.txt");

                //Issue Invoice -Normal - Ext	No Surcharge	Card	NOREXTNOSURCC

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("External1");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("045NOREXTNOSURCC@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Console.WriteLine("InvoiceCreated");
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                SendPg.SentOutstandingBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                SendPg.SearchInvoiceSent().SendKeys("045NOREXTNOSURCC@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(4);
                string ffinvnumber6 = SIVPG1.InvNumber().Text;
                string invoicenumber45 = ffinvnumber6.Substring(ffinvnumber6.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber45, "045NOREXTNOSURCC@" + randnumber2, "FDRInvoiceslist2.csv");
                InvList("invoicenumber45", invoicenumber45, "stringlist.txt");

                //Issue Invoice -Deal - Int	Surcharge	Card	DEALSURCC
                SeleniumSetMethods.WaitOnPage(4);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+cdrfdrpayer");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("046DEALINTSURCC@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("60");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.NewTotal().SendKeys("60");
                DateTime newDate = DateTime.Now.AddDays(15);
                string dtString3 = newDate.ToString("dd/MM/yyyy");
                IssueInvoicePg.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
                IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");
                IssueInvoicePg.SurchargeCheckbox().Click();
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Console.WriteLine("InvoiceCreated");
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                SendPg.SentOutstandingBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                SendPg.SearchInvoiceSent().SendKeys("046DEALINTSURCC@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(4);
                string ffinvnumber7 = SIVPG1.InvNumber().Text;
                string invoicenumber46 = ffinvnumber7.Substring(ffinvnumber7.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber46, "046DEALINTSURCC@" + randnumber2, "FDRInvoiceslist2.csv");
                InvList("invoicenumber46", invoicenumber46, "stringlist.txt");

                //Issue Invoice -Deal - Int	No Surcharge	Card	DEALNOSURCC
                SeleniumSetMethods.WaitOnPage(4);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+cdrfdrpayer");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("047DEALINTNOSURCC@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("50");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.NewTotal().SendKeys("50");
                IssueInvoicePg.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
                IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");
                //IssueInvoicePg.SurchargeCheckbox().Click();
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Console.WriteLine("InvoiceCreated");
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                SendPg.SentOutstandingBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                SendPg.SearchInvoiceSent().SendKeys("047DEALINTNOSURCC@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(4);
                string ffinvnumber8 = SIVPG1.InvNumber().Text;
                string invoicenumber47 = ffinvnumber8.Substring(ffinvnumber8.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber47, "047DEALINTNOSURCC@" + randnumber2, "FDRInvoiceslist2.csv");
                SeleniumSetMethods.WaitOnPage(4);
                InvList("invoicenumber47", invoicenumber47, "stringlist.txt");
                //Issue Invoice -Deal - Int	Surcharge	Bank	DEALSURDD

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+cdrfdrpayer");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("048DEALINTSURDD@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("200");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.NewTotal().SendKeys("200");
                IssueInvoicePg.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
                IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");
                IssueInvoicePg.SurchargeCheckbox().Click();
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Console.WriteLine("InvoiceCreated");
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                SendPg.SentOutstandingBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                SendPg.SearchInvoiceSent().SendKeys("048DEALINTSURDD@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(4);
                string ffinvnumber9 = SIVPG1.InvNumber().Text;
                string invoicenumber48 = ffinvnumber9.Substring(ffinvnumber9.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber48, "048DEALINTSURDD@" + randnumber2, "FDRInvoiceslist2.csv");
                SeleniumSetMethods.WaitOnPage(4);
                InvList("invoicenumber48", invoicenumber48, "stringlist.txt");
                //Issue Invoice -Deal - Int	No Surcharge	Bank	DEALNOSURDD


                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+cdrfdrpayer");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("049DEALINTNOSURDD@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.NewTotal().SendKeys("100");
                IssueInvoicePg.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
                IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");
                //IssueInvoicePg.SurchargeCheckbox().Click();
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Console.WriteLine("InvoiceCreated");
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                SendPg.SentOutstandingBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                SendPg.SearchInvoiceSent().SendKeys("049DEALINTNOSURDD@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(4);
                string ffinvnumber10 = SIVPG1.InvNumber().Text;
                string invoicenumber49 = ffinvnumber10.Substring(ffinvnumber10.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber49, "049DEALINTNOSURDD@" + randnumber2, "FDRInvoiceslist2.csv");
                SeleniumSetMethods.WaitOnPage(4);
                InvList("invoicenumber49", invoicenumber49, "stringlist.txt");
                //Issue Invoice -Normal - Ext	No Surcharge	MP	NOREXTMAP

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("External1");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("050NOREXTMAPBOBO@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Console.WriteLine("InvoiceCreated");
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                SendPg.SentOutstandingBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                SendPg.SearchInvoiceSent().SendKeys("050NOREXTMAPBOBO@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(4);
                string ffinvnumber11 = SIVPG1.InvNumber().Text;
                string invoicenumber50 = ffinvnumber11.Substring(ffinvnumber11.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber50, "050NOREXTMAPBOBO@" + randnumber2, "FDRInvoiceslist2.csv");
                InvList("invoicenumber50", invoicenumber50, "stringlist.txt");

                //Issue Invoice -Deal - Int	Surcharge	MP	DEALINTMAP
                SeleniumSetMethods.WaitOnPage(4);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+cdrfdrpayer");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("051DEALINTSURMAPBOBO@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("200");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.NewTotal().SendKeys("200");
                IssueInvoicePg.OfferExpiry().Clear();
                SeleniumSetMethods.WaitOnPage(3);
                IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
                IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");
                IssueInvoicePg.SurchargeCheckbox().Click();
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Console.WriteLine("InvoiceCreated");
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                SendPg.SentOutstandingBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                SendPg.SearchInvoiceSent().SendKeys("051DEALINTSURMAPBOBO@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(4);
                string ffinvnumber12 = SIVPG1.InvNumber().Text;
                string invoicenumber51 = ffinvnumber12.Substring(ffinvnumber12.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber51, "051DEALINTSURMAPBOBO@" + randnumber2, "FDRInvoiceslist2.csv");
                InvList("invoicenumber51", invoicenumber51, "stringlist.txt");
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(4);
                loginPg.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                loginPg.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(2);
                loginPg.UserNameTextBox().SendKeys("manualtestdemob+unverbiller@gmail.com");
                loginPg.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                loginPg.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(2);
                loginPg.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(7);

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("manualtestdemob+unverpayer");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(1);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("052NORUNVERSURCC@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Console.WriteLine("InvoiceCreated");
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                SendPg.SentOutstandingBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                SendPg.SearchInvoiceSent().SendKeys("052NORUNVERSURCC@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(4);
                string ffinvnumber13 = SIVPG1.InvNumber().Text;
                string invoicenumber52 = ffinvnumber13.Substring(ffinvnumber13.IndexOf("Invoice ")).Replace("Invoice ", "");
                FDRInvList(invoicenumber52, "052NORUNVERSURCC@" + randnumber2, "FDRInvoiceslist2.csv");
                InvList("invoicenumber52", invoicenumber52, "stringlist.txt");
                SeleniumSetMethods.WaitOnPage(4);
                HomePg.SignOutBTN().Click();


                SeleniumSetMethods.WaitOnPage(4);
                loginPg.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                loginPg.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(2);
                loginPg.UserNameTextBox().SendKeys("billzydemo+financial-controller@gmail.com");
                loginPg.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                loginPg.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(2);
                loginPg.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(10);

                var invdecset1 = new List<string> { invoicenumber9, invoicenumber10, invoicenumber17, invoicenumber27, invoicenumber28, invoicenumber33 };
                for (int i = invdecset1.Count - 1; i >= 0; i--)
                {
                    IWebElement DeclineButton1 = WebDriver.FindElement(By.XPath("//td[text()=\"" + invdecset1[i] + "\"]/../td/button[text()=\"decline\"]"));
                    SeleniumSetMethods.WaitOnPage(2);
                    DeclineButton1.Click();
                    SeleniumSetMethods.WaitOnPage(5);
                    IAlert alert1 = WebDriver.SwitchTo().Alert();
                    alert1.Accept();
                    SeleniumSetMethods.WaitOnPage(3);
                    alert1.Accept();
                    SeleniumSetMethods.WaitOnPage(3);
                    alert1.Accept();
                    SeleniumSetMethods.WaitOnPage(3);
                }

                SeleniumSetMethods.WaitOnPage(5);
                HomePg.Uploadfactorfox().SendKeys(@"C:\Users\BillzyAdmin\OneDrive - Billzy\BillzyTestSuite\BillzyAutomationTestSuite\bin\Debug\netcoreapp3.0\FDRFactorFox.csv");
                SeleniumSetMethods.WaitOnPage(19);
                IAlert alert2 = WebDriver.SwitchTo().Alert();
                alert2.Accept();
                SeleniumSetMethods.WaitOnPage(5);

                var invset1 = new List<string> { invoicenumber3, invoicenumber4, invoicenumber5, invoicenumber6, invoicenumber7, invoicenumber8, invoicenumber12, invoicenumber14, invoicenumber15, invoicenumber16, invoicenumber21, invoicenumber22, invoicenumber23, invoicenumber24, invoicenumber25, invoicenumber26, invoicenumber30, invoicenumber31, invoicenumber32 };

                for (int i = invset1.Count - 1; i >= 0; i--)
                {
                    IWebElement ApproveButton1 = WebDriver.FindElement(By.XPath("//td[text()=\"" + invset1[i] + "\"]/../td/button[text()=\"approve\"]"));
                    SeleniumSetMethods.WaitOnPage(2);
                    ApproveButton1.Click();
                    SeleniumSetMethods.WaitOnPage(3);
                    HomePg.Cashratesubmit().Click();
                    SeleniumSetMethods.WaitOnPage(5);
                    IAlert alert3 = WebDriver.SwitchTo().Alert();
                    SeleniumSetMethods.WaitOnPage(5);
                    alert3.Accept();
                    SeleniumSetMethods.WaitOnPage(2);
                }

                HomePg.FCLogout().Click();
                SeleniumSetMethods.WaitOnPage(4);

                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                SeleniumSetMethods.WaitOnPage(4);
                //Pay the requested, pre-approved, approved and declined cash invoices

                loginPg.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                loginPg.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(2);
                loginPg.UserNameTextBox().SendKeys("madcowtesting10+cdrfdrpayer@gmail.com");
                loginPg.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                loginPg.PasswordTextBox().SendKeys("Cognito1");
                loginPg.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(10);
                var invcard1 = new List<string> { invoicenumber1, invoicenumber11, invoicenumber9 };
                for (int i = invcard1.Count - 1; i >= 0; i--)
                {
                    Recpg.SearchInvoiceReceived().SendKeys(invcard1[i]);
                    SeleniumSetMethods.WaitOnPage(3);
                    Recpg.SelectInvoiceRow01().Click();
                    SeleniumSetMethods.WaitOnPage(2);
                    Recpg.PayBTNTop().Click();
                    SeleniumSetMethods.WaitOnPage(2);
                    Paynwpg.Row01SelectCard().Click();
                    SeleniumSetMethods.WaitOnPage(3);
                    Paynwpg.CardRow01().Click();
                    SeleniumSetMethods.WaitOnPage(3);
                    Paynwpg.ConfirmPaymentBTN().Click();
                    SeleniumSetMethods.WaitOnPage(2);
                    Paynwpg.DoneBTN().Click();
                    SeleniumSetMethods.WaitOnPage(5);
                }
                var invbank1 = new List<string> { invoicenumber2, invoicenumber4, invoicenumber10 };
                for (int i = invbank1.Count - 1; i >= 0; i--)
                {
                    Recpg.SearchInvoiceReceived().SendKeys(invbank1[i]);
                    SeleniumSetMethods.WaitOnPage(3);
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
                }


                SeleniumSetMethods.WaitOnPage(5);
                HomePg.SignOutBTN().Click();


                //Bobo User marked the invoices as Paid
                //Mark As Paid: 14,15,16,17,18,29,30,31,32,33,34

                WebDriver.Navigate().GoToUrl("https://4impact-billzy-bobo-ui-uat.s3-ap-southeast-2.amazonaws.com/poc.html");

                Bobopg.Username().Click();
                SeleniumSetMethods.WaitOnPage(2);
                Bobopg.Username().SendKeys("madcowbiller+bobo_02@gmail.com");
                Bobopg.Password().Click();
                SeleniumSetMethods.WaitOnPage(2);
                Bobopg.Password().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(2);
                Bobopg.LoginBTN().Click();
                SeleniumSetMethods.WaitOnPage(10);
                Bobopg.UpdateExistingBillzyInvoice().Click();
                SeleniumSetMethods.WaitOnPage(6);
                Bobopg.SelectBusiness().SendKeys("madcowtesting10+cdrfdrbiller");
                SeleniumSetMethods.WaitOnPage(3);

                var invsetMAP1 = new List<string> { invoicenumber13, invoicenumber17, invoicenumber18, invoicenumber29, invoicenumber30, invoicenumber33, invoicenumber34 };
                for (int i = invsetMAP1.Count - 1; i >= 0; i--)
                {

                    Bobopg.InputInvoice().SendKeys(invsetMAP1[i]);
                    SeleniumSetMethods.WaitOnPage(2);
                    Bobopg.SearchBTN().Click();
                    SeleniumSetMethods.WaitOnPage(4);
                    Bobopg.MarkAsPaidEnabled().Click();
                    SeleniumSetMethods.WaitOnPage(4);
                    Bobopg.MAPYes().Click();
                    SeleniumSetMethods.WaitOnPage(4);
                    Bobopg.InputInvoice().Click();
                    SeleniumSetMethods.WaitOnPage(1);
                    Bobopg.InputInvoice().Clear();
                    SeleniumSetMethods.WaitOnPage(1);
                }


                //External Payment
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://accounts.google.com/signin/v2/identifier?service=mail&passive=true&rm=false&continue=https%3A%2F%2Fmail.google.com%2Fmail%2F&ss=1&scc=1&ltmpl=default&ltmplcache=2&emr=1&osid=1&flowName=GlifWebSignIn&flowEntry=ServiceLogin");
                SeleniumSetMethods.WaitOnPage(4);
                gmailpg.Username().Click();
                SeleniumSetMethods.WaitOnPage(2);
                gmailpg.Username().SendKeys("manualtestdemob@gmail.com");
                SeleniumSetMethods.WaitOnPage(2);
                gmailpg.UserNext().Click();
                SeleniumSetMethods.WaitOnPage(4);
                gmailpg.Password().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(2);
                gmailpg.PasswordNext().Click();
                SeleniumSetMethods.WaitOnPage(7);

                var invextpayset1 = new List<string> { "19EXTSURCASHREQCC", "027EXTSURCASHDECCC", "021EXTSURCASHAPPCC" };
                for (int i = invextpayset1.Count - 1; i >= 0; i--)
                {

                    gmailpg.Search().Click();
                    SeleniumSetMethods.WaitOnPage(2);
                    gmailpg.Search().SendKeys(invextpayset1[i] + "@" + randnumber2);
                    SeleniumSetMethods.WaitOnPage(2);
                    SeleniumSetMethods.WaitOnPage(2);
                    gmailpg.SearchOption().Click();
                    SeleniumSetMethods.WaitOnPage(2);
                    gmailpg.SearchButton().Click();
                    SeleniumSetMethods.WaitOnPage(5);
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                    SeleniumSetMethods.WaitOnPage(2);
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                    SeleniumSetMethods.WaitOnPage(2);
                    SeleniumSetMethods.WaitOnPage(2);
                    var tabs = WebDriver.WindowHandles;
                    gmailpg.Verify().Click();
                    SeleniumSetMethods.WaitOnPage(7);
                    WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
                    SeleniumSetMethods.WaitOnPage(2);
                    SeleniumSetMethods.WaitOnPage(2);
                    gmailpg.CardName().SendKeys("Valid");
                    SeleniumSetMethods.WaitOnPage(1);
                    gmailpg.CardNumber().SendKeys("4242424242424242");
                    SeleniumSetMethods.WaitOnPage(1);
                    gmailpg.Expmon().SendKeys("12");
                    SeleniumSetMethods.WaitOnPage(1);
                    gmailpg.ExpYY().SendKeys("25");
                    SeleniumSetMethods.WaitOnPage(1);
                    gmailpg.CVC().SendKeys("089");
                    SeleniumSetMethods.WaitOnPage(1);
                    gmailpg.PAY().Click();
                    SeleniumSetMethods.WaitOnPage(7);
                    string successmsg = gmailpg.Successmsg().Text;
                    SeleniumSetMethods.WaitOnPage(2);
                    Assert.IsTrue(successmsg.Contains("Successful payment"));
                    SeleniumSetMethods.WaitOnPage(2);
                    WebDriver.Close();
                    WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
                    SeleniumSetMethods.WaitOnPage(2);
                    gmailpg.Search().Click();
                    SeleniumSetMethods.WaitOnPage(2);
                    gmailpg.Search().Clear();
                    SeleniumSetMethods.WaitOnPage(2);
                }
                var invextpayset11 = new List<string> { "021EXTSURCASHAPPCC" };
                for (int i = invextpayset11.Count - 1; i >= 0; i--)
                {

                    gmailpg.Search().Click();
                    SeleniumSetMethods.WaitOnPage(2);
                    gmailpg.Search().SendKeys(invextpayset1[i] + "@" + randnumber2);
                    SeleniumSetMethods.WaitOnPage(2);
                    SeleniumSetMethods.WaitOnPage(2);
                    gmailpg.SearchOption().Click();
                    SeleniumSetMethods.WaitOnPage(2);
                    gmailpg.SearchButton().Click();
                    SeleniumSetMethods.WaitOnPage(5);
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                    SeleniumSetMethods.WaitOnPage(2);
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                    SeleniumSetMethods.WaitOnPage(2);
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                    SeleniumSetMethods.WaitOnPage(2);
                    SeleniumSetMethods.WaitOnPage(2);
                    var tabs = WebDriver.WindowHandles;
                    gmailpg.Verify().Click();
                    SeleniumSetMethods.WaitOnPage(7);
                    WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
                    SeleniumSetMethods.WaitOnPage(2);
                    SeleniumSetMethods.WaitOnPage(2);
                    gmailpg.CardName().SendKeys("Valid");
                    SeleniumSetMethods.WaitOnPage(1);
                    gmailpg.CardNumber().SendKeys("4242424242424242");
                    SeleniumSetMethods.WaitOnPage(1);
                    gmailpg.Expmon().SendKeys("12");
                    SeleniumSetMethods.WaitOnPage(1);
                    gmailpg.ExpYY().SendKeys("25");
                    SeleniumSetMethods.WaitOnPage(1);
                    gmailpg.CVC().SendKeys("089");
                    SeleniumSetMethods.WaitOnPage(1);
                    gmailpg.PAY().Click();
                    SeleniumSetMethods.WaitOnPage(7);
                    string successmsg = gmailpg.Successmsg().Text;
                    SeleniumSetMethods.WaitOnPage(2);
                    Assert.IsTrue(successmsg.Contains("Successful payment"));
                    SeleniumSetMethods.WaitOnPage(2);
                    WebDriver.Close();
                    WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
                    SeleniumSetMethods.WaitOnPage(2);
                    gmailpg.Search().Click();
                    SeleniumSetMethods.WaitOnPage(2);
                    gmailpg.Search().Clear();
                    SeleniumSetMethods.WaitOnPage(2);
                }
                gmailpg.profile().Click();
                SeleniumSetMethods.WaitOnPage(4);
                gmailpg.signout().Click();
                SeleniumSetMethods.WaitOnPage(4);


                WebDriver.Navigate().GoToUrl("https://us-east-1.signin.aws.amazon.com/oauth?response_type=code&client_id=arn%3Aaws%3Aiam%3A%3A015428540659%3Auser%2Fhomepage&redirect_uri=https%3A%2F%2Fconsole.aws.amazon.com%2Fconsole%2Fhome%3Fstate%3DhashArgs%2523%26isauthcode%3Dtrue&forceMobileLayout=0&forceMobileApp=0");
                SeleniumSetMethods.WaitOnPage(8);
                awspg.AccountId1().Click();
                SeleniumSetMethods.WaitOnPage(2);
                awspg.AccountId1().SendKeys(awsid);
                SeleniumSetMethods.WaitOnPage(2);
                awspg.Next().Click();
                SeleniumSetMethods.WaitOnPage(5);

                awspg.Username().Click();
                SeleniumSetMethods.WaitOnPage(2);
                awspg.Username().SendKeys(awsuname);
                SeleniumSetMethods.WaitOnPage(2);
                awspg.Password().Click();
                SeleniumSetMethods.WaitOnPage(2);
                awspg.Password().SendKeys(awspassword);
                SeleniumSetMethods.WaitOnPage(4);
                awspg.SignIn().Click();
                SeleniumSetMethods.WaitOnPage(8);
                awspg.SearchBox().Click();
                SeleniumSetMethods.WaitOnPage(4);
                awspg.SearchBox().SendKeys("step functions");
                SeleniumSetMethods.WaitOnPage(4);
                awspg.SelectStepFunction().Click();
                SeleniumSetMethods.WaitOnPage(4);
                awspg.BpayStateMachineUAT().Click();
                SeleniumSetMethods.WaitOnPage(4);
                awspg.StartExecution().Click();
                SeleniumSetMethods.WaitOnPage(4);
                awspg.Script().Click();
                SeleniumSetMethods.WaitOnPage(4);
                awspg.Execute().Click();
                SeleniumSetMethods.WaitOnPage(4);
                awspg.NewExecution().Click();
                SeleniumSetMethods.WaitOnPage(7);
                awspg.EditScriptInsert().Click();
                SeleniumSetMethods.WaitOnPage(4);

                var invextbpayset1 = new List<string> { invoicenumber20, invoicenumber22, invoicenumber28 };
                // var invextbpayset1 = new List<string> { "INV10361988", "INV10361996" };
                for (int i = invextbpayset1.Count - 1; i >= 0; i--)
                {
                    SeleniumSetMethods.WaitOnPage(2);

                    command.CommandText = "Select crn from billzy.invoice where invoice_number in ('" + invextbpayset1[i] + "');";
                    try
                    {
                        conn.Open();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    MySqlDataReader reader00 = command.ExecuteReader();
                    string crnvalue20;
                    while (reader00.Read())
                    {
                        Console.WriteLine(reader00["crn"].ToString());
                    }
                    crnvalue20 = reader00["crn"].ToString();
                    conn.Close();
                    SeleniumSetMethods.WaitOnPage(2);
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();

                    Random rand33 = new Random();
                    DateTime dt33 = new DateTime();
                    string dtString33 = dt33.ToString("MM/dd/yyyy HH:mm:ss");
                    int randnumber33 = rand33.Next();

                    new Actions(WebDriver).SendKeys("{\"crn\": \"" + crnvalue20 + "\",  \"amount\": 110,  \"received_time\": " + randnumber33).Perform();
                    SeleniumSetMethods.WaitOnPage(4);
                    awspg.NewExe().Click();
                    SeleniumSetMethods.WaitOnPage(50);
                    SeleniumSetMethods.WaitOnPage(50);
                    SeleniumSetMethods.WaitOnPage(30);
                    awspg.NewExecution().Click();
                    SeleniumSetMethods.WaitOnPage(7);
                    awspg.EditScriptInsert().Click();
                    SeleniumSetMethods.WaitOnPage(4);

                }

                SeleniumSetMethods.WaitOnPage(5);
                awspg.CancelExecution().Click();
                SeleniumSetMethods.WaitOnPage(5);
                awspg.Profilesignout().Click();
                SeleniumSetMethods.WaitOnPage(2);
                awspg.Signout().Click();
                SeleniumSetMethods.WaitOnPage(2);


                SeleniumSetMethods.WaitOnPage(2);
                WebDriver.Navigate().GoToUrl("http://bamboo.controlplane.billzy.com:443/allPlans.action");
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.Login().Click();
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Username().Click();
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Username().SendKeys(bamboouname);
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Password().Click();
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Password().SendKeys(bamboopassword);
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(6);
                Bampg.DeployMenu().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.AllDeploymentProjects().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BillzyExecuteFD().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.EditUAT().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.UATVariables().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.ActionType().Click();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.ActionTypeclear().Clear();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.ActionTypeclear().SendKeys("CREATE_REPORT");
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.ActionTypeSave().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.DISTType().Click();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.DISTTypeClear().Clear();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.DISTTypeClear().SendKeys("CASH");
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.DISTTypeSave().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.BacktoDeployment().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.ExecuteDeployment().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.StartDeployment().Click();
                SeleniumSetMethods.WaitOnPage(60);
                IWebElement bodyTag190 = WebDriver.FindElement(By.TagName("body"));
                bool status1 = bodyTag190.Text.Contains("SUCCESS");
                SeleniumSetMethods.WaitOnPage(3);
                if (status1 == false)
                {
                    SeleniumSetMethods.WaitOnPage(60);
                }
                SeleniumSetMethods.WaitOnPage(3);
                Assert.IsTrue(status1 == true);
                //SeleniumSetMethods.WaitOnPage(60);
                SeleniumSetMethods.WaitOnPage(30);
                Bampg.Bamboologout().Click();
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Bamboologoutbutton().Click();
                SeleniumSetMethods.WaitOnPage(3);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                loginPg.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                loginPg.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(2);
                loginPg.UserNameTextBox().SendKeys("billzydemo+financial-controller@gmail.com");
                loginPg.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                loginPg.PasswordTextBox().SendKeys("Cognito1");
                loginPg.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(10);
                IWebElement bodyTag03 = WebDriver.FindElement(By.TagName("body"));
                SeleniumSetMethods.WaitOnPage(3);
                bool CDRSTATUS0 = bodyTag03.Text.Contains("CASH DISTRIBUTION STATUS");
                bool CDRSTATUS01 = bodyTag03.Text.Contains("The cash distribution report for " + SentPgDueDate + " has been produced.");
                bool CDRSTATUS02 = bodyTag03.Text.Contains(" of cash APPROVED invoices to distribute. Click below to download the report.");
                bool CDRSTATUS03 = bodyTag03.Text.Contains("The cash distribution report has not been generated for today.");
                SeleniumSetMethods.WaitOnPage(3);
                Assert.IsTrue(CDRSTATUS0 == true && CDRSTATUS01 == true && CDRSTATUS02 == true && CDRSTATUS03 == false);
                SeleniumSetMethods.WaitOnPage(3);
                loginPg.CDRCancelBatch().Click();
                SeleniumSetMethods.WaitOnPage(3);
                IAlert alert02 = WebDriver.SwitchTo().Alert();
                alert02.Accept();
                SeleniumSetMethods.WaitOnPage(3);
                alert02.Accept();
                SeleniumSetMethods.WaitOnPage(3);
                HomePg.FCLogout().Click();
                SeleniumSetMethods.WaitOnPage(3);
                WebDriver.Navigate().GoToUrl("http://bamboo.controlplane.billzy.com:443/allPlans.action");
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.Login().Click();
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Username().Click();
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Username().SendKeys(bamboouname);
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Password().Click();
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Password().SendKeys(bamboopassword);
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(6);
                Bampg.DeployMenu().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.AllDeploymentProjects().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BillzyExecuteFD().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.EditUAT().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.UATVariables().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.ActionType().Click();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.ActionTypeclear().Clear();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.ActionTypeclear().SendKeys("CREATE_REPORT");
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.ActionTypeSave().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.DISTType().Click();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.DISTTypeClear().Clear();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.DISTTypeClear().SendKeys("CASH");
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.DISTTypeSave().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.BacktoDeployment().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.ExecuteDeployment().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.StartDeployment().Click();
                SeleniumSetMethods.WaitOnPage(60);
                IWebElement bodyTag111 = WebDriver.FindElement(By.TagName("body"));
                bool status111 = bodyTag111.Text.Contains("SUCCESS");
                SeleniumSetMethods.WaitOnPage(3);
                if (status111 == false)
                {
                    SeleniumSetMethods.WaitOnPage(60);
                }
                SeleniumSetMethods.WaitOnPage(3);
                Assert.IsTrue(status1 == true);
                //SeleniumSetMethods.WaitOnPage(60);
                SeleniumSetMethods.WaitOnPage(30);
                Bampg.Bamboologout().Click();
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Bamboologoutbutton().Click();
                SeleniumSetMethods.WaitOnPage(3);

                command.CommandText = "select funds_distribution_status from billzy.funds_distribution order by id desc limit 1;";
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                MySqlDataReader reader0 = command.ExecuteReader();
                string funds_distribution_status0;
                while (reader0.Read())
                {
                    Console.WriteLine(reader0["funds_distribution_status"].ToString());
                }
                funds_distribution_status0 = reader0["funds_distribution_status"].ToString();
                conn.Close();
                SeleniumSetMethods.WaitOnPage(2);
                Assert.IsTrue(funds_distribution_status0 == "UNSTARTED");

                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                loginPg.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                loginPg.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(2);
                loginPg.UserNameTextBox().SendKeys("billzydemo+financial-controller@gmail.com");
                loginPg.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                loginPg.PasswordTextBox().SendKeys("Cognito1");
                loginPg.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(10);
                IWebElement bodyTag003 = WebDriver.FindElement(By.TagName("body"));
                SeleniumSetMethods.WaitOnPage(3);
                bool CDRSTATUS00 = bodyTag003.Text.Contains("CASH DISTRIBUTION STATUS");
                bool CDRSTATUS001 = bodyTag003.Text.Contains("The cash distribution report for " + SentPgDueDate + " has been produced.");
                bool CDRSTATUS002 = bodyTag003.Text.Contains(" of cash APPROVED invoices to distribute. Click below to download the report.");
                bool CDRSTATUS003 = bodyTag003.Text.Contains("The cash distribution report has not been generated for today.");
                SeleniumSetMethods.WaitOnPage(3);
                Assert.IsTrue(CDRSTATUS00 == true && CDRSTATUS001 == true && CDRSTATUS002 == true && CDRSTATUS003 == false);
                SeleniumSetMethods.WaitOnPage(3);
                loginPg.CDReoprtLink().Click();
                SeleniumSetMethods.WaitOnPage(5);
                string text = File.ReadAllText(@"C:\Users\BillzyAdmin\OneDrive-Billzy\BillzyTestSuite\BillzyAutomationTestSuite\bin\Debug\netcoreapp3.0\Files" + folderdate + "\\cdr-report.csv");
                SeleniumSetMethods.WaitOnPage(3);
                bool cdrinv1 = text.Contains(invoicenumber1);
                bool cdrinv2 = text.Contains(invoicenumber2);
                bool cdrinv4 = text.Contains(invoicenumber4);
                bool cdrinv9 = text.Contains(invoicenumber9);
                bool cdrinv10 = text.Contains(invoicenumber10);
                bool cdrinv11 = text.Contains(invoicenumber11);
                bool cdrinv13 = text.Contains(invoicenumber13);
                bool cdrinv17 = text.Contains(invoicenumber17);
                bool cdrinv18 = text.Contains(invoicenumber18);
                bool cdrinv19 = text.Contains(invoicenumber19);
                bool cdrinv20 = text.Contains(invoicenumber20);
                bool cdrinv21 = text.Contains(invoicenumber21);
                bool cdrinv22 = text.Contains(invoicenumber22);
                bool cdrinv27 = text.Contains(invoicenumber27);
                bool cdrinv28 = text.Contains(invoicenumber28);
                bool cdrinv29 = text.Contains(invoicenumber29);
                bool cdrinv30 = text.Contains(invoicenumber30);
                bool cdrinv33 = text.Contains(invoicenumber33);
                bool cdrinv34 = text.Contains(invoicenumber34);
                SeleniumSetMethods.WaitOnPage(3);
                Assert.IsTrue(text.Contains("65432111\""));
                Assert.IsTrue(text.Contains(invoicenumber3 + "\",\"$88.00\",\"madcowtesting10+cdrfdrbiller\",\"12345678\",\"madcowtesting10+cdrfdrbiller@gmail.com\",\"receiveAccount\",\"484799\""));
                Assert.IsTrue(text.Contains(invoicenumber12 + "\",\"$88.00\",\"madcowtesting10+cdrfdrbiller\",\"12345678\",\"madcowtesting10+cdrfdrbiller@gmail.com\",\"receiveAccount\",\"484799\""));
                Assert.IsTrue(text.Contains(invoicenumber5 + "\",\"$88.00\",\"madcowtesting10+cdrfdrbiller\",\"12345678\",\"madcowtesting10+cdrfdrbiller@gmail.com\",\"receiveAccount\",\"484799\""));
                Assert.IsTrue(text.Contains(invoicenumber6 + "\",\"$88.00\",\"madcowtesting10+cdrfdrbiller\",\"12345678\",\"madcowtesting10+cdrfdrbiller@gmail.com\",\"receiveAccount\",\"484799\""));
                Assert.IsTrue(text.Contains(invoicenumber7 + "\",\"$88.00\",\"madcowtesting10+cdrfdrbiller\",\"12345678\",\"madcowtesting10+cdrfdrbiller@gmail.com\",\"receiveAccount\",\"484799\""));
                Assert.IsTrue(text.Contains(invoicenumber8 + "\",\"$88.00\",\"madcowtesting10+cdrfdrbiller\",\"12345678\",\"madcowtesting10+cdrfdrbiller@gmail.com\",\"receiveAccount\",\"484799\""));
                Assert.IsTrue(text.Contains(invoicenumber14 + "\",\"$88.00\",\"madcowtesting10+cdrfdrbiller\",\"12345678\",\"madcowtesting10+cdrfdrbiller@gmail.com\",\"receiveAccount\",\"484799\""));
                Assert.IsTrue(text.Contains(invoicenumber15 + "\",\"$88.00\",\"madcowtesting10+cdrfdrbiller\",\"12345678\",\"madcowtesting10+cdrfdrbiller@gmail.com\",\"receiveAccount\",\"484799\""));
                Assert.IsTrue(text.Contains(invoicenumber16 + "\",\"$88.00\",\"madcowtesting10+cdrfdrbiller\",\"12345678\",\"madcowtesting10+cdrfdrbiller@gmail.com\",\"receiveAccount\",\"484799\""));
                Assert.IsTrue(text.Contains(invoicenumber23 + "\",\"$88.00\",\"madcowtesting10+cdrfdrbiller\",\"12345678\",\"madcowtesting10+cdrfdrbiller@gmail.com\",\"receiveAccount\",\"484799\""));
                Assert.IsTrue(text.Contains(invoicenumber24 + "\",\"$88.00\",\"madcowtesting10+cdrfdrbiller\",\"12345678\",\"madcowtesting10+cdrfdrbiller@gmail.com\",\"receiveAccount\",\"484799\""));
                Assert.IsTrue(text.Contains(invoicenumber25 + "\",\"$88.00\",\"madcowtesting10+cdrfdrbiller\",\"12345678\",\"madcowtesting10+cdrfdrbiller@gmail.com\",\"receiveAccount\",\"484799\""));
                Assert.IsTrue(text.Contains(invoicenumber26 + "\",\"$88.00\",\"madcowtesting10+cdrfdrbiller\",\"12345678\",\"madcowtesting10+cdrfdrbiller@gmail.com\",\"receiveAccount\",\"484799\""));
                Assert.IsTrue(text.Contains(invoicenumber31 + "\",\"$88.00\",\"madcowtesting10+cdrfdrbiller\",\"12345678\",\"madcowtesting10+cdrfdrbiller@gmail.com\",\"receiveAccount\",\"484799\""));
                Assert.IsTrue(text.Contains(invoicenumber32 + "\",\"$88.00\",\"madcowtesting10+cdrfdrbiller\",\"12345678\",\"madcowtesting10+cdrfdrbiller@gmail.com\",\"receiveAccount\",\"484799\""));
                Assert.IsTrue(cdrinv1 == false && cdrinv2 == false && cdrinv4 == false && cdrinv9 == false && cdrinv10 == false && cdrinv11 == false && cdrinv13 == false && cdrinv17 == false && cdrinv18 == false && cdrinv19 == false && cdrinv20 == false && cdrinv21 == false && cdrinv22 == false && cdrinv27 == false && cdrinv28 == false && cdrinv29 == false && cdrinv30 == false && cdrinv33 == false && cdrinv34 == false);
                //FC Blocks invoices from the batch file "012INTNOSURCASHPVERDD@"
                SeleniumSetMethods.WaitOnPage(2);
                loginPg.CDRBlockInvField().SendKeys(invoicenumber12);
                SeleniumSetMethods.WaitOnPage(2);
                loginPg.CDRBlockCash().Click();
                SeleniumSetMethods.WaitOnPage(3);
                HomePg.FCLogout().Click();
                SeleniumSetMethods.WaitOnPage(3);

                //Pay the Approved and CDR invoices 13 and 14

                loginPg.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                loginPg.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(2);
                loginPg.UserNameTextBox().SendKeys("madcowtesting10+cdrfdrpayer@gmail.com");
                loginPg.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                loginPg.PasswordTextBox().SendKeys("Cognito1");
                loginPg.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(10);
                var invcard11 = new List<string> { invoicenumber3 };
                for (int i = invcard11.Count - 1; i >= 0; i--)
                {
                    Recpg.SearchInvoiceReceived().SendKeys(invcard11[i]);
                    SeleniumSetMethods.WaitOnPage(3);
                    Recpg.SelectInvoiceRow01().Click();
                    SeleniumSetMethods.WaitOnPage(2);
                    Recpg.PayBTNTop().Click();
                    SeleniumSetMethods.WaitOnPage(2);
                    Paynwpg.Row01SelectCard().Click();
                    SeleniumSetMethods.WaitOnPage(3);
                    Paynwpg.CardRow01().Click();
                    SeleniumSetMethods.WaitOnPage(3);
                    Paynwpg.ConfirmPaymentBTN().Click();
                    SeleniumSetMethods.WaitOnPage(2);
                    Paynwpg.DoneBTN().Click();
                    SeleniumSetMethods.WaitOnPage(5);
                }


                SeleniumSetMethods.WaitOnPage(5);
                HomePg.SignOutBTN().Click();

                //Bobo User marked the invoices as Paid


                WebDriver.Navigate().GoToUrl("https://4impact-billzy-bobo-ui-uat.s3-ap-southeast-2.amazonaws.com/poc.html");

                Bobopg.Username().Click();
                SeleniumSetMethods.WaitOnPage(2);
                Bobopg.Username().SendKeys("madcowbiller+bobo_02@gmail.com");
                Bobopg.Password().Click();
                SeleniumSetMethods.WaitOnPage(2);
                Bobopg.Password().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(2);
                Bobopg.LoginBTN().Click();
                SeleniumSetMethods.WaitOnPage(10);
                Bobopg.UpdateExistingBillzyInvoice().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bobopg.SelectBusiness().SendKeys("madcowtesting10+cdrfdrbiller");
                SeleniumSetMethods.WaitOnPage(3);

                var invsetMAP201 = new List<string> { invoicenumber14 };
                for (int i = invsetMAP201.Count - 1; i >= 0; i--)
                {

                    Bobopg.InputInvoice().SendKeys(invsetMAP201[i]);
                    SeleniumSetMethods.WaitOnPage(2);
                    Bobopg.SearchBTN().Click();
                    SeleniumSetMethods.WaitOnPage(4);
                    Bobopg.MarkAsPaidEnabled().Click();
                    SeleniumSetMethods.WaitOnPage(4);
                    Bobopg.MAPYes().Click();
                    SeleniumSetMethods.WaitOnPage(4);
                    Bobopg.InputInvoice().Click();
                    SeleniumSetMethods.WaitOnPage(1);
                    Bobopg.InputInvoice().Clear();
                    SeleniumSetMethods.WaitOnPage(1);
                }



                SeleniumSetMethods.WaitOnPage(3);
                WebDriver.Navigate().GoToUrl("http://bamboo.controlplane.billzy.com:443/allPlans.action");
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.Login().Click();
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Username().Click();
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Username().SendKeys(bamboouname);
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Password().Click();
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Password().SendKeys(bamboopassword);
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(6);
                Bampg.DeployMenu().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.AllDeploymentProjects().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BillzyExecuteFD().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.EditUAT().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.UATVariables().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.ActionType().Click();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.ActionTypeclear().Clear();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.ActionTypeclear().SendKeys("TRANSFER_REQUEST");
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.ActionTypeSave().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.BacktoDeployment().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.ExecuteDeployment().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.StartDeployment().Click();
                SeleniumSetMethods.WaitOnPage(60);
                IWebElement bodyTag121 = WebDriver.FindElement(By.TagName("body"));
                bool status121 = bodyTag121.Text.Contains("SUCCESS");
                SeleniumSetMethods.WaitOnPage(3);
                if (status121 == false)
                {
                    SeleniumSetMethods.WaitOnPage(60);
                }
                SeleniumSetMethods.WaitOnPage(3);
                Assert.IsTrue(status121 == true);
                //SeleniumSetMethods.WaitOnPage(60);
                SeleniumSetMethods.WaitOnPage(30);
                Bampg.Bamboologout().Click();
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Bamboologoutbutton().Click();
                SeleniumSetMethods.WaitOnPage(3);

                // Verify the CDR status in databse for PENDING
                command.CommandText = "select funds_distribution_status from billzy.funds_distribution order by id desc limit 1;";
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                MySqlDataReader reader = command.ExecuteReader();
                string funds_distribution_status;
                while (reader.Read())
                {
                    Console.WriteLine(reader["funds_distribution_status"].ToString());
                }
                funds_distribution_status = reader["funds_distribution_status"].ToString();
                conn.Close();
                SeleniumSetMethods.WaitOnPage(2);
                Assert.IsTrue(funds_distribution_status == "PENDING");


                // Verify the cash status in databse for BATCHED


                command.CommandText = "select inv.id, ch.cash_state  from billzy.invoice inv left join billzy.cash_history ch on inv.id = ch.invoice_financed_id where invoice_number = '" + invoicenumber15 + "' order by id asc;";
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                MySqlDataReader reader2 = command.ExecuteReader();
                string cashstate;
                while (reader2.Read())
                {
                    Console.WriteLine(reader2["cash_state"].ToString());
                }
                cashstate = reader2["cash_state"].ToString();
                conn.Close();
                SeleniumSetMethods.WaitOnPage(2);
                Assert.IsTrue(cashstate == "BATCHED");
                SeleniumSetMethods.WaitOnPage(5);

                // Verify the Blocked invoice cash status in databse for APPROVED
                command.CommandText = "select inv.id, ch.cash_state  from billzy.invoice inv left join billzy.cash_history ch on inv.id = ch.invoice_financed_id where invoice_number = '" + invoicenumber12 + "' order by id asc;";
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                MySqlDataReader reader3 = command.ExecuteReader();
                string cashstate1;
                while (reader3.Read())
                {
                    Console.WriteLine(reader3["cash_state"].ToString());
                }
                cashstate1 = reader3["cash_state"].ToString();
                conn.Close();
                SeleniumSetMethods.WaitOnPage(2);
                Assert.IsTrue(cashstate1 == "APPROVED");



                //Pay all batched invoices 5,6,15,23,24,31
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                SeleniumSetMethods.WaitOnPage(4);
                //Pay the requested, pre-approved, approved and declined cash invoices

                loginPg.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                loginPg.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(2);
                loginPg.UserNameTextBox().SendKeys("madcowtesting10+cdrfdrpayer@gmail.com");
                loginPg.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                loginPg.PasswordTextBox().SendKeys("Cognito1");
                loginPg.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(10);
                var invcard101 = new List<string> { invoicenumber5 };
                for (int i = invcard101.Count - 1; i >= 0; i--)
                {
                    Recpg.SearchInvoiceReceived().SendKeys(invcard101[i]);
                    SeleniumSetMethods.WaitOnPage(3);
                    Recpg.SelectInvoiceRow01().Click();
                    SeleniumSetMethods.WaitOnPage(2);
                    Recpg.PayBTNTop().Click();
                    SeleniumSetMethods.WaitOnPage(2);
                    Paynwpg.Row01SelectCard().Click();
                    SeleniumSetMethods.WaitOnPage(3);
                    Paynwpg.CardRow01().Click();
                    SeleniumSetMethods.WaitOnPage(3);
                    Paynwpg.ConfirmPaymentBTN().Click();
                    SeleniumSetMethods.WaitOnPage(2);
                    Paynwpg.DoneBTN().Click();
                    SeleniumSetMethods.WaitOnPage(5);
                }
                var invbank101 = new List<string> { invoicenumber6 };
                for (int i = invbank101.Count - 1; i >= 0; i--)
                {
                    Recpg.SearchInvoiceReceived().SendKeys(invbank101[i]);
                    SeleniumSetMethods.WaitOnPage(3);
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
                }


                SeleniumSetMethods.WaitOnPage(5);
                HomePg.SignOutBTN().Click();

                //Bobo User marked the invoices as Paid
                //Mark As Paid: 14,15,16,17,18,29,30,31,32,33,34

                WebDriver.Navigate().GoToUrl("https://4impact-billzy-bobo-ui-uat.s3-ap-southeast-2.amazonaws.com/poc.html");

                Bobopg.Username().Click();
                SeleniumSetMethods.WaitOnPage(2);
                Bobopg.Username().SendKeys("madcowbiller+bobo_02@gmail.com");
                Bobopg.Password().Click();
                SeleniumSetMethods.WaitOnPage(2);
                Bobopg.Password().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(2);
                Bobopg.LoginBTN().Click();
                SeleniumSetMethods.WaitOnPage(10);
                Bobopg.UpdateExistingBillzyInvoice().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bobopg.SelectBusiness().SendKeys("madcowtesting10+cdrfdrbiller");
                SeleniumSetMethods.WaitOnPage(3);

                var invsetMAP101 = new List<string> { invoicenumber15, invoicenumber31 };
                for (int i = invsetMAP101.Count - 1; i >= 0; i--)
                {

                    Bobopg.InputInvoice().SendKeys(invsetMAP101[i]);
                    SeleniumSetMethods.WaitOnPage(2);
                    Bobopg.SearchBTN().Click();
                    SeleniumSetMethods.WaitOnPage(4);
                    Bobopg.MarkAsPaidEnabled().Click();
                    SeleniumSetMethods.WaitOnPage(4);
                    Bobopg.MAPYes().Click();
                    SeleniumSetMethods.WaitOnPage(4);
                    Bobopg.InputInvoice().Click();
                    SeleniumSetMethods.WaitOnPage(1);
                    Bobopg.InputInvoice().Clear();
                    SeleniumSetMethods.WaitOnPage(1);
                }

                //External Payment
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://accounts.google.com/signin/v2/identifier?service=mail&passive=true&rm=false&continue=https%3A%2F%2Fmail.google.com%2Fmail%2F&ss=1&scc=1&ltmpl=default&ltmplcache=2&emr=1&osid=1&flowName=GlifWebSignIn&flowEntry=ServiceLogin");

                gmailpg.Username().Click();
                SeleniumSetMethods.WaitOnPage(2);
                gmailpg.Username().SendKeys("madcowtesting10@gmail.com");
                SeleniumSetMethods.WaitOnPage(2);
                gmailpg.UserNext().Click();
                SeleniumSetMethods.WaitOnPage(4);
                gmailpg.Password().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(2);
                gmailpg.PasswordNext().Click();
                SeleniumSetMethods.WaitOnPage(7);

                var invextpayset101 = new List<string> { "023EXTSURCASHBATCC" };
                for (int i = invextpayset101.Count - 1; i >= 0; i--)
                {

                    gmailpg.Search().Click();
                    SeleniumSetMethods.WaitOnPage(2);
                    gmailpg.Search().SendKeys(invextpayset101[i] + "@" + randnumber2);
                    SeleniumSetMethods.WaitOnPage(2);
                    SeleniumSetMethods.WaitOnPage(2);
                    gmailpg.SearchOption().Click();
                    SeleniumSetMethods.WaitOnPage(2);
                    gmailpg.SearchButton().Click();
                    SeleniumSetMethods.WaitOnPage(5);
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                    SeleniumSetMethods.WaitOnPage(2);
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                    SeleniumSetMethods.WaitOnPage(2);
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                    SeleniumSetMethods.WaitOnPage(2);
                    SeleniumSetMethods.WaitOnPage(2);
                    var tabs = WebDriver.WindowHandles;
                    gmailpg.Verify().Click();
                    SeleniumSetMethods.WaitOnPage(7);
                    WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
                    SeleniumSetMethods.WaitOnPage(2);
                    SeleniumSetMethods.WaitOnPage(2);
                    gmailpg.CardName().SendKeys("Valid");
                    SeleniumSetMethods.WaitOnPage(1);
                    gmailpg.CardNumber().SendKeys("4242424242424242");
                    SeleniumSetMethods.WaitOnPage(1);
                    gmailpg.Expmon().SendKeys("12");
                    SeleniumSetMethods.WaitOnPage(1);
                    gmailpg.ExpYY().SendKeys("25");
                    SeleniumSetMethods.WaitOnPage(1);
                    gmailpg.CVC().SendKeys("089");
                    SeleniumSetMethods.WaitOnPage(1);
                    gmailpg.PAY().Click();
                    SeleniumSetMethods.WaitOnPage(7);
                    string successmsg = gmailpg.Successmsg().Text;
                    SeleniumSetMethods.WaitOnPage(2);
                    Assert.IsTrue(successmsg.Contains("Successful payment"));
                    SeleniumSetMethods.WaitOnPage(2);
                    WebDriver.Close();
                    WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
                    SeleniumSetMethods.WaitOnPage(2);
                    gmailpg.Search().Click();
                    SeleniumSetMethods.WaitOnPage(2);
                    gmailpg.Search().Clear();
                    SeleniumSetMethods.WaitOnPage(2);
                }
                gmailpg.profile().Click();
                SeleniumSetMethods.WaitOnPage(2);
                gmailpg.signout().Click();
                SeleniumSetMethods.WaitOnPage(5);

                WebDriver.Navigate().GoToUrl("https://us-east-1.signin.aws.amazon.com/oauth?response_type=code&client_id=arn%3Aaws%3Aiam%3A%3A015428540659%3Auser%2Fhomepage&redirect_uri=https%3A%2F%2Fconsole.aws.amazon.com%2Fconsole%2Fhome%3Fstate%3DhashArgs%2523%26isauthcode%3Dtrue&forceMobileLayout=0&forceMobileApp=0");
                SeleniumSetMethods.WaitOnPage(8);
                awspg.AccountId1().Click();
                SeleniumSetMethods.WaitOnPage(2);
                awspg.AccountId1().SendKeys(awsid);
                SeleniumSetMethods.WaitOnPage(2);
                awspg.Next().Click();
                SeleniumSetMethods.WaitOnPage(5);

                awspg.Username().Click();
                SeleniumSetMethods.WaitOnPage(2);
                awspg.Username().SendKeys(awsuname);
                SeleniumSetMethods.WaitOnPage(2);
                awspg.Password().Click();
                SeleniumSetMethods.WaitOnPage(2);
                awspg.Password().SendKeys(awspassword);
                SeleniumSetMethods.WaitOnPage(4);
                awspg.SignIn().Click();
                SeleniumSetMethods.WaitOnPage(8);
                awspg.SearchBox().Click();
                SeleniumSetMethods.WaitOnPage(4);
                awspg.SearchBox().SendKeys("step functions");
                SeleniumSetMethods.WaitOnPage(4);
                awspg.SelectStepFunction().Click();
                SeleniumSetMethods.WaitOnPage(4);
                awspg.BpayStateMachineUAT().Click();
                SeleniumSetMethods.WaitOnPage(4);
                awspg.StartExecution().Click();
                SeleniumSetMethods.WaitOnPage(4);
                awspg.Script().Click();
                SeleniumSetMethods.WaitOnPage(4);
                awspg.Execute().Click();
                SeleniumSetMethods.WaitOnPage(4);
                awspg.NewExecution().Click();
                SeleniumSetMethods.WaitOnPage(7);
                awspg.EditScriptInsert().Click();
                SeleniumSetMethods.WaitOnPage(4);

                var invextbpayset121 = new List<string> { invoicenumber24 };
                // var invextbpayset1 = new List<string> { "INV10361988", "INV10361996" };
                for (int i = invextbpayset121.Count - 1; i >= 0; i--)
                {
                    SeleniumSetMethods.WaitOnPage(2);

                    command.CommandText = "Select crn from billzy.invoice where invoice_number in ('" + invextbpayset121[i] + "');";
                    try
                    {
                        conn.Open();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    MySqlDataReader reader00 = command.ExecuteReader();
                    string crnvalue20;
                    while (reader00.Read())
                    {
                        Console.WriteLine(reader00["crn"].ToString());
                    }
                    crnvalue20 = reader00["crn"].ToString();
                    conn.Close();
                    SeleniumSetMethods.WaitOnPage(2);
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();

                    Random rand33 = new Random();
                    DateTime dt33 = new DateTime();
                    string dtString33 = dt33.ToString("MM/dd/yyyy HH:mm:ss");
                    int randnumber33 = rand33.Next();

                    new Actions(WebDriver).SendKeys("{\"crn\": \"" + crnvalue20 + "\",  \"amount\": 110,  \"received_time\": " + randnumber33).Perform();
                    SeleniumSetMethods.WaitOnPage(4);
                    awspg.NewExe().Click();
                    SeleniumSetMethods.WaitOnPage(50);
                    SeleniumSetMethods.WaitOnPage(50);
                    SeleniumSetMethods.WaitOnPage(30);
                    awspg.NewExecution().Click();
                    SeleniumSetMethods.WaitOnPage(7);
                    awspg.EditScriptInsert().Click();
                    SeleniumSetMethods.WaitOnPage(4);

                }

                SeleniumSetMethods.WaitOnPage(5);
                awspg.CancelExecution().Click();
                SeleniumSetMethods.WaitOnPage(5);
                awspg.Profilesignout().Click();
                SeleniumSetMethods.WaitOnPage(2);
                awspg.Signout().Click();
                SeleniumSetMethods.WaitOnPage(6);

                //Execute Capital distribution

                //Execute Upload against Capital Distribution

                SeleniumSetMethods.WaitOnPage(3);
                WebDriver.Navigate().GoToUrl("http://bamboo.controlplane.billzy.com:443/allPlans.action");
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.Login().Click();
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Username().Click();
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Username().SendKeys(bamboouname);
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Password().Click();
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Password().SendKeys(bamboopassword);
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(6);
                Bampg.DeployMenu().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.AllDeploymentProjects().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BillzyBankTransferSendActionMessage().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BTSAUATEdit().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BTSAUATVariables().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BTSAActionType().Click();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSAActionTypeClear().Clear();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSAActionTypeClear().SendKeys("UPLOAD");
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSAActiontypesave().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.BTSATransType().Click();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSATransTypeClear().Clear();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSATransTypeClear().SendKeys("BZYCAPITALDIST");
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSATranstypesave().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.BacktoDeployment().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BTSAExecuteDeployment().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.StartDeployment().Click();
                SeleniumSetMethods.WaitOnPage(60);
                IWebElement bodyTag2 = WebDriver.FindElement(By.TagName("body"));
                bool status2 = bodyTag2.Text.Contains("SUCCESS");
                SeleniumSetMethods.WaitOnPage(3);
                if (status2 == false)
                {
                    SeleniumSetMethods.WaitOnPage(60);
                }
                SeleniumSetMethods.WaitOnPage(3);
                Assert.IsTrue(status2 == true);
                SeleniumSetMethods.WaitOnPage(60);
                SeleniumSetMethods.WaitOnPage(60);
                SeleniumSetMethods.WaitOnPage(60);
                SeleniumSetMethods.WaitOnPage(60);
                Bampg.Bamboologout().Click();
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Bamboologoutbutton().Click();
                SeleniumSetMethods.WaitOnPage(3);

                //Login to ilink and check for deeds and derps

                DateTime duedate2 = DateTime.Today;
                string SentPgDueDate1 = duedate2.ToString("d MMM yyyy");
                string SentPgDueDate11 = duedate2.ToString("dd MMM yyyy");
                WebDriver.Navigate().GoToUrl("https://ilink.support.qvalent.com/LoginView");

                SeleniumSetMethods.WaitOnPage(4);
                ilinkpg.Username().SendKeys(ilinkuname);
                SeleniumSetMethods.WaitOnPage(3);
                ilinkpg.Password().SendKeys(ilinkpassword);
                SeleniumSetMethods.WaitOnPage(3);
                ilinkpg.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(10);
                string derpsfile = ilinkpg.Derpsfile().Text;
                string Derpsfiledate = ilinkpg.Derpsfiledate().Text;
                string Deedsfile = ilinkpg.Deedsfile().Text;
                string Deedsfiledate = ilinkpg.Deedsfiledate().Text;
                SeleniumSetMethods.WaitOnPage(3);
                if (derpsfile.Contains("Incoming") && Derpsfiledate.Contains(SentPgDueDate1) && Deedsfile.Contains("DEEDS File") && Deedsfiledate.Contains(SentPgDueDate1))
                {
                    Assert.IsTrue(derpsfile.Contains("Incoming") && Derpsfiledate.Contains(SentPgDueDate1) && Deedsfile.Contains("DEEDS File") && Deedsfiledate.Contains(SentPgDueDate1));
                }
                else
                {
                    SeleniumSetMethods.WaitOnPage(60);
                    SeleniumSetMethods.WaitOnPage(60);
                    SeleniumSetMethods.WaitOnPage(60);
                }
                string deedsfilename = ilinkpg.Deedsfilename().Text;
                ilinkpg.Deedsfilename().Click();
                SeleniumSetMethods.WaitOnPage(2);
                ilinkpg.Deedsfiledownload().Click();
                SeleniumSetMethods.WaitOnPage(3);
                string deedstext = File.ReadAllText(@"C:\Users\BillzyAdmin\OneDrive-Billzy\BillzyTestSuite\BillzyAutomationTestSuite\bin\Debug\netcoreapp3.0\Files" + folderdate + "\\" + deedsfilename);
                SeleniumSetMethods.WaitOnPage(3);
                bool blockedinv = deedstext.Contains("012INTNOSUR");
                SeleniumSetMethods.WaitOnPage(2);

                bool notpresent1 = deedstext.Contains("003INTSURCASH");
                bool notpresent2 = deedstext.Contains("004INTNOSURC");
                bool notpresent3 = deedstext.Contains("014INTSURCA");
                bool notpresent4 = deedstext.Contains("021EXTSUR");
                bool notpresent5 = deedstext.Contains("022EXTNOSUR");
                bool notpresent6 = deedstext.Contains("030EXTSUR");

                Assert.IsTrue(deedstext.Contains("005INTSURCAS"));
                Assert.IsTrue(deedstext.Contains("006INTNOSURC"));
                Assert.IsTrue(deedstext.Contains("007INTSURCAS"));
                Assert.IsTrue(deedstext.Contains("008INTNOSURC"));
                Assert.IsTrue(deedstext.Contains("015INTSURC"));
                Assert.IsTrue(deedstext.Contains("016INTSUR"));
                Assert.IsTrue(deedstext.Contains("023EXTSUR"));
                Assert.IsTrue(deedstext.Contains("024EXTNO"));
                Assert.IsTrue(deedstext.Contains("025EXTSUR"));
                Assert.IsTrue(deedstext.Contains("026EXTSNO"));
                Assert.IsTrue(deedstext.Contains("031EXTSUR"));
                Assert.IsTrue(deedstext.Contains("032EXTSURCAS"));
                Assert.IsTrue(blockedinv == false && notpresent1 == false && notpresent2 == false && notpresent3 == false && notpresent4 == false && notpresent5 == false && notpresent6 == false);
                Assert.IsTrue(deedstext.Contains("CASHEXTNOSUR"));
                Assert.IsTrue(deedstext.Contains("1484-799 65432111 5000000176"));
                DateTime duedate1111 = DateTime.Today;
                string SentPgDueDate111 = duedate1111.ToString("ddMMyy");
                SeleniumSetMethods.WaitOnPage(3);
                ilinkpg.Dashboard().Click();
                SeleniumSetMethods.WaitOnPage(2);
                string derpsfilename = ilinkpg.Derpsfilename().Text;
                ilinkpg.Derpsfilename().Click();
                SeleniumSetMethods.WaitOnPage(2);
                ilinkpg.Derpsfiledownload().Click();
                SeleniumSetMethods.WaitOnPage(3);
                string derpstext = File.ReadAllText(@"C:\Users\BillzyAdmin\Downloads\" + derpsfilename);
                SeleniumSetMethods.WaitOnPage(3);
                Assert.IsTrue(derpstext.Contains("545473"));
                Assert.IsTrue(derpstext.Contains(SentPgDueDate111 + "034-001519897"));
                Assert.IsTrue(derpstext.Contains("7999-999"));
                SeleniumSetMethods.WaitOnPage(3);
                WebDriver.Navigate().GoToUrl("http://bamboo.controlplane.billzy.com:443/allPlans.action");

                // " DEEDS & BZYCAPITALDIST"

                SeleniumSetMethods.WaitOnPage(4);
                Bampg.Login().Click();
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Username().Click();
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Username().SendKeys(bamboouname);
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Password().Click();
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Password().SendKeys(bamboopassword);
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(6);
                Bampg.DeployMenu().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.AllDeploymentProjects().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BillzyBankTransferSendActionMessage().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BTSAUATEdit().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BTSAUATVariables().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BTSAActionType().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.BTSAActionTypeClear().Clear();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSAActionTypeClear().SendKeys("DEEDS");
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSAActiontypesave().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.BTSATransType().Click();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSATransTypeClear().Clear();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSATransTypeClear().SendKeys("BZYCAPITALDIST");
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSATranstypesave().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.BacktoDeployment().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BTSAExecuteDeployment().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.StartDeployment().Click();
                SeleniumSetMethods.WaitOnPage(60);
                IWebElement bodyTag33 = WebDriver.FindElement(By.TagName("body"));
                bool status3 = bodyTag33.Text.Contains("SUCCESS");
                SeleniumSetMethods.WaitOnPage(3);
                if (status3 == false)
                {
                    SeleniumSetMethods.WaitOnPage(60);
                }
                SeleniumSetMethods.WaitOnPage(3);
                Assert.IsTrue(status3 == true);
                SeleniumSetMethods.WaitOnPage(30);

                // DERPS & BZYCAPITALDIST

                SeleniumSetMethods.WaitOnPage(4);
                Bampg.DeployMenu().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.AllDeploymentProjects().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BillzyBankTransferSendActionMessage().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BTSAUATEdit().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BTSAUATVariables().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BTSAActionType().Click();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSAActionTypeClear().Clear();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSAActionTypeClear().SendKeys("DERPS");
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSAActiontypesave().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.BTSATransType().Click();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSATransTypeClear().Clear();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSATransTypeClear().SendKeys("BZYCAPITALDIST");
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSATranstypesave().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.BacktoDeployment().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BTSAExecuteDeployment().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.StartDeployment().Click();
                SeleniumSetMethods.WaitOnPage(60);
                IWebElement bodyTag4 = WebDriver.FindElement(By.TagName("body"));
                bool status4 = bodyTag4.Text.Contains("SUCCESS");
                SeleniumSetMethods.WaitOnPage(3);
                if (status4 == false)
                {
                    SeleniumSetMethods.WaitOnPage(60);
                }
                SeleniumSetMethods.WaitOnPage(3);
                Assert.IsTrue(status4 == true);
                SeleniumSetMethods.WaitOnPage(30);
                Bampg.Bamboologout().Click();
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Bamboologoutbutton().Click();
                SeleniumSetMethods.WaitOnPage(3);

                //Verify the Derps file disappears

                WebDriver.Navigate().GoToUrl("https://ilink.support.qvalent.com/LoginView");
                SeleniumSetMethods.WaitOnPage(3);
                SeleniumSetMethods.WaitOnPage(4);
                ilinkpg.Username().SendKeys(ilinkuname);
                SeleniumSetMethods.WaitOnPage(3);
                ilinkpg.Password().SendKeys(ilinkpassword);
                SeleniumSetMethods.WaitOnPage(3);
                ilinkpg.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(5);
                string none = ilinkpg.NoFile().Text;
                SeleniumSetMethods.WaitOnPage(3);
                Assert.IsTrue(none.Contains("None"));
                SeleniumSetMethods.WaitOnPage(5);


                // Verify the cash status in databse for FUNDED


                command.CommandText = "select inv.id, ch.cash_state  from billzy.invoice inv left join billzy.cash_history ch on inv.id = ch.invoice_financed_id where invoice_number = '" + invoicenumber5 + "' order by id asc;";
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                MySqlDataReader reader33 = command.ExecuteReader();
                string cashstate33;
                while (reader33.Read())
                {
                    Console.WriteLine(reader33["cash_state"].ToString());
                }
                cashstate33 = reader33["cash_state"].ToString();
                conn.Close();
                SeleniumSetMethods.WaitOnPage(2);
                Assert.IsTrue(cashstate33 == "FUNDED");
                SeleniumSetMethods.WaitOnPage(5);

                string Created12 = DateTime.Now.AddDays(-40).ToString("yyyy-MM-dd HH:mm:ss");
                //string invoicenumber7 = "INV10362200";
                string duedate = DateTime.Now.AddDays(-40).ToString("d/MM/yyyy");
                command.CommandText = "SELECT id FROM billzy.invoice where invoice_number in ('" + invoicenumber7 + "');";
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                MySqlDataReader reader120 = command.ExecuteReader();
                string id;
                while (reader120.Read())
                {
                    Console.WriteLine(reader120["id"].ToString());
                }
                id = reader120["id"].ToString();
                conn.Close();
                SeleniumSetMethods.WaitOnPage(2);
                SeleniumSetMethods.WaitOnPage(5);

                string duedate10 = DateTime.Now.AddDays(-10).ToString("yyyy-MM-dd");
                command.CommandText = "UPDATE `billzy`.`cash_history` SET `created_at` = '" + Created12 + "' WHERE(`invoice_financed_id` = '" + id + "');";
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                MySqlDataReader reader11 = command.ExecuteReader();
                SeleniumSetMethods.WaitOnPage(2);
                conn.Close();
                SeleniumSetMethods.WaitOnPage(2);
                SeleniumSetMethods.WaitOnPage(5);

                //validate the paid timestamp
                command.CommandText = "SELECT invoice_financed_id,created_at FROM billzy.cash_history where invoice_financed_id in  ('" + id + "');";
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                MySqlDataReader reader12 = command.ExecuteReader();
                string created;
                while (reader12.Read())
                {
                    Console.WriteLine(reader12["created_at"].ToString());
                }
                created = reader12["created_at"].ToString();
                conn.Close();
                SeleniumSetMethods.WaitOnPage(2);
                Assert.IsTrue(created.Contains(duedate));
                SeleniumSetMethods.WaitOnPage(5);



                //pay all other invoices 7,8,16,25,26,40,41,42,43,44,45,46,47,48,49,50,51, 12
                //Pay all batched invoices 5,6,15,23,24,31
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                SeleniumSetMethods.WaitOnPage(4);
                //Pay the requested, pre-approved, approved and declined cash invoices

                loginPg.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                loginPg.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(2);
                loginPg.UserNameTextBox().SendKeys("madcowtesting10+cdrfdrpayer@gmail.com");
                loginPg.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                loginPg.PasswordTextBox().SendKeys("Cognito1");
                loginPg.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(10);
                var invcard133 = new List<string> { invoicenumber7, invoicenumber40, invoicenumber41, invoicenumber46, invoicenumber47 };
                for (int i = invcard133.Count - 1; i >= 0; i--)
                {
                    Recpg.SearchInvoiceReceived().SendKeys(invcard133[i]);
                    SeleniumSetMethods.WaitOnPage(5);
                    Recpg.SelectInvoiceRow01().Click();
                    SeleniumSetMethods.WaitOnPage(2);
                    Recpg.PayBTNTop().Click();
                    SeleniumSetMethods.WaitOnPage(2);
                    Paynwpg.Row01SelectCard().Click();
                    SeleniumSetMethods.WaitOnPage(3);
                    Paynwpg.CardRow01().Click();
                    SeleniumSetMethods.WaitOnPage(3);
                    Paynwpg.ConfirmPaymentBTN().Click();
                    SeleniumSetMethods.WaitOnPage(2);
                    Paynwpg.DoneBTN().Click();
                    SeleniumSetMethods.WaitOnPage(5);
                }
                var invbank133 = new List<string> { invoicenumber8, invoicenumber42, invoicenumber43, invoicenumber48, invoicenumber49, invoicenumber12 };
                for (int i = invbank133.Count - 1; i >= 0; i--)
                {
                    Recpg.SearchInvoiceReceived().SendKeys(invbank133[i]);
                    SeleniumSetMethods.WaitOnPage(5);
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
                }


                SeleniumSetMethods.WaitOnPage(5);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(4);
                loginPg.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                loginPg.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(2);
                loginPg.UserNameTextBox().SendKeys("manualtestdemob+unverpayer@gmail.com");
                loginPg.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                loginPg.PasswordTextBox().SendKeys("Cognito1");
                loginPg.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(7);

                Recpg.SearchInvoiceReceived().SendKeys("052NORUNVERSURCC@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(5);
                Recpg.SelectInvoiceRow01().Click();
                SeleniumSetMethods.WaitOnPage(2);
                Recpg.PayBTNTop().Click();
                SeleniumSetMethods.WaitOnPage(2);
                Paynwpg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(3);
                Paynwpg.CardRow01().Click();
                SeleniumSetMethods.WaitOnPage(3);
                Paynwpg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(2);
                Paynwpg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(5);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(3);

                //Bobo User marked the invoices as Paid
                //Mark As Paid: 14,15,16,17,18,29,30,31,32,33,34

                WebDriver.Navigate().GoToUrl("https://4impact-billzy-bobo-ui-uat.s3-ap-southeast-2.amazonaws.com/poc.html");

                Bobopg.Username().Click();
                SeleniumSetMethods.WaitOnPage(2);
                Bobopg.Username().SendKeys("madcowbiller+bobo_02@gmail.com");
                Bobopg.Password().Click();
                SeleniumSetMethods.WaitOnPage(2);
                Bobopg.Password().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(2);
                Bobopg.LoginBTN().Click();
                SeleniumSetMethods.WaitOnPage(10);
                Bobopg.UpdateExistingBillzyInvoice().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bobopg.SelectBusiness().SendKeys("madcowtesting10+cdrfdrbiller");
                SeleniumSetMethods.WaitOnPage(3);

                var invsetMAP301 = new List<string> { invoicenumber16, invoicenumber32, invoicenumber50, invoicenumber51 };
                for (int i = invsetMAP301.Count - 1; i >= 0; i--)
                {

                    Bobopg.InputInvoice().SendKeys(invsetMAP301[i]);
                    SeleniumSetMethods.WaitOnPage(2);
                    Bobopg.SearchBTN().Click();
                    SeleniumSetMethods.WaitOnPage(4);
                    Bobopg.MarkAsPaidEnabled().Click();
                    SeleniumSetMethods.WaitOnPage(4);
                    Bobopg.MAPYes().Click();
                    SeleniumSetMethods.WaitOnPage(4);
                    Bobopg.InputInvoice().Click();
                    SeleniumSetMethods.WaitOnPage(1);
                    Bobopg.InputInvoice().Clear();
                    SeleniumSetMethods.WaitOnPage(1);
                }

                //External Payment
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://accounts.google.com/signin/v2/identifier?service=mail&passive=true&rm=false&continue=https%3A%2F%2Fmail.google.com%2Fmail%2F&ss=1&scc=1&ltmpl=default&ltmplcache=2&emr=1&osid=1&flowName=GlifWebSignIn&flowEntry=ServiceLogin");

                gmailpg.Username().Click();
                SeleniumSetMethods.WaitOnPage(2);
                gmailpg.Username().SendKeys("madcowtesting10@gmail.com");
                SeleniumSetMethods.WaitOnPage(2);
                gmailpg.UserNext().Click();
                SeleniumSetMethods.WaitOnPage(4);
                gmailpg.Password().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(2);
                gmailpg.PasswordNext().Click();
                SeleniumSetMethods.WaitOnPage(7);

                var invextpayset1001 = new List<string> { "025EXTSURCASHFUNCC", "044NOREXTSURCC", "045NOREXTNOSURCC" };
                for (int i = invextpayset1001.Count - 1; i >= 0; i--)
                {

                    gmailpg.Search().Click();
                    SeleniumSetMethods.WaitOnPage(2);
                    gmailpg.Search().SendKeys(invextpayset1001[i] + "@" + randnumber2);
                    SeleniumSetMethods.WaitOnPage(2);
                    SeleniumSetMethods.WaitOnPage(2);
                    gmailpg.SearchOption().Click();
                    SeleniumSetMethods.WaitOnPage(2);
                    gmailpg.SearchButton().Click();
                    SeleniumSetMethods.WaitOnPage(5);
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                    SeleniumSetMethods.WaitOnPage(2);
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                    SeleniumSetMethods.WaitOnPage(2);
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                    SeleniumSetMethods.WaitOnPage(2);
                    SeleniumSetMethods.WaitOnPage(2);
                    var tabs = WebDriver.WindowHandles;
                    gmailpg.Verify().Click();
                    SeleniumSetMethods.WaitOnPage(7);
                    WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
                    SeleniumSetMethods.WaitOnPage(2);
                    SeleniumSetMethods.WaitOnPage(2);
                    gmailpg.CardName().SendKeys("Valid");
                    SeleniumSetMethods.WaitOnPage(1);
                    gmailpg.CardNumber().SendKeys("4242424242424242");
                    SeleniumSetMethods.WaitOnPage(1);
                    gmailpg.Expmon().SendKeys("12");
                    SeleniumSetMethods.WaitOnPage(1);
                    gmailpg.ExpYY().SendKeys("25");
                    SeleniumSetMethods.WaitOnPage(1);
                    gmailpg.CVC().SendKeys("089");
                    SeleniumSetMethods.WaitOnPage(1);
                    gmailpg.PAY().Click();
                    SeleniumSetMethods.WaitOnPage(7);
                    string successmsg = gmailpg.Successmsg().Text;
                    SeleniumSetMethods.WaitOnPage(2);
                    Assert.IsTrue(successmsg.Contains("Successful payment"));
                    SeleniumSetMethods.WaitOnPage(2);
                    WebDriver.Close();
                    WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
                    SeleniumSetMethods.WaitOnPage(2);
                    gmailpg.Search().Click();
                    SeleniumSetMethods.WaitOnPage(2);
                    gmailpg.Search().Clear();
                    SeleniumSetMethods.WaitOnPage(2);
                }
                gmailpg.profile().Click();
                SeleniumSetMethods.WaitOnPage(2);
                gmailpg.signout().Click();
                SeleniumSetMethods.WaitOnPage(5);

                WebDriver.Navigate().GoToUrl("https://us-east-1.signin.aws.amazon.com/oauth?response_type=code&client_id=arn%3Aaws%3Aiam%3A%3A015428540659%3Auser%2Fhomepage&redirect_uri=https%3A%2F%2Fconsole.aws.amazon.com%2Fconsole%2Fhome%3Fstate%3DhashArgs%2523%26isauthcode%3Dtrue&forceMobileLayout=0&forceMobileApp=0");
                SeleniumSetMethods.WaitOnPage(8);
                awspg.AccountId1().Click();
                SeleniumSetMethods.WaitOnPage(2);
                awspg.AccountId1().SendKeys(awsid);
                SeleniumSetMethods.WaitOnPage(2);
                awspg.Next().Click();
                SeleniumSetMethods.WaitOnPage(5);

                awspg.Username().Click();
                SeleniumSetMethods.WaitOnPage(2);
                awspg.Username().SendKeys(awsuname);
                SeleniumSetMethods.WaitOnPage(2);
                awspg.Password().Click();
                SeleniumSetMethods.WaitOnPage(2);
                awspg.Password().SendKeys(awspassword);
                SeleniumSetMethods.WaitOnPage(4);
                awspg.SignIn().Click();
                SeleniumSetMethods.WaitOnPage(8);
                awspg.SearchBox().Click();
                SeleniumSetMethods.WaitOnPage(4);
                awspg.SearchBox().SendKeys("step functions");
                SeleniumSetMethods.WaitOnPage(4);
                awspg.SelectStepFunction().Click();
                SeleniumSetMethods.WaitOnPage(4);
                awspg.BpayStateMachineUAT().Click();
                SeleniumSetMethods.WaitOnPage(4);
                awspg.StartExecution().Click();
                SeleniumSetMethods.WaitOnPage(4);
                awspg.Script().Click();
                SeleniumSetMethods.WaitOnPage(4);
                awspg.Execute().Click();
                SeleniumSetMethods.WaitOnPage(4);
                awspg.NewExecution().Click();
                SeleniumSetMethods.WaitOnPage(7);
                awspg.EditScriptInsert().Click();
                SeleniumSetMethods.WaitOnPage(4);

                var invextbpayset11 = new List<string> { invoicenumber26 };
                // var invextbpayset1 = new List<string> { "INV10361988", "INV10361996" };
                for (int i = invextbpayset11.Count - 1; i >= 0; i--)
                {
                    SeleniumSetMethods.WaitOnPage(2);

                    command.CommandText = "Select crn from billzy.invoice where invoice_number in ('" + invextbpayset11[i] + "');";
                    try
                    {
                        conn.Open();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    MySqlDataReader reader00 = command.ExecuteReader();
                    string crnvalue20;
                    while (reader00.Read())
                    {
                        Console.WriteLine(reader00["crn"].ToString());
                    }
                    crnvalue20 = reader00["crn"].ToString();
                    conn.Close();
                    SeleniumSetMethods.WaitOnPage(2);
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                    new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();

                    Random rand33 = new Random();
                    DateTime dt33 = new DateTime();
                    string dtString33 = dt33.ToString("MM/dd/yyyy HH:mm:ss");
                    int randnumber33 = rand33.Next();

                    new Actions(WebDriver).SendKeys("{\"crn\": \"" + crnvalue20 + "\",  \"amount\": 110,  \"received_time\": " + randnumber33).Perform();
                    SeleniumSetMethods.WaitOnPage(4);
                    awspg.NewExe().Click();
                    SeleniumSetMethods.WaitOnPage(50);
                    SeleniumSetMethods.WaitOnPage(50);
                    SeleniumSetMethods.WaitOnPage(30);
                    awspg.NewExecution().Click();
                    SeleniumSetMethods.WaitOnPage(7);
                    awspg.EditScriptInsert().Click();
                    SeleniumSetMethods.WaitOnPage(4);


                }

                SeleniumSetMethods.WaitOnPage(5);
                awspg.CancelExecution().Click();
                SeleniumSetMethods.WaitOnPage(5);
                awspg.Profilesignout().Click();
                SeleniumSetMethods.WaitOnPage(2);
                awspg.Signout().Click();
                SeleniumSetMethods.WaitOnPage(6);

                SeleniumSetMethods.WaitOnPage(2);
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("http://bamboo.controlplane.billzy.com:443/allPlans.action");
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.Login().Click();
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Username().Click();
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Username().SendKeys(bamboouname);
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Password().Click();
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Password().SendKeys(bamboopassword);
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(6);
                Bampg.DeployMenu().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.AllDeploymentProjects().Click();
                SeleniumSetMethods.WaitOnPage(5);

                // Verify the invoice status in databse for Processing


                command.CommandText = "select invoice_number, status from billzy.invoice where reference in ('" + invoicenumber49 + "');";
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                MySqlDataReader reader4 = command.ExecuteReader();
                string status;
                while (reader4.Read())
                {
                    Console.WriteLine(reader4["status"].ToString());
                }
                status = reader4["status"].ToString();
                conn.Close();
                SeleniumSetMethods.WaitOnPage(2);
                Assert.IsTrue(status == "PROCESSING");
                SeleniumSetMethods.WaitOnPage(5);

                //Move the bank paid invoices to paid from processing through bamboo "UPLOAD & BZYTRUSTXFER"

                Bampg.BillzyBankTransferSendActionMessage().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BTSAUATEdit().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BTSAUATVariables().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BTSAActionType().Click();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSAActionTypeClear().Clear();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSAActionTypeClear().SendKeys("UPLOAD");
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSAActiontypesave().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.BTSATransType().Click();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSATransTypeClear().Clear();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSATransTypeClear().SendKeys("BZYTRUSTXFER");
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSATranstypesave().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.BacktoDeployment().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BTSAExecuteDeployment().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.StartDeployment().Click();
                SeleniumSetMethods.WaitOnPage(60);
                IWebElement bodyTag02 = WebDriver.FindElement(By.TagName("body"));
                bool status02 = bodyTag02.Text.Contains("SUCCESS");
                SeleniumSetMethods.WaitOnPage(3);
                if (status02 == false)
                {
                    SeleniumSetMethods.WaitOnPage(60);
                }
                SeleniumSetMethods.WaitOnPage(3);
                Assert.IsTrue(status02 == true);
                SeleniumSetMethods.WaitOnPage(60);
                SeleniumSetMethods.WaitOnPage(60);
                SeleniumSetMethods.WaitOnPage(60);
                SeleniumSetMethods.WaitOnPage(60);
                Bampg.Bamboologout().Click();
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Bamboologoutbutton().Click();
                SeleniumSetMethods.WaitOnPage(3);

                //Login to ilink and check for deeds and derps

                WebDriver.Navigate().GoToUrl("https://ilink.support.qvalent.com/LoginView");
                SeleniumSetMethods.WaitOnPage(4);
                ilinkpg.Username().SendKeys(ilinkuname);
                SeleniumSetMethods.WaitOnPage(3);
                ilinkpg.Password().SendKeys(ilinkpassword);
                SeleniumSetMethods.WaitOnPage(3);
                ilinkpg.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(10);
                string derpsfile0 = ilinkpg.Derpsfile().Text;
                string Derpsfiledate0 = ilinkpg.Derpsfiledate().Text;
                string Deedsfile0 = ilinkpg.Deedsfile().Text;
                string Deedsfiledate0 = ilinkpg.Deedsfiledate().Text;
                SeleniumSetMethods.WaitOnPage(3);
                if (derpsfile0.Contains("Incoming") && Derpsfiledate0.Contains(SentPgDueDate1) && Deedsfile0.Contains("DEEDS File") && Deedsfiledate0.Contains(SentPgDueDate1))
                {
                    Assert.IsTrue(derpsfile0.Contains("Incoming") && Derpsfiledate0.Contains(SentPgDueDate1) && Deedsfile0.Contains("DEEDS File") && Deedsfiledate0.Contains(SentPgDueDate1));
                }
                else
                {
                    SeleniumSetMethods.WaitOnPage(60);
                    SeleniumSetMethods.WaitOnPage(60);
                    SeleniumSetMethods.WaitOnPage(60);
                }
                SeleniumSetMethods.WaitOnPage(3);

                string deedsfilename1 = ilinkpg.Deedsfilename().Text;
                ilinkpg.Deedsfilename().Click();
                SeleniumSetMethods.WaitOnPage(2);
                ilinkpg.Deedsfiledownload().Click();
                SeleniumSetMethods.WaitOnPage(3);
                string deedstext1 = File.ReadAllText(@"C:\Users\BillzyAdmin\Downloads\" + deedsfilename1);
                SeleniumSetMethods.WaitOnPage(3);
                Assert.IsTrue(deedstext1.Contains("002INTNOSUR"));
                Assert.IsTrue(deedstext1.Contains("004INTNOSU"));
                Assert.IsTrue(deedstext1.Contains("006INTNO"));
                Assert.IsTrue(deedstext1.Contains("008INTNOS"));
                Assert.IsTrue(deedstext1.Contains("010INTNOS"));
                Assert.IsTrue(deedstext1.Contains("012INTNO"));
                Assert.IsTrue(deedstext1.Contains("042NORINT"));
                Assert.IsTrue(deedstext1.Contains("043NORINT"));
                Assert.IsTrue(deedstext1.Contains("048DEALIN"));
                Assert.IsTrue(deedstext1.Contains("049DEALINT"));


                WebDriver.Navigate().GoToUrl("http://bamboo.controlplane.billzy.com:443/allPlans.action");

                // DEEDS & BZYTRUSTXFER
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.Login().Click();
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Username().Click();
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Username().SendKeys(bamboouname);
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Password().Click();
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Password().SendKeys(bamboopassword);
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(3);
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.DeployMenu().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.AllDeploymentProjects().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BillzyBankTransferSendActionMessage().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BTSAUATEdit().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BTSAUATVariables().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BTSAActionType().Click();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSAActionTypeClear().Clear();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSAActionTypeClear().SendKeys("DEEDS");
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSAActiontypesave().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.BTSATransType().Click();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSATransTypeClear().Clear();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSATransTypeClear().SendKeys("BZYTRUSTXFER");
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSATranstypesave().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.BacktoDeployment().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BTSAExecuteDeployment().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.StartDeployment().Click();
                SeleniumSetMethods.WaitOnPage(60);
                IWebElement bodyTag331 = WebDriver.FindElement(By.TagName("body"));
                bool status31 = bodyTag331.Text.Contains("SUCCESS");
                SeleniumSetMethods.WaitOnPage(3);
                if (status31 == false)
                {
                    SeleniumSetMethods.WaitOnPage(60);
                }
                SeleniumSetMethods.WaitOnPage(3);
                Assert.IsTrue(status31 == true);
                SeleniumSetMethods.WaitOnPage(30);
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.DeployMenu().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.AllDeploymentProjects().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BillzyBankTransferSendActionMessage().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BTSAUATEdit().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BTSAUATVariables().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BTSAActionType().Click();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSAActionTypeClear().Clear();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSAActionTypeClear().SendKeys("DERPS");
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSAActiontypesave().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.BTSATransType().Click();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSATransTypeClear().Clear();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSATransTypeClear().SendKeys("BZYTRUSTXFER");
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSATranstypesave().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.BacktoDeployment().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BTSAExecuteDeployment().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.StartDeployment().Click();
                SeleniumSetMethods.WaitOnPage(60);
                IWebElement bodyTag44 = WebDriver.FindElement(By.TagName("body"));
                bool status44 = bodyTag44.Text.Contains("SUCCESS");
                SeleniumSetMethods.WaitOnPage(3);
                if (status44 == false)
                {
                    SeleniumSetMethods.WaitOnPage(60);
                }
                SeleniumSetMethods.WaitOnPage(3);
                Assert.IsTrue(status44 == true);
                SeleniumSetMethods.WaitOnPage(30);
                Bampg.Bamboologout().Click();
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Bamboologoutbutton().Click();
                SeleniumSetMethods.WaitOnPage(3);

                //Verify the Derps file disappears

                WebDriver.Navigate().GoToUrl("https://ilink.support.qvalent.com/LoginView");
                SeleniumSetMethods.WaitOnPage(3);
                SeleniumSetMethods.WaitOnPage(4);
                ilinkpg.Username().SendKeys(ilinkuname);
                SeleniumSetMethods.WaitOnPage(3);
                ilinkpg.Password().SendKeys(ilinkpassword);
                SeleniumSetMethods.WaitOnPage(3);
                ilinkpg.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(5);
                string none1 = ilinkpg.NoFile().Text;
                SeleniumSetMethods.WaitOnPage(3);
                Assert.IsTrue(none1.Contains("None"));
                SeleniumSetMethods.WaitOnPage(3);
                SeleniumSetMethods.WaitOnPage(3);

                // Verify the invoice status in databse for SUCCESSFUL


                command.CommandText = "select invoice_number, status from billzy.invoice where reference in ('" + invoicenumber49 + "');";
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                MySqlDataReader reader55 = command.ExecuteReader();
                string cashstate55;
                while (reader55.Read())
                {
                    Console.WriteLine(reader55["status"].ToString());
                }
                cashstate55 = reader55["status"].ToString();
                conn.Close();
                SeleniumSetMethods.WaitOnPage(2);
                Assert.IsTrue(cashstate55 == "SUCCESSFUL");
                SeleniumSetMethods.WaitOnPage(5);

                //Get the test string data for backdateing

                DateTime duedate11 = DateTime.Today.AddDays(-3);
                string dtString12 = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd HH:mm:ss");
                string dtString120 = DateTime.Now.AddDays(-3).ToString("d/MM/yyyy");
                string dtString121 = duedate11.ToString("yyyy-MM-dd HH:mm:ss");

                SeleniumSetMethods.WaitOnPage(2);
                //command.CommandText = "select id from billzy.invoice where invoice_number in ('" + invoicenumber1 + "','" + invoicenumber3 + "','" + invoicenumber7 + "','" + invoicenumber5 + "','" + invoicenumber11 + "','" + invoicenumber19 + "','" + invoicenumber21 + "','" + invoicenumber23 + "','" + invoicenumber25 + "','" + invoicenumber27 + "','" + invoicenumber40 + "','" + invoicenumber41 + "','" + invoicenumber44 + "','" + invoicenumber45 + "','" + invoicenumber46 + "','" + invoicenumber47 + "'); ";
                command.CommandText = "select id from billzy.invoice where invoice_number in ('" + invoicenumber1 + "','" + invoicenumber3 + "','" + invoicenumber7 + "'); ";
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                MySqlDataReader reader6 = command.ExecuteReader();
                System.Text.StringBuilder numbers = new System.Text.StringBuilder();
                while (reader6.Read())
                {
                    numbers.Append(reader6["id"].ToString());
                    numbers.Append("','");
                }
                Console.WriteLine(numbers);
                conn.Close();


                //Bakdate all the invoice paid timestamp
                command.CommandText = "UPDATE `billzy`.`receivable` SET `paid_timestamp` = '" + dtString12 + "' where invoice_id in ('" + numbers + "');";
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                MySqlDataReader reader7 = command.ExecuteReader();
                SeleniumSetMethods.WaitOnPage(2);
                conn.Close();
                SeleniumSetMethods.WaitOnPage(2);
                SeleniumSetMethods.WaitOnPage(5);

                //validate the paid timestamp
                command.CommandText = "Select paid_timestamp from `billzy`.`receivable` where invoice_id in ('" + numbers + "');";
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                MySqlDataReader reader8 = command.ExecuteReader();
                string receivabledate1;
                while (reader8.Read())
                {
                    Console.WriteLine(reader8["paid_timestamp"].ToString());
                }
                receivabledate1 = reader8["paid_timestamp"].ToString();
                conn.Close();
                SeleniumSetMethods.WaitOnPage(2);
                Assert.IsTrue(receivabledate1.Contains(dtString120));
                SeleniumSetMethods.WaitOnPage(5);

                //Bakdate all the invoice paid timestamp
                command.CommandText = "UPDATE `billzy`.`invoice_amount_submitted` SET `amount_submitted_timestamp` = '" + dtString12 + "', `amount_success_timestamp` = '" + dtString12 + "' WHERE invoice_id in ('" + numbers + "');";
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                MySqlDataReader reader9 = command.ExecuteReader();
                SeleniumSetMethods.WaitOnPage(2);
                conn.Close();
                SeleniumSetMethods.WaitOnPage(2);
                SeleniumSetMethods.WaitOnPage(5);

                //validate the paid timestamp
                command.CommandText = "Select amount_submitted_timestamp from `billzy`.`invoice_amount_submitted` where invoice_id in ('" + numbers + "');";
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                MySqlDataReader reader10 = command.ExecuteReader();
                string receivabledate2;
                while (reader10.Read())
                {
                    Console.WriteLine(reader10["amount_submitted_timestamp"].ToString());
                }
                receivabledate2 = reader10["amount_submitted_timestamp"].ToString();
                conn.Close();
                SeleniumSetMethods.WaitOnPage(2);
                Assert.IsTrue(receivabledate2.Contains(dtString120));
                SeleniumSetMethods.WaitOnPage(5);





                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("http://bamboo.controlplane.billzy.com:443/allPlans.action");

                Bampg.Login().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.Username().SendKeys(bamboouname);
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.Password().SendKeys(bamboopassword);
                SeleniumSetMethods.WaitOnPage(2);
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(6);
                Bampg.DeployMenu().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.AllDeploymentProjects().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BillzyExecuteFD().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.EditUAT().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.UATVariables().Click();
                SeleniumSetMethods.WaitOnPage(5);

                //Generate Funds Distribution Status through bamboo "CREATE_REPORT & FUNDS"

                Bampg.ActionType().Click();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.ActionTypeclear().Clear();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.ActionTypeclear().SendKeys("CREATE_REPORT");
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.ActionTypeSave().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.DISTType().Click();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.DISTTypeClear().Clear();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.DISTTypeClear().SendKeys("FUNDS");
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.DISTTypeSave().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.BacktoDeployment().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.ExecuteDeployment().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.StartDeployment().Click();
                SeleniumSetMethods.WaitOnPage(60);
                IWebElement bodyTag8 = WebDriver.FindElement(By.TagName("body"));

                bool status8 = bodyTag8.Text.Contains("SUCCESS");
                bool status008 = bodyTag8.Text.Contains(": Deployment of Release 21.1.0 to UAT");
                if (status8 == false)
                {
                    SeleniumSetMethods.WaitOnPage(60);
                }
                SeleniumSetMethods.WaitOnPage(3);
                Assert.IsTrue(status8 == true && status008 == true);
                Bampg.Bamboologout().Click();
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Bamboologoutbutton().Click();
                SeleniumSetMethods.WaitOnPage(3);

                //FC Login to verify FDR is generated or not


                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                loginPg.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                loginPg.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(2);
                loginPg.UserNameTextBox().SendKeys("billzydemo+financial-controller@gmail.com");
                loginPg.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                loginPg.PasswordTextBox().SendKeys("Cognito1");
                loginPg.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(10);
                IWebElement bodyTag030 = WebDriver.FindElement(By.TagName("body"));
                bool CDRSTATUS800 = bodyTag030.Text.Contains("STATUS");
                bool CDRSTATUS8010 = bodyTag030.Text.Contains("The funds distribution report for " + SentPgDueDate11 + " has been produced.");
                bool CDRSTATUS8020 = bodyTag030.Text.Contains("of this total are fees. Click below to download the report.");
                bool CDRSTATUS8030 = bodyTag030.Text.Contains("The funds distribution report has not been generated for today.");
                SeleniumSetMethods.WaitOnPage(3);
                Assert.IsTrue(CDRSTATUS800 == true && CDRSTATUS8010 == true && CDRSTATUS8020 == true && CDRSTATUS8030 == false);
                SeleniumSetMethods.WaitOnPage(3);
                loginPg.FDRCancelBatch().Click();
                SeleniumSetMethods.WaitOnPage(3);
                IAlert alert03 = WebDriver.SwitchTo().Alert();
                alert03.Accept();
                SeleniumSetMethods.WaitOnPage(3);
                alert03.Accept();
                SeleniumSetMethods.WaitOnPage(3);
                HomePg.FCLogout().Click();
                SeleniumSetMethods.WaitOnPage(3);
                SeleniumSetMethods.WaitOnPage(2);
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("http://bamboo.controlplane.billzy.com:443/allPlans.action");

                Bampg.Login().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.Username().SendKeys(bamboouname);
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.Password().SendKeys(bamboopassword);
                SeleniumSetMethods.WaitOnPage(2);
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(6);
                Bampg.DeployMenu().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.AllDeploymentProjects().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BillzyExecuteFD().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.EditUAT().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.UATVariables().Click();
                SeleniumSetMethods.WaitOnPage(5);

                //Generate Funds Distribution Status through bamboo "CREATE_REPORT & FUNDS"

                Bampg.ActionType().Click();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.ActionTypeclear().Clear();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.ActionTypeclear().SendKeys("CREATE_REPORT");
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.ActionTypeSave().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.DISTType().Click();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.DISTTypeClear().Clear();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.DISTTypeClear().SendKeys("FUNDS");
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.DISTTypeSave().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.BacktoDeployment().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.ExecuteDeployment().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.StartDeployment().Click();
                SeleniumSetMethods.WaitOnPage(60);
                IWebElement bodyTag18 = WebDriver.FindElement(By.TagName("body"));

                bool status18 = bodyTag18.Text.Contains("SUCCESS");
                bool status1008 = bodyTag18.Text.Contains(": Deployment of Release 21.1.0 to UAT");
                if (status18 == false)
                {
                    SeleniumSetMethods.WaitOnPage(60);
                }
                SeleniumSetMethods.WaitOnPage(3);
                Assert.IsTrue(status18 == true && status1008 == true);
                SeleniumSetMethods.WaitOnPage(60);
                Bampg.Bamboologout().Click();
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Bamboologoutbutton().Click();
                SeleniumSetMethods.WaitOnPage(3);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                loginPg.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                loginPg.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(2);
                loginPg.UserNameTextBox().SendKeys("billzydemo+financial-controller@gmail.com");
                loginPg.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(2);
                loginPg.PasswordTextBox().SendKeys("Cognito1");
                loginPg.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(10);
                loginPg.FDRReportLink().Click();
                SeleniumSetMethods.WaitOnPage(5);



                SeleniumSetMethods.WaitOnPage(5);
                string text00 = File.ReadAllText(@"C:\Users\BillzyAdmin\OneDrive-Billzy\BillzyTestSuite\BillzyAutomationTestSuite\bin\Debug\netcoreapp3.0\Files" + folderdate + "\\fdr-report.csv");
                // string text = File.ReadAllText(@"C:\Users\BillzyAdmin\Desktop\Imp\fdr-report.csv");
                SeleniumSetMethods.WaitOnPage(5);
                bool fdrinv1 = text00.Contains(invoicenumber1 + ",$110.00,madcowtesting10+cdrfdrbiller,12345678,madcowtesting10+cdrfdrbiller@gmail.com,receiveAccount,") && text.Contains(invoicenumber1 + ",$110.00,madcowtesting10+cdrfdrbiller,12345678,madcowtesting10+cdrfdrbiller@gmail.com,receiveAccount,");
                bool fdrinv2 = text00.Contains(invoicenumber2 + ",$110.00,madcowtesting10+cdrfdrbiller,12345678,madcowtesting10+cdrfdrbiller@gmail.com,receiveAccount,");
                bool fdrinv3 = text00.Contains(invoicenumber3 + ",$110.00,madcowtesting10+cdrfdrbiller,12345678,madcowtesting10+cdrfdrbiller@gmail.com,receiveAccount") && text.Contains(invoicenumber3 + ",$1.84,Billzy,1300 BILLZY,contact@billzy.com,Billzy Fees");
                bool fdrinv4 = text00.Contains(invoicenumber4 + ",$110.00,madcowtesting10+cdrfdrbiller,12345678,madcowtesting10+cdrfdrbiller@gmail.com,receiveAccount");
                bool fdrinv5 = text00.Contains(invoicenumber5 + ",$88.00,Billzy Capital,1300 BILLZY,contact@billzy.com,Billzy Capital") && text.Contains(invoicenumber5 + ",$16.50,madcowtesting10+cdrfdrbiller,12345678,madcowtesting10+cdrfdrbiller@gmail.com,receiveAccount") && text.Contains(invoicenumber5 + ",$5.50,Billzy,1300 BILLZY,contact@billzy.com,Billzy Fees") && text.Contains(invoicenumber5 + ",$1.84,Billzy,1300 BILLZY,contact@billzy.com,Billzy Fees");
                bool fdrinv6 = text00.Contains(invoicenumber6 + ",$88.00,Billzy Capital,1300 BILLZY,contact@billzy.com,Billzy Capital") && text.Contains(invoicenumber6 + ",$16.50,madcowtesting10+cdrfdrbiller,12345678,madcowtesting10+cdrfdrbiller@gmail.com,receiveAccount") && text.Contains(invoicenumber6 + ",$5.50,Billzy,1300 BILLZY,contact@billzy.com,Billzy Fees");
                bool fdrinv7 = text00.Contains(invoicenumber7 + ",$88.00,Billzy Capital,1300 BILLZY,contact@billzy.com,Billzy Capital") && text.Contains(invoicenumber7 + ",$14.48,manualtestdemob+cdrfdrbiller,12345678,manualtestdemob+gstfdrbiller@gmail.com,receiveAccount") && text.Contains(invoicenumber7 + ",$5.50,Billzy,1300 BILLZY,contact@billzy.com,Billzy Fees") && text.Contains(invoicenumber7 + ",$2.02,Billzy,1300 BILLZY,contact@billzy.com,Billzy Fees") && text.Contains(invoicenumber7 + ",$1.84,Billzy,1300 BILLZY,contact@billzy.com,Billzy Fees");
                bool fdrinv8 = text00.Contains(invoicenumber8 + ",$88.00,Billzy Capital,1300 BILLZY,contact@billzy.com,Billzy Capital") && text.Contains(invoicenumber8 + ",$16.50,madcowtesting10+cdrfdrbiller,12345678,madcowtesting10+cdrfdrbiller@gmail.com,receiveAccount") && text.Contains(invoicenumber8 + ",$5.50,Billzy,1300 BILLZY,contact@billzy.com,Billzy Fees");
                bool fdrinv9 = text00.Contains(invoicenumber9 + ",$110.00,madcowtesting10+cdrfdrbiller,12345678,madcowtesting10+cdrfdrbiller@gmail.com,receiveAccount") && text.Contains(invoicenumber9 + ",$1.84,Billzy,1300 BILLZY,contact@billzy.com,Billzy Fees");
                bool fdrinv10 = text00.Contains(invoicenumber10 + ",$110.00,madcowtesting10+cdrfdrbiller,12345678,madcowtesting10+cdrfdrbiller@gmail.com,receiveAccount");
                bool fdrinv11 = text00.Contains(invoicenumber11 + ",$110.00,madcowtesting10+cdrfdrbiller,12345678,madcowtesting10+cdrfdrbiller@gmail.com,receiveAccount") && text.Contains(invoicenumber11 + ",$1.84,Billzy,1300 BILLZY,contact@billzy.com,Billzy Fees");
                bool fdrinv12 = text00.Contains(invoicenumber12 + ",$110.00,madcowtesting10+cdrfdrbiller,12345678,madcowtesting10+cdrfdrbiller@gmail.com,receiveAccount");
                bool fdrinv19 = text00.Contains(invoicenumber19 + ",$110.00,madcowtesting10+cdrfdrbiller,12345678,madcowtesting10+cdrfdrbiller@gmail.com,receiveAccount") && text.Contains(invoicenumber19 + ",$1.84,Billzy,1300 BILLZY,contact@billzy.com,Billzy Fees");
                bool fdrinv20 = text00.Contains(invoicenumber20 + ",$110.00,madcowtesting10+cdrfdrbiller,12345678,madcowtesting10+cdrfdrbiller@gmail.com,receiveAccount");
                bool fdrinv21 = text00.Contains(invoicenumber21 + ",$110.00,madcowtesting10+cdrfdrbiller,12345678,madcowtesting10+cdrfdrbiller@gmail.com,receiveAccount") && text.Contains(invoicenumber21 + ",$1.84,Billzy,1300 BILLZY,contact@billzy.com,Billzy Fees");
                bool fdrinv22 = text00.Contains(invoicenumber22 + ",$110.00,madcowtesting10+cdrfdrbiller,12345678,madcowtesting10+cdrfdrbiller@gmail.com,receiveAccount");
                bool fdrinv23 = text00.Contains(invoicenumber23 + ",$88.00,Billzy Capital,1300 BILLZY,contact@billzy.com,Billzy Capital") && text.Contains(invoicenumber23 + ",$16.50,madcowtesting10+cdrfdrbiller,12345678,madcowtesting10+cdrfdrbiller@gmail.com,receiveAccount") && text.Contains(invoicenumber23 + ",$5.50,Billzy,1300 BILLZY,contact@billzy.com,Billzy Fees") && text.Contains(invoicenumber23 + ",$1.84,Billzy,1300 BILLZY,contact@billzy.com,Billzy Fees");
                bool fdrinv24 = text00.Contains(invoicenumber24 + ",$88.00,Billzy Capital,1300 BILLZY,contact@billzy.com,Billzy Capital") && text.Contains(invoicenumber24 + ",$16.50,madcowtesting10+cdrfdrbiller,12345678,madcowtesting10+cdrfdrbiller@gmail.com,receiveAccount") && text.Contains(invoicenumber24 + ",$5.50,Billzy,1300 BILLZY,contact@billzy.com,Billzy Fees");
                bool fdrinv25 = text00.Contains(invoicenumber25 + ",$88.00,Billzy Capital,1300 BILLZY,contact@billzy.com,Billzy Capital") && text.Contains(invoicenumber25 + ",$16.50,madcowtesting10+cdrfdrbiller,12345678,madcowtesting10+cdrfdrbiller@gmail.com,receiveAccount") && text.Contains(invoicenumber25 + ",$5.50,Billzy,1300 BILLZY,contact@billzy.com,Billzy Fees");
                bool fdrinv26 = text00.Contains(invoicenumber26 + ",$88.00,Billzy Capital,1300 BILLZY,contact@billzy.com,Billzy Capital") && text.Contains(invoicenumber26 + ",$16.50,madcowtesting10+cdrfdrbiller,12345678,madcowtesting10+cdrfdrbiller@gmail.com,receiveAccount") && text.Contains(invoicenumber26 + ",$5.50,Billzy,1300 BILLZY,contact@billzy.com,Billzy Fees");
                bool fdrinv27 = text00.Contains(invoicenumber27 + ",$110.00,madcowtesting10+cdrfdrbiller,12345678,madcowtesting10+cdrfdrbiller@gmail.com,receiveAccount") && text.Contains(invoicenumber27 + ",$1.84,Billzy,1300 BILLZY,contact@billzy.com,Billzy Fees");
                bool fdrinv28 = text00.Contains(invoicenumber28 + ",$110.00,madcowtesting10+cdrfdrbiller,12345678,madcowtesting10+cdrfdrbiller@gmail.com,receiveAccount");
                bool fdrinv40 = text00.Contains(invoicenumber40 + ",$220.00,madcowtesting10+cdrfdrbiller,12345678,madcowtesting10+cdrfdrbiller@gmail.com,receiveAccount") && text.Contains(invoicenumber40 + ",$3.67,Billzy,1300 BILLZY,contact@billzy.com,Billzy Fees");
                bool fdrinv41 = text00.Contains(invoicenumber41 + ",$108.16,madcowtesting10+cdrfdrbiller,12345678,madcowtesting10+cdrfdrbiller@gmail.com,receiveAccount") && text.Contains(invoicenumber41 + ",$1.84,Billzy,1300 BILLZY,contact@billzy.com,Billzy Fees");
                bool fdrinv42 = text00.Contains(invoicenumber42 + ",$66.00,madcowtesting10+cdrfdrbiller,12345678,madcowtesting10+cdrfdrbiller@gmail.com,receiveAccount");
                bool fdrinv43 = text00.Contains(invoicenumber43 + ",$55.00,madcowtesting10+cdrfdrbiller,12345678,madcowtesting10+cdrfdrbiller@gmail.com,receiveAccount");
                bool fdrinv44 = text00.Contains(invoicenumber44 + ",$220.00,madcowtesting10+cdrfdrbiller,12345678,madcowtesting10+cdrfdrbiller@gmail.com,receiveAccount") && text.Contains(invoicenumber44 + ",$3.67,Billzy,1300 BILLZY,contact@billzy.com,Billzy Fees");
                bool fdrinv45 = text00.Contains(invoicenumber45 + ",$108.16,madcowtesting10+cdrfdrbiller,12345678,madcowtesting10+cdrfdrbiller@gmail.com,receiveAccount") && text.Contains(invoicenumber45 + ",$1.84,Billzy,1300 BILLZY,contact@billzy.com,Billzy Fees");
                bool fdrinv46 = text00.Contains(invoicenumber46 + ",$60.00,madcowtesting10+cdrfdrbiller,12345678,madcowtesting10+cdrfdrbiller@gmail.com,receiveAccount") && text.Contains(invoicenumber46 + ",$1.00,Billzy,1300 BILLZY,contact@billzy.com,Billzy Fees");
                bool fdrinv47 = text00.Contains(invoicenumber47 + ",$49.16,madcowtesting10+cdrfdrbiller,12345678,madcowtesting10+cdrfdrbiller@gmail.com,receiveAccount") && text.Contains(invoicenumber47 + ",$0.84,Billzy,1300 BILLZY,contact@billzy.com,Billzy Fees");
                bool fdrinv48 = text00.Contains(invoicenumber48 + ",$200.00,madcowtesting10+cdrfdrbiller,12345678,madcowtesting10+cdrfdrbiller@gmail.com,receiveAccount");
                bool fdrinv49 = text00.Contains(invoicenumber49 + ",$100.00,madcowtesting10+cdrfdrbiller,12345678,madcowtesting10+cdrfdrbiller@gmail.com,receiveAccount");
                bool fdrinv13 = text00.Contains(invoicenumber13);
                bool fdrinv14 = text00.Contains(invoicenumber14);
                bool fdrinv15 = text00.Contains(invoicenumber15);
                bool fdrinv16 = text00.Contains(invoicenumber16);
                bool fdrinv17 = text00.Contains(invoicenumber17);
                bool fdrinv18 = text00.Contains(invoicenumber18);
                bool fdrinv29 = text00.Contains(invoicenumber29);
                bool fdrinv30 = text00.Contains(invoicenumber30);
                bool fdrinv31 = text00.Contains(invoicenumber31);
                bool fdrinv32 = text00.Contains(invoicenumber32);
                bool fdrinv33 = text00.Contains(invoicenumber33);
                bool fdrinv34 = text00.Contains(invoicenumber34);
                bool fdrinv50 = text00.Contains(invoicenumber50);
                bool fdrinv51 = text00.Contains(invoicenumber51);
                bool fdrinv52 = text00.Contains(invoicenumber52);


                Assert.IsTrue(fdrinv1 == true && fdrinv2 == true && fdrinv3 == true && fdrinv4 == true && fdrinv5 == true && fdrinv6 == true && fdrinv7 == true && fdrinv8 == true && fdrinv9 == true && fdrinv10 == true && fdrinv11 == true && fdrinv12 == true && fdrinv13 == false && fdrinv14 == false && fdrinv15 == false && fdrinv16 == false && fdrinv17 == false && fdrinv18 == false && fdrinv19 == true && fdrinv20 == true);
                Assert.IsTrue(fdrinv21 == true && fdrinv22 == true && fdrinv23 == true && fdrinv24 == true && fdrinv25 == true && fdrinv26 == true && fdrinv27 == true && fdrinv28 == true && fdrinv29 == false && fdrinv30 == false && fdrinv31 == false && fdrinv32 == false && fdrinv33 == false && fdrinv34 == false && fdrinv40 == true);
                Assert.IsTrue(fdrinv41 == true && fdrinv42 == true && fdrinv43 == true && fdrinv44 == true && fdrinv45 == true && fdrinv46 == true && fdrinv47 == true && fdrinv48 == true && fdrinv49 == true && fdrinv50 == false && fdrinv51 == false && fdrinv52 == false);
                //FC Blocks invoices from the batch file "012INTNOSURCASHPVERDD@"
                SeleniumSetMethods.WaitOnPage(2);

                loginPg.FDRBlockInv().Click();
                SeleniumSetMethods.WaitOnPage(2);
                loginPg.FDRBlockInv().SendKeys("invoicenumber1");
                SeleniumSetMethods.WaitOnPage(2);
                loginPg.FDRBlockInvbutton().Click();
                SeleniumSetMethods.WaitOnPage(2);
                IAlert alert12 = WebDriver.SwitchTo().Alert();
                alert12.Accept();
                SeleniumSetMethods.WaitOnPage(3);
                alert12.Accept();
                SeleniumSetMethods.WaitOnPage(3);
                HomePg.FCLogout().Click();
                SeleniumSetMethods.WaitOnPage(3);
                SeleniumSetMethods.WaitOnPage(2);

                // Verify the FDR status in databse for UNSTARTED
                command.CommandText = "select funds_distribution_status from billzy.funds_distribution order by id desc limit 1;";
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                MySqlDataReader readerfdr1 = command.ExecuteReader();
                string funds_distribution_status1;
                while (readerfdr1.Read())
                {
                    Console.WriteLine(readerfdr1["funds_distribution_status"].ToString());
                }
                funds_distribution_status1 = readerfdr1["funds_distribution_status"].ToString();
                conn.Close();
                SeleniumSetMethods.WaitOnPage(2);
                Assert.IsTrue(funds_distribution_status1 == "UNSTARTED");

                WebDriver.Navigate().GoToUrl("http://bamboo.controlplane.billzy.com:443/allPlans.action");

                Bampg.Login().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.Username().SendKeys(bamboouname);
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.Password().SendKeys(bamboopassword);
                SeleniumSetMethods.WaitOnPage(2);
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(6);
                Bampg.DeployMenu().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.AllDeploymentProjects().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BillzyExecuteFD().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.EditUAT().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.UATVariables().Click();
                SeleniumSetMethods.WaitOnPage(5);

                //Generate Funds Distribution Status through bamboo "CREATE_REPORT & FUNDS"

                Bampg.ActionType().Click();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.ActionTypeclear().Clear();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.ActionTypeclear().SendKeys("TRANSFER_REQUEST");
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.ActionTypeSave().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.BacktoDeployment().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.ExecuteDeployment().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.StartDeployment().Click();
                SeleniumSetMethods.WaitOnPage(60);
                IWebElement bodyTag118 = WebDriver.FindElement(By.TagName("body"));

                bool status118 = bodyTag118.Text.Contains("SUCCESS");
                bool status11008 = bodyTag118.Text.Contains(": Deployment of Release 21.1.0 to UAT");
                if (status118 == false)
                {
                    SeleniumSetMethods.WaitOnPage(60);
                }
                SeleniumSetMethods.WaitOnPage(3);
                Assert.IsTrue(status118 == true && status11008 == true);
                Bampg.Bamboologout().Click();
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Bamboologoutbutton().Click();
                SeleniumSetMethods.WaitOnPage(3);

                // Verify the FDR status in databse for UNSTARTED
                command.CommandText = "select funds_distribution_status from billzy.funds_distribution order by id desc limit 1;";
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                MySqlDataReader readerfdr2 = command.ExecuteReader();

                while (readerfdr2.Read())
                {
                    Console.WriteLine(readerfdr2["funds_distribution_status"].ToString());
                }
                funds_distribution_status = readerfdr2["funds_distribution_status"].ToString();
                conn.Close();
                SeleniumSetMethods.WaitOnPage(2);
                Assert.IsTrue(funds_distribution_status == "PENDING");

                WebDriver.Navigate().GoToUrl("http://bamboo.controlplane.billzy.com:443/allPlans.action");

                // UPLOAD & BZYTRUSTDIST

                SeleniumSetMethods.WaitOnPage(4);
                Bampg.Login().Click();
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Username().Click();
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Username().SendKeys(bamboouname);
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Password().Click();
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Password().SendKeys(bamboopassword);
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(6);
                Bampg.DeployMenu().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.AllDeploymentProjects().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BillzyBankTransferSendActionMessage().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BTSAUATEdit().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BTSAUATVariables().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BTSAActionType().Click();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSAActionTypeClear().Clear();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSAActionTypeClear().SendKeys("UPLOAD");
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSAActiontypesave().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.BTSATransType().Click();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSATransTypeClear().Clear();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSATransTypeClear().SendKeys("BZYTRUSTDIST");
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSATranstypesave().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.BacktoDeployment().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BTSAExecuteDeployment().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.StartDeployment().Click();
                SeleniumSetMethods.WaitOnPage(60);
                IWebElement bodyTag002 = WebDriver.FindElement(By.TagName("body"));
                bool status002 = bodyTag002.Text.Contains("SUCCESS");
                SeleniumSetMethods.WaitOnPage(3);
                if (status002 == false)
                {
                    SeleniumSetMethods.WaitOnPage(60);
                }
                SeleniumSetMethods.WaitOnPage(3);
                Assert.IsTrue(status002 == true);
                SeleniumSetMethods.WaitOnPage(60);
                SeleniumSetMethods.WaitOnPage(60);
                SeleniumSetMethods.WaitOnPage(60);
                SeleniumSetMethods.WaitOnPage(60);
                Bampg.Bamboologout().Click();
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Bamboologoutbutton().Click();
                SeleniumSetMethods.WaitOnPage(3);

                //Login to ilink and check for deeds and derps


                WebDriver.Navigate().GoToUrl("https://ilink.support.qvalent.com/LoginView");
                SeleniumSetMethods.WaitOnPage(4);
                ilinkpg.Username().SendKeys(ilinkuname);
                SeleniumSetMethods.WaitOnPage(3);
                ilinkpg.Password().SendKeys(ilinkpassword);
                SeleniumSetMethods.WaitOnPage(3);
                ilinkpg.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(10);
                string derpsfile000 = ilinkpg.Derpsfile().Text;
                string Derpsfiledate000 = ilinkpg.Derpsfiledate().Text;
                string Deedsfile000 = ilinkpg.Deedsfile().Text;
                string Deedsfiledate000 = ilinkpg.Deedsfiledate().Text;
                SeleniumSetMethods.WaitOnPage(3);
                if (derpsfile000.Contains("Incoming") && Derpsfiledate000.Contains(SentPgDueDate1) && Deedsfile000.Contains("DEEDS File") && Deedsfiledate000.Contains(SentPgDueDate1))
                {
                    Assert.IsTrue(derpsfile000.Contains("Incoming") && Derpsfiledate000.Contains(SentPgDueDate1) && Deedsfile000.Contains("DEEDS File") && Deedsfiledate000.Contains(SentPgDueDate1));
                }
                else
                {
                    SeleniumSetMethods.WaitOnPage(60);
                    SeleniumSetMethods.WaitOnPage(60);
                    SeleniumSetMethods.WaitOnPage(60);
                }

                string deedsfilename2 = ilinkpg.Deedsfilename().Text;
                ilinkpg.Deedsfilename().Click();
                SeleniumSetMethods.WaitOnPage(2);
                ilinkpg.Deedsfiledownload().Click();
                SeleniumSetMethods.WaitOnPage(3);
                string deedstext12 = File.ReadAllText(@"C:\Users\BillzyAdmin\OneDrive-Billzy\BillzyTestSuite\BillzyAutomationTestSuite\bin\Debug\netcoreapp3.0\Files" + folderdate + "\\" + deedsfilename2);
                SeleniumSetMethods.WaitOnPage(3);

                SeleniumSetMethods.WaitOnPage(2);

                bool present1 = deedstext12.Contains("002INTNOS");
                bool present2 = deedstext12.Contains("003INTSUR");
                bool present3 = deedstext12.Contains("004INTNOS");
                bool present4 = deedstext12.Contains("005INTSUR");
                bool present5 = deedstext12.Contains("006INTNOS");
                bool present6 = deedstext12.Contains("007INTSUR");
                bool present7 = deedstext12.Contains("008INTNOS");
                bool present8 = deedstext12.Contains("009INTSUR");
                bool present9 = deedstext12.Contains("010INTNOS");
                bool present10 = deedstext12.Contains("011INTSUR");
                bool present11 = deedstext12.Contains("012INTNOS");
                bool present12 = deedstext12.Contains("019EXTSUR");
                bool present13 = deedstext12.Contains("020EXTNOS");
                bool present14 = deedstext12.Contains("021EXTSUR");
                bool present15 = deedstext12.Contains("022EXTNOS");
                bool present16 = deedstext12.Contains("023EXTSUR");
                bool present17 = deedstext12.Contains("024EXTNOS");
                bool present18 = deedstext12.Contains("025EXTSUR");
                bool present19 = deedstext12.Contains("026EXTSNO");
                bool present20 = deedstext12.Contains("027EXTSUR");
                bool present21 = deedstext12.Contains("028EXTNOS");
                bool present22 = deedstext12.Contains("040NORINT");
                bool present23 = deedstext12.Contains("041NORINT");
                bool present24 = deedstext12.Contains("042NORINT");
                bool present25 = deedstext1.Contains("043NORINT");
                bool present26 = deedstext12.Contains("044NOREXT");
                bool present27 = deedstext12.Contains("045NOREXT");
                bool present28 = deedstext12.Contains("046DEALIN");
                bool present29 = deedstext12.Contains("047DEALIN");
                bool present30 = deedstext12.Contains("048DEALIN");
                bool present31 = deedstext12.Contains("049DEALIN");

                bool notpresent101 = deedstext12.Contains("001INTSUR");
                bool notpresent102 = deedstext12.Contains("013INTSUR");
                bool notpresent103 = deedstext12.Contains("014INTSUR");
                bool notpresent104 = deedstext12.Contains("015INTSUR");
                bool notpresent105 = deedstext12.Contains("016INTSUR");
                bool notpresent106 = deedstext12.Contains("017INTSUR");
                bool notpresent7 = deedstext12.Contains("018INTSUR");
                bool notpresent8 = deedstext12.Contains("029EXTSUR");
                bool notpresent9 = deedstext12.Contains("030EXTSUR");
                bool notpresent10 = deedstext12.Contains("031EXTSUR");
                bool notpresent11 = deedstext12.Contains("032EXTSUR");
                bool notpresent12 = deedstext12.Contains("033EXTSUR");
                bool notpresent13 = deedstext12.Contains("034EXTSUR");
                bool notpresent14 = deedstext12.Contains("050NOREXT");
                bool notpresent15 = deedstext12.Contains("051DEALIN");
                bool notpresent16 = deedstext12.Contains("052NORUNV");
                SeleniumSetMethods.WaitOnPage(3);
                Assert.IsTrue(notpresent101 == false && notpresent102 == false && notpresent103 == false && notpresent104 == false && notpresent105 == false && notpresent106 == false && notpresent7 == false && notpresent8 == false && notpresent9 == false && notpresent10 == false && notpresent11 == false && notpresent12 == false && notpresent13 == false && notpresent14 == false && notpresent15 == false && notpresent16 == false);
                Assert.IsTrue(present1 == true && present2 == true && present3 == true && present4 == true && present5 == true && present6 == true && present7 == true && present8 == true && present9 == true && present10 == true);
                Assert.IsTrue(present11 == true && present12 == true && present13 == true && present14 == true && present15 == true && present16 == true && present17 == true && present18 == true && present19 == true && present20 == true);
                Assert.IsTrue(present21 == true && present22 == true && present23 == true && present24 == true && present25 == true && present26 == true && present27 == true && present28 == true && present29 == true && present30 == true);
                Assert.IsTrue(present31 == true);
                Assert.IsTrue(deedstext.Contains("CASHEXTNOSUR"));
                Assert.IsTrue(deedstext.Contains("1484-799 65432111 5000000176"));
                DateTime duedate1110 = DateTime.Today;
                string SentPgDueDate1111 = duedate1111.ToString("ddMMyy");
                SeleniumSetMethods.WaitOnPage(3);
                ilinkpg.Dashboard().Click();
                SeleniumSetMethods.WaitOnPage(2);
                string derpsfilename11 = ilinkpg.Derpsfilename().Text;
                ilinkpg.Derpsfilename().Click();
                SeleniumSetMethods.WaitOnPage(2);
                ilinkpg.Derpsfiledownload().Click();
                SeleniumSetMethods.WaitOnPage(3);
                string derpstext11 = File.ReadAllText(@"C:\Users\BillzyAdmin\Downloads\" + derpsfilename11);
                SeleniumSetMethods.WaitOnPage(3);
                Assert.IsTrue(derpstext11.Contains("545473"));
                Assert.IsTrue(derpstext11.Contains(SentPgDueDate1111 + "034-001519897"));
                Assert.IsTrue(derpstext11.Contains("7999-999"));
                SeleniumSetMethods.WaitOnPage(3);
                SeleniumSetMethods.WaitOnPage(3);
                WebDriver.Navigate().GoToUrl("http://bamboo.controlplane.billzy.com:443/allPlans.action");

                // DEEDS & BZYTRUSTDIST
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.Login().Click();
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Username().Click();
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Username().SendKeys(bamboouname);
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Password().Click();
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Password().SendKeys(bamboopassword);
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(3);
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.DeployMenu().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.AllDeploymentProjects().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BillzyBankTransferSendActionMessage().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BTSAUATEdit().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BTSAUATVariables().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BTSAActionType().Click();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSAActionTypeClear().Clear();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSAActionTypeClear().SendKeys("DEEDS");
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSAActiontypesave().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.BTSATransType().Click();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSATransTypeClear().Clear();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSATransTypeClear().SendKeys("BZYTRUSTDIST");
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSATranstypesave().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.BacktoDeployment().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BTSAExecuteDeployment().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.StartDeployment().Click();
                SeleniumSetMethods.WaitOnPage(60);
                IWebElement bodyTag332 = WebDriver.FindElement(By.TagName("body"));
                bool status333 = bodyTag332.Text.Contains("SUCCESS");
                SeleniumSetMethods.WaitOnPage(3);
                if (status333 == false)
                {
                    SeleniumSetMethods.WaitOnPage(60);
                }
                SeleniumSetMethods.WaitOnPage(3);
                Assert.IsTrue(status333 == true);
                SeleniumSetMethods.WaitOnPage(60);

                // DERPS & BZYTRUSTDIST

                SeleniumSetMethods.WaitOnPage(4);
                Bampg.DeployMenu().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.AllDeploymentProjects().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BillzyBankTransferSendActionMessage().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BTSAUATEdit().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BTSAUATVariables().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BTSAActionType().Click();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSAActionTypeClear().Clear();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSAActionTypeClear().SendKeys("DERPS");
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSAActiontypesave().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.BTSATransType().Click();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSATransTypeClear().Clear();
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSATransTypeClear().SendKeys("BZYTRUSTDIST");
                SeleniumSetMethods.WaitOnPage(2);
                Bampg.BTSATranstypesave().Click();
                SeleniumSetMethods.WaitOnPage(4);
                Bampg.BacktoDeployment().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.BTSAExecuteDeployment().Click();
                SeleniumSetMethods.WaitOnPage(5);
                Bampg.StartDeployment().Click();
                SeleniumSetMethods.WaitOnPage(60);
                IWebElement bodyTag104 = WebDriver.FindElement(By.TagName("body"));
                bool status104 = bodyTag104.Text.Contains("SUCCESS");
                SeleniumSetMethods.WaitOnPage(3);
                if (status104 == false)
                {
                    SeleniumSetMethods.WaitOnPage(60);
                }
                SeleniumSetMethods.WaitOnPage(3);
                Assert.IsTrue(status104 == true);
                SeleniumSetMethods.WaitOnPage(60);
                Bampg.Bamboologout().Click();
                SeleniumSetMethods.WaitOnPage(3);
                Bampg.Bamboologoutbutton().Click();
                SeleniumSetMethods.WaitOnPage(3);

                //Verify the Derps file disappears

                WebDriver.Navigate().GoToUrl("https://ilink.support.qvalent.com/LoginView");
                SeleniumSetMethods.WaitOnPage(3);
                SeleniumSetMethods.WaitOnPage(4);
                ilinkpg.Username().SendKeys(ilinkuname);
                SeleniumSetMethods.WaitOnPage(3);
                ilinkpg.Password().SendKeys(ilinkpassword);
                SeleniumSetMethods.WaitOnPage(3);
                ilinkpg.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(5);
                string none2 = ilinkpg.NoFile().Text;
                SeleniumSetMethods.WaitOnPage(3);
                Assert.IsTrue(none2.Contains("None"));
                SeleniumSetMethods.WaitOnPage(3);
                SeleniumSetMethods.WaitOnPage(3);

                // Verify the FDR status in databse for COMPLETE
                command.CommandText = "select funds_distribution_status from billzy.funds_distribution order by id desc limit 1;";
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                MySqlDataReader readerfdr3 = command.ExecuteReader();

                while (readerfdr3.Read())
                {
                    Console.WriteLine(readerfdr3["funds_distribution_status"].ToString());
                }
                funds_distribution_status = readerfdr3["funds_distribution_status"].ToString();
                conn.Close();
                SeleniumSetMethods.WaitOnPage(2);
                Assert.IsTrue(funds_distribution_status == "COMPLETE");
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



        public static void FDRInvList(string ID, string status, string filepath)
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

        public static void InvList(string invnumID, string invnum, string filepath)
        {
            try
            {

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filepath, true))
                {
                    file.WriteLine("string " + invnumID + " = \"" + invnum + "\";");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("This program not working:", ex);
            }

        }

    }
}
