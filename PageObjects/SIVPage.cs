using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
namespace BillzyAutomationTestSuite.PageObjects
{
    class SIVPage
    {
        private IWebDriver webDriver;
        public SIVPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
        ////*[@id="cash-status-icon"]/div/p
        /// <summary>
         public IWebElement SIVCashRequestedStatus()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"cash-status-icon\"]/div/p"));
        }
        public IWebElement SIVOfferDiscountpercentage()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"add-discount-modal\"]/div/div/div[2]/div[1]/div[1]/div[2]/div[1]/div[3]/span"));
        }
        public IWebElement postmessage()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"pay-panel-deal-or-biller\"]/div/div[4]/div[3]"));
            
        }
        public IWebElement postmessagepayer()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"pay-panel-no-deal\"]/div[5]/div"));
            //*[@id="pay-panel-no-deal"]/div[5]/div
        }


        public IWebElement DeleteComment()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"delete-comments\"]"));
        }
        public IWebElement VerifiedTextMsg()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"pay-panel-no-deal\"]/div[4]/div[1]"));
        }
        public IWebElement VerifiedTextMsgBiller()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"pay-panel-deal-or-biller\"]/div/div[4]/div[2]"));
        }
        public IWebElement VerifyTextMsg()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"invoice-verify-panel\"]/div/div/div[2]/div/i"));
        }
        /// </summary>
        /// <returns></returns>
        public IWebElement PayerOfferEarlyPaymentBTN()
        {
            return webDriver.FindElement(By.XPath("//div[@class = 'preview-bill'] //strong[text() = 'OFFER EARLY PAYMENT' and not(contains(@class,'hide ') )]"));
        }
        public IWebElement PayerMakeACounterOfferBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"biller-made-deal-payer-action-panel\" and not(contains(@class,'hide ') )] //*[text()='MAKE A COUNTER-OFFER']"));
        }
        public IWebElement NewTotal()
        {
            return webDriver.FindElement(By.XPath("//*[@id='discount-amount-payable']"));
         }
        public IWebElement OfferExpiry()
        {
            return webDriver.FindElement(By.Id("discount-due-date"));
        }
        public IWebElement Comments()
        {
            return webDriver.FindElement(By.Id("discount-comments"));
        }
        public IWebElement offerEarlyPaymentModalBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id='send-offer-btn-label' and text()='OFFER EARLY PAYMENT']"));
        }
        //
        public IWebElement OfferEarlyPaymentModalBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"payer-new-deal-btn\"]/span[1]/strong"));
        }

        public IWebElement OfferEarlyPaymentModalBTN1()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"send-offer-btn-label\"]"));
        }
        
        public IWebElement makeCounterOfferModalBTN()
        {
            return webDriver.FindElement(By.XPath("//span[text()='MAKE COUNTER-OFFER']"));
        }
        
        public IWebElement SIVDealErrorMessage()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"add-discount-modal\"]/div/div/div[2]/div[1]/div[1]/span"));
        }

        ////*[@id="payer-made-deal-payer-action-panel"]/div[2]/button/span[1]/strong
        public IWebElement WithdrawOffer()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"payer-made-deal-payer-action-panel\"]/div[2]/button/span[1]/strong"));

        }
        public IWebElement BillerWithdrawOffer()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"biller-made-deal-biller-action-panel\"]/div[2]/button/span[1]/strong"));

        }   
        

        public IWebElement NewTotalSIV()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"discount-amount-payable\"]"));
        }
        public IWebElement WithdrawOfferCancelButton()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"withdraw-offer\"]/div/div/div[2]/div[3]/div[2]/button"));
        }
        public IWebElement ReturnBTN()
        {
            return webDriver.FindElement(By.XPath("//button[text()='RETURN']"));
        }
        public IWebElement InvoiceNumber()
        {
            return webDriver.FindElement(By.XPath("substring (//div[@class='row invoice-info-top'] //p[2] /text()[1] , 30, 11)"));
        }
        public IWebElement InvoiceDetailsToggle()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[3]/div[3]/div/div[1]/div[1]"));
        }
        public IWebElement PayBTNNoDeal()
        {
            return webDriver.FindElement(By.Id("pay-button-no-deal"));
        }
        public IWebElement InvoiceStatus()
        {
            return webDriver.FindElement(By.XPath("//p[contains(@class,'status-icon right')]"));
        }
        public IWebElement Unpaidstatus()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[3]/div[3]/div/div[1]/div[3]/div[1]/p[1]"));
        }
        public IWebElement InvoiceDetailsSurchargeMsgBiller()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"pay-panel-deal-or-biller\"]/div/div[2]"));
        }
        public IWebElement InvoiceDetailsSurchargeMsgPayer()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"pay-panel-no-deal\"]/div[2]/div"));
        }
        public IWebElement InvoiceDetailsInvoiceAmount()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@id,'invoice-info-panel')] //div[contains(@class,'paid-invoice-amount')]"));
        }
        public IWebElement InvoiceDetailsInvoiceRef()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@id,'invoice-info-panel')] /div[2]"));
        }
        public IWebElement InvoiceDetailsIssueDate()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@id,'invoice-info-panel')] /div[3]"));
        }
        public IWebElement InvoiceDetailsPaymentTerms()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@id,'invoice-info-panel')] /div[4]"));
        }
        public IWebElement InvoiceDetailsPayPanel()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@id, 'pay-panel-paid')] // div[2]"));
        }
        public IWebElement InvoiceDetailsDatePaid()
        {
            return webDriver.FindElement(By.Id("paid-date-span-value"));
        }
        public IWebElement InvoiceDetailsDuePaid()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'invoice-info-top')] //div[contains(@class, 'due-date')]"));
        }
        public IWebElement InvoiceDetailsPayPanelUnpaidWithDeal()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@id, 'pay-panel-deal')] //span[contains(@class, 'amount-text')]"));
        }
        public IWebElement InvoiceDetailsMarkAsPaidDate()
        {
            return webDriver.FindElement(By.Id("paid-date-span-value"));
        }
        public IWebElement PaymentMethodUsed()
        {
            return webDriver.FindElement(By.XPath("/html/body/div[2]/div[4]/div[3]/div[3]/div/div[2]/div[4]/div[1]/div[1]"));
        }
        public IWebElement DealSection()
        {
            return webDriver.FindElement(By.Id("active-deal-div"));
        }
        public IWebElement DealToggle()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"toggle-deal-info\"]"));
        }
        public IWebElement ExpiryDayBiller()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"has-active-deal\"] //*[text()='Expires in']"));
        }

        public IWebElement DiscPerctageValue()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"has-active-deal\"]/div/div[1]/div[1]/div/div[3]/div[3]"));
        }
        public IWebElement GetPaidInfoBiller()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"has-active-deal\"]/div/div[1]/div[1]/div/div[3]/div[4]/div[1]"));
        }
        public IWebElement DealAmountBiller()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"has-active-deal\"]/div/div[1]/div[2]/div[2]/div[1]/span"));
        }
        public IWebElement TotalGSTInfo()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"has-active-deal\"]/div/div[1]/div[2]/div[2]/div[2]/span"));
        }
        public IWebElement CommentsSIV()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"deal-info-panel\"]/div[3]"));
        }
        public IWebElement PayButton()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"pay-button-deal\"]"));
        }
        public IWebElement PayButtonNoDeal()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"pay-button-no-deal\"]"));
        }
        public IWebElement SurchargeMessage()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"has-active-deal\"]/div/div[1]/div[2]/div[1]/div[4]/i"));
        }
        public IWebElement ExpiryDayPayer()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"has-active-deal\"]/div/div[1]/div[1]/div/div[3]/div[2]/div"));
        }
        public IWebElement SavedInfoPayer()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"has-active-deal\"]/div/div[1]/div[1]/div/div[3]/div[4]/div[2]"));
        }
        public IWebElement OfferedBy()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"deal-info-panel\"]/div[2]"));
        }
        public IWebElement CreateANewOffer()
        {
            return webDriver.FindElement(By.XPath("//button[@id=\"biller-new- deal-btn\"]"));
        }
        public IWebElement DealHeading()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"add-discount-modal\"]/div/div/div[1]/h4"));
        }
        public IWebElement CancelButton()
        {
            return webDriver.FindElement(By.XPath("//div[contains(@class, 'modal-dialog')] //button[@class = 'btn secondary-btn cancel-new-deal-modal-btn cancel-btn']"));
        }
        public IWebElement ExpiresXDays()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"has-active-deal\"]/div/div[1]/div[1]/div/div[3]/div[1]/div/span/strong"));
        }
        public IWebElement XPercentDisc()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"has-active-deal\"]/div/div[1]/div[1]/div/div[3]/div[3]/b"));
        }
        public IWebElement ExpiresDateAndTime()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"deal-info-panel\"]/div[1]"));
        }
        public IWebElement WithdrawOfferBillerBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"biller-made-deal-biller-action-panel\"]/div[2]/button"));
        }
        public IWebElement WithdrawOfferPayerBTN()
        {
            return webDriver.FindElement(By.XPath("(//button[@data-id = 'withdraw-deal-btn'] //strong[text()= 'WITHDRAW OFFER'])[2]"));
        }
        public IWebElement PayerPendingDealAmount()
        {
            return webDriver.FindElement(By.XPath("//div[@class='payer-pending-deal'] //span[@class='amount-text']"));
        }
        public IWebElement PayerPendingDealMessage()
        {
            return webDriver.FindElement(By.XPath("(//div[@class='payer-pending-deal'])[1]"));
        }
        public IWebElement BillzyDealNotification()
        {
            return webDriver.FindElement(By.Id("paid-deal-biller"));
        }
        public IWebElement BillzyDealNofitfactionPayer()
        {
            return webDriver.FindElement(By.Id("paid-deal-payer"));
        }
        public IWebElement BillzyDealNotificationPending()
        {
            return webDriver.FindElement(By.Id("paid-processing-or-pending"));
        }
        public IWebElement DealPercentage()
        {
            return webDriver.FindElement(By.XPath("//span[contains(@class, 'deal-subtext discount-percent')]"));
        }
        public IWebElement BillerOfferADiscountBTN()
        {
            return webDriver.FindElement(By.XPath("//div[@class = 'preview-bill'] //strong[text() = 'OFFER A DISCOUNT' and not(contains(@class,'hide') )]"));
        }
        public IWebElement BillerMakeACounterOfferBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"payer-made-deal-biller-action-panel\" and not(contains(@class,'hide') )] //*[text()='MAKE A COUNTER-OFFER']"));
        }
        public IWebElement OfferDiscountModalBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id='send-offer-btn-label' and text()='OFFER DISCOUNT']"));
        }
        public IWebElement CancelModalBTN()
        {
            return webDriver.FindElement(By.XPath("//button[@id = 'cancel-modal-btn']"));
        }
        public IWebElement YesWithdrawOfferBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"withdraw-offer\"]/div/div/div[2]/div[3]/div[1]/button"));
        }
        public IWebElement WithdrawNoBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"withdraw-offer\"]/div/div/div[2]/div[3]/div[2]/button"));
        }
        public IWebElement DeclineOfferBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"payer-made-deal-biller-action-panel\" and not(contains(@class,'hide') )]/div[1]/button"));
        }
        public IWebElement DeclineOfferModalYes()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"decline-offer\"]/div/div/div[2]/div[3]/div[1]/button"));
        }
        public IWebElement DeclineOfferModalNo()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"decline-offer\"]/div/div/div[2]/div[3]/div[2]/button"));
        }
        public IWebElement AcceptOfferBTN()
        {
            return webDriver.FindElement(By.XPath("//button[@data-id='biller-accept-btn' and not(contains(@class,'hide') )]"));
                }
        public IWebElement AcceptTheOfferModalYesBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"accept-offer\"]/div/div/div[2]/div[3]/div[1]/button/span[1]"));
        }
        public IWebElement AcceptTheOfferModalNoBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"accept-offer\"]/div/div/div[2]/div[3]/div[2]/button"));
        }
        public IWebElement ActionDropdown()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"dd-action-inv\"]"));
        }
        public IWebElement ActionDropdownDelete()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"actionInv\"]//a[text()='Delete']"));
        }
        public IWebElement ActionDropdownMarkAsPaid()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"actionInv\"]//a[text()='Mark As Paid']"));
        }
        public IWebElement MarkAsPaidBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"mark-as-paid-modal\"]/div/div/div/div/div[4]/div[1]/button/span[text()='MARK AS PAID']"));
        }
        public IWebElement ConfirmDeleteBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"delete-invoice-modal\"]/div/div/div //span[text()='CONFIRM DELETE']"));
        }
        public IWebElement DeleteCancelBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"delete-invoice-modal\"]/div/div/div //button[text()='CANCEL']"));
        }
        public IWebElement MarkAsPaidCancelBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"mark-as-paid-modal\"]/div/div/div/div/div[4]/div[2]/button[text()='CANCEL']"));
        }
        public IWebElement MarkAsPaidErrorMessage()
        {
            return webDriver.FindElement(By.Id("mark-as-paid-errmessage"));
        }
        /* public IWebElement ToggleDealHistory()
         {
             return webDriver.FindElement(By.XPath("//div[contains(@class, 'deal-history-area deal-header-row')] /div [1]"));
         }*/

        public IWebElement ToggleDealHistory()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"deal-history-area\"]/div[1]"));
        }


        


        public IWebElement DiscountHistorySectionTitle()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"deal-history-area\"]/div[2]/p"));
        }
        public IWebElement DiscountHistoryStatus01()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row deal-history-combined-row')] //p[contains(@class,'status-icon invoice-status-icon')])[1]"));
        }
        public IWebElement DiscountHistoryAmount01()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row deal-history-combined-row')] //p)[2]"));
        }
        public IWebElement DiscountHistoryCreatedDate01()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row deal-history-combined-row')] //p)[3]"));
        }
        public IWebElement DiscountHistoryExpiryDate01()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row deal-history-combined-row')] //label)[1]"));
        }
        public IWebElement DiscountHistoryComment01()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row deal-history-combined-row')] //p)[4]"));
        }
        public IWebElement DiscountHistoryStatus02()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row deal-history-combined-row')] [2] //p[contains(@class,'status-icon invoice-status-icon')])[1]"));
        }
        public IWebElement DiscountHistoryAmount02()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row deal-history-combined-row')] [2] //p)[2]"));
        }
        public IWebElement DiscountHistoryCreatedDate02()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row deal-history-combined-row')] [2] //p)[3]"));
        }

        public IWebElement DiscountHistoryExpiryDate02()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row deal-history-combined-row')] [2] //label)[1]"));
        }
        public IWebElement DiscountHistoryComment02()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row deal-history-combined-row')] [2] //p)[4]"));
        }
        public IWebElement DiscountHistoryStatus03()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row deal-history-combined-row')] [3] //p[contains(@class,'status-icon invoice-status-icon')])[1]"));
        }
        public IWebElement DiscountHistoryAmount03()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row deal-history-combined-row')] [3] //p)[2]"));
        }
        public IWebElement DiscountHistoryCreatedDate03()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row deal-history-combined-row')] [3] //p)[3]"));
        }
        public IWebElement DiscountHistoryExpiryDate03()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row deal-history-combined-row')] [3] //label)[1]"));
        }
        public IWebElement DiscountHistoryComment03()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row deal-history-combined-row')] [3] //p)[4]"));
        }
        public IWebElement DiscountHistoryStatus04()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row deal-history-combined-row')] [4] //p[contains(@class,'status-icon invoice-status-icon')])[1]"));
        }
        public IWebElement DiscountHistoryAmount04()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row deal-history-combined-row')] [4] //p)[2]"));
        }
        public IWebElement DiscountHistoryCreatedDate04()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row deal-history-combined-row')] [4] //p)[3]"));
        }
        public IWebElement DiscountHistoryExpiryDate04()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row deal-history-combined-row')] [4] //label)[1]"));
        }
        public IWebElement DiscountHistoryComment04()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row deal-history-combined-row')] [4] //p)[4]"));
        }
        public IWebElement DiscountHistoryStatus05()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row deal-history-combined-row')] [5] //p[contains(@class,'status-icon invoice-status-icon')])[1]"));
        }
        public IWebElement DiscountHistoryAmount05path()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row deal-history-combined-row')] [5] //p)[2]"));
        }
        public IWebElement DiscountHistoryCreatedDate05path()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row deal-history-combined-row')] [5] //p)[3]"));
        }
        public IWebElement DiscountHistoryExpiryDate05path()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row deal-history-combined-row')] [5] //label)[1]"));
        }
        public IWebElement DiscountHistoryComment05xpath()
        {
            return webDriver.FindElement(By.XPath("(//div[contains(@class,'row deal-history-combined-row')] [5] //p)[4]"));
        }
        public IWebElement DeleteInvoiceMessageModal()
        {
            return webDriver.FindElement(By.Id("delete-comments"));
        }
        public IWebElement InvoiceDetailsDateDeleted()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[3]/div[3]/div/div[1]/div[3]/div[4]"));
        }
        public IWebElement DeletedMessage()
        {
            return webDriver.FindElement(By.Id("deleted-invoice-details-panel"));
        }
        public IWebElement WhoDeletedInfo()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"pay-panel-deleted\"]/div[1]/div"));
        }
        public IWebElement BillzyCashPanel()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"billzy-cash-div\"]"));
        }
        public IWebElement RequestBillzyCashBTN()
        {
            return webDriver.FindElement(By.XPath("//div[@id = 'billzy-cash-div'] //*[@id=\"request-billzy-cash-btn\"]"));
        }
        public IWebElement SIVRequestBillzyCashBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"request-billzy-cash-btn\"]"));
        }
        public IWebElement GetPaidNowAmountSIV()
        {
            return webDriver.FindElement(By.XPath("//div[@id = 'active-billzy-cash'] //span[@class = 'billzy-cash-upfront']"));
        }
        public IWebElement GetPaidLaterAmountSIV()
        {
            return webDriver.FindElement(By.XPath("//div[@id = 'active-billzy-cash'] //span[@class = 'billzy-cash-later']"));
        }
        public IWebElement TermsAndConditions()
        {
            return webDriver.FindElement(By.XPath("//div[@id = 'active-billzy-cash'] //b[text() = 'Terms and Conditions']"));
        }
        public IWebElement HTMLLink()
        {
            return webDriver.FindElement(By.XPath("//div[@id = 'active-billzy-cash'] //a[contains(@href,'/legal')]"));
        }
        public IWebElement TermsAndConditionsTextBox()
        {
            return webDriver.FindElement(By.XPath("/div[@id = 'active-billzy-cash'] //div[contains(@class, 'billzy-cash-terms-panel')]"));
        }
        public IWebElement BillzyCashStatusBTN()
        {
            return webDriver.FindElement(By.XPath("//div[@id = 'active-billzy-cash'] //p[contains(@class, 'billzy-status-icon')]"));
        }
        public IWebElement BillzyCashIcon()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"active-billzy-cash\"]/div[1]/div[1]"));
        }
        public IWebElement PayerVerifyBTN()
        {
            return webDriver.FindElement(By.Id("invoice-verify-btn"));
        }
        public IWebElement VerifiedStatusIcon()
        {
            return webDriver.FindElement(By.XPath("//p[contains(@class, 'verified-status-icon')]"));
        }
        public IWebElement BillzyInboxIcon()
        {
            return webDriver.FindElement(By.Id("inbox-icon"));
        }
        public IWebElement VerifiedMsgBillerSIV()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"pay-panel-deal-or-biller\"]/div/div[4]/div[2]"));
        }

        public IWebElement VerifiedMsgstatus()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[3]/div[3]/div/div[1]/div[3]/div[1]/p[2]"));
        }
        //*[@id="wrapper"]/div[4]/div[3]/div[3]/div/div[1]/div[3]/div[1]/p[2]
        public IWebElement RequestBillzyDealBTN()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"biller-new-deal-btn\"]/span[1]/strong"));
        }
        ////*[@id="cash-status-icon"]/div/p
        //*[@id="wrapper"]/div[4]/div[3]/div[3]/div/div[1]/div[3]/div[1]/p[1]
        public IWebElement PaidStatus()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[3]/div[3]/div/div[1]/div[3]/div[1]/p[1]"));
        }
        ////*[@id="request-billzycash-modal"]/div/div/div[2]/div[3]/div[2]/button
        public IWebElement BillzycashCancel()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"request-billzycash-modal\"]/div/div/div[2]/div[3]/div[2]/button"));
        }
        //
        public IWebElement SIVInvStatus()
        { 
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[3]/div[3]/div/div[1]/div[3]/div[1]/p[2]"));
        }
        public IWebElement SIVGrid()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[3]/div[3]/div"));
        }
        
        public IWebElement SIVPDFIcon()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"pdf-invoice\"]/img"));
        }
        public IWebElement SIVCashIcon()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"request-billzy-cash\"]/div/label"));
        }
        public IWebElement SIVDEALIcon()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"no-active-deal\"]/div/label"));
        }
        
        
        public IWebElement SIVCashPanel()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"billzy-cash-div\"]"));
        }
        public IWebElement SIVDEALPanel()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"active-deal-div\"]"));
        }
        public IWebElement InvNumber()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[4]/div[3]/div[3]/div/div[1]/div[2]/p[2]"));
        }
        public IWebElement Deleteerrmsg()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"delete-invoice-modal\"]/div/div/div/div/div[3]/div"));
        }

        public IWebElement DeleteModalTitle()
        {
            return webDriver.FindElement(By.XPath("//div[@class = 'modal-body'] //div[text()='Delete Invoice']"));
        }

        public IWebElement DeleteInvoiceMessage()
        {
            return webDriver.FindElement(By.XPath("//div[@class = 'modal-body'] //div[@class = 'page-subtitle']"));
        }

        public IWebElement DeleteComments()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"delete-comments\"]"));
        }
        

        public IWebElement BoboMarkaspaid()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"pay-panel-paid\"]/div[1]/div[1]"));
        }
        public IWebElement CashBannedImg()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"billzy-cash-disabled-popup\"]/span"));
        }

        public IWebElement DealBannedImg()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"billzy-deal-disabled-popup\"]"));
        }
        public IWebElement DealBannedInfoIcon()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"billzy-deal-disabled-popup-info-icon\"]"));
        }
        public IWebElement CashBannedInfoIcon()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"billzy-cash-disabled-popup-info-icon\"]"));
        }

        public IWebElement Download()
        {
            return webDriver.FindElement(By.XPath("//*[@id=\"icon\"]"));
        }

    }
}

