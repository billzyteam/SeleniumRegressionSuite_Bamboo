using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
namespace BillzyAutomationTestSuite.PageObjects
{
    class BillzyCashModal
    {
        private IWebDriver webDriver;
        public BillzyCashModal(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public IWebElement BillzyCashTitleModal()
        {
            return webDriver.FindElement(By.XPath("//h4[contains(@class,'modal-title') and text()='FOR YOUR INFORMATION']"));
        }
        public IWebElement GetPaidNowLabel()
        {
            return webDriver.FindElement(By.XPath("//div[@class = 'modal-body'] //b[text()='Get Paid Now']	"));
        }
        public IWebElement GetPaidNowAmount()
        {
            return webDriver.FindElement(By.XPath("//div[@class = 'modal-body'] //span[contains(@class, 'billzy-cash-upfront')]"));
        }
        public IWebElement GetPaidLaterLabel()
        {
            return webDriver.FindElement(By.XPath("//div[@class = 'modal-body'] //b[text()='Get Paid Later']	"));
        }
        public IWebElement GetPaidLaterAmount()
        {
            return webDriver.FindElement(By.XPath("//div[@class = 'modal-body'] //span[contains(@class, 'billzy-cash-later')]"));
        }
        public IWebElement BillzyCashTerms()
        {
            return webDriver.FindElement(By.XPath("//div[@class = 'modal-body'] //div[contains(@class,'page-subtitle ')] /p"));
        }
        public IWebElement TermsAndConditions()
        {
            return webDriver.FindElement(By.XPath("//div[@class = 'modal-body'] //b[text()='Terms and Conditions']"));
        }
        public IWebElement HTMLLink()
        {
            return webDriver.FindElement(By.XPath("//div[@class = 'modal-body'] //a[text()='Click here']"));
        }
        public IWebElement BillzyCashNoBTN()
        {
            return webDriver.FindElement(By.XPath("//div[@id = 'request-billzycash-modal'] //button[@class = 'btn secondary-btn cancel-btn']"));
        }
        public IWebElement BillzyCashConfirmBTN()
        {
            return webDriver.FindElement(By.XPath("//div[@id = 'request-billzycash-modal'] //button[@class = 'btn primary-btn ladda-button']"));
        }
        public IWebElement DeleteModalTitle()
        {
            return webDriver.FindElement(By.XPath("//div[@class = 'modal-body'] //div[text()='Delete Invoice']"));
        }
        public IWebElement DeleteInvoiceMessage()
        {
            return webDriver.FindElement(By.XPath("//div[@class = 'modal-body'] //div[@class = 'page-subtitle']"));
        }
        public IWebElement DeleteComments()
        {
            return webDriver.FindElement(By.Id("delete-comments"));
        }
        public IWebElement ConfirmDeleteBTN()
        {
            return webDriver.FindElement(By.XPath("//div[@class = 'modal-body'] //span[text()='CONFIRM DELETE']"));
        }
        public IWebElement CancelBTN()
        {
            return webDriver.FindElement(By.XPath("(//div[@class = 'modal-body'] //button[text()='CANCEL'])[1]"));
        }
        public IWebElement DeleteInvoiceErrorMsg()
        {
            return webDriver.FindElement(By.XPath("//div[@class = 'delete-invoice-errmessage']"));
        }
    
        public IWebElement BillzyCash80percentMsg()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"billzy-cash-component\"]/div/div[2]/div[1]/div/div/div[4]/div/b"));
        }
        public IWebElement BillzyCashRetentionMsg()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"billzy-cash-component\"]/div/div[2]/div[1]/div/div/div[5]/div/b"));
        }
        
    }
}
