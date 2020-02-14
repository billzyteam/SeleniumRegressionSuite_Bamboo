using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace BillzyAutomationTestSuite.PageObjects
{
    class SetPasswordPage
    {
        private IWebDriver webDriver;
        public SetPasswordPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
        public IWebElement Email()
        {
            return webDriver.FindElement(By.Id("set-password-username"));
        }

        public IWebElement TemporaryPassword()
        {
            return webDriver.FindElement(By.Id("set-password-temp-password"));
        }
        public IWebElement NewPassword()
        {
            return webDriver.FindElement(By.Id("set-password-new-password"));
        }
        public IWebElement ConfirmPassword()
        {
            return webDriver.FindElement(By.Id("set-password-new-password-retype"));
        }
        public IWebElement SetYourPasswordBTN()
        {
            return webDriver.FindElement(By.Id("set-password-button"));
        }

    }
}
