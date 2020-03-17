using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace BillzyAutomationTestSuite.PageObjects
{
    class BOBOPage
    {
        private IWebDriver webDriver;
        public BOBOPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
        public IWebElement Username()
        {
            return webDriver.FindElement(By.Id("username"));
        }
        public IWebElement Password()
        {
            return webDriver.FindElement(By.Id("password"));
        }
        public IWebElement LoginBTN()
        {
            return webDriver.FindElement(By.Id("login-button"));
        }
        public IWebElement WelcomeMessage()
        {
            return webDriver.FindElement(By.XPath("//*[@id='create-contact-form'] /h2"));
        }
        

        public IWebElement IssueMessage()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issue-form\"]/text()[3]"));
        }



        public IWebElement UserWelcomeMessage()
        {
            return webDriver.FindElement(By.XPath("//*[@id='issue-form']/h2"));
        }

        public IWebElement PdfUpload()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"pdfupload\"]"));
        }
        public IWebElement PdfUploadTPB()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"pdfupload_tpb\"]"));
        }

        public IWebElement CreateAccountOnBehalfOf()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"contact-business-list\"]"));
        }
        public IWebElement ExistingCustomer()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"create-contact-form\"]/select[2]"));
        }
        public IWebElement BusinessName()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"create-contact-form\"]/input[1]"));
        }
        public IWebElement ABN()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"create-contact-form\"]/input[2]"));
        }
        public IWebElement ContactName()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"create-contact-form\"]/input[3]"));
        }
        public IWebElement ContactEmail()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"create-contact-form\"]/input[4]"));
        }
        public IWebElement ContactPhoneNumber()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"create-contact-form\"]/input[5]"));
        }
        public IWebElement Street()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"create-contact-form\"]/input[6]"));
        }
        public IWebElement Suburb()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"create-contact-form\"]/input[7]"));
        }
        public IWebElement PostCode()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"create-contact-form\"]/input[8]"));
        }
        public IWebElement State()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"create-contact-form\"]/select[3]"));
        }
        public IWebElement CreateInternalContact()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"create-contact-form\"]/button[2]"));
        }
        public IWebElement CreateExternalContact()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"create-contact-form\"]/button[3]"));
        }
        public IWebElement Message()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class,'swal-text')] "));
        }
        public IWebElement CreateAnoterContact()
        {
            return webDriver.FindElement(By.XPath("//button[contains(@class,'swal-button swal-button--createAnother')]"));
        }
        public IWebElement IssueAnInvoice()
        {
            return webDriver.FindElement(By.XPath("//button[contains(@class,'swal-button swal-button--issueInvoice')]"));
        }
        public IWebElement CreateANewThirdPartyBiller()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"third_party_biller_div\"]/button[1]"));
        }
        public IWebElement ExistingCustomer1()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"create-contact-form\"]/select[2]"));
        }
        public IWebElement BusinessName1()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"tpb-name\"]"));
        }
        public IWebElement ABN1()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"tpb-abn\"]"));
        }
        public IWebElement BillerEmail1()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"tpb-email\"]"));
        }
        public IWebElement ContactEmail1()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"tpb-email\"]"));
        }
        public IWebElement Bsb1()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"tpb-bsb\"]"));
        }
        public IWebElement BankAccountNumber()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"tpb-account-num\"]"));
        }
        public IWebElement BankAccountName()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"tpb-account-name\"]"));
        }
        public IWebElement CreateNewThirdPartyBiller()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"create-tpb-form\"]/button[2]"));
        }
        public IWebElement CreateAnotherBtnTPB()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'swal-button-container')][1]"));
        }
        public IWebElement IssueAnInvoiceBtnTPB()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'swal-button-container')][2]"));
        }
        //BOBO Main Page
        public IWebElement WelcomeMessage1()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issue-form\"] /h2"));
        }
        public IWebElement BillzyBiller()
        {
            return webDriver.FindElement(By.Id("billzy_biller_radio"));
        }
        public IWebElement ThirdPartyBiller()
        {
            return webDriver.FindElement(By.Id("third_party_biller_radio"));
        }
        public IWebElement UpdateExistingBillzyInvoice()
        {
            return webDriver.FindElement(By.Id("update_invoice_radio"));
        }
        public IWebElement IssueInvoiceOnBehalfOf()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issue-inv-business\"] "));
        }
        public IWebElement IssueInvoiceOnBehalfOfTPB()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issue-inv-business_tpb\"]"));
        }
        public IWebElement IssueInvoiceTo()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issue-inv-contact\"]"));
        }
        public IWebElement IssueInvoiceToTPB()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issue-inv-contact_tpb\"]"));
        }
        public IWebElement EmailTo()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issue-contact-email\"]"));
        }
        public IWebElement EmailToTPB()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issue-contact-email_tpb\"]"));
        }
        public IWebElement Reference()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issue-reference\"]"));
        }
        public IWebElement ReferenceTPB()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issue-reference_tpb\"]"));
        }
        public IWebElement InvoiceDueDate()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issue-due-date\"]"));
        }
        public IWebElement InvoiceDueDateTPB()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issue-due-date_tpb\"]"));
        }
        public IWebElement InvoiceIssueDate()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issue-issue-date\"]"));
        }
        public IWebElement InvoiceIssueDateTPB()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issue-issue-date_tpb\"]"));
        }
        public IWebElement TotalAmount()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issue-amount\"]"));
        }
        public IWebElement TotalAmountTPB()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issue-amount_tpb\"]"));
        }
        public IWebElement Surcharge()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issue-surcharge\"]"));
        }
        public IWebElement RequestCash()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issue-cash\"]"));
        }
        public IWebElement CreateNewContactBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"billzy_biller_div\"]/button[1]"));
        }
        public IWebElement BrowseBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"pdfupload\"]"));
        }
        public IWebElement BrowseBTNTPB()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"pdfupload_tpb\"]"));
        }
        public IWebElement ChooseFile()
        {
            return webDriver.FindElement(By.Id("photoupload"));
        }
        public IWebElement Message1()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'swal-modal')] //div[contains(@class, 'swal-text')]"));
        }
        public IWebElement Issue()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issue-inv-btn\"]"));
        }
        public IWebElement IssueTPB()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issue-tpb-inv-btn\"]"));
        }
        public IWebElement OKBTN()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'swal-modal')] //button[contains(@class, 'swal-button')]"));
        }
        public IWebElement CreateANewThirdPartyBiller1()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"third_party_biller_div\"]/button[1]"));
        }
        public IWebElement InvoiceIssuedMessageTPB()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'swal-text')]"));
        }
        public IWebElement OKButtonTPB()
        {
            return webDriver.FindElement(By.XPath("//button[contains(@class, 'swal-button swal-button')]"));
        }

        //updateExistingBillzyInvoice
        public IWebElement UpdateExistingBillzyInvoiceSection()
        {
            return webDriver.FindElement(By.Id("update_invoice_div"));
        }
        public IWebElement SelectBusiness()
        {
            return webDriver.FindElement(By.Id("update-inv-business"));
        }
        public IWebElement InputInvoice()
        {
            return webDriver.FindElement(By.XPath("//input[contains(@id, 'invoice-number')]"));
        }
        public IWebElement SearchBTN()
        {
            return webDriver.FindElement(By.Id("search-invoice-number"));
        }
        public IWebElement InvoiceTableResult()
        {
            return webDriver.FindElement(By.Id("invoice-results"));
        }
        public IWebElement InvoiceNumber()
        {
            return webDriver.FindElement(By.XPath("//*[contains(@id,\"row-\")]/td[1]"));
        }
        public IWebElement InvoiceRef()
        {
            return webDriver.FindElement(By.XPath("//*[contains(@id,\"row-\")]/td[2]"));
        }
        public IWebElement BillerName()
        {
            return webDriver.FindElement(By.XPath("//*[contains(@id,\"row-\")]/td[3]"));
        }
        public IWebElement PayerName()
        {
            return webDriver.FindElement(By.XPath("//*[contains(@id,\"row-\")]/td[4]"));
        }
        public IWebElement IsPayerExt()
        {
            return webDriver.FindElement(By.XPath("//*[contains(@id,\"row-\")]/td[5]"));
        }
        public IWebElement InvoiceValue()
        {
            return webDriver.FindElement(By.XPath("//*[contains(@id,\"row-\")]/td[6]"));
        }
        public IWebElement CashStatus()
        {
            return webDriver.FindElement(By.XPath("//*[contains(@id,\"row-\")]/td[7]"));
        }
        public IWebElement VerifiedTimeStamp()
        {
            return webDriver.FindElement(By.XPath("//*[contains(@id,\"row-\")]/td[8]"));
        }
        public IWebElement VerifyBTNEnabled()
        {
            return webDriver.FindElement(By.XPath("//button[contains(@action, 'BILLZY_CASH_PAYER_VERIFY') and not (@disabled)]"));
        }
        public IWebElement VerifyBTNDisabled()
        {
            return webDriver.FindElement(By.XPath("//button[contains(@action, 'BILLZY_CASH_PAYER_VERIFY') and (@disabled)]"));
        }
        public IWebElement UnverifyBTNEnabled()
        {
            return webDriver.FindElement(By.XPath("//button[contains(@action, 'BILLZY_CASH_PAYER_UNVERIFY') and not (@disabled)]"));
        }
        public IWebElement UnverifyBTNDisabled()
        {
            return webDriver.FindElement(By.XPath("//button[contains(@action, 'BILLZY_CASH_PAYER_UNVERIFY') and (@disabled)]"));
        }
        public IWebElement ViewPDF()
        {
            return webDriver.FindElement(By.Id("view-pdf"));
        }
        public IWebElement InvoiceStatus()
        {
            return webDriver.FindElement(By.XPath("//*[contains(@id,\"row-\")]/td[11]"));
        }
        public IWebElement MarkAsPaidEnabled()
        {
            return webDriver.FindElement(By.XPath("//button[contains(@id, 'mark-as-paid') and not(@disabled)] "));
        }
        public IWebElement DeleteDisabled()
        {
            return webDriver.FindElement(By.XPath("//button[contains(@id, 'delete') and (@disabled)]"));
        }

        public IWebElement DeleteEnabled()
        {
            return webDriver.FindElement(By.XPath("//button[contains(@id, 'delete') and not(@disabled)]"));
        }
        public IWebElement MarkAsPaidDisabled()
        {
            return webDriver.FindElement(By.XPath("//button[contains(@id, 'mark-as-paid') and (@disabled)] "));
        }

        public IWebElement UpdateMsg1()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"update_invoice_div\"]"));
        }

        public IWebElement UpdateMsg2()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"update_invoice_div\"]/text()[3]"));
        }
        
        public IWebElement Invtitles()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"invoice-results\"]"));
        }
        public IWebElement ExternalClientok()
        {
            return webDriver.FindElement(By.XPath("//*[@class=\"swal-button swal-button--createAnother\"]"));
        }

        public IWebElement MAPYes()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"confirm-markAsPaid\"]/div/button[1]"));
        }
        public IWebElement DeleteYes()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"confirm-delete\"]/div/button[1]"));
        }
        public IWebElement MAPCancel()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"confirm-markAsPaid\"]/div//button[2]"));
        }
        public IWebElement DeleteCancel()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"confirm-delete\"]/div//button[2]"));
        }

        public IWebElement DeletecashCancel()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"cannot-delete-cash-history\"]/div/button"));
        }
        //Payway Tab

        public IWebElement PaywayTabSelection()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"payway\"]"));
        }

        public IWebElement MatchButton1()
        {
            return webDriver.FindElement(By.XPath("(//*[@type=\"button\"])[2]"));
        }

        public IWebElement MatchButtonCancel()
        {
            return webDriver.FindElement(By.XPath("/html/body/div[6]/div/div[3]/div/button"));
        }
        public IWebElement MatchButtonOk()
        {
            return webDriver.FindElement(By.XPath("/html/body/div[6]/div/div[3]/div/button"));
        }
    }
}
