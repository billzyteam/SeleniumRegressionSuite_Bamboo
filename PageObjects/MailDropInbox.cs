using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace BillzyAutomationTestSuite.PageObjects
{
    class MailDropInbox
    {
        private IWebDriver webDriver;
        public MailDropInbox(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
        public IWebElement Reload()
        {
            return webDriver.FindElement(By.Id("inbox-reload"));
        }
        public IWebElement InboxLink()
        {
            return webDriver.FindElement(By.XPath("//td[@class= 'subject'] //a[contains(text(),' has sent you an invoice')]"));
        }
        public IWebElement Username()
        {
            return webDriver.FindElement(By.XPath("(//td[@class='default-Text'] /b)[1]"));
        }
        public IWebElement TemporaryPassword()
        {
            return webDriver.FindElement(By.XPath("/html/body/table[2]/tbody/tr[2]/td[2]/table/tbody/tr[3]/td/table/tbody/tr[8]/td /b"));
        }
        public IWebElement SetYourPasswordBTN()
        {
            return webDriver.FindElement(By.XPath("//a[text()='Set Your Password'] "));
        }
        public IWebElement MessageFrame()
        {
            return webDriver.FindElement(By.Id("messageframe"));
        }
        public IWebElement WelcomeMessageForTempPassword()
        {
            return webDriver.FindElement(By.XPath("/html/body/table[2]/tbody/tr[2]/td[2]/table/tbody/tr[3]/td/table/tbody/tr[9]/td"));
        }

    }
}
