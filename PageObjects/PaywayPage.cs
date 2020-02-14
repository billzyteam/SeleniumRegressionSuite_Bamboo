using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace BillzyAutomationTestSuite.PageObjects
{
    class PaywayPage
    {
        private IWebDriver webDriver;
        public PaywayPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public IWebElement Username()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"username\"]"));
        }
        public IWebElement Password()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"password\"]"));
        }
        public IWebElement SignIn()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"signInSubmit\"]"));
        }

        public IWebElement PaymentsTab()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"nav_Transactions\"]/li[1]/a"));
        }
        public IWebElement CustomerRefernceNumber()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"ReferenceNumber\"]"));
        }
        public IWebElement CardHolderName()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"AccountName\"]"));
        }
        public IWebElement CardNumber()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"CardNumber\"]"));
        }
        public IWebElement ExpiryMonth()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"ExpiryDateMonth\"]"));

        }
        public IWebElement ExpiryYear()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"ExpiryDateYear\"]"));

        }
        public IWebElement CardVerificationNumber()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"CVN\"]"));

        }
        public IWebElement Amount()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"TransactionPrincipalAmount\"]"));

        }
        public IWebElement PaymentNext()
        {
            return webDriver.FindElement(By.XPath("//*[@class=\"btn btn-primary\"]"));

        }
        public IWebElement ConfirmPayment()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"buttons1\"]"));

        }
        public IWebElement ConfirmDuplicatePayment()
        {
            return webDriver.FindElement(By.XPath("//*[@value=\"Confirm Duplicate Payment\"]"));

        }

        public IWebElement ProcessNewTRansaction()
        {
            return webDriver.FindElement(By.XPath("//*[@class=\"btn btn-primary\"]"));

        }
        public IWebElement ErrorMessage()
        {
            return webDriver.FindElement(By.XPath("//*[@class=\"align-middle\"]"));

        }

        public IWebElement Signout()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"navbar\"]/a/button"));

        }



    }
}
