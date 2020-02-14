using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace BillzyAutomationTestSuite.PageObjects
{
    class TimeoutModalPage
    {
        private IWebDriver webDriver;
        public TimeoutModalPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public IWebElement TimeOutModalTitle()
        {
            return webDriver.FindElement(By.XPath("(//h4[contains(@class,'modal-title modal-title-bar') and text()='Session Timeout'])[1]"));
        }
        public IWebElement BillzyLogo()
        {
            return webDriver.FindElement(By.XPath("(//img[contains(@src,'/billzy-column.png')])[1]"));
        }
        public IWebElement ClockIcon()
        {
            return webDriver.FindElement(By.XPath("(//i[contains(@class,'clock-icon')])[1]"));
        }
        public IWebElement KeepMySessionBTN()
        {
            return webDriver.FindElement(By.Id("keep-session-btn"));
        }
        public IWebElement EndMySessionBTN()
        {
            return webDriver.FindElement(By.Id("end-session-btn"));
        }
        public IWebElement RemainingTime()
        {
            //return webDriver.FindElement(By.XPath("seconds-remaining-text"));
            return webDriver.FindElement(By.XPath(" //div[@id=\"timeoutModal\"][01]//div//div//div//div//div//div[@id=\"seconds-remaining-text\"][01]"));
           
        }

    }
}
