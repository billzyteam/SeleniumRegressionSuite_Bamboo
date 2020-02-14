using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace BillzyAutomationTestSuite.PageObjects
{
    class PasswordResetPage
    {
        private IWebDriver webDriver;
        public PasswordResetPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
        public IWebElement OkBTN()
        {
            return webDriver.FindElement(By.XPath("//div[@class='reset-password-confirmation-wrapper container-fluid'] //button[text()='OK']"));
        }

        public IWebElement NewPassword()
        {
            return webDriver.FindElement(By.XPath("//input[contains(@class, 'reset-password-new')]"));
        }
        public IWebElement RetypePassword()
        {
            return webDriver.FindElement(By.XPath("//input[contains(@class, 'reset-password-retype')]"));
        }
        public IWebElement ResetBTN()
        {
            return webDriver.FindElement(By.XPath("//button[text()='RESET']"));
        }
        public IWebElement OkBTN1()
        {
            return webDriver.FindElement(By.XPath("//div[@class='reset-password-wrapper container-fluid'] //button[text()='OK']"));
        }
        public IWebElement ResetMessage()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'reset-password-error-message')]"));
        }

    }
}
