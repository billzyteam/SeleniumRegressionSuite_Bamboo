using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace BillzyAutomationTestSuite.PageObjects
{
    class PreviewRecievedInvoicePage
    {
        private IWebDriver webDriver;
        public PreviewRecievedInvoicePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }


        public IWebElement ReturnButton()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[3]/div[1]/div[2]/h1/div/button"));
        }
        public IWebElement Status()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[3]/div[3]/div/div[2]"));
        }
        public IWebElement BusinessDetailsSection()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[3]/div[4]/div[1]/div/h3"));
        }
        public IWebElement InvoiceDetailsSection()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[3]/div[4]/div[2]/div/h3"));
        }
        public IWebElement BillzyReference()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[3]/div[4]/div[2]/div/div[1]/div/div[1]/div/div"));
        }
        public IWebElement InvoiceReference()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[3]/div[4]/div[2]/div/div[1]/div/div[2]/div/div"));
        }
        public IWebElement PaymentDetailsSection()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[3]/div[4]/div[3]/div/h3"));
        }
        public IWebElement BusinessName()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[3]/div[4]/div[1]/div/div/div/div[1]/div"));
        }
        public IWebElement InvoiceRefNum()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[3]/div[4]/div[2]/div/div[1]/div/div[2]/div/div"));
        }
        public IWebElement InvoiceDate()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"invoice-date-value\"]"));
        }
        public IWebElement PaymentTerms()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[3]/div[4]/div[3]/div/div[1]/div/div/div"));
        }
        public IWebElement PaidDate()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[3]/div[4]/div[3]/div/div[2]/div/div[2]/div/div"));
        }
        public IWebElement PayButton()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"deal-area\"]/div[3]/div[3]/button"));
        }
        public IWebElement PayerNewDealStatus()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"active-deals-row\"]/div[2]/div[1]/div[1]"));
        }
        public IWebElement PendingActiveDealDiscount()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"active-deals-row\"]/div[2]/div[1]/div[6]"));
        }
        public IWebElement PendingActiveDealTotalAfterDisc()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"active-deals-row\"]/div[2]/div[1]/div[7]"));
        }
        public IWebElement WithdrawBTN()
        {
            return webDriver.FindElement(By.XPath("(//div[@class='row deals-combined-row'] //button[@id='withdraw-deal-btn'])[2]"));
        }
        public IWebElement PayersDiscount()
        {
            return webDriver.FindElement(By.Id("prevInv-deal-percentage"));
        }

    }
}
