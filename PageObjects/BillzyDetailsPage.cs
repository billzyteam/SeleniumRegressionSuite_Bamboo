using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace BillzyAutomationTestSuite.PageObjects
{
    class BillzyDetailsPage
    {
        private IWebDriver webDriver;
        public BillzyDetailsPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public IWebElement SettingsTitlePage()
        {
            return webDriver.FindElement(By.XPath("//div[@class='settings'] //h1[text()='Settings']"));
        }
        public IWebElement BillzyDetailsTabActive()
        {
            return webDriver.FindElement(By.XPath("//div[@class= 'settings'] //li[@id= 'billzy-details-pills' and @class = 'active']"));
        }
        public IWebElement BillzyDetailsTab()
        {
            return webDriver.FindElement(By.XPath("//div[@class= 'settings'] //li[@id= 'billzy-details-pills']"));
        }
        public IWebElement YourDetailsHeader()
        {
            return webDriver.FindElement(By.XPath("//div[@class= 'settings'] //h3[text()='Your Details']"));
        }
        public IWebElement Email()
        {
            return webDriver.FindElement(By.XPath("//div[@class='settings'] //input[@id='billzy-email']"));
        }
        public IWebElement PersonalPhone()
        {
            return webDriver.FindElement(By.XPath("//div[@class='settings'] //input[@id='billzy-phone']"));
        }
        public IWebElement BillzyBusinessDetails()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"billzy-details-tab\"]/div/div[3]/div/h3"));
        }
        public IWebElement BusinessName()
        {
            return webDriver.FindElement(By.XPath("//div[@class='settings'] //input[@id='billzy-businessname']"));
        }
        public IWebElement BusinessPhone()
        {
            return webDriver.FindElement(By.XPath("//div[@class='settings'] //input[@id='billzy-details-phone']"));
        }
        public IWebElement BusinessAddress()
        {
            return webDriver.FindElement(By.XPath("//div[@class='settings'] //textarea[@id='billzy-address']"));
        }
        public IWebElement BusinessABN()
        {
            return webDriver.FindElement(By.XPath("//div[@class='settings'] //input[@id='billzy-abn']"));
        }
        public IWebElement UpdateBTN()
        {
            return webDriver.FindElement(By.XPath("//div[@class='settings'] //button[@id='billzy-details-update-btn']"));
        }
        public IWebElement InvalidEmailMsg()
        {
            return webDriver.FindElement(By.XPath("//div[@class='settings'] //span[@id='billzy-email-errmessage']"));
        }
        public IWebElement PersonalPhoneMsg()
        {
            return webDriver.FindElement(By.XPath("//div[@class='settings'] //span[@id='billzy-phone-errmessage']"));
        }
        public IWebElement BusinessPhoneMsg()
        {
            return webDriver.FindElement(By.XPath("//div[@class='settings'] //span[@id='billzy-details-phone-errmessage']"));
        }
        public IWebElement ABNMsg()
        {
            return webDriver.FindElement(By.XPath("//div[@class='settings'] //span[@id='billzy-abn-errmessage']"));
        }
        public IWebElement SuccessfullyUpdateMsg()
        {
            return webDriver.FindElement(By.XPath("//div[@class='settings'] //div[@id='billzy-details-message']"));
        }
        public IWebElement MerchantName()
        {
            return webDriver.FindElement(By.XPath("billzy-business-merchant-name"));
        }
        public IWebElement Street()
        {
            return webDriver.FindElement(By.Id("billzy-street"));
        }
        public IWebElement Suburb()
        {
            return webDriver.FindElement(By.Id("billzy-suburb"));
        }
        public IWebElement Postcode()
        {
            return webDriver.FindElement(By.Id("billzy-postcode"));
        }
        public IWebElement State()
        {
            return webDriver.FindElement(By.Id("billzy-state"));
        }
        public IWebElement Country()
        {
            return webDriver.FindElement(By.Id("billzy-country"));
        }

    }
}
