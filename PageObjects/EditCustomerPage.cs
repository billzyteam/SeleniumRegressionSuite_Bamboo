using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace BillzyAutomationTestSuite.PageObjects
{
    class EditCustomerPage
    {
        private IWebDriver webDriver;
        public EditCustomerPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
        public IWebElement EditBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id = 'view-client'] //*[@id=\"client-view-edit-btn\"]"));
        }
        public IWebElement SaveBTN()
        {
            return webDriver.FindElement(By.Id("client-view-save-btn"));
        }
        public IWebElement CancelBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id = 'view-client'] //*[@id = 'client-view-cancel-btn']"));
        }
        public IWebElement Title()
        {
            return webDriver.FindElement(By.Id("view-title"));
        }
        public IWebElement BusinessName1()
        {
            return webDriver.FindElement(By.XPath("//*[@id = 'view-client'] //*[@id = 'business-name'] "));
        }
        public IWebElement AbnNumber()
        {
            return webDriver.FindElement(By.XPath("//*[@id = 'view-client'] //*[@id = 'business-abn']"));
        }
        public IWebElement ClientName()
        {
            return webDriver.FindElement(By.XPath("//*[@id = 'view-client'] //*[@id = 'client-name']"));
        }
        public IWebElement ContactEmail()
        {
            return webDriver.FindElement(By.XPath("//*[@id = 'view-client'] //*[@id = 'business-email']"));
        }
        public IWebElement ContactPhone2()
        {
            return webDriver.FindElement(By.XPath("//*[@id = 'view-client'] //*[@id = 'phone-num']"));
        }
        public IWebElement Street1()
        {
            return webDriver.FindElement(By.XPath("//*[@id = 'view-client'] //*[@id = 'business-street']"));
        }
        public IWebElement Suburb()
        {
            return webDriver.FindElement(By.XPath("//*[@id = 'view-client'] //*[@id = 'business-suburb']"));
        }

        public IWebElement PostCode1()
        {
            return webDriver.FindElement(By.XPath("//*[@id = 'view-client'] //*[@id= 'business-postcode']"));
        }
        public IWebElement State()
        {
            return webDriver.FindElement(By.XPath("//*[@id = 'view-client'] //*[@id= 'business-state']"));
        }
        public IWebElement Country()
        {
            return webDriver.FindElement(By.XPath("//*[@id = 'view-client'] //*[@id = 'country']"));
        }
    }
}
