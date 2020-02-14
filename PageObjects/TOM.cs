using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace BillzyAutomationTestSuite.PageObjects
{
    class TOM
    {
        private IWebDriver webDriver;
        public TOM(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
        public IWebElement TOMicon()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"tom\"]"));
        }
        public IWebElement TOMHeader()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[12]/div[2]/div[6]/table/tbody/tr[1]/td/h1"));
        }
        public IWebElement TOMBodyText()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[12]/div[2]/div[6]/table/tbody/tr[2]/td/div/div"));
        }
        public IWebElement TOMScore()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"tom-score\"]"));
        }
        public IWebElement TOMmerchantSince()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"membership-date\"]"));
        }
        public IWebElement TOMinfoIcon()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"tom-score-tooltip\"]"));
        }
        public IWebElement Memnbershipdate()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"membership-date\"]"));
        }
        //*[@id="membership-date"]


    }
}
