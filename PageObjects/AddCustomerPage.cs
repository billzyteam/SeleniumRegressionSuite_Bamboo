using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace BillzyAutomationTestSuite.PageObjects
{
    class AddCustomerPage
    {
        private IWebDriver webDriver;
        public AddCustomerPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public IWebElement Profiledata()
        {
            return webDriver.FindElement(By.XPath(" //*[@id=\"wrapper\"]/div[4]/div[12]/div[2]/div[2]/div/div[5] "));
        }

        public IWebElement EditPgSaveBtn()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"client-view-save-btn\"]"));
        }
        

        public IWebElement AddCustomerButton()
        {
            
            return webDriver.FindElement(By.XPath("//*[@id=\"issInv-add-new-customer\"]"));
        }
        public IWebElement EditPgABN()
        {

            return webDriver.FindElement(By.XPath("(//*[@id=\"business-abn\"])[2]"));
        }
        public IWebElement Customer3()
        {

            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[12]/div[2]/div[2]/div/div[5]/div[5]/div[2]/span/a"));
        }
        
        public IWebElement BusinessName()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"business-name\"]"));
            //*[@id="business-name"]
        }
        public IWebElement EditBusinessName()
        {
            return webDriver.FindElement(By.XPath("//div[@id=\"view-client\"]//*[@id=\"business-name\"]"));
            //*[@id="business-name"]
        }
        
        public IWebElement Abn()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"business-abn\"]"));
        }
        public IWebElement ContactName()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"client-name\"]"));
        }
        public IWebElement ContactEmail()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"business-email\"]"));
        }
        public IWebElement ContactPhoneNumber()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"phone-num\"]"));
        }
        public IWebElement Street()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"business-street\"]"));
        }
        public IWebElement Suburb()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"business-suburb\"]"));
        }
        public IWebElement Postcode()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"business-postcode\"]"));
        }
        public IWebElement State()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"business-state\"]"));
        }
        public IWebElement Country()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"country\"]"));
        }
        public IWebElement AddBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"add-client-btn\"]"));
        }
        public IWebElement CancelBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"cancel-add-client-btn\"]"));
        }
        public IWebElement Clickoutside()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"add-client\"]/div[2]"));
        }
        public IWebElement Amount()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issInv-upload-amount\"]"));
        }

        public IWebElement AddCustomerAbnErrMsg()
        {
            return webDriver.FindElement(By.Id("business-abn-help"));
        }

        public IWebElement AddCustomerEmailErrMsg()
        {
            return webDriver.FindElement(By.Id("business-email-help"));
        }
        public IWebElement SelectCustomer()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[12]/div[2]/div[2]/div/div[5]/div/div[2]/span/a"));
        }

        public IWebElement SelectCustomerlist()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"add-client\"]/div[2]/div[1]/div/div/div[1]/span[2]/div[2]/div/div[2]"));
        }
        

        public IWebElement RemoveCustomer()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"client-view-remove-btn\"]"));
        }

        public IWebElement ConfirmRemoveCustomer()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"client-remove-modal\"]/div/div/div/div/div[4]/div[1]/button"));
        }

        public IWebElement EditCustomer()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"client-view-edit-btn\"]"));
        }
        
        public IWebElement SaveCustomer()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"client-view-save-btn\"]"));
        }



    }
}

