using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace BillzyAutomationTestSuite.PageObjects
{
    class MerchantAccountPage
    {
        private IWebDriver webDriver;
        public MerchantAccountPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
        public IWebElement MerchantAccountTab()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"bsb-cards-pills\"]/a[text()='Merchant Account']"));
        }
        public IWebElement UpdateMessage()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"card-mgmt-bank-tab\"]/div/div/div[3]/div[1]/em"));
        }
        public IWebElement VerifyYourBankAccountBTN()
        {
            return webDriver.FindElement(By.XPath("//button[text()='VERIFY YOUR BANK ACCOUNT'] "));
        }
        public IWebElement UpdateBTN()
        {
            return webDriver.FindElement(By.XPath("//button[text()='UPDATE'] "));
        }
        public IWebElement ContactBillzyBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"card-mgmt-bank-tab\"]/div/div/div[3]/div[1]/button"));
        }
        public IWebElement BSB()
        {
            return webDriver.FindElement(By.Id("recAcctBranchCode"));
        }
        public IWebElement AccountNumber()
        {
            return webDriver.FindElement(By.Id("recAcctNumber"));
        }
        public IWebElement AccountName()
        {
            return webDriver.FindElement(By.Id("recAcctName"));
        }
        public IWebElement VerifiedDate()
        {
            return webDriver.FindElement(By.Id("verifiedDate"));
        }


    }
}
