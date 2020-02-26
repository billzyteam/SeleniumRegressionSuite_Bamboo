using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace BillzyAutomationTestSuite.PageObjects
{
    class SendPage
    {

        private IWebDriver webDriver;
        public SendPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
        ////*[@id="wrapper"]/div[4]/div[1]/div[2]/div[11]/div/div[14]/div/span
        public IWebElement SearchedInvoiceCashStatus()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[1]/div[2]/div[11]/div[1]/div[14]/div/span"));
        }
        ////*[@id="wrapper"]/div[4]/div[1]/div[2]/div[11]/div[1]/div[14]/div/img
        public IWebElement BillzyColumnCashIcon()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[1]/div[2]/div[11]/div[1]/div[14]/div/img"));
        }
        public IWebElement SentOutstandingBTN()
        {
            return webDriver.FindElement(By.XPath("//ul[@id='sent-page-pills']//li[@id='unpaid-toogle']"));
        }

        public IWebElement ClickRow1()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[1]/div[2]/div[9]"));
        }
        public IWebElement ActionDropdown()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"dd-action-inv\"]"));
        }
        public IWebElement Delete()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"delete-action\"]/a"));
        }
        public IWebElement MarkAsPaid()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"mark-as-paid-action\"]/a"));
        }
        public IWebElement MarkAsPaidConfirm()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"mark-as-paid-modal\"]/div/div/div/div/div[4]/div[1]/button"));
        }
        public IWebElement ConfirmDelete()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"delete-invoice-modal\"]/div/div/div/div/div[4]/div[1]/button"));
        }
        public IWebElement EmptyBoxIcon()
        {
            return webDriver.FindElement(By.Id("no-match-found-img-sent"));
        }
        public IWebElement SentBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"collapsable-menu-items\"]/ul[1]/li[3]/a"));
        }
        public IWebElement SentPaidBTN()
        {
            return webDriver.FindElement(By.XPath("//ul[@id='sent-page-pills']//li[@id= 'paid-toogle']"));
        }
        public IWebElement SentHistoryBTN()
        {
            return webDriver.FindElement(By.XPath("//ul[@id='sent-page-pills'] //a[text()='History']"));
        }
        public IWebElement BillzyReference()
        {
            return webDriver.FindElement(By.XPath("//*[@id='sent-invoicenum']"));
        }
        public IWebElement NoInvoiceResult()
        {
            return webDriver.FindElement(By.XPath("(//h4[@id='no-match-found-msg'])[1]"));
        }
        public IWebElement ClearBTN()
        {
            return webDriver.FindElement(By.Id("sent-clear-filter-lg"));
        }
        public IWebElement SearchInvoiceSent()
        {
            return webDriver.FindElement(By.Id("sent-search-invoiced"));
        }
        public IWebElement Row1()
        {
            return webDriver.FindElement(By.XPath("(//div[@class='row table-row combined-row'])[1]"));
        }
        public IWebElement SearchedFirstRowDetailsLink()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class,'row table-row combined-row')]/div[contains(@class, 'view-details-lnk')]"));
        }
        public IWebElement RejectBTN()
        {
            return webDriver.FindElement(By.XPath("(//button[@id='reject-deal-btn'])[2]"));
        }
        public IWebElement AcceptBTN()
        {
            return webDriver.FindElement(By.XPath("(//button[@id='accept-deal-btn'])[2]"));
        }
        //# Sent Page Outstanding Tab - billzy Reference
        public IWebElement BillzyReferenceRow01()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'sent-data'] //div[contains(@class, 'invoice-number')]) [01]"));
        }
        public IWebElement BillzyReferenceRow02()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'sent-data'] //div[contains(@class, 'invoice-number')]) [02]"));
        }
        public IWebElement BillzyReferenceRow03()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'sent-data'] //div[contains(@class, 'invoice-number')]) [03]"));
        }
        public IWebElement BillzyReferenceRow04()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'sent-data'] //div[contains(@class, 'invoice-number')]) [04]"));
        }
        public IWebElement BillzyReferenceRow05()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'sent-data'] //div[contains(@class, 'invoice-number')]) [05]"));
        }
        public IWebElement BillzyReferenceRow06()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'sent-data'] //div[contains(@class, 'invoice-number')]) [06]"));
        }
        public IWebElement BillzyReferenceRow07()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'sent-data'] //div[contains(@class, 'invoice-number')]) [07]"));
        }
        public IWebElement BillzyReferenceRow08()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'sent-data'] //div[contains(@class, 'invoice-number')]) [08]"));
        }
        public IWebElement BillzyReferenceRow09()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'sent-data'] //div[contains(@class, 'invoice-number')]) [09]"));
        }
        public IWebElement BillzyReferenceRow10()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'sent-data'] //div[contains(@class, 'invoice-number')]) [10]"));
        }

        //# Sent Page Outstanding Tab - Invoice Reference


        public IWebElement InvoiceReferenceRow01()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'sent-data'] //div[contains(@class, 'reference')]) [01]"));
        }
        public IWebElement InvoiceReferenceRow02()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'sent-data'] //div[contains(@class, 'reference')]) [02]"));
        }
        public IWebElement InvoiceReferenceRow03()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'sent-data'] //div[contains(@class, 'reference')]) [03]"));
        }
        public IWebElement InvoiceReferenceRow04()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'sent-data'] //div[contains(@class, 'reference')]) [04]"));
        }
        public IWebElement InvoiceReferenceRow05()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'sent-data'] //div[contains(@class, 'reference')]) [05]"));
        }
        public IWebElement InvoiceReferenceRow06()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'sent-data'] //div[contains(@class, 'reference')]) [06]"));
        }
        public IWebElement InvoiceReferenceRow07()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'sent-data'] //div[contains(@class, 'reference')]) [07]"));
        }
        public IWebElement InvoiceReferenceRow08()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'sent-data'] //div[contains(@class, 'reference')]) [08]"));
        }
        public IWebElement InvoiceReferenceRow09()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'sent-data'] //div[contains(@class, 'reference')]) [09]"));
        }
        public IWebElement InvoiceReferenceRow10()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'sent-data'] //div[contains(@class, 'reference')]) [10]"));
        }


        //# Sent Page Outstanding Tab - Invoice Reference

        public IWebElement BillzyDealRow01()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'sent-data'] //div[contains(@class, 'billzy-deal-value')]) [01]"));
        }
        public IWebElement BillzyDealRow02()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'sent-data'] //div[contains(@class, 'billzy-deal-value')]) [02]"));
        }
        public IWebElement BillzyDealRow03()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'sent-data'] //div[contains(@class, 'billzy-deal-value')]) [03]"));
        }
        public IWebElement BillzyDealRow04()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'sent-data'] //div[contains(@class, 'billzy-deal-value')]) [04]"));
        }
        public IWebElement BillzyDealRow05()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'sent-data'] //div[contains(@class, 'billzy-deal-value')]) [05]"));
        }
        public IWebElement BillzyDealRow06()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'sent-data'] //div[contains(@class, 'billzy-deal-value')]) [06]"));
        }
        public IWebElement BillzyDealRow07()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'sent-data'] //div[contains(@class, 'billzy-deal-value')]) [07]"));
        }
        public IWebElement BillzyDealRow08()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'sent-data'] //div[contains(@class, 'billzy-deal-value')]) [08]"));
        }
        public IWebElement BillzyDealRow09()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'sent-data'] //div[contains(@class, 'billzy-deal-value')]) [09]"));
        }
        public IWebElement BillzyDealRow10()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'sent-data'] //div[contains(@class, 'billzy-deal-value')]) [10]"));
        }

        public IWebElement DueInRow1()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[1]/div[2]/div[9]/div[1]/div[11]"));
        }
        public IWebElement InvoiceAmount()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[1]/div[2]/div[9]/div[1]/div[15]"));
        }
        public IWebElement AcceptButton()
        {
            return webDriver.FindElement(By.XPath("(//button[@id= 'accept-deal-btn'] )[2]"));
        }
        public IWebElement BillzyRefResult()
        {
            return webDriver.FindElement(By.XPath("//*[@class=\"sent-data\"]//div[contains(@class,'row table-row combined-row')] //div[contains(@class,'invoice-number')][1]"));
        }

        public IWebElement NotViewed()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[1]/div[2]/div[11]/div[1]/div[2]/i"));
        }

        //*[@id="wrapper"]/div[4]/div[1]/div[2]/div[11]/div[1]/div[2]/i
        public IWebElement TitlePage()
        {
            return webDriver.FindElement(By.XPath("//h2[text() = 'Sent Invoices']"));
        }
        public IWebElement Filter()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'filter-box')] //input[@placeholder = 'Keyword'])[1]"));
        }
        public IWebElement FromDate()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"sent-date-from-filter\"]"));
        }
        public IWebElement ToDate()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"sent-date-to-filter\"]"));
        }

        public IWebElement StatusColumn()
        {
            return webDriver.FindElement(By.XPath("//span[@id= 'sent-status-span' and text()= 'Status']"));
        }

        public IWebElement ToColumn()
        {
            return webDriver.FindElement(By.XPath("//span[@id= 'sent-recipientBusiness-span' and text()= 'To']"));
        }

        public IWebElement InvoiceNumColumn()
        {
            return webDriver.FindElement(By.XPath("//span[@id= 'sent-invoicenum-span' and text()= 'Invoice Number']"));
        }

        public IWebElement DueColumn()
        {
            return webDriver.FindElement(By.XPath("//span[@id= 'sent-dueDate-span' and text()= 'Due']"));
        }

        public IWebElement PaidOnColumn()
        {
            return webDriver.FindElement(By.XPath("//span[@id= 'sent-paidDate-span' and text()= 'Paid On']"));
        }

        public IWebElement AmountColumn()
        {
            return webDriver.FindElement(By.XPath("//span[@id= 'sent-amount-span' and text()= 'Amount']"));
        }

        public IWebElement BillzyColumn()
        {
            return webDriver.FindElement(By.XPath("//div[@id = 'sent-billzyDeal'] //img[contains(@src,'billzy-column.png')]"));
        }

        public IWebElement ActionsColumn()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'unpaid-col')]//span[text() = 'Actions'])[1]"));
        }

        public IWebElement CompletedColumn()
        {
            return webDriver.FindElement(By.XPath("//span[@id= 'sent-paidDate-span' and text()= 'Completed']"));
        }

        public IWebElement SelectAllUnchecked()
        {
            return webDriver.FindElement(By.XPath("//div[@class = 'sent-details'] //div[contains(@class, 'select-all-bill no-bill-pay')]"));
        }

        public IWebElement SelectAllChecked()
        {
            return webDriver.FindElement(By.XPath("//div[@class = 'sent-details'] //div[contains(@class, 'select-all-bill bill-pay')]"));
        }
        public IWebElement FirstRowUnchecked()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'sent-data')] //div[contains(@class, 'select-bill no-bill-pay')])[1]"));
        }
        public IWebElement SecondRowUnchecked()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'sent-data')] //div[contains(@class, 'select-bill no-bill-pay')])[2]"));
        }
        public IWebElement ThirdRowUnchecked()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'sent-data')] //div[contains(@class, 'select-bill no-bill-pay')])[3]"));
        }
        public IWebElement FourthRowUnchecked()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'sent-data')] //div[contains(@class, 'select-bill no-bill-pay')])[4]"));
        }
        public IWebElement FirstRowChecked()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'sent-data')] //div[contains(@class, 'bill-pay-indicator select-bill no-bill-pay')])[1]"));
        }
        public IWebElement SecondRowChecked()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'sent-data')] //div[contains(@class, 'bill-pay-indicator select-bill no-bill-pay')])[2]"));
        }
        public IWebElement ThirdRowChecked()
        {
            //return webDriver.FindElement(By.XPath("(//div[contains(@class, 'sent-data')] //div[contains(@class, 'select-bill bill-pay')])[3]"));
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'sent-data')] //div[contains(@class, 'bill-pay-indicator select-bill no-bill-pay')])[3]"));
        }
        public IWebElement FourthRowChecked()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'sent-data')] //div[contains(@class, 'bill-pay-indicator select-bill no-bill-pay')])[4]"));

        }

        public IWebElement PdfButtonTop()
        {
            return webDriver.FindElement(By.Id("sent-download-btn"));
        }
        public IWebElement Invoiceloaded()
        {
            return webDriver.FindElement(By.XPath("//*[@class=\"invoices-loaded center-text\"]"));
        }

        public IWebElement PdfButtonButton()
        {
            return webDriver.FindElement(By.XPath("//div[@class = 'sent-details'] //div[contains(@class, 'pdf-download-area-bottom')] //button[@class = 'btn download-btn ladda-button']"));
        }
        public IWebElement PDFSelection5()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[1]/div[2]/div[11]/div[5]/div[1]/div"));
        }
        public IWebElement PDFSelection63()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[1]/div[2]/div[11]/div[67]/div[1]/div"));
        }
        public IWebElement PDFSelection129()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[1]/div[2]/div[11]/div[129]/div[1]/div"));
        }

        public IWebElement PDFSentHistSelection5()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[1]/div[2]/div[11]/div[5]/div[1]/div"));
        }

        public IWebElement StatusNotViewedRow01()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'sent-data'] //div[contains(@class,'row table-row combined-row')] //i[@data-title= 'not viewed'])[01]"));
        }

        public IWebElement StatusViewedRow01()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'sent-data'] //div[contains(@class,'row table-row combined-row')] //i[@data-title= 'viewed'] )[01]"));
        }
        
        public IWebElement StatusViewed()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[1]/div[2]/div[11]/div/div[2]/i"));
        }
        public IWebElement StatusOverdueRow01()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'sent-data'] //div[contains(@class,'row table-row combined-row')] //i[@data-title= 'overdue'])[01]"));
        }

        public IWebElement StatusProcessingRow01()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'sent-data'] //div[contains(@class,'row table-row combined-row')]  //i[@data-title= 'processing'])[01]"));
        }
        ////*[@id="wrapper"]/div[4]/div[1]/div[2]/div[11]/div/div[2]/i
        public IWebElement StatusProcessingRow()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[1]/div[2]/div[11]/div/div[2]/i"));
        }
        public IWebElement StatusPaidRow01()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'sent-data'] //div[contains(@class,'row table-row combined-row')] //i[@data-title= 'paid'] )[01]"));
        }

        public IWebElement StatusDeletedRow01()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'sent-data'] //div[contains(@class,'row table-row combined-row')] //i[@data-title= 'deleted'] )[01]"));
        }

        public IWebElement ToRow01()
        {
            return webDriver.FindElement(By.XPath("//div[@class= 'sent-data'] //div[contains(@class,'row table-row combined-row')] //div[@class= 'col-lg-2 visible-lg']"));
        }

        public IWebElement BillzyInvoiceNumRow01()
        {
            return webDriver.FindElement(By.XPath("//div[@class= 'sent-data'] //div[contains(@class,'row table-row combined-row')] //div[contains(@class, 'invoice-number')]"));
        }

        public IWebElement DueRow01()
        {
            return webDriver.FindElement(By.XPath("//div[@class= 'sent-data'] //div[contains(@class,'row table-row combined-row')] //div[contains(@class, 'due-date-value unpaid')]"));
        }

        public IWebElement PaidOnRow1()
        {
            return webDriver.FindElement(By.XPath("//div[@class= 'sent-data'] //div[contains(@class,'row table-row combined-row')] //div[contains(@class, 'paid-date-value paid-col')]"));
        }

        public IWebElement CompletedRow1()
        {
            return webDriver.FindElement(By.XPath("//div[@class= 'sent-data'] //div[contains(@class,'row table-row combined-row')] //div[contains(@class, 'paid-date-value')]"));
        }


        public IWebElement AmountRow1()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'sent-data'] //div[contains(@class,'row table-row combined-row')] //div[contains(@class, 'paid-foreground')])[2]"));
        }

        public IWebElement AmountViewedRow1()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'sent-data'] //div[contains(@class,'row table-row combined-row')] //div[contains(@class, 'unpaid-foreground')])[2]"));
        }

        public IWebElement AmountOverdueRow1()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'sent-data'] //div[contains(@class,'row table-row combined-row')] //p[contains(@class, 'overdue-foreground')])[1]"));
        }

        public IWebElement AmountOverdueRow1Sent()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'sent-data'] //div[contains(@class,'row table-row combined-row')] //div[contains(@class, 'overdue-foreground')])[2]"));
        }

        public IWebElement BillzyRow1()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'sent-data'] //div[contains(@class,'row table-row combined-row')] //div[contains(@class,'billzy-deal gutter')]) [1]"));
        }

        public IWebElement BillzyDealIconRow1()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'sent-data'] //div[contains(@class,'row table-row combined-row')] //div[contains(@class, 'lg billzy-deal')] //span[contains(@class, 'billzy-deal-icon')])[1]"));
        }

        public IWebElement ActionsMenu()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'sent-data'] //div[contains(@class,'row table-row combined-row')] //div[@class = 'action-menu-area'] //span[contains(@class,'actionMenu  dropdown-toggle')])[1]"));
        }

        public IWebElement PDFInvoice()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')] //ul[contains(@class, 'dropdown-menu dropdown-menu-right')] //li[contains(@data-id, 'view-pdf-action')])"));
        }

        
         public IWebElement PDFInvoice2()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[1]/div[2]/div[11]/div/div[16]/div/div/div/ul/li[6]"));
        }
   

    public IWebElement DeleteOption()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')] //ul[contains(@class, 'dropdown-menu dropdown-menu-right')] //li[contains(@data-id, 'delete-action')])"));
        }

        public IWebElement BillzyCashOption()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')] //ul[contains(@class, 'dropdown-menu dropdown-menu-right')] //li[contains(@data-id, 'billzy-cash-action')])"));
        }

        public IWebElement BillzyDealOption()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')] //ul[contains(@class, 'dropdown-menu dropdown-menu-right')] //li[contains(@data-id, 'billzy-deal-action')])"));
        }

        public IWebElement MarkAsPaidOption()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')] //ul[contains(@class, 'dropdown-menu dropdown-menu-right')] //li[text()='Mark As Paid'])"));
        }

        public IWebElement SentOnloadInvoiceCount_Sum()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"sent-page-pills\"]/li[3]"));
        }

        public IWebElement BillzyCashFilterCheckBox()
        {
            return webDriver.FindElement(By.XPath("//*[@src='/assets/billzy-cash-filter-off.svg' and @id='sent-cash-filter-off-lg']"));
        }

        public IWebElement BillzyCashFilterUncheckBox()
        {
            return webDriver.FindElement(By.XPath("//*[@src='/assets/billzy-cash-filter-on.svg' and @id='sent-cash-filter-on-lg']"));
        }

        public IWebElement BillzyDealFilterCheckBox()
        {
            return webDriver.FindElement(By.XPath("//*[@src='/assets/billzy-deal-filter-off.svg' and @id='sent-deal-filter-off-lg']"));
        }

        public IWebElement BillzyDealFilterUncheckBox()
        {
            return webDriver.FindElement(By.XPath("//*[@src='/assets/billzy-deal-filter-on.svg' and @id='sent-deal-filter-on-lg']"));
        }

        public IWebElement SelectExportFormat()
        {
            return webDriver.FindElement(By.Id("csv-export-sent"));
        }

        public IWebElement BillzyExport()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"sent-export-format-div\"]/span/div/div/div[1]"));
        }

        public IWebElement MYOB()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"sent-export-format-div\"]/span/div/div/div[2]"));
        }

        public IWebElement XERO()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"sent-export-format-div\"]/span/div/div/div[3]"));
        }

        public IWebElement CashRequestedIcon()
        {
            return webDriver.FindElement(By.XPath("//img[contains(@src,'/assets/billzy-cash-grey.svg')]"));
        }
        //*[@id="wrapper"]/div[4]/div[1]/div[2]/div[11]/div/div[14]/div/img
        public IWebElement CashPaidIcon()
        {
            return webDriver.FindElement(By.XPath("//img[contains(@src,'/assets/billzy-cash-green.svg')]"));
        }

        public IWebElement CashPaidIconBeforefunded()
        {
            return webDriver.FindElement(By.XPath("//img[contains(@src,'/assets/billzy-cash-red.svg')]"));
        }
        public IWebElement CashApprovedIcon()
        {
            return webDriver.FindElement(By.XPath("//img[contains(@src,'/assets/billzy-cash-green.svg')]"));
        }

        public IWebElement CashDeclinedIcon()
        {
            return webDriver.FindElement(By.XPath("//img[contains(@src,'/assets/billzy-cash-red.svg')]"));
        }

        public IWebElement LoadMoreBTN()
        {
            return webDriver.FindElement(By.XPath("//button[text()='LOAD MORE']"));
        }

        public IWebElement TotalAmountCount()
        {
            return webDriver.FindElement(By.XPath("//li[contains(@class, 'invoice-summary-area-sent')] "));
        }

        public IWebElement ScrollToTop()
        {
            return webDriver.FindElement(By.XPath("//div[@class='sent']  //div[@class='scrollToTop']"));
        }
        //# Sent Page Outstanding Tab - To Column
        public IWebElement SentToColumnRow01()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][01] //div[contains(@class, 'visible-lg')])[01]"));

        }

        public IWebElement SentToColumnRow02()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][02] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow03()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][03] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow04()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][04] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow05()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][05] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow06()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][06] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow07()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][07] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow08()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][08] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow09()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][09] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow10()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][10] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow11()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][11] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow12()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][12] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow13()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][13] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow14()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][14] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow15()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][15] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow16()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][16] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow17()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][17] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow18()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][18] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow19()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][19] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow20()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][20] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow21()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][21] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow22()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][22] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow23()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][23] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow24()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][24] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow25()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][25] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow26()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][26] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow27()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][27] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow28()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][28] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow29()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][29] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow30()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][30] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow31()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][31] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow32()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][32] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow33()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][33] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow34()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][34] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow35()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][35] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow36()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][36] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow37()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][37] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow38()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][38] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow39()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][39] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow40()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][40] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow41()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][41] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow42()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][42] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow43()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][43] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow44()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][44] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow45()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][45] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow46()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][46] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow47()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][47] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow48()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][48] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow49()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][49] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow50()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][50] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow51()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][51] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow52()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][52] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow53()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][53] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow54()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][54] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow55()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][55] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow56()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][56] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow57()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][57] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow58()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][58] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow59()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][59] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement SentToColumnRow60()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][60] //div[contains(@class, 'visible-lg')])[01]"));
        }

        //# Sent Page Outstanding Tab - Invoice Number Column
        public IWebElement SentInvoiceNumberColumnRow01()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][01] //div[contains(@class, 'view-details-lnk')])[01]"));

        }

        public IWebElement SentInvoiceNumberColumnRow02()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][02] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow03()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][03] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow04()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][04] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow05()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][05] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow06()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][06] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow07()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][07] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow08()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][08] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow09()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][09] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow10()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][10] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow11()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][11] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow12()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][12] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow13()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][13] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow14()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][14] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow15()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][15] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow16()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][16] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow17()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][17] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow18()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][18] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow19()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][19] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow20()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][20] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow21()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][21] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow22()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][22] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow23()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][23] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow24()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][24] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow25()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][25] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow26()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][26] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow27()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][27] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow28()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][28] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow29()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][29] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow30()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][30] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow31()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][31] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow32()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][32] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow33()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][33] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow34()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][34] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow35()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][35] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow36()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][36] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow37()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][37] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow38()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][38] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow39()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][39] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow40()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][40] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow41()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][41] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow42()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][42] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow43()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][43] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow44()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][44] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow45()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][45] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow46()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][46] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow47()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][47] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow48()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][48] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow49()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][49] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow50()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][50] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow51()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][51] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow52()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][52] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow53()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][53] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow54()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][54] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow55()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][55] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow56()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][56] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow57()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][57] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow58()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][58] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow59()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][59] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement SentInvoiceNumberColumnRow60()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][60] //div[contains(@class, 'view-details-lnk')])[01]"));
        }
        //# Sent Page Outstanding Tab - Due Column
        public IWebElement OutstandingDueColumnRow01()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][01] //div[contains(@class, 'due-date-value')])[01]"));

        }

        public IWebElement OutstandingDueColumnRow02()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][02] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow03()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][03] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow04()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][04] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow05()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][05] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow06()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][06] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow07()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][07] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow08()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][08] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow09()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][09] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow10()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][10] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow11()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][11] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow12()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][12] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow13()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][13] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow14()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][14] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow15()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][15] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow16()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][16] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow17()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][17] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow18()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][18] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow19()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][19] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow20()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][20] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow21()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][21] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow22()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][22] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow23()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][23] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow24()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][24] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow25()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][25] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow26()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][26] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow27()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][27] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow28()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][28] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow29()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][29] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow30()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][30] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow31()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][31] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow32()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][32] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow33()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][33] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow34()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][34] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow35()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][35] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow36()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][36] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow37()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][37] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow38()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][38] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow39()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][39] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow40()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][40] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow41()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][41] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow42()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][42] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow43()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][43] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow44()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][44] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow45()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][45] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow46()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][46] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow47()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][47] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow48()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][48] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow49()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][49] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow50()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][50] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow51()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][51] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow52()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][52] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow53()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][53] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow54()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][54] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow55()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][55] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow56()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][56] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow57()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][57] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow58()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][58] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow59()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][59] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement OutstandingDueColumnRow60()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][60] //div[contains(@class, 'due-date-value')])[01]"));
        }
        //# Sent Page Outstanding Tab - Due Column
        public IWebElement HistoryCompletedColumnRow01()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][01] //div[contains(@class, 'due-paid-date-value')])[01]"));

        }

        public IWebElement HistoryCompletedColumnRow02()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][02] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow03()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][03] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow04()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][04] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow05()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][05] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow06()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][06] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow07()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][07] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow08()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][08] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow09()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][09] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow10()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][10] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow11()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][11] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow12()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][12] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow13()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][13] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow14()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][14] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow15()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][15] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow16()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][16] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow17()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][17] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow18()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][18] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow19()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][19] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow20()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][20] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow21()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][21] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow22()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][22] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow23()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][23] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow24()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][24] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow25()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][25] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow26()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][26] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow27()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][27] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow28()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][28] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow29()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][29] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow30()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][30] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow31()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][31] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow32()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][32] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow33()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][33] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow34()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][34] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow35()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][35] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow36()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][36] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow37()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][37] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow38()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][38] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow39()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][39] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow40()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][40] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow41()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][41] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow42()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][42] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow43()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][43] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow44()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][44] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow45()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][45] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow46()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][46] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow47()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][47] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow48()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][48] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow49()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][49] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow50()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][50] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow51()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][51] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow52()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][52] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow53()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][53] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow54()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][54] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow55()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][55] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow56()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][56] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow57()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][57] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow58()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][58] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow59()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][59] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow60()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][60] //div[contains(@class, 'due-paid-date-value')])[01]"));
        }
        //# Sent Page Outstanding Tab - Amount Column
        public IWebElement SentAmountColumnRow01()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][01] //div[contains(@class, 'left-align')])[01]"));

        }

        public IWebElement SentAmountColumnRow02()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][02] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow03()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][03] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow04()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][04] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow05()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][05] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow06()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][06] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow07()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][07] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow08()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][08] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow09()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][09] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow10()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][10] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow11()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][11] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow12()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][12] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow13()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][13] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow14()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][14] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow15()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][15] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow16()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][16] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow17()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][17] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow18()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][18] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow19()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][19] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow20()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][20] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow21()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][21] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow22()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][22] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow23()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][23] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow24()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][24] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow25()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][25] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow26()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][26] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow27()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][27] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow28()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][28] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow29()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][29] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow30()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][30] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow31()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][31] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow32()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][32] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow33()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][33] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow34()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][34] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow35()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][35] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow36()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][36] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow37()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][37] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow38()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][38] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow39()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][39] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow40()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][40] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow41()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][41] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow42()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][42] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow43()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][43] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow44()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][44] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow45()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][45] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow46()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][46] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow47()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][47] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow48()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][48] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow49()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][49] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow50()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][50] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow51()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][51] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow52()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][52] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow53()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][53] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow54()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][54] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow55()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][55] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow56()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][56] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow57()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][57] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow58()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][58] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow59()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][59] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement SentAmountColumnRow60()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][60] //div[contains(@class, 'left-align')])[01]"));
        }
        //# Sent Page Outstanding Tab - billzy Column
        public IWebElement SentBillzyColumnRow01()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][01] //div[contains(@class, 'billzy-deal')])[01]"));

        }

        public IWebElement SentBillzyColumnRow02()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][02] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow03()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][03] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow04()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][04] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow05()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][05] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow06()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][06] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow07()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][07] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow08()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][08] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow09()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][09] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow10()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][10] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow11()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][11] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow12()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][12] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow13()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][13] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow14()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][14] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow15()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][15] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow16()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][16] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow17()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][17] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow18()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][18] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow19()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][19] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow20()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][20] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow21()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][21] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow22()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][22] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow23()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][23] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow24()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][24] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow25()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][25] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow26()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][26] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow27()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][27] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow28()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][28] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow29()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][29] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow30()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][30] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow31()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][31] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow32()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][32] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow33()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][33] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow34()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][34] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow35()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][35] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow36()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][36] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow37()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][37] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow38()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][38] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow39()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][39] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow40()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][40] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow41()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][41] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow42()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][42] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow43()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][43] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow44()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][44] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow45()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][45] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow46()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][46] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow47()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][47] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow48()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][48] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow49()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][49] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow50()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][50] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow51()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][51] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow52()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][52] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow53()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][53] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow54()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][54] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow55()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][55] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow56()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][56] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow57()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][57] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow58()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][58] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow59()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][59] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement SentBillzyColumnRow60()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][60] //div[contains(@class, 'billzy-deal')])[01]"));
        }
        ////*[@id="deal-history-list"]/div/div[1]/div[2]/p
        public IWebElement SentDealhistorystatus()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"deal-history-list\"]/div/div[1]/div[2]/p"));
        }
       
        public IWebElement Noinvoiceavailablemsg()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"no-match-found-msg\"]"));
        }

        public IWebElement Foo( string bar)
        {

            return webDriver.FindElement(By.XPath($"//*[@id=\"no-match-found-msg\"]/*[text()='{bar}']"));
            //
            //
        }
        public IWebElement OfferRecievedIcon()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'text-left col-lg-2 col-sm-2  col-md-2 visible-sm visible-lg visible-md   billzy-deal gutter text-center')][01] //div[contains(@class, 'deal-popover')])[01]//img[contains(@src,'/assets/billzy-offer/offer_blue.png')]"));
        }
        public IWebElement OfferAcceptedIcon()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'text-left col-lg-2 col-sm-2  col-md-2 visible-sm visible-lg visible-md   billzy-deal gutter text-center')][01] //div[contains(@class, 'deal-popover')])[01]//img[contains(@src,'/assets/billzy-offer/offer_green_blue.png')]"));
        }
        public IWebElement HistoryPaidStatus()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'col-sm-half col-sm-1 col-xs-1 text-center')][01] //i[contains(@class, 'paid-circle paid-background')])[01]"));
        }
        public IWebElement HistOfferstatus()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class,'text-left col-lg-2 col-sm-2  col-md-2 visible-sm visible-lg visible-md   billzy-deal gutter text-center')]//div//span[contains(@style,'margin')]"));

        }
        public IWebElement OfferStatus()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'text-left col-lg-2 col-sm-2  col-md-2 visible-sm visible-lg visible-md   billzy-deal gutter text-center')][01] //div[contains(@class, 'deal-popover')])[01]//span[contains(@style,'margin')]"));

        }
        public IWebElement withdrawimg()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class,'text-left col-lg-2 col-sm-2  col-md-2 visible-sm visible-lg visible-md   billzy-deal gutter text-center')]//div//img[contains(@src,'/assets/billzy-offer/offer_grey_bgGrey.png')]"));

        }
        public IWebElement withdrawimgtxt()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class,'text-left col-lg-2 col-sm-2  col-md-2 visible-sm visible-lg visible-md   billzy-deal gutter text-center')]//div//span"));

        }
        public IWebElement Invoicelist()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[1]/div[2]/div[12]/div[1]/div/h4"));

        }

        public IWebElement OfferStatussendpage()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[1]/div[2]/div[11]/div/div[14]/div/span"));

        }
        
        public IWebElement DealStatus()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[1]/div[2]/div[11]/div[1]/div[14]/div/span"));
        }
        public IWebElement OfferDeclinedIcon()
        {
            return webDriver.FindElement(By.XPath("//div//img[contains(@src,'/assets/billzy-offer/offer_red.png')]"));
        }
        public IWebElement OfferSentIcon()
        {
            return webDriver.FindElement(By.XPath("//div//img[contains(@src,'/assets/billzy-offer/offer_grey_bgGrey.png')]"));
        }
        public IWebElement OfferSentIconbiller()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class,'deal-popover')]//img[contains(@src,'/assets/billzy-offer/offer_grey_bgGrey.png')]"));
        }

        public IWebElement OfferWithdrawnIcon()
        {
            return webDriver.FindElement(By.XPath("//div//img[contains(@src,'/assets/billzy-offer/offer_grey_bgGrey.png')]"));
        }
        public IWebElement OfferwithdrawnbillerStatus()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class,'sent-data')]//div//div[contains(@class,'text-left col-lg-2 col-sm-2  col-md-2 visible-sm visible-lg visible-md   billzy-deal gutter text-center')]//div//span"));

        }
        public IWebElement OfferDeclinedhover()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'text-left col-lg-2 col-sm-2  col-md-2 visible-sm visible-lg visible-md   billzy-deal gutter text-center')][01] //div[contains(@class, 'deal-popover')])[01]//img[contains(@src,'/assets/billzy-offer/offer_green_blue.png')]"));
        }
        public IWebElement OfferSenthover()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'text-left col-lg-2 col-sm-2  col-md-2 visible-sm visible-lg visible-md   billzy-deal gutter text-center')][01] //div[contains(@class, 'deal-popover')])[01]"));
        }
        public IWebElement OfferDeclinedstatus()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[1]/div[2]/div[11]/div/div[14]/div/span"));
        }
        public IWebElement HistoryProcessingStatus()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'col-sm-half col-sm-1 col-xs-1 text-center')][01] //i[contains(@class, 'greenColour glyphicon glyphicon-refresh')])[01]"));
        }
        public IWebElement SIVProcessingStatus()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[3]/div[3]/div/div[1]/div[3]/div[1]/p[1]"));
        }

        public IWebElement HomePgInvDeails()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"sent-page-pills\"]"));
        }
        public IWebElement Showingtxt()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[1]/div[2]/div[12]/div[1]/div/h4"));
        }
        public IWebElement SentInvoicestxt()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[1]/div[2]/div[1]/h2"));
        }
        
        public IWebElement Totxt()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"sent-recipientBusiness-tablet-span\"]"));
        }
        public IWebElement InvoiceNumTxt()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"sent-invoicenum-span\"]"));
        }

        public IWebElement Statustxt()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"sent-status-span\"]"));
        }
        public IWebElement HistoryDeletedStatus()
        {
            return webDriver.FindElement(By.XPath("//i[contains(@class,'deleted-circle paid-background')]"));
        }


        public IWebElement Duetxt()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"sent-dueDate-span\"]"));
        }
        public IWebElement Amounttxt()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"sent-amount-span\"]"));
        }
        public IWebElement BillzyIcon()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"sent-billzyDeal\"]/span/img[1]"));
        }
        public IWebElement Actionstxt()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[1]/div[2]/div[10]/div[13]/span"));
        }
        public IWebElement HistMarkAspaid()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class,'paid-foreground col-lg-2 col-md-2 col-sm-2  hidden-xs left-align')]"));
        }
        public IWebElement HistDelete()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class,'unpaid-foreground col-lg-2 col-md-2 col-sm-2  hidden-xs left-align')]//p"));
        }

        public IWebElement HistoryOfferwithdrawnStatus()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class,'text-left col-lg-2 col-sm-2  col-md-2 visible-sm visible-lg visible-md   billzy-deal gutter text-center')]//div//span"));
        }
        public IWebElement ExportCSVFile()
        {
            //return webDriver.FindElement(By.ClassName("//*[@id=\"export-message-success\"]/a"));
            return webDriver.FindElement(By.ClassName("export-download-link"));
        }
        public IWebElement pdfdet()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"plugin\"]"));
        }

    }
}
