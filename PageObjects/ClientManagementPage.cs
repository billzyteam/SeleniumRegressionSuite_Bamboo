using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace BillzyAutomationTestSuite.PageObjects
{
    class ClientManagementPage
    {
        private IWebDriver webDriver;
        public ClientManagementPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
        public IWebElement UserBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"client-mgmt\"]"));
        }
        public IWebElement UserProfile()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"collapsable-menu-items\"]/ul[2]/li[1]/a[1]"));
        }
        public IWebElement AddCustomer()
        {
            return webDriver.FindElement(By.XPath("//div[text()='Add Customer']"));
        }
        public IWebElement BusinessName5()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"business-name\"]"));
        }
        public IWebElement SelectBusiness()
        {
            return webDriver.FindElement(By.XPath("//div[@class='business-suggestion tt-suggestion-xs-collapsed tt-selectable']"));
        }
        public IWebElement Abn1()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"business-abn\"]"));
        }
        public IWebElement ContactName1()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"client-name\"]"));
        }
        public IWebElement ContactEmail1()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"business-email\"]"));
        }
        public IWebElement ContactPhoneNumber1()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"phone-num\"]"));
        }
        public IWebElement Street1()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"business-street\"]"));
        }
        public IWebElement Suburb2()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"business-suburb\"]"));
        }
        public IWebElement Postcode2()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"business-postcode\"]"));
        }
        public IWebElement State2()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"business-state\"]"));
        }
        public IWebElement country2()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"country\"]"));
        }
        public IWebElement AddBTN2()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"add-client-btn\"]"));
        }
        public IWebElement CancelBTN2()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"cancel-add-client-btn\"]"));
        }
        public IWebElement EditBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"client-view-edit-btn\"]"));
        }
        public IWebElement saveBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"client-view-save-btn\"]"));
        }
        public IWebElement Abn2()
        {
            return webDriver.FindElement(By.Id("business-abn"));
        }
        public IWebElement SelectExtCustomer1()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[6]/div[2]/div[2]/div/div[5]/div[9]/div[2]/span/a"));
        }

        public IWebElement RemoveBTN()
        {
            return webDriver.FindElement(By.Id("//*[@id=\"client-view-remove-btn\"]"));
        }
        public IWebElement ConfirmRemoveBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"client-remove-modal\"]/div/div/div/div/div[4]/div[1]/button"));
        }
        public IWebElement CancelBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"client-remove-modal\"]/div/div/div/div/div[4]/div[2]/button"));
        }

        public IWebElement SelectCustomer()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"add-client\"]/div[2]/div[1]/div/div/div[1]/span[2]/div[2]"));
        }
        public IWebElement ContactEmail()
        {
            return webDriver.FindElement(By.Id("business-email"));
        }
        public IWebElement AddBTN()
        {
            return webDriver.FindElement(By.XPath("//div[@class= 'acct-mgmt-content'] //button[@id= 'add-client-btn'] "));
        }
        public IWebElement CancelBTN1()
        {
            return webDriver.FindElement(By.Id("cancel-add-client-btn"));
        }
        public IWebElement BillzyLogoIdentifier()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[12]/div[2]/div[2]/div/div[5]/div[1]/div[2]/span/span"));

        }


    }
}
