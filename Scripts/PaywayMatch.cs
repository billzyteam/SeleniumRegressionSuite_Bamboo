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
using OpenQA.Selenium.Interactions;

namespace BillzyAutomationTestSuite.Scripts
{
   
   
    class PaywayMatch : Tests
    {
        [Test]
        public void Payway01_SettlementReportGeneration()
        {
            HomePage HomePg = new HomePage(WebDriver);
            LoginPage loginPage = new LoginPage(WebDriver);
            try
            {

                WebDriver.Manage().Window.Maximize();

                WebDriver.Navigate().GoToUrl("https://www.payway.com.au/sign-in");
                PaywayPage Paywaypg = new PaywayPage(WebDriver);
                Paywaypg.Username().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paywaypg.Username().SendKeys("SELENIUM01");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paywaypg.Password().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paywaypg.Password().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Paywaypg.SignIn().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Paywaypg.PaymentsTab().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Random rand2 = new Random();
                DateTime dt2 = new DateTime();
                string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber2 = rand2.Next();

                var invsetMAP1 = new List<string> { "110", "111.84","66","100","80","50"};
                for (int i = invsetMAP1.Count - 1; i >= 0; i--)
                {

                    Paywaypg.CustomerRefernceNumber().SendKeys("Inv-"+ randnumber2);
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    Paywaypg.CardHolderName().SendKeys("Valid");
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    Paywaypg.CardNumber().SendKeys("5163200000000008");
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    Paywaypg.ExpiryMonth().SendKeys("08");
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    Paywaypg.ExpiryYear().SendKeys("20");
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    Paywaypg.CardVerificationNumber().SendKeys("070");
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    Paywaypg.Amount().SendKeys(invsetMAP1[i]);
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    Paywaypg.PaymentNext().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    string Errmsg = Paywaypg.ErrorMessage().Text;
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    if (Errmsg.Contains("The payment you are about to process may be a duplicate"))
                    {
                        Paywaypg.ConfirmDuplicatePayment().Click();
                        SeleniumSetMethods.WaitOnPage(secdelay5);
                    }
                    else
                    {
                        Paywaypg.ConfirmPayment().Click();
                        SeleniumSetMethods.WaitOnPage(secdelay5);
                    }
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    Paywaypg.ProcessNewTRansaction().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay4);
                }
              SeleniumSetMethods.WaitOnPage(secdelay2);
              Paywaypg.Signout().Click();
              SeleniumSetMethods.WaitOnPage(secdelay2);
            }
            finally
            {
                

            }

        }

    }
}
