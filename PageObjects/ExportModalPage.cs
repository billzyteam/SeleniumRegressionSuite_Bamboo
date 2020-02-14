using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace BillzyAutomationTestSuite.PageObjects
{
    class ExportModalPage
    {
        private IWebDriver webDriver;
        public ExportModalPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public IWebElement ExportModalTitle()
        {
            return webDriver.FindElement(By.XPath("//h2[text()='Export']"));
        }
        public IWebElement ExportMessage()
        {
            return webDriver.FindElement(By.Id("export-message-success"));
        }
        public IWebElement ExportDownloadIcon()
        {
            return webDriver.FindElement(By.Id("file-icon-csv-export"));
        }
        public IWebElement ExportCloseBTN()
        {
            return webDriver.FindElement(By.Id("close-export-btn"));
        }
        public IWebElement HereHypherLink()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"export-message-success\"]/a"));
        }
        //### MYOB Only
        public IWebElement AccountNumber()
        {
            return webDriver.FindElement(By.XPath("//*[@id='export-myob-account' and @placeholder=\"MYOB Account Number\"]"));
        }
        public IWebElement AccountNumberMessage()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"export-modal\"]/div/div/div[2]/div[1]/span"));
        }
        public IWebElement CancelBTN()
        {
            return webDriver.FindElement(By.Id("close-export-btn"));
        }
        public IWebElement NextBTN()
        {
            return webDriver.FindElement(By.Id("next-export-btn"));
        }

    }
}
