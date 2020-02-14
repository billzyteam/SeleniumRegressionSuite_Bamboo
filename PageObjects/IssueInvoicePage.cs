using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BillzyAutomationTestSuite.PageObjects
{
    public class IssueInvoicePage
    {

        private IWebDriver webDriver;
        public IssueInvoicePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        //no-match-found-img-rcvd

        public IWebElement RecievedTabInvoiceDetails()
        {
            return webDriver.FindElement(By.Id("no-match-found-img-rcvd"));
        }
        public IWebElement Feemsg()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issInv-billzy-cash-component\"]/div/div[2]/div[1]/div/div/div[5]/div/b"));
        }
        public IWebElement Cashpercentmsg()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issInv-billzy-cash-component\"]/div/div[2]/div[1]/div/div/div[4]/div/b"));
        }

        public IWebElement CashBannedImg()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issInv-cashBanned-popover\"]/img[1]"));
        }

        public IWebElement DealBannedImg()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issInv-dealBanned-popover\"]/img[1]"));
        }
        public IWebElement DealBannedInfoIcon()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"billzy-deal-disabled-info-icon\"]"));
        }
        public IWebElement CashBannedInfoIcon()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"billzy-cash-disabled-info-icon\"]"));
        }
        

        public IWebElement Outside()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issInv-create-part1\"]/div[3]"));
        }
        public IWebElement BillzyCashAmount()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issInv-billzy-cash-component\"]/div/div[2]/div[1]/div/div/div[1]/div/b[2]/span"));
        }
        public IWebElement IssueInvoiceButton()
        {
            return webDriver.FindElement(By.XPath("//a[contains(@class, 'issue-inv-link')]"));
        }
        public IWebElement AddCustomerButton()
        {
            return webDriver.FindElement(By.Id("issInv-add-new-customer"));
        }
        public IWebElement BusinessName()
        {
            return webDriver.FindElement(By.XPath("//div[@class= 'issue-invoice-inner'] //input[@id = 'issInv-existing-customer']"));
        }
        public IWebElement SelectBusinessName()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issue - invoice - main\"]//div[@class=\"business - suggestion tt - suggestion tt - selectable\"][1]"));
        }
        public IWebElement Abn()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issInv-abn\"]"));
        }
        public IWebElement Email()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issInv-email\"]"));
        }
        public IWebElement Street()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issInv-street\"]"));
        }
        public IWebElement Suburb()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issInv-suburb\"]"));
        }
        public IWebElement Postcode()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issInv-postcode\"]"));
        }
        public IWebElement PaymentTerms()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issInv-payment-terms\"]"));
        }

        public static void SelectDropDown(IWebDriver webDriver, string element, string value, string elementtype)
        {
            if (elementtype == "Id")
                new SelectElement(webDriver.FindElement(By.Id(element))).SelectByText(value);
            if (elementtype == "XPath")
                new SelectElement(webDriver.FindElement(By.XPath(element))).SelectByText(value);
        }
        public IWebElement ClickPage()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issue-invoice-main\"]/div/div[2]"));
        }
        public IWebElement UploadPDFInvoice()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issInv-decision-upload-file-icon\"]"));
        }
        public IWebElement PdfUploadFileBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issInv-decision-upload-file\"]"));
        }
        public IWebElement Amount()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issInv-upload-amount\"]"));
        }
        public IWebElement IssueInvoiceTxt()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issue-invoice-main\"]/div/h2"));
        }
        public IWebElement chooseFile()
        {
            return webDriver.FindElement(By.Id("issInv-upload-file-button"));
        }

        public IWebElement IncludeGSTYes()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issInv-create-decision-inv-gst-yes\"]"));
        }

        public IWebElement IncludeGSTNo()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issInv-create-decision-inv-gst-no\"]"));
        }
        public IWebElement GstValue()
        {
            return webDriver.FindElement(By.Id("issInv-upload-gst-amount"));
        }

        public IWebElement LineItemIncludeGSTYes()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issInv-create-decision-line-gst-yes\"]"));
        }
        public IWebElement LineItemIncludeGSTNo()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issInv-create-decision-line-gst-no\"]"));
        }


        public IWebElement InvoiceReferenceCreate()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issInv-create-ref\"]"));
        }
        public IWebElement InvoiceReferenceUpload()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issInv-upload-ref\"]"));
        }
        public IWebElement CreateInvoice()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issInv-decision-create-pdf\"]"));
        }

        public IWebElement Message()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issInv-email-body\"]"));
        }
        public IWebElement SendInvoiceBTN()
        {
            return webDriver.FindElement(By.Id("issInv-confirm-btn"));
        }
        public IWebElement Description()
        {
            return webDriver.FindElement(By.Id("lineDesc"));
        }

        public IWebElement UploadDescription()
        {
            return webDriver.FindElement(By.Id("lineDesc"));
        }
        public IWebElement UploadAmount()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issInv-upload-amount\"]"));
        }

        public IWebElement UploadInvRef()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issInv-upload-ref\"]"));
        }
        public IWebElement LineItemAmount()
        {
            return webDriver.FindElement(By.Id("lineAmount"));
        }
        
        public IWebElement SurchargeCheckbox()
        {
            return webDriver.FindElement(By.XPath("//label[@for=\"issInv-create-surcharge-checkbox\"]"));
        }

       

        public IWebElement UploadSurchargeCheckbox()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issInv-upload-part1\"]/div[4]/form/div[1]/label"));
        }

        //

        public IWebElement LineItem1()
        {
            return webDriver.FindElement(By.XPath("(//*[@id=\"lineAmount\"])[1]"));
        }
        public IWebElement LineItem2()
        {
            return webDriver.FindElement(By.XPath("(//*[@id=\"lineAmount\"])[2]"));
        }
        public IWebElement LineItem3()
        {
            return webDriver.FindElement(By.XPath("(//*[@id=\"lineAmount\"])[3]"));
        }
        public IWebElement LineItem4()
        {
            return webDriver.FindElement(By.XPath("(//*[@id=\"lineAmount\"])[4]"));
        }
        public IWebElement AddDescription1()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issInv-create-line-items\"]/div[2]/div/div/div[2]/textarea"));
        }
        public IWebElement AddLineItem()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issInv-create-add-line-item\"]"));
        }
        public IWebElement TotalInclGST()
        {
            return webDriver.FindElement(By.XPath("//span[@id = 'issInv-create-total-value']"));
        }
        public IWebElement TotalGSTMsg()
        {
            return webDriver.FindElement(By.Id("issInv-create-total-gst-message"));
        }
        public IWebElement TotalValue()
        {
            return webDriver.FindElement(By.Id("issInv-create-total-value"));
        }
        public IWebElement UploadTotalValue()
        {
            return webDriver.FindElement(By.XPath("(//label[contains(@for,'issInv-upload-amount')])[2]"));
        }
        public IWebElement Subject()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issInv-email-subject\"]"));
        }
       
        public IWebElement Footer()
        {
            return webDriver.FindElement(By.XPath("//footer[@class = 'footer']"));
        }
       
        public IWebElement SelectRow1()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issue-invoice-main\"]/div/div[2]/div[1]/div[1]/span/div/div/div"));
        }
        public IWebElement CancelBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issInv-cancel-btn\"]"));
        }
        public IWebElement PreviewInvoice()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issInv-preview-btn\"]/span[1]"));
        }

        public IWebElement AmountPayable1()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[1]/div[4]/div/div/div[2]/div[7]/div/div/input"));
        }
        public IWebElement SplitBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[1]/div[4]/div/div/div[2]/div[8]/button[1]"));
        }
        public IWebElement SelectCardFeild2()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[1]/div[4]/div/div[2]/div[2]/div[6]/div/div"));
        }
        public IWebElement SelectValidCard2()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[1]/div[4]/div/div[2]/div[2]/div[6]/div/ul/li/a/span[2]/table/tbody/tr/td[2]"));
        }
        public IWebElement SelectInvalidCard()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[1]/div[4]/div/div[2]/div[2]/div[6]/div/ul/li[4]/a/span[2]"));
        }
        public IWebElement Discount()
        {
            return webDriver.FindElement(By.Id("issInv-discount-percent"));
        }
        public IWebElement DiscountPaymentTerms()
        {
            return webDriver.FindElement(By.Id("issInv-discount-terms"));
        }
        public IWebElement DueDate()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issInv-due-date\"]"));
        }
        public IWebElement SumTotalAfterDiscount()
        {
            return webDriver.FindElement(By.Id("total-after-discount"));
        }
        public IWebElement PageLevelErrorMessage()
        {
            return webDriver.FindElement(By.Id("issInv-page-level-error"));
        }
        public IWebElement AddDiscountBTN()
        {
            return webDriver.FindElement(By.Id("issInv-add-discount-btn"));
        }


        // Billzy Deal
        public IWebElement BillzyDealBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id= 'addDiscountForm'] //img[contains(@src, 'billzy-logo-deal-greyed.png')]"));
        }
        public IWebElement BillzyDealSelectedBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id= 'addDiscountForm'] //img[contains(@src, 'billzy-logo-deal-ticked.png')]"));
        }
        public IWebElement RemovedBillzyDealBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id ='issInv-deal-component'] //p[@class= 'remove-billzy-deal']"));
        }
        public IWebElement BillzyDealIcon()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issInv-deal-component\"]/div/div[1]/div[1]"));
        }

        public IWebElement BillzyDealHovered()
        {
            return webDriver.FindElement(By.XPath("//img[contains(@src,'billzy-logo-deal') and @class= 'billzy-deal-hovered']"));
        }


        public IWebElement SurchargeCheckboxUpload()
        {
            return webDriver.FindElement(By.XPath("//label[@for=\"issInv-upload-surcharge-checkbox\"]"));
        }
        public IWebElement SurchargeInfo()
        {
            return webDriver.FindElement(By.Id("create-surchargeInfo"));
        }
        ////*[@id="issInv-deal-component"]/div/div[2]/div[2]/div[1]/label
        public IWebElement OfferExpiresCheck()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issInv-deal-component\"]/div/div[2]/div[2]/div[1]/label"));
        }
        // Deal Section on Issue Invoice - Create/Upload Invoice

        public IWebElement DealCheckbox()
        {
            return webDriver.FindElement(By.XPath("//label[@for=\"issInv-add-discount-btn\"]"));
        }
        public IWebElement NewTotal()
        {
            return webDriver.FindElement(By.XPath("//div[@style='display: block;'] //input[@id='discount-amount-payable']"));
        }

       
        public IWebElement OfferExpiry()
        {
            return webDriver.FindElement(By.XPath("//div[@style='display: block;'] //input[@id='discount-due-date']"));
        }
        public IWebElement Comments()
        {
            return webDriver.FindElement(By.XPath("//div[@style='display: block;'] //textarea[@id='discount-comments']"));
        }
        public IWebElement DealInformation()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"addDiscountForm\"]/i"));
        }

        public IWebElement SelectBusiness()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issue-invoice-main\"]/div/div/div[2]/div[1]/div[1]/span/div"));
        }
        ////*[@id="issInv-page-level-error"]
        public IWebElement ErrorMsg()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issInv-page-level-error\"]"));
        }
        ////*[@id="issInv-page-level-error"]

        public IWebElement BillzyCashBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id= 'addBillzyCashForm'] //img[contains(@src, 'billzy-logo-cash-greyed.png')] "));
        }
        public IWebElement BillzyCashSelectedBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id= 'addBillzyCashForm'] //img[contains(@src, 'billzy-logo-cash-ticked.png')] "));
        }
        public IWebElement RemovedBillzyCashBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id ='issInv-billzy-cash-component'] //p[@class= 'remove-billzy-cash']"));
        }
        public IWebElement BillzyCashIcon()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issInv-billzy-cash-component\"]/div/div[1]/div[1]"));
        }
        public IWebElement GetPaidNowLabel()
        {
            return webDriver.FindElement(By.XPath("//*[@id ='issInv-billzy-cash-component'] //b[text()='Get Paid Now']"));
        }
        public IWebElement GetPaidNowAmount()
        {
            return webDriver.FindElement(By.XPath("//*[@id ='issInv-billzy-cash-component'] //span[contains(@class,'billzy-cash-upfront')]"));
        }
        public IWebElement GetPaidLaterLabel()
        {
            return webDriver.FindElement(By.XPath("//*[@id ='issInv-billzy-cash-component'] //b[text()='Get Paid Later']"));
        }
        public IWebElement GetPaidLaterAmount()
        {
            return webDriver.FindElement(By.XPath("//*[@id ='issInv-billzy-cash-component'] //span[contains(@class,'billzy-cash-later')]"));
        }
        public IWebElement TermAndConditionLabel()
        {
            return webDriver.FindElement(By.XPath("//*[@id ='issInv-billzy-cash-component'] //b[text()='Terms and Conditions']"));
        }
        public IWebElement TCLink()
        {
            return webDriver.FindElement(By.XPath("//*[@id ='issInv-billzy-cash-component'] //a[contains(@href, 'legal')]"));
        }
        public IWebElement AcceptTCBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id ='issInv-billzy-cash-component'] //label[@for='IssInv-billzy-cash-terms-checkbox']"));
        }
        public IWebElement BillzyCashTerms()
        {
            return webDriver.FindElement(By.XPath("//*[@id ='issInv-billzy-cash-component'] //div[@class='billzy-cash-terms-text row']"));
        }
        public IWebElement BillzyCashHovered()
        {
            return webDriver.FindElement(By.XPath("//img[contains(@src,'billzy-logo-cash') and @class= 'billzy-cash-hovered']"));
        }
        public IWebElement uploadPDF()
        {
            return webDriver.FindElement(By.Id("issInv-upload-file-form-input"));
        }


        public IWebElement UploadYourFileButton()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issInv-upload-file-button\"]"));

        }
        public IWebElement Uploadfilepath()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issInv-upload-file-name-section\"]"));

        }
        public IWebElement Uploadsurcharge()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"issInv-upload-part1\"]/div[4]/form/div[1]"));

        }
        

    }
}


