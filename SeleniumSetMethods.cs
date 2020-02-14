using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace BillzyAutomationTestSuite
{
    class SeleniumSetMethods
    {
        private static IWebDriver webdriver;
        private IWebDriver webDriver1;
        

        public SeleniumSetMethods(IWebDriver webDriver1)
        {
            this.webDriver1 = webDriver1;

            
        }

        // Enter text in a text Box
        public static void EnterText(IWebDriver webDriver, string element, string value, string elementtype)
        {
            if (elementtype == "Id")
                webDriver.FindElement(By.Id(element)).SendKeys(value);
            if (elementtype == "Name")
                webDriver.FindElement(By.Id(element)).SendKeys(value);
        }

        // Click into button, checkbox, option etc
        public static void Click(IWebDriver webDriver, string element, string elementtype)
        {
            if (elementtype == "Id")
                webDriver.FindElement(By.Id(element)).Click();
            if (elementtype == "XPath")
                webDriver.FindElement(By.XPath(element)).Click();

        }


        // Click into button, checkbox, option etc
        public static void SelectDropDown(IWebDriver webDriver, string element, string value, string elementtype)
        {
            if (elementtype == "Id")
                new SelectElement(webDriver.FindElement(By.Id(element))).SelectByText(value);
            if (elementtype == "XPath")
                new SelectElement(webDriver.FindElement(By.XPath(element))).SelectByText(value);
        }

        [Obsolete]
        public static void WaitUntillElementDisplayed(IWebDriver webDriver, string element, string elementtype, int maxseconds)
        {
            WebDriverWait wDWait;
            wDWait = new WebDriverWait(webdriver, TimeSpan.FromSeconds(maxseconds));

            if (elementtype == "XPath")
                wDWait.Until(ExpectedConditions.ElementExists(By.XPath(element)));

        }


        public static void WaitOnPage(int seconds)
        {
            System.Threading.Thread.Sleep(seconds * 1000);
        }
    }
}
