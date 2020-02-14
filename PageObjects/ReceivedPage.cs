using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BillzyAutomationTestSuite.PageObjects
{
    class ReceivedPage
    {
        private IWebDriver webDriver;
        public ReceivedPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public IWebElement SearchInvoiceReceived()
        {
            return webDriver.FindElement(By.XPath("//*[@id = 'received-search-invoiced']"));
        }
        //searchedFirstRowDetailsLink.xpath 	= (//div[contains(@class,'row table-row combined-row')]/div/div[contains(@class, 'view-details-lnk')])[1]
        public IWebElement SearchedFirstRowDetailsLink()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')]/div/div[contains(@class, 'view-details-lnk')])[1]"));
        }
        public IWebElement OfferWithdrawnIcon()
        {
            return webDriver.FindElement(By.XPath("//div//img[contains(@src,'/assets/billzy-offer/offer_grey_bgGrey.png')]"));
        }
        public IWebElement HistOfferWithdrawnIcon()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'deal-popover')]//img[contains(@src,'/assets/billzy-offer/offer_grey_bgGrey.png')]"));
        }
        public IWebElement Expiredhovertxt()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'received-data')]//div[contains(@class, 'row table-row combined-row  background-White')][1]//div[contains(@class, 'text-left col-lg-2 col-sm-2  col-md-2 visible-sm visible-lg visible-md   billzy-deal gutter text-center')]//div[contains(@class, 'deal-popover')]"));
        }
        

        public IWebElement SearchedFirstRowDetailsLink1()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')]/div/div[contains(@class, 'col-md-2 visible-md view-details-lnk invoice-number blueColour')])[1]"));
        }

        public IWebElement AlreadyPaidBTN()
        {
            return webDriver.FindElement(By.XPath("//ul[@id='received-page-pills']//li[@id= 'paid-toogle']"));
        }


        public IWebElement DoneBTN()
        {
            return webDriver.FindElement(By.XPath("//*[contains(@class, 'btn doneBtn')]"));
        }


        public IWebElement SelectRow2()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[3]/div[8]/div/div[2]"));
        }


        public IWebElement ConfirmPayment()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[1]/div[6]/div[1]/div/button/span[1]"));
        }


        public IWebElement EmptyBoxIcon()
        {
            return webDriver.FindElement(By.Id("no-match-found-img-rcvd"));
        }


        public IWebElement PayBTN()
        {
            return webDriver.FindElement(By.XPath("//*[contains(@class, 'pay-now-link')]"));
        }


        public IWebElement SelectRow1()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"received-page-pills\"]"));
        }


        public IWebElement NeedtoPayBTN()
        {
            return webDriver.FindElement(By.XPath("//ul[@id='received-page-pills']//li[@id= 'unpaid-toogle']"));
        }


        public IWebElement ToPayTab()
        {
            return webDriver.FindElement(By.XPath("//ul[@id='received-page-pills']//li[@id= 'unpaid-toogle'] //a[text()='To Pay']"));
        }


        public IWebElement PaidTab()
        {
            return webDriver.FindElement(By.XPath("//ul[@id='received-page-pills']//li[@id= 'paid-toogle'] //a[text()='Paid']"));
        }


        public IWebElement ReceivedHistoryBTN()
        {
            return webDriver.FindElement(By.XPath("//ul[@id='received-page-pills'] //a[text()='History']"));
        }


        public IWebElement ClearBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@src='/assets/billzy-clear-filter.svg' and @id='rcvd-clear-filter-lg']"));
        }


        public IWebElement NoInvoiceResult()
        {
            return webDriver.FindElement(By.XPath("(//h4[@id='no-match-found-msg'])[2]"));
        }



        public IWebElement PayInvoiceSelect()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'received-data')]//div[contains(@class, 'row table-row combined-row')]//div[contains(@class, 'col-md-1 col-sm-1 col-xs-1 text-center')]//div[contains(@class,'bill-pay-indicator select-bill no-bill-pay')]"));
        }

        public IWebElement PayInvoiceTwoSelect()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'received-data')]//div[contains(@class, 'row table-row combined-row')]//div[contains(@class, 'col-md-1 col-sm-1 col-xs-1 text-center')]//div[contains(@class,'bill-pay-indicator select-bill no-bill-pay')]"));
        }

        public IWebElement SelectCardrow1()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[1]/div[4]/div/div/div[2]/div[6]/div/div"));
        }
        public IWebElement SelectValidCardrow1()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[1]/div[4]/div/div/div[2]/div[6]/div/ul/li[2]/a"));
        }
        public IWebElement SelectCardrow2()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[1]/div[4]/div[2]/div/div[2]/div[6]/div/div"));
        }
        public IWebElement SelectValidCardrow2()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[1]/div[4]/div[2]/div/div[2]/div[6]/div/ul/li[2]/a"));
        }
        public IWebElement SelectDebitRow1()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[1]/div[4]/div[1]/div/div[2]/div[6]/div/div"));
        }
        public IWebElement SelectValidDebitCard1()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[1]/div[4]/div[1]/div/div[2]/div[6]/div/ul/li/a"));
        }
        public IWebElement SelectDebitRow2()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[1]/div[4]/div[2]/div/div[2]/div[6]/div/div"));
        }
        public IWebElement SelectValidDebitCard2()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[1]/div[4]/div[2]/div/div[2]/div[6]/div/ul/li/a"));
        }
        public IWebElement SelectDebitRow3()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[1]/div[4]/div/div[2]/div[2]/div[6]/div/div"));
        }
        public IWebElement SelectValidDebitCard3()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[1]/div[4]/div/div[2]/div[2]/div[6]/div/ul/li/a"));
        }

        public IWebElement SearchInvoiceReceived1()
        {
            return webDriver.FindElement(By.XPath("//*[@id = 'received-search-invoiced']"));
        }


        public IWebElement BillzyReferenceReceived()
        {
            return webDriver.FindElement(By.XPath("//*[@id = 'rcvd-invoicenum']"));
        }


        public IWebElement BillzyRefResult()
        {
            return webDriver.FindElement(By.XPath("(//*[@class=\"received-data\"]//div[contains(@class, 'row table-row combined-row')] //div[contains(@class,'view-details-lnk invoice-number')])[1]"));
        }


        public IWebElement ReceivedPageReferenceRow01()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class, 'invoice-number')]) [01]"));
        }


        public IWebElement ReceivedPageReferenceRow02()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class, 'invoice-number')]) [02]"));
        }


        public IWebElement ReceivedPageReferenceRow03()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class, 'invoice-number')]) [03]"));
        }


        public IWebElement ReceivedPageReferenceRow04()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class, 'invoice-number')]) [04]"));
        }


        public IWebElement ReceivedPageReferenceRow05()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class, 'invoice-number')]) [05]"));
        }


        public IWebElement ReceivedPageReferenceRow06()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class, 'invoice-number')]) [06]"));
        }


        public IWebElement ReceivedPageReferenceRow07()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class, 'invoice-number')]) [07]"));
        }


        public IWebElement ReceivedPageReferenceRow08()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class, 'invoice-number')]) [08]"));
        }


        public IWebElement ReceivedPageReferenceRow09()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class, 'invoice-number')]) [09]"));
        }


        public IWebElement ReceivedPageReferenceRow10()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class, 'invoice-number')]) [10]"));
        }



        public IWebElement InvoiceReferenceRow01()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class, 'reference')]) [01]"));
        }
        public IWebElement InvoiceReferenceRow02()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class, 'reference')]) [02]"));
        }
        public IWebElement InvoiceReferenceRow03()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class, 'reference')]) [03]"));
        }
        public IWebElement InvoiceReferenceRow04()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class, 'reference')]) [04]"));
        }
        public IWebElement InvoiceReferenceRow05()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class, 'reference')]) [05]"));
        }
        public IWebElement InvoiceReferenceRow06()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class, 'reference')]) [06]"));
        }
        public IWebElement InvoiceReferenceRow07()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class, 'reference')]) [07]"));
        }
        public IWebElement InvoiceReferenceRow08()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class, 'reference')]) [08]"));
        }
        public IWebElement InvoiceReferenceRow09()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class, 'reference')]) [09]"));
        }
        public IWebElement InvoiceReferenceRow10()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class, 'reference')]) [10]"));
        }
        public IWebElement VerifystatusIcon()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@id,'row-unpaidRow-')]/div[7]/img"));
        }
        
        public IWebElement PostedIcon()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@id,'row-unpaidRow-')]/div[2]/i"));
        }



        public IWebElement BillzyDealRow01()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //span[contains(@class, 'billzy-deal-value')]) [01]"));
        }
        public IWebElement BillzyDealRow02()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //span[contains(@class, 'billzy-deal-value')]) [02]"));
        }
        public IWebElement BillzyDealRow03()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //span[contains(@class, 'billzy-deal-value')]) [03]"));
        }
        public IWebElement BillzyDealRow04()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //span[contains(@class, 'billzy-deal-value')]) [04]"));
        }
        public IWebElement BillzyDealRow05()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //span[contains(@class, 'billzy-deal-value')]) [05]"));
        }
        public IWebElement BillzyDealRow06()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //span[contains(@class, 'billzy-deal-value')]) [06]"));
        }
        public IWebElement BillzyDealRow07()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //span[contains(@class, 'billzy-deal-value')]) [07]"));
        }
        public IWebElement BillzyDealRow08()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //span[contains(@class, 'billzy-deal-value')]) [08]"));
        }
        public IWebElement BillzyDealRow09()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //span[contains(@class, 'billzy-deal-value')]) [09]"));
        }
        public IWebElement BillzyDealRow10()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //span[contains(@class, 'billzy-deal-value')]) [10]"));
        }

        public IWebElement BillzyDealIconRow01()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class, 'billzy-deal-icon')]) [01]"));
        }

        public IWebElement ReferenceHeader()
        {
            return webDriver.FindElement(By.Id("rcvd-invoicenum"));
        }
        public IWebElement UnpaidRow1()
        {
            return webDriver.FindElement(By.Id("row-unpaidRow-1"));
        }
       
        public IWebElement SearchedSecondRowDetailsLink()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')]/div/div[contains(@class, 'view-details-lnk')])[2]"));
        }
        public IWebElement SearchedThirdRowDetailsLink()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')]/div/div[contains(@class, 'view-details-lnk')])[3]"));
        }
        public IWebElement SearchedFourthRowDetailsLink()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')]/div/div[contains(@class, 'view-details-lnk')])[4]"));
        }
        public IWebElement SearchedFifthRowDetailsLink()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')]/div/div[contains(@class, 'view-details-lnk')])[5]"));
        }

        public IWebElement SearchedFirstRowPayCheckBox()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')]/div/div/div[contains(@class, 'bill-pay-indicator')])[1]"));
        }
        public IWebElement SearchedSecondRowPayCheckBox()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')]/div/div/div[contains(@class, 'bill-pay-indicator')])[2]"));
        }
        public IWebElement SearchedThirdRowPayCheckBox()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')]/div/div/div[contains(@class, 'bill-pay-indicator')])[3]"));
        }
        public IWebElement SearchedFourthRowPayCheckBox()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')]/div/div/div[contains(@class, 'bill-pay-indicator')])[4]"));
        }
        public IWebElement SearchedFifthRowPayCheckBox()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')]/div/div/div[contains(@class, 'bill-pay-indicator')])[5]"));
        }

        public IWebElement BillzyDealIcon()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')] //div[contains(@class, ' view-details-lnk fa fa-tag billzy-deal-icon')])[1]"));
        }

        public IWebElement StatusColumn()
        {
            return webDriver.FindElement(By.XPath("//span[@id= 'rcvd-status-span' and text()= 'Status']"));
        }
        public IWebElement VerifiedColumn()
        {
            return webDriver.FindElement(By.XPath("//span[@id= 'rcvd-verified-span' and text()= 'Verified']"));
        }
        public IWebElement ToColumn()
        {
            return webDriver.FindElement(By.XPath("//span[@id= 'rcvd-sendersBusiness-span' and text()= 'From']"));
        }
        public IWebElement InvoiceNumColumn()
        {
            return webDriver.FindElement(By.XPath("//span[@id= 'rcvd-invoicenum-span' and text()= 'Invoice Number']"));
        }
        public IWebElement DueColumn()
        {
            return webDriver.FindElement(By.XPath("//span[@id= 'rcvd-dueDate-span' and text()= 'Due']"));
        }
        public IWebElement PaidOnColumn()
        {
            return webDriver.FindElement(By.XPath("//span[@id= 'paidTimestamp' and text()= 'Paid On']"));
        }
        public IWebElement CompletedColumn()
        {
            return webDriver.FindElement(By.XPath("//span[@id= 'rcvd-paidDate-span' and text()= 'Completed']"));
        }
        public IWebElement AmountColumn()
        {
            return webDriver.FindElement(By.XPath("//span[@id= 'rcvd-amount-span' and text()= 'Amount']"));
        }
        public IWebElement BillzyColumn()
        {
            return webDriver.FindElement(By.XPath("//div[@id = 'rcvd-billzyDeal'] //img[contains(@src,'billzy-column.png')]"));
        }
        public IWebElement ActionsColumn()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'unpaid-col')] //span[text() = 'Actions'])[2]"));
        }

        public IWebElement SelectAllUnchecked()
        {
            return webDriver.FindElement(By.XPath("//div[@class = 'received-details'] //div[contains(@class, 'select-all-bill no-bill-pay')]"));
        }
        public IWebElement SelectAllChecked()
        {
            return webDriver.FindElement(By.XPath("//div[@class = 'received-details'] //div[contains(@class, 'select-all-bill bill-pay')]"));
        }
        public IWebElement FirstRowUnchecked()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'received-data')] //div[contains(@class, 'select-bill no-bill-pay')])[1]"));
        }
        public IWebElement SecondRowUnchecked()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'received-data')] //div[contains(@class, 'select-bill no-bill-pay')])[2]"));
        }
        public IWebElement ThirdRowUnchecked()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'received-data')] //div[contains(@class, 'select-bill no-bill-pay')])[3]"));
        }
        public IWebElement FourthRowUnchecked()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'received-data')] //div[contains(@class, 'select-bill no-bill-pay')])[4]"));
        }
        public IWebElement FirstRowChecked()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'received-data')] //div[contains(@class, 'select-bill bill-pay')])[1]"));
        }
        public IWebElement SecondRowChecked()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'received-data')] //div[contains(@class, 'select-bill bill-pay')])[2]"));
        }
        public IWebElement ThirdRowChecked()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'received-data')] //div[contains(@class, 'select-bill bill-pay')])[3]"));
        }
        public IWebElement FourthRowChecked()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'received-data')] //div[contains(@class, 'select-bill bill-pay')])[4]"));
        }

        public IWebElement PdfButtonTop()
        {
            return webDriver.FindElement(By.Id("receivedUnpaid-download-btn"));
        }
        public IWebElement PdfButtonButton()
        {
            return webDriver.FindElement(By.XPath("//div[@class = 'received-details'] //div[contains(@class, 'pdf-download-area-bottom')] //button[@class = 'btn download-btn ladda-button']"));
        }

        public IWebElement TitlePage()
        {
            return webDriver.FindElement(By.XPath("//h2[text() = 'Received Invoices']"));
        }

        public IWebElement Filter()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'filter-box')] //input[@placeholder = 'Keyword'])[2]"));
        }

        public IWebElement FromDate()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'filter-box')] //div[@id = 'rcvd-date-from-dp']"));
        }

        public IWebElement ToDate()
        {
            return webDriver.FindElement(By.Id("received-date-to-filter"));
        }

        public IWebElement SelectInvoiceRow01()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class,'row table-row combined-row')] //div[@data-id = 'pay-now-col'])[01]"));
        }

        public IWebElement SelectInvoiceRow02()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class,'row table-row combined-row')] //div[@data-id = 'pay-now-col'])[02]"));
        }

        public IWebElement SelectInvoiceRow03()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class,'row table-row combined-row')] //div[@data-id = 'pay-now-col'])[03]"));
        }

        public IWebElement SelectInvoiceRow04()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class,'row table-row combined-row')] //div[@data-id = 'pay-now-col'])[04]"));
        }

        public IWebElement SelectInvoiceRow05()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class,'row table-row combined-row')] //div[@data-id = 'pay-now-col'])[05]"));
        }

        public IWebElement StatusNotViewedRow01()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class,'row table-row combined-row')] //i[@data-title= 'not viewed'])[2]"));
        }

        public IWebElement StatusNotViewedRow02()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class,'row table-row combined-row')] //i[@data-title= 'not viewed'])[2]"));
        }

        public IWebElement StatusViewedRow01()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class,'row table-row combined-row')] //i[@data-title= 'viewed'])[02]"));
        }

        public IWebElement StatuspostedRow01()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class,'row table-row combined-row')] //i[@data-title= 'posted'])[3]"));
        }
        public IWebElement StatusViewedRow02()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class,'row table-row combined-row')] //i[@data-title= 'viewed'])[02]"));
        }

        public IWebElement StatusOverdueRow01()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class,'row table-row combined-row')] //i[@data-title= 'overdue'])[01]"));
        }

        public IWebElement StatusProcessingRow01()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class,'row table-row combined-row')] //i[@data-title= 'processing'])[2]"));
        }


        public IWebElement StatusPendingRow01()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class,'row table-row combined-row')] //i[@data-title= 'pending'])[01]"));
        }

        public IWebElement StatusPaidRow01()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class,'row table-row combined-row')] //i[@data-title= 'paid'])[02]"));
        }

        public IWebElement StatusPostedRow01()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class,'row table-row combined-row')] //i [@data-title= 'posted'])[2]"));
        }

        public IWebElement StatusDeletedRow01()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'row-status-column')] //i[contains(@data-title, 'deleted')])[2]"));
        }

        public IWebElement VerifiedInvoice()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class,'row table-row combined-row')] //img[@data-title= 'verified'])[01]"));
        }
        public IWebElement UnverifiedInvoice()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class,'row table-row combined-row')] //img[@data-title= 'unverified'])[01]"));
        }

        public IWebElement UnverifiedInvoice1()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class,'row table-row combined-row')] //img[@data-title= 'unverified'])[02]"));
        }

        public IWebElement FromRow01()
        {
            return webDriver.FindElement(By.XPath("//div[@class= 'received-data'] //div[contains(@class,'row table-row combined-row')] //div[@class= 'col-lg-2 visible-lg']"));
            
        }
        
        public IWebElement FromBillerRow01()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"row-unpaidRow-54\"]/div[6]"));
           
        }
        public IWebElement BillzyInvoiceNumRow01()
        {
            return webDriver.FindElement(By.XPath("//div[@class= 'received-data'] //div[contains(@class,'row table-row combined-row')] //div[contains(@class, 'invoice-number')]"));
        }
        public IWebElement DueRow01()
        {
            return webDriver.FindElement(By.XPath("//div[@class= 'received-data'] //div[contains(@class,'row table-row combined-row')] //div[contains(@class, 'due-date-value unpaid')]"));
        }
        public IWebElement PaidOnRow1()
        {
            return webDriver.FindElement(By.XPath("//div[@class= 'received-data'] //div[@contains(@class,'row table-row combined-row')] //div[contains(@class, 'paid-date-value paid')]"));
        }
        public IWebElement CompletedRow1()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class,'row table-row combined-row')] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement AmountRow1()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class,'row table-row combined-row')] //div[contains(@class, 'paid-foreground')])[2]"));
        }
        public IWebElement AmountRowProcess11()
        {
            return webDriver.FindElement(By.XPath("//div[@class= 'received-data'] //div[@class= 'row table-row combined-row  background-White']//div//div[contains(@class, 'viewed-foreground col-sm-1-half  hidden-xs left-align')]"));
        }

        
        public IWebElement AmountRowProcess1()
        {
            return webDriver.FindElement(By.XPath("//div[@class= 'received-data'] //div[@class= 'row table-row combined-row  background-White']//div//div[contains(@class, 'overdue-foreground col-sm-1-half  hidden-xs left-align')]"));
        }
        
        public IWebElement AmountViewedRow1()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class,'row table-row combined-row')] //div[contains(@class, 'viewed-foreground')])[2]"));
        }
        public IWebElement AmountOverdueRow1Inbox()
        {
            return webDriver.FindElement(By.XPath("(//*[@class= 'received-data'] //*[contains(@class,'row table-row combined-row')] //div[contains(@class, 'overdue-foreground')])[2]"));
        }
        public IWebElement AmountOverdueRow1()
        {
            return webDriver.FindElement(By.XPath("(//*[@class= 'received-data'] //*[contains(@class,'row table-row combined-row')] //p[contains(@class, 'overdue-foreground')])[1]"));
        }
        public IWebElement AmountUnpaidProcessing()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[@contains(@class,'row table-row combined-row')] //div[contains(@class, 'unpaid-foreground')])[1]"));
        }

        public IWebElement BillzyRow1()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class,'row table-row combined-row')] //div[contains(@class, 'billzy-deal gutter')])[1]"));
        }

        public IWebElement ActionsMenu()
        {
            return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class,'row table-row combined-row')] //div[@class = 'action-menu-area'] //span[contains(@class,'actionMenu  dropdown-toggle')])[1]"));
        }

        public IWebElement PAY()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')] //ul[contains(@class, 'dropdown-menu dropdown-menu-right')] //li[text()='Pay'])[1]"));
        }
        public IWebElement StatusProcessingRow()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"row-unpaidRow-203\"]/div[4]/i"));
        }
        ////*[@id="row-unpaidRow-357"]/div[16]/div/img
        public IWebElement OfferExpiredIcon()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'text-left col-lg-2 col-sm-2  col-md-2 visible-sm visible-lg visible-md   billzy-deal gutter text-center')][01] //div[contains(@class, 'deal-popover')])[01]//img[contains(@src,'/assets/billzy-offer/offer_red.png')]"));
        }

        public IWebElement OfferSentIcon()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'text-left col-lg-2 col-sm-2  col-md-2 visible-sm visible-lg visible-md   billzy-deal gutter text-center')][01] //div[contains(@class, 'deal-popover')])[01]//img[contains(@src,'/assets/billzy-offer/offer_grey_bgGrey.png')]"));
        }
        public IWebElement OfferStatus()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'text-left col-lg-2 col-sm-2  col-md-2 visible-sm visible-lg visible-md   billzy-deal gutter text-center')][01] //div[contains(@class, 'deal-popover')])[01]//span"));

        }
        public IWebElement OfferdeclinedStatus()
        {
            return webDriver.FindElement(By.XPath("( //div[contains(@class, 'text-left col-lg-2 col-sm-2  col-md-2 visible-sm visible-lg visible-md   billzy-deal gutter text-center')])[01]//span"));

        }
        public IWebElement OfferwithdrawnpayerStatus()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class,'received-data')]//div//div//div[contains(@class,'text-left col-lg-2 col-sm-2  col-md-2 visible-sm visible-lg visible-md   billzy-deal gutter text-center')]//div//span"));

        }
        public IWebElement OfferDeclinedStatus()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class,'text-left col-lg-2 col-sm-2  col-md-2 visible-sm visible-lg visible-md   billzy-deal gutter text-center')][01]//div//span"));

        }
        public IWebElement OfferacceptedStatus()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'text-left col-lg-2 col-sm-2  col-md-2 visible-sm visible-lg visible-md   billzy-deal gutter text-center')][01] //div[contains(@class, 'deal-popover')])[01]//span"));

        }
        

        public IWebElement Offerhovertext()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'text-left col-lg-2 col-sm-2  col-md-2 visible-sm visible-lg visible-md   billzy-deal gutter text-center')][01] //div[contains(@class, 'deal-popover')])[01]"));
        }
        public IWebElement OfferSentIconhover()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'text-left col-lg-2 col-sm-2  col-md-2 visible-sm visible-lg visible-md   billzy-deal gutter text-center')][01] //div[contains(@class, 'deal-popover')])[01]"));
        }
        

        public IWebElement HistOfferstatus()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class,'text-left col-lg-2 col-sm-2  col-md-2 visible-sm visible-lg visible-md   billzy-deal gutter text-center')]//div//span"));

        }
        public IWebElement HistOfferWithdrawndeletedstatus()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'deal-popover')]//span"));

        }
        

        public IWebElement HistOfferIcon()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class,'text-left col-lg-2 col-sm-2  col-md-2 visible-sm visible-lg visible-md   billzy-deal gutter text-center')]//div//img[contains(@src,'/assets/billzy-offer/offer_red.png')]"));

        }
        public IWebElement PDFInvoice()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')] //ul[contains(@class, 'dropdown-menu dropdown-menu-right')] //li[contains(text(),'PDF Invoice')])[1]"));
        }

        public IWebElement DeleteOption()
        {
            return webDriver.FindElement(By.XPath("//ul[contains(@class, 'dropdown-menu dropdown-menu-right')] //li[text()='Delete']"));
        }

        public IWebElement BillzyDealOption()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class,'row table-row combined-row')] //ul[contains(@class, 'dropdown-menu dropdown-menu-right')] //li[contains(@data-id, 'billzy-deal-action')]"));
        }

        public IWebElement MarkAsPaidOptionJLL()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')] //ul[contains(@class, 'dropdown-menu dropdown-menu-right')] //li[text()='Mark As Paid'])"));
        }
        public IWebElement MarkAsPaidOptionFT()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')] //ul[contains(@class, 'dropdown-menu dropdown-menu-right')] //li[text()='Mark As Paid'])[2]"));
        }

        public IWebElement VerifyInvoice()
        {
            return webDriver.FindElement(By.XPath("//ul[contains(@class, 'dropdown-menu dropdown-menu-right')] //li[contains(@data-id, 'payer-invoice-verify')]"));
        }

        public IWebElement PostInvoice()
        {
            return webDriver.FindElement(By.XPath("//ul[contains(@class, 'dropdown-menu dropdown-menu-right')] //li[contains(@data-id, 'post-invoice')]"));
        }

        public IWebElement PayBTNTop()
        {
            return webDriver.FindElement(By.XPath("//button[contains(@class, 'btn pay-now-link primary-btn pay-now-mobile-preview pay-btn-top')]"));
        }

        public IWebElement PayBTNBottom()
        {
            return webDriver.FindElement(By.XPath("//button[contains(@class ,'btn pay-now-link primary-btn pay-now-mobile-preview pay-btn-bottom ladda-button')]"));
        }

        public IWebElement PaYBTNTopText()
        {
            return webDriver.FindElement(By.XPath("//button[contains(@class, 'btn pay-now-link primary-btn pay-now-mobile-preview pay-btn-top')] //span[@class='pay-button-text']"));
        }

        public IWebElement PaYBTNBottomText()
        {
            return webDriver.FindElement(By.XPath("//button[contains(@class ,'btn pay-now-link primary-btn pay-now-mobile-preview pay-btn-bottom ladda-button')] //span[@class = 'pay-button-text']"));
        }

        public IWebElement PostInvoiceTitleModal()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'modal-content')] //div[text()='Post Invoice']"));
        }

        public IWebElement PostInvoicePostBTN()
        {
            return webDriver.FindElement(By.Id("post-invoice-btn"));
        }

        public IWebElement PostInvoiceCancelBTN()
        {
            return webDriver.FindElement(By.XPath("(//div[@class = 'modal-body'] //button[text()='CANCEL'])[2]"));
        }

        public IWebElement ReceivedOnloadInvoiceCount_Sum()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"received-page-pills\"]/li[3]"));
        }

        public IWebElement BillzyDealFilterCheckBox()
        {
            return webDriver.FindElement(By.XPath("//*[@src='/assets/billzy-deal-filter-off.svg' and @id='rcvd-deal-filter-off-lg']"));
        }

        public IWebElement BillzyDealFilterUncheckBox()
        {
            return webDriver.FindElement(By.XPath("//*[@src='/assets/billzy-deal-filter-on.svg' and @id='rcvd-deal-filter-on-lg']"));
        }

        public IWebElement BillzyInboxFilterCheckBox()
        {
            return webDriver.FindElement(By.Id("rcvd-inbox-filter-off-lg"));
        }

        public IWebElement BillzyInboxFilterUncheckBox()
        {
            return webDriver.FindElement(By.Id("rcvd-cash-filter-on-lg"));
        }

        public IWebElement SelectExportFormat()
        {
            return webDriver.FindElement(By.Id("csv-export-received"));
        }

        public IWebElement BillzyExport()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"rcvd-export-format-div\"]/span/div/div/div[1]"));
        }

        public IWebElement MYOB()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"rcvd-export-format-div\"]/span/div/div/div[2]"));

        }

        public IWebElement XERO()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"rcvd-export-format-div\"]/span/div/div/div[3]"));
        }
        public IWebElement SentBillzyDealFilterCheckBox()
        {
            return webDriver.FindElement(By.XPath("//label[@for='billzy-deal-filter-checkbox']"));
        }

        public IWebElement LoadMoreBTN()
        {
            return webDriver.FindElement(By.XPath("//button[text()='LOAD MORE']"));
        }

        public IWebElement TotalAmountCount()
        {
            return webDriver.FindElement(By.XPath("//li[@class= 'bold invoice-summary-area-rcvd hidden-xs'] "));
        }

        public IWebElement ScrollToTop()
        {
            return webDriver.FindElement(By.XPath("//div[@class='received']  //div[@class='scrollToTop']"));
        }

        //Received Page Outstanding Tab - To Column
        public IWebElement ReceivedFromColumnRow01()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][01] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow02()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][02] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow03()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][03] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow04()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][04] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow05()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][05] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow06()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][06] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow07()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][07] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow08()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][08] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow09()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][09] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow10()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][10] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow11()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][11] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow12()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][12] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow13()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][13] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow14()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][14] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow15()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][15] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow16()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][16] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow17()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][17] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow18()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][18] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow19()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][19] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow20()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][20] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow21()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][21] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow22()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][22] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow23()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][23] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow24()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][24] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow25()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][25] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow26()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][26] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow27()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][27] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow28()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][28] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow29()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][29] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow30()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][30] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow31()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][31] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow32()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][32] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow33()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][33] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow34()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][34] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow35()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][35] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow36()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][36] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow37()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][37] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow38()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][38] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow39()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][39] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow40()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][40] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow41()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][41] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow42()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][42] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow43()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][43] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow44()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][44] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow45()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][45] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow46()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][46] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow47()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][47] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow48()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][48] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow49()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][49] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow50()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][50] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow51()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][51] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow52()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][52] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow53()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][53] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow54()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][54] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow55()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][55] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow56()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][56] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow57()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][57] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow58()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][58] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow59()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][59] //div[contains(@class, 'visible-lg')])[01]"));
        }

        public IWebElement ReceivedFromColumnRow60()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][60] //div[contains(@class, 'visible-lg')])[01]"));
        }
        //# Received Page Outstanding Tab - Invoice Number Column

        public IWebElement ReceivedInvoiceNumberColumnRow01()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][01] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow02()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][02] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow03()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][03] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow04()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][04] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow05()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][05] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow06()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][06] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow07()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][07] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow08()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][08] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow09()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][09] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow10()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][10] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow11()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][11] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow12()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][12] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow13()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][13] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow14()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][14] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow15()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][15] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow16()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][16] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow17()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][17] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow18()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][18] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow19()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][19] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow20()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][20] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow21()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][21] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow22()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][22] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow23()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][23] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow24()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][24] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow25()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][25] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow26()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][26] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow27()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][27] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow28()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][28] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow29()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][29] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow30()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][30] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow31()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][31] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow32()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][32] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow33()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][33] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow34()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][34] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow35()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][35] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow36()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][36] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow37()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][37] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow38()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][38] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow39()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][39] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow40()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][40] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow41()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][41] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow42()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][42] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow43()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][43] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow44()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][44] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow45()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][45] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow46()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][46] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow47()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][47] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow48()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][48] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow49()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][49] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow50()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][50] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow51()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][51] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow52()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][52] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow53()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][53] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow54()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][54] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow55()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][55] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow56()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][56] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow57()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][57] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow58()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][58] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow59()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][59] //div[contains(@class, 'view-details-lnk')])[01]"));
        }

        public IWebElement ReceivedInvoiceNumberColumnRow60()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][60] //div[contains(@class, 'view-details-lnk')])[01]"));
        }
        //# Received Page Outstanding Tab - Due Column

        public IWebElement ToPayDueColumnRow01()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][01] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow02()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][02] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow03()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][03] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow04()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][04] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow05()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][05] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow06()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][06] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow07()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][07] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow08()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][08] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow09()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][09] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow10()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][10] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow11()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][11] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow12()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][12] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow13()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][13] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow14()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][14] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow15()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][15] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow16()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][16] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow17()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][17] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow18()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][18] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow19()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][19] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow20()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][20] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow21()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][21] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow22()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][22] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow23()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][23] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow24()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][24] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow25()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][25] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow26()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][26] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow27()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][27] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow28()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][28] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow29()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][29] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow30()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][30] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow31()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][31] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow32()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][32] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow33()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][33] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow34()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][34] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow35()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][35] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow36()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][36] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow37()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][37] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow38()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][38] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow39()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][39] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow40()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][40] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow41()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][41] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow42()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][42] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow43()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][43] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow44()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][44] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow45()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][45] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow46()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][46] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow47()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][47] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow48()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][48] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow49()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][49] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow50()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][50] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow51()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][51] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow52()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][52] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow53()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][53] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow54()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][54] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow55()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][55] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow56()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][56] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow57()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][57] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow58()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][58] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow59()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][59] //div[contains(@class, 'due-date-value')])[01]"));
        }

        public IWebElement ToPayDueColumnRow60()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][60] //div[contains(@class, 'due-date-value')])[01]"));
        }
        //# Received Page Outstanding Tab - Completed Column

        public IWebElement HistoryCompletedColumnRow01()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][01] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow02()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][02] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow03()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][03] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow04()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][04] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow05()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][05] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow06()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][06] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow07()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][07] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow08()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][08] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow09()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][09] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow10()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][10] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow11()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][11] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow12()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][12] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow13()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][13] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow14()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][14] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow15()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][15] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow16()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][16] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow17()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][17] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow18()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][18] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow19()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][19] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow20()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][20] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow21()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][21] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow22()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][22] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow23()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][23] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow24()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][24] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow25()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][25] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow26()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][26] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow27()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][27] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow28()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][28] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow29()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][29] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow30()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][30] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow31()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][31] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow32()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][32] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow33()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][33] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow34()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][34] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow35()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][35] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow36()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][36] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow37()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][37] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow38()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][38] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow39()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][39] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow40()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][40] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow41()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][41] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow42()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][42] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow43()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][43] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow44()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][44] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow45()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][45] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow46()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][46] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow47()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][47] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow48()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][48] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow49()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][49] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow50()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][50] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow51()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][51] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow52()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][52] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow53()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][53] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow54()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][54] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow55()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][55] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow56()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][56] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow57()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][57] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow58()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][58] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow59()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][59] //div[contains(@class, 'paid-date-value')])[01]"));
        }

        public IWebElement HistoryCompletedColumnRow60()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][60] //div[contains(@class, 'paid-date-value')])[01]"));
        }
        //# Received Page Outstanding Tab - Amount Column

        public IWebElement ReceivedAmountColumnRow01()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][01] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow02()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][02] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow03()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][03] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow04()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][04] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow05()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][05] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow06()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][06] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow07()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][07] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow08()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][08] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow09()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][09] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow10()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][10] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow11()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][11] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow12()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][12] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow13()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][13] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow14()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][14] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow15()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][15] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow16()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][16] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow17()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][17] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow18()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][18] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow19()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][19] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow20()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][20] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow21()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][21] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow22()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][22] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow23()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][23] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow24()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][24] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow25()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][25] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow26()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][26] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow27()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][27] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow28()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][28] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow29()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][29] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow30()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][30] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow31()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][31] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow32()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][32] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow33()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][33] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow34()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][34] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow35()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][35] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow36()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][36] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow37()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][37] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow38()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][38] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow39()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][39] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow40()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][40] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow41()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][41] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow42()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][42] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow43()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][43] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow44()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][44] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow45()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][45] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow46()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][46] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow47()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][47] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow48()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][48] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow49()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][49] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow50()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][50] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow51()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][51] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow52()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][52] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow53()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][53] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow54()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][54] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow55()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][55] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow56()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][56] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow57()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][57] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow58()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][58] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow59()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][59] //div[contains(@class, 'left-align')])[01]"));
        }

        public IWebElement ReceivedAmountColumnRow60()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][60] //div[contains(@class, 'left-align')])[01]"));
        }
        //# Received Page Outstanding Tab - billzy Column

        public IWebElement ReceivedBillzyColumnRow01()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][01] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow02()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][02] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow03()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][03] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow04()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][04] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow05()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][05] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow06()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][06] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow07()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][07] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow08()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][08] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow09()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][09] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow10()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][10] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow11()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][11] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow12()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][12] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow13()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][13] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow14()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][14] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow15()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][15] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow16()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][16] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow17()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][17] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow18()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][18] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow19()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][19] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow20()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][20] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow21()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][21] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow22()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][22] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow23()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][23] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow24()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][24] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow25()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][25] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow26()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][26] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow27()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][27] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow28()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][28] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow29()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][29] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow30()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][30] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow31()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][31] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow32()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][32] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow33()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][33] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow34()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][34] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow35()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][35] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow36()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][36] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow37()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][37] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow38()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][38] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow39()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][39] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow40()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][40] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow41()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][41] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow42()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][42] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow43()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][43] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow44()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][44] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow45()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][45] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow46()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][46] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow47()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][47] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow48()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][48] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow49()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][49] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow50()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][50] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow51()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][51] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow52()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][52] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow53()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][53] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow54()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][54] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow55()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][55] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow56()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][56] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow57()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][57] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow58()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][58] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow59()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][59] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement ReceivedBillzyColumnRow60()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row table-row combined-row')][60] //div[contains(@class, 'billzy-deal')])[01]"));
        }

        public IWebElement CancelModalBTN()
        {
            return webDriver.FindElement(By.XPath("//button[@class ='btn secondary-btn cancel-new-deal-modal-btn']"));
        }
        ////*[@id="row-unpaidRow-28"]/div[11]
        /////*[@id="row-unpaidRow-28"]/div[13]
        ///
         public IWebElement InvoiceList()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[4]/div[12]/div[1]/div/h4"));
        }
        public IWebElement OfferRecievedIcon()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'text-left col-lg-2 col-sm-2  col-md-2 visible-sm visible-lg visible-md   billzy-deal gutter text-center')][01] //div[contains(@class, 'deal-popover')])[01]//img[contains(@src,'/assets/billzy-offer/offer_blue.png')]"));
        }
        public IWebElement HistOfferRecievedIcon()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'text-left col-lg-2 col-sm-2  col-md-2 visible-sm visible-lg visible-md   billzy-deal gutter text-center')]//div//img[contains(@src,'/assets/billzy-offer/offer_blue.png')]"));
        }
        public IWebElement OfferAcceptedIcon()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'text-left col-lg-2 col-sm-2  col-md-2 visible-sm visible-lg visible-md   billzy-deal gutter text-center')][01] //div[contains(@class, 'deal-popover')])[01]//img[contains(@src,'/assets/billzy-offer/offer_green_blue.png')]"));
        }
        public IWebElement OfferDeclinedIcon()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class, 'text-left col-lg-2 col-sm-2  col-md-2 visible-sm visible-lg visible-md   billzy-deal gutter text-center')])[01]//div//img[contains(@src,'/assets/billzy-offer/offer_red.png')]"));
        }
        public IWebElement OfferDeclinedhover()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'text-left col-lg-2 col-sm-2  col-md-2 visible-sm visible-lg visible-md   billzy-deal gutter text-center')][01] //div[contains(@class, 'deal-popover')])[01]//img[contains(@src,'/assets/billzy-offer/offer_red.png')]"));
        }


        public IWebElement HistoryPaidStatus()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'col-sm-half visible-lg text-center row-status-column')][01] //i[contains(@class, 'paid-circle paid-background')])[01]"));
        }
        public IWebElement HistoryDeletedStatus()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class,'visible-xs row-status-column')]//i[contains(@class,'deleted-circle paid-background')]"));
        }
        public IWebElement HistoryProcessingStatus()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'col-sm-2 visible-sm')][01] //i[contains(@class, 'greenColour glyphicon glyphicon-refresh')])[01]"));
        }
        
        public IWebElement RecInvoicestxt()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[4]/div[2]/h2"));
        }

        public IWebElement Fromtxt()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"rcvd-sendersBusiness-tablet-span\"]"));
        }
        public IWebElement InvoiceNumTxt()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"rcvd-invoicenum-tablet-span\"]"));
        }

        public IWebElement InvoiceNumclick()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"rcvd-invoicenum-span\"]"));
        }
        //*[@id="rcvd-invoicenum-span"]
        public IWebElement Statusverifiedtxt()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"rcvd-verified-span\"]"));
        }



        public IWebElement Duetxt()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"rcvd-dueDate-span\"])"));
        }
        public IWebElement Amounttxt()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"rcvd-amount-span\"]"));
        }
        public IWebElement BillzyIcon()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"rcvd-billzyDeal\"]/span/img[2]"));
        }
        public IWebElement Actionstxt()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[4]/div[10]/div[16]/span"));
        }
        public IWebElement Showingtxt()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[2]/div[4]/div[12]/div[1]/div/h4"));
        }
        public IWebElement HomePgInvDeails()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"received-page-pills\"]"));
        }
        //div[contains(@class,'col-xs-3 visible-xs')]//div
        public IWebElement HistMarkAspaid()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class,'paid-foreground col-sm-1-half  hidden-xs left-align')]"));
            
        }
        public IWebElement HistDelete()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class,'col-xs-3 visible-xs')]//div//p"));
        }
        public IWebElement HistDeleteamount()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class,'viewed-foreground col-sm-1-half  hidden-xs left-align')]//p[contains(@class,'overdue-foreground m-b-0')]"));
        }

        public IWebElement HistoverdueDeleteamount()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class,'overdue-foreground col-sm-1-half  hidden-xs left-align')]//p[contains(@class,'overdue-foreground m-b-0')]"));
        }
        
        public IWebElement TopayNotViewed()
        {
            
            //return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class,'row table-row combined-row')] //i[@data-title= 'not viewed'])[3]"));
            return webDriver.FindElement(By.XPath("//div[contains(@id,'row-unpaidRow-')]/div[4]/i"));
            
        }
        public IWebElement TopayViewed()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@id,'row-unpaidRow-')]/div[4]/i"));
        }
        public IWebElement ViewedStatusClick()
        {

            //return webDriver.FindElement(By.XPath("(//div[@class= 'received-data'] //div[contains(@class,'row table-row combined-row')] //i[@data-title= 'not viewed'])[3]"));
            return webDriver.FindElement(By.XPath("//div[contains(@id,'row-unpaidRow-')]/div[4]"));

        }

        public IWebElement PDFSelection5()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"row-unpaidRow-5\"]/div[1]/div[1]"));
        }
        public IWebElement PDFSelection51()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"row-unpaidRow-51\"]/div[1]/div[1]"));
        }
        public IWebElement PDFSelection79()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"row-unpaidRow-90\"]/div[1]/div[1]"));
        }

        public IWebElement PDFSentHistSelection5()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"row-unpaidRow-85\"]/div[1]/div[1]"));
        }

        public IWebElement Invoiceloaded()
        {
            return webDriver.FindElement(By.XPath("//*[@class=\"invoices-loaded center-text\"]"));
        }

    }
}


