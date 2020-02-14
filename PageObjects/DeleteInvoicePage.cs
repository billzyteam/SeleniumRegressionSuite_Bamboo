using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace BillzyAutomationTestSuite.PageObjects
{
    class DeleteInvoicePage
    {
        private IWebDriver webDriver;
        public DeleteInvoicePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public IWebElement DeleteInvoiceTitle()
        {
            return webDriver.FindElement(By.XPath("//div[@class= 'modal fade in'] //div[@class='client-remove'] //div[text()='Delete Invoice']"));
        }
        public IWebElement DeleteInvoiceSubTitle()
        {
            return webDriver.FindElement(By.XPath("//div[@class='client-remove'] //div[@class='page-subtitle']"));
        }
        public IWebElement ConfirmDeleteBTN()
        {
            return webDriver.FindElement(By.XPath("//div[@class= 'modal fade in'] //button/span[text()='CONFIRM DELETE']"));
        }
        public IWebElement CancelBTN()
        {
            return webDriver.FindElement(By.XPath("//div[@class= 'modal fade in'] //button[text()='CANCEL']"));
        }


    }
}
