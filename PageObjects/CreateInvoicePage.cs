using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace BillzyAutomationTestSuite.PageObjects
{
    class CreateInvoicePage
    {
        private IWebDriver webDriver;
        public CreateInvoicePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }


        public IWebElement CreateInvoiceBTN()
        {
            return webDriver.FindElement(By.XPath("(//div[@style = 'display: block;'] //div[contains(text(),'Create Invoice')])[1]"));
        }
        public IWebElement CreateInvoiceTitlePage()
        {
            return webDriver.FindElement(By.XPath("//div[@class= 'create-invoice'] //h2[text()='Create Invoice']"));
        }

        public IWebElement Recipient()
        {
            return webDriver.FindElement(By.Id("recipients-name"));
        }
        public IWebElement RecipientsEmail()
        {
            return webDriver.FindElement(By.Id("recipients-email"));
        }
        public IWebElement InvoiceNumber()
        {
            return webDriver.FindElement(By.Id("invoice-number"));
        }
        public IWebElement InvoiceDate()
        {
            return webDriver.FindElement(By.Id("invoice-date"));
        }
        public IWebElement InvoiceDueDate()
        {
            return webDriver.FindElement(By.Id("due-date"));
        }
        public IWebElement InvoiceAmt()
        {
            return webDriver.FindElement(By.Id("invoice-amount"));
        }
        public IWebElement PaymentTerms()
        {
            return webDriver.FindElement(By.Id("payment-terms"));
        }
        public IWebElement LateFee()
        {
            return webDriver.FindElement(By.Id("late-fees"));
        }
        public IWebElement WarningMsg()
        {
            return webDriver.FindElement(By.Id("invoice-amount-message"));
        }
        public IWebElement BusinessName()
        {
            return webDriver.FindElement(By.XPath("//button[contains(@class, 'btn btn-default dropdown-toggle business-name-selected')]"));
        }
        public IWebElement SelectBusiness1()
        {
            return webDriver.FindElement(By.XPath("(//li[contains(@class, 'clients-list-dd')])[1]"));
        }
        public IWebElement SelectBusiness2()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'form-group required')]/li[2]"));
        }
        public IWebElement SelectBusiness3()
        {
            return webDriver.FindElement(By.XPath("(//li[contains(@class, 'clients-list-dd')])[3]"));
        }

        public IWebElement Select1()
        {
            return webDriver.FindElement(By.XPath("//ul[contains(@class, 'dropdown-menu business-name-list')] //li//a[contains(@value, '0')]"));
        }
        public IWebElement Select2()
        {
            return webDriver.FindElement(By.XPath("//ul[contains(@class, 'dropdown-menu business-name-list')] //li//a[contains(@value, '1')]"));
        }
        public IWebElement Select3()
        {
            return webDriver.FindElement(By.XPath("//ul[contains(@class, 'dropdown-menu business-name-list')] //li//a[contains(@value, '2')]"));
        }
        public IWebElement Select4()
        {
            return webDriver.FindElement(By.XPath("//ul[contains(@class, 'dropdown-menu business-name-list')] //li//a[contains(@value, '3')]"));
        }
        public IWebElement Select5()
        {
            return webDriver.FindElement(By.XPath("//ul[contains(@class, 'dropdown-menu business-name-list')] //li//a[contains(@value, '4')]"));
        }
        public IWebElement Select6()
        {
            return webDriver.FindElement(By.XPath("//ul[contains(@class, 'dropdown-menu business-name-list')] //li//a[contains(@value, '5')]"));
        }
        public IWebElement Select7()
        {
            return webDriver.FindElement(By.XPath("//ul[contains(@class, 'dropdown-menu business-name-list')] //li//a[contains(@value, '6')]"));
        }
        public IWebElement Select8()
        {
            return webDriver.FindElement(By.XPath("//ul[contains(@class, 'dropdown-menu business-name-list')] //li//a[contains(@value, '7')]"));
        }
        public IWebElement Select9()
        {
            return webDriver.FindElement(By.XPath("//ul[contains(@class, 'dropdown-menu business-name-list')] //li//a[contains(@value, '8')]"));
        }
        public IWebElement Select10()
        {
            return webDriver.FindElement(By.XPath("//ul[contains(@class, 'dropdown-menu business-name-list')] //li//a[contains(@value, '9')]"));
        }
        public IWebElement Select11()
        {
            return webDriver.FindElement(By.XPath("//ul[contains(@class, 'dropdown-menu business-name-list')] //li//a[contains(@value, '10')]"));
        }
        public IWebElement Select12()
        {
            return webDriver.FindElement(By.XPath("//ul[contains(@class, 'dropdown-menu business-name-list')] //li//a[contains(@value, '11')]"));
        }
        public IWebElement Select13()
        {
            return webDriver.FindElement(By.XPath("//ul[contains(@class, 'dropdown-menu business-name-list')] //li//a[contains(@value, '12')]"));
        }
        public IWebElement Select14()
        {
            return webDriver.FindElement(By.XPath("//ul[contains(@class, 'dropdown-menu business-name-list')] //li//a[contains(@value, '13')]"));
        }
        public IWebElement Select15()
        {
            return webDriver.FindElement(By.XPath("//ul[contains(@class, 'dropdown-menu business-name-list')] //li//a[contains(@value, '14')]"));
        }
        public IWebElement CompleteInvoiceBTN()
        {
            return webDriver.FindElement(By.XPath("//button[text()='COMPLETE INVOICE']"));
        }
        public IWebElement ConfirmInvoiceBTN()
        {
            return webDriver.FindElement(By.XPath("//button[text()='CONFIRM INVOICE']"));
        }
        public IWebElement AddClient()
        {
            return webDriver.FindElement(By.XPath("//button[text()='ADD NEW CLIENT']"));
        }
        public IWebElement CancelInvoiceBTN()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'row')] //button[text()='CANCEL'])[1]"));
        }
        public IWebElement CommonArea()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'create-invoice-input-form')] //div[contains(@class, 'row invoice-total-section')]"));
        }
        public IWebElement EmailBody()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'form-group')] //textarea[@id='email-message1']"));
        }
        public IWebElement BackBTN()
        {
            return webDriver.FindElement(By.XPath("//button[text()='BACK']"));
        }
        public IWebElement SendInvoiceBTN()
        {
            return webDriver.FindElement(By.XPath("//button[contains(@class, 'btn send-email-btn ladda-button')]"));
        }
        public IWebElement CancelEmailBTN()
        {
            return webDriver.FindElement(By.XPath("(//button[text()='CANCEL'])[2]"));
        }
        public IWebElement CancelBTN()
        {
            return webDriver.FindElement(By.Id("cancel-add-client-btn"));
        }
        public IWebElement UploadBTN()
        {
            return webDriver.FindElement(By.Id("uploadCancelBtn"));
        }
        public IWebElement AlternativeName()
        {
            return webDriver.FindElement(By.Id("user-friendly-name"));
        }
        public IWebElement EmailSubject()
        {
            return webDriver.FindElement(By.Id("email-subject"));
        }
        public IWebElement EmailFooter()
        {
            return webDriver.FindElement(By.Id("email-message2"));
        }

    }
}
