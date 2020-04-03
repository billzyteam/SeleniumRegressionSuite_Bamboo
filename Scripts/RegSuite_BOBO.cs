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
    class RegSuite_BOBO : Tests
    {

        /*
        Script Description : BOBO User adds new external contacts, and issue an invoice
       */

        [Test]
        public void BOBO01_LoginPage_NewExternalContacts_IssueInvoice_Cash_Surcharge()
        {
            BOBOPage Bobopg = new BOBOPage(WebDriver);
            HomePage homepg = new HomePage(WebDriver);
            try
            {
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
                //testInfo = 'Select Billzy Biller or Third Party Biller (Inbox)'
                string textcheck = Bobopg.UserWelcomeMessage().Text;
                //string txtmsg = Bobopg.IssueMessage().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(textcheck.Contains("Welcome, madcowbiller+bobo_02@gmail.com"));
                Bobopg.BillzyBiller().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //testInfo = 'Create New Internal and External Contact'
                Bobopg.CreateNewContactBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //testInfo = 'Verify External Contacts Section'
                bool CreateAccountOnBehalfOf = Bobopg.CreateAccountOnBehalfOf().Displayed;
                bool ExistingCustomer = Bobopg.ExistingCustomer().Displayed;
                bool BusinessName = Bobopg.BusinessName().Displayed;
                bool ABN = Bobopg.ABN().Displayed;
                bool ContactName = Bobopg.ContactName().Displayed;
                bool ContactEmail = Bobopg.ContactEmail().Displayed;
                bool ContactPhoneNumber = Bobopg.ContactPhoneNumber().Displayed;
                bool Street = Bobopg.Street().Displayed;
                bool Suburb = Bobopg.Suburb().Displayed;
                bool PostCode = Bobopg.PostCode().Displayed;
                bool State = Bobopg.State().Displayed;
                bool CreateInternalContact = Bobopg.CreateInternalContact().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(CreateAccountOnBehalfOf == true && ExistingCustomer == true && BusinessName == true && ABN == true && ContactName == true & ContactEmail == true && ContactPhoneNumber == true && Street == true && Suburb == true && PostCode == true && State == true && CreateInternalContact == true);
                //testInfo = 'Add New External Payer'

                Random rand2 = new Random();
                DateTime dt2 = new DateTime();
                string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber2 = rand2.Next();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.CreateAccountOnBehalfOf().SendKeys("madcowbillergst+BOBOinternal01");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.BusinessName().SendKeys("Ext-BOBO_@" + randnumber2);
                Bobopg.ABN().SendKeys("12345678901");
                Bobopg.ContactName().SendKeys("BOBO Testing - External Contact" + randnumber2);
                Bobopg.ContactEmail().SendKeys("madcowpayer+boboexternal" + randnumber2 + "@gmail.com");
                Bobopg.ContactPhoneNumber().SendKeys("123456789");
                Bobopg.Street().SendKeys("Testing St.");
                Bobopg.Suburb().SendKeys("BRISBANE");
                Bobopg.PostCode().SendKeys("4001");
                Bobopg.State().SendKeys("NSW");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.CreateExternalContact().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string message = Bobopg.Message().Text;
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Assert.IsTrue(message.Contains("External contact has been created"));
                bool createAnoterContact = Bobopg.CreateAnoterContact().Displayed;
                bool IssueAnInvoice = Bobopg.IssueAnInvoice().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(createAnoterContact == true && IssueAnInvoice == true);
                //testInfo = 'Issue Invoice'
                Bobopg.IssueAnInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //testInfo = 'Select Billzy Biller or Third Party Biller (Inbox)'
                Bobopg.BillzyBiller().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //testInfo = 'Add New on behalf of (Internal)'
                Bobopg.IssueInvoiceOnBehalfOf().SendKeys("madcowbillergst+BOBOinternal01");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.IssueInvoiceTo().SendKeys("Ext-BOBO_@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                DateTime newDate = DateTime.Now.AddDays(60);
                string Invduedate = newDate.ToString("dd/MM/yyyy");
                string Invduedate1 = newDate.ToString("dd MMM yy");
                string Invduedate2 = newDate.ToString("dd/MM/yy");
                DateTime newDate1 = DateTime.Now;
                string Issuedate = newDate1.ToString("dd/MM/yyyy");
                
                Bobopg.EmailTo().SendKeys("madcowpayer+boboexternal" + randnumber2 + "@gmail.com");
                Bobopg.Reference().SendKeys("Ext-Inv_@" + randnumber2);
                Bobopg.InvoiceDueDate().SendKeys(Invduedate);
                Bobopg.InvoiceIssueDate().SendKeys(Issuedate);
                Bobopg.TotalAmount().SendKeys("100.00");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.Surcharge().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.RequestCash().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.PdfUpload().SendKeys(@"C:\Users\Selenium\Desktop\SeleniumRegressionSuite_Bamboo\bin\Debug\netcoreapp3.1\Invoice.pdf");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.Issue().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                string message2 = Bobopg.Message().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(message2.Contains("Invoice has been created"));
                Bobopg.OKBTN().Click();
                //testInfo = 'Login to Webapp and validate External added to Biller and an invoice was created to External Payer'
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);
                SendPage SendPg = new SendPage(WebDriver);
                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowbillergst+BOBOinternal01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                
                homepg.Profile().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                AddCustomerPage custpg = new AddCustomerPage(WebDriver);
                string profiledata = custpg.Profiledata().Text;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(profiledata.Contains("BOBO Testing - External Contact" + randnumber2));
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("Ext-Inv_@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);

                bool viewedstatus = SendPg.StatusNotViewedRow01().Displayed;
                string toRow01 = SendPg.ToRow01().Text;
                string BillzyInvoiceNumRow01 = SendPg.BillzyInvoiceNumRow01().Text;
                string DueRow01 = SendPg.DueRow01().Text;
                string AmountRow1 = SendPg.AmountRow1().Text;
                string BillzyRow1 = SendPg.BillzyRow1().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(viewedstatus == true && toRow01.Contains("Ext-BOBO_@" + randnumber2) && BillzyInvoiceNumRow01.Contains("Ext-Inv_@" + randnumber2) && DueRow01.Contains(Invduedate1) && AmountRow1.Contains("100.00") && BillzyRow1.Contains("Cash requested"));

                DateTime duedate1 = DateTime.Today;
                string today = duedate1.ToString("dd/MM/yy");

                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPage SIVpg = new SIVPage(WebDriver);
                string invstatus = SIVpg.InvoiceStatus().Text;
                string surmsg = SIVpg.InvoiceDetailsSurchargeMsgBiller().Text;
                string issuedate = SIVpg.InvoiceDetailsIssueDate().Text;
                string InvoiceDetailsDuePaid = SIVpg.InvoiceDetailsDuePaid().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invstatus.Contains("UNPAID") && surmsg.Contains("A 1.67% surcharge will apply to credit & debit cards") && issuedate.Contains(today) && InvoiceDetailsDuePaid.Contains(Invduedate));

                string billzyCashStatusBTN = SIVpg.BillzyCashStatusBTN().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(billzyCashStatusBTN.Contains("PENDING APPROVAL"));
                //ABN Validation in Bobo Connect
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
                Bobopg.BillzyBiller().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.CreateNewContactBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.CreateAccountOnBehalfOf().SendKeys("manualtestdemob+gstbiller");
                SeleniumSetMethods.WaitOnPage(secdelay2);

                Bobopg.BusinessName().SendKeys("Ext-ABNValid@" + randnumber2);
                Bobopg.ABN().SendKeys("dsfsdsdgdhbgfhfgh");
                Bobopg.ContactName().SendKeys("BOBO Testing - External Contact" + randnumber2);
                Bobopg.ContactEmail().SendKeys("madcowpayer+boboexternal" + randnumber2 + "@gmail.com");
                Bobopg.ContactPhoneNumber().SendKeys("123456789");
                Bobopg.Street().SendKeys("Testing St.");
                Bobopg.Suburb().SendKeys("BRISBANE");
                Bobopg.PostCode().SendKeys("4001");
                Bobopg.State().SendKeys("NSW");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.CreateExternalContact().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string extmessage1 = Bobopg.Message().Text;
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Assert.IsTrue(extmessage1.Contains("There was an error creating the external contact"));
                Bobopg.ExternalClientok().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                Bobopg.ABN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.ABN().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.ABN().SendKeys("123456789");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.CreateExternalContact().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string extmessage2 = Bobopg.Message().Text;
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Assert.IsTrue(extmessage2.Contains("There was an error creating the external contact"));
                Bobopg.ExternalClientok().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                Bobopg.ABN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.ABN().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.ABN().SendKeys("1234567891235");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.CreateExternalContact().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string extmessage3 = Bobopg.Message().Text;
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Assert.IsTrue(extmessage3.Contains("There was an error creating the external contact"));
                Bobopg.ExternalClientok().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                Bobopg.ABN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.ABN().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.ABN().SendKeys("dghdgh!@#%$");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.CreateExternalContact().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string extmessage4 = Bobopg.Message().Text;
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Assert.IsTrue(extmessage4.Contains("There was an error creating the external contact"));
                Bobopg.ExternalClientok().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                Bobopg.ABN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.ABN().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.ABN().SendKeys("sfgsdg12312312");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.CreateExternalContact().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string extmessage5 = Bobopg.Message().Text;
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Assert.IsTrue(extmessage5.Contains("There was an error creating the external contact"));
                Bobopg.ExternalClientok().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                Bobopg.ABN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.ABN().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.ABN().SendKeys("    ");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.Street().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.Street().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.Suburb().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.Suburb().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.PostCode().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.PostCode().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.CreateExternalContact().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string extmessage6 = Bobopg.Message().Text;
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Assert.IsTrue(extmessage6.Contains("There was an error creating the external contact"));
                Bobopg.ExternalClientok().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                Bobopg.ABN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.ABN().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                
                Bobopg.CreateExternalContact().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string extmessage7 = Bobopg.Message().Text;
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Assert.IsTrue(extmessage7.Contains("There was an error creating the external contact"));
                Bobopg.ExternalClientok().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                Bobopg.ABN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.ABN().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.Street().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.Street().SendKeys("Lade street");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.Suburb().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.Suburb().SendKeys("Brisbane");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.PostCode().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.PostCode().SendKeys("4000");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.CreateExternalContact().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string extmessage8 = Bobopg.Message().Text;
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Assert.IsTrue(extmessage8.Contains("External contact has been created"));
                bool createAnoterContact1 = Bobopg.CreateAnoterContact().Displayed;
                bool IssueAnInvoice1 = Bobopg.IssueAnInvoice().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(createAnoterContact1 == true && IssueAnInvoice1 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.IssueAnInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                Bobopg.BillzyBiller().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                
                Bobopg.IssueInvoiceOnBehalfOf().SendKeys("manualtestdemob+gstbiller");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.IssueInvoiceTo().SendKeys("Ext-ABNValid@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                
                Bobopg.Reference().SendKeys("Ext-BOBOABNVALID@" + randnumber2);
                Bobopg.InvoiceDueDate().SendKeys(Invduedate);
                Bobopg.InvoiceIssueDate().SendKeys(Issuedate);
                Bobopg.TotalAmount().SendKeys("100.00");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.Surcharge().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.RequestCash().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.PdfUpload().SendKeys(@"C:\Users\Selenium\Desktop\SeleniumRegressionSuite_Bamboo\bin\Debug\netcoreapp3.1\Invoice.pdf");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.Issue().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                string message3 = Bobopg.Message().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(message3.Contains("Invoice has been created"));
                Bobopg.OKBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay4);


            }
            finally
            {
               
               

            }
        }

        /*
        Script Description : BOBO User adds internal users and issue a cash invoice with surcharge
       */

        [Test]
        public void BOBO02_CreateNewInternalContacts_IssueInvoice_CASH_Surcharge()
        {
            BOBOPage Bobopg = new BOBOPage(WebDriver);
            HomePage homepg = new HomePage(WebDriver);
            try
            {
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
                //testInfo = 'Select Billzy Biller or Third Party Biller (Inbox)'
                string textcheck = Bobopg.UserWelcomeMessage().Text;
                //string txtmsg = Bobopg.IssueMessage().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(textcheck.Contains("Welcome, madcowbiller+bobo_02@gmail.com"));
                Bobopg.BillzyBiller().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //testInfo = 'Create New Internal and External Contact'
                //Bobopg.CreateNewContactBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //testInfo = 'Verify External Contacts Section'
               // //bool CreateAccountOnBehalfOf = Bobopg.CreateAccountOnBehalfOf().Displayed;
                //bool ExistingCustomer = Bobopg.ExistingCustomer().Displayed;
                //bool BusinessName = Bobopg.BusinessName().Displayed;
                //bool ABN = Bobopg.ABN().Displayed;
                //bool ContactName = Bobopg.ContactName().Displayed;
                //bool ContactEmail = Bobopg.ContactEmail().Displayed;
                //bool ContactPhoneNumber = Bobopg.ContactPhoneNumber().Displayed;
                //bool Street = Bobopg.Street().Displayed;
                //bool Suburb = Bobopg.Suburb().Displayed;
                //bool PostCode = Bobopg.PostCode().Displayed;
                //bool State = Bobopg.State().Displayed;
                //bool CreateInternalContact = Bobopg.CreateInternalContact().Displayed;
                //SeleniumSetMethods.WaitOnPage(secdelay2);
                //Assert.IsTrue(CreateAccountOnBehalfOf == true && ExistingCustomer == true && BusinessName == true && ABN == true && ContactName == true & ContactEmail == true && ContactPhoneNumber == true && Street == true && Suburb == true && PostCode == true && State == true && CreateInternalContact == true);
                //testInfo = 'Add New on behalf of (Internal)'

                Random rand2 = new Random();
                DateTime dt2 = new DateTime();
                string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber2 = rand2.Next();

                //Bobopg.CreateAccountOnBehalfOf().SendKeys("madcowbillergst+BOBOinternal01");
               // Bobopg.ExistingCustomer().SendKeys("madcowbillergst+BOBOinternal02");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //Bobopg.CreateInternalContact().Click();
                //SeleniumSetMethods.WaitOnPage(secdelay2);
                //string message = Bobopg.Message().Text;
                //SeleniumSetMethods.WaitOnPage(secdelay2);
                //Assert.IsTrue(message.Contains("Internal contact has been created"));
                //bool createAnoterContact = Bobopg.CreateAnoterContact().Displayed;
                //bool IssueAnInvoice = Bobopg.IssueAnInvoice().Displayed;
                //SeleniumSetMethods.WaitOnPage(secdelay2);
                //Assert.IsTrue(createAnoterContact == true && IssueAnInvoice == true);
                ////testInfo = 'Issue Invoice'
                //Bobopg.IssueAnInvoice().Click();
                //SeleniumSetMethods.WaitOnPage(secdelay2);
                ////testInfo = 'Select Billzy Biller or Third Party Biller (Inbox)'
                //Bobopg.BillzyBiller().Click();
                //SeleniumSetMethods.WaitOnPage(secdelay2);
                //testInfo = 'Add New on behalf of (Internal)'
                Bobopg.IssueInvoiceOnBehalfOf().SendKeys("madcowbillergst+BOBOinternal01");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.IssueInvoiceTo().SendKeys("b. - madcowbillergst+BOBOinternal02");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                DateTime newDate = DateTime.Now.AddDays(60);
                string Invduedate = newDate.ToString("dd/MM/yyyy");
                string Invduedate1 = newDate.ToString("dd MMM yy");
                string Invduedate2 = newDate.ToString("dd/MM/yy");
                DateTime newDate1 = DateTime.Now;
                string Issuedate = newDate1.ToString("dd/MM/yyyy");

                Bobopg.EmailTo().SendKeys("madcowbillergst+BOBOinternal02@gmail.com");
                Bobopg.Reference().SendKeys("Int-Inv_@" + randnumber2);
                Bobopg.InvoiceDueDate().SendKeys(Invduedate);
                Bobopg.InvoiceIssueDate().SendKeys(Issuedate);
                Bobopg.TotalAmount().SendKeys("200.00");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.Surcharge().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.RequestCash().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.PdfUpload().SendKeys(@"C:\Users\Selenium\Desktop\SeleniumRegressionSuite_Bamboo\bin\Debug\netcoreapp3.1\Invoice.pdf");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.Issue().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                string message2 = Bobopg.Message().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(message2.Contains("Invoice has been created"));
                Bobopg.OKBTN().Click();
                //testInfo = 'Login to Webapp and validate External added to Biller and an invoice was created to External Payer'
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);
                SendPage SendPg = new SendPage(WebDriver);
                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowbillergst+BOBOinternal01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                homepg.Profile().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                AddCustomerPage custpg = new AddCustomerPage(WebDriver);
                string profiledata = custpg.Profiledata().Text;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(profiledata.Contains("madcowbillergst+BOBOinternal02"));
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("Int-Inv_@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);

                bool viewedstatus = SendPg.StatusNotViewedRow01().Displayed;
                string toRow01 = SendPg.ToRow01().Text;
                string BillzyInvoiceNumRow01 = SendPg.BillzyInvoiceNumRow01().Text;
                string DueRow01 = SendPg.DueRow01().Text;
                string AmountRow1 = SendPg.AmountRow1().Text;
                string BillzyRow1 = SendPg.BillzyRow1().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(viewedstatus == true && toRow01.Contains("madcowbillergst+BOB...") && BillzyInvoiceNumRow01.Contains("Int-Inv_@" + randnumber2) && DueRow01.Contains(Invduedate1) && AmountRow1.Contains("200.00") && BillzyRow1.Contains("Cash requested"));

                DateTime duedate1 = DateTime.Today;
                string today = duedate1.ToString("dd/MM/yy");

                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPage SIVpg = new SIVPage(WebDriver);
                string invstatus = SIVpg.InvoiceStatus().Text;
                string surmsg = SIVpg.InvoiceDetailsSurchargeMsgBiller().Text;
                string issuedate = SIVpg.InvoiceDetailsIssueDate().Text;
                string InvoiceDetailsDuePaid = SIVpg.InvoiceDetailsDuePaid().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invstatus.Contains("UNPAID") && surmsg.Contains("A 1.67% surcharge will apply to credit & debit cards") && issuedate.Contains(today) && InvoiceDetailsDuePaid.Contains(Invduedate));

                string billzyCashStatusBTN = SIVpg.BillzyCashStatusBTN().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(billzyCashStatusBTN.Contains("PENDING PAYER VERIFICATION"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                homepg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowbillergst+BOBOinternal02@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                homepg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("Int-Inv_@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                homepg.SignOutBTN().Click();

            }
            finally
            {
                

            }
        }
        /*
        Script Description : BOBO User adds new external contacts, and issue a normal invoice without surcharge
       */

        [Test]
        public void BOBO03_03_LoginPage_NewExternalContacts_IssueInvoice_NormalInvoice()
        {
            BOBOPage Bobopg = new BOBOPage(WebDriver);
            HomePage homepg = new HomePage(WebDriver);
            try
            {
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
                //testInfo = 'Select Billzy Biller or Third Party Biller (Inbox)'
                string textcheck = Bobopg.UserWelcomeMessage().Text;
                //string txtmsg = Bobopg.IssueMessage().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(textcheck.Contains("Welcome, madcowbiller+bobo_02@gmail.com"));
                Bobopg.BillzyBiller().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //testInfo = 'Create New Internal and External Contact'
                Bobopg.CreateNewContactBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //testInfo = 'Verify External Contacts Section'
                bool CreateAccountOnBehalfOf = Bobopg.CreateAccountOnBehalfOf().Displayed;
                bool ExistingCustomer = Bobopg.ExistingCustomer().Displayed;
                bool BusinessName = Bobopg.BusinessName().Displayed;
                bool ABN = Bobopg.ABN().Displayed;
                bool ContactName = Bobopg.ContactName().Displayed;
                bool ContactEmail = Bobopg.ContactEmail().Displayed;
                bool ContactPhoneNumber = Bobopg.ContactPhoneNumber().Displayed;
                bool Street = Bobopg.Street().Displayed;
                bool Suburb = Bobopg.Suburb().Displayed;
                bool PostCode = Bobopg.PostCode().Displayed;
                bool State = Bobopg.State().Displayed;
                bool CreateInternalContact = Bobopg.CreateInternalContact().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(CreateAccountOnBehalfOf == true && ExistingCustomer == true && BusinessName == true && ABN == true && ContactName == true & ContactEmail == true && ContactPhoneNumber == true && Street == true && Suburb == true && PostCode == true && State == true && CreateInternalContact == true);
                //testInfo = 'Add New External Payer'

                Random rand2 = new Random();
                DateTime dt2 = new DateTime();
                string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber2 = rand2.Next();

                Bobopg.CreateAccountOnBehalfOf().SendKeys("madcowbillergst+BOBOinternal01");
                Bobopg.BusinessName().SendKeys("Ext-BOBO_@" + randnumber2);
                Bobopg.ABN().SendKeys("12345678901");
                Bobopg.ContactName().SendKeys("BOBO Testing - External Contact" + randnumber2);
                Bobopg.ContactEmail().SendKeys("madcowpayer+boboexternal" + randnumber2 + "@gmail.com");
                Bobopg.ContactPhoneNumber().SendKeys("123456789");
                Bobopg.Street().SendKeys("Testing St.");
                Bobopg.Suburb().SendKeys("BRISBANE");
                Bobopg.PostCode().SendKeys("4001");
                Bobopg.State().SendKeys("NSW");
                Bobopg.CreateExternalContact().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string message = Bobopg.Message().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(message.Contains("External contact has been created"));
                bool createAnoterContact = Bobopg.CreateAnoterContact().Displayed;
                bool IssueAnInvoice = Bobopg.IssueAnInvoice().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(createAnoterContact == true && IssueAnInvoice == true);
                //testInfo = 'Issue Invoice'
                Bobopg.IssueAnInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //testInfo = 'Select Billzy Biller or Third Party Biller (Inbox)'
                Bobopg.BillzyBiller().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //testInfo = 'Add New on behalf of (Internal)'
                Bobopg.IssueInvoiceOnBehalfOf().SendKeys("madcowbillergst+BOBOinternal01");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.IssueInvoiceTo().SendKeys("Ext-BOBO_@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                DateTime newDate = DateTime.Now.AddDays(60);
                string Invduedate = newDate.ToString("dd/MM/yyyy");
                string Invduedate1 = newDate.ToString("dd MMM yy");
                string Invduedate2 = newDate.ToString("dd/MM/yy");
                DateTime newDate1 = DateTime.Now;
                string Issuedate = newDate1.ToString("dd/MM/yyyy");

                Bobopg.EmailTo().SendKeys("madcowpayer+boboexternal" + randnumber2 + "@gmail.com");
                Bobopg.Reference().SendKeys("Ext-Inv_@" + randnumber2);
                Bobopg.InvoiceDueDate().SendKeys(Invduedate);
                Bobopg.InvoiceIssueDate().SendKeys(Issuedate);
                Bobopg.TotalAmount().SendKeys("300.00");
                SeleniumSetMethods.WaitOnPage(secdelay2);
               
                Bobopg.PdfUpload().SendKeys(@"C:\Users\Selenium\Desktop\SeleniumRegressionSuite_Bamboo\bin\Debug\netcoreapp3.1\Invoice.pdf");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.Issue().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                string message2 = Bobopg.Message().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(message2.Contains("Invoice has been created"));
                Bobopg.OKBTN().Click();
                //testInfo = 'Login to Webapp and validate External added to Biller and an invoice was created to External Payer'
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);
                SendPage SendPg = new SendPage(WebDriver);
                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowbillergst+BOBOinternal01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                homepg.Profile().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                AddCustomerPage custpg = new AddCustomerPage(WebDriver);
                string profiledata = custpg.Profiledata().Text;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(profiledata.Contains("BOBO Testing - External Contact" + randnumber2));
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("Ext-Inv_@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);

                bool viewedstatus = SendPg.StatusNotViewedRow01().Displayed;
                string toRow01 = SendPg.ToRow01().Text;
                string BillzyInvoiceNumRow01 = SendPg.BillzyInvoiceNumRow01().Text;
                string DueRow01 = SendPg.DueRow01().Text;
                string AmountRow1 = SendPg.AmountRow1().Text;
                string BillzyRow1 = SendPg.BillzyRow1().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(viewedstatus == true && toRow01.Contains("Ext-BOBO_@" + randnumber2) && BillzyInvoiceNumRow01.Contains("Ext-Inv_@" + randnumber2) && DueRow01.Contains(Invduedate1) && AmountRow1.Contains("300.00") && BillzyRow1.Contains(""));

                DateTime duedate1 = DateTime.Today;
                string today = duedate1.ToString("dd/MM/yy");

                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPage SIVpg = new SIVPage(WebDriver);
                string invstatus = SIVpg.InvoiceStatus().Text;
                
                string issuedate = SIVpg.InvoiceDetailsIssueDate().Text;
                string InvoiceDetailsDuePaid = SIVpg.InvoiceDetailsDuePaid().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invstatus.Contains("UNPAID") && issuedate.Contains(today) && InvoiceDetailsDuePaid.Contains(Invduedate));

                bool billzyCashStatusBTN = SIVpg.SIVRequestBillzyCashBTN().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(billzyCashStatusBTN == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                homepg.SignOutBTN().Click();

            }
            finally
            {
                

            }

        }

        /*
        Script Description : BOBO User adds new internal contacts, and issue an invoice, Make the payment 
       */

        [Test]
        public void BOBO04_InternalContacts_IssueInvoice_NormalInvoice()
        {
            BOBOPage Bobopg = new BOBOPage(WebDriver);
            HomePage homepg = new HomePage(WebDriver);
            try
            {
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
                //testInfo = 'Select Billzy Biller or Third Party Biller (Inbox)'
                string textcheck = Bobopg.UserWelcomeMessage().Text;
                //string txtmsg = Bobopg.IssueMessage().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(textcheck.Contains("Welcome, madcowbiller+bobo_02@gmail.com"));
                Bobopg.BillzyBiller().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                
                //testInfo = 'Add New on behalf of (Internal)'

                Random rand2 = new Random();
                DateTime dt2 = new DateTime();
                string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber2 = rand2.Next();

               
                //testInfo = 'Add New on behalf of (Internal)'
                Bobopg.IssueInvoiceOnBehalfOf().SendKeys("madcowbillergst+BOBOinternal01");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.IssueInvoiceTo().SendKeys("b. - madcowbillergst+BOBOinternal02");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                DateTime newDate = DateTime.Now.AddDays(60);
                string Invduedate = newDate.ToString("dd/MM/yyyy");
                string Invduedate1 = newDate.ToString("dd MMM yy");
                string Invduedate2 = newDate.ToString("dd/MM/yy");
                DateTime newDate1 = DateTime.Now;
                string Issuedate = newDate1.ToString("dd/MM/yyyy");

                Bobopg.EmailTo().SendKeys("madcowbillergst+BOBOinternal02@gmail.com");
                Bobopg.Reference().SendKeys("Int-Inv_@" + randnumber2);
                Bobopg.InvoiceDueDate().SendKeys(Invduedate);
                Bobopg.InvoiceIssueDate().SendKeys(Issuedate);
                Bobopg.TotalAmount().SendKeys("200.00");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                
                Bobopg.PdfUpload().SendKeys(@"C:\Users\Selenium\Desktop\SeleniumRegressionSuite_Bamboo\bin\Debug\netcoreapp3.1\Invoice.pdf");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.Issue().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                string message2 = Bobopg.Message().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(message2.Contains("Invoice has been created"));
                Bobopg.OKBTN().Click();
                //testInfo = 'Login to Webapp and validate External added to Biller and an invoice was created to External Payer'
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);
                SendPage SendPg = new SendPage(WebDriver);
                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowbillergst+BOBOinternal01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                homepg.Profile().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                AddCustomerPage custpg = new AddCustomerPage(WebDriver);
                string profiledata = custpg.Profiledata().Text;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(profiledata.Contains("madcowbillergst+BOBOinternal02"));
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("Int-Inv_@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);

                bool viewedstatus = SendPg.StatusNotViewedRow01().Displayed;
                string toRow01 = SendPg.ToRow01().Text;
                string BillzyInvoiceNumRow01 = SendPg.BillzyInvoiceNumRow01().Text;
                string DueRow01 = SendPg.DueRow01().Text;
                string AmountRow1 = SendPg.AmountRow1().Text;
                string BillzyRow1 = SendPg.BillzyRow1().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(viewedstatus == true && toRow01.Contains("madcowbillergst+BOB...") && BillzyInvoiceNumRow01.Contains("Int-Inv_@" + randnumber2) && DueRow01.Contains(Invduedate1) && AmountRow1.Contains("200.00") && BillzyRow1.Contains(""));

                DateTime duedate1 = DateTime.Today;
                string today = duedate1.ToString("dd/MM/yy");
                string today1 = duedate1.ToString("dd MMM yy");

                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPage SIVpg = new SIVPage(WebDriver);
                string invstatus = SIVpg.InvoiceStatus().Text;
                
                string issuedate = SIVpg.InvoiceDetailsIssueDate().Text;
                string InvoiceDetailsDuePaid = SIVpg.InvoiceDetailsDuePaid().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invstatus.Contains("UNPAID") && issuedate.Contains(today) && InvoiceDetailsDuePaid.Contains(Invduedate));

                bool billzyCashStatusBTN = SIVpg.SIVRequestBillzyCashBTN().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(billzyCashStatusBTN == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                homepg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowbillergst+BOBOinternal02@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                homepg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("Int-Inv_@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                //testInfo = 'Pay Invoice from BOBO Path thru CC'
                SIVpg.PayBTNNoDeal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay6);
               
                PayNowPage paypg = new PayNowPage(WebDriver);
                paypg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.CardRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.ConfirmPayBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                homepg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.ReceivedHistoryBTN().Click();
                Recpg.SearchInvoiceReceived().SendKeys("Int-Inv_@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string paiddate = Recpg.CompletedRow1().Text;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paiddate.Contains(today1));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                homepg.SignOutBTN().Click();


            }
            finally
            {
                

            }
        }

        /*
        Script Description : BOBO User adds new external contacts by providing ABN details only, and issue an invoice
       */

        [Test]
        public void BOBO05_NewExternalContacts_ABNOnly_IssueInvoice()
        {
            BOBOPage Bobopg = new BOBOPage(WebDriver);
            HomePage homepg = new HomePage(WebDriver);
            try
            {
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
                //testInfo = 'Select Billzy Biller or Third Party Biller (Inbox)'
                string textcheck = Bobopg.UserWelcomeMessage().Text;
                //string txtmsg = Bobopg.IssueMessage().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(textcheck.Contains("Welcome, madcowbiller+bobo_02@gmail.com"));
                Bobopg.BillzyBiller().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //testInfo = 'Create New Internal and External Contact'
                Bobopg.CreateNewContactBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //testInfo = 'Verify External Contacts Section'
                bool CreateAccountOnBehalfOf = Bobopg.CreateAccountOnBehalfOf().Displayed;
                bool ExistingCustomer = Bobopg.ExistingCustomer().Displayed;
                bool BusinessName = Bobopg.BusinessName().Displayed;
                bool ABN = Bobopg.ABN().Displayed;
                bool ContactName = Bobopg.ContactName().Displayed;
                bool ContactEmail = Bobopg.ContactEmail().Displayed;
                bool ContactPhoneNumber = Bobopg.ContactPhoneNumber().Displayed;
                bool Street = Bobopg.Street().Displayed;
                bool Suburb = Bobopg.Suburb().Displayed;
                bool PostCode = Bobopg.PostCode().Displayed;
                bool State = Bobopg.State().Displayed;
                bool CreateInternalContact = Bobopg.CreateInternalContact().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(CreateAccountOnBehalfOf == true && ExistingCustomer == true && BusinessName == true && ABN == true && ContactName == true & ContactEmail == true && ContactPhoneNumber == true && Street == true && Suburb == true && PostCode == true && State == true && CreateInternalContact == true);
                //testInfo = 'Add New External Payer'

                Random rand2 = new Random();
                DateTime dt2 = new DateTime();
                string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber2 = rand2.Next();

                Bobopg.CreateAccountOnBehalfOf().SendKeys("madcowbillergst+BOBOinternal01");
                Bobopg.BusinessName().SendKeys("Ext-BOBO_@" + randnumber2);
                Bobopg.ABN().SendKeys("12345678901");
                Bobopg.ContactName().SendKeys("BOBO Testing - External Contact" + randnumber2);
                Bobopg.ContactEmail().SendKeys("madcowpayer+boboexternal" + randnumber2 + "@gmail.com");
                Bobopg.ContactPhoneNumber().SendKeys("123456789");
                
                Bobopg.PostCode().SendKeys("4001");
                Bobopg.State().SendKeys("NSW");
                Bobopg.CreateExternalContact().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string message = Bobopg.Message().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(message.Contains("External contact has been created"));
                bool createAnoterContact = Bobopg.CreateAnoterContact().Displayed;
                bool IssueAnInvoice = Bobopg.IssueAnInvoice().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(createAnoterContact == true && IssueAnInvoice == true);
                //testInfo = 'Issue Invoice'
                Bobopg.IssueAnInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //testInfo = 'Select Billzy Biller or Third Party Biller (Inbox)'
                Bobopg.BillzyBiller().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //testInfo = 'Add New on behalf of (Internal)'
                Bobopg.IssueInvoiceOnBehalfOf().SendKeys("madcowbillergst+BOBOinternal01");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.IssueInvoiceTo().SendKeys("Ext-BOBO_@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                DateTime newDate = DateTime.Now.AddDays(60);
                string Invduedate = newDate.ToString("dd/MM/yyyy");
                string Invduedate1 = newDate.ToString("dd MMM yy");
                string Invduedate2 = newDate.ToString("dd/MM/yy");
                DateTime newDate1 = DateTime.Now;
                string Issuedate = newDate1.ToString("dd/MM/yyyy");

                Bobopg.EmailTo().SendKeys("madcowpayer+boboexternal" + randnumber2 + "@gmail.com");
                Bobopg.Reference().SendKeys("Ext-Inv_@" + randnumber2);
                Bobopg.InvoiceDueDate().SendKeys(Invduedate);
                Bobopg.InvoiceIssueDate().SendKeys(Issuedate);
                Bobopg.TotalAmount().SendKeys("100.00");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                
                Bobopg.RequestCash().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.PdfUpload().SendKeys(@"C:\Users\Selenium\Desktop\SeleniumRegressionSuite_Bamboo\bin\Debug\netcoreapp3.1\Invoice.pdf");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.Issue().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                string message2 = Bobopg.Message().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(message2.Contains("Invoice has been created"));
                Bobopg.OKBTN().Click();
                //testInfo = 'Login to Webapp and validate External added to Biller and an invoice was created to External Payer'
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);
                SendPage SendPg = new SendPage(WebDriver);
                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowbillergst+BOBOinternal01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                homepg.Profile().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                AddCustomerPage custpg = new AddCustomerPage(WebDriver);
                string profiledata = custpg.Profiledata().Text;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(profiledata.Contains("BOBO Testing - External Contact" + randnumber2));
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("Ext-Inv_@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);

                bool viewedstatus = SendPg.StatusNotViewedRow01().Displayed;
                string toRow01 = SendPg.ToRow01().Text;
                string BillzyInvoiceNumRow01 = SendPg.BillzyInvoiceNumRow01().Text;
                string DueRow01 = SendPg.DueRow01().Text;
                string AmountRow1 = SendPg.AmountRow1().Text;
                string BillzyRow1 = SendPg.BillzyRow1().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(viewedstatus == true && toRow01.Contains("Ext-BOBO_@" + randnumber2) && BillzyInvoiceNumRow01.Contains("Ext-Inv_@" + randnumber2) && DueRow01.Contains(Invduedate1) && AmountRow1.Contains("100.00") && BillzyRow1.Contains("Cash requested"));

                DateTime duedate1 = DateTime.Today;
                string today = duedate1.ToString("dd/MM/yy");

                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPage SIVpg = new SIVPage(WebDriver);
                string invstatus = SIVpg.InvoiceStatus().Text;
                
                string issuedate = SIVpg.InvoiceDetailsIssueDate().Text;
                string InvoiceDetailsDuePaid = SIVpg.InvoiceDetailsDuePaid().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invstatus.Contains("UNPAID")  && issuedate.Contains(today) && InvoiceDetailsDuePaid.Contains(Invduedate));

                string billzyCashStatusBTN = SIVpg.BillzyCashStatusBTN().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(billzyCashStatusBTN.Contains("PENDING APPROVAL"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                homepg.SignOutBTN().Click();

            }
            finally
            {
               

            }
        }

        /*
        Script Description : BOBO User adds new external contacts without address, and issue an invoice
       */

        [Test]
        public void BOBO06_ExistingExternalContacts_NoAddressIssueInvoice()
        {
            BOBOPage Bobopg = new BOBOPage(WebDriver);
            HomePage homepg = new HomePage(WebDriver);
            try
            {
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
                //testInfo = 'Select Billzy Biller or Third Party Biller (Inbox)'
                string textcheck = Bobopg.UserWelcomeMessage().Text;
                //string txtmsg = Bobopg.IssueMessage().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(textcheck.Contains("Welcome, madcowbiller+bobo_02@gmail.com"));
                // Client with No Address
                Bobopg.BillzyBiller().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                

                Random rand2 = new Random();
                DateTime dt2 = new DateTime();
                string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber2 = rand2.Next();

                Bobopg.IssueInvoiceOnBehalfOf().SendKeys("madcowbillergst+BOBOinternal01");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.IssueInvoiceTo().SendKeys("Ext-NoAddress");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                DateTime newDate = DateTime.Now.AddDays(60);
                string Invduedate = newDate.ToString("dd/MM/yyyy");
                string Invduedate1 = newDate.ToString("dd MMM yy");
                string Invduedate2 = newDate.ToString("dd/MM/yy");
                DateTime newDate1 = DateTime.Now;
                string Issuedate = newDate1.ToString("dd/MM/yyyy");
                Bobopg.EmailTo().SendKeys("madcowpayer+BOBOExternal1+Ext-NoAddress@gmail.com");
                Bobopg.Reference().SendKeys("Ex-Ext-Inv_1@" + randnumber2);
                Bobopg.InvoiceDueDate().SendKeys(Invduedate);
                Bobopg.InvoiceIssueDate().SendKeys(Issuedate);
                Bobopg.TotalAmount().SendKeys("800.00");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.Surcharge().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.RequestCash().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.PdfUpload().SendKeys(@"C:\Users\Selenium\Desktop\SeleniumRegressionSuite_Bamboo\bin\Debug\netcoreapp3.1\Invoice.pdf");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.Issue().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                string message2 = Bobopg.Message().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(message2.Contains("Invoice has been created"));
                Bobopg.OKBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                // Client with No ABN

                Bobopg.BillzyBiller().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.IssueInvoiceOnBehalfOf().SendKeys("madcowbillergst+BOBOinternal01");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.IssueInvoiceTo().SendKeys("Ext-NoABN");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.EmailTo().SendKeys("madcowpayer+BOBOExternal1+Ext-NoABN@gmail.com");
                Bobopg.Reference().SendKeys("Ex-Ext-Inv_2@" + randnumber2);
                Bobopg.InvoiceDueDate().SendKeys(Invduedate);
                Bobopg.InvoiceIssueDate().SendKeys(Issuedate);
                Bobopg.TotalAmount().SendKeys("850.00");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.PdfUpload().SendKeys(@"C:\Users\Selenium\Desktop\SeleniumRegressionSuite_Bamboo\bin\Debug\netcoreapp3.1\Invoice.pdf");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.Issue().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                string message3 = Bobopg.Message().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(message3.Contains("Invoice has been created"));

                Bobopg.OKBTN().Click();
                //testInfo = 'Login to Webapp and validate External added to Biller and an invoice was created to External Payer'
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);
                SendPage SendPg = new SendPage(WebDriver);
                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowbillergst+BOBOinternal01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                // search for invoice with No address client
                SendPg.SearchInvoiceSent().SendKeys("Ex-Ext-Inv_1@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                bool viewedstatus = SendPg.StatusNotViewedRow01().Displayed;
                string toRow01 = SendPg.ToRow01().Text;
                string BillzyInvoiceNumRow01 = SendPg.BillzyInvoiceNumRow01().Text;
                string DueRow01 = SendPg.DueRow01().Text;
                string AmountRow1 = SendPg.AmountRow1().Text;
                string BillzyRow1 = SendPg.BillzyRow1().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(viewedstatus == true && toRow01.Contains("Ext-NoAddress") && BillzyInvoiceNumRow01.Contains("Ex-Ext-Inv_1@") && DueRow01.Contains(Invduedate1) && AmountRow1.Contains("$800.00") && BillzyRow1.Contains("Cash requested"));
                DateTime duedate1 = DateTime.Today;
                string today = duedate1.ToString("dd/MM/yy");
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPage SIVpg = new SIVPage(WebDriver);
                string invstatus = SIVpg.InvoiceStatus().Text;
                string surmsg = SIVpg.InvoiceDetailsSurchargeMsgBiller().Text;
                string issuedate = SIVpg.InvoiceDetailsIssueDate().Text;
                string InvoiceDetailsDuePaid = SIVpg.InvoiceDetailsDuePaid().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invstatus.Contains("UNPAID") && surmsg.Contains("A 1.67% surcharge will apply to credit & debit cards") && issuedate.Contains(today) && InvoiceDetailsDuePaid.Contains(Invduedate));
                string billzyCashStatusBTN = SIVpg.BillzyCashStatusBTN().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(billzyCashStatusBTN.Contains("PENDING APPROVAL"));

                SeleniumSetMethods.WaitOnPage(secdelay5);
                
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                // search for invoice with No ABN client
                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("Ex-Ext-Inv_2@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                bool viewedstatus2 = SendPg.StatusNotViewedRow01().Displayed;
                string toRow02 = SendPg.ToRow01().Text;
                string BillzyInvoiceNumRow02 = SendPg.BillzyInvoiceNumRow01().Text;
                string DueRow02 = SendPg.DueRow01().Text;
                string AmountRow2 = SendPg.AmountRow1().Text;
                string BillzyRow2 = SendPg.BillzyRow1().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(viewedstatus2 == true && toRow02.Contains("Ext-NoABN") && BillzyInvoiceNumRow02.Contains("Ex-Ext-Inv_2@") && DueRow02.Contains(Invduedate1) && AmountRow2.Contains("850.00") && BillzyRow1.Contains(""));
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string invstatus2 = SIVpg.InvoiceStatus().Text;
                string issuedate2 = SIVpg.InvoiceDetailsIssueDate().Text;
                string InvoiceDetailsDuePaid2 = SIVpg.InvoiceDetailsDuePaid().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(invstatus2.Contains("UNPAID") && issuedate2.Contains(today) && InvoiceDetailsDuePaid2.Contains(Invduedate));
                bool billzyCashStatusBTN2 = SIVpg.SIVRequestBillzyCashBTN().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(billzyCashStatusBTN2 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                homepg.SignOutBTN().Click();

            }
            finally
            {
               

            }
        }

        /*
        Script Description : BOBO User creates Third Party Biller and issue inbox invoices
       */

        [Test]
        public void BOBO07_TPB_CreateNewBiller_IssueBillzyInbox()
        {
            BOBOPage Bobopg = new BOBOPage(WebDriver);
            HomePage homepg = new HomePage(WebDriver);
            try
            {
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
                //testInfo = 'Select Billzy Biller or Third Party Biller (Inbox)'
                string textcheck = Bobopg.UserWelcomeMessage().Text;
                //string txtmsg = Bobopg.IssueMessage().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(textcheck.Contains("Welcome, madcowbiller+bobo_02@gmail.com"));
                
                Bobopg.ThirdPartyBiller().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                bool issueInvoiceOnBehalfOfTPB = Bobopg.IssueInvoiceOnBehalfOfTPB().Displayed;
                bool issueInvoiceToTPB = Bobopg.IssueInvoiceToTPB().Displayed;
                bool emailToTPB = Bobopg.EmailToTPB().Displayed;
                bool referenceTPB = Bobopg.ReferenceTPB().Displayed;
                bool invoiceDueDateTPB = Bobopg.InvoiceDueDateTPB().Displayed;
                bool InvoiceIssueDateTPB = Bobopg.InvoiceIssueDateTPB().Displayed;
                bool totalAmountTPB = Bobopg.TotalAmountTPB().Displayed;
                bool surcharge = Bobopg.Surcharge().Displayed;
                bool requestCash = Bobopg.RequestCash().Displayed;
                bool browseBTNTPB = Bobopg.BrowseBTNTPB().Displayed;
                bool issueTPB = Bobopg.IssueTPB().Displayed;
                
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(issueInvoiceOnBehalfOfTPB == true && issueInvoiceToTPB == true && emailToTPB == true && referenceTPB == true && invoiceDueDateTPB == true & InvoiceIssueDateTPB == true && totalAmountTPB == true && surcharge == false && requestCash == false && browseBTNTPB == true && issueTPB == true);
                Bobopg.CreateANewThirdPartyBiller().Click();
                Random rand2 = new Random();
                DateTime dt2 = new DateTime();
                string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber2 = rand2.Next();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.BusinessName1().SendKeys("TPB_NewBiller@" + randnumber2);
                Bobopg.ABN1().SendKeys("12345678901");
                Bobopg.BillerEmail1().SendKeys("madcowtesting10+TPB_@" + randnumber2 + "@gmail.com");
                Bobopg.Bsb1().SendKeys("650001");
                Bobopg.BankAccountNumber().SendKeys("123456");
                Bobopg.BankAccountName().SendKeys("BillerBankAccount@" + randnumber2);

                SeleniumSetMethods.WaitOnPage(secdelay2);

                Bobopg.CreateNewThirdPartyBiller().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                string message2 = Bobopg.Message().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(message2.Contains("Third Party Biller has been created"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.IssueAnInvoiceBtnTPB().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool bbiller = Bobopg.BillzyBiller().Displayed;
                bool tpbbiller = Bobopg.ThirdPartyBiller().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(bbiller == true && tpbbiller == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.ThirdPartyBiller().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);


                Bobopg.IssueInvoiceOnBehalfOfTPB().SendKeys("TPB_NewBiller@" + randnumber2 +" - BSB: 650001 - AccountNumber: 123456");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.IssueInvoiceToTPB().SendKeys("raffy3@demo.billzyinbox.com - RaffyInbox_01");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                DateTime newDate = DateTime.Now.AddDays(60);
                string Invduedate = newDate.ToString("dd/MM/yyyy");
                string Invduedate1 = newDate.ToString("dd MMM yy");
                string Invduedate2 = newDate.ToString("dd/MM/yy");
                DateTime newDate1 = DateTime.Now;
                string Issuedate = newDate1.ToString("dd/MM/yyyy");
                Bobopg.EmailToTPB().SendKeys("rafie00+RaffyInbox_01@gmail.com");
                Bobopg.ReferenceTPB().SendKeys("BOBO-INV@" + randnumber2);
                Bobopg.InvoiceDueDateTPB().SendKeys(Invduedate);
                Bobopg.InvoiceIssueDateTPB().SendKeys(Issuedate);
                Bobopg.TotalAmountTPB().SendKeys("150.66");
                SeleniumSetMethods.WaitOnPage(secdelay2);
               
                Bobopg.PdfUploadTPB().SendKeys(@"C:\Users\Selenium\Desktop\SeleniumRegressionSuite_Bamboo\bin\Debug\netcoreapp3.1\Invoice.pdf");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.IssueTPB().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                string message3 = Bobopg.Message().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(message3.Contains("Invoice has been created"));
                Bobopg.OKBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                //testInfo = 'Login to Webapp and validate the invoice'
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);
                SendPage SendPg = new SendPage(WebDriver);
                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("rafie00+RaffyInbox_01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                ReceivedPage recpg = new ReceivedPage(WebDriver);
                recpg.SearchInvoiceReceived().SendKeys("BOBO-INV@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                homepg.SignOutBTN().Click();


            }
            finally
            {
                

            }
        }

        /*
        Script Description : BOBO User updates an existing billzy invoice like invoice verification and marked as paid
        */

        [Test]
        public void BOBO08_UpdateExistingBillzyInvoice()
        {
            BOBOPage Bobopg = new BOBOPage(WebDriver);
            HomePage homepg = new HomePage(WebDriver);
            try
            {
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
                //testInfo = 'Select Billzy Biller or Third Party Biller (Inbox)'
                string textcheck = Bobopg.UserWelcomeMessage().Text;
                //string txtmsg = Bobopg.IssueMessage().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                 Assert.IsTrue(textcheck.Contains("Welcome, madcowbiller+bobo_02@gmail.com"));

                Bobopg.BillzyBiller().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                //testInfo = 'Add New on behalf of (Internal)'

                Random rand2 = new Random();
                DateTime dt2 = new DateTime();
                string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber2 = rand2.Next();


                //testInfo = 'Add New on behalf of (Internal)'
                Bobopg.IssueInvoiceOnBehalfOf().SendKeys("madcowbillergst+BOBOinternal01");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.IssueInvoiceTo().SendKeys("b. - madcowbillergst+BOBOinternal02");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                DateTime newDate = DateTime.Now.AddDays(60);
                string Invduedate = newDate.ToString("dd/MM/yyyy");
                string Invduedate1 = newDate.ToString("dd MMM yy");
                string Invduedate2 = newDate.ToString("dd/MM/yy");
                DateTime newDate1 = DateTime.Now;
                string Issuedate = newDate1.ToString("dd/MM/yyyy");

                Bobopg.EmailTo().SendKeys("madcowbillergst+BOBOinternal02@gmail.com");
                Bobopg.Reference().SendKeys("Int-Inv_@" + randnumber2);
                Bobopg.InvoiceDueDate().SendKeys(Invduedate);
                Bobopg.InvoiceIssueDate().SendKeys(Issuedate);
                Bobopg.TotalAmount().SendKeys("200.00");
                SeleniumSetMethods.WaitOnPage(secdelay2);

                Bobopg.PdfUpload().SendKeys(@"C:\Users\Selenium\Desktop\SeleniumRegressionSuite_Bamboo\bin\Debug\netcoreapp3.1\Invoice.pdf");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.Issue().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                string message2 = Bobopg.Message().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(message2.Contains("Invoice has been created"));
                Bobopg.OKBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);


                //testInfo = 'Login to Webapp and validate the invoice'
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);
                SendPage SendPg = new SendPage(WebDriver);
                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowbillergst+BOBOinternal01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                ReceivedPage recpg = new ReceivedPage(WebDriver);
                homepg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("Int-Inv_@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SIVPage SIVPG1 = new SIVPage(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string invnumber = SIVPG1.InvNumber().Text;
                string invoicenumber = invnumber.Substring(invnumber.IndexOf("Invoice ")).Replace("Invoice ", "");
                homepg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                // Updating the invoice thru Bobo

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
                string textcheck1 = Bobopg.UserWelcomeMessage().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(textcheck1.Contains("Welcome, madcowbiller+bobo_02@gmail.com"));
                Bobopg.UpdateExistingBillzyInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string UpdateMsg1 = Bobopg.UpdateMsg1().Text;
                
                bool updatesection = Bobopg.UpdateExistingBillzyInvoiceSection().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(updatesection == true && UpdateMsg1.Contains("Select the business you are searching invoices on behalf of"));
                Bobopg.SelectBusiness().SendKeys("madcowbillergst+BOBOinternal01");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.InputInvoice().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.SearchBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay8);
                string title = Bobopg.Invtitles().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(title.Contains("INVOICE NUMBER") && title.Contains("INVOICE NUMBER") && title.Contains("INVOICE REFERENCE") && title.Contains("BILLER NAME") && title.Contains("PAYER NAME"));
                Assert.IsTrue(title.Contains("IS PAYER EXTERNAL") && title.Contains("INVOICE VALUE") && title.Contains("CASH STATUS") && title.Contains("VERIFIED TIMESTAMP") && title.Contains("TOGGLE VERIFICATION") && title.Contains("VIEW PDF") && title.Contains("INVOICE STATUS") && title.Contains("MARK INVOICE AS PAID"));
                //testInfo = Invoice has NO Deal nor CASH and NOT yet verified


                string data1 = Bobopg.InvoiceNumber().Text;
                string data2 = Bobopg.InvoiceRef().Text;
                string data3 = Bobopg.BillerName().Text;
                string data4 = Bobopg.PayerName().Text;
                string data5 = Bobopg.IsPayerExt().Text;
                string data6 = Bobopg.InvoiceValue().Text;
                string data7 = Bobopg.CashStatus().Text;
                string data8 = Bobopg.VerifiedTimeStamp().Text;
                string data9 = Bobopg.InvoiceStatus().Text;
                bool verifybtn = Bobopg.VerifyBTNEnabled().Displayed;
                bool pdf = Bobopg.ViewPDF().Displayed;
                bool markaspaid = Bobopg.MarkAsPaidEnabled().Displayed;

                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(verifybtn == true && pdf == true && markaspaid == true && data1.Contains(invoicenumber) && data2.Contains("Int-Inv_@" + randnumber2) && data3.Contains("madcowbillergst+BOBOinternal01") && data4.Contains("madcowbillergst+BOBOinternal02") && data5.Contains("false") && data6.Contains("200") && data7.Contains("") && data8.Contains("Unverified") && data9.Contains("UNPAID"));
                Bobopg.VerifyBTNEnabled().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.SearchBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay8);
                string verifystatus = Bobopg.VerifiedTimeStamp().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(verifystatus.Contains("Verified"));
                bool unverifybtn = Bobopg.UnverifyBTNEnabled().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(unverifybtn == true);
                Bobopg.MarkAsPaidEnabled().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Bobopg.MAPYes().Click();
                SeleniumSetMethods.WaitOnPage(secdelay8);
                bool Markaspaiddisabled = Bobopg.MarkAsPaidDisabled().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Markaspaiddisabled == true);
                string data99 = Bobopg.InvoiceStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(data99.Contains("PAID"));
                //Issue invoice with cash

                Bobopg.BillzyBiller().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                //testInfo = 'Add New on behalf of (Internal)'

                Random rand3 = new Random();
                DateTime dt3 = new DateTime();
                string dtString3 = dt3.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber3 = rand3.Next();

                //testInfo = 'Add New on behalf of (Internal)'
                Bobopg.IssueInvoiceOnBehalfOf().SendKeys("madcowbillergst+BOBOinternal01");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.IssueInvoiceTo().SendKeys("b. - madcowbillergst+BOBOinternal02");
                SeleniumSetMethods.WaitOnPage(secdelay2);


                Bobopg.EmailTo().SendKeys("madcowbillergst+BOBOinternal02@gmail.com");
                Bobopg.Reference().SendKeys("Int-Inv_Cash@" + randnumber3);
                Bobopg.InvoiceDueDate().SendKeys(Invduedate);
                Bobopg.InvoiceIssueDate().SendKeys(Issuedate);
                Bobopg.TotalAmount().SendKeys("200.00");
                Bobopg.RequestCash().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                Bobopg.PdfUpload().SendKeys(@"C:\Users\Selenium\Desktop\SeleniumRegressionSuite_Bamboo\bin\Debug\netcoreapp3.1\Invoice.pdf");
                SeleniumSetMethods.WaitOnPage(secdelay2);

                Bobopg.Issue().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                string message3 = Bobopg.Message().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(message3.Contains("Invoice has been created"));
                Bobopg.OKBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                //testInfo = 'Login to Webapp and validate the invoice'
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");

                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowbillergst+BOBOinternal01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                homepg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SearchInvoiceSent().SendKeys("Int-Inv_@" + randnumber2);
                
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string noinvresult = SendPg.NoInvoiceResult().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(noinvresult.Contains("No Invoices Available"));
                SendPg.SentHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string markaspaidmsg = SIVPG1.BoboMarkaspaid().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(markaspaidmsg.Contains("Billzy has marked this invoice as paid."));
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                homepg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowbillergst+BOBOinternal02@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                recpg.SearchInvoiceReceived().SendKeys("Int-Inv_Cash@" + randnumber3);

                SeleniumSetMethods.WaitOnPage(secdelay4);
                recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.PayerVerifyBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string invnumber2 = SIVPG1.InvNumber().Text;
                string invoicenumber2 = invnumber2.Substring(invnumber2.IndexOf("Invoice ")).Replace("Invoice ", "");
                homepg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

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
                
                Bobopg.UpdateExistingBillzyInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                
                Bobopg.SelectBusiness().SendKeys("madcowbillergst+BOBOinternal01");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.InputInvoice().SendKeys(invoicenumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.SearchBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay8);
                string title1 = Bobopg.Invtitles().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(title1.Contains("INVOICE NUMBER") && title.Contains("INVOICE NUMBER") && title.Contains("INVOICE REFERENCE") && title.Contains("BILLER NAME") && title.Contains("PAYER NAME"));
                Assert.IsTrue(title.Contains("IS PAYER EXTERNAL") && title.Contains("INVOICE VALUE") && title.Contains("CASH STATUS") && title.Contains("VERIFIED TIMESTAMP") && title.Contains("TOGGLE VERIFICATION") && title.Contains("VIEW PDF") && title.Contains("INVOICE STATUS") && title.Contains("MARK INVOICE AS PAID"));
                //testInfo = Invoice has NO Deal nor CASH and NOT yet verified


                
                string data77 = Bobopg.CashStatus().Text;
                string data88 = Bobopg.VerifiedTimeStamp().Text;
                
                bool unverifybtn1 = Bobopg.UnverifyBTNEnabled().Displayed;
                

                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(unverifybtn1 == true && data77.Contains("PENDING APPROVAL") && data88.Contains("Verified"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.UnverifyBTNEnabled().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                string verifystatus1 = Bobopg.VerifiedTimeStamp().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(verifystatus1.Contains("Unverified"));
                bool verifybtn1 = Bobopg.VerifyBTNEnabled().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(verifybtn1 == true);
                Bobopg.MarkAsPaidEnabled().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Bobopg.MAPYes().Click();
                SeleniumSetMethods.WaitOnPage(secdelay8);
                bool Markaspaiddisabled2 = Bobopg.MarkAsPaidDisabled().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Markaspaiddisabled2 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                //homepg.SignOutBTN().Click();

            }
            finally
            {
               

            }
        }

        /*
        Script Description : BOBO User marking the noraml invoice as paid
       */

        [Test]
        public void BOBO09_UpdateExistingBillzyInvoice_MarkAsPaid01_NormalInvoice()
        {
            BOBOPage Bobopg = new BOBOPage(WebDriver);
            HomePage homepg = new HomePage(WebDriver);
            SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
            IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
            SendPage SendPg = new SendPage(WebDriver);
            SIVPage SIVPG1 = new SIVPage(WebDriver);
            LoginPage loginPage = new LoginPage(WebDriver);
            ReceivedPage Recpg = new ReceivedPage(WebDriver);
            PayNowPage Paynwpg = new PayNowPage(WebDriver);
            try
            {

                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+gstfdrbiller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                String PaymentTerms = "90 days";
                SeleniumSetMethods.WaitOnPage(secdelay7);
                DateTime dt2 = new DateTime();
                Random rand = new Random();
                string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber2 = rand.Next();
                var invnum = new List<string> { "UNPAID", "PAIDDD", "PAIDCC", "MAP", "DELETE" };
                for (int i = invnum.Count - 1; i >= 0; i--)
                //for (int i = 0; i < 20; i++)
                {
                                     
                    SeleniumSetMethods.WaitOnPage(secdelay9);
                    IssueInvoicePg.IssueInvoiceButton().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    IssueInvoicePg.BusinessName().Click();
                    IssueInvoicePg.BusinessName().SendKeys("manualtestdemob+gstfdrpayer");
                    IssueInvoicePg.SelectBusiness().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                    IssueInvoicePg.CreateInvoice().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    IssueInvoicePg.InvoiceReferenceCreate().SendKeys("BOBOMAP" + invnum[i] + "3149" + randnumber2);
                    IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                    IssueInvoicePg.LineItemAmount().SendKeys("100");
                    IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                    SeleniumSetMethods.WaitOnPage(secdelay1);
                    IssueInvoicePg.SurchargeCheckbox().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    IssueInvoicePg.SendInvoiceBTN().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay5);
                    string outstandingtext = SendPg.SentHistoryBTN().Text;
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    Assert.IsTrue(outstandingtext.Contains("History"));
                    Console.WriteLine(i);

                }
                //Issue invoice to external payer
                SeleniumSetMethods.WaitOnPage(secdelay9);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("External1");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("BOBOMAPExternal3149" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("BOBOMAPExternal3149" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber5 = SIVPG1.InvNumber().Text;
                string invoicenumber5 = invnumber5.Substring(invnumber5.IndexOf("Invoice ")).Replace("Invoice ", "");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SendPg.SearchInvoiceSent().SendKeys("BOBOMAPDELETE3149" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber4 = SIVPG1.InvNumber().Text;
                string invoicenumber4 = invnumber4.Substring(invnumber4.IndexOf("Invoice ")).Replace("Invoice ", "");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ActionDropdownDelete().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.DeleteComment().SendKeys("Biller deleted invoice - UNPAID");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ConfirmDeleteBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                homepg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SendPg.SearchInvoiceSent().SendKeys("BOBOMAPMAP3149" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber3 = SIVPG1.InvNumber().Text;
                string invoicenumber3 = invnumber3.Substring(invnumber3.IndexOf("Invoice ")).Replace("Invoice ", "");
                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ActionDropdownMarkAsPaid().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.MarkAsPaidBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                homepg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SendPg.SearchInvoiceSent().SendKeys("BOBOMAPPAIDCC3149" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber2 = SIVPG1.InvNumber().Text;
                string invoicenumber2 = invnumber2.Substring(invnumber2.IndexOf("Invoice ")).Replace("Invoice ", "");
                homepg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SendPg.SearchInvoiceSent().SendKeys("BOBOMAPPAIDDD3149" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber1 = SIVPG1.InvNumber().Text;
                string invoicenumber1 = invnumber1.Substring(invnumber1.IndexOf("Invoice ")).Replace("Invoice ", "");
                homepg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SendPg.SearchInvoiceSent().SendKeys("BOBOMAPUNPAID3149" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay6);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber0 = SIVPG1.InvNumber().Text;
                string invoicenumber0 = invnumber0.Substring(invnumber0.IndexOf("Invoice ")).Replace("Invoice ", "");
                homepg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                homepg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                // Make payments for the invoices through credit card and Bank
                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+gstfdrpayer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                homepg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                // Payment through CC
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                Recpg.SelectInvoiceRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.PayBTNTop().Click();
                SeleniumSetMethods.WaitOnPage(secdelay6);
                Paynwpg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Paynwpg.CardRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Paynwpg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paynwpg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                // Payment through Bank
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber1);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                Recpg.SelectInvoiceRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.PayBTNTop().Click();
                SeleniumSetMethods.WaitOnPage(secdelay6);
                Paynwpg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Paynwpg.CardRow02().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Paynwpg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paynwpg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                homepg.SignOutBTN().Click();
                // Mark as paid throguh bobo connect
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
                Bobopg.UpdateExistingBillzyInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                
                Bobopg.SelectBusiness().SendKeys("manualtestdemob+gstfdrbiller");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                // Internal unpaid normal invoices
                Bobopg.InputInvoice().SendKeys(invoicenumber0);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.SearchBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.MarkAsPaidEnabled().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Bobopg.MAPYes().Click();
                SeleniumSetMethods.WaitOnPage(secdelay8);
                bool Markaspaiddisabled0 = Bobopg.MarkAsPaidDisabled().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Markaspaiddisabled0 == true);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Bobopg.InputInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.InputInvoice().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                // External upaid noraml invoices
                Bobopg.InputInvoice().SendKeys(invoicenumber5);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.SearchBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.MarkAsPaidEnabled().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Bobopg.MAPYes().Click();
                SeleniumSetMethods.WaitOnPage(secdelay8);
                bool Markaspaiddisabled5 = Bobopg.MarkAsPaidDisabled().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Markaspaiddisabled5 == true);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Bobopg.InputInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.InputInvoice().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                
                // invoice paid through card
                Bobopg.InputInvoice().SendKeys(invoicenumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.SearchBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool Markaspaiddisabled2 = Bobopg.MarkAsPaidDisabled().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Markaspaiddisabled2 == true);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.InputInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.InputInvoice().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                //Invoice marked as paid by the biller
                Bobopg.InputInvoice().SendKeys(invoicenumber3);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.SearchBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool Markaspaiddisabled3 = Bobopg.MarkAsPaidDisabled().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Markaspaiddisabled3 == true);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.InputInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.InputInvoice().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                // Invoices deleted by the biller
                Bobopg.InputInvoice().SendKeys(invoicenumber4);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.SearchBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool Markaspaiddisabled4 = Bobopg.MarkAsPaidDisabled().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Markaspaiddisabled4 == true);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.InputInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.InputInvoice().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                // Invoice paid through Bank

                Bobopg.InputInvoice().SendKeys(invoicenumber1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.SearchBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.MarkAsPaidEnabled().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Bobopg.MAPYes().Click();
                SeleniumSetMethods.WaitOnPage(secdelay8);
                bool Markaspaiddisabled1 = Bobopg.MarkAsPaidDisabled().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Markaspaiddisabled1 == true);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.InputInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.InputInvoice().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);


            }


            finally
            {


            }
        }
        /*
    Script Description : BOBO User marking the cash invoice as paid
   */

        [Test]
        public void BOBO10_UpdateExistingBillzyInvoice_MarkAsPaid02_CashInvoice()
        {
            BOBOPage Bobopg = new BOBOPage(WebDriver);
            HomePage homepg = new HomePage(WebDriver);
            SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
            IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
            SendPage SendPg = new SendPage(WebDriver);
            SIVPage SIVPG1 = new SIVPage(WebDriver);
            LoginPage loginPage = new LoginPage(WebDriver);
            ReceivedPage Recpg = new ReceivedPage(WebDriver);
            PayNowPage Paynwpg = new PayNowPage(WebDriver);
            try
            {

                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+gstfdrbiller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                String PaymentTerms = "90 days";
                SeleniumSetMethods.WaitOnPage(secdelay7);
                DateTime dt2 = new DateTime();
                Random rand = new Random();
                string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber2 = rand.Next();
                var invnum = new List<string> { "Requested", "Approved", "Declined", "Paid", "Processing" };
                for (int i = invnum.Count - 1; i >= 0; i--)
                //for (int i = 0; i < 20; i++)
                {

                    //Internal Cash    Yes Requested   CC 01INTSURCASHREQCC@
                    SeleniumSetMethods.WaitOnPage(secdelay9);
                    IssueInvoicePg.IssueInvoiceButton().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    IssueInvoicePg.BusinessName().Click();
                    IssueInvoicePg.BusinessName().SendKeys("manualtestdemob+gstfdrpayer");
                    IssueInvoicePg.SelectBusiness().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                    IssueInvoicePg.CreateInvoice().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    IssueInvoicePg.InvoiceReferenceCreate().SendKeys("BOBOMAP" + invnum[i] + "3149" + randnumber2);
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
                    string outstandingtext = SendPg.SentHistoryBTN().Text;
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    Assert.IsTrue(outstandingtext.Contains("History"));
                    Console.WriteLine(i);

                }

                SendPg.SearchInvoiceSent().SendKeys("BOBOMAPRequested3149" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber4 = SIVPG1.InvNumber().Text;
                string invoicenumber4 = invnumber4.Substring(invnumber4.IndexOf("Invoice ")).Replace("Invoice ", "");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                homepg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SendPg.SearchInvoiceSent().SendKeys("BOBOMAPApproved3149" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber3 = SIVPG1.InvNumber().Text;
                string invoicenumber3 = invnumber3.Substring(invnumber3.IndexOf("Invoice ")).Replace("Invoice ", "");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                homepg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SendPg.SearchInvoiceSent().SendKeys("BOBOMAPDeclined3149" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber2 = SIVPG1.InvNumber().Text;
                string invoicenumber2 = invnumber2.Substring(invnumber2.IndexOf("Invoice ")).Replace("Invoice ", "");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                homepg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SendPg.SearchInvoiceSent().SendKeys("BOBOMAPPaid3149" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber1 = SIVPG1.InvNumber().Text;
                string invoicenumber1 = invnumber1.Substring(invnumber1.IndexOf("Invoice ")).Replace("Invoice ", "");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                homepg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SendPg.SearchInvoiceSent().SendKeys("BOBOMAPProcessing3149" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber0 = SIVPG1.InvNumber().Text;
                string invoicenumber0 = invnumber0.Substring(invnumber0.IndexOf("Invoice ")).Replace("Invoice ", "");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                homepg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                homepg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                addrecord(invoicenumber0, "approved", "FDRFactorFox.csv");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                addrecord(invoicenumber1, "approved", "FDRFactorFox.csv");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                addrecord(invoicenumber3, "approved", "FDRFactorFox.csv");
                SeleniumSetMethods.WaitOnPage(secdelay1);

                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("billzydemo+financial-controller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
               

           IWebElement DeclineButton1 = WebDriver.FindElement(By.XPath("//td[text()=\"" + invoicenumber2 + "\"]/../td/button[text()=\"decline\"]"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                DeclineButton1.Click();
                //HomePg.Declinebtn().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                IAlert alert1 = WebDriver.SwitchTo().Alert();
                alert1.Accept();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                alert1.Accept();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                alert1.Accept();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                homepg.Uploadfactorfox().SendKeys(@"C:\Users\Selenium\Desktop\SeleniumRegressionSuite_Bamboo\bin\Debug\netcoreapp3.1\FDRFactorFox.csv");

                SeleniumSetMethods.WaitOnPage(secdelay9);
                IAlert alert2 = WebDriver.SwitchTo().Alert();
                alert2.Accept();
                SeleniumSetMethods.WaitOnPage(secdelay9);
                var invset1 = new List<string> { invoicenumber0, invoicenumber1, invoicenumber3 };
                
                for (int i = invset1.Count - 1; i >= 0; i--)
                {

                    IWebElement ApproveButton1 = WebDriver.FindElement(By.XPath("//td[text()=\"" + invset1[i] + "\"]/../td/button[text()=\"approve\"]"));
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    ApproveButton1.Click();
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    homepg.Cashratesubmit().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    IAlert alert3 = WebDriver.SwitchTo().Alert();
                    SeleniumSetMethods.WaitOnPage(secdelay5);
                    alert3.Accept();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                }

                homepg.FCLogout().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+gstfdrpayer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay9);
                //paid by CC for paid status
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber1);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                Recpg.SelectInvoiceRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.PayBTNTop().Click();
                SeleniumSetMethods.WaitOnPage(secdelay6);
                Paynwpg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Paynwpg.CardRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Paynwpg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paynwpg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                // paid by bank for processing status
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber0);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                Recpg.SelectInvoiceRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.PayBTNTop().Click();
                SeleniumSetMethods.WaitOnPage(secdelay6);
                Paynwpg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Paynwpg.CardRow02().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Paynwpg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paynwpg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                homepg.SignOutBTN().Click();

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
                Bobopg.UpdateExistingBillzyInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                Bobopg.SelectBusiness().SendKeys("manualtestdemob+gstfdrbiller");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                // invoice with Cash reqested status
                Bobopg.InputInvoice().SendKeys(invoicenumber4);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.SearchBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.MarkAsPaidEnabled().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Bobopg.MAPYes().Click();
                SeleniumSetMethods.WaitOnPage(secdelay8);
                bool Markaspaiddisabled0 = Bobopg.MarkAsPaidDisabled().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Markaspaiddisabled0 == true);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Bobopg.InputInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.InputInvoice().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                // invoice with cash approved status
                Bobopg.InputInvoice().SendKeys(invoicenumber3);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.SearchBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.MarkAsPaidEnabled().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Bobopg.MAPYes().Click();
                SeleniumSetMethods.WaitOnPage(secdelay8);
                bool Markaspaiddisabled3 = Bobopg.MarkAsPaidDisabled().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Markaspaiddisabled3 == true);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Bobopg.InputInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.InputInvoice().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                // invoice with cash approved status
                Bobopg.InputInvoice().SendKeys(invoicenumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.SearchBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.MarkAsPaidEnabled().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Bobopg.MAPYes().Click();
                SeleniumSetMethods.WaitOnPage(secdelay8);
                bool Markaspaiddisabled2 = Bobopg.MarkAsPaidDisabled().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Markaspaiddisabled2 == true);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Bobopg.InputInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.InputInvoice().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);
               
                // invoice with cash approved and  paid status
                Bobopg.InputInvoice().SendKeys(invoicenumber1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.SearchBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool Markaspaiddisabled1 = Bobopg.MarkAsPaidDisabled().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Markaspaiddisabled1 == true);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.InputInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.InputInvoice().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);

                // invoices with cash approved and processing status
                Bobopg.InputInvoice().SendKeys(invoicenumber0);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.SearchBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.MarkAsPaidEnabled().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Bobopg.MAPYes().Click();
                SeleniumSetMethods.WaitOnPage(secdelay8);
                bool Markaspaiddisabled00 = Bobopg.MarkAsPaidDisabled().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Markaspaiddisabled00 == true);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.InputInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.InputInvoice().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);

            }


            finally
            {


            }
        }
        /*
            Script Description : BOBO User marking the deal invoice as paid
           */

        [Test]
        public void BOBO11_UpdateExistingBillzyInvoice_MarkAsPaid03_DealInvoice()
        {
            BOBOPage Bobopg = new BOBOPage(WebDriver);
            HomePage homepg = new HomePage(WebDriver);
            SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
            IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
            SendPage SendPg = new SendPage(WebDriver);
            SIVPage SIVPG1 = new SIVPage(WebDriver);
            LoginPage loginPage = new LoginPage(WebDriver);
            ReceivedPage Recpg = new ReceivedPage(WebDriver);
            PayNowPage Paynwpg = new PayNowPage(WebDriver);
            try
            {

                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+gstfdrbiller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                String PaymentTerms = "90 days";
                SeleniumSetMethods.WaitOnPage(secdelay7);
                DateTime dt2 = new DateTime();
                Random rand = new Random();
                string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber2 = rand.Next();
                DateTime newDate = DateTime.Now.AddDays(15);
                string dtString3 = newDate.ToString("dd/MM/yyyy");
                string dtString4 = newDate.ToString("dd/MM/yy");
                
                //Internal Cash    Yes Requested   CC 01INTSURCASHREQCC@
                SeleniumSetMethods.WaitOnPage(secdelay9);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                    IssueInvoicePg.BusinessName().Click();
                    IssueInvoicePg.BusinessName().SendKeys("manualtestdemob+gstfdrpayer");
                    IssueInvoicePg.SelectBusiness().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                    IssueInvoicePg.CreateInvoice().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    IssueInvoicePg.InvoiceReferenceCreate().SendKeys("BOBOMAPDealSent"+ randnumber2);
                    IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                    IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                    IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                    SeleniumSetMethods.WaitOnPage(secdelay1);
                    IssueInvoicePg.BillzyDealBTN().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.NewTotal().SendKeys("319.82");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.OfferExpiry().Clear();
                IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Comments().SendKeys("Biller created deal");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                    IssueInvoicePg.SurchargeCheckbox().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    IssueInvoicePg.SendInvoiceBTN().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().Click();
               SendPg.SearchInvoiceSent().SendKeys("BOBOMAPDealSent" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber1 = SIVPG1.InvNumber().Text;
                string invoicenumber1 = invnumber1.Substring(invnumber1.IndexOf("Invoice ")).Replace("Invoice ", "");
                SeleniumSetMethods.WaitOnPage(secdelay2);

                //Offer received

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("manualtestdemob+gstfdrpayer");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("BOBOMAPDealReceived" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.NewTotal().SendKeys("319.82");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.OfferExpiry().Clear();
                IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Comments().SendKeys("Biller created deal");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("BOBOMAPDealReceived" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber2 = SIVPG1.InvNumber().Text;
                string invoicenumber2 = invnumber2.Substring(invnumber2.IndexOf("Invoice ")).Replace("Invoice ", "");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                homepg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+gstfdrpayer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                homepg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SIVPG1.PayerMakeACounterOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                DateTime duedate000 = DateTime.Today.AddDays(5);
                string SentPgDueDate2 = duedate000.ToString("dd/MM/yyyy");
                SIVPG1.NewTotal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.NewTotal().SendKeys("208.82");
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
                homepg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);


                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+gstfdrbiller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("manualtestdemob+gstfdrpayer");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("BOBOMAPDealApprove" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.NewTotal().SendKeys("319.82");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.OfferExpiry().Clear();
                IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Comments().SendKeys("Biller created deal");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("BOBOMAPDealApprove" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber3 = SIVPG1.InvNumber().Text;
                string invoicenumber3 = invnumber3.Substring(invnumber3.IndexOf("Invoice ")).Replace("Invoice ", "");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                homepg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+gstfdrpayer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                homepg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber3);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SIVPG1.PayerMakeACounterOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.NewTotal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.NewTotal().SendKeys("208.82");
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
                homepg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+gstfdrbiller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                homepg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys(invoicenumber3);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SIVPG1.AcceptOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.AcceptTheOfferModalYesBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

                //Offer Decline

                SeleniumSetMethods.WaitOnPage(secdelay7);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("manualtestdemob+gstfdrpayer");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("BOBOMAPDealDecline" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.NewTotal().SendKeys("319.82");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.OfferExpiry().Clear();
                IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Comments().SendKeys("Biller created deal");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("BOBOMAPDealDecline" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber4 = SIVPG1.InvNumber().Text;
                string invoicenumber4 = invnumber4.Substring(invnumber4.IndexOf("Invoice ")).Replace("Invoice ", "");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                homepg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+gstfdrpayer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                homepg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber4);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SIVPG1.PayerMakeACounterOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.NewTotal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.NewTotal().SendKeys("208.82");
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
                homepg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+gstfdrbiller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                homepg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys(invoicenumber4);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.DeclineOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.DeclineOfferModalYes().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                //Offer Paid

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("manualtestdemob+gstfdrpayer");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("BOBOMAPDealpaid" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.NewTotal().SendKeys("319.82");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.OfferExpiry().Clear();
                IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Comments().SendKeys("Biller created deal");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("BOBOMAPDealpaid" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber5 = SIVPG1.InvNumber().Text;
                string invoicenumber5 = invnumber5.Substring(invnumber5.IndexOf("Invoice ")).Replace("Invoice ", "");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                homepg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+gstfdrpayer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                homepg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber5);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.SelectInvoiceRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.PayBTNTop().Click();
                SeleniumSetMethods.WaitOnPage(secdelay6);
                Paynwpg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Paynwpg.CardRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Paynwpg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paynwpg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);



                homepg.SignOutBTN().Click();

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
                Bobopg.UpdateExistingBillzyInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                Bobopg.SelectBusiness().SendKeys("manualtestdemob+gstfdrbiller");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //invoice with offer sent status
                Bobopg.InputInvoice().SendKeys(invoicenumber1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.SearchBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.MarkAsPaidEnabled().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Bobopg.MAPYes().Click();
                SeleniumSetMethods.WaitOnPage(secdelay8);
                bool Markaspaiddisabled0 = Bobopg.MarkAsPaidDisabled().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Markaspaiddisabled0 == true);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Bobopg.InputInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.InputInvoice().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                // invoice with offer received status
                Bobopg.InputInvoice().SendKeys(invoicenumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.SearchBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.MarkAsPaidEnabled().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Bobopg.MAPYes().Click();
                SeleniumSetMethods.WaitOnPage(secdelay8);
                bool Markaspaiddisabled2 = Bobopg.MarkAsPaidDisabled().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Markaspaiddisabled2 == true);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Bobopg.InputInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.InputInvoice().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                // invoices with offer accepted status
                Bobopg.InputInvoice().SendKeys(invoicenumber3);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.SearchBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.MarkAsPaidEnabled().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Bobopg.MAPYes().Click();
                SeleniumSetMethods.WaitOnPage(secdelay8);
                bool Markaspaiddisabled3 = Bobopg.MarkAsPaidDisabled().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Markaspaiddisabled3 == true);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Bobopg.InputInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.InputInvoice().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                // invoices with offer declined status
                Bobopg.InputInvoice().SendKeys(invoicenumber4);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.SearchBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.MarkAsPaidEnabled().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Bobopg.MAPYes().Click();
                SeleniumSetMethods.WaitOnPage(secdelay8);
                bool Markaspaiddisabled4 = Bobopg.MarkAsPaidDisabled().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Markaspaiddisabled4 == true);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Bobopg.InputInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.InputInvoice().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                // invocies with offer paid through credit card
                Bobopg.InputInvoice().SendKeys(invoicenumber5);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.SearchBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool Markaspaiddisabled5 = Bobopg.MarkAsPaidDisabled().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Markaspaiddisabled5 == true);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Bobopg.InputInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.InputInvoice().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);

            }


            finally
            {


            }
        }


       

        /*
       Script Description : BOBO User checks whether Mark as Paid option is available for Normal Unpaid, Paid, Processing, Delete and biller Mark as Paid invoices
      */

        [Test]
        public void BOBO12_UpdateExistingBillzyInvoice_Delete01_NormalInvoice()
        {
            BOBOPage Bobopg = new BOBOPage(WebDriver);
            HomePage homepg = new HomePage(WebDriver);
            SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
            IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
            SendPage SendPg = new SendPage(WebDriver);
            SIVPage SIVPG1 = new SIVPage(WebDriver);
            LoginPage loginPage = new LoginPage(WebDriver);
            ReceivedPage Recpg = new ReceivedPage(WebDriver);
            PayNowPage Paynwpg = new PayNowPage(WebDriver);
            try
            {

                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+gstfdrbiller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                String PaymentTerms = "90 days";
                SeleniumSetMethods.WaitOnPage(secdelay7);
                DateTime dt2 = new DateTime();
                Random rand = new Random();
                string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber2 = rand.Next();
                var invnum = new List<string> { "UNPAID", "PAIDDD", "PAIDCC", "MAP", "DELETE" };
                for (int i = invnum.Count - 1; i >= 0; i--)
                //for (int i = 0; i < 20; i++)
                {

                    SeleniumSetMethods.WaitOnPage(secdelay9);
                    IssueInvoicePg.IssueInvoiceButton().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    IssueInvoicePg.BusinessName().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay1);
                    IssueInvoicePg.BusinessName().SendKeys("manualtestdemob+gstfdrpayer");
                    SeleniumSetMethods.WaitOnPage(secdelay1);
                    IssueInvoicePg.SelectBusiness().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                    IssueInvoicePg.CreateInvoice().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    IssueInvoicePg.InvoiceReferenceCreate().SendKeys("BOBODEL" + invnum[i] + "3149" + randnumber2);
                    IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                    IssueInvoicePg.LineItemAmount().SendKeys("100");
                    IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                    SeleniumSetMethods.WaitOnPage(secdelay1);
                    IssueInvoicePg.SurchargeCheckbox().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    IssueInvoicePg.SendInvoiceBTN().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay5);
                    string outstandingtext = SendPg.SentHistoryBTN().Text;
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    Assert.IsTrue(outstandingtext.Contains("History"));
                    Console.WriteLine(i);

                }
                //Issue invoice to external payer
                SeleniumSetMethods.WaitOnPage(secdelay9);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("External1");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("BOBODELExternal3149" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("BOBODELExternal3149" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber5 = SIVPG1.InvNumber().Text;
                string invoicenumber5 = invnumber5.Substring(invnumber5.IndexOf("Invoice ")).Replace("Invoice ", "");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SendPg.SearchInvoiceSent().SendKeys("BOBODELDELETE3149" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber4 = SIVPG1.InvNumber().Text;
                string invoicenumber4 = invnumber4.Substring(invnumber4.IndexOf("Invoice ")).Replace("Invoice ", "");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ActionDropdownDelete().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.DeleteComment().SendKeys("Biller deleted invoice - UNPAID");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ConfirmDeleteBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                homepg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SendPg.SearchInvoiceSent().SendKeys("BOBODELMAP3149" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber3 = SIVPG1.InvNumber().Text;
                string invoicenumber3 = invnumber3.Substring(invnumber3.IndexOf("Invoice ")).Replace("Invoice ", "");
                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ActionDropdownMarkAsPaid().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.MarkAsPaidBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                homepg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SendPg.SearchInvoiceSent().SendKeys("BOBODELPAIDCC3149" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber2 = SIVPG1.InvNumber().Text;
                string invoicenumber2 = invnumber2.Substring(invnumber2.IndexOf("Invoice ")).Replace("Invoice ", "");
                homepg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SendPg.SearchInvoiceSent().SendKeys("BOBODELPAIDDD3149" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber1 = SIVPG1.InvNumber().Text;
                string invoicenumber1 = invnumber1.Substring(invnumber1.IndexOf("Invoice ")).Replace("Invoice ", "");
                homepg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SendPg.SearchInvoiceSent().SendKeys("BOBODELUNPAID3149" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber0 = SIVPG1.InvNumber().Text;
                string invoicenumber0 = invnumber0.Substring(invnumber0.IndexOf("Invoice ")).Replace("Invoice ", "");
                homepg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                homepg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                // Make payments for the invoices through credit card and Bank
                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+gstfdrpayer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                homepg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                // Payment through CC
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                Recpg.SelectInvoiceRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.PayBTNTop().Click();
                SeleniumSetMethods.WaitOnPage(secdelay6);
                Paynwpg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Paynwpg.CardRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Paynwpg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paynwpg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                // Payment through Bank
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber1);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                Recpg.SelectInvoiceRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.PayBTNTop().Click();
                SeleniumSetMethods.WaitOnPage(secdelay6);
                Paynwpg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Paynwpg.CardRow02().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Paynwpg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paynwpg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                homepg.SignOutBTN().Click();
                // Mark as paid throguh bobo connect
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
                Bobopg.UpdateExistingBillzyInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                Bobopg.SelectBusiness().SendKeys("manualtestdemob+gstfdrbiller");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                // Internal unpaid normal invoices
                Bobopg.InputInvoice().SendKeys(invoicenumber0);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.SearchBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.DeleteEnabled().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Bobopg.DeleteYes().Click();
                SeleniumSetMethods.WaitOnPage(secdelay8);
                bool DeleteDisabled = Bobopg.DeleteDisabled().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(DeleteDisabled == true);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Bobopg.InputInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.InputInvoice().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                // External upaid noraml invoices
                Bobopg.InputInvoice().SendKeys(invoicenumber5);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.SearchBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.DeleteEnabled().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Bobopg.DeleteYes().Click();
                SeleniumSetMethods.WaitOnPage(secdelay8);
                bool DeleteDisabled5 = Bobopg.DeleteDisabled().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(DeleteDisabled5 == true);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Bobopg.InputInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.InputInvoice().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);

                // invoice paid through card
                Bobopg.InputInvoice().SendKeys(invoicenumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.SearchBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool DeleteEnabled2 = Bobopg.DeleteDisabled().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(DeleteEnabled2 == true);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.InputInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.InputInvoice().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                //Invoice marked as paid by the biller
                Bobopg.InputInvoice().SendKeys(invoicenumber3);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.SearchBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool DeleteEnabled3 = Bobopg.DeleteDisabled().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(DeleteEnabled3 == true);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.InputInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.InputInvoice().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                // Invoices deleted by the biller
                Bobopg.InputInvoice().SendKeys(invoicenumber4);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.SearchBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool DeleteDisabled4 = Bobopg.DeleteDisabled().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(DeleteDisabled4 == true);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.InputInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.InputInvoice().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                // Invoice paid through Bank

                Bobopg.InputInvoice().SendKeys(invoicenumber1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.SearchBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool DeleteDisabled1 = Bobopg.DeleteDisabled().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(DeleteDisabled1 == true);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.InputInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.InputInvoice().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);


            }


            finally
            {


            }
        }

        /*
         Script Description : BOBO User deletes the cash invoice
        */

        [Test]
        public void BOBO13_UpdateExistingBillzyInvoice_Delete02_CashInvoice()
        {
            BOBOPage Bobopg = new BOBOPage(WebDriver);
            HomePage homepg = new HomePage(WebDriver);
            SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
            IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
            SendPage SendPg = new SendPage(WebDriver);
            SIVPage SIVPG1 = new SIVPage(WebDriver);
            LoginPage loginPage = new LoginPage(WebDriver);
            ReceivedPage Recpg = new ReceivedPage(WebDriver);
            PayNowPage Paynwpg = new PayNowPage(WebDriver);
            try
            {

                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+gstfdrbiller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                String PaymentTerms = "90 days";
                SeleniumSetMethods.WaitOnPage(secdelay7);
                DateTime dt2 = new DateTime();
                Random rand = new Random();
                string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber2 = rand.Next();
                var invnum = new List<string> { "Requested", "Approved", "Declined", "Paid", "Processing" };
                for (int i = invnum.Count - 1; i >= 0; i--)
                //for (int i = 0; i < 20; i++)
                {

                    //Internal Cash    Yes Requested   CC 01INTSURCASHREQCC@
                    SeleniumSetMethods.WaitOnPage(secdelay9);
                    IssueInvoicePg.IssueInvoiceButton().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    IssueInvoicePg.BusinessName().Click();
                    IssueInvoicePg.BusinessName().SendKeys("manualtestdemob+gstfdrpayer");
                    IssueInvoicePg.SelectBusiness().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                    IssueInvoicePg.CreateInvoice().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    IssueInvoicePg.InvoiceReferenceCreate().SendKeys("BOBOMAP" + invnum[i] + "3149" + randnumber2);
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
                    string outstandingtext = SendPg.SentHistoryBTN().Text;
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    Assert.IsTrue(outstandingtext.Contains("History"));
                    Console.WriteLine(i);

                }

                SendPg.SearchInvoiceSent().SendKeys("BOBOMAPRequested3149" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay6);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber4 = SIVPG1.InvNumber().Text;
                string invoicenumber4 = invnumber4.Substring(invnumber4.IndexOf("Invoice ")).Replace("Invoice ", "");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                homepg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("BOBOMAPApproved3149" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber3 = SIVPG1.InvNumber().Text;
                string invoicenumber3 = invnumber3.Substring(invnumber3.IndexOf("Invoice ")).Replace("Invoice ", "");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                homepg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("BOBOMAPDeclined3149" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber2 = SIVPG1.InvNumber().Text;
                string invoicenumber2 = invnumber2.Substring(invnumber2.IndexOf("Invoice ")).Replace("Invoice ", "");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                homepg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("BOBOMAPPaid3149" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber1 = SIVPG1.InvNumber().Text;
                string invoicenumber1 = invnumber1.Substring(invnumber1.IndexOf("Invoice ")).Replace("Invoice ", "");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                homepg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("BOBOMAPProcessing3149" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber0 = SIVPG1.InvNumber().Text;
                string invoicenumber0 = invnumber0.Substring(invnumber0.IndexOf("Invoice ")).Replace("Invoice ", "");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                homepg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                homepg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                addrecord(invoicenumber0, "approved", "FDRFactorFox.csv");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                addrecord(invoicenumber1, "approved", "FDRFactorFox.csv");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                addrecord(invoicenumber3, "approved", "FDRFactorFox.csv");
                SeleniumSetMethods.WaitOnPage(secdelay1);

                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("billzydemo+financial-controller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                IWebElement DeclineButton1 = WebDriver.FindElement(By.XPath("//td[text()=\"" + invoicenumber2 + "\"]/../td/button[text()=\"decline\"]"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                DeclineButton1.Click();
                //HomePg.Declinebtn().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                IAlert alert1 = WebDriver.SwitchTo().Alert();
                alert1.Accept();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                alert1.Accept();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                alert1.Accept();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                homepg.Uploadfactorfox().SendKeys(@"C:\Users\Selenium\Desktop\SeleniumRegressionSuite_Bamboo\bin\Debug\netcoreapp3.1\FDRFactorFox.csv");

                SeleniumSetMethods.WaitOnPage(12);
                IAlert alert2 = WebDriver.SwitchTo().Alert();
                alert2.Accept();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                var invset1 = new List<string> { invoicenumber0, invoicenumber1, invoicenumber3 };
                for (int i = invset1.Count - 1; i >= 0; i--)
                {

                    IWebElement ApproveButton1 = WebDriver.FindElement(By.XPath("//td[text()=\"" + invset1[i] + "\"]/../td/button[text()=\"approve\"]"));
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    ApproveButton1.Click();
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    homepg.Cashratesubmit().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay7);
                    IAlert alert3 = WebDriver.SwitchTo().Alert();
                    SeleniumSetMethods.WaitOnPage(secdelay5);
                    alert3.Accept();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                }

                homepg.FCLogout().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+gstfdrpayer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay9);
                //paid by CC for paid status
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber1);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                Recpg.SelectInvoiceRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.PayBTNTop().Click();
                SeleniumSetMethods.WaitOnPage(secdelay6);
                Paynwpg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Paynwpg.CardRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Paynwpg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paynwpg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                // paid by bank for processing status
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber0);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                Recpg.SelectInvoiceRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.PayBTNTop().Click();
                SeleniumSetMethods.WaitOnPage(secdelay6);
                Paynwpg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Paynwpg.CardRow02().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Paynwpg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paynwpg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);

                homepg.SignOutBTN().Click();

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
                Bobopg.UpdateExistingBillzyInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                Bobopg.SelectBusiness().SendKeys("manualtestdemob+gstfdrbiller");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                // invoice with Cash reqested status
                Bobopg.InputInvoice().SendKeys(invoicenumber4);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.SearchBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.DeleteEnabled().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));
                bool decline1 = bodyTag.Text.Contains("You cannot delete the invoice. Decline the cash request first.");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(decline1 == true );
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.DeletecashCancel().Click();
                SeleniumSetMethods.WaitOnPage(secdelay8);
                Bobopg.InputInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.InputInvoice().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                // invoice with cash approved status
                Bobopg.InputInvoice().SendKeys(invoicenumber3);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.SearchBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.DeleteEnabled().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                IWebElement bodyTag1 = WebDriver.FindElement(By.TagName("body"));
                bool decline11 = bodyTag1.Text.Contains("You cannot delete the invoice. Decline the cash request first.");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(decline11 == true);
                Bobopg.DeletecashCancel().Click();
                SeleniumSetMethods.WaitOnPage(secdelay8);
                Bobopg.InputInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.InputInvoice().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                // invoice with cash declined status
                Bobopg.InputInvoice().SendKeys(invoicenumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.SearchBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.DeleteEnabled().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                IWebElement bodyTag2 = WebDriver.FindElement(By.TagName("body"));
                bool decline12 = bodyTag2.Text.Contains("You cannot delete the invoice. Decline the cash request first.");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(decline12 == false);
                Bobopg.DeleteYes().Click();
                SeleniumSetMethods.WaitOnPage(secdelay8);               
                Bobopg.InputInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.InputInvoice().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                // invoices with cash approved and processing status
                Bobopg.InputInvoice().SendKeys(invoicenumber0);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.SearchBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool DeleteDisabled00 = Bobopg.DeleteDisabled().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(DeleteDisabled00 == true);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.InputInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.InputInvoice().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                // invoice with cash approved and  paid status
                Bobopg.InputInvoice().SendKeys(invoicenumber1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.SearchBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool DeleteDisabled1 = Bobopg.DeleteDisabled().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(DeleteDisabled1 == true);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.InputInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.InputInvoice().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);

            }


            finally
            {


            }
        }

        /*
         Script Description : BOBO User deletes the deal invoice
        */

        [Test]
        public void BOBO14_UpdateExistingBillzyInvoice_Delete03_DealInvoice()
        {
            BOBOPage Bobopg = new BOBOPage(WebDriver);
            HomePage homepg = new HomePage(WebDriver);
            SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
            IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
            SendPage SendPg = new SendPage(WebDriver);
            SIVPage SIVPG1 = new SIVPage(WebDriver);
            LoginPage loginPage = new LoginPage(WebDriver);
            ReceivedPage Recpg = new ReceivedPage(WebDriver);
            PayNowPage Paynwpg = new PayNowPage(WebDriver);
            try
            {

                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+gstfdrbiller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                String PaymentTerms = "90 days";
                SeleniumSetMethods.WaitOnPage(secdelay7);
                DateTime dt2 = new DateTime();
                Random rand = new Random();
                string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber2 = rand.Next();
                DateTime newDate = DateTime.Now.AddDays(15);
                string dtString3 = newDate.ToString("dd/MM/yyyy");
                string dtString4 = newDate.ToString("dd/MM/yy");

                //Internal Cash    Yes Requested   CC 01INTSURCASHREQCC@
                SeleniumSetMethods.WaitOnPage(secdelay9);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("manualtestdemob+gstfdrpayer");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("BOBOMAPDealSent" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.NewTotal().SendKeys("319.82");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.OfferExpiry().Clear();
                IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Comments().SendKeys("Biller created deal");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("BOBOMAPDealSent" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber1 = SIVPG1.InvNumber().Text;
                string invoicenumber1 = invnumber1.Substring(invnumber1.IndexOf("Invoice ")).Replace("Invoice ", "");
                SeleniumSetMethods.WaitOnPage(secdelay2);

                //Offer received

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("manualtestdemob+gstfdrpayer");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("BOBOMAPDealReceived" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.NewTotal().SendKeys("319.82");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.OfferExpiry().Clear();
                IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Comments().SendKeys("Biller created deal");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("BOBOMAPDealReceived" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber2 = SIVPG1.InvNumber().Text;
                string invoicenumber2 = invnumber2.Substring(invnumber2.IndexOf("Invoice ")).Replace("Invoice ", "");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                homepg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+gstfdrpayer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                homepg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SIVPG1.PayerMakeACounterOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                DateTime duedate000 = DateTime.Today.AddDays(5);
                string SentPgDueDate2 = duedate000.ToString("dd/MM/yyyy");
                SIVPG1.NewTotal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.NewTotal().SendKeys("208.82");
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
                homepg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                //DealApprove

                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+gstfdrbiller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("manualtestdemob+gstfdrpayer");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("BOBOMAPDealApprove" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.NewTotal().SendKeys("319.82");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.OfferExpiry().Clear();
                IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Comments().SendKeys("Biller created deal");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("BOBOMAPDealApprove" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber3 = SIVPG1.InvNumber().Text;
                string invoicenumber3 = invnumber3.Substring(invnumber3.IndexOf("Invoice ")).Replace("Invoice ", "");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                homepg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+gstfdrpayer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                homepg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber3);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SIVPG1.PayerMakeACounterOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.NewTotal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.NewTotal().SendKeys("208.82");
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
                homepg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+gstfdrbiller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                homepg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys(invoicenumber3);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SIVPG1.AcceptOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SIVPG1.AcceptTheOfferModalYesBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

                //Offer Decline

                SeleniumSetMethods.WaitOnPage(secdelay7);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("manualtestdemob+gstfdrpayer");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("BOBOMAPDealDECLINE" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.NewTotal().SendKeys("319.82");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.OfferExpiry().Clear();
                IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Comments().SendKeys("Biller created deal");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("BOBOMAPDealDECLINE" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber4 = SIVPG1.InvNumber().Text;
                string invoicenumber4 = invnumber4.Substring(invnumber4.IndexOf("Invoice ")).Replace("Invoice ", "");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                homepg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+gstfdrpayer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                homepg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber4);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SIVPG1.PayerMakeACounterOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SIVPG1.NewTotal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.NewTotal().SendKeys("208.82");
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
                homepg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+gstfdrbiller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                homepg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys(invoicenumber4);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.DeclineOfferBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.DeclineOfferModalYes().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                //Offer Paid

                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("manualtestdemob+gstfdrpayer");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("BOBOMAPDealPaid" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("319.82");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BillzyDealBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.NewTotal().SendKeys("319.82");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.OfferExpiry().Clear();
                IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Comments().SendKeys("Biller created deal");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SearchInvoiceSent().SendKeys("BOBOMAPDealPaid" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber5 = SIVPG1.InvNumber().Text;
                string invoicenumber5 = invnumber5.Substring(invnumber5.IndexOf("Invoice ")).Replace("Invoice ", "");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                homepg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+gstfdrpayer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                homepg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys(invoicenumber5);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.SelectInvoiceRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.PayBTNTop().Click();
                SeleniumSetMethods.WaitOnPage(secdelay6);
                Paynwpg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Paynwpg.CardRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Paynwpg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paynwpg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);



                homepg.SignOutBTN().Click();

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
                Bobopg.UpdateExistingBillzyInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                Bobopg.SelectBusiness().SendKeys("manualtestdemob+gstfdrbiller");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //invoice with offer sent
                Bobopg.InputInvoice().SendKeys(invoicenumber1);
                Console.WriteLine(invoicenumber1);
                Console.WriteLine(invoicenumber2);
                Console.WriteLine(invoicenumber3);
                Console.WriteLine(invoicenumber4);
                Console.WriteLine(invoicenumber5);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.SearchBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.DeleteEnabled().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Bobopg.DeleteYes().Click();
                SeleniumSetMethods.WaitOnPage(secdelay8);
                bool DeleteDisabled0 = Bobopg.DeleteDisabled().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(DeleteDisabled0 == true);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Bobopg.InputInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.InputInvoice().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                // invoice with offer received status
                Bobopg.InputInvoice().SendKeys(invoicenumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.SearchBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.DeleteEnabled().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Bobopg.DeleteYes().Click();
                SeleniumSetMethods.WaitOnPage(secdelay8);
                bool DeleteDisabled2 = Bobopg.DeleteDisabled().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(DeleteDisabled2 == true);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Bobopg.InputInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.InputInvoice().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                // invoices with offer accepted status
                Bobopg.InputInvoice().SendKeys(invoicenumber3);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.SearchBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.DeleteEnabled().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Bobopg.DeleteYes().Click();
                SeleniumSetMethods.WaitOnPage(secdelay8);
                bool DeleteDisabled3 = Bobopg.DeleteDisabled().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(DeleteDisabled3 == true);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Bobopg.InputInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.InputInvoice().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                // invoices with offer declined status
                Bobopg.InputInvoice().SendKeys(invoicenumber4);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.SearchBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.DeleteEnabled().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Bobopg.DeleteYes().Click();
                SeleniumSetMethods.WaitOnPage(secdelay8);
                bool DeleteDisabled4 = Bobopg.DeleteDisabled().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(DeleteDisabled4 == true);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Bobopg.InputInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.InputInvoice().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                // invocies with offer paid through credit card
                Bobopg.InputInvoice().SendKeys(invoicenumber5);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.SearchBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool DeleteDisabled5 = Bobopg.DeleteDisabled().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(DeleteDisabled5 == true);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Bobopg.InputInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                Bobopg.InputInvoice().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay1);

            }


            finally
            {


            }
        }

        /*
         Script Description : BOBO User creates an invoice with surcharge and validates the surcharge rates in the payment page
        */

        [Test]
        public void BOBO15_BillzyBillerCCRateValidation_NormalInvoice()
        {
            // Verifying the invoice created throiugh bob reflects the correct cc rate percentage
            BOBOPage Bobopg = new BOBOPage(WebDriver);
            HomePage homepg = new HomePage(WebDriver);
            SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
            IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
            SendPage SendPg = new SendPage(WebDriver);
            SIVPage SIVPG1 = new SIVPage(WebDriver);
            LoginPage loginPage = new LoginPage(WebDriver);
            ReceivedPage Recpg = new ReceivedPage(WebDriver);
            PayNowPage Paynwpg = new PayNowPage(WebDriver);
            try
            {

                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://4impact-billzy-bobo-ui-uat.s3-ap-southeast-2.amazonaws.com/poc.html");
                Random rand2 = new Random();
                DateTime dt2 = new DateTime();
                string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber2 = rand2.Next();
                DateTime newDate = DateTime.Now.AddDays(60);
                string Invduedate = newDate.ToString("dd/MM/yyyy");
                string Invduedate1 = newDate.ToString("dd MMM yy");
                string Invduedate2 = newDate.ToString("dd/MM/yy");
                DateTime newDate1 = DateTime.Now;
                string Issuedate = newDate1.ToString("dd/MM/yyyy");
                Bobopg.Username().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.Username().SendKeys("madcowbiller+bobo_02@gmail.com");
                Bobopg.Password().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.Password().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.LoginBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                //testInfo = 'Select Billzy Biller or Third Party Biller (Inbox)'
                string textcheck = Bobopg.UserWelcomeMessage().Text;
                //string txtmsg = Bobopg.IssueMessage().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(textcheck.Contains("Welcome, madcowbiller+bobo_02@gmail.com"));
                Bobopg.BillzyBiller().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                //testInfo = 'Add New on behalf of (Internal)'
                
                //testInfo = 'Add New on behalf of (Internal)'
                Bobopg.IssueInvoiceOnBehalfOf().SendKeys("madcowtesting10+quicktest1");
                SeleniumSetMethods.WaitOnPage(secdelay7);
                Bobopg.IssueInvoiceTo().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                
                
                Bobopg.Reference().SendKeys("INV_CCRATE@" + randnumber2);
                Bobopg.InvoiceDueDate().SendKeys(Invduedate);
                Bobopg.InvoiceIssueDate().SendKeys(Issuedate);
                Bobopg.TotalAmount().SendKeys("100.00");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.PdfUpload().SendKeys(@"C:\Users\Selenium\Desktop\SeleniumRegressionSuite_Bamboo\bin\Debug\netcoreapp3.1\Invoice.pdf");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.Surcharge().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.IssueInvoiceTo().SendKeys("b. - manualtestdemob+billerverify");
                SeleniumSetMethods.WaitOnPage(secdelay7);
                Bobopg.Issue().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                string message2 = Bobopg.Message().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(message2.Contains("Invoice has been created"));
                Bobopg.OKBTN().Click();
                //testInfo = 'Login to Webapp and validate External added to Biller and an invoice was created to External Payer'
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+quicktest1@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INV_CCRATE@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool suchargemsg = bodyTag.Text.Contains("A 5% surcharge (incl. GST) will apply to credit & debit cards");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(suchargemsg == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BusinessName().SendKeys("manualtestdemob+billerverify");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "60 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("WEBAPPCCRate@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag0 = WebDriver.FindElement(By.TagName("body"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool suchargemsg0 = bodyTag0.Text.Contains("If checked, Billzy will pass the 5.00% including GST credit card fee onto your customer when they pay.");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(suchargemsg0 == true);
                //issueInvoice_issueInvoicePage_totalValue.checkValueContains = @amountGst
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("WEBAPPCCRate@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                homepg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+billerverify@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                homepg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("INV_CCRATE@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                IWebElement bodyTag1 = WebDriver.FindElement(By.TagName("body"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool suchargemsg1 = bodyTag1.Text.Contains("A 5% surcharge (incl. GST) will apply to credit & debit cards");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(suchargemsg1 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.PayBTNNoDeal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay6);
                PayNowPage paypg = new PayNowPage(WebDriver);
                paypg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.CardRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag2 = WebDriver.FindElement(By.TagName("body"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool suchargemsg2 = bodyTag2.Text.Contains("Includes 5.00% surcharge");
                bool amount = bodyTag2.Text.Contains("105.00");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(suchargemsg2 == true && amount == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                DateTime duedate1 = DateTime.Today;
                string today1 = duedate1.ToString("dd MMM yy");
                paypg.ConfirmPayBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                homepg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.ReceivedHistoryBTN().Click();
                Recpg.SearchInvoiceReceived().SendKeys("INV_CCRATE@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string paiddate = Recpg.CompletedRow1().Text;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(paiddate.Contains(today1));
                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                IWebElement bodyTag3 = WebDriver.FindElement(By.TagName("body"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool suchargemsg3 = bodyTag3.Text.Contains("Incl. surcharge");
                bool amount3 = bodyTag3.Text.Contains("$105.00");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(suchargemsg2 == true && amount3 == true);
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ToPayTab().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.SearchInvoiceReceived().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.SearchInvoiceReceived().SendKeys("WEBAPPCCRate@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                IWebElement bodyTag11 = WebDriver.FindElement(By.TagName("body"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool suchargemsg11 = bodyTag11.Text.Contains("A 5% surcharge (incl. GST) will apply to credit & debit cards");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(suchargemsg11 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.PayBTNNoDeal().Click();
                SeleniumSetMethods.WaitOnPage(secdelay6);
                paypg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                paypg.CardRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag22 = WebDriver.FindElement(By.TagName("body"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool suchargemsg22 = bodyTag22.Text.Contains("Includes 5.00% surcharge");
                bool amount2 = bodyTag2.Text.Contains("115.50");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(suchargemsg22 == true && amount2 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);

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
    }
}

