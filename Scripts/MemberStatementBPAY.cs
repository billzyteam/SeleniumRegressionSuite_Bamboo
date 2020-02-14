using System;
using System.IO;
using System.Net;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using BillzyAutomationTestSuite;
using BillzyAutomationTestSuite.PageObjects;
using OpenQA.Selenium.Interactions;

namespace BillzyAutomationTestSuite.Scripts
{
    class MemberStatementBPAY : Tests
    {

        [Test]
        public void ManualTest07_MemberStatement_ReportGeneration()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {

                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("http://bamboo.controlplane.billzy.com:443/allPlans.action");
                BambooPage Bampg = new BambooPage(WebDriver);
                Bampg.Login().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Bampg.Username().SendKeys("nraju@billzy.com");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bampg.Password().SendKeys("bamboo2019!");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bampg.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);


                // Mmeber Statement Generation

                SeleniumSetMethods.WaitOnPage(secdelay4);
                Bampg.DeployMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Bampg.AllDeploymentProjects().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bampg.BillzyMemberStatement().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bampg.BMSUATEdit().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bampg.BMSVariable().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bampg.BMSBID().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bampg.BMSBIDClear().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bampg.BMSBIDClear().SendKeys("48507");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bampg.BMSBIDSave().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Bampg.BMSMonth().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bampg.BMSMonthClear().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bampg.BMSMonthClear().SendKeys("10");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bampg.BMSMonthsave().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Bampg.BMSYear().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bampg.BMSYearClear().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bampg.BMSYearClear().SendKeys("2019");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bampg.BMSYearsave().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Bampg.BacktoDeployment().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bampg.BMSExecuteDeployment().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bampg.StartDeployment().Click();
                SeleniumSetMethods.WaitOnPage(60);
                IWebElement bodyTag2 = WebDriver.FindElement(By.TagName("body"));
                bool status2 = bodyTag2.Text.Contains("SUCCESS");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                if (status2 == false)
                {
                    SeleniumSetMethods.WaitOnPage(60);
                }


                //Login to webapp and check for member statement

                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+gstfdrbiller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                HomePage homepg = new HomePage(WebDriver);
                homepg.Profile().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                homepg.MemberStatement().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));
                bool MSstatus = bodyTag.Text.Contains("October 2019 - Statement");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(MSstatus == true);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                homepg.SignOutBTN().Click();
            }
            finally
            {
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com");

            }

        }

        [Test]
        public void ManualTest08_BPAY_Payment()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {

                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://us-east-1.signin.aws.amazon.com/oauth?response_type=code&client_id=arn%3Aaws%3Aiam%3A%3A015428540659%3Auser%2Fhomepage&redirect_uri=https%3A%2F%2Fconsole.aws.amazon.com%2Fconsole%2Fhome%3Fstate%3DhashArgs%2523%26isauthcode%3Dtrue&forceMobileLayout=0&forceMobileApp=0");
                AWSNonProdPage awspg = new AWSNonProdPage(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                awspg.AccountId1().SendKeys("564633686392");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                awspg.Next().Click();
                SeleniumSetMethods.WaitOnPage(30);
                awspg.Username().SendKeys("nelda.raju");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                awspg.Password().SendKeys("nonprod2019!");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                awspg.SignIn().Click();
                SeleniumSetMethods.WaitOnPage(20);
                // BPAY Payment
                awspg.SearchBox().SendKeys("step function");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                awspg.SelectStepFunction().Click();
                SeleniumSetMethods.WaitOnPage(secdelay6);
                awspg.BpayStateMachine().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                awspg.StartExecution().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                awspg.Script().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
                new Actions(WebDriver).SendKeys("\"crn\": \"99103099204\",  \"amount\": 10,  \"received_time\": 1572825469").Perform();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                awspg.Execute().Click();
                SeleniumSetMethods.WaitOnPage(30);
                awspg.Profilesignout().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                awspg.Signout().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);


            }
            finally
            {
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com");

            }

        }
    }
}
