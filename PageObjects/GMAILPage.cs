using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace BillzyAutomationTestSuite.PageObjects
{
    class GMAILPage
    {

        private IWebDriver webDriver;
        public GMAILPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public IWebElement Username()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"identifierId\"]"));
        }
        public IWebElement Antotheraccount()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"view_container\"]/div/div/div[2]/div/div[1]/div/form/span/section/div/div/div/div/ul/li[2]/div/div/div[2]"));
        }

        public IWebElement UserNext()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"identifierNext\"]/span/span"));
        }

        public IWebElement Password()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"password\"]/div[1]/div/div[1]/input"));
        }

        public IWebElement PasswordNext()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"passwordNext\"]/span"));
        }

        public IWebElement Search()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"gs_lc50\"]/input[1]"));
        }

        public IWebElement SearchOption()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"aso_search_form_anchor\"]/button[2]"));
        }
        public IWebElement SearchButton()
        {
            return webDriver.FindElement(By.XPath("//div//div//div//div//*[@data-tooltip=\"Search Mail\"]"));
        }

        public IWebElement NoMail()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\":1\"]/div/div[2]/div[5]/div[3]/table/tbody/tr/td"));
        }
        public IWebElement SearchClear()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"aso_search_form_anchor\"]/button[3]"));
        }

        public IWebElement Selection()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\":1j9\"]"));
        }

        public IWebElement PDF()
        {
            return webDriver.FindElement(By.XPath("//*[contains(@aria-label,'Save attachment')]/div"));
           // return webDriver.FindElement(By.XPath("//*[@class=\"aSH\"]/div/div/div/div[1]/span"));
        }
        public IWebElement Verify()
        {
            return webDriver.FindElement(By.XPath("//*[@class=\"gs\"]/div/div/div/div[1]/table[2]/tbody/tr[2]/td[2]/table/tbody/tr[7]/td/div/a"));
        }
        public IWebElement logo()
        {
            return webDriver.FindElement(By.XPath("//*[@role=\"listitem\"]/div/div/div/div/div/div/div/div/div/div[1]/table[1]/tbody/tr[2]/td/a/table/tbody/tr/td[1]/img"));
        }
        public IWebElement profile()
        {
            return webDriver.FindElement(By.XPath("//*[@role=\"banner\"]/div[2]/div[3]/div/div[2]/div/a/span"));
        }
        public IWebElement signout()
        {
            return webDriver.FindElement(By.XPath("//a[contains(@href,'https://accounts.google.com/Logout?')]"));
        }
        public IWebElement bpay()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"bpay-image\"]"));
        }
        public IWebElement paypageverify()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"external-bill-verify-button\"]/span[1]"));
        }
        

        public IWebElement paypageverified()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"external-bill-verified-span\"]"));
        }

        public IWebElement cardname()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"billTo-name\"]"));
        }
        public IWebElement SetYourPwd()
        {
            return webDriver.FindElement(By.XPath("//*[@class=\"ii gt\"]/div/div/table[2]/tbody/tr[2]/td[2]/table/tbody/tr[4]/td/div/a"));
        }

        public IWebElement Email()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"set-password-username\"]"));
        }
        public IWebElement Temppwd()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"set-password-temp-password\"]"));
        }
        public IWebElement Newpwd()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"set-password-new-password\"]"));
        }
        public IWebElement Conpwd()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"set-password-new-password-retype\"]"));
        }
        public IWebElement SetYourPwdbutton()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"set-password-button\"]"));
        }
        public IWebElement BacktoSearchresult()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\":4\"]/div[3]/div[1]/div/div[1]/div/div"));
        }
        public IWebElement Panel()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\":4\"]/div[3]"));
        }
        public IWebElement Dealmailcount()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\":qa\"]/span"));
        }

        public IWebElement Dealmailcount1()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\":wt\"]/span/span[1]/span[2]"));
        }

        public IWebElement CardName()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"billTo-name\"]"));
        }

        public IWebElement CardNumber()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"billTo-card-number\"]"));
        }

        public IWebElement Expmon()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"billTo-expiryMonth\"]"));
        }

        public IWebElement ExpYY()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"billTo-expiryYear\"]"));
        }

        public IWebElement CVC()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"billTo-cardCvc\"]"));
        }

        public IWebElement PAY()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"external-bill-pay-button\"]"));
        }
        public IWebElement Successmsg()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"external-payment-success\"]/div[2]/h2"));
        }
    }
}
