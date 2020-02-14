using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
namespace BillzyAutomationTestSuite.PageObjects
{
    class AWSNonProdPage
    {

        private IWebDriver webDriver;
        public AWSNonProdPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }


        public IWebElement Username()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"username\"]"));
        }

        public IWebElement Password()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"password\"]"));
        }
        public IWebElement AccountId()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"account\"]"));
        }

        public IWebElement AccountId1()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"resolving_input\"]"));
        }

        public IWebElement Next()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"next_button\"]"));
        }
        public IWebElement SignIn()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"signin_button\"]"));
        }

        public IWebElement SearchBox()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"search-box-input\"]"));
        }
        public IWebElement SelectStepFunction()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"search-box-input-dropdown-states\"]/awsui-select-option/div"));
        }

        public IWebElement Optionstab()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"search-box-input-dropdown-states\"]/awsui-select-option/div"));
        }

        public IWebElement StepFunctionTab()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"nav-shortcutBar\"]/li[3]/a/span[2]"));
        }

        public IWebElement BpayStateMachine()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"view-container\"]/sfn-state-machines/sfn-page-layout/awsui-app-layout/div/main/div[2]/div/div/ng-transclude/sfn-state-machines-table/awsui-table/div/div[3]/table/tbody/tr[1]/td[2]/span/a"));
            
        }
        public IWebElement BpayStateMachineUAT()
        {
            return webDriver.FindElement(By.XPath("//td//span//*[@href=\"#/statemachines/view/arn:aws:states:ap-southeast-2:564633686392:stateMachine:BpayStateMachine-uat\"]"));
         
        }

        public IWebElement StartExecution()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"view-container\"]/sfn-state-machine-details/sfn-page-layout/awsui-app-layout/div/main/div[2]/div/div/ng-transclude/awsui-tabs/div/div/span/sfn-execution-table/awsui-table/div/div[2]/div/div[1]/span/div/div[2]/awsui-button[4]/button/span"));
        }

        public IWebElement Script()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"view-container\"]/sfn-state-machine-details/sfn-page-layout/awsui-app-layout/div/main/div[2]/div/div/ng-transclude/new-execution-modal/awsui-modal/div[2]/div/div/div[2]/div/span/section[2]/div[2]/awsui-form-field/div/div[2]/div/div/div/ui-codemirror/div/div[6]/div[1]/div/div/div/div[5]"));
        }

        public IWebElement EditScriptInsert()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"view-container\"]/sfn-execution/sfn-page-layout/awsui-app-layout/div/main/div[2]/div/div/ng-transclude/section/new-execution-modal/awsui-modal/div[2]/div/div/div[2]/div/span/section[2]/div[2]/awsui-form-field/div/div[2]/div/div/div/ui-codemirror/div/div[6]/div[1]/div/div/div/div[5]/div/pre"));
        }

        public IWebElement EditScriptCol()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"view-container\"]/sfn-state-machine-details/sfn-page-layout/awsui-app-layout/div/main/div[2]/div/div/ng-transclude/new-execution-modal/awsui-modal/div[2]/div/div/div[2]/div/span/section[2]/div[2]/awsui-form-field/div/div[2]/div/div/div/ui-codemirror/div/div[6]/div[1]/div/div/div/div[5]/div[1]/pre/span/span"));
        }

        public IWebElement EditScriptcomment()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"view-container\"]/sfn-state-machine-details/sfn-page-layout/awsui-app-layout/div/main/div[2]/div/div/ng-transclude/new-execution-modal/awsui-modal/div[2]/div/div/div[2]/div/span/section[2]/div[2]/awsui-form-field/div/div[2]/div/div/div/ui-codemirror/div/div[6]/div[1]/div/div/div/div[5]/div[2]/pre/span/span[1]"));
        }

        public IWebElement Execute()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"view-container\"]/sfn-state-machine-details/sfn-page-layout/awsui-app-layout/div/main/div[2]/div/div/ng-transclude/new-execution-modal/awsui-modal/div[2]/div/div/div[3]/span/div/div[2]/div/awsui-button[2]/button/span"));
        }
        public IWebElement NewExe()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"view-container\"]/sfn-execution/sfn-page-layout/awsui-app-layout/div/main/div[2]/div/div/ng-transclude/section/new-execution-modal/awsui-modal/div[2]/div/div/div[3]/span/div/div[2]/div/awsui-button[2]/button/span"));
        }

        public IWebElement Scriptenter()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"view-container\"]/sfn-state-machine-details/sfn-page-layout/awsui-app-layout/div/main/div[2]/div/div/ng-transclude/awsui-tabs/div/div/span/sfn-execution-table/awsui-table/div/div[2]/div/div[2]/span/awsui-table-filtering/span/awsui-input/span/input"));
        }
        public IWebElement Profilesignout()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"nav-usernameMenu\"]/div[1]"));
        }
        public IWebElement Signout()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"aws-console-logout\"]"));
        }

        public IWebElement NewExecution()
        {
            return webDriver.FindElement(By.XPath("//*[@text=\"New execution\"]"));
        }

        public IWebElement CancelExecution()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"view-container\"]/sfn-execution/sfn-page-layout/awsui-app-layout/div/main/div[2]/div/div/ng-transclude/section/new-execution-modal/awsui-modal/div[2]/div/div/div[3]/span/div/div[2]/div/awsui-button[1]/button/span"));
        }


    }
}
