using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace BillzyAutomationTestSuite.PageObjects
{
    class MarkAsPaidInvoicePage
    {
        private IWebDriver webDriver;
        public MarkAsPaidInvoicePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public IWebElement MarkAsPaidTitle()
        {
            return webDriver.FindElement(By.XPath("//div[@class= 'modal fade in'] //div[@class='client-remove'] //div[text()='Mark As Paid']"));
        }
        public IWebElement MarkAsPaidBTN()
        {
            return webDriver.FindElement(By.XPath("//div[@class= 'modal fade in'] //button/span[text()='MARK AS PAID']"));
        }
        public IWebElement CancelBTN()
        {
            return webDriver.FindElement(By.XPath("//div[@cla0ss= 'modal fade in'] //button[text()='CANCEL']"));
        }

    }
}
