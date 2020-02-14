using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace BillzyAutomationTestSuite.PageObjects
{
    class PayNowPage
    {
        private IWebDriver webDriver;
        public PayNowPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
        //*[@id="wrapper"]/div[4]/div[2]/div[1]/div[4]/div/div/div[2]/div[8]/div/div
        
        public IWebElement CcDropDown()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'card-drop-down')]"));
        }
        public IWebElement FirstCC()
        {
            return webDriver.FindElement(By.XPath("//li[contains(@class, 'cc-list-dd')]/a[@value = '3']"));
        }
        public IWebElement NoSplitReady()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'no-split-ready')]"));
        }
        public IWebElement ConfirmPayBTN()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'received')] //button[contains(@class, 'pay-now-confirmpay-btn')] //span[text()='CONFIRM PAYMENT']"));
        }
        public IWebElement DoneBTN()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'doneBtn')]"));
        }
        public IWebElement CancelBTN()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'received')] //button[text()='CANCEL']"));
        }
        public IWebElement PayNowTitle()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'pay-now')] //h1[text()='Pay Now']"));
        }
        public IWebElement PayableRow1()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'pay-now')] //div[contains(@class, 'table-row combined-row pay-now-row')][1] /div[3]"));
        }
        public IWebElement ConfirmPaymentBTN()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'pay-now')]  //button[contains(@class, 'btn pay-now-confirmpay-btn')] //span[text()= 'CONFIRM PAYMENT']"));
        }
        public IWebElement ConfirmPaymentProp()
        {
            return webDriver.FindElement(By.XPath("(//button[@class= 'btn pay-now-confirmpay-btn bold ladda-button'])[1]"));
        }
        public IWebElement TotalItemsCount()
        {
            return webDriver.FindElement(By.XPath("//div[@class= 'pay-now'] //div[contains(@class, 'pay-now-total-row')] //span[@class= 'total-items']"));
        }
        public IWebElement TotalAmount()
        {
            return webDriver.FindElement(By.XPath("//div[@class= 'pay-now'] //div[contains(@class, 'pay-now-total-row')] //span[@class= 'pay-now-total-amount']"));
        }

        //Sender's Business

        public IWebElement Row01SendersBusiness()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[1])[01]"));
        }
        public IWebElement Row02SendersBusiness()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[1])[02]"));
        }
        public IWebElement Row03SendersBusiness()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[1])[03]"));
        }
        public IWebElement Row04SendersBusiness()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[1])[04]"));
        }
        public IWebElement Row05SendersBusiness()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[1])[05]"));
        }
        public IWebElement Row06SendersBusiness()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[1])[06]"));
        }
        public IWebElement Row07SendersBusiness()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[1])[07]"));
        }
        public IWebElement Row08SendersBusiness()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[1])[08]"));
        }
        public IWebElement Row09SendersBusiness()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[1])[09]"));
        }
        public IWebElement Row10SendersBusiness()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[1])[10]"));
        }
        public IWebElement Row11SendersBusiness()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[1])[11]"));
        }
        public IWebElement Row12SendersBusiness()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[1])[12]"));
        }
        public IWebElement Row13SendersBusiness()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[1])[13]"));
        }
        public IWebElement Row14SendersBusiness()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[1])[14]"));
        }
        //### Invoice #

        public IWebElement Row01InvoiceNum()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[2])[01]"));
        }
        public IWebElement Row02InvoiceNum()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[2])[02]"));
        }
        public IWebElement Row03InvoiceNum()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[2])[03]"));
        }
        public IWebElement Row04InvoiceNum()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[2])[04]"));
        }
        public IWebElement Row05InvoiceNum()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[2])[05]"));
        }
        public IWebElement Row06InvoiceNum()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[2])[06]"));
        }
        public IWebElement Row07InvoiceNum()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[2])[07]"));
        }
        public IWebElement Row08InvoiceNum()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[2])[08]"));
        }
        public IWebElement Row09InvoiceNum()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[2])[09]"));
        }
        public IWebElement Row10InvoiceNum()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[2])[10]"));
        }
        public IWebElement Row11InvoiceNum()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[2])[11]"));
        }
        public IWebElement Row12InvoiceNum()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[2])[12]"));
        }
        public IWebElement Row13InvoiceNum()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[2])[13]"));
        }
        public IWebElement Row14InvoiceNum()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[2])[14]"));
        }
        //### Due In

        public IWebElement Row01DueIn()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[3])[01]"));
        }
        public IWebElement Row02DueIn()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[3])[02]"));
        }
        public IWebElement Row03DueIn()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[3])[03]"));
        }
        public IWebElement Row04DueIn()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[3])[04]"));
        }
        public IWebElement Row05DueIn()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[3])[05]"));
        }
        public IWebElement Row06DueIn()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[3])[06]"));
        }
        public IWebElement Row07DueIn()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[3])[07]"));
        }
        public IWebElement Row08DueIn()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[3])[08]"));
        }
        public IWebElement Row09DueIn()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[3])[09]"));
        }
        public IWebElement Row10DueIn()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[3])[10]"));
        }
        public IWebElement Row11DueIn()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[3])[11]"));
        }
        public IWebElement Row12DueIn()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[3])[12]"));
        }
        public IWebElement Row13DueIn()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[3])[13]"));
        }
        public IWebElement Row14DueIn()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[3])[14]"));
        }
        //### Total

        public IWebElement Row01Total()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[4])[01]"));
        }
        public IWebElement Row02Total()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[4])[02]"));
        }
        public IWebElement Row03Total()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[4])[03]"));
        }
        public IWebElement Row04Total()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[4])[04]"));
        }
        public IWebElement Row05Total()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[4])[05]"));
        }
        public IWebElement Row06Total()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[4])[06]"));
        }
        public IWebElement Row07Total()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[4])[07]"));
        }
        public IWebElement Row08Total()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[4])[08]"));
        }
        public IWebElement Row09Total()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[4])[09]"));
        }
        public IWebElement Row10Total()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[4])[10]"));
        }
        public IWebElement Row11Total()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[4])[11]"));
        }
        public IWebElement Row12Total()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[4])[12]"));
        }
        public IWebElement Row13Total()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[4])[13]"));
        }
        public IWebElement Row14Total()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'pay-now'] //div[@class= 'row'] /div[4])[14]"));
        }
        //### Select Card

        public IWebElement Row01SelectCard()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'pay-now')] //div[contains(@class, 'creditCardMenu')])[01]"));
        }
        public IWebElement Row02SelectCard()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'pay-now')] //div[contains(@class, 'creditCardMenu')])[02]"));
        }
        public IWebElement Row03SelectCard()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'pay-now')] //div[contains(@class, 'creditCardMenu')])[03]"));
        }
        public IWebElement Row04SelectCard()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'pay-now')] //div[contains(@class, 'creditCardMenu')])[04]"));
        }
        public IWebElement Row05SelectCard()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'pay-now')] //div[contains(@class, 'creditCardMenu')])[05]"));
        }
        public IWebElement Row06SelectCard()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'pay-now')] //div[contains(@class, 'creditCardMenu')])[06]"));
        }
        public IWebElement Row07SelectCard()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'pay-now')] //div[contains(@class, 'creditCardMenu')])[07]"));
        }
        public IWebElement Row08SelectCard()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'pay-now')] //div[contains(@class, 'creditCardMenu')])[08]"));
        }
        public IWebElement Row09SelectCard()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'pay-now')] //div[contains(@class, 'creditCardMenu')])[09]"));
        }
        public IWebElement Row10SelectCard()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'pay-now')] //div[contains(@class, 'creditCardMenu')])[10]"));
        }
        public IWebElement Row11SelectCard()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'pay-now')] //div[contains(@class, 'creditCardMenu')])[11]"));
        }
        public IWebElement Row12SelectCard()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'pay-now')] //div[contains(@class, 'creditCardMenu')])[12]"));
        }
        public IWebElement Row13SelectCard()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'pay-now')] //div[contains(@class, 'creditCardMenu')])[13]"));
        }
        public IWebElement Row14SelectCard()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'pay-now')] //div[contains(@class, 'creditCardMenu')])[14]"));
        }
        //### Amount Payable

        public IWebElement Row01AmountPayable()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'pay-now')] //input[contains(@class, 'form-control amt-payable')])[01]"));
        }
        public IWebElement Row02AmountPayable()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'pay-now')] //input[contains(@class, 'form-control amt-payable')])[02]"));
        }
        public IWebElement Row03AmountPayable()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'pay-now')] //input[contains(@class, 'form-control amt-payable')])[03]"));
        }
        public IWebElement Row04AmountPayable()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'pay-now')] //input[contains(@class, 'form-control amt-payable')])[04]"));
        }
        public IWebElement Row05AmountPayable()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'pay-now')] //input[contains(@class, 'form-control amt-payable')])[05]"));
        }
        public IWebElement Row06AmountPayable()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'pay-now')] //input[contains(@class, 'form-control amt-payable')])[06]"));
        }
        public IWebElement Row07AmountPayable()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'pay-now')] //input[contains(@class, 'form-control amt-payable')])[07]"));
        }
        public IWebElement Row08AmountPayable()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'pay-now')] //input[contains(@class, 'form-control amt-payable')])[08]"));
        }
        public IWebElement Row09AmountPayable()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'pay-now')] //input[contains(@class, 'form-control amt-payable')])[09]"));
        }
        public IWebElement Row10AmountPayable()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'pay-now')] //input[contains(@class, 'form-control amt-payable')])[10]"));
        }
        public IWebElement Row11AmountPayable()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'pay-now')] //input[contains(@class, 'form-control amt-payable')])[11]"));
        }
        public IWebElement Row12AmountPayable()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'pay-now')] //input[contains(@class, 'form-control amt-payable')])[12]"));
        }
        public IWebElement Row13AmountPayable()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'pay-now')] //input[contains(@class, 'form-control amt-payable')])[13]"));
        }
        public IWebElement Row14AmountPayable()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'pay-now')] //input[contains(@class, 'form-control amt-payable')])[14]"));
        }
        //### Actions

        public IWebElement Row01SplitBTN()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'pay-now')] //button[text() = 'Split'])[01]"));
        }
        public IWebElement Row02SplitBTN()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'pay-now')] //button[text() = 'Split'])[02]"));
        }
        public IWebElement Row03SplitBTN()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'pay-now')] //button[text() = 'Split'])[03]"));
        }
        public IWebElement Row04SplitBTN()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'pay-now')] //button[text() = 'Split'])[04]"));
        }
        public IWebElement Row05SplitBTN()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'pay-now')] //button[text() = 'Split'])[05]"));
        }
        public IWebElement Row06SplitBTN()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'pay-now')] //button[text() = 'Split'])[06]"));
        }
        public IWebElement Row07SplitBTN()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'pay-now')] //button[text() = 'Split'])[07]"));
        }
        public IWebElement Row08SplitBTN()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'pay-now')] //button[text() = 'Split'])[08]"));
        }
        public IWebElement Row09SplitBTN()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'pay-now')] //button[text() = 'Split'])[09]"));
        }
        public IWebElement Row10SplitBTN()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'pay-now')] //button[text() = 'Split'])[10]"));
        }
        public IWebElement Row11SplitBTN()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'pay-now')] //button[text() = 'Split'])[11]"));
        }
        public IWebElement Row12SplitBTN()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'pay-now')] //button[text() = 'Split'])[12]"));
        }
        public IWebElement Row13SplitBTN()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'pay-now')] //button[text() = 'Split'])[13]"));
        }
        public IWebElement Row14SplitBTN()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'pay-now')] //button[text() = 'Split'])[14]"));
        }
        //### Drop down from Select Card

        public IWebElement CardRow01()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[1]/div[4]/div/div/div[2]/div[8]/div/ul/li[1]/span[2]/a/table/tbody/tr/td[2]"));
        }
        public IWebElement CardRow02()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[1]/div[4]/div/div/div[2]/div[8]/div/ul/li[2]/span[2]/a/table/tbody/tr/td[2]"));
        }
        public IWebElement CardRow03()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[1]/div[4]/div/div/div[2]/div[8]/div/ul/li[3]/span[2]/a/table/tbody/tr/td[2]"));
        }
        public IWebElement CardRow04()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[1]/div[4]/div/div/div[2]/div[8]/div/ul/li[4]/span[2]/a/table/tbody/tr/td[2]"));
        }
        public IWebElement CardRow05()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[1]/div[4]/div/div/div[2]/div[8]/div/ul/li[5]/span[2]/a/table/tbody/tr/td[2]"));
        }
        public IWebElement Card1()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[1]/div[4]/div/div/div[2]/div[8]/div/ul/li[1]/span[2]/a/table/tbody/tr/td[2]"));
        }
        public IWebElement Bank1()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[1]/div[4]/div/div/div[2]/div[8]/div/ul/li[2]/span[2]/a/table/tbody/tr/td[2]"));
        }
        public IWebElement verifyBank1()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[1]/div[4]/div/div/div[2]/div[8]/div/ul/li[2]/span[2]/a/table/tbody/tr/td[2]"));
        }

        //*[@id="wrapper"]/div[4]/div[2]/div[1]/div[4]/div/div/div[2]/div[8]/div/ul/li[2]/span[2]/a/table/tbody/tr/td[2]
        public IWebElement Card2()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[1]/div[4]/div/div[2]/div[2]/div[8]/div/ul/li[1]/span[2]/a/table/tbody/tr/td[2]"));
                                                  
        }
        public IWebElement Card3()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[1]/div[4]/div/div[2]/div[2]/div[8]/div/ul/li[2]/span[2]/a/table/tbody/tr/td[2]"));
                                                     
        }

        public IWebElement CardRow06()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[1]/div[4]/div/div/div[2]/div[8]/div/ul/li[6]/span[2]/a/table/tbody/tr/td[2]"));
        }
        public IWebElement CardRow07()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[1]/div[4]/div/div/div[2]/div[8]/div/ul/li[7]/span[2]/a/table/tbody/tr/td[2]"));
        }
        public IWebElement CardRow08()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[1]/div[4]/div/div/div[2]/div[8]/div/ul/li[8]/span[2]/a/table/tbody/tr/td[2]"));
        }
        public IWebElement CardRow09()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[1]/div[4]/div/div/div[2]/div[8]/div/ul/li[9]/span[2]/a/table/tbody/tr/td[2]"));
        }
        public IWebElement CardRow10()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[1]/div[4]/div/div/div[2]/div[8]/div/ul/li[10]/span[2]/a/table/tbody/tr/td[2]"));
        }
        public IWebElement CardRow11()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[1]/div[4]/div/div/div[2]/div[8]/div/ul/li[11]/span[2]/a/table/tbody/tr/td[2]"));
        }
        public IWebElement CardRow12()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[1]/div[4]/div/div/div[2]/div[8]/div/ul/li[12]/span[2]/a/table/tbody/tr/td[2]"));
        }
        public IWebElement CardRow13()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[1]/div[4]/div/div/div[2]/div[8]/div/ul/li[13]/span[2]/a/table/tbody/tr/td[2]"));
        }
        public IWebElement CardRow14()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[1]/div[4]/div/div/div[2]/div[8]/div/ul/li[14]/span[2]/a/table/tbody/tr/td[2]"));
        }
        //### Drop down from Select Card #2
        

        public IWebElement SelectCard2()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[1]/div[4]/div/div[2]/div[2]/div[8]/div/ul/li[1]/span[2]/a/table/tbody/tr/td[2]"));
        }
        public IWebElement SelectinvalidCard2()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[1]/div[4]/div/div[2]/div[2]/div[8]/div/ul/li[3]/span[2]/a/table/tbody/tr/td[2]"));
        }

        public IWebElement Selectinvalidbank2()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[1]/div[4]/div/div[2]/div[2]/div[8]/div/ul/li[1]/span[2]/a/table/tbody/tr/td[2]"));
        }
        public IWebElement Selectinvalidbank3()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[1]/div[4]/div/div[2]/div[2]/div[8]/div/ul/li[2]/span[2]/a/table/tbody/tr/td[2]"));
        } 

        public IWebElement Selectvalidbank2()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[1]/div[4]/div/div[2]/div[2]/div[8]/div/ul/li[3]/span[2]/a/table/tbody/tr/td[2]"));
        }
        //*[@id="wrapper"]/div[4]/div[2]/div[1]/div[4]/div/div[2]/div[2]/div[8]/div/ul/li[3]/span[2]/a/table/tbody/tr/td[2]

        public IWebElement SelectCard2CardRow01()
        {
            return webDriver.FindElement(By.XPath("((//ul[contains(@class, 'dropdown-menu creditCardList')]) [2] //li[@class = 'cc-list-dd'] /a/span[2]/table/tbody/tr/td[2] )[1]"));
        }
        public IWebElement SelectCard2CardRow02()
        {
            return webDriver.FindElement(By.XPath("((//ul[contains(@class, 'dropdown-menu creditCardList')]) [2] //li[@class = 'cc-list-dd'] /a/span[2]/table/tbody/tr/td[2] )[2]"));
        }
        public IWebElement SelectCard2CardRow03()
        {
            return webDriver.FindElement(By.XPath("((//ul[contains(@class, 'dropdown-menu creditCardList')]) [2] //li[@class = 'cc-list-dd'] /a/span[2]/table/tbody/tr/td[2] )[3]"));
        }
        public IWebElement SelectCard2CardRow04()
        {
            return webDriver.FindElement(By.XPath("((//ul[contains(@class, 'dropdown-menu creditCardList')]) [2] //li[@class = 'cc-list-dd'] /a/span[2]/table/tbody/tr/td[2] )[4]"));
        }

    }
}
