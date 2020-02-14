using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BillzyAutomationTestSuite.PageObjects
{
    //Homepage class
    class HomePage
    {
        private IWebDriver webDriver;
        public HomePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        
        public IWebElement FCImport()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"import-csv\"]"));
        }
        public IWebElement SignOutBTN()
        {
            return webDriver.FindElement(By.XPath("//a/button[@class= 'btn navbar-btn logout-button-main login-button-text logout-link' and text()='SIGN OUT']"));
        }

        public IWebElement BillSentTitle()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'bills-sent-title')]"));
        }
        public IWebElement SentBTN()
        {
            return webDriver.FindElement(By.XPath("//a[contains(text(),'SENT')]"));
        }
        public IWebElement ReceivedBTN()
        {
            return webDriver.FindElement(By.XPath("//a[@class=\"received-link\"]"));
        }
        public IWebElement AddCustBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[12]/div[2]/div[2]/div/div[1]/div/div/a/div[1]"));
        }
        public IWebElement AddCustTab()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[12]/nav/div/ul/li[1]/a"));
        }

        public IWebElement AddNewClientBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"create-invoice-main\"]/div/div[2]/div[1]/div[1]/div/div[1]/div/div[2]/div[4]/button"));
        }
        public IWebElement OutstandingBTN()
        {
            return webDriver.FindElement(By.Id("sent-page-pills"));
        }
        public IWebElement Dashboard()
        {
            return webDriver.FindElement(By.XPath("//a[contains(@class,'dashboard-link')]"));
        }
        public IWebElement Profile()
        {
            return webDriver.FindElement(By.XPath("(//a[contains(@class,'username-display')])[1]"));
        }
        //*[@id="collapsable-menu-items"]/ul[2]/li[2]/a[1]
        public IWebElement CardMgmnt()
        {
            return webDriver.FindElement(By.XPath("//nav//li//a[contains(@class,\"card-mgmt-nav\")]"));
        }
        public IWebElement ClientMgmnt()
        {
            return webDriver.FindElement(By.XPath("//a[contains(@class, 'client-mgmt-nav')]"));
        }
        public IWebElement Settings()
        {
            return webDriver.FindElement(By.Id("settings"));
        }
        public IWebElement ActiveDashboard()
        {
            return webDriver.FindElement(By.XPath("//nav//li//a[contains(@class,\"acct-dashboard-nav active\")]"));
        }
        public IWebElement CopyRight()
        {
            return webDriver.FindElement(By.Id("copyright-year"));
        }


// Sign Out functionality  variables

        public IWebElement SignOutBTN1()
        {
            return webDriver.FindElement(By.XPath("//button[contains(@class, \"logout-link\")]"));
        }
        public IWebElement SentBTN1()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"collapsable-menu-items\"]/ul[1]/li[1]/a"));
        }
        public IWebElement ReceivedBTN1()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"collapsable-menu-items\"]/ul[1]/li[2]/a"));
        }
        public IWebElement IssueInvoiceBTN1()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"collapsable-menu-items\"]/ul[1]/li[3]/a"));
        }
        //Financial Controller page

        public IWebElement FFApproved()
        {
            return webDriver.FindElement(By.XPath("//table[@id=\"pending-cash-requests\"]//tr[2]/td[9]"));
        }
        public IWebElement Approvebtn()
        {
            return webDriver.FindElement(By.XPath("//table[@id=\"pending-cash-requests\"]//tr[2]/td[10]"));
        }

        public IWebElement Declinebtn()
        {
            return webDriver.FindElement(By.XPath("//table[@id=\"pending-cash-requests\"]//tr[2]/td[11]"));
        }
        //*[@id="row-INV10305878"]/td[9]
        //*[@id="upload-csv-input"]

        public IWebElement Uploadfactorfox()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"upload-csv-input\"]"));
        }

        public IWebElement Cashratesubmit()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"cash-rates-submit\"]"));
        }

        public IWebElement FCLogout()
        {
            return webDriver.FindElement(By.XPath("/html/body/button"));
        }
        public IWebElement MemberStatement()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"statements\"]"));
        }

        public IWebElement FCAccountName()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"account-name-field\"]"));
        }
        public IWebElement FCBSB()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"bsb-field\"]"));
        }
        public IWebElement FCAccountNumber()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"account-number-field\"]"));
        }
        public IWebElement FCAmount()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"amount-field\"]"));
        }
        public IWebElement FCDDInvNum()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"dd-invoice-number\"]"));
        }
        public IWebElement FCDDComment()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"dd-comment\"]"));
        }

        public IWebElement FCDDSubmit()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"submit-dd\"]"));
        }



    }

}

