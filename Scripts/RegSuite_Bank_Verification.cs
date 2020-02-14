using System;
using System.IO;
using System.Net;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Text;
using BillzyAutomationTestSuite.PageObjects;
using BillzyAutomationTestSuite;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace BillzyAutomationTestSuite.Scripts
{
    [TestFixture]
    [Parallelizable]
    //Test validation
    class RegSuite_Bank_Verification : Tests
    {
        [Test]
        public void BankAccountVerification01_VerifyNewlyAddedBank()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {
                /* Bank Account Verification Scenarios - 
                 *  Add Account and Verify
                 *  Delete Account
                 *  Add account and failed verification
                 */
                string bankAccountName1 = "Bank Account 01";
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);
                SendPage SendPg = new SendPage(WebDriver);
                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                BillzyCashModal BillzyCashMlPg = new BillzyCashModal(WebDriver);
                SIVPage SIVPG1 = new SIVPage(WebDriver);
                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+demobiller01@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                
                SeleniumSetMethods.WaitOnPage(secdelay8);
                
                HomePg.Profile().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                HomePg.CardMgmnt().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                DebitCardPage DebitCardPg = new DebitCardPage(WebDriver);
                DebitCardPg.DebitCardBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                DebitCardPg.AddBankAccountBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                DebitCardPg.NameofAccount().SendKeys(bankAccountName1);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                DebitCardPg.Bsb().SendKeys("650001");

                Random rand1 = new Random();
                DateTime dt1 = new DateTime();
                string dtString1 = dt1.ToString("MM HH:mm:ss");
                int randBankAccountNumber1 = rand1.Next();

                DebitCardPg.AccountNumber().SendKeys(randBankAccountNumber1.ToString());
                String BankAccountNumber1 = DebitCardPg.AccountNumber().Text;
                DebitCardPg.BankName().SendKeys("Westpac");
                DebitCardPg.AccountNickname().SendKeys(bankAccountName1);
                DebitCardPg.TCCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                DebitCardPg.AddDebitAccountBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                DebitCardPg.AccountNickName1().Equals(bankAccountName1);

                String DateVerified1 = DebitCardPg.DateVerified1().Text;
                String BSB1 = DebitCardPg.BSB1().Text;
                String AccountNumber1 = DebitCardPg.AccountNumber1().Text;
                String AccountNickName1 = DebitCardPg.AccountNickName1().Text;
                String AccountName1 = DebitCardPg.AccountName1().Text;
                string PendingIcon1 = DebitCardPg.VerifyPendingIcon1().GetAttribute("title");
                SeleniumSetMethods.WaitOnPage(secdelay4);

                Assert.IsTrue(DateVerified1.Contains("Verify Now") && BSB1.Contains("650001") && AccountName1.Contains(bankAccountName1) && AccountNumber1.Contains(BankAccountNumber1) && PendingIcon1.Contains("Pending transactions"));


                DebitCardPg.VerifyNowLink1().Click();

                SeleniumSetMethods.WaitOnPage(secdelay2);
                string defaultDepositedAmount = "0.01";
                VerifyBankAccountPage VerifyBankAccountPg = new VerifyBankAccountPage(WebDriver);
                VerifyBankAccountPg.DepositedAmount1().SendKeys(defaultDepositedAmount);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                VerifyBankAccountPg.DepositedAmount2().SendKeys(defaultDepositedAmount);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                String CancelBTN = VerifyBankAccountPg.CancelBTN().Text;
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Assert.IsTrue(CancelBTN.Contains("CANCEL"));


                VerifyBankAccountPg.VerifyBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string Today = DateTime.Now.ToString("dd/MM/yyyy");
                //bool VerifyVerifiedIcon1 = DebitCardPg.VerifyVerifiedIcon1().Displayed;
                string VerifiedIcon1 = DebitCardPg.VerifyVerifiedIcon1().GetAttribute("title");
                String DateVerified2 = DebitCardPg.DateVerified1().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(DateVerified2.Contains(Today) && VerifiedIcon1.Contains("Verified account"));

                VerifyBankAccountPg.DeleteAccountButton().Click();

                SeleniumSetMethods.WaitOnPage(secdelay3);

                DebitCardPg.AddBankAccountBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Random rand2 = new Random();
                DateTime dt2 = new DateTime();
                string dtString2 = dt2.ToString("MM HH:mm:ss");
                int randBankAccountNumber2 = rand2.Next();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                DebitCardPg.NameofAccount().SendKeys("Invalid Account");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                DebitCardPg.Bsb().SendKeys("650002");
                DebitCardPg.AccountNumber().SendKeys(randBankAccountNumber2.ToString());
                String BankAccountNumber11 = DebitCardPg.AccountNumber().Text;
                DebitCardPg.BankName().SendKeys("Westpac");
                DebitCardPg.AccountNickname().SendKeys("Invalid Account");
                DebitCardPg.TCCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                DebitCardPg.AddDebitAccountBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                DebitCardPg.VerifyNowLink1().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                VerifyBankAccountPg.DepositedAmount1().SendKeys("0.02");
                VerifyBankAccountPg.DepositedAmount2().SendKeys("0.02");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                VerifyBankAccountPg.VerifyBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                String ErrorMessage = VerifyBankAccountPg.ErrorMessage().Text;


                Assert.IsTrue(ErrorMessage.Contains("You have two attempts remaining"));

                VerifyBankAccountPg.CancelBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                DebitCardPg.VerifyNowLink1().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                VerifyBankAccountPg.DepositedAmount1().SendKeys("0.03");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                VerifyBankAccountPg.DepositedAmount2().SendKeys("0.03");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                VerifyBankAccountPg.VerifyBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                String ErrorMessage1 = VerifyBankAccountPg.ErrorMessage().Text;
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Assert.IsTrue(ErrorMessage1.Contains("You have one attempt remaining"));

                VerifyBankAccountPg.CancelBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                DebitCardPg.VerifyNowLink1().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                VerifyBankAccountPg.DepositedAmount1().SendKeys("0.04");

                SeleniumSetMethods.WaitOnPage(secdelay2);
                VerifyBankAccountPg.DepositedAmount2().SendKeys("0.04");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                VerifyBankAccountPg.VerifyBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                String ErrorMessage2 = VerifyBankAccountPg.ErrorMessage().Text;
                Assert.IsTrue(ErrorMessage2.Contains("You have no more attempts remaining, please contact billzy"));

                bool VerifyButton = DebitCardPg.VerifyNowLink1().Displayed;
                Console.WriteLine(VerifyButton);
                VerifyBankAccountPg.CancelBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                DebitCardPg.VerifyContactBillzy().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                String BillzyContact = VerifyBankAccountPg.BillzyContact1().Text;
                Assert.IsTrue(BillzyContact.Contains("Phone: 1300 BILLZY"));

                HomePg.CardMgmnt().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                DebitCardPg.DebitCardBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                VerifyBankAccountPg.DeleteAccountButton().Click();
               

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
        public void BankAccountVerification02_UnverifiedAccountPAY()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {
                /* Bank Account Verification Scenarios - 
                 * Verify cant pay with unverified bank account
                 */
                
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
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                ReceivedPage recpg = new ReceivedPage(WebDriver);
                recpg.SearchInvoiceReceived().SendKeys("INV10308526");
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.PAY().Click();
                PayNowPage Paynwpg = new PayNowPage(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paynwpg.Row01SelectCard().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));
                bool banklist = bodyTag.Text.Contains("invalid");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(banklist == false);
                
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
        public void MerchantAccountVerification03_VerifyMerchantAccount()
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
                    // Merchant account verification
                    HomePg.Profile().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    HomePg.CardMgmnt().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    MerchantAccountPage MerchantPg = new MerchantAccountPage(WebDriver);
                    MerchantPg.MerchantAccountTab().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    bool BSB = MerchantPg.BSB().Displayed;
                    bool AccountName = MerchantPg.AccountName().Displayed;
                    bool AccountNumber = MerchantPg.AccountNumber().Displayed;
                    bool VerifiedDate = MerchantPg.VerifiedDate().Displayed;
                    bool UpdateMessage = MerchantPg.UpdateMessage().Displayed;
                    bool VerifyYourBankAccountBTN = MerchantPg.VerifyYourBankAccountBTN().Displayed;
                    String DateVerified1 = MerchantPg.VerifiedDate().Text;
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    Assert.IsTrue((VerifyYourBankAccountBTN == true) && DateVerified1.Contains("Account not yet verified"));
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    // failed to verify the first two attempts and successful in the third attempt
                    MerchantPg.VerifyYourBankAccountBTN().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    VerifyBankAccountPage VerifyBankAccountPg = new VerifyBankAccountPage(WebDriver);
                    VerifyBankAccountPg.DepositedAmount1().SendKeys("0.02");
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    VerifyBankAccountPg.DepositedAmount2().SendKeys("0.02");
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    VerifyBankAccountPg.VerifyBTN().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    String VerifyErrorMessage = VerifyBankAccountPg.ErrorMessage().Text;
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    Assert.IsTrue(VerifyErrorMessage.Contains("You have two attempts remaining"));
                    VerifyBankAccountPg.CancelBTN().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    MerchantPg.VerifyYourBankAccountBTN().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    VerifyBankAccountPg.DepositedAmount1().SendKeys("0.03");
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    VerifyBankAccountPg.DepositedAmount2().SendKeys("0.01");
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    VerifyBankAccountPg.VerifyBTN().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    String VerifyErrorMessage1 = VerifyBankAccountPg.ErrorMessage().Text;
                    Assert.IsTrue(VerifyErrorMessage1.Contains("You have one attempt remaining"));
                    VerifyBankAccountPg.CancelBTN().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    MerchantPg.VerifyYourBankAccountBTN().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    VerifyBankAccountPg.DepositedAmount1().SendKeys("0.01");
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    VerifyBankAccountPg.DepositedAmount2().SendKeys("0.01");
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    VerifyBankAccountPg.VerifyBTN().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    String UpdateMessage1 = MerchantPg.UpdateMessage().Text;
                    String VerifiedDate1 = MerchantPg.VerifiedDate().Text;
                    string Today = DateTime.Now.ToString("dd/MM/yyyy");
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    Assert.IsTrue(UpdateMessage1.Contains("If you update your merchant account you will be required to verify your new bank account details by confirming two small amounts that will be deposited into your account.") && VerifiedDate1.Contains(Today));
                    HomePg.CardMgmnt().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay1);
                    //verifying the account update
                    MerchantPg.MerchantAccountTab().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    MerchantPg.BSB().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    MerchantPg.BSB().Clear();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    MerchantPg.BSB().SendKeys("484798");
                    MerchantPg.AccountNumber().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay8);
                    MerchantPg.AccountNumber().Clear();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    MerchantPg.AccountNumber().SendKeys("65432112");
                    MerchantPg.UpdateBTN().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    bool VerifyYourBankAccountBTN1 = MerchantPg.VerifyYourBankAccountBTN().Displayed;
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    Assert.IsTrue(VerifyYourBankAccountBTN1 == true);
                    //verifying the already verified account
                    MerchantPg.MerchantAccountTab().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    MerchantPg.BSB().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay8);
                    MerchantPg.BSB().Clear();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    MerchantPg.BSB().SendKeys("484799");
                    MerchantPg.AccountNumber().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay8);
                    MerchantPg.AccountNumber().Clear();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    MerchantPg.AccountNumber().SendKeys("65432111");
                    MerchantPg.AccountName().Click();
                    MerchantPg.AccountName().SendKeys("2");
                    MerchantPg.UpdateBTN().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    bool VerifyYourBankAccountBTN2 = MerchantPg.VerifyYourBankAccountBTN().Displayed;
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    string Today1 = DateTime.Now.ToString("dd/MM/yyyy");
                    String VerifiedDate11 = MerchantPg.VerifiedDate().Text;
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    Assert.IsTrue(VerifyYourBankAccountBTN2 == false && VerifiedDate11.Contains(Today1));
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    // failed verification in all three attempts
                    MerchantPg.MerchantAccountTab().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    MerchantPg.BSB().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay8);
                    MerchantPg.BSB().Clear();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    MerchantPg.BSB().SendKeys("484799");
                    MerchantPg.AccountNumber().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay8);
                    MerchantPg.AccountNumber().Clear();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    MerchantPg.AccountNumber().SendKeys("65432112");
                    MerchantPg.AccountName().Click();
                    MerchantPg.AccountName().SendKeys("2");
                    MerchantPg.UpdateBTN().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    MerchantPg.VerifyYourBankAccountBTN().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    VerifyBankAccountPg.DepositedAmount1().SendKeys("0.02");
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    VerifyBankAccountPg.DepositedAmount2().SendKeys("0.02");
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    VerifyBankAccountPg.VerifyBTN().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    String VerifyErrorMessage11 = VerifyBankAccountPg.ErrorMessage().Text;
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    Assert.IsTrue(VerifyErrorMessage11.Contains("You have two attempts remaining"));
                    VerifyBankAccountPg.CancelBTN().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    MerchantPg.VerifyYourBankAccountBTN().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    VerifyBankAccountPg.DepositedAmount1().SendKeys("0.03");
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    VerifyBankAccountPg.DepositedAmount2().SendKeys("0.01");
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    VerifyBankAccountPg.VerifyBTN().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    String VerifyErrorMessage22 = VerifyBankAccountPg.ErrorMessage().Text;
                    Assert.IsTrue(VerifyErrorMessage22.Contains("You have one attempt remaining"));
                    VerifyBankAccountPg.CancelBTN().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    MerchantPg.VerifyYourBankAccountBTN().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    VerifyBankAccountPg.DepositedAmount1().SendKeys("0.01");
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    VerifyBankAccountPg.DepositedAmount2().SendKeys("0.04");
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    VerifyBankAccountPg.VerifyBTN().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    String VerifyErrorMessage33 = VerifyBankAccountPg.ErrorMessage().Text;
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    Assert.IsTrue(VerifyErrorMessage33.Contains("You have no more attempts remaining, please contact billzy"));
                    VerifyBankAccountPg.CancelBTN().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    bool ContactBillzyBTN = MerchantPg.ContactBillzyBTN().Displayed;
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    Assert.IsTrue(ContactBillzyBTN == true);

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

