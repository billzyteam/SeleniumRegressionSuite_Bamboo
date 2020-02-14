using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace BillzyAutomationTestSuite.PageObjects
{
    class PasswordEmailSentPage
    {
        private IWebDriver webDriver;
        public PasswordEmailSentPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
        public IWebElement OkBTN()
        {
            return webDriver.FindElement(By.XPath("//div[@class= 'modal fade in'] //button[text()='OK']"));
        }
        public IWebElement CloseX()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"forgotten-password-sent-modal\"]/div/div/div/a/img"));
        }
    }
}
