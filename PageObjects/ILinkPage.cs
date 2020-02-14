using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace BillzyAutomationTestSuite.PageObjects
{
    class ILinkPage
    {

        private IWebDriver webDriver;
        public ILinkPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public IWebElement Username()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"LoginName\"]"));
        }
        public IWebElement Password()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"Password\"]"));
        }
        public IWebElement LoginButton()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"login-container\"]/form/button/span[2]"));
        }

        public IWebElement Derpsfile()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"content-inner\"]/div[2]/div[4]/div/ul/li[1]/span[1]"));
        }

        public IWebElement Derpsfiledate()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"content-inner\"]/div[2]/div[4]/div/ul/li[1]/span[2]"));
        }

        public IWebElement Deedsfile()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"content-inner\"]/div[2]/div[4]/div/ul/li[2]/span[1]"));
        }

        public IWebElement Deedsfiledate()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"content-inner\"]/div[2]/div[4]/div/ul/li[2]/span[2]"));
        }
        public IWebElement Deedsfilename()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"content-inner\"]/div[2]/div[4]/div/ul/li[2]/a"));
        }
        public IWebElement Deedsfiledownload()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"content-inner\"]/section/div[9]/span/ul/li[1]/a"));
        }
        public IWebElement Dashboard()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"navbarNav\"]/ul[1]/li[1]/a"));
        }
        public IWebElement Derpsfilename()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"content-inner\"]/div[2]/div[4]/div/ul/li[1]/a"));
        }
        public IWebElement Derpsfiledownload()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"content-inner\"]/section/div[9]/span/ul/li[1]/a"));
        }
        public IWebElement NoFile()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"content-inner\"]/div[2]/div[4]/div/ul/li"));
        }
    }
}
