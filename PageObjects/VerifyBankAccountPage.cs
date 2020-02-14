using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace BillzyAutomationTestSuite.PageObjects
{
    class VerifyBankAccountPage
    {
        private IWebDriver webDriver;
        public VerifyBankAccountPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
        public IWebElement AccountName()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"verify-account-name\"]"));
        }
        public IWebElement BSB()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"verify-account-bsb\"]"));
        }
        public IWebElement Account()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"verify-account-number\"]"));
        }
        public IWebElement VerifyYourBankAccountMsg()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"verify-bank-account-modal\"]/div/div/div[3]/div[1]/p"));
        }
        public IWebElement DepositedAmount1()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"verify-bank-account-modal\" and contains(@style,'display: block;')] //input[@class='form-control verify-bank-first-amount']"));
        }
        public IWebElement DepositedAmount2()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"verify-bank-account-modal\" and contains(@style,'display: block;')] //input[@class='form-control verify-bank-second-amount']"));
        }
        public IWebElement CancelBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"verify-bank-account-modal\" and contains(@style,'display: block;')] //button[text()='CANCEL']"));
        }
        public IWebElement VerifyBTN()
        {
            return webDriver.FindElement(By.XPath("(//*[@id=\"verify-bank-account-modal\" and contains(@style,'display: block;')] //button[@class='btn primary-btn ladda-button'] //span[text()='VERIFY'])[1]"));
        }
        public IWebElement ErrorMessage()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class,'modal fade in')] //*[@id=\"verify-bank-verification-errmessage\"]"));

            
        }
     
        public IWebElement BillzyContact1()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[12]/div[2]/div[5]/table/tbody/tr[2]/td/h2"));


        }

        public IWebElement DeleteAccountButton()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"card-mgmt-debit-tab\"]/div/div/div[4]/div/div[1]/div/div[9]/button/span[1]"));
        }
    }
}
