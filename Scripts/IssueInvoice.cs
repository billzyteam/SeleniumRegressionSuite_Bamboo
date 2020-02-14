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



namespace Templates
{
    class IssueInvoiceTemplates : Tests 
    {
       /* [Test]
        public void ExpernalpayerIssueInvoice01_GST_NoSurcharge()
        {
      
            LoginAccounts loginAcc = new LoginAccounts();
            loginAcc.InitialiseBrowser();
            loginAcc.UserLogin();
            SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
            SeleniumSetMethods.WaitOnPage(secdelay5);
            IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
            IssueInvoicePg.IssueInvoiceButton().Click();
            
            //Generate two random numbers for unique customer details and invoice
            Random rand = new Random();
            DateTime dt = new DateTime();
            string dtString = dt.ToString("MM/dd/yyyy HH:mm:ss");
            int randnumber1 = rand.Next();
            Random rand2 = new Random();
            DateTime dt2 = new DateTime();
            string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
            int randnumber2 = rand.Next();

            //Add Customer
            AddCustomerPage AddCustomerPg = new AddCustomerPage(WebDriver);
            AddCustomerPg.AddCustomerButton().Click();
            AddCustomerPg.BusinessName().Click();
            AddCustomerPg.BusinessName().SendKeys("ExternalNoGST@"+ randnumber1);
            AddCustomerPg.Abn().SendKeys("abhushuhuhq");
            AddCustomerPg.ContactName().SendKeys("Test@"+randnumber1);
            AddCustomerPg.ContactEmail().SendKeys("test.com");
            AddCustomerPg.ContactPhoneNumber().SendKeys("12345671447");
            AddCustomerPg.Street().SendKeys("10 Miller Street");
            AddCustomerPg.Suburb().SendKeys("Murarrie");
            AddCustomerPg.Postcode().SendKeys("4172");
            AddCustomerPg.AddBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay3);

            //Erron Message Validation
            String ActualAbnError = WebDriver.FindElement(By.Id("business-abn-help")).Text;
            String ActualEmailError = WebDriver.FindElement(By.Id("business-email-help")).Text;
            if (ActualAbnError.Contains("The value entered was not a valid 11 digit ABN (numbers and spaces only).") && ActualEmailError.Contains("The value needs to be a valid email address, e.g. something@somewhere.com"))

            {
                AddCustomerPg.ContactEmail().Clear();
                AddCustomerPg.ContactEmail().SendKeys("madcowtesting10+" + randnumber1 + "@gmail.com");
                AddCustomerPg.Abn().Clear();
                AddCustomerPg.Abn().SendKeys("12345678910");
                AddCustomerPg.AddBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

                // Invoice Creation @amountGst.default 			= $1,000.00
                IssueInvoicePg.CreateInvoice().Click();
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to External Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("1000");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");

             }
            else
            {

                Assert.Fail();
            }

        }

        [Test]
        public void CreateInvoiceExternalPayerexcludingGSTWithSurcharge()
        {
            LoginAccounts loginAcc = new LoginAccounts();
            loginAcc.InitialiseBrowser();
            loginAcc.UserLogin();
            SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
            SeleniumSetMethods.WaitOnPage(secdelay5);
            IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
            IssueInvoicePg.IssueInvoiceButton().Click();

            //Generate two random numbers for unique customer details and invoice
            Random rand = new Random();
            DateTime dt = new DateTime();
            string dtString = dt.ToString("MM/dd/yyyy HH:mm:ss");
            int randnumber1 = rand.Next();
            Random rand2 = new Random();
            DateTime dt2 = new DateTime();
            string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
            int randnumber2 = rand.Next();

            //Add Customer
            AddCustomerPage AddCustomerPg = new AddCustomerPage(WebDriver);
            AddCustomerPg.AddCustomerButton().Click();
            AddCustomerPg.BusinessName().Click();
            AddCustomerPg.BusinessName().SendKeys("ExternalNoGST@" + randnumber1);
            AddCustomerPg.Abn().SendKeys("abhushuhuhq");
            AddCustomerPg.ContactName().SendKeys("Test@" + randnumber1);
            AddCustomerPg.ContactEmail().SendKeys("test.com");
            AddCustomerPg.ContactPhoneNumber().SendKeys("12345671447");
            AddCustomerPg.Street().SendKeys("10 Miller Street");
            AddCustomerPg.Suburb().SendKeys("Murarrie");
            AddCustomerPg.Postcode().SendKeys("4172");
            AddCustomerPg.AddBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay3);

            //Erron Message Validation
            String ActualAbnError = WebDriver.FindElement(By.Id("business-abn-help")).Text;
            String ActualEmailError = WebDriver.FindElement(By.Id("business-email-help")).Text;
            if (ActualAbnError.Contains("The value entered was not a valid 11 digit ABN (numbers and spaces only).") && ActualEmailError.Contains("The value needs to be a valid email address, e.g. something@somewhere.com"))

            {
                AddCustomerPg.ContactEmail().Clear();
                AddCustomerPg.ContactEmail().SendKeys("madcowtesting10+" + randnumber1 + "@gmail.com");
                AddCustomerPg.Abn().Clear();
                AddCustomerPg.Abn().SendKeys("12345678910");
                AddCustomerPg.AddBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

                // Invoice Creation @amountGst.default 			= $1,000.00
                IssueInvoicePg.CreateInvoice().Click();
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to External Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("1000");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                IssueInvoicePg.SurchargeCheckbox().Click();
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");

            }
            else
            {

                Assert.Fail();
            }

        }

        [Test]
        public void CreateIssueInvoiceExternalPayerincludingGST()
        {
            LoginAccounts loginAcc = new LoginAccounts();
            loginAcc.InitialiseBrowser();
            loginAcc.UserLogin();
            SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
            SeleniumSetMethods.WaitOnPage(secdelay5);
            IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
            IssueInvoicePg.IssueInvoiceButton().Click();

            //Generate two random numbers for unique customer details and invoice
            Random rand = new Random();
            DateTime dt = new DateTime();
            string dtString = dt.ToString("MM/dd/yyyy HH:mm:ss");
            int randnumber1 = rand.Next();
            Random rand2 = new Random();
            DateTime dt2 = new DateTime();
            string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
            int randnumber2 = rand.Next();

            //Add Customer
            AddCustomerPage AddCustomerPg = new AddCustomerPage(WebDriver);
            AddCustomerPg.AddCustomerButton().Click();
            AddCustomerPg.BusinessName().Click();
            AddCustomerPg.BusinessName().SendKeys("ExternalNoGST@" + randnumber1);
            AddCustomerPg.Abn().SendKeys("abhushuhuhq");
            AddCustomerPg.ContactName().SendKeys("Test@" + randnumber1);
            AddCustomerPg.ContactEmail().SendKeys("test.com");
            AddCustomerPg.ContactPhoneNumber().SendKeys("12345671447");
            AddCustomerPg.Street().SendKeys("10 Miller Street");
            AddCustomerPg.Suburb().SendKeys("Murarrie");
            AddCustomerPg.Postcode().SendKeys("4172");
            AddCustomerPg.AddBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay3);

            //Erron Message Validation
            String ActualAbnError = WebDriver.FindElement(By.Id("business-abn-help")).Text;
            String ActualEmailError = WebDriver.FindElement(By.Id("business-email-help")).Text;
            if (ActualAbnError.Contains("The value entered was not a valid 11 digit ABN (numbers and spaces only).") && ActualEmailError.Contains("The value needs to be a valid email address, e.g. something@somewhere.com"))

            {
                AddCustomerPg.ContactEmail().Clear();
                AddCustomerPg.ContactEmail().SendKeys("madcowtesting10+" + randnumber1 + "@gmail.com");
                AddCustomerPg.Abn().Clear();
                AddCustomerPg.Abn().SendKeys("12345678910");
                AddCustomerPg.AddBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

                String PaymentTerms = "14 days";

                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);

                // Invoice Creation - @amountGst.default = $203.63
                IssueInvoicePg.CreateInvoice().Click();
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to External Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("185.12");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");

            }
            else
            {

                Assert.Fail();
            }

        }
        [Test]
        public void CreateIssueInvoiceExternalPayerincludingGSTWithSurcharge()
        {
            LoginAccounts loginAcc = new LoginAccounts();
            loginAcc.InitialiseBrowser();
            loginAcc.UserLogin();
            SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
            SeleniumSetMethods.WaitOnPage(secdelay5);
            IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
            IssueInvoicePg.IssueInvoiceButton().Click();

            //Generate two random numbers for unique customer details and invoice
            Random rand = new Random();
            DateTime dt = new DateTime();
            string dtString = dt.ToString("MM/dd/yyyy HH:mm:ss");
            int randnumber1 = rand.Next();
            Random rand2 = new Random();
            DateTime dt2 = new DateTime();
            string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
            int randnumber2 = rand.Next();

            //Add Customer
            AddCustomerPage AddCustomerPg = new AddCustomerPage(WebDriver);
            AddCustomerPg.AddCustomerButton().Click();
            AddCustomerPg.BusinessName().Click();
            AddCustomerPg.BusinessName().SendKeys("ExternalNoGST@" + randnumber1);
            AddCustomerPg.Abn().SendKeys("abhushuhuhq");
            AddCustomerPg.ContactName().SendKeys("Test@" + randnumber1);
            AddCustomerPg.ContactEmail().SendKeys("test.com");
            AddCustomerPg.ContactPhoneNumber().SendKeys("12345671447");
            AddCustomerPg.Street().SendKeys("10 Miller Street");
            AddCustomerPg.Suburb().SendKeys("Murarrie");
            AddCustomerPg.Postcode().SendKeys("4172");
            AddCustomerPg.AddBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay3);

            //Erron Message Validation
            String ActualAbnError = WebDriver.FindElement(By.Id("business-abn-help")).Text;
            String ActualEmailError = WebDriver.FindElement(By.Id("business-email-help")).Text;
            if (ActualAbnError.Contains("The value entered was not a valid 11 digit ABN (numbers and spaces only).") && ActualEmailError.Contains("The value needs to be a valid email address, e.g. something@somewhere.com"))

            {
                AddCustomerPg.ContactEmail().Clear();
                AddCustomerPg.ContactEmail().SendKeys("madcowtesting10+" + randnumber1 + "@gmail.com");
                AddCustomerPg.Abn().Clear();
                AddCustomerPg.Abn().SendKeys("12345678910");
                AddCustomerPg.AddBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

                String PaymentTerms = "14 days";

                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);

                // Invoice Creation @amountGst.defaults = $1,100.00
                IssueInvoicePg.CreateInvoice().Click();
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to External Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("1000");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                IssueInvoicePg.SurchargeCheckbox().Click();
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");

            }
            else
            {

                Assert.Fail();
            }

        }
        

        [Test]
   
        public void CreateIssueInvoiceInternalPayerexcludingGST_Deal_NoSurcharge()
        {
            LoginAccounts loginAcc = new LoginAccounts();
            loginAcc.InitialiseBrowser();
            loginAcc.UserLogin();
            SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
            SeleniumSetMethods.WaitOnPage(secdelay5);
            IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
            IssueInvoicePg.IssueInvoiceButton().Click();
            IssueInvoicePg.BusinessName().Click();
            IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+demopayer01");
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

           String PaymentTerms = "60 days";
           IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);    
           IssueInvoicePg.CreateInvoice().Click();
           IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV@" + randnumber2);
           IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
           IssueInvoicePg.LineItemAmount().SendKeys("1089.29");
           IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer excluding GST");
           IssueInvoicePg.BillzyDealBTN().Click();
           IssueInvoicePg.NewTotal().SendKeys("925.12");
           IssueInvoicePg.Comments().SendKeys("Deal is being offered excluding GST");
           //IssueInvoicePg.SurchargeCheckbox().Click();
           IssueInvoicePg.SendInvoiceBTN().Click();
           Console.WriteLine("InvoiceCreated");

          

        }

        [Test]

        public void CreateIssueInvoiceInternalPayerexcludingGST_Deal_Surcharge()
        {
            LoginAccounts loginAcc = new LoginAccounts();
            loginAcc.InitialiseBrowser();
            loginAcc.UserLogin();
            SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
            SeleniumSetMethods.WaitOnPage(secdelay5);
            IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
            IssueInvoicePg.IssueInvoiceButton().Click();
            IssueInvoicePg.BusinessName().Click();
            IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+demopayer01");
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

            String PaymentTerms = "60 days";
            IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
            IssueInvoicePg.CreateInvoice().Click();
            IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV@" + randnumber2);
            IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
            IssueInvoicePg.LineItemAmount().SendKeys("2055.25");
            IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer excluding GST");
            IssueInvoicePg.BillzyDealBTN().Click();
            IssueInvoicePg.NewTotal().SendKeys("1099");

            DateTime newDate = DateTime.Now.AddDays(35);
            string dtString3 = newDate.ToString("dd/MM/yyyy");

            IssueInvoicePg.OfferExpiry().Clear();
            IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
            IssueInvoicePg.Comments().SendKeys("Deal is being offered excluding GST");
            IssueInvoicePg.SurchargeCheckbox().Click();
            IssueInvoicePg.SendInvoiceBTN().Click();
            Console.WriteLine("InvoiceCreated");

        }

        [Test]

        public void CreateIssueInvoiceInternalPayerexcludingGST_NoDeal_NoSurcharge()
        {
            LoginAccounts loginAcc = new LoginAccounts();
            loginAcc.InitialiseBrowser();
            loginAcc.UserLogin();
            SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
            SeleniumSetMethods.WaitOnPage(secdelay5);
            IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
            IssueInvoicePg.IssueInvoiceButton().Click();
            IssueInvoicePg.BusinessName().Click();
            IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+demopayer01");
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

            String PaymentTerms = "30 days";
            IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
            IssueInvoicePg.CreateInvoice().Click();
            IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV@" + randnumber2);
            IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
            IssueInvoicePg.LineItemAmount().SendKeys("185.25");
            IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
            //IssueInvoicePg.SurchargeCheckbox().Click();
            IssueInvoicePg.SendInvoiceBTN().Click();
            Console.WriteLine("InvoiceCreated");

        }
        [Test]

        public void CreateIssueInvoiceInternalPayerexcludingGST_NoDeal_Surcharge()
        {
            LoginAccounts loginAcc = new LoginAccounts();
            loginAcc.InitialiseBrowser();
            loginAcc.UserLogin();
            SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
            SeleniumSetMethods.WaitOnPage(secdelay5);
            IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
            IssueInvoicePg.IssueInvoiceButton().Click();
            IssueInvoicePg.BusinessName().Click();
            IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+demopayer01");
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

            String PaymentTerms = "30 days";
            IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
            IssueInvoicePg.CreateInvoice().Click();
            IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV@" + randnumber2);
            IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
            IssueInvoicePg.LineItemAmount().SendKeys("192.77");
            IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
            IssueInvoicePg.SurchargeCheckbox().Click();
            IssueInvoicePg.SendInvoiceBTN().Click();
            Console.WriteLine("InvoiceCreated");

        }

        [Test]

        public void CreateIssueInvoiceInternalPayerexcludingGST_NoDeal_Surcharge_EndOfNextMonth()
        {
            LoginAccounts loginAcc = new LoginAccounts();
            loginAcc.InitialiseBrowser();
            loginAcc.UserLogin();
            SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
            SeleniumSetMethods.WaitOnPage(secdelay5);
            IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
            IssueInvoicePg.IssueInvoiceButton().Click();
            IssueInvoicePg.BusinessName().Click();
            IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+demopayer01");
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

            String PaymentTerms = "End of next month";
            IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
            IssueInvoicePg.CreateInvoice().Click();
            IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV@" + randnumber2);
            IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
            IssueInvoicePg.LineItemAmount().SendKeys("192.77");
            IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
            IssueInvoicePg.SurchargeCheckbox().Click();
            IssueInvoicePg.SendInvoiceBTN().Click();
            Console.WriteLine("InvoiceCreated");

        }

        [Test]

        public void CreateIssueInvoiceInternalPayerincludingGST_Deal_NoSurcharge()
        {
            LoginAccounts loginAcc = new LoginAccounts();
            loginAcc.InitialiseBrowser();
            loginAcc.UserLogin();
            SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
            SeleniumSetMethods.WaitOnPage(secdelay5);
            IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
            IssueInvoicePg.IssueInvoiceButton().Click();
            IssueInvoicePg.BusinessName().Click();
            IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+demopayer01");
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

            String PaymentTerms = "60 days";
            IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
            IssueInvoicePg.CreateInvoice().Click();
            IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV@" + randnumber2);
            IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
            IssueInvoicePg.LineItemAmount().SendKeys("299.10");
            IssueInvoicePg.Message().SendKeys("Internal Payer with Deal and no surcharge");
            IssueInvoicePg.BillzyDealBTN().Click();
            IssueInvoicePg.NewTotal().SendKeys("200");

            DateTime newDate = DateTime.Now.AddDays(17);
            string dtString3 = newDate.ToString("dd/MM/yyyy");

            IssueInvoicePg.OfferExpiry().Clear();
            IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
            IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");
            //IssueInvoicePg.SurchargeCheckbox().Click();
            IssueInvoicePg.SendInvoiceBTN().Click();
            Console.WriteLine("InvoiceCreated");

        }
        [Test]

        public void CreateIssueInvoiceInternalPayerincludingGST_Deal_NoSurcharge_EndOfNextMonth()
        {
            LoginAccounts loginAcc = new LoginAccounts();
            loginAcc.InitialiseBrowser();
            loginAcc.UserLogin();
            SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
            SeleniumSetMethods.WaitOnPage(secdelay5);
            IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
            IssueInvoicePg.IssueInvoiceButton().Click();
            IssueInvoicePg.BusinessName().Click();
            IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+demopayer01");
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

            String PaymentTerms = "End of next month";
            IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
            IssueInvoicePg.CreateInvoice().Click();
            IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV@" + randnumber2);
            IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
            IssueInvoicePg.LineItemAmount().SendKeys("299.10");
            IssueInvoicePg.Message().SendKeys("Internal Payer with Deal and  surcharge");
            IssueInvoicePg.BillzyDealBTN().Click();
            IssueInvoicePg.NewTotal().SendKeys("200");

            DateTime newDate = DateTime.Now.AddDays(17);
            string dtString3 = newDate.ToString("dd/MM/yyyy");

            IssueInvoicePg.OfferExpiry().Clear();
            IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
            IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");
            IssueInvoicePg.SurchargeCheckbox().Click();
            IssueInvoicePg.SendInvoiceBTN().Click();
            Console.WriteLine("InvoiceCreated");

        }
        [Test]

        public void CreateIssueInvoiceInternalPayerincludingGST_Deal_Surcharge()
        {
            LoginAccounts loginAcc = new LoginAccounts();
            loginAcc.InitialiseBrowser();
            loginAcc.UserLogin();
            SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
            SeleniumSetMethods.WaitOnPage(secdelay5);
            IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
            IssueInvoicePg.IssueInvoiceButton().Click();
            IssueInvoicePg.BusinessName().Click();
            IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+demopayer01");
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
            //@amountGst.default          = $330.28
            String PaymentTerms = "60 days";
            IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
            IssueInvoicePg.CreateInvoice().Click();
            IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV@" + randnumber2);
            IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
            IssueInvoicePg.LineItemAmount().SendKeys("330.25");
            IssueInvoicePg.Message().SendKeys("Internal Payer with Deal and  surcharge");
            IssueInvoicePg.BillzyDealBTN().Click();
            IssueInvoicePg.NewTotal().SendKeys("128.80");

            DateTime newDate = DateTime.Now.AddDays(60);
            string dtString3 = newDate.ToString("dd/MM/yyyy");

            IssueInvoicePg.OfferExpiry().Clear();
            IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
            IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");
            IssueInvoicePg.SurchargeCheckbox().Click();
            IssueInvoicePg.SendInvoiceBTN().Click();
            Console.WriteLine("InvoiceCreated");

        }
        [Test]

        public void CreateIssueInvoiceInternalPayerincludingGST_Deal_Surcharge_2Items()
        {
            LoginAccounts loginAcc = new LoginAccounts();
            loginAcc.InitialiseBrowser();
            loginAcc.UserLogin();
            SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
            SeleniumSetMethods.WaitOnPage(secdelay5);
            IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
            IssueInvoicePg.IssueInvoiceButton().Click();
            IssueInvoicePg.BusinessName().Click();
            IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+demopayer01");
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
            //@amountGst.default          = $330.17
            String PaymentTerms = "30 days";
            IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
            IssueInvoicePg.CreateInvoice().Click();
            IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV@" + randnumber2);
            IssueInvoicePg.Description().SendKeys("Test1 Invoice issued to Internal Payer");
            IssueInvoicePg.LineItemAmount().SendKeys("200.15");
            IssueInvoicePg.AddLineItem().Click();
            IssueInvoicePg.LineItem2().SendKeys("100");
            IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
            IssueInvoicePg.BillzyDealBTN().Click();
            IssueInvoicePg.NewTotal().SendKeys("229");
            IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");
            IssueInvoicePg.SurchargeCheckbox().Click();
            IssueInvoicePg.SendInvoiceBTN().Click();
            Console.WriteLine("InvoiceCreated");

        }

        [Test]

        public void CreateIssueInvoiceInternalPayerincludingGST_Deal_Surcharge_EndOfNextMonth()
        {
            LoginAccounts loginAcc = new LoginAccounts();
            loginAcc.InitialiseBrowser();
            loginAcc.UserLogin();
            SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
            SeleniumSetMethods.WaitOnPage(secdelay5);
            IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
            IssueInvoicePg.IssueInvoiceButton().Click();
            IssueInvoicePg.BusinessName().Click();
            IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+demopayer01");
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
            //@amountGst.default          = $330.17
            String PaymentTerms = "End of next month";
            IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
            IssueInvoicePg.CreateInvoice().Click();
            IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV@" + randnumber2);
            IssueInvoicePg.Description().SendKeys("Test1 Invoice issued to Internal Payer");
            IssueInvoicePg.LineItemAmount().SendKeys("299.10");
            IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
            IssueInvoicePg.BillzyDealBTN().Click();
            IssueInvoicePg.NewTotal().SendKeys("200");
            DateTime newDate = DateTime.Now.AddDays(17);
            string dtString3 = newDate.ToString("dd/MM/yyyy");

            IssueInvoicePg.OfferExpiry().Clear();
            IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
            IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST");
            IssueInvoicePg.SurchargeCheckbox().Click();
            IssueInvoicePg.SendInvoiceBTN().Click();
            Console.WriteLine("InvoiceCreated");

        }
        [Test]

        public void CreateIssueInvoiceInternalPayerincludingGST_Deal_Surcharge_Multiple_Invoice()
        {
            LoginAccounts loginAcc = new LoginAccounts();
            loginAcc.InitialiseBrowser();
            loginAcc.UserLogin();
            SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
            SeleniumSetMethods.WaitOnPage(secdelay5);
            IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
            IssueInvoicePg.IssueInvoiceButton().Click();
            IssueInvoicePg.BusinessName().Click();
            IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+demopayer01");
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
            //@amountGst.default          = $330.17
            String PaymentTerms = "30 days";
            IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
            IssueInvoicePg.CreateInvoice().Click();
            IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV@" + randnumber2);
            IssueInvoicePg.Description().SendKeys("Test1 Invoice issued to Internal Payer");
            IssueInvoicePg.LineItemAmount().SendKeys("300.25");
            IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
            IssueInvoicePg.BillzyDealBTN().Click();
            IssueInvoicePg.NewTotal().SendKeys("200");
            DateTime newDate = DateTime.Now.AddDays(30);
            string dtString3 = newDate.ToString("dd/MM/yyyy");

            IssueInvoicePg.OfferExpiry().Clear();
            IssueInvoicePg.OfferExpiry().SendKeys(dtString3);
            IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST Invoice #1");
            IssueInvoicePg.SurchargeCheckbox().Click();
            IssueInvoicePg.SendInvoiceBTN().Click();
            Console.WriteLine("InvoiceCreated");
            SeleniumSetMethods.WaitOnPage(secdelay3);

            IssueInvoicePg.IssueInvoiceButton().Click();
            IssueInvoicePg.BusinessName().Click();
            IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+demopayer01");
            IssueInvoicePg.SelectBusiness().Click();

            //Generate two random numbers for unique customer details and invoice
            Random rand11 = new Random();
            DateTime dt11 = new DateTime();
            string dtString11 = dt11.ToString("MM/dd/yyyy HH:mm:ss");
            int randnumber11 = rand.Next();
            

            SeleniumSetMethods.WaitOnPage(secdelay3);
            //@amountGst.default          = $330.17
            String PaymentTerms1 = "60 days";
            IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms1);
            IssueInvoicePg.CreateInvoice().Click();
            IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV@" + randnumber11);
            IssueInvoicePg.Description().SendKeys("Test1 Invoice issued to Internal Payer");
            IssueInvoicePg.LineItemAmount().SendKeys("300.25");
            IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
            IssueInvoicePg.BillzyDealBTN().Click();
            IssueInvoicePg.NewTotal().SendKeys("128.80");
            DateTime newDate1 = DateTime.Now.AddDays(60);
            string dtString4 = newDate1.ToString("dd/MM/yyyy");

            

            IssueInvoicePg.OfferExpiry().Clear();
            IssueInvoicePg.OfferExpiry().SendKeys(dtString4);
            IssueInvoicePg.Comments().SendKeys("Deal is being offered including GST Invoice #2");
            IssueInvoicePg.SurchargeCheckbox().Click();
            IssueInvoicePg.SendInvoiceBTN().Click();
            Console.WriteLine("InvoiceCreated");
        }
        [Test]

        public void CreateIssueInvoiceInternalPayerincludingGST_NoDeal_NoSurcharge()
        {
            LoginAccounts loginAcc = new LoginAccounts();
            loginAcc.InitialiseBrowser();
            loginAcc.UserLogin();
            SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
            SeleniumSetMethods.WaitOnPage(secdelay5);
            IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
            IssueInvoicePg.IssueInvoiceButton().Click();
            IssueInvoicePg.BusinessName().Click();
            IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+demopayer01");
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
            IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV@" + randnumber2);
            IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
            IssueInvoicePg.LineItemAmount().SendKeys("200.15");
            IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
            //IssueInvoicePg.SurchargeCheckbox().Click();

            //issueInvoice_issueInvoicePage_totalValue.checkValueContains = @amountGst
            IssueInvoicePg.SendInvoiceBTN().Click();
            Console.WriteLine("InvoiceCreated");

        }

        [Test]

        public void CreateIssueInvoiceInternalPayerincludingGST_NoDeal_Surcharge()
        {
            LoginAccounts loginAcc = new LoginAccounts();
            loginAcc.InitialiseBrowser();
            loginAcc.UserLogin();
            SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
            SeleniumSetMethods.WaitOnPage(secdelay5);
            IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
            IssueInvoicePg.IssueInvoiceButton().Click();
            IssueInvoicePg.BusinessName().Click();
            IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+demopayer01");
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

            String PaymentTerms = "90 days";
            IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
            IssueInvoicePg.CreateInvoice().Click();
            IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV@" + randnumber2);
            IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
            IssueInvoicePg.LineItemAmount().SendKeys("812.66");
            IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
            IssueInvoicePg.SurchargeCheckbox().Click();

            //issueInvoice_issueInvoicePage_totalValue.checkValueContains = @amountGst
            IssueInvoicePg.SendInvoiceBTN().Click();
            Console.WriteLine("InvoiceCreated");

        }

        [Test]
        public void UploadIssueInvoiceExternalPayerexcludingGST()
        {
            LoginAccounts loginAcc = new LoginAccounts();
            loginAcc.InitialiseBrowser();
            loginAcc.UserLogin();
            SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
            SeleniumSetMethods.WaitOnPage(secdelay5);
            IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
            IssueInvoicePg.IssueInvoiceButton().Click();

            //Generate two random numbers for unique customer details and invoice
            Random rand = new Random();
            DateTime dt = new DateTime();
            string dtString = dt.ToString("MM/dd/yyyy HH:mm:ss");
            int randnumber1 = rand.Next();
            Random rand2 = new Random();
            DateTime dt2 = new DateTime();
            string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
            int randnumber2 = rand.Next();

            //Add Customer
            AddCustomerPage AddCustomerPg = new AddCustomerPage(WebDriver);
            AddCustomerPg.AddCustomerButton().Click();
            AddCustomerPg.BusinessName().Click();
            AddCustomerPg.BusinessName().SendKeys("ExternalNoGST@" + randnumber1);
            AddCustomerPg.Abn().SendKeys("abhushuhuhq");
            AddCustomerPg.ContactName().SendKeys("Test@" + randnumber1);
            AddCustomerPg.ContactEmail().SendKeys("test.com");
            AddCustomerPg.ContactPhoneNumber().SendKeys("12345671447");
            AddCustomerPg.Street().SendKeys("10 Miller Street");
            AddCustomerPg.Suburb().SendKeys("Murarrie");
            AddCustomerPg.Postcode().SendKeys("4172");
            AddCustomerPg.AddBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay3);

            //Erron Message Validation
            String ActualAbnError = WebDriver.FindElement(By.Id("business-abn-help")).Text;
            String ActualEmailError = WebDriver.FindElement(By.Id("business-email-help")).Text;
            if (ActualAbnError.Contains("The value entered was not a valid 11 digit ABN (numbers and spaces only).") && ActualEmailError.Contains("The value needs to be a valid email address, e.g. something@somewhere.com"))

            {
                AddCustomerPg.ContactEmail().Clear();
                AddCustomerPg.ContactEmail().SendKeys("madcowtesting10+" + randnumber1 + "@gmail.com");
                AddCustomerPg.Abn().Clear();
                AddCustomerPg.Abn().SendKeys("12345678910");
                AddCustomerPg.AddBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "7 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);

                // Invoice Creation @amountGst.default 			= $1,000.00
                WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
                IssueInvoicePg.PdfUploadFileBTN().Click();
                IssueInvoicePg.InvoiceReferenceUpload().SendKeys("INV@" + randnumber2);
               IssueInvoicePg.UploadYourFileButton().Click();
                //element.SendKeys("C:\\Some_Folder\\MyFile.txt");
                ////*[@id="issInv-upload-file-name-span"]
                //IWebElement fileUpload = WebDriver.FindElement(By.XPath("//*[@id=\"issInv-upload-part1\"]/div[2]/div[1]/div"));
                IWebElement fileUpload1 = WebDriver.FindElement(By.XPath("//*[@id=\"issInv-upload-file-name-section\"]"));
                ////*[@id="issInv-upload-part1"]/div[2]/div[1]/div
                ///////*[@id="issInv-upload-file-name-section"]
                //fileUpload.SendKeys(@"C:\Users\BillzyAdmin\Desktop\Madcow\Invoice.pdf");
                fileUpload1.SendKeys(@"C:\Users\BillzyAdmin\Desktop\Madcow\Invoice.pdf");
                //string filePath = @"C:\Users\BillzyAdmin\Desktop\Madcow\Invoice.pdf";
                //C:\Users\BillzyAdmin\Documents\Visual Studio 2019\Projects\BillzyAutomationTestSuite\Invoice.pdf
                // IssueInvoicePg.UploadYourFileButton().SendKeys(filePath);
                // WebDriver.FindElement(By.Id("fileInput")).SendKeys(filePath);
                //System.Windows.Forms.SendKeys.SendWait(filePath);
                //System.Windows.Forms.SendKeys.SendWait(@"{Enter}");


                //IssueInvoicePg.Description().SendKeys("Test Invoice issued to External Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("1800.51");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                IssueInvoicePg.SurchargeCheckbox().Click();
                IssueInvoicePg.SendInvoiceBTN().Click();
                Console.WriteLine("InvoiceCreated");

            }
            else
            {

                Assert.Fail();
            }



        }

    */
    }

  
}