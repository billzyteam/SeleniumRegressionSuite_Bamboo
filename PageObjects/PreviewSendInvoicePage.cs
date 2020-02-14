using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace BillzyAutomationTestSuite.PageObjects
{
    class PreviewSendInvoicePage
    {
        private IWebDriver webDriver;
        public PreviewSendInvoicePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public IWebElement PreviewSentInvoiceTitlePage()
        {
            return webDriver.FindElement(By.XPath("(//div[@class='preview-bill'] //div[@class='row'][1] //div/h1)[1]"));
        }
        public IWebElement UnpaidLabel()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'preview-bill'] //div[text()='Unpaid'])[1]"));
        }
        public IWebElement ActionMenu()
        {
            return webDriver.FindElement(By.XPath("//div[@class='preview-bill'] //button[@id='dd-action-inv']"));
        }
        public IWebElement SelectDelete()
        {
            return webDriver.FindElement(By.XPath("//div[@class='preview-bill'] //ul/li[@id='delete-action']"));
        }
        public IWebElement SelectmarkAsPaid()
        {
            return webDriver.FindElement(By.XPath("//div[@class='preview-bill'] //ul/li[@id='mark-as-paid-action']"));
        }
        public IWebElement ReturnBTN()
        {
            return webDriver.FindElement(By.XPath("//div[@class='preview-bill']  //button[text()='Return']"));
        }
        public IWebElement StatusPaid()
        {
            return webDriver.FindElement(By.XPath("//div[@class='preview-bill'] //div[@class='row'][3] //div[text()='Paid']"));
        }
        public IWebElement StatusUnpaid()
        {
            return webDriver.FindElement(By.XPath("//div[@class='preview-bill'] //div[@class='row'][3] //div[text()='Unpaid']"));
        }
        public IWebElement PageLevelErrorSent()
        {
            return webDriver.FindElement(By.Id("prevInv-page-level-error"));
        }
        //## billzy Deal

        public IWebElement BillzyDealStatus()
        {
            return webDriver.FindElement(By.XPath("//div[@id = 'deal-area'] //div[contains(@class , 'deal-statu')]"));
        }
        public IWebElement BillzyDealDate()
        {
            return webDriver.FindElement(By.XPath("//div[@id = 'deal-area'] //div[contains(@class, 'initiationDate ')]"));
        }
        public IWebElement BillzyDealInitiator()
        {
            return webDriver.FindElement(By.XPath("//div[@id = 'deal-area'] //div[contains(@class, 'initiatedBy')]"));
        }
        public IWebElement BillzyDealPaymentTerm()
        {
            return webDriver.FindElement(By.XPath("//div[@id = 'deal-area'] //div[contains(@class, 'term')]"));
        }
        public IWebElement BillzyDealDueDate()
        {
            return webDriver.FindElement(By.XPath("//div[@id = 'deal-area'] //div[contains(@class, 'due-date')]"));
        }
        public IWebElement BillzyDealDiscount()
        {
            return webDriver.FindElement(By.XPath("//div[@id = 'deal-area'] //div[contains(@class, 'percentage ')]"));
        }
        public IWebElement BillzyDealTotalAfterDiscount()
        {
            return webDriver.FindElement(By.XPath("//div[@id = 'deal-area'] //div[contains(@class, 'amount')]"));

        }
        public IWebElement InputTotalAfterDiscount()
        {
            return webDriver.FindElement(By.XPath("//div[@id = 'deal-area'] //input[@id = 'prevInv-deal-amount-payable']"));
        }
        public IWebElement InputDiscount()
        {
            return webDriver.FindElement(By.Id("prevInv-deal-percentage"));
        }
        public IWebElement InputPaymentTerm()
        {
            return webDriver.FindElement(By.Id("prevInv-deal-payment-terms"));
        }
        public IWebElement InputDueDate()
        {
            return webDriver.FindElement(By.Id("prevInv-deal-due-date"));
        }
        public IWebElement TotalAfterDiscountAmount()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"deal-area\"]/div[3]/div[2]/div/h4"));
        }
        public IWebElement WithdrawBTN()
        {
            return webDriver.FindElement(By.Id("withdraw-deal-btn"));
        }
        public IWebElement RejectBTN()
        {
            return webDriver.FindElement(By.XPath("(//button[@id='reject-deal-btn'])[2]"));
        }
        public IWebElement AcceptBTN()
        {
            return webDriver.FindElement(By.XPath("(//button[@id='accept-deal-btn'])[2]"));
        }
        public IWebElement SendDealBTN()
        {
            return webDriver.FindElement(By.Id("prevInv-send-deal-btn"));
        }

        public IWebElement HistoryStatus()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[3]/div[7] //div[contains(@class, 'status')]"));
        }

        public IWebElement HistoryDealDate()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[3]/div[7] //div[contains(@class, 'initiationDate')]"));
        }

        public IWebElement HistoryInitiator()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[3]/div[7] //div[contains(@class, 'initiatedBy')]"));
        }

        public IWebElement HistoryPaymentTerm()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[3]/div[7] //div[contains(@class, 'term')]"));
        }

        public IWebElement HistoryDueDate()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[3]/div[7] //div[contains(@class, 'due-date')]"));
        }

        public IWebElement HistoryDiscount()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[3]/div[7] //div[contains(@class, 'percentage')]"));
        }

        public IWebElement HistoryTotalAfterDiscount()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[3]/div[7] //div[contains(@class, 'amount')]"));
        }


    }
}
