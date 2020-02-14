using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace BillzyAutomationTestSuite.PageObjects
{
    class TimeOutTemplate
    {
        private IWebDriver webDriver;
        public TimeOutTemplate(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
        public void TimeOutModal()
        {
            SeleniumSetMethods.WaitOnPage(60);
            SeleniumSetMethods.WaitOnPage(60);
            SeleniumSetMethods.WaitOnPage(60);
            SeleniumSetMethods.WaitOnPage(29);
            SeleniumSetMethods.WaitOnPage(29);
            TimeoutModalPage TimeOutPg = new TimeoutModalPage(webDriver);
            String Timeout1 = TimeOutPg.RemainingTime().Text;
            string Title = TimeOutPg.TimeOutModalTitle().Text;

            bool isClockIconDisplayed = TimeOutPg.ClockIcon().Displayed;
            bool isKeepMySessionButton = TimeOutPg.KeepMySessionBTN().Displayed;
            bool isEndMySessionButton = TimeOutPg.EndMySessionBTN().Displayed;
            bool isRemainingTime = TimeOutPg.RemainingTime().Displayed;

            Console.WriteLine(isClockIconDisplayed);
            Console.WriteLine(isKeepMySessionButton);
            Console.WriteLine(isEndMySessionButton);
            Console.WriteLine(isRemainingTime);
            Console.WriteLine(TimeOutPg.ClockIcon().Text);
            Console.WriteLine(TimeOutPg.KeepMySessionBTN().Text);
            Console.WriteLine(TimeOutPg.EndMySessionBTN().Text);
            Console.WriteLine(TimeOutPg.RemainingTime().Text);

            webDriver.PageSource.Contains(TimeOutPg.ClockIcon().Text);
            webDriver.PageSource.Contains(TimeOutPg.KeepMySessionBTN().Text);
            webDriver.PageSource.Contains(TimeOutPg.EndMySessionBTN().Text);
            webDriver.PageSource.Contains(TimeOutPg.RemainingTime().Text);
            webDriver.PageSource.Contains("For security, your session with billzy is about to time-out.");
            webDriver.PageSource.Contains("Would you like to remain logged in?");



        }
    }
}
