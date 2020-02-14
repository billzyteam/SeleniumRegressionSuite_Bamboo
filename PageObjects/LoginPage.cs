using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;


namespace BillzyAutomationTestSuite.PageObjects
{
    //Login Page
    public class LoginPage { 

        private IWebDriver webDriver;

        public LoginPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public IWebElement IssueInvoiceButton()
        {
            return webDriver.FindElement(By.XPath("//a[contains(@class, 'issue-inv-link')]"));
        }

        public IWebElement loginerr()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"loginmessage\"]"));
        }

        public IWebElement UserNameTextBox()
        {
            return webDriver.FindElement(By.Id("username"));
        }

        public IWebElement PasswordTextBox()
        {
            return webDriver.FindElement(By.Id("password"));
        }
        public IWebElement RememberMeCheckBox()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"login-options\"]/div[1]/label"));
        }
        public IWebElement LoginButton()
        {
            return webDriver.FindElement(By.Id("login-button"));
        }
        public IWebElement LogoutButton()
        {
            return webDriver.FindElement(By.XPath("//a/button[@class= 'btn navbar-btn logout-button-main login-button-text logout-link' and text()='SIGN OUT']"));
        }
        public IWebElement ForgotPassword()
        {
            return webDriver.FindElement(By.XPath("//a[contains(@class, 'forgot-password')]"));
        }
        public IWebElement ErrorMessage()
        {
            return webDriver.FindElement(By.Id("loginmessage"));
        }

        public IWebElement CDReoprtLink()
        {
            return webDriver.FindElement(By.XPath("/html/body/a"));
        }
        public IWebElement CDRCancelBatch()
        {
            return webDriver.FindElement(By.XPath("//*[@class=\"cancel-batch-button\"][2]"));
        }
        public IWebElement CDRBlockCash()
        {
            return webDriver.FindElement(By.XPath("/html/body/span/button"));
        }
        public IWebElement CDRBlockInvField()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"cash-invoice-number-block\"]"));
        }

        public IWebElement finconautodeclinelist()
        {
            return webDriver.FindElement(By.XPath("/html/body/div[2]"));
        }

        public IWebElement finconcashreqlist()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"pending-cash-requests\"]"));
        }

        public IWebElement FDRCancelBatch()
        {
            return webDriver.FindElement(By.XPath("//*[@class=\"cancel-batch-button\"][1]"));
        }

        public IWebElement FDRReportLink()
        {
            return webDriver.FindElement(By.XPath("//*[@download=\"fdr-report.csv\"][1]"));
        }

        public IWebElement FDRBlockInvbutton()
        {
            return webDriver.FindElement(By.XPath("//*[@onclick=\"blockOneButtonClicked();\"]"));
        }

        public IWebElement FDRBlockInv()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"invoice-number-block\"]"));
        }

    }
}
