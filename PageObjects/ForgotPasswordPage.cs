using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace BillzyAutomationTestSuite.PageObjects
{
    class ForgotPasswordPage
    {
        private IWebDriver webDriver;
        public ForgotPasswordPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
        public IWebElement LogoLink()
        {
            return webDriver.FindElement(By.XPath("//img[@class=\"forgotten-password-logo\"]"));
        }
        public IWebElement Email()
        {
            return webDriver.FindElement(By.XPath("//div[@class= 'modal fade in'] //input[contains(@class, 'forgotten-password-email')]"));
        }
        public IWebElement SendBTN()
        {
            return webDriver.FindElement(By.XPath("//div[@id=\"forgotten-password-modal\"]//button"));
        }
        public IWebElement CloseX()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"forgotten-password-modal\"]/div/div/div/a/img"));
        }
        public IWebElement ForgotPageTitle()
        {
            return webDriver.FindElement(By.Id("forgot-password-link"));
        }

    }
}
