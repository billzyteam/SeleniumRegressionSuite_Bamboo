using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace BillzyAutomationTestSuite.PageObjects
{
    class SuccessPaymentPage
    {
        private IWebDriver webDriver;
        public SuccessPaymentPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public IWebElement CcDropDown()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'card-drop-down')]"));
        }

        public IWebElement FirstCC()
        {
            return webDriver.FindElement(By.XPath("//li[contains(@class, 'cc-list-dd')]/a[@value = '3']"));
        }
        public IWebElement NoSplitReady()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'no-split-ready')]"));
        }
        public IWebElement ConfirmPayBTN()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'received')] //button[contains(@class, 'pay-now-confirmpay-btn')] //span[text()='CONFIRM PAYMENT']"));
        }
        public IWebElement DoneBTN()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'doneBtn')]"));
        }
        public IWebElement CancelBTN()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'received')] //button[text()='CANCEL']"));
        }
        public IWebElement PayNowTitle()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'pay-now')] //h1[text()='Pay Now']"));
        }
        public IWebElement PayableRow1()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'pay-now')] //div[contains(@class, 'table-row combined-row pay-now-row')][1] /div[3]"));
        }
        public IWebElement ConfirmPaymentBTN()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'pay-now')]  //button[contains(@class, 'btn pay-now-confirmpay-btn')] //span[text()= 'CONFIRM PAYMENT']"));
        }
        public IWebElement ConfirmPaymentProp()
        {
            return webDriver.FindElement(By.XPath("(//button[@class= 'btn pay-now-confirmpay-btn bold ladda-button'])[1]"));
        }
        public IWebElement TotalItemsCount()
        {
            return webDriver.FindElement(By.XPath("//div[@class= 'pay-now'] //div[contains(@class, 'pay-now-total-row')] //span[@class= 'total-items']"));
        }
        public IWebElement TotalAmount()
        {
            return webDriver.FindElement(By.XPath("//div[@class= 'pay-now'] //div[contains(@class, 'pay-now-total-row')] //span[@class= 'pay-now-total-amount']"));
        }
        public IWebElement SuccessfulLine1lMsg()
        {
            return webDriver.FindElement(By.XPath("(//div[@class='payment-success'] //p[@class= 'payment-success-text'])[1]"));
        }
        public IWebElement SuccessfulLine2lMsg()
        {
            return webDriver.FindElement(By.XPath("(//div[@class='payment-success'] //p[@class= 'payment-success-text'])[2]"));
        }
        public IWebElement DontBTN()
        {
            return webDriver.FindElement(By.XPath("//div[@class='payment-success'] //div[text()= 'DONE']"));
        }

    }
}
