using System;
using System.IO;
using System.Net;
using NUnit.Framework;
using OpenQA.Selenium;
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
//using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BillzyAutomationTestSuite.Scripts
{
   [TestFixture]
   [Parallelizable]
    class RegSuite_Postman_UserCreation : Tests
    {
        [Test]
        ////THis method parses a XML body TO create a user. Respond 201 code. 
        public void Postman01_UserCreation_Billzy()
        {

            Random rand = new Random();
            DateTime dt = new DateTime();
            string dtString = dt.ToString("MM/dd/yyyy HH:mm:ss");
            int randnumber1 = rand.Next();
            

            string xmlMessage = @"<BillzyBusiness>
            <businessName>madcowtesting10+anogstbiller02</businessName>
            <qvalentSubMerchantName>madcowtesting10+anogstbiller02</qvalentSubMerchantName>
            <businessPhone>12345678</businessPhone>
            <businessAddressStreet>370 Queen St</businessAddressStreet>
            <businessAddressSuburb>Brisbane</businessAddressSuburb>
            <businessAddressState>QLD</businessAddressState>
            <businessAddressPostcode>4000</businessAddressPostcode>
            <businessEmail>madcowtesting10+anogstbiller02@gmail.com</businessEmail>
            <abn>10987654321</abn>
            <showDebitAccounts>true</showDebitAccounts>
            <gstRegistered>false</gstRegistered>
            <contact>
                <name>madcowtesting10+anogstbiller02</name>
                <email>madcowtesting10+anogstbiller02@gmail.com</email>
                <phone>0405028000</phone>
                <loginName>madcowtesting10+anogstbiller02@gmail.com</loginName>
            </contact>
            <bankAccount>
                <name>receiveAccount</name>
                <bsb>484799</bsb>
                <accountNumber>65432111</accountNumber>
            </bankAccount>
            <createdByUser>
                <username>billzydemo+onboarding-api@gmail.com</username>
                <password>Cognito1</password>
            </createdByUser>
            <referrer>
                <referrerId>1</referrerId>
                <name>madcowtesting10+anogstbiller02@gmail.com</name>
            </referrer>
        </BillzyBusiness>";
            string numb = randnumber1.ToString();
            var replacement = xmlMessage.Replace("anogstbiller02", numb);
            Console.WriteLine($"The source string is <{xmlMessage}>");
            Console.WriteLine($"The updated string is <{replacement}>");

            string url = "https://api.demo.billzy.com/accounts/v1";
            byte[] bytes = Encoding.UTF8.GetBytes(replacement);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentLength = bytes.Length;
            request.ContentType = "text/xml";
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);

            }
            using (HttpWebResponse response = (HttpWebResponse)
                request.GetResponse())
            {
                // if (response.StatusCode == HttpStatusCode.OK)
                // {

                //Verify the welcome email

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
                SeleniumSetMethods.WaitOnPage(secdelay6);
                gmailpg.Search().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Search().SendKeys("Username: madcowtesting10+"+numb+"@gmail.com");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                gmailpg.SearchButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag1 = WebDriver.FindElement(By.TagName("body"));
                bool Content1 = bodyTag1.Text.Contains("Welcome to the billzy Community");
                bool Content2 = bodyTag1.Text.Contains("Please set your password using the link below before you can start enjoying all the benefits billzy has to offer.");
                bool Content3 = bodyTag1.Text.Contains("Soon your bank account will receive two small transactions from billzy and an email explaining how you can verify your bank account. You can commence invoicing today, however payments will be held until your merchant account has been verified.");
                bool Content4 = bodyTag1.Text.Contains("Please view our legal documentation here: http://www.billzy.com/legal");
                bool Content5 = bodyTag1.Text.Contains("Temporary Password: Password1");
                bool Content6 = bodyTag1.Text.Contains("This temporary password is valid for the next 90 days.");
                bool Content7 = bodyTag1.Text.Contains("As a member of the billzy community you have exclusive access to Billzy Cash which allows you to apply for finance directly from your invoice.To apply simply press the Request Cash button on your invoice.");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Content1 == true && Content2 == true && Content3 == true && Content4 == true && Content5 == true && Content6 == true && Content7 == true);
                gmailpg.SetYourPwd().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
                gmailpg.Email().SendKeys("madcowtesting10+" + numb + "@gmail.com");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Temppwd().SendKeys("Password1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Newpwd().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Conpwd().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SetYourPwdbutton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                LoginPage loginPage = new LoginPage(WebDriver);
                SendPage SendPg = new SendPage(WebDriver);
                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().Clear();
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+" + numb + "@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                HomePage hmpg = new HomePage(WebDriver);
                hmpg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string noinctxt = SendPg.Noinvoiceavailablemsg().Text;
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Assert.IsTrue(noinctxt.Contains("No Invoices Available"));
                SeleniumSetMethods.WaitOnPage(secdelay4);
                hmpg.SignOutBTN().Click();

               // }
            }
        }

        [Test]
        public void Postman02_BillzyUserCreation_IssueInvoice()
        {
            //New user creation
            HomePage HomePg = new HomePage(WebDriver);
            try
            {
                Random rand = new Random();
                DateTime dt = new DateTime();
                string dtString = dt.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber1 = rand.Next();


                string xmlMessage = @"<BillzyBusiness>
            <businessName>madcowtesting10+anogstbiller02</businessName>
            <qvalentSubMerchantName>madcowtesting10+anogstbiller02</qvalentSubMerchantName>
            <businessPhone>12345678</businessPhone>
            <businessAddressStreet>370 Queen St</businessAddressStreet>
            <businessAddressSuburb>Brisbane</businessAddressSuburb>
            <businessAddressState>QLD</businessAddressState>
            <businessAddressPostcode>4000</businessAddressPostcode>
            <businessEmail>madcowtesting10+anogstbiller02@gmail.com</businessEmail>
            <abn>10987654321</abn>
            <showDebitAccounts>true</showDebitAccounts>
            <gstRegistered>false</gstRegistered>
            <contact>
                <name>madcowtesting10+anogstbiller02</name>
                <email>madcowtesting10+anogstbiller02@gmail.com</email>
                <phone>0405028000</phone>
                <loginName>madcowtesting10+anogstbiller02@gmail.com</loginName>
            </contact>
            <bankAccount>
                <name>receiveAccount</name>
                <bsb>484799</bsb>
                <accountNumber>65432111</accountNumber>
            </bankAccount>
            <createdByUser>
                <username>billzydemo+onboarding-api@gmail.com</username>
                <password>Cognito1</password>
            </createdByUser>
            <referrer>
                <referrerId>1</referrerId>
                <name>madcowtesting10+anogstbiller02@gmail.com</name>
            </referrer>
        </BillzyBusiness>";
                string numb = randnumber1.ToString();
                var replacement = xmlMessage.Replace("anogstbiller02", numb);
                Console.WriteLine($"The source string is <{xmlMessage}>");
                Console.WriteLine($"The updated string is <{replacement}>");

                string url = "https://api.demo.billzy.com/accounts/v1";
                byte[] bytes = Encoding.UTF8.GetBytes(replacement);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentLength = bytes.Length;
                request.ContentType = "text/xml";
                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(bytes, 0, bytes.Length);

                }
                using (HttpWebResponse response = (HttpWebResponse)
                    request.GetResponse())
                {

                    //###Login to biller account
                    WebDriver.Manage().Window.Maximize();
                    WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                    LoginPage loginPage = new LoginPage(WebDriver);
                    SendPage SendPg = new SendPage(WebDriver);
                    ReceivedPage Recpg = new ReceivedPage(WebDriver);
                    loginPage.UserNameTextBox().Click();
                    loginPage.UserNameTextBox().SendKeys("madcowtesting10+" + randnumber1 + "@gmail.com");
                    loginPage.PasswordTextBox().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    loginPage.PasswordTextBox().SendKeys("Password1");
                    loginPage.LoginButton().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay5);
                    SetPasswordPage setpwdpg = new SetPasswordPage(WebDriver);
                    //initial password setup
                    setpwdpg.Email().SendKeys("madcowtesting10+" + randnumber1 + "@gmail.com");
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    setpwdpg.TemporaryPassword().SendKeys("Password1");
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    setpwdpg.NewPassword().SendKeys("Cognito1");
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    setpwdpg.ConfirmPassword().SendKeys("Cognito1");
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    setpwdpg.SetYourPasswordBTN().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay5);
                    loginPage.PasswordTextBox().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    loginPage.PasswordTextBox().Clear();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    loginPage.PasswordTextBox().SendKeys("Cognito1");
                    loginPage.LoginButton().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay5);
                    HomePage hmpg = new HomePage(WebDriver);
                    hmpg.SentBTN().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay5);
                    string noinctxt = SendPg.Noinvoiceavailablemsg().Text;
                    SeleniumSetMethods.WaitOnPage(secdelay5);
                    Assert.IsTrue(noinctxt.Contains("No Invoices Available"));
                    SeleniumSetMethods.WaitOnPage(secdelay4);
                    IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                    IssueInvoicePg.IssueInvoiceButton().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay4);
                    // Issue Invoice

                    AddCustomerPage AddCustomerPg = new AddCustomerPage(WebDriver);
                    AddCustomerPg.AddCustomerButton().Click();
                    AddCustomerPg.BusinessName().Click();
                    AddCustomerPg.BusinessName().SendKeys("ExternalNoGST@" + randnumber1);
                    AddCustomerPg.Abn().SendKeys("12345678910");
                    AddCustomerPg.ContactName().SendKeys("Test@" + randnumber1);
                    AddCustomerPg.ContactEmail().SendKeys("manualtestdemob+" + randnumber1 + "@gmail.com");
                    AddCustomerPg.ContactPhoneNumber().SendKeys("12345671447");
                    AddCustomerPg.Street().SendKeys("10 Miller Street");
                    AddCustomerPg.Suburb().SendKeys("Murarrie");
                    AddCustomerPg.Postcode().SendKeys("4172");
                    AddCustomerPg.AddBTN().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay5);

                    // Invoice Creation @amountGst.default 			= $1,000.00
                    IssueInvoicePg.CreateInvoice().Click();
                    IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVNEW@"+ randnumber1);
                    IssueInvoicePg.Description().SendKeys("Test Invoice issued to External Payer");
                    IssueInvoicePg.LineItemAmount().SendKeys("1010");
                    IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                    IssueInvoicePg.SendInvoiceBTN().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay7);
                    Console.WriteLine("InvoiceCreated");
                    HomePg.SentBTN().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay7);

                    SendPg.SentOutstandingBTN().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay7);
                    SendPg.SearchInvoiceSent().SendKeys("INVNEW@"+ randnumber1);
                    SeleniumSetMethods.WaitOnPage(secdelay10);
                    SendPg.BillzyRefResult().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay4);


                }

            }
            finally
            {
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay4);
               
            }

        }

    }
}
