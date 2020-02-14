using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using BillzyAutomationTestSuite;
using BillzyAutomationTestSuite.PageObjects;

using BillzyAutomationTestSuite.Scripts;

namespace BillzyAutomationTestSuite.Scripts
{
    class ExportTimeout : Tests
    {
       
        [Test]
        public void Timeout01()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {
                //###Login to biller account
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);
                SendPage SendPg = new SendPage(WebDriver);
                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                ExportModalPage ExportMlPg = new ExportModalPage(WebDriver);

                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+deal01payer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                TimeoutModalPage Timepg = new TimeoutModalPage(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay8);
                Recpg.ToPayTab().Click();
                /*SeleniumSetMethods.WaitOnPage(60);
                SeleniumSetMethods.WaitOnPage(60);
                SeleniumSetMethods.WaitOnPage(60);
                SeleniumSetMethods.WaitOnPage(60);
                SeleniumSetMethods.WaitOnPage(60);
                SeleniumSetMethods.WaitOnPage(15);
                string timeoutmodal = Timepg.TimeOutModalTitle().Text;
                string remainingtime = Timepg.RemainingTime().Text;
                Assert.IsTrue(timeoutmodal.Contains("Session Timeout") && remainingtime.Contains("5 Minutes Remaining"));
                bool clockicon = Timepg.ClockIcon().Displayed;
                bool keepMySessionBTN = Timepg.KeepMySessionBTN().Displayed;
                bool endMySessionBTN = Timepg.EndMySessionBTN().Displayed;
                bool remainingTime = Timepg.RemainingTime().Displayed;
                Assert.IsTrue(clockicon == true && keepMySessionBTN == true && endMySessionBTN == true && remainingTime == true);
                Timepg.KeepMySessionBTN().Click();*/
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Recpg.ReceivedHistoryBTN().Click();

                SeleniumSetMethods.WaitOnPage(60);
                SeleniumSetMethods.WaitOnPage(60);
                SeleniumSetMethods.WaitOnPage(60);
                SeleniumSetMethods.WaitOnPage(60);
                SeleniumSetMethods.WaitOnPage(60);
                SeleniumSetMethods.WaitOnPage(60);
                SeleniumSetMethods.WaitOnPage(30);
                string remainingtime2 = Timepg.RemainingTime().Text;
                Assert.IsTrue(remainingtime2.Contains("4 Minutes Remaining"));
                SeleniumSetMethods.WaitOnPage(60);
                SeleniumSetMethods.WaitOnPage(30);
                string remainingtime3 = Timepg.RemainingTime().Text;
                Assert.IsTrue(remainingtime3.Contains("3 Minutes Remaining"));
                SeleniumSetMethods.WaitOnPage(60);
                SeleniumSetMethods.WaitOnPage(30);
                string remainingtime4 = Timepg.RemainingTime().Text;
                Assert.IsTrue(remainingtime4.Contains("2 Minutes Remaining"));
                SeleniumSetMethods.WaitOnPage(60);
                SeleniumSetMethods.WaitOnPage(30);
                string remainingtime5 = Timepg.RemainingTime().Text;
                Assert.IsTrue(remainingtime4.Contains("Seconds Remaining"));
                SeleniumSetMethods.WaitOnPage(60);
            }
            finally
            {
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();
            }



        }


    }
}


