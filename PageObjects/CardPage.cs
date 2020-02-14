using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace BillzyAutomationTestSuite.PageObjects
{
    class CardPage
    {
        private IWebDriver webDriver;
        public CardPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public IWebElement CreditCards()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'card-mgmt')] //a[text()='Credit Cards']"));
        }

        public IWebElement BusAccount()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'card-mgmt')] //a[text()='Business Account']"));
        }
        public IWebElement CardName()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"cardName\"]"));
        }
        public IWebElement NumberOnCard()
        {
            return webDriver.FindElement(By.Id("creditCardNo"));
        }

        
        public IWebElement EndMonth()
        {
            return webDriver.FindElement(By.Id("expiryMonth"));
        }


        public IWebElement EndYear()
        {
            return webDriver.FindElement(By.Id("expiryYear"));
        }

        public IWebElement CardNickname()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"cardNickname\"]"));
        }

        public IWebElement CardCvc()
        {
            return webDriver.FindElement(By.Id("cardCvc"));
        }
 

        public IWebElement AddCard()
        {
            return webDriver.FindElement(By.XPath("//div[text()='Add Card']"));
        }

        public IWebElement UpdateCard()
        {
            return webDriver.FindElement(By.XPath("//button[text()='UPDATE']"));
        }

        public IWebElement Cancel()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"cardModal\"]/div/div/div/div/div/div[8]/div[2]/button"));
        }

        public IWebElement ErrorMsg()
        {
            return webDriver.FindElement(By.Id("cards - errmessage"));
        }
        public IWebElement AddCard2()
        {
            return webDriver.FindElement(By.XPath("//button[contains(@class, 'btn primary-btn  add-card ladda-button m-t-0')]"));
        }

        public IWebElement DeleteCard()
        {
            return webDriver.FindElement(By.XPath("(//button[contains(@class, 'delete-card')])[1]"));
        }

        public IWebElement UserProfile()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"collapsable-menu-items\"]/ul[2]/li[1]/a[1]"));
        }

        public IWebElement CardManagement()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"card-mgmt\"]"));
        }

        public IWebElement DeleteCard1()
        {
            return webDriver.FindElement(By.XPath("(//button[text()='Delete Card'])[1]"));
        }

        public IWebElement DeleteCard2()
        {
            return webDriver.FindElement(By.XPath("(//button[text()='Delete Card'])[2]"));
        }
        public IWebElement DeleteCard3()
        {
            return webDriver.FindElement(By.XPath("(//button[text()='Delete Card'])[3]"));
        }
        public IWebElement DeleteCard4()
        {
            return webDriver.FindElement(By.XPath("(//button[text()='Delete Card'])[4]"));
        }
        public IWebElement DeleteCard5()
        {
            return webDriver.FindElement(By.XPath("(//button[text()='Delete Card'])[5]"));
        }
        public IWebElement DeleteCard6()
        {
            return webDriver.FindElement(By.XPath("(//button[text()='Delete Card'])[6]"));
        }
        public IWebElement DeleteCard7()
        {
            return webDriver.FindElement(By.XPath("(//button[text()='Delete Card'])[7]"));
        }
        public IWebElement DeleteCard8()
        {
            return webDriver.FindElement(By.XPath("(//button[text()='Delete Card'])[8]"));
        }
        public IWebElement DeleteCard9()
        {
            return webDriver.FindElement(By.XPath("(//button[text()='Delete Card'])[9]"));
        }
        public IWebElement DeleteCard10()
        {
            return webDriver.FindElement(By.XPath("(//button[text()='Delete Card'])[10]"));
        }
        public IWebElement DeleteCard11()
        {
            return webDriver.FindElement(By.XPath("(//button[text()='Delete Card'])[11]"));
        }
        public IWebElement DeleteCard12()
        {
            return webDriver.FindElement(By.XPath("(//button[text()='Delete Card'])[12]"));
        }
        public IWebElement DeleteCard13()
        {
            return webDriver.FindElement(By.XPath("(//button[text()='Delete Card'])[13]"));
        }
        public IWebElement DeleteCard14()
        {
            return webDriver.FindElement(By.XPath("(//button[text()='Delete Card'])[14]"));
        }
        public IWebElement DeleteCard15()
        {
            return webDriver.FindElement(By.XPath("(//button[text()='Delete Card'])[15]"));
        }
        public IWebElement DeleteCard16()
        {
            return webDriver.FindElement(By.XPath("(//button[text()='Delete Card'])[16]"));
        }
        public IWebElement CardDiv1()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'row active-card-row')])[1]"));
        }
        public IWebElement CardDiv2()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'row active-card-row')])[2]"));
        }
        public IWebElement CardDiv3()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'row active-card-row')])[3]"));
        }
        public IWebElement CardDiv4()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'row active-card-row')])[4]"));
        }
        public IWebElement CardDiv5()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'row active-card-row')])[5]"));
        }
        public IWebElement CardDiv6()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'row active-card-row')])[6]"));
        }
        public IWebElement CardDiv7()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'row active-card-row')])[7]"));
        }
        public IWebElement CardDiv8()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'row active-card-row')])[8]"));
        }
        public IWebElement CardDiv9()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'row active-card-row')])[9]"));
        }
        public IWebElement CardDiv10()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'row active-card-row')])[10]"));
        }
        public IWebElement CardDiv11()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'row active-card-row')])[11]"));
        }
        public IWebElement Row1CardType()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'active-cards-data')]//div[contains(@class, 'row active-card-row')][1]//div[contains(@class, 'row')][1]//div[2]"));
        }
        public IWebElement Row2CardType()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'active-cards-data')]//div[contains(@class, 'row active-card-row')][2]//div[contains(@class, 'row')][1]//div[2]"));
        }
        public IWebElement Row3CardType()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'active-cards-data')]//div[contains(@class, 'row active-card-row')][3]//div[contains(@class, 'row')][1]//div[2]"));
        }
        public IWebElement Row4CardType()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'active-cards-data')]//div[contains(@class, 'row active-card-row')][4]//div[contains(@class, 'row')][1]//div[2]"));
        }
        public IWebElement Row5CardType()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'active-cards-data')]//div[contains(@class, 'row active-card-row')][5]//div[contains(@class, 'row')][1]//div[2]"));
        }
        public IWebElement Row6CardType()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'active-cards-data')]//div[contains(@class, 'row active-card-row')][6]//div[contains(@class, 'row')][1]//div[2]"));
        }
        public IWebElement Row7CardType()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'active-cards-data')]//div[contains(@class, 'row active-card-row')][7]//div[contains(@class, 'row')][1]//div[2]"));
        }
        public IWebElement Row8CardType()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'active-cards-data')]//div[contains(@class, 'row active-card-row')][8]//div[contains(@class, 'row')][1]//div[2]"));
        }
        public IWebElement Row9CardType()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'active-cards-data')]//div[contains(@class, 'row active-card-row')][9]//div[contains(@class, 'row')][1]//div[2]"));
        }
        public IWebElement Row10CardType()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'active-cards-data')]//div[contains(@class, 'row active-card-row')][10]//div[contains(@class, 'row')][1]//div[2]"));
        }
        public IWebElement Row1CardCardName()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'active-cards-data')]//div[contains(@class, 'row active-card-row')][1]//div[contains(@class, 'row')][2]//div[3]"));
        }
        public IWebElement Row2CardCardName()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'active-cards-data')]//div[contains(@class, 'row active-card-row')][2]//div[contains(@class, 'row')][2]//div[3]"));
        }
        public IWebElement Row3CardCardName()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'active-cards-data')]//div[contains(@class, 'row active-card-row')][3]//div[contains(@class, 'row')][2]//div[3]"));
        }
        public IWebElement Row4CardCardName()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'active-cards-data')]//div[contains(@class, 'row active-card-row')][4]//div[contains(@class, 'row')][2]//div[3]"));
        }
        public IWebElement Row5CardCardName()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'active-cards-data')]//div[contains(@class, 'row active-card-row')][5]//div[contains(@class, 'row')][2]//div[3]"));
        }
        public IWebElement Row6CardCardName()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'active-cards-data')]//div[contains(@class, 'row active-card-row')][6]//div[contains(@class, 'row')][2]//div[3]"));
        }
        public IWebElement Row7CardCardName()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'active-cards-data')]//div[contains(@class, 'row active-card-row')][7]//div[contains(@class, 'row')][2]//div[3]"));
        }
        public IWebElement Row8CardCardName()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'active-cards-data')]//div[contains(@class, 'row active-card-row')][8]//div[contains(@class, 'row')][2]//div[3]"));
        }
        public IWebElement Row9CardCardName()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'active-cards-data')]//div[contains(@class, 'row active-card-row')][9]//div[contains(@class, 'row')][2]//div[3]"));
        }
        public IWebElement Row10CardCardName()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'active-cards-data')]//div[contains(@class, 'row active-card-row')][10]//div[contains(@class, 'row')][2]//div[3]"));
        }
        public IWebElement Row1CardCardNumber()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'active-cards-data')]//div[contains(@class, 'row active-card-row')][1]//div[contains(@class, 'row')][1]//div[3]"));
        }
        public IWebElement Row2CardCardNumber()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'active-cards-data')]//div[contains(@class, 'row active-card-row')][2]//div[contains(@class, 'row')][1]//div[3]"));
        }
        public IWebElement Row3CardCardNumber()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'active-cards-data')]//div[contains(@class, 'row active-card-row')][3]//div[contains(@class, 'row')][1]//div[3]"));
        }
        public IWebElement Row4CardCardNumber()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'active-cards-data')]//div[contains(@class, 'row active-card-row')][4]//div[contains(@class, 'row')][1]//div[3]"));
        }
        public IWebElement Row5CardCardNumber()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'active-cards-data')]//div[contains(@class, 'row active-card-row')][5]//div[contains(@class, 'row')][1]//div[3]"));
        }
        public IWebElement Row6CardCardNumber()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'active-cards-data')]//div[contains(@class, 'row active-card-row')][6]//div[contains(@class, 'row')][1]//div[3]"));
        }
        public IWebElement Row7CardCardNumber()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'active-cards-data')]//div[contains(@class, 'row active-card-row')][7]//div[contains(@class, 'row')][1]//div[3]"));
        }
        public IWebElement Row8CardCardNumber()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'active-cards-data')]//div[contains(@class, 'row active-card-row')][8]//div[contains(@class, 'row')][1]//div[3]"));
        }
        public IWebElement Row9CardCardNumber()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'active-cards-data')]//div[contains(@class, 'row active-card-row')][9]//div[contains(@class, 'row')][1]//div[3]"));
        }
        public IWebElement Row10CardCardNumber()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'active-cards-data')]//div[contains(@class, 'row active-card-row')][10]//div[contains(@class, 'row')][1]//div[3]"));
        }
        public IWebElement Row1CardEndDate()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'active-cards-data')]//div[contains(@class, 'row active-card-row')][1]//div[contains(@class, 'row')][2]//div[5]"));
        }
        public IWebElement Row2CardEndDate()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'active-cards-data')]//div[contains(@class, 'row active-card-row')][2]//div[contains(@class, 'row')][2]//div[5]"));
        }
        public IWebElement Row3CardEndDate()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'active-cards-data')]//div[contains(@class, 'row active-card-row')][3]//div[contains(@class, 'row')][2]//div[5]"));
        }
        public IWebElement Row4CardEndDate()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'active-cards-data')]//div[contains(@class, 'row active-card-row')][4]//div[contains(@class, 'row')][2]//div[5]"));
        }
        public IWebElement Row5CardEndDate()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'active-cards-data')]//div[contains(@class, 'row active-card-row')][5]//div[contains(@class, 'row')][2]//div[5]"));
        }
        public IWebElement Row6CardEndDate()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'active-cards-data')]//div[contains(@class, 'row active-card-row')][6]//div[contains(@class, 'row')][2]//div[5]"));
        }
        public IWebElement Row7CardEndDate()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'active-cards-data')]//div[contains(@class, 'row active-card-row')][7]//div[contains(@class, 'row')][2]//div[5]"));
        }
        public IWebElement Row8CardEndDate()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'active-cards-data')]//div[contains(@class, 'row active-card-row')][8]//div[contains(@class, 'row')][2]//div[5]"));
        }
        public IWebElement Row9CardEndDate()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'active-cards-data')]//div[contains(@class, 'row active-card-row')][9]//div[contains(@class, 'row')][2]//div[5]"));
        }
        public IWebElement Row10CardEndDate()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'active-cards-data')]//div[contains(@class, 'row active-card-row')][10]//div[contains(@class, 'row')][2]//div[5]"));
        }

        
        public IWebElement BankAccountTitles()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"card-mgmt-debit-tab\"]/div/div/div[2]/div[2]/div"));
        }

        public IWebElement BankAccountData()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"card-mgmt-debit-tab\"]/div/div/div[4]"));
        }

        public IWebElement CardTitles()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"card-mgmt-credit-tab\"]/div/div[1]/div[2]/div[1]/div"));
        }

        public IWebElement CardData()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"card-mgmt-credit-tab\"]/div/div[1]/div[4]/div"));
        }
        public IWebElement Deleteaccount()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"card-mgmt-debit-tab\"]/div/div/div[4]/div/div[1]/div/div[9]/button"));
        }

        public IWebElement BillzyAccountTab()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"bsb-payway-pills\"]/a"));
        }

        public IWebElement Pawaybsb()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"recPWayAcctBSB\"]"));
        }

        public IWebElement Pawayaccnumber()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"recPWayAcctNumber\"]"));
        }

      

        //*[@id="card-mgmt-debit-tab"]/div/div/div[4]/div/div[1]/div/div[9]/button

    }
}
