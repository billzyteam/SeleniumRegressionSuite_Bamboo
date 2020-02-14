using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;


namespace BillzyAutomationTestSuite.PageObjects
{
    class BambooPage
    {
        private IWebDriver webDriver;
        public BambooPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public IWebElement Login()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"login\"]"));
        }

        public IWebElement Username()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"loginForm_os_username\"]"));
        }
        public IWebElement Password()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"loginForm_os_password\"]"));
        }
        

        public IWebElement LoginButton()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"loginForm_save\"]"));
        }
        public IWebElement DeployMenu()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"system_deploy_menu\"]/a"));
        }
        public IWebElement AllDeploymentProjects()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"deployments\"]"));
        }
        public IWebElement BillzyExecuteFD()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"environment-12812289\"]/td[1]/a"));
        }
        public IWebElement EditUAT()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"environment-14811137\"]/td[5]/a[1]/span"));
        }
        public IWebElement UATVariables()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"editEnvironmentVariables14811137\"]"));
        }
        public IWebElement ActionType()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"14614595\"]"));
        }
        public IWebElement ActionTypeclear()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"value_14614595\"]"));
        }

  

        public IWebElement ActionTypeSave()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"tr_variable_14614595\"]/td[3]/button"));
        }
        
        public IWebElement DISTType()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"24519944\"]"));
        }
        public IWebElement DISTTypeClear()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"value_24519944\"]"));
        }

        public IWebElement DISTTypeSave()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"tr_variable_24519944\"]/td[3]/button"));
        }
        public IWebElement BacktoDeployment()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"backToDeploymentProject\"]"));
        }
        public IWebElement ExecuteDeployment()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"executeDeployment14811137\"]"));
        }

        public IWebElement StartDeployment()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"executeManualDeployment_save\"]"));
        }

        public IWebElement BillzyBankTransferSendActionMessage()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"environment-12812290\"]/td[1]/a"));
        }

        public IWebElement BTSAUATEdit()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"environment-14811138\"]/td[5]/a[1]/span"));
        }

        public IWebElement BTSAUATVariables()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"editEnvironmentVariables14811138\"]"));
        }

        public IWebElement BTSAActionType()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"14614598\"]"));
        }

        public IWebElement BTSAActionTypeClear()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"value_14614598\"]"));
        }

        public IWebElement BTSATransType()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"14614600\"]"));
        }

        public IWebElement BTSATransTypeClear()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"value_14614600\"]"));
        }

        public IWebElement BTSAExecuteDeployment()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"executeDeployment14811138\"]"));
        }
        public IWebElement BTSAActiontypesave()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"tr_variable_14614598\"]/td[3]/button"));
        }
        public IWebElement BTSATranstypesave()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"tr_variable_14614600\"]/td[3]/button"));
        }

        public IWebElement BillzyMemberStatement()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"environment-16547842\"]/td[1]/a"));
        }
        public IWebElement BMSUATEdit()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"environment-16547844\"]/td[5]/a[1]/span"));
        }
        public IWebElement BMSVariable()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"editEnvironmentVariables16547844\"]"));
        }
        public IWebElement BMSBID()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"15704063\"]"));
        }
        public IWebElement BMSBIDClear()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"value_15704063\"]"));
        }
        public IWebElement BMSBIDSave()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"tr_variable_15704063\"]/td[3]/button"));
        }
        public IWebElement BMSMonth()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"15698800\"]"));
        }
        public IWebElement BMSMonthClear()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"value_15698800\"]"));
        }
        public IWebElement BMSMonthsave()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"tr_variable_15698800\"]/td[3]/button"));
        }
        public IWebElement BMSYear()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"15699594\"]"));
        }
        public IWebElement BMSYearClear()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"value_15699594\"]"));
        }
        public IWebElement BMSYearsave()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"tr_variable_15699594\"]/td[3]/button"));
        }

        public IWebElement BMSExecuteDeployment()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"executeDeployment16547844\"]"));
        }

        public IWebElement Bamboologout()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"userInfo\"]/a"));
        }
        public IWebElement Bamboologoutbutton()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"log-out\"]"));
        }

    }
}
