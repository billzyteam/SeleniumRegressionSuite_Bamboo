using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace BillzyAutomationTestSuite.PageObjects
{
    class SettingsPage
    {
        private IWebDriver webDriver;
        public SettingsPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
        public IWebElement CurrentPassword()
        {
            return webDriver.FindElement(By.Id("current-password"));
        }
        public IWebElement NewPassword()
        {
            return webDriver.FindElement(By.Id("change-password-new"));
        }
        public IWebElement ConfirmNewPassword()
        {
            return webDriver.FindElement(By.Id("change-password-retype"));
        }
        public IWebElement ChangeBTN()
        {
            return webDriver.FindElement(By.Id("change-password-btn"));
        }
        public IWebElement ChangePasswordMsg()
        {
            return webDriver.FindElement(By.Id("change-password-message"));
        }
        public IWebElement ErrorMsgCurrentPass()
        {
            return webDriver.FindElement(By.Id("current-password-help"));
        }
        public IWebElement ErrorMsgNewPass()
        {
            return webDriver.FindElement(By.Id("change-password-new-help"));
        }
        public IWebElement ErrorMsgConfirmPass()
        {
            return webDriver.FindElement(By.Id("change-password-retype-help"));
        }
        public IWebElement GSTRegisteredYes()
        {
            return webDriver.FindElement(By.Id("billzy-business-gst-yes"));
        }
        public IWebElement GSTRegisteredNo()
        {
            return webDriver.FindElement(By.Id("billzy-business-gst-no"));
        }
        public IWebElement UpdateBTN()
        {
            return webDriver.FindElement(By.Id("billzy-details-update-btn"));
        }
        public IWebElement ChangePasswordTab()
        {
            return webDriver.FindElement(By.Id("//div[@class= 'settings'] //li[@id= 'change-password-pills']"));
        }
        public IWebElement BillzyDetailsTab()
        {
            return webDriver.FindElement(By.Id("//div[@class= 'settings'] //li[@id= 'billzy-details-pills']"));
        }
        public IWebElement BillzyDetailsTabActive()
        {
            return webDriver.FindElement(By.Id("//div[@class= 'settings'] //li[@id= 'billzy-details-pills' and @class = 'active']"));
        }
        public IWebElement BillzyABN()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"billzy-abn\"]"));
        }

    }
}
