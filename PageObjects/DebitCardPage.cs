using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace BillzyAutomationTestSuite.PageObjects
{
    class DebitCardPage
    {
        private IWebDriver webDriver;
        public DebitCardPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
        public IWebElement DebitCardBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"debit-accounts-pills\"]/a"));
        }
        public IWebElement AddBankAccountBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"add-bank-acct-row-sm\"]/div/a"));
        }
        public IWebElement NameofAccount()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class,'new-debit-acct-form')] //input[@id=\"debitAcctName\"]"));
        }
        public IWebElement Bsb()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class,'new-debit-acct-form')] //*[@id=\"debitAcctBSB\"]"));
        }
        public IWebElement AccountNumber()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class,'new-debit-acct-form')] //*[@id=\"debitAcctNumber\"]"));
        }
        public IWebElement BankName()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class,'new-debit-acct-form')] //*[@id=\"bankName\"]"));
        }
        public IWebElement AccountNickname()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class,'new-debit-acct-form')] //*[@id=\"debitAcctNickname\"]"));
        }
        public IWebElement AddDebitAccountBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"debitAcctModal\"]/div/div/div/div/div/div[7]/div[1]/button"));
        }
        public IWebElement CancelBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"debitAcctModal\"]/div/div/div/div/div/div[7]/div[2]/button"));
        }
        public IWebElement TCCheckbox()
        {
            return webDriver.FindElement(By.XPath("//label[@for = 'dd_accept-checkbox']"));
        }
        public IWebElement AccountNumberMsg()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"debitAcctNumber-errmessage\"]"));
        }
        public IWebElement BsbNumberMSG()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"debitAcctBSB-errmessage\"]"));
        }
        public IWebElement DeleteDebitCardBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"card-mgmt-debit-tab\"]/div/div/div[4]/div/div[1]/div/div[8]/button"));
        }
        public IWebElement VerifyNowLink1()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"card-mgmt-debit-tab\"]/div/div/div[4]/div[1]/div[1]/div/div[3]"));
        }

        public IWebElement VerifyNowLink2()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"card-mgmt-debit-tab\"]/div/div/div[4]/div[2]/div[1]/div/div[3]"));
        }

        public IWebElement VerifyNowLink3()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"card-mgmt-debit-tab\"]/div/div/div[4]/div[3]/div[1]/div/div[3]"));
        }

        public IWebElement VerifyNowLink4()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"card-mgmt-debit-tab\"]/div/div/div[4]/div[4]/div[1]/div/div[3]"));
        }
        public IWebElement VerifiedIcon()
        {
            return webDriver.FindElement(By.XPath("(//img[@src='/assets/bank_verified.svg'])[1]"));
        }
        public IWebElement VerifyPendingIcon1()
        {
            return webDriver.FindElement(By.XPath("(//*[@id=\"card-mgmt-debit-tab\"] //div[@class='row debit-acct-row'] //img[@src='/assets/bank_pending_green.svg' and @title='Pending transactions'])[1]"));
        }
        public IWebElement VerifyPendingIcon2()
        {
            return webDriver.FindElement(By.XPath("(//*[@id=\"card-mgmt-debit-tab\"] //div[@class='row debit-acct-row'] //img[@src='/assets/bank_pending_green.svg' and @title='Pending transactions'])[2]"));
        }
        public IWebElement VerifyPendingIcon3()
        {
            return webDriver.FindElement(By.XPath("(//*[@id=\"card-mgmt-debit-tab\"] //div[@class='row debit-acct-row'] //img[@src='/assets/bank_pending_green.svg' and @title='Pending transactions'])[3]"));
        }
        public IWebElement VerifyVerifiedIcon1()
        {
            return webDriver.FindElement(By.XPath("(//*[@id=\"card-mgmt-debit-tab\"] //div[@class='row debit-acct-row'] //img[@src='/assets/bank_verified.svg' and @title='Verified account'])[1]"));
        }
        public IWebElement VerifyVerifiedIcon2()
        {
            return webDriver.FindElement(By.XPath("(//*[@id=\"card-mgmt-debit-tab\"] //div[@class='row debit-acct-row'] //img[@src='/assets/bank_verified.svg' and @title='Verified account'])[2]"));
        }
        public IWebElement VerifyVerifiedIcon3()
        {
            return webDriver.FindElement(By.XPath("(//*[@id=\"card-mgmt-debit-tab\"] //div[@class='row debit-acct-row'] //img[@src='/assets/bank_verified.svg' and @title='Verified account'])[3]"));
        }
        

        public IWebElement VerifyContactBillzy()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"card-mgmt-debit-tab\"]/div/div/div[4]/div/div[1]/div/div[3]"));
        }
        public IWebElement DateVerified1()
        {
            return webDriver.FindElement(By.XPath("(//*[@id=\"card-mgmt-debit-tab\"] //div[@class='row debit-acct-row'][1] //div[contains(@class, 'verify-link')])[1]"));
        }
        public IWebElement DateVerified2()
        {
            return webDriver.FindElement(By.XPath("(//*[@id=\"card-mgmt-debit-tab\"] //div[@class='row debit-acct-row'][2] //div[contains(@class, 'verify-link')])[1]"));
        }
        public IWebElement DateVerified3()
        {
            return webDriver.FindElement(By.XPath("(//*[@id=\"card-mgmt-debit-tab\"] //div[@class='row debit-acct-row'][3] //div[contains(@class, 'verify-link')])[1]"));
        }
        public IWebElement DateVerified4()
        {
            return webDriver.FindElement(By.XPath("(//*[@id=\"card-mgmt-debit-tab\"] //div[@class='row debit-acct-row'][4] //div[contains(@class, 'verify-link')])[1]"));
        }
        public IWebElement DateVerified5()
        {
            return webDriver.FindElement(By.XPath("(//*[@id=\"card-mgmt-debit-tab\"] //div[@class='row debit-acct-row'][5] //div[contains(@class, 'verify-link')])[1]"));
        }
        public IWebElement DateVerified6()
        {
            return webDriver.FindElement(By.XPath("(//*[@id=\"card-mgmt-debit-tab\"] //div[@class='row debit-acct-row'][6] //div[contains(@class, 'verify-link')])[1]"));
        }
        public IWebElement DateVerified7()
        {
            return webDriver.FindElement(By.XPath("(//*[@id=\"card-mgmt-debit-tab\"] //div[@class='row debit-acct-row'][7] //div[contains(@class, 'verify-link')])[1]"));
        }
        public IWebElement AccountNickName1()
        {
            return webDriver.FindElement(By.XPath("(//*[@id=\"card-mgmt-debit-tab\"] //div[@class='row debit-acct-row'][1] //div[contains(@class, 'wordwrap')][1])[1]"));
        }
        public IWebElement AccountNickName2()
        {
            return webDriver.FindElement(By.XPath("(//*[@id=\"card-mgmt-debit-tab\"] //div[@class='row debit-acct-row'][2] //div[contains(@class, 'wordwrap')][1])[1]"));
        }

        public IWebElement AccountNickName3()
        {
            return webDriver.FindElement(By.XPath("(//*[@id=\"card-mgmt-debit-tab\"] //div[@class='row debit-acct-row'][3] //div[contains(@class, 'wordwrap')][1])[1]"));
        }

        public IWebElement AccountNickName4()
        {
            return webDriver.FindElement(By.XPath("(//*[@id=\"card-mgmt-debit-tab\"] //div[@class='row debit-acct-row'][4] //div[contains(@class, 'wordwrap')][1])[1]"));
        }

        public IWebElement AccountNickName5()
        {
            return webDriver.FindElement(By.XPath("(//*[@id=\"card-mgmt-debit-tab\"] //div[@class='row debit-acct-row'][5] //div[contains(@class, 'wordwrap')][1])[1]"));
        }

        public IWebElement BSB1()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"card-mgmt-debit-tab\"]/div/div/div[4]/div[1]/div[1]/div/div[5]"));
        }
        public IWebElement BSB2()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"card-mgmt-debit-tab\"]/div/div/div[4]/div[2]/div[1]/div/div[5]"));
        }
        public IWebElement BSB3()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"card-mgmt-debit-tab\"]/div/div/div[4]/div[3]/div[1]/div/div[5]"));
        }
        public IWebElement BSB4()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"card-mgmt-debit-tab\"]/div/div/div[4]/div[4]/div[1]/div/div[5]"));
        }
        public IWebElement BSB5()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"card-mgmt-debit-tab\"]/div/div/div[4]/div[5]/div[1]/div/div[5]"));
        }
        public IWebElement AccountNumber1()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"card-mgmt-debit-tab\"]/div/div/div[4]/div[1]/div[1]/div/div[6]"));
        }
        public IWebElement AccountNumber2()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"card-mgmt-debit-tab\"]/div/div/div[4]/div[2]/div[1]/div/div[6]"));
        }
        public IWebElement AccountNumber3()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"card-mgmt-debit-tab\"]/div/div/div[4]/div[3]/div[1]/div/div[6]"));
        }
        public IWebElement AccountNumber4()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"card-mgmt-debit-tab\"]/div/div/div[4]/div[4]/div[1]/div/div[6]"));
        }
        public IWebElement AccountNumber5()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"card-mgmt-debit-tab\"]/div/div/div[4]/div[5]/div[1]/div/div[6]"));
        }
        public IWebElement Bank1()
        {
            return webDriver.FindElement(By.XPath("(//*[@id=\"card-mgmt-debit-tab\"] //div[@class='row debit-acct-row'][1] //div[contains(@class, 'wordwrap')][2])[1]"));
        }
        public IWebElement Bank2()
        {
            return webDriver.FindElement(By.XPath("(//*[@id=\"card-mgmt-debit-tab\"] //div[@class='row debit-acct-row'][2] //div[contains(@class, 'wordwrap')][2])[1]"));
        }
        public IWebElement Bank3()
        {
            return webDriver.FindElement(By.XPath("(//*[@id=\"card-mgmt-debit-tab\"] //div[@class='row debit-acct-row'][3] //div[contains(@class, 'wordwrap')][2])[1]"));
        }
        public IWebElement Bank4()
        {
            return webDriver.FindElement(By.XPath("(//*[@id=\"card-mgmt-debit-tab\"] //div[@class='row debit-acct-row'][4] //div[contains(@class, 'wordwrap')][2])[1]"));
        }
        public IWebElement Bank5()
        {
            return webDriver.FindElement(By.XPath("(//*[@id=\"card-mgmt-debit-tab\"] //div[@class='row debit-acct-row'][5] //div[contains(@class, 'wordwrap')][2])[1]"));
        }
        public IWebElement AccountName1()
        {
            return webDriver.FindElement(By.XPath("(//*[@id=\"card-mgmt-debit-tab\"] //div[@class='row debit-acct-row'][1] //div[contains(@class, 'wordwrap')][3])[1]"));
        }
        public IWebElement AccountName2()
        {
            return webDriver.FindElement(By.XPath("(//*[@id=\"card-mgmt-debit-tab\"] //div[@class='row debit-acct-row'][2] //div[contains(@class, 'wordwrap')][3])[1]"));
        }
        public IWebElement AccountName3()
        {
            return webDriver.FindElement(By.XPath("(//*[@id=\"card-mgmt-debit-tab\"] //div[@class='row debit-acct-row'][3] //div[contains(@class, 'wordwrap')][3])[1]"));
        }
        public IWebElement AccountName4()
        {
            return webDriver.FindElement(By.XPath("(//*[@id=\"card-mgmt-debit-tab\"] //div[@class='row debit-acct-row'][4] //div[contains(@class, 'wordwrap')][3])[1]"));
        }
        public IWebElement AccountName5()
        {
            return webDriver.FindElement(By.XPath("(//*[@id=\"card-mgmt-debit-tab\"] //div[@class='row debit-acct-row'][5] //div[contains(@class, 'wordwrap')][3])[1]"));
        }

        public IWebElement Deleteaccount()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"card-mgmt-debit-tab\"]/div/div/div[4]/div/div[1]/div/div[9]/button"));
        }


    }
}


