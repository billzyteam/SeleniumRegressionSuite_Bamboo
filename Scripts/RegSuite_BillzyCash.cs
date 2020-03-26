using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using BillzyAutomationTestSuite;
using BillzyAutomationTestSuite.PageObjects;
using BillzyAutomationTestSuite.Scripts;
using OpenQA.Selenium.Interactions;

namespace BillzyAutomationTestSuite.Scripts
{
    [TestFixture]
    [Parallelizable]
    class RegSuite_BillzyCash : Tests

    {
       [Test]
        public void BillzyCash01_IssueInvoice_ListViews_REQUESTED()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try { 
            //###Login to biller account
            WebDriver.Manage().Window.Maximize();
            WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
            LoginPage loginPage = new LoginPage(WebDriver);
            loginPage.UserNameTextBox().Click();
            loginPage.UserNameTextBox().SendKeys("madcowtesting10+cash01biller@gmail.com");
            loginPage.PasswordTextBox().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            loginPage.PasswordTextBox().SendKeys("Cognito1");
            loginPage.RememberMeCheckBox().Click();
            loginPage.LoginButton().Click();
            SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
            SeleniumSetMethods.WaitOnPage(secdelay8);
            IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
            //### Validte the cash invoice creation for external users
            IssueInvoicePg.IssueInvoiceButton().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            IssueInvoicePg.BusinessName().Click();
            IssueInvoicePg.BusinessName().SendKeys("External1");
            IssueInvoicePg.SelectBusiness().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            IssueInvoicePg.PaymentTerms().SendKeys("90 days");
            SeleniumSetMethods.WaitOnPage(secdelay2);
            //Scenario 1 : Verify Billzy Deal Disabled for External payer
            IssueInvoicePg.CreateInvoice().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            IssueInvoicePg.BillzyDealBTN().Click();
            String DealClass = IssueInvoicePg.BillzyDealBTN().GetAttribute("class");
            SeleniumSetMethods.WaitOnPage(secdelay4);
            //HomePage HomePg = new HomePage(WebDriver);
            Assert.IsTrue(DealClass.Contains("billzy-deal-unselected"));
            Console.WriteLine("Scenario1: Billzy Deal Disabled");
            IssueInvoicePg.BillzyCashBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            bool BillzyCashIcon = IssueInvoicePg.BillzyCashIcon().Displayed;
            bool GetPaidNowLabel = IssueInvoicePg.GetPaidNowLabel().Displayed;
            bool GetPaidNowAmount = IssueInvoicePg.GetPaidNowAmount().Displayed;
            bool GetPaidLaterLabel = IssueInvoicePg.GetPaidLaterLabel().Displayed;
            bool GetPaidLaterAmount = IssueInvoicePg.GetPaidLaterAmount().Displayed;
            bool TermAndConditionLabel = IssueInvoicePg.TermAndConditionLabel().Displayed;
            bool TCLink = IssueInvoicePg.TCLink().Displayed;
            bool AcceptTCBTN = IssueInvoicePg.AcceptTCBTN().Displayed;
            SeleniumSetMethods.WaitOnPage(secdelay3);
            Assert.IsTrue((BillzyCashIcon == true) && (GetPaidNowLabel == true) && (BillzyCashIcon == true) && (GetPaidNowAmount == true) && (GetPaidLaterLabel == true) && (GetPaidLaterAmount == true) && (TermAndConditionLabel == true) && (TCLink == true) && (AcceptTCBTN == true));
            Console.WriteLine("Scenario1: Billzy Cash Enabled");
            SeleniumSetMethods.WaitOnPage(secdelay3);
            HomePg.Profile().Click();
            //Scenario 2 : Verify Billzy Deal and Cash Button enabled for Internal payer
            SeleniumSetMethods.WaitOnPage(secdelay2);
            IssueInvoicePg.IssueInvoiceButton().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            IssueInvoicePg.BusinessName().Click();
            IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+cash01payer");
            IssueInvoicePg.SelectBusiness().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            IssueInvoicePg.PaymentTerms().SendKeys("90 days");
            SeleniumSetMethods.WaitOnPage(secdelay2);
            //Verify Billzy Deal Button Disabled for External payer
            IssueInvoicePg.CreateInvoice().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            Random rand2 = new Random();
            DateTime dt2 = new DateTime();
            string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
            int randnumber2 = rand2.Next();
            IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV@CASH" + randnumber2);
            SeleniumSetMethods.WaitOnPage(secdelay2);
            IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
            SeleniumSetMethods.WaitOnPage(secdelay2);
            IssueInvoicePg.LineItemAmount().SendKeys("500.50");
            SeleniumSetMethods.WaitOnPage(secdelay1);
            IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer excluding GST");
            SeleniumSetMethods.WaitOnPage(secdelay2);
            String TotalIncGST = IssueInvoicePg.TotalInclGST().Text;
            Assert.IsTrue(TotalIncGST.Contains("550.55"));         
            Console.WriteLine("Scenario 2 : Total Amount Includes GST");       
            SeleniumSetMethods.WaitOnPage(secdelay1);
            String BillzyDealBTNStatus = IssueInvoicePg.BillzyDealBTN().GetAttribute("src");
            bool Dealtemplate = IssueInvoicePg.BillzyDealIcon().Displayed;
            Console.WriteLine(Dealtemplate);
            Assert.IsTrue((Dealtemplate == false) && BillzyDealBTNStatus.Contains("billzy-logo-deal-greyed.png"));           
            SeleniumSetMethods.WaitOnPage(secdelay3);
            IssueInvoicePg.BillzyDealBTN().Click();            
            String BillzyDealBTNStatus1 = IssueInvoicePg.BillzyDealSelectedBTN().GetAttribute("src");
            bool Dealtemplate1 = IssueInvoicePg.BillzyDealIcon().Displayed;
            Console.WriteLine(Dealtemplate1);
            SeleniumSetMethods.WaitOnPage(secdelay5);
            Assert.IsTrue((Dealtemplate1 == true) && BillzyDealBTNStatus1.Contains("billzy-logo-deal-ticked.png"));           
            String DealClass1 = IssueInvoicePg.BillzyDealBTN().GetAttribute("class");
            SeleniumSetMethods.WaitOnPage(secdelay2);
            Assert.IsTrue(DealClass1.Contains("billzy-deal-unselected hide"));        
            Console.WriteLine("Scenario2: Billzy Deal Enabled");
            bool NewTotal = IssueInvoicePg.NewTotal().Displayed;
            bool OfferExpiry = IssueInvoicePg.OfferExpiry().Displayed;
            bool Comments = IssueInvoicePg.Comments().Displayed;
            SeleniumSetMethods.WaitOnPage(secdelay2);
            Assert.IsTrue((NewTotal == true) && (OfferExpiry == true) && (Comments == true));
            Console.WriteLine("Scenario2: Billzy Deal Icons Present");
            SeleniumSetMethods.WaitOnPage(secdelay3);
            String BillzyCashBTNStatus = IssueInvoicePg.BillzyCashBTN().GetAttribute("src");
            bool Cashtemplate = IssueInvoicePg.BillzyCashIcon().Displayed;
            Console.WriteLine(Cashtemplate);
            SeleniumSetMethods.WaitOnPage(secdelay2);
            Assert.IsTrue((Cashtemplate == false) && BillzyCashBTNStatus.Contains("billzy-logo-cash-greyed.png"));
            IssueInvoicePg.BillzyCashBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            String DealClass2 = IssueInvoicePg.BillzyDealBTN().GetAttribute("class");
            Console.WriteLine("Billzycashiconstatus" + DealClass2);
            SeleniumSetMethods.WaitOnPage(secdelay2);
            Assert.IsTrue(DealClass2.Contains("billzy-deal-unselected"));
            Console.WriteLine("Billzy Deal Removed");
            SeleniumSetMethods.WaitOnPage(secdelay2);
            IssueInvoicePg.RemovedBillzyCashBTN().Click();
            IssueInvoicePg.Outside().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            bool GetPaidNowLabelForremovecashbutton = IssueInvoicePg.GetPaidNowLabel().Displayed;
            Assert.IsTrue(GetPaidNowLabelForremovecashbutton == false);
            IssueInvoicePg.BillzyDealBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            IssueInvoicePg.RemovedBillzyDealBTN().Click();
            IssueInvoicePg.Outside().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            bool OfferExpiresCheckForremovedealbutton = IssueInvoicePg.OfferExpiresCheck().Displayed;
            Assert.IsTrue(OfferExpiresCheckForremovedealbutton == false);
            SeleniumSetMethods.WaitOnPage(secdelay2);
            IssueInvoicePg.BillzyCashBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            String BillzyCashBTNStatus1 = IssueInvoicePg.BillzyCashSelectedBTN().GetAttribute("src");
            bool Cashtemplate1 = IssueInvoicePg.BillzyCashIcon().Displayed;
            SeleniumSetMethods.WaitOnPage(secdelay2);
            Assert.IsTrue((Cashtemplate1 == true) && BillzyCashBTNStatus1.Contains("billzy-logo-cash-ticked.png"));
            SeleniumSetMethods.WaitOnPage(secdelay2);
            String BillzyCashAmount = IssueInvoicePg.BillzyCashAmount().Text;
            String BillzyPayLater = IssueInvoicePg.GetPaidLaterAmount().Text;
            Assert.IsTrue(BillzyCashAmount.Contains("440.44") && BillzyPayLater.Contains("See below"));
            Console.WriteLine("Scenario 2 : Billzy Cash with 80% is : 440.44");
            bool BillzyCashIcon0 = IssueInvoicePg.BillzyCashIcon().Displayed;
            bool GetPaidNowLabel0 = IssueInvoicePg.GetPaidNowLabel().Displayed;
            bool GetPaidNowAmount0 = IssueInvoicePg.GetPaidNowAmount().Displayed;
            bool GetPaidLaterLabel0 = IssueInvoicePg.GetPaidLaterLabel().Displayed;
            bool GetPaidLaterAmount0 = IssueInvoicePg.GetPaidLaterAmount().Displayed;
            bool TermAndConditionLabel0 = IssueInvoicePg.TermAndConditionLabel().Displayed;
            bool TCLink0 = IssueInvoicePg.TCLink().Displayed;
            bool AcceptTCBTN0 = IssueInvoicePg.AcceptTCBTN().Displayed;
            String Cashpercentmsg = IssueInvoicePg.Cashpercentmsg().Text;
            String feemsg = IssueInvoicePg.Feemsg().Text;
            String BillzyCashTerms = IssueInvoicePg.BillzyCashTerms().Text;
            SeleniumSetMethods.WaitOnPage(secdelay2);
            Assert.IsTrue(Cashpercentmsg.Contains("80% of the total invoice amount") && feemsg.Contains("The Retention Fund less Facility Fee, Acceptance Fee and any Credit Card Fees.") && BillzyCashTerms.Contains("By selecting Confirm, you offer to sell the invoice to Billzy. If this invoice is accepted by Billzy, you acknowledge that the Facility Fee is payable and may be deducted from the Retention Fund. The balance of the Retention Fund will be paid to you when the invoice is paid by the Customer. You acknowledge and agree that this transaction is governed by the Billzy Cash Facility Agreement that you have signed including the Billzy Cash Terms and Conditions (as varied from time to time)") && (BillzyCashIcon0 == true) && (GetPaidNowLabel0 == true) && (BillzyCashIcon0 == true) && (GetPaidNowAmount0 == true) && (GetPaidLaterLabel0 == true) && (GetPaidLaterAmount0 == true) && (TermAndConditionLabel0 == true) && (TCLink0 == true) && (AcceptTCBTN0 == true));
            Console.WriteLine("Scenario2: Billzy Cash Icons Present");
            SeleniumSetMethods.WaitOnPage(secdelay3);
            SeleniumSetMethods.WaitOnPage(secdelay2);
            IssueInvoicePg.LineItemAmount().Click();
            SeleniumSetMethods.WaitOnPage(secdelay3);
            IssueInvoicePg.LineItemAmount().Clear();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            IssueInvoicePg.LineItemAmount().SendKeys("267.50");
            SeleniumSetMethods.WaitOnPage(secdelay2);
            IssueInvoicePg.Outside().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            String TotalIncGST2 = IssueInvoicePg.TotalInclGST().Text;
            Assert.IsTrue(TotalIncGST2.Contains("294.25"));
            Console.WriteLine("Scenario 2 : Total Amount Includes GST");
            String BillzyCashAmount1 = IssueInvoicePg.BillzyCashAmount().Text;
            String BillzyPayLater1 = IssueInvoicePg.GetPaidLaterAmount().Text;
            Assert.IsTrue(BillzyCashAmount1.Contains("235.40") && BillzyPayLater1.Contains("See below"));
            Console.WriteLine("Scenario 2 : Billzy Cash with 80% is : 235.40");
            SeleniumSetMethods.WaitOnPage(secdelay3);
            IssueInvoicePg.TCLink().Click();
            SeleniumSetMethods.WaitOnPage(secdelay3);
            var tabs = WebDriver.WindowHandles;
            if (tabs.Count > 1)
            {
            WebDriver.SwitchTo().Window(tabs[1]);
            WebDriver.Close();
            WebDriver.SwitchTo().Window(tabs[0]);
            }
            SeleniumSetMethods.WaitOnPage(secdelay2);
            IssueInvoicePg.Outside().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            IssueInvoicePg.BillzyCashSelectedBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay4);
            bool Cashtemplate2 = IssueInvoicePg.BillzyCashIcon().Displayed;
            Console.WriteLine(Cashtemplate2);
            Assert.IsTrue(Cashtemplate2 == false);
            Console.WriteLine("Scenario2: Billzy Cash Removed");
            HomePg.Profile().Click();
            //Scenario 3: 'Verify the error message – The BillzyCash terms and conditions must be accepted'
            SeleniumSetMethods.WaitOnPage(secdelay2);
            IssueInvoicePg.IssueInvoiceButton().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            IssueInvoicePg.BusinessName().Click();
            IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+cash01payer");
            IssueInvoicePg.SelectBusiness().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            IssueInvoicePg.PaymentTerms().SendKeys("90 days");
            SeleniumSetMethods.WaitOnPage(secdelay2);
            //Verify Billzy Deal Button Disabled for External payer
            IssueInvoicePg.CreateInvoice().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            Random rand3 = new Random();
            DateTime dt3 = new DateTime();
            string dtString3 = dt3.ToString("MM/dd/yyyy HH:mm:ss");
            int randnumber3 = rand3.Next();
            IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV@CASH" + randnumber3);
            SeleniumSetMethods.WaitOnPage(secdelay2);
            IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
            SeleniumSetMethods.WaitOnPage(secdelay2);
            IssueInvoicePg.LineItemAmount().SendKeys("1204.09");
            SeleniumSetMethods.WaitOnPage(secdelay1);
            IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer excluding GST");
            SeleniumSetMethods.WaitOnPage(secdelay2);
            String duedate = IssueInvoicePg.DueDate().Text;
            Console.WriteLine("DueDate" + duedate);
            String TotalIncGST3 = IssueInvoicePg.TotalInclGST().Text;
            SeleniumSetMethods.WaitOnPage(secdelay2);
            Assert.IsTrue(TotalIncGST3.Contains("1,324.50"));
            Console.WriteLine("Scenario 2 : Total Amount Includes GST");
            SeleniumSetMethods.WaitOnPage(secdelay2);
            IssueInvoicePg.BillzyCashBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            IssueInvoicePg.SendInvoiceBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay5);
            String Err1 = IssueInvoicePg.ErrorMsg().Text;
            Console.WriteLine("Error" + Err1);
            SeleniumSetMethods.WaitOnPage(secdelay3);
            Assert.IsTrue(Err1.Contains("The billzyCash terms and conditions must be accepted."));
            IssueInvoicePg.AcceptTCBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay4);
            IssueInvoicePg.SurchargeCheckbox().Click();
            SeleniumSetMethods.WaitOnPage(secdelay4);
            IssueInvoicePg.SendInvoiceBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay7);
            //### Validate the List view of generated invoice
            HomePg.SentBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            SendPage SendPg = new SendPage(WebDriver);
            SendPg.SentOutstandingBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            SendPg.SearchInvoiceSent().SendKeys("INV@CASH" + randnumber3);
            SeleniumSetMethods.WaitOnPage(secdelay2);
            String SearchedInvoiceCashStatus = SendPg.SearchedInvoiceCashStatus().Text;
            String toRow01 = SendPg.ToRow01().Text;
            String billzyInvoiceNumRow01 = SendPg.BillzyInvoiceNumRow01().Text;
            String dueRow01 = SendPg.DueRow01().Text;
            String AmountRow1 = SendPg.AmountRow1().Text;
            bool BillzyColumnCashIcon = SendPg.BillzyColumnCashIcon().Displayed;
            DateTime duedate1 = DateTime.Today.AddDays(90);
            string SentPgDueDate = duedate1.ToString("dd MMM yy");
            SeleniumSetMethods.WaitOnPage(secdelay3);
            Assert.IsTrue(SearchedInvoiceCashStatus.Contains("Cash requested") && toRow01.Contains("madcowtesting10+cas...") && billzyInvoiceNumRow01.Contains("INV@CASH" + randnumber3) && dueRow01.Contains(SentPgDueDate) && AmountRow1.Contains("1,324.50") && (BillzyColumnCashIcon == true));
            SendPg.ActionsMenu().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            String PDFInvoiceOption = SendPg.PDFInvoice().Text;
            String DeleteOption1 = SendPg.DeleteOption().Text;
            bool CashOption = SendPg.BillzyCashOption().Displayed;
            bool DealOption = SendPg.BillzyDealOption().Displayed;
            SeleniumSetMethods.WaitOnPage(secdelay3);
            SIVPage SIVPg = new SIVPage(WebDriver);
            Assert.IsTrue(PDFInvoiceOption.Contains("PDF Invoice") && DeleteOption1.Contains("Delete") && (CashOption == false) && (DealOption == false));
            //### Verify the SIV page 
            SendPg.BillzyRefResult().Click();
            SeleniumSetMethods.WaitOnPage(secdelay4);
            bool Cashpanel = SIVPg.BillzyCashPanel().Displayed;
            bool billerOfferADiscountBTN = SIVPg.BillerOfferADiscountBTN().Displayed;
            bool getPaidNowAmountSIV = SIVPg.GetPaidNowAmountSIV().Displayed;
            bool getPaidLaterAmountSIV = SIVPg.GetPaidLaterAmountSIV().Displayed;
            bool termsAndConditions = SIVPg.TermsAndConditions().Displayed;
            bool HTMLLink = SIVPg.HTMLLink().Displayed;
            bool billzyCashStatusBTN = SIVPg.BillzyCashStatusBTN().Displayed;
            bool requestBillzyCashBTN = SIVPg.RequestBillzyCashBTN().Displayed;
            String SIVCashRequestedStatus = SIVPg.SIVCashRequestedStatus().Text;
            bool billzyCashIcon = SIVPg.BillzyCashIcon().Displayed;
            SeleniumSetMethods.WaitOnPage(secdelay3);
            Assert.IsTrue((Cashpanel == true) && (billerOfferADiscountBTN == false) && (getPaidNowAmountSIV == true) && (getPaidLaterAmountSIV == true) && (termsAndConditions == true) && (HTMLLink == true) && (billzyCashStatusBTN == true) && (requestBillzyCashBTN == false) && (billzyCashIcon == true) && SIVCashRequestedStatus.Contains("PENDING PAYER VERIFICATION"));
            Console.WriteLine("SIVPage Verified");
            HomePg.SentBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            // SendPg.SentOutstandingBTN().Click();
            // SeleniumSetMethods.WaitOnPage(secdelay2);
            //### Verify the cash and deal filter options
            SendPg.BillzyCashFilterCheckBox().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            SendPg.SearchInvoiceSent().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            SendPg.SearchInvoiceSent().Clear();
            SendPg.SearchInvoiceSent().SendKeys("");
            String SearchedInvoiceCashStatus1 = SendPg.SearchedInvoiceCashStatus().Text;
            Assert.IsTrue(SearchedInvoiceCashStatus1.Contains("Cash"));
            SendPg.BillzyDealFilterCheckBox().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            SendPg.BillzyCashFilterUncheckBox().Click();
            SeleniumSetMethods.WaitOnPage(secdelay5);
            //String SearchedInvoicedealStatus = SendPg.SearchedInvoiceCashStatus().Text;
               
            // Assert.IsTrue(SearchedInvoicedealStatus.Contains("Offer"));
            SendPg.BillzyDealFilterUncheckBox().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            HomePg.SignOutBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay5);
            //### sign into the payer account
            loginPage.UserNameTextBox().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            loginPage.UserNameTextBox().Clear();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            loginPage.UserNameTextBox().SendKeys("madcowtesting10+cash01Payer@gmail.com");
            loginPage.PasswordTextBox().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            loginPage.PasswordTextBox().SendKeys("Cognito1");
            loginPage.RememberMeCheckBox().Click();
            loginPage.LoginButton().Click();
            SeleniumSetMethods.WaitOnPage(secdelay8);
            HomePg.ReceivedBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay3);
            ReceivedPage RecPg = new ReceivedPage(WebDriver);
            // RecPg.ToPayTab().Click();
            //SeleniumSetMethods.WaitOnPage(secdelay3);
            RecPg.SearchInvoiceReceived().SendKeys("INV@CASH" + randnumber3);
            //RecPg.SearchInvoiceReceived().SendKeys("INV@CASH1756170729");
            SeleniumSetMethods.WaitOnPage(secdelay5);
            ////### verify the action menu options
            RecPg.ActionsMenu().Click();
            bool verifyInvoice = RecPg.VerifyInvoice().Displayed;
            bool pay = RecPg.PAY().Displayed;
            bool PostInvoice = RecPg.PostInvoice().Displayed;
            bool PDFInvoice = RecPg.PDFInvoice().Displayed;
            bool DeleteOption = RecPg.DeleteOption().Displayed;
            bool BillzyDealOption = RecPg.BillzyDealOption().Displayed;
            SeleniumSetMethods.WaitOnPage(secdelay3);
            SIVPage SIVPG1 = new SIVPage(WebDriver);
            Assert.IsTrue((BillzyDealOption == false) && (verifyInvoice == true) && (pay == true) && (PostInvoice == true) && (PDFInvoice == true) && (DeleteOption == true));
            RecPg.PAY().Click();
            SeleniumSetMethods.WaitOnPage(secdelay3);
            PayNowPage PayPg = new PayNowPage(WebDriver);
            PayPg.CancelBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay3);
            //RecPg.SearchInvoiceReceived().SendKeys("INV@CASH1756170729");
            RecPg.SearchInvoiceReceived().SendKeys("INV@CASH" + randnumber3);
            SeleniumSetMethods.WaitOnPage(secdelay3);
            String BusinesSName = RecPg.FromRow01().Text;
            String billzyInvoiceNumRow02 = RecPg.BillzyInvoiceNumRow01().Text;
            String dueRow02 = RecPg.DueRow01().Text;
            String AmountRow2 = RecPg.AmountViewedRow1().Text;
            //### Verify the list view in the payer account recieved tab
            SeleniumSetMethods.WaitOnPage(secdelay3);
            Assert.IsTrue(BusinesSName.Contains("madcowtesting10+cas...") && billzyInvoiceNumRow02.Contains("INV@CASH" + randnumber3) && dueRow02.Contains(SentPgDueDate) && AmountRow2.Contains("1,324.50"));
            //  if (BusinesSName.Contains("madcowtesting10+cas...") && billzyInvoiceNumRow02.Contains("INV@CASH1756170729") && dueRow02.Contains(SentPgDueDate) && AmountRow2.Contains("1,324.50"))
            RecPg.ActionsMenu().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            //### Verify the SIV view on the payer account
            RecPg.VerifyInvoice().Click();
            SeleniumSetMethods.WaitOnPage(secdelay3);
            String InvoiceStatus = SIVPG1.InvoiceStatus().Text;
            bool billzyCashPanel1 = SIVPG1.BillzyCashPanel().Displayed;
            bool payerOfferEarlyPaymentBTN = SIVPG1.PayerOfferEarlyPaymentBTN().Displayed;
            bool getPaidNowAmountSIV0 = SIVPG1.GetPaidNowAmountSIV().Displayed;
            bool getPaidLaterAmountSIV0 = SIVPG1.GetPaidLaterAmountSIV().Displayed;
            bool termsAndConditions0 = SIVPG1.TermsAndConditions().Displayed;
            bool HTMLLink0 = SIVPG1.HTMLLink().Displayed;
            //bool termsAndConditionsTextBox = SIVPG1.TermsAndConditionsTextBox().Displayed;
            bool billzyCashStatusBTN0 = SIVPG1.BillzyCashStatusBTN().Displayed;
            SeleniumSetMethods.WaitOnPage(secdelay3);
            Assert.IsTrue(InvoiceStatus.Contains("UNPAID") && (billzyCashPanel1 == false) && (payerOfferEarlyPaymentBTN == false) && (getPaidNowAmountSIV0 == false) && (termsAndConditions0 == false) && (HTMLLink0 == false) && (billzyCashStatusBTN0 == false));
            SIVPG1.ActionDropdown().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            bool actionDropdownDelete = SIVPG1.ActionDropdownDelete().Displayed;
            bool PayerVerifyBTN = SIVPG1.PayerVerifyBTN().Displayed;
            string VerifyText = SIVPG1.VerifyTextMsg().Text;
            SeleniumSetMethods.WaitOnPage(secdelay2);
            Assert.IsTrue((actionDropdownDelete == true) && (PayerVerifyBTN == true) && VerifyText.Contains("By selecting Verify you confirm that the supply of goods or services relevant to this invoice has been completed to your satisfaction and that you intend to pay the invoice amount."));
            //### Verify the invoice
            SIVPG1.PayerVerifyBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay3);
            string VerifiedTextMsg = SIVPG1.VerifiedTextMsg().Text;
            Assert.IsTrue(VerifiedTextMsg.Contains("You verified this invoice on"));
            SIVPG1.ReturnBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay3);
            string CashStausText = RecPg.BillzyRow1().Text;
            Assert.IsTrue(CashStausText.Contains(""));
            RecPg.ActionsMenu().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            bool verifyInvoice1 = RecPg.VerifyInvoice().Displayed;
            Assert.IsTrue(verifyInvoice1 == false);
            Console.WriteLine("Invoice Verified");
            HomePg.SignOutBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            //### sign in to the biller account
            loginPage.UserNameTextBox().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            loginPage.UserNameTextBox().Clear();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            loginPage.UserNameTextBox().SendKeys("madcowtesting10+cash01biller@gmail.com");
            loginPage.PasswordTextBox().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            loginPage.PasswordTextBox().SendKeys("Cognito1");
            loginPage.RememberMeCheckBox().Click();
            loginPage.LoginButton().Click();
            SeleniumSetMethods.WaitOnPage(secdelay8);
            HomePg.SentBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            SendPg.SearchInvoiceSent().SendKeys("INV@CASH" + randnumber3);
            SeleniumSetMethods.WaitOnPage(secdelay3);
            SendPg.BillzyRefResult().Click();
            SeleniumSetMethods.WaitOnPage(secdelay3);
            String SIVCashRequestedStatus2 = SIVPG1.SIVCashRequestedStatus().Text;
            String VerifiedMsgBillerSIV = SIVPG1.VerifiedMsgBillerSIV().Text;
            SeleniumSetMethods.WaitOnPage(secdelay3);
            Assert.IsTrue(SIVCashRequestedStatus2.Contains("PENDING APPROVAL") && VerifiedMsgBillerSIV.Contains("madcowtesting10+cash01payer verified this invoice on "));
            SeleniumSetMethods.WaitOnPage(secdelay2);
            SIVPG1.ReturnBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();

            }
            finally
            {
                
            }
        }
        [Test]
        public void BillzyCash02_CreatedinSIV()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try { 

            WebDriver.Manage().Window.Maximize();
            WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
            LoginPage loginPage = new LoginPage(WebDriver);
             loginPage.UserNameTextBox().Click();
             SeleniumSetMethods.WaitOnPage(secdelay2);
             loginPage.UserNameTextBox().Clear();
             SeleniumSetMethods.WaitOnPage(secdelay2);
            loginPage.UserNameTextBox().SendKeys("madcowtesting10+cash02biller@gmail.com");
            loginPage.PasswordTextBox().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            loginPage.PasswordTextBox().SendKeys("Cognito1");
            loginPage.RememberMeCheckBox().Click();
            loginPage.LoginButton().Click();
            SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
            SeleniumSetMethods.WaitOnPage(secdelay7);
            IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
            IssueInvoicePg.IssueInvoiceButton().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            IssueInvoicePg.BusinessName().Click();
            IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+cash02payer");
            IssueInvoicePg.SelectBusiness().Click();
            SeleniumSetMethods.WaitOnPage(secdelay1);
            //Generate two random numbers for unique customer details and invoice
            Random rand = new Random();
            DateTime dt = new DateTime();
            string dtString = dt.ToString("MM/dd/yyyy HH:mm:ss");
            int randnumber1 = rand.Next();
            Random rand2 = new Random();
            DateTime dt2 = new DateTime();
            string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
            int randnumber2 = rand.Next();
            SeleniumSetMethods.WaitOnPage(secdelay3);
            String PaymentTerms = "90 days";
            IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
            IssueInvoicePg.CreateInvoice().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV@" + randnumber2);
            IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
            IssueInvoicePg.LineItemAmount().SendKeys("1500.00");
            IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
            IssueInvoicePg.SurchargeCheckbox().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            //issueInvoice_issueInvoicePage_totalValue.checkValueContains = @amountGst
            IssueInvoicePg.SendInvoiceBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            Console.WriteLine("InvoiceCreated");
            //HomePage HomePg = new HomePage(WebDriver);
            HomePg.SentBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            SendPage SendPg = new SendPage(WebDriver);
            SendPg.SentOutstandingBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            SendPg.SearchInvoiceSent().SendKeys("INV@" + randnumber2);
            SeleniumSetMethods.WaitOnPage(secdelay2);
            SendPg.ActionsMenu().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            SendPg.BillzyCashOption().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            SIVPage SIVPG1 = new SIVPage(WebDriver);
            String SIVCashRequestedStatus2 = SIVPG1.SIVCashRequestedStatus().Text;
            DeleteInvoicePage DeleteInvPg = new DeleteInvoicePage(WebDriver);
            BillzyCashModal BillzyCashMlPg = new BillzyCashModal(WebDriver);
            string BillzyCashBTNStatus = SIVPG1.RequestBillzyCashBTN().Text;
            string BillzyDealBTNStatus = SIVPG1.RequestBillzyDealBTN().Text;
            SeleniumSetMethods.WaitOnPage(secdelay2);
            Assert.IsTrue(BillzyCashBTNStatus.Contains("REQUEST CASH") && BillzyDealBTNStatus.Contains("OFFER A DISCOUNT"));
            SIVPG1.ReturnBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            SendPg.ActionsMenu().Click();
            SendPg.BillzyDealOption().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            SIVPG1.ActionDropdown().Click();
            bool Delete = SIVPG1.ActionDropdownDelete().Displayed;
            bool MarkasPaid = SIVPG1.ActionDropdownMarkAsPaid().Displayed;
            SeleniumSetMethods.WaitOnPage(secdelay2);
            Assert.IsTrue((Delete == true) && (MarkasPaid == true));
            SIVPG1.ReturnBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            SendPg.ActionsMenu().Click();
            SeleniumSetMethods.WaitOnPage(secdelay1);
            SendPg.MarkAsPaidOption().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            SIVPG1.ReturnBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            string billzycolumnstatus = SendPg.BillzyRow1().Text;
            Assert.IsTrue(billzycolumnstatus.Contains(""));
            SendPg.ActionsMenu().Click();
            SeleniumSetMethods.WaitOnPage(secdelay1);
            SendPg.DeleteOption().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            DeleteInvPg.CancelBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            SendPg.ActionsMenu().Click();
            SeleniumSetMethods.WaitOnPage(secdelay1);
            SendPg.BillzyCashOption().Click();
            SeleniumSetMethods.WaitOnPage(secdelay5);
            SIVPG1.RequestBillzyCashBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay3);
            bool getPaidLaterLabel = BillzyCashMlPg.GetPaidLaterLabel().Displayed;
            String getPaidLaterAmount = BillzyCashMlPg.GetPaidLaterAmount().Text;
            string Getamount = BillzyCashMlPg.GetPaidNowAmount().Text;
            bool termsAndConditions = BillzyCashMlPg.TermsAndConditions().Displayed;
            bool HTMLLink = BillzyCashMlPg.HTMLLink().Displayed;
            bool billzyCashNoBTN = BillzyCashMlPg.BillzyCashNoBTN().Displayed;
            bool billzyCashConfirmBTN = BillzyCashMlPg.BillzyCashConfirmBTN().Displayed;
            String BillzyCashTerms = BillzyCashMlPg.BillzyCashTerms().Text;
            String BillzyCash80percentMsg = BillzyCashMlPg.BillzyCash80percentMsg().Text;
            String BillzyCashRetentionMsg = BillzyCashMlPg.BillzyCashRetentionMsg().Text;
            SeleniumSetMethods.WaitOnPage(secdelay2);
            Assert.IsTrue((getPaidLaterLabel == true) && Getamount.Contains("1,320.00") && getPaidLaterAmount.Contains("See below…") && (termsAndConditions == true) && (HTMLLink == true) && (billzyCashNoBTN == true) && BillzyCashTerms.Contains("By selecting Confirm, you offer to sell the invoice to Billzy. If this invoice is accepted by Billzy, you acknowledge that the Facility Fee is payable and may be deducted from the Retention Fund. The balance of the Retention Fund will be paid to you when the invoice is paid by the Customer. You acknowledge and agree that this transaction is governed by the Billzy Cash Facility Agreement that you have signed including the Billzy Cash Terms and Conditions (as varied from time to time)."));
            SIVPG1.BillzycashCancel().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            HomePg.SignOutBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            //### sign in to the Payer account
            loginPage.UserNameTextBox().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            loginPage.UserNameTextBox().Clear();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            loginPage.UserNameTextBox().SendKeys("madcowtesting10+cash02Payer@gmail.com");
            loginPage.PasswordTextBox().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            loginPage.PasswordTextBox().SendKeys("Cognito1");
            loginPage.RememberMeCheckBox().Click();
            loginPage.LoginButton().Click();
            SeleniumSetMethods.WaitOnPage(secdelay8);
            HomePg.ReceivedBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay3);
            ReceivedPage RecPg = new ReceivedPage(WebDriver);
            // RecPg.ToPayTab().Click();
            //SeleniumSetMethods.WaitOnPage(secdelay3);
            RecPg.SearchInvoiceReceived().SendKeys("INV@" + randnumber2);
            //RecPg.SearchInvoiceReceived().SendKeys("INV@CASH1756170729");
            SeleniumSetMethods.WaitOnPage(secdelay5);
            RecPg.ActionsMenu().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            RecPg.BillzyDealOption().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            SIVPG1.ActionDropdown().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            SIVPG1.ActionDropdownDelete().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            DeleteInvPg.CancelBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            bool BillzyCashPanel = SIVPG1.BillzyCashPanel().Displayed;
            SeleniumSetMethods.WaitOnPage(secdelay2);
            Assert.IsTrue(BillzyCashPanel == false);
            SIVPG1.ReturnBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            HomePg.SignOutBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            loginPage.UserNameTextBox().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            //Biller Login
            loginPage.UserNameTextBox().Clear();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            loginPage.UserNameTextBox().SendKeys("madcowtesting10+cash02biller@gmail.com");
            loginPage.PasswordTextBox().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            loginPage.PasswordTextBox().SendKeys("Cognito1");
            loginPage.RememberMeCheckBox().Click();
            loginPage.LoginButton().Click();
            SeleniumSetMethods.WaitOnPage(secdelay8);
            HomePg.SentBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            SendPg.SearchInvoiceSent().SendKeys("INV@" + randnumber2);
            SeleniumSetMethods.WaitOnPage(secdelay3);
            SendPg.BillzyRefResult().Click();
            SeleniumSetMethods.WaitOnPage(secdelay3);
            SIVPG1.RequestBillzyCashBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            BillzyCashMlPg.BillzyCashConfirmBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay10);
            SIVPG1.ReturnBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);        
            HomePg.SentBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            SendPg.SearchInvoiceSent().SendKeys("INV@" + randnumber2);
            SeleniumSetMethods.WaitOnPage(secdelay3);
            String CashstatusBillzycolumn = SendPg.BillzyRow1().Text;
            bool CashIconBillzycolumn = SendPg.CashRequestedIcon().Displayed;
            SeleniumSetMethods.WaitOnPage(secdelay2);
            Assert.IsTrue(CashstatusBillzycolumn.Contains("Cash requested") && (CashIconBillzycolumn == true));
            HomePg.SignOutBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            //### sign in to the Payer account
            loginPage.UserNameTextBox().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            loginPage.UserNameTextBox().Clear();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            loginPage.UserNameTextBox().SendKeys("madcowtesting10+cash02Payer@gmail.com");
            loginPage.PasswordTextBox().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            loginPage.PasswordTextBox().SendKeys("Cognito1");
            loginPage.RememberMeCheckBox().Click();
            loginPage.LoginButton().Click();
            SeleniumSetMethods.WaitOnPage(secdelay8);
            HomePg.ReceivedBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay3);
            RecPg.SearchInvoiceReceived().SendKeys("INV@" + randnumber2);
            SeleniumSetMethods.WaitOnPage(secdelay3);
            RecPg.SearchedFirstRowDetailsLink().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            SIVPG1.PayerVerifyBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            SIVPG1.ReturnBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay3);
            RecPg.SearchInvoiceReceived().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            RecPg.SearchInvoiceReceived().Clear();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            RecPg.SearchInvoiceReceived().SendKeys("INV@" + randnumber2);
            SeleniumSetMethods.WaitOnPage(secdelay5);
            RecPg.ActionsMenu().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            RecPg.PAY().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            //Proceed to payment
            PayNowPage PNPg = new PayNowPage(WebDriver);
            PNPg.CcDropDown().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            PNPg.CardRow01().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            PNPg.ConfirmPaymentBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            PNPg.DoneBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            HomePg.ReceivedBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            RecPg.ReceivedHistoryBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay7);
            RecPg.SearchInvoiceReceived().SendKeys("INV@" + randnumber2);
            SeleniumSetMethods.WaitOnPage(secdelay7);
            RecPg.ActionsMenu().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            bool PDFInvoice = RecPg.PDFInvoice().Displayed;
            bool DeleteOption1 = RecPg.DeleteOption().Displayed;
            bool VerifyInvoice = RecPg.VerifyInvoice().Displayed;
            bool PAY = RecPg.PAY().Displayed;
            bool DealOption = RecPg.BillzyDealOption().Displayed;
            SeleniumSetMethods.WaitOnPage(secdelay2);
            Assert.IsTrue((PDFInvoice == true) && (DeleteOption1 == false) && (DeleteOption1 == false) && (VerifyInvoice == false) && (PAY == false) && (DealOption == false));
            RecPg.SearchedFirstRowDetailsLink().Click();
            SeleniumSetMethods.WaitOnPage(secdelay3);
            string PaidStatus = SIVPG1.PaidStatus().Text;
            SeleniumSetMethods.WaitOnPage(secdelay2);
            Assert.IsTrue(PaidStatus.Contains("PAID"));
            SIVPG1.ReturnBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
                //HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();
            }
            finally
            {
                
            }
        }

        [Test]
        public void BillzyCash03_IssueInvoice_ListViews_APPROVED()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try { 

           WebDriver.Manage().Window.Maximize();
           WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
            LoginPage loginPage = new LoginPage(WebDriver);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowbillergst@gmail.com");
            loginPage.PasswordTextBox().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            loginPage.PasswordTextBox().SendKeys("Cognito1");
            loginPage.LoginButton().Click();
            SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
            SeleniumSetMethods.WaitOnPage(secdelay7);
            IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
            
            SendPage SendPg = new SendPage(WebDriver);
            ReceivedPage Recpg = new ReceivedPage(WebDriver);
            BillzyCashModal BillzyCashMlPg = new BillzyCashModal(WebDriver);
            SIVPage SIVPG1 = new SIVPage(WebDriver);
            HomePg.SentBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            SendPg.SearchInvoiceSent().SendKeys("billzyCashApproved");
            SeleniumSetMethods.WaitOnPage(secdelay7);
            SendPg.ActionsMenu().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            bool Cashoption = SendPg.BillzyCashOption().Displayed;
            bool markAsPaidOption = SendPg.MarkAsPaidOption().Displayed;
            bool PDFInvoice2 = SendPg.PDFInvoice2().Displayed;
            bool deleteoption1 = SendPg.DeleteOption().Displayed;
            bool dealoption = SendPg.BillzyDealOption().Displayed;
            SeleniumSetMethods.WaitOnPage(secdelay3);
            Assert.IsTrue(Cashoption == false && markAsPaidOption == false && PDFInvoice2 == true && deleteoption1 == false && dealoption == false);
            SendPg.BillzyRefResult().Click();
            SeleniumSetMethods.WaitOnPage(secdelay5);
            String Cashstatus = SIVPG1.BillzyCashStatusBTN().Text;
            String SIVINVStatus = SIVPG1.SIVInvStatus().Text;
            SeleniumSetMethods.WaitOnPage(secdelay2);
            Assert.IsTrue(Cashstatus.Contains("APPROVED") && SIVINVStatus.Contains("VERIFIED"));
            SIVPG1.ReturnBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay3);
            string SendpgCashstatus = SendPg.SearchedInvoiceCashStatus().Text;
            bool cashicon = SendPg.CashApprovedIcon().Displayed;
            String amount = SendPg.AmountViewedRow1().Text;
            SeleniumSetMethods.WaitOnPage(secdelay2);
            Assert.IsTrue(SendpgCashstatus.Contains("Cash approved") && (cashicon == true) && amount.Contains("1,324.50"));
            SendPg.ActionsMenu().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            bool PDFInvoice = SendPg.PDFInvoice().Displayed;
            bool BillzyDeal = SendPg.BillzyDealOption().Displayed;
            bool MarkasPaid = SendPg.MarkAsPaidOption().Displayed;
            SeleniumSetMethods.WaitOnPage(secdelay2);
            Assert.IsTrue((PDFInvoice == true) && (BillzyDeal == false) && (MarkasPaid == false));
            SendPg.SentHistoryBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            SendPg.SearchInvoiceSent().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            SendPg.SearchInvoiceSent().Clear();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            SendPg.SearchInvoiceSent().SendKeys("BCApp-Verified");
            SeleniumSetMethods.WaitOnPage(secdelay4);
            String status1 = SendPg.StatusProcessingRow().GetAttribute("data-title");
            string cashstatus = SendPg.BillzyRow1().Text;
            bool cashiconstatus = SendPg.CashPaidIcon().Displayed;
            SeleniumSetMethods.WaitOnPage(secdelay2);
            Assert.IsTrue(status1.Contains("paid") && cashstatus.Contains("Cash paid") && cashiconstatus == true);
            SendPg.ActionsMenu().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            bool pdfinvoice = SendPg.PDFInvoice().Displayed;
            Assert.IsTrue(pdfinvoice == true);
            HomePg.SignOutBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            //### sign in to the Payer account
            loginPage.UserNameTextBox().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            loginPage.UserNameTextBox().SendKeys("madcowpayergst@gmail.com");
            loginPage.PasswordTextBox().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            loginPage.PasswordTextBox().SendKeys("Cognito1");         
            loginPage.LoginButton().Click();
            SeleniumSetMethods.WaitOnPage(secdelay8);
            HomePg.ReceivedBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay3);           
            Recpg.SearchInvoiceReceived().SendKeys("billzyCashApproved");
            SeleniumSetMethods.WaitOnPage(secdelay3);    
            String businessname = Recpg.FromRow01().Text;
            String due = Recpg.DueRow01().Text;
            String amountviewed = Recpg.AmountViewedRow1().Text;
            SeleniumSetMethods.WaitOnPage(secdelay2);
            Assert.IsTrue(businessname.Contains("billergst01") && due.Contains("03 May 20") && amountviewed.Contains("1,324.50"));
            Recpg.BillzyRefResult().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            String InvStatus = SIVPG1.InvoiceStatus().Text;
            bool cashbuttonenabled = SIVPG1.RequestBillzyCashBTN().Displayed;
            bool Cashpanel = SIVPG1.BillzyCashPanel().Displayed;
            bool HTMLLinkenabled = SIVPG1.HTMLLink().Displayed;
            string verifiedmsg = SIVPG1.VerifiedTextMsg().Text;
            SeleniumSetMethods.WaitOnPage(secdelay5);
            Assert.IsTrue(InvStatus.Contains("UNPAID") && cashbuttonenabled == false && Cashpanel == false && HTMLLinkenabled == false && verifiedmsg.Contains("You verified this invoice on 6th August 2019 at 2:44 am"));
            SIVPG1.ReturnBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            Recpg.ActionsMenu().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            bool verifyinvoice = Recpg.VerifyInvoice().Displayed;
            bool Pay = Recpg.PAY().Displayed;
            bool PostInvoice = Recpg.PostInvoice().Displayed;
            bool PDFInvoice1 = Recpg.PDFInvoice().Displayed;
            bool deleteoption = Recpg.DeleteOption().Displayed;
            bool dealoption2 = Recpg.BillzyDealOption().Displayed;
            SeleniumSetMethods.WaitOnPage(secdelay2);
            Assert.IsTrue(verifyinvoice == false && Pay == true && PostInvoice == true && PDFInvoice1 == true && deleteoption == false && dealoption2 == false);
            HomePg.ReceivedBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            Recpg.ReceivedHistoryBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            Recpg.SearchInvoiceReceived().SendKeys("BCApp-NVerified");
            SeleniumSetMethods.WaitOnPage(secdelay4);
            //string status = Recpg.StatusProcessingRow().GetAttribute("data-title");
            String billzycolumn = Recpg.BillzyRow1().Text;
            SeleniumSetMethods.WaitOnPage(secdelay2);
                //Assert.IsTrue(status.Contains("paid") && billzycolumn.Contains(""));
                Assert.IsTrue(billzycolumn.Contains(""));
                Recpg.ActionsMenu().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            bool pdfinvoice1 = Recpg.PDFInvoice().Displayed;
            Assert.IsTrue(pdfinvoice1 == true);
            SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();

            }
            finally
            {
                
            }
        }

        [Test]
        public void BillzyCash04_IssueInvoice_ListViews_DECLINED()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try { 
           WebDriver.Manage().Window.Maximize();
           WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
            LoginPage loginPage = new LoginPage(WebDriver);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowbillergst@gmail.com");
            loginPage.PasswordTextBox().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            loginPage.PasswordTextBox().SendKeys("Cognito1");
            loginPage.LoginButton().Click();
            SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
            SeleniumSetMethods.WaitOnPage(secdelay7);
            IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
           // HomePage HomePg = new HomePage(WebDriver);
            SendPage SendPg = new SendPage(WebDriver);
            ReceivedPage Recpg = new ReceivedPage(WebDriver);
            BillzyCashModal BillzyCashMlPg = new BillzyCashModal(WebDriver);
            SIVPage SIVPG1 = new SIVPage(WebDriver);
            HomePg.SentBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            SendPg.SearchInvoiceSent().SendKeys("billzyCashDeclined");
            SeleniumSetMethods.WaitOnPage(secdelay7);
            string amount = SendPg.AmountViewedRow1().Text;
            string dueRow01 = SendPg.DueRow01().Text;
            string toRow01 = SendPg.ToRow01().Text;
            bool statusViewedRow01 = SendPg.StatusViewedRow01().Displayed;
            SeleniumSetMethods.WaitOnPage(secdelay2);
            Assert.IsTrue(amount.Contains("1,324.50") && dueRow01.Contains("03 May 20") && toRow01.Contains("Australian Skin Cl") && statusViewedRow01 == true);
            SendPg.ActionsMenu().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            bool markAsPaidOption = SendPg.MarkAsPaidOption().Displayed;
            bool PDFInvoice2 = SendPg.PDFInvoice2().Displayed;
            bool deleteoption1 = SendPg.DeleteOption().Displayed;
            bool dealoption = SendPg.BillzyDealOption().Displayed;
            Console.WriteLine("markAsPaidOption" + markAsPaidOption);
            Console.WriteLine("PDFInvoice2" + PDFInvoice2);
            Console.WriteLine("deleteoption1" + deleteoption1);
            Console.WriteLine("dealoption" + dealoption);
            SeleniumSetMethods.WaitOnPage(secdelay3);
            Assert.IsTrue(markAsPaidOption == true && PDFInvoice2 == true && deleteoption1 == true && dealoption == true);
            SendPg.BillzyRefResult().Click();
            SeleniumSetMethods.WaitOnPage(secdelay3);
            String Cashstatus = SIVPG1.BillzyCashStatusBTN().Text;
            String SIVINVStatus = SIVPG1.SIVInvStatus().Text;
            Console.WriteLine("Cashstatus" + Cashstatus);
            Console.WriteLine("SIVINVStatus" + SIVINVStatus);
            SeleniumSetMethods.WaitOnPage(secdelay2);
            Assert.IsTrue(Cashstatus.Contains("DECLINED") && SIVINVStatus.Contains("VERIFIED"));
            SIVPG1.ReturnBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay3);
            string SendpgCashstatus = SendPg.SearchedInvoiceCashStatus().Text;
            bool cashicon = SendPg.CashDeclinedIcon().Displayed;
            String amount2 = SendPg.AmountViewedRow1().Text;
            Console.WriteLine("SendpgCashstatus" + SendpgCashstatus);
            Console.WriteLine("cashicon" + cashicon);
            Console.WriteLine("amount2" + amount2);
            SeleniumSetMethods.WaitOnPage(secdelay2);
            Assert.IsTrue(SendpgCashstatus.Contains("Cash declined") && (cashicon == true) && amount2.Contains("1,324.50"));
            SendPg.BillzyRefResult().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            string BillzyDealBTNStatus = SIVPG1.RequestBillzyDealBTN().Text;
            bool requestBillzyCashBTN = SIVPG1.RequestBillzyCashBTN().Displayed;
            Console.WriteLine("BillzyDealBTNStatus" + BillzyDealBTNStatus);
            Console.WriteLine("requestBillzyCashBTN" + requestBillzyCashBTN);
            SeleniumSetMethods.WaitOnPage(secdelay2);
            Assert.IsTrue(BillzyDealBTNStatus.Contains("OFFER A DISCOUNT") && requestBillzyCashBTN == false);
            SIVPG1.ReturnBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            HomePg.SignOutBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            loginPage.UserNameTextBox().Click();
            loginPage.UserNameTextBox().SendKeys("madcowpayergst@gmail.com");
            loginPage.PasswordTextBox().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            loginPage.PasswordTextBox().SendKeys("Cognito1");
            loginPage.LoginButton().Click();
            SeleniumSetMethods.WaitOnPage(secdelay8);
            HomePg.ReceivedBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay3);
            Recpg.SearchInvoiceReceived().SendKeys("billzyCashDeclined");
            SeleniumSetMethods.WaitOnPage(secdelay3);
            String businessname = Recpg.FromRow01().Text;
            String due = Recpg.DueRow01().Text;
            String amountviewed = Recpg.AmountViewedRow1().Text;
            SeleniumSetMethods.WaitOnPage(secdelay2);
            Assert.IsTrue(businessname.Contains("billergst01") && due.Contains("03 May 20") && amountviewed.Contains("1,324.50"));
            Recpg.BillzyRefResult().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            String InvStatus = SIVPG1.InvoiceStatus().Text;
            bool cashbuttonenabled = SIVPG1.RequestBillzyCashBTN().Displayed;
            bool Cashpanel = SIVPG1.BillzyCashPanel().Displayed;
            bool HTMLLinkenabled = SIVPG1.HTMLLink().Displayed;
            string verifiedmsg = SIVPG1.VerifiedTextMsg().Text;
            string offerearlypaymentstatus = SIVPG1.OfferEarlyPaymentModalBTN().Text;
            SeleniumSetMethods.WaitOnPage(secdelay5);
            Assert.IsTrue(offerearlypaymentstatus.Contains("OFFER EARLY PAYMENT") && InvStatus.Contains("UNPAID") && cashbuttonenabled == false && Cashpanel == false && HTMLLinkenabled == false && verifiedmsg.Contains("You verified this invoice on 6th August 2019 at 2:40 am"));
            SIVPG1.ReturnBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            Recpg.ActionsMenu().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            bool verifyinvoice = Recpg.VerifyInvoice().Displayed;
            bool Pay = Recpg.PAY().Displayed;
            bool PostInvoice = Recpg.PostInvoice().Displayed;
            bool PDFInvoice1 = Recpg.PDFInvoice().Displayed;
            bool deleteoption = Recpg.DeleteOption().Displayed;
            bool dealoption2 = Recpg.BillzyDealOption().Displayed;
            SeleniumSetMethods.WaitOnPage(secdelay2);
            SeleniumSetMethods.WaitOnPage(secdelay2);
            Assert.IsTrue(verifyinvoice == false && Pay == true && PostInvoice == true && PDFInvoice1 == true && deleteoption == true && dealoption2 == true);
            HomePg.ReceivedBTN().Click();
                // HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();
               
            }
            finally
            {
                
            }
        }

        [Test]
        public void BillzyCash05_IssueInvoice_ListViews_REQUESTED_ExternalClient()
        {
            
            HomePage HomePg = new HomePage(WebDriver);
            try {
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+cash03biller@gmail.com");
            loginPage.PasswordTextBox().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            loginPage.PasswordTextBox().SendKeys("Cognito1");
            SeleniumSetMethods.WaitOnPage(secdelay2);
            loginPage.LoginButton().Click();
            SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
           // HomePage HomePg = new HomePage(WebDriver);
            SendPage SendPg = new SendPage(WebDriver);
            SeleniumSetMethods.WaitOnPage(secdelay8);
            IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
            //### Validte the cash invoice creation for external users
            IssueInvoicePg.IssueInvoiceButton().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            IssueInvoicePg.BusinessName().Click();
            IssueInvoicePg.BusinessName().SendKeys("External1");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.SelectBusiness().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            IssueInvoicePg.PaymentTerms().SendKeys("90 days");
            SeleniumSetMethods.WaitOnPage(secdelay2);
            //Scenario 1 : Verify Billzy Deal and Cash Button Disabled for External payer
            IssueInvoicePg.CreateInvoice().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            Random rand2 = new Random();
            DateTime dt2 = new DateTime();
            string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
            int randnumber2 = rand2.Next();
            IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV@CASH" + randnumber2);
            SeleniumSetMethods.WaitOnPage(secdelay2);
            IssueInvoicePg.Description().SendKeys("Test Invoice issued to External Payer");
            SeleniumSetMethods.WaitOnPage(secdelay2);
            IssueInvoicePg.LineItemAmount().SendKeys("500.50");
            SeleniumSetMethods.WaitOnPage(secdelay1);
            IssueInvoicePg.Message().SendKeys("Test invoice has been sent to external payer excluding GST");
            SeleniumSetMethods.WaitOnPage(secdelay2);
            String TotalIncGST = IssueInvoicePg.TotalInclGST().Text;
            SeleniumSetMethods.WaitOnPage(secdelay2);
            Assert.IsTrue(TotalIncGST.Contains("550.55"));
            IssueInvoicePg.BillzyCashBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            bool BillzyCashIcon = IssueInvoicePg.BillzyCashIcon().Displayed;
            bool GetPaidNowLabel = IssueInvoicePg.GetPaidNowLabel().Displayed;
            string GetPaidNowAmount = IssueInvoicePg.GetPaidNowAmount().Text;
            bool GetPaidLaterLabel = IssueInvoicePg.GetPaidLaterLabel().Displayed;
            bool GetPaidLaterAmount = IssueInvoicePg.GetPaidLaterAmount().Displayed;
            bool TermAndConditionLabel = IssueInvoicePg.TermAndConditionLabel().Displayed;
            bool TCLink = IssueInvoicePg.TCLink().Displayed;
            bool AcceptTCBTN = IssueInvoicePg.AcceptTCBTN().Displayed;
            SeleniumSetMethods.WaitOnPage(secdelay3);
            Assert.IsTrue((BillzyCashIcon == true) && (GetPaidNowLabel == true) && (BillzyCashIcon == true) && (GetPaidNowAmount.Contains("440.44")) && (GetPaidLaterLabel == true) && (GetPaidLaterAmount == true) && (TermAndConditionLabel == true) && (TCLink == true) && (AcceptTCBTN == true));
            IssueInvoicePg.AcceptTCBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay4);
            IssueInvoicePg.SurchargeCheckbox().Click();
            SeleniumSetMethods.WaitOnPage(secdelay4);
            IssueInvoicePg.SendInvoiceBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay7);
            HomePg.SentBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            SendPg.SearchInvoiceSent().SendKeys("INV@CASH" + randnumber2);
            SeleniumSetMethods.WaitOnPage(secdelay7);
            SendPg.ActionsMenu().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            bool PDFInvoice = SendPg.PDFInvoice().Displayed;
            bool Delete = SendPg.DeleteOption().Displayed;
            SeleniumSetMethods.WaitOnPage(secdelay2);
            Assert.IsTrue(PDFInvoice == true && Delete == true);
            SeleniumSetMethods.WaitOnPage(secdelay2);
            string billzycolumnstatus = SendPg.SearchedInvoiceCashStatus().Text;
            bool billzycolumnIcon = SendPg.BillzyColumnCashIcon().Displayed;
            SeleniumSetMethods.WaitOnPage(secdelay2);
            Assert.IsTrue(billzycolumnstatus.Contains("Cash requested") && billzycolumnIcon == true);
                //HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();
            }
            finally
            {
               
            }
        }

        [Test]
        public void BillzyCash06_createdInSIV_ExternalClient()
        {
           
            HomePage HomePg = new HomePage(WebDriver);
            try
            {
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+cash03biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SendPage SendPg = new SendPage(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay8);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                //### Validte the cash invoice creation for external users
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("External1");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.PaymentTerms().SendKeys("90 days");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //Scenario 1 : Verify Billzy Deal and Cash Button Disabled for External payer
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Random rand2 = new Random();
                DateTime dt2 = new DateTime();
                string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber2 = rand2.Next();
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INV@CASH" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to External Payer");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.LineItemAmount().SendKeys("500.50");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to external payer excluding GST");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                String TotalIncGST = IssueInvoicePg.TotalInclGST().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INV@CASH" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SendPg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool PDFInvoice = SendPg.PDFInvoice().Displayed;
                bool Delete = SendPg.DeleteOption().Displayed;
                bool BillzyCashOption = SendPg.BillzyCashOption().Displayed;
                bool MarkAsPaidOption = SendPg.MarkAsPaidOption().Displayed;
                bool BillzyDealOption = SendPg.BillzyDealOption().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(PDFInvoice == true && Delete == true && BillzyCashOption == true && MarkAsPaidOption == true && BillzyDealOption == false);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyCashOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPage SIVPg = new SIVPage(WebDriver);
                BillzyCashModal BillzyCashMlPg = new BillzyCashModal(WebDriver);
                SIVPg.RequestBillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                BillzyCashMlPg.BillzyCashConfirmBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SIVPg.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string billzycolumnstatus = SendPg.SearchedInvoiceCashStatus().Text;
                bool billzycolumnIcon = SendPg.BillzyColumnCashIcon().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(billzycolumnstatus.Contains("Cash requested") && billzycolumnIcon == true);
                //HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();
            }
            finally
            {
                
            }
        }

        [Test]
        public void BillzyCash07_External_IssueInvoice_ListViews_APPROVED()
        {
           
            HomePage HomePg = new HomePage(WebDriver);
            try
            {
                WebDriver.Manage().Window.Maximize();
               WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowbillergst@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                //HomePage HomePg = new HomePage(WebDriver);
                SendPage SendPg = new SendPage(WebDriver);
                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                BillzyCashModal BillzyCashMlPg = new BillzyCashModal(WebDriver);
                SIVPage SIVPG1 = new SIVPage(WebDriver);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("Ext_CashApproved");
                SeleniumSetMethods.WaitOnPage(secdelay7);
                string amount = SendPg.AmountViewedRow1().Text;
                string dueRow01 = SendPg.DueRow01().Text;
                string toRow01 = SendPg.ToRow01().Text;
                string StatusViewed = SendPg.StatusViewed().GetAttribute("data-title");
                string billzyRow1 = SendPg.BillzyRow1().Text;
                bool cashicon = SendPg.CashApprovedIcon().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(amount.Contains("1,324.50") && dueRow01.Contains("01 Jan 23") && toRow01.Contains("External Client") && StatusViewed.Contains("not viewed") && billzyRow1.Contains("Cash approved") && cashicon == true);
                SendPg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool markAsPaidOption = SendPg.MarkAsPaidOption().Displayed;
                bool PDFInvoice2 = SendPg.PDFInvoice2().Displayed;
                bool deleteoption1 = SendPg.DeleteOption().Displayed;
                bool dealoption = SendPg.BillzyDealOption().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(markAsPaidOption == false && PDFInvoice2 == true && deleteoption1 == false && dealoption == false);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                bool verfiymessage = SIVPG1.VerifiedMsgBillerSIV().Displayed;
                bool billserofferdiscountbutton = SIVPG1.BillerOfferADiscountBTN().Displayed;
                bool cashpanel = SIVPG1.BillzyCashPanel().Displayed;
                bool cashbutton = SIVPG1.RequestBillzyCashBTN().Displayed;
                string cashstatus = SIVPG1.SIVCashRequestedStatus().Text;
                Assert.IsTrue(verfiymessage == false && billserofferdiscountbutton == false && cashpanel == true && cashbutton == false && cashstatus.Contains("APPROVED"));
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();

            }
            finally
            {
                
            }

        }

        [Test]
        public void BillzyCash08_External_IssueInvoice_ListViews_DECLINED()
        {

            HomePage HomePg = new HomePage(WebDriver);
            try
            { 
           WebDriver.Manage().Window.Maximize();
            WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
            LoginPage loginPage = new LoginPage(WebDriver);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowbillergst@gmail.com");
            loginPage.PasswordTextBox().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            loginPage.PasswordTextBox().SendKeys("Cognito1");
            SeleniumSetMethods.WaitOnPage(secdelay2);
            loginPage.LoginButton().Click();
            SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
            SeleniumSetMethods.WaitOnPage(secdelay7);
            IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
            
            SendPage SendPg = new SendPage(WebDriver);
            ReceivedPage Recpg = new ReceivedPage(WebDriver);
            BillzyCashModal BillzyCashMlPg = new BillzyCashModal(WebDriver);
            SIVPage SIVPG1 = new SIVPage(WebDriver);
            HomePg.SentBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            SendPg.SearchInvoiceSent().SendKeys("ext_CashDeclined");
            SeleniumSetMethods.WaitOnPage(secdelay7);
            string amount = SendPg.AmountViewedRow1().Text;
            string dueRow01 = SendPg.DueRow01().Text;
            string toRow01 = SendPg.ToRow01().Text;
            string StatusViewed = SendPg.StatusViewed().GetAttribute("data-title");
            string billzyRow1 = SendPg.BillzyRow1().Text;
            bool cashicon = SendPg.CashDeclinedIcon().Displayed;
            SeleniumSetMethods.WaitOnPage(secdelay2);
            Assert.IsTrue(amount.Contains("1,324.50") && dueRow01.Contains("01 Jan 23") && toRow01.Contains("External Client") && StatusViewed.Contains("not viewed") && billzyRow1.Contains("Cash declined") && cashicon == true);
            SendPg.ActionsMenu().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
            bool markAsPaidOption = SendPg.MarkAsPaidOption().Displayed;
            bool PDFInvoice2 = SendPg.PDFInvoice2().Displayed;
            bool deleteoption1 = SendPg.DeleteOption().Displayed;
            bool dealoption = SendPg.BillzyDealOption().Displayed;
            SeleniumSetMethods.WaitOnPage(secdelay3);
            Assert.IsTrue(markAsPaidOption == true && PDFInvoice2 == true && deleteoption1 == true && dealoption == false);
            SendPg.BillzyRefResult().Click();
            SeleniumSetMethods.WaitOnPage(secdelay3);
            bool verfiymessage = SIVPG1.VerifiedMsgBillerSIV().Displayed;
            bool billserofferdiscountbutton = SIVPG1.BillerOfferADiscountBTN().Displayed;
            bool cashpanel = SIVPG1.BillzyCashPanel().Displayed;
            bool cashbutton = SIVPG1.RequestBillzyCashBTN().Displayed;
            string cashstatus = SIVPG1.SIVCashRequestedStatus().Text;
            SeleniumSetMethods.WaitOnPage(secdelay2);
            Assert.IsTrue(verfiymessage == false && billserofferdiscountbutton == false && cashpanel == true && cashbutton == false && cashstatus.Contains("DECLINED"));
            SIVPG1.ReturnBTN().Click();
            SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();

            }
            finally
            {
                
            }


        }

        [Test]
        public void BillzyCash09_BillzyCashFlow_APPROVED_IconLogic()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {

                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);

                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+cash02biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+cash02payer");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay1);
                //Generate two random numbers for unique customer details and invoice
                Random rand = new Random();
                DateTime dt = new DateTime();
                string dtString = dt.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber1 = rand.Next();
                Random rand2 = new Random();
                DateTime dt2 = new DateTime();
                string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber2 = rand.Next();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "90 days";
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("INVCASHRAP@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued to Internal Payer");
                IssueInvoicePg.LineItemAmount().SendKeys("1500.00");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent to internal payer");
                IssueInvoicePg.SurchargeCheckbox().Click();

                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);


                //issueInvoice_issueInvoicePage_totalValue.checkValueContains = @amountGst
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Console.WriteLine("InvoiceCreated");
                //HomePage HomePg = new HomePage(WebDriver);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPage SendPg = new SendPage(WebDriver);
                SendPg.SentOutstandingBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVCASHRAP@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool CashReqIcon = SendPg.CashRequestedIcon().Displayed;
                String CashReqTxt = SendPg.SearchedInvoiceCashStatus().Text;
                Assert.IsTrue(CashReqIcon == true && CashReqTxt.Contains("Cash requested"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SIVPage SIVPG1 = new SIVPage(WebDriver);
                string invnumber = SIVPG1.InvNumber().Text;

                string invoicenumber = invnumber.Substring(invnumber.IndexOf("Invoice ")).Replace("Invoice ", "");
                string sivcashstatus = SIVPG1.SIVCashRequestedStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(sivcashstatus.Contains("PENDING PAYER VERIFICATION"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                //string Path = @"C:\Users\BillzyAdmin\Documents\Visual Studio 2019\Projects\BillzyAutomationTestSuite\bin\Debug\netcoreapp2.1\FactorFox.csv";
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                // addrecord("INVCASH@" + 1310961952, "approved", "FactorFox.csv");
                addrecord(invoicenumber, "approved", "FactorFox.csv");
                SeleniumSetMethods.WaitOnPage(secdelay2);


                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("billzydemo+financial-controller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                string cashapprove1 = HomePg.FFApproved().Text;
                bool approvebtn1 = HomePg.Approvebtn().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(cashapprove1.Contains("Pending Approval") && approvebtn1 == true);
                SeleniumSetMethods.WaitOnPage(secdelay5);

                HomePg.Uploadfactorfox().SendKeys(@"C:\Users\Selenium\Desktop\SeleniumRegressionSuite_Bamboo\bin\Debug\netcoreapp3.1\FactorFox.csv");
                SeleniumSetMethods.WaitOnPage(secdelay7);
                IAlert alert = WebDriver.SwitchTo().Alert();
                alert.Accept();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                //string invoicenumber = "INV10309557";
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay5);

                IWebElement ApproveButton = WebDriver.FindElement(By.XPath("//td[text()=\"" + invoicenumber + "\"]/../td/button[text()=\"approve\"]"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ApproveButton.Click();
                //HomePg.Approvebtn().Click();

                SeleniumSetMethods.WaitOnPage(secdelay6);
                HomePg.Cashratesubmit().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                alert.Accept();
                HomePg.FCLogout().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+cash02biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);

                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SendPg.SentOutstandingBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVCASHRAP@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                bool CashReqIcon1 = SendPg.CashApprovedIcon().Displayed;
                String CashReqTxt1 = SendPg.SearchedInvoiceCashStatus().Text;
                Assert.IsTrue(CashReqIcon1 == true && CashReqTxt1.Contains("Cash approved"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string sivcashstatus1 = SIVPG1.SIVCashRequestedStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(sivcashstatus1.Contains("APPROVED"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();

                SeleniumSetMethods.WaitOnPage(secdelay4);


                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+cash02payer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                ReceivedPage recpg = new ReceivedPage(WebDriver);
                recpg.SearchInvoiceReceived().SendKeys("INVCASHRAP@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                recpg.PAY().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                //Proceed to payment
                PayNowPage PNPg = new PayNowPage(WebDriver);
                PNPg.CcDropDown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PNPg.CardRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PNPg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PNPg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                recpg.ReceivedHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                recpg.SearchInvoiceReceived().SendKeys("INVCASHRAP@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();

                SeleniumSetMethods.WaitOnPage(secdelay4);


                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+cash02biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SendPg.SentHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVCASHRAP@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                String status1 = SendPg.StatusProcessingRow().GetAttribute("data-title");
                string cashstatus = SendPg.BillzyRow1().Text;
                bool cashiconstatus = SendPg.CashDeclinedIcon().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(status1.Contains("paid") && cashstatus.Contains("Cash declined") && cashiconstatus == true);
                SendPg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();

               


            }
            finally
            {
               

            }

        }
        public static void addrecord(string ID, string status, string filepath)
        {
            try
            {

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filepath, true))
                {
                    file.WriteLine(ID + "," + status);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("This program not working:", ex);
            }

        }

        [Test]
        public void BillzyCash10_BillzyCashFlow_BOBORequestedDeclined_Delete()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {

                WebDriver.Manage().Window.Maximize();

                WebDriver.Navigate().GoToUrl("https://4impact-billzy-bobo-ui-uat.s3-ap-southeast-2.amazonaws.com/poc.html");
                BOBOPage Bobopg = new BOBOPage(WebDriver);
                Bobopg.Username().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.Username().SendKeys("madcowbiller+bobo_02@gmail.com");
                Bobopg.Password().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.Password().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.LoginBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                SeleniumSetMethods.WaitOnPage(secdelay10);
                string textcheck = Bobopg.UserWelcomeMessage().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(textcheck.Contains("Welcome, madcowbiller+bobo_02@gmail.com"));
                Bobopg.BillzyBiller().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Random rand2 = new Random();
                DateTime dt2 = new DateTime();
                string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber2 = rand2.Next();

                //Issue Invoice - BOBO CONNECT - Create Invoice
                //Bobopg.IssueAnInvoice().Click();
                //SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.BillzyBiller().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.IssueInvoiceOnBehalfOf().SendKeys("manualtestdemob+gstbiller");
                SeleniumSetMethods.WaitOnPage(secdelay8);
                Bobopg.IssueInvoiceTo().SendKeys("b. - manualtestdemob+gstpayer");
                SeleniumSetMethods.WaitOnPage(secdelay5);
                DateTime newDate = DateTime.Now.AddDays(60);
                string Invduedate = newDate.ToString("dd/MM/yyyy");
                string Invduedate1 = newDate.ToString("dd MMM yy");
                string Invduedate2 = newDate.ToString("dd/MM/yy");
                DateTime newDate1 = DateTime.Now;
                string Issuedate = newDate1.ToString("dd/MM/yyyy");
                // Bobopg.EmailTo().SendKeys("manualtestdemob+gstpayer@gmail.com");
                Bobopg.Reference().SendKeys("INVMTBOBOCASH@" + randnumber2);
                Bobopg.InvoiceDueDate().SendKeys(Invduedate);
                Bobopg.InvoiceIssueDate().SendKeys(Issuedate);
                Bobopg.TotalAmount().SendKeys("100.00");
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.Surcharge().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.RequestCash().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Bobopg.PdfUpload().SendKeys(@"C:\Users\Selenium\Desktop\SeleniumRegressionSuite_Bamboo\bin\Debug\netcoreapp3.1\Invoice.pdf");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.Issue().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                string message2 = Bobopg.Message().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(message2.Contains("Invoice has been created"));
                Bobopg.OKBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);

                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);

                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+gstbiller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay7);

                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPage SendPg = new SendPage(WebDriver);
                SendPg.SentOutstandingBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("INVMTBOBOCASH@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                bool CashReqIcon = SendPg.CashRequestedIcon().Displayed;
                String CashReqTxt = SendPg.SearchedInvoiceCashStatus().Text;
                Assert.IsTrue(CashReqIcon == true && CashReqTxt.Contains("Cash requested"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SIVPage SIVPG1 = new SIVPage(WebDriver);
                string invnumber = SIVPG1.InvNumber().Text;

                string invoicenumber = invnumber.Substring(invnumber.IndexOf("Invoice ")).Replace("Invoice ", "");
                string sivcashstatus = SIVPG1.SIVCashRequestedStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(sivcashstatus.Contains("PENDING PAYER VERIFICATION"));
                SeleniumSetMethods.WaitOnPage(secdelay2);

                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                SeleniumSetMethods.WaitOnPage(secdelay2);


                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("billzydemo+financial-controller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                string cashapprove1 = HomePg.FFApproved().Text;
                bool Declinebtn = HomePg.Declinebtn().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(cashapprove1.Contains("Pending Approval") && Declinebtn == true);
                SeleniumSetMethods.WaitOnPage(secdelay5);

                IWebElement DeclineButton = WebDriver.FindElement(By.XPath("//td[text()=\"" + invoicenumber + "\"]/../td/button[text()=\"decline\"]"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                DeclineButton.Click();
                //HomePg.Declinebtn().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                IAlert alert = WebDriver.SwitchTo().Alert();
                alert.Accept();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                alert.Accept();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                alert.Accept();
                SeleniumSetMethods.WaitOnPage(secdelay3);

                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.FCLogout().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+gstbiller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);

                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SendPg.SentOutstandingBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool CashDeclinedIcon = SendPg.CashDeclinedIcon().Displayed;
                String CashDeclinedTxt1 = SendPg.SearchedInvoiceCashStatus().Text;
                Assert.IsTrue(CashDeclinedIcon == true && CashDeclinedTxt1.Contains("Cash declined"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string sivcashstatus1 = SIVPG1.SIVCashRequestedStatus().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(sivcashstatus1.Contains("DECLINED"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool BillerOfferADiscountBTN = SIVPG1.BillerOfferADiscountBTN().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(BillerOfferADiscountBTN == true);
                bool delete = SIVPG1.ActionDropdownDelete().Displayed;
                bool markaspaid = SIVPG1.ActionDropdownMarkAsPaid().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(delete == true && markaspaid == true);
                HomePg.SignOutBTN().Click();

                SeleniumSetMethods.WaitOnPage(secdelay4);


                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("manualtestdemob+gstpayer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                ReceivedPage recpg = new ReceivedPage(WebDriver);
                recpg.SearchInvoiceReceived().SendKeys(invoicenumber);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                recpg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool PayerOfferEarlyPaymentBTN = SIVPG1.PayerOfferEarlyPaymentBTN().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(PayerOfferEarlyPaymentBTN == true);
                SIVPG1.ActionDropdown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool delete1 = SIVPG1.ActionDropdownDelete().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(delete1 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();

            }
            finally
            {
               

            }

        }

        [Test]
        public void BillzyCash11_DynamicCashStateChange_Scenario1_CashRequested()
        {
            HomePage HomePg = new HomePage(WebDriver);
            LoginPage loginPage = new LoginPage(WebDriver);
            BOBOPage Bobopg = new BOBOPage(WebDriver);
            try
            {

                WebDriver.Manage().Window.Maximize();

                WebDriver.Navigate().GoToUrl("https://demo.billzy.com");
                
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+cash02biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                Random rand = new Random();
                DateTime dt = new DateTime();
                string dtString = dt.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber1 = rand.Next();
                Random rand2 = new Random();
                DateTime dt2 = new DateTime();
                string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber2 = rand.Next();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "90 days";

                var invnum = new List<string> { "Scen1INVCASHREQCARD", "Scen1INVCASHREQBANK", "Scen1INVCASHREQMAP" };
                for (int i = invnum.Count - 1; i >= 0; i--)
                //for (int i = 0; i < 20; i++)
                {

                    //Internal Cash    Yes Requested   CC 01INTSURCASHREQCC@
                    SeleniumSetMethods.WaitOnPage(secdelay5);
                    IssueInvoicePg.IssueInvoiceButton().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    IssueInvoicePg.BusinessName().Click();
                    IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+cash02payer");
                    IssueInvoicePg.SelectBusiness().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                    IssueInvoicePg.CreateInvoice().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    IssueInvoicePg.InvoiceReferenceCreate().SendKeys(invnum[i] + "@" + randnumber2);
                    IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                    IssueInvoicePg.LineItemAmount().SendKeys("100");
                    IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                    SeleniumSetMethods.WaitOnPage(secdelay1);
                    IssueInvoicePg.BillzyCashBTN().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    IssueInvoicePg.AcceptTCBTN().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    IssueInvoicePg.SurchargeCheckbox().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    IssueInvoicePg.SendInvoiceBTN().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay5);

                }

                SeleniumSetMethods.WaitOnPage(secdelay5);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("External1");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("Scen1INVCASHREQEXTCARD@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPage SendPg = new SendPage(WebDriver);
                SendPg.SearchInvoiceSent().SendKeys("Scen1INVCASHREQCARD@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool CashReqIcon = SendPg.CashRequestedIcon().Displayed;
                String CashReqTxt = SendPg.SearchedInvoiceCashStatus().Text;
                Assert.IsTrue(CashReqIcon == true && CashReqTxt.Contains("Cash requested"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SIVPage SIVPG1 = new SIVPage(WebDriver);
                string invnumber1 = SIVPG1.InvNumber().Text;
                string invoicenumber1 = invnumber1.Substring(invnumber1.IndexOf("Invoice ")).Replace("Invoice ", "");
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("Scen1INVCASHREQBANK@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                String CashReqTxt1 = SendPg.SearchedInvoiceCashStatus().Text;
                Assert.IsTrue(CashReqTxt1.Contains("Cash requested"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber2 = SIVPG1.InvNumber().Text;
                string invoicenumber2 = invnumber2.Substring(invnumber2.IndexOf("Invoice ")).Replace("Invoice ", "");
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("Scen1INVCASHREQMAP@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                String CashReqTxt2 = SendPg.SearchedInvoiceCashStatus().Text;
                Assert.IsTrue(CashReqTxt2.Contains("Cash requested"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber3 = SIVPG1.InvNumber().Text;
                string invoicenumber3 = invnumber3.Substring(invnumber3.IndexOf("Invoice ")).Replace("Invoice ", "");
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("Scen1INVCASHREQEXTCARD@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                String CashReqTxt4 = SendPg.SearchedInvoiceCashStatus().Text;
                Assert.IsTrue(CashReqTxt4.Contains("Cash requested"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber4 = SIVPG1.InvNumber().Text;
                string invoicenumber4 = invnumber4.Substring(invnumber4.IndexOf("Invoice ")).Replace("Invoice ", "");
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Console.WriteLine(invoicenumber1, invoicenumber2, invoicenumber3, invoicenumber4);
                
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

               

                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+cash02payer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                
                ReceivedPage recpg = new ReceivedPage(WebDriver);
                recpg.SearchInvoiceReceived().SendKeys(invoicenumber1);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                recpg.PAY().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                //Proceed to payment
                PayNowPage PNPg = new PayNowPage(WebDriver);
                PNPg.CcDropDown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PNPg.CardRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PNPg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PNPg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                recpg.SearchInvoiceReceived().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                recpg.SearchInvoiceReceived().Clear();
                recpg.SearchInvoiceReceived().SendKeys(invoicenumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                recpg.PAY().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);           
                PNPg.CcDropDown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PNPg.CardRow03().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PNPg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PNPg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                

                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://accounts.google.com/signin/v2/identifier?service=mail&passive=true&rm=false&continue=https%3A%2F%2Fmail.google.com%2Fmail%2F&ss=1&scc=1&ltmpl=default&ltmplcache=2&emr=1&osid=1&flowName=GlifWebSignIn&flowEntry=ServiceLogin");

                GMAILPage gmailpg = new GMAILPage(WebDriver);

                DateTime duedate1 = DateTime.Today.AddDays(90);
                string SentPgDueDate = duedate1.ToString("dd MMM yyyy");
                gmailpg.Username().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Username().SendKeys("madcowtesting10@gmail.com");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.UserNext().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                gmailpg.Password().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.PasswordNext().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                gmailpg.Search().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Search().SendKeys("Scen1INVCASHREQEXTCARD@" + randnumber2);
                //gmailpg.Search().SendKeys("Scen1INVCASHREQEXTCARD@194388391");
                

                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag4 = WebDriver.FindElement(By.TagName("body"));
                bool Content42 = bodyTag4.Text.Contains("has sent you an invoice via billzy.");
                bool Content44 = bodyTag4.Text.Contains("Scen1INVCASHREQEXTCARD");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Content42 == true && Content44 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Verify().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));
                bool bpay = bodyTag.Text.Contains("The Bpay Biller Code is created via the Billzy platform, with the Biller displaying as Billzy or your Suppliers name.");
                Console.WriteLine(bodyTag);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(bpay == true);
                gmailpg.paypageverify().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                bool verifiedmsg = gmailpg.paypageverified().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(verifiedmsg == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.CardName().SendKeys("Valid");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                gmailpg.CardNumber().SendKeys("4242424242424242");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                gmailpg.Expmon().SendKeys("12");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                gmailpg.ExpYY().SendKeys("25");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                gmailpg.CVC().SendKeys("089");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                gmailpg.PAY().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                string successmsg = gmailpg.Successmsg().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(successmsg.Contains("Successful payment"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Close();
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.profile().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.signout().Click();

                
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://4impact-billzy-bobo-ui-uat.s3-ap-southeast-2.amazonaws.com/poc.html");
                Bobopg.Username().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.Username().SendKeys("madcowbiller+bobo_02@gmail.com");
                Bobopg.Password().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.Password().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.LoginBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                Bobopg.UpdateExistingBillzyInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                Bobopg.SelectBusiness().SendKeys("madcowtesting10+cash02biller");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                // invoice with Cash reqested status
                Bobopg.InputInvoice().SendKeys(invoicenumber3);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.SearchBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.MarkAsPaidEnabled().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Bobopg.MAPYes().Click();
                SeleniumSetMethods.WaitOnPage(secdelay8);
                bool Markaspaiddisabled0 = Bobopg.MarkAsPaidDisabled().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Markaspaiddisabled0 == true);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+cash02biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);

                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SendPg.SentHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SendPg.SearchInvoiceSent().SendKeys(invoicenumber1);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                bool CashDec1 = SendPg.CashDeclinedIcon().Displayed;
                String CashDecTxt1 = SendPg.SearchedInvoiceCashStatus().Text;
                Assert.IsTrue(CashDec1 == true && CashDecTxt1.Contains("Cash declined"));
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SendPg.SearchInvoiceSent().SendKeys(invoicenumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool CashDec2 = SendPg.CashDeclinedIcon().Displayed;
                String CashDecTxt2 = SendPg.SearchedInvoiceCashStatus().Text;
                Assert.IsTrue(CashDec2 == true && CashDecTxt2.Contains("Cash declined"));
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SendPg.SearchInvoiceSent().SendKeys(invoicenumber3);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool CashDec3 = SendPg.CashDeclinedIcon().Displayed;
                String CashDecTxt3 = SendPg.SearchedInvoiceCashStatus().Text;
                Assert.IsTrue(CashDec3 == true && CashDecTxt3.Contains("Cash declined"));

                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SendPg.SearchInvoiceSent().SendKeys(invoicenumber4);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool CashDec4 = SendPg.CashDeclinedIcon().Displayed;
                String CashDecTxt4 = SendPg.SearchedInvoiceCashStatus().Text;
                Assert.IsTrue(CashDec4 == true && CashDecTxt4.Contains("Cash declined"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("billzydemo+financial-controller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                string autodeclinelist = loginPage.finconautodeclinelist().Text;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(autodeclinelist.Contains(invoicenumber1) && autodeclinelist.Contains(invoicenumber2) && autodeclinelist.Contains(invoicenumber3) && autodeclinelist.Contains(invoicenumber4));
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string finconcashreqlist = loginPage.finconcashreqlist().Text;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                bool inv1 = finconcashreqlist.Contains(invoicenumber1);
                bool inv2 = finconcashreqlist.Contains(invoicenumber2);
                bool inv3 = finconcashreqlist.Contains(invoicenumber3);
                bool inv4 = finconcashreqlist.Contains(invoicenumber4);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(inv1 == false && inv2 == false && inv3 == false && inv4 == false);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.FCLogout().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

            }
            finally
            {
               

            }

        }

        [Test]
        public void BillzyCash12_DynamicCashStateChange_Scenario2_CashPreApproved()
        {
            HomePage HomePg = new HomePage(WebDriver);
            LoginPage loginPage = new LoginPage(WebDriver);
            try
            {

                WebDriver.Manage().Window.Maximize();

                WebDriver.Navigate().GoToUrl("https://demo.billzy.com");
                BOBOPage Bobopg = new BOBOPage(WebDriver);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+cash02biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
                
                Random rand = new Random();
                DateTime dt = new DateTime();
                string dtString = dt.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber1 = rand.Next();
                Random rand2 = new Random();
                DateTime dt2 = new DateTime();
                string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber2 = rand.Next();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "90 days";
                Console.WriteLine(randnumber2);

                var invnum = new List<string> { "Scen2INVCASHREQCARD", "Scen2INVCASHREQBANK", "Scen2INVCASHREQMAP" };
                for (int i = invnum.Count - 1; i >= 0; i--)
                //for (int i = 0; i < 20; i++)
                {

                    //Internal Cash    Yes Requested   CC 01INTSURCASHREQCC@
                    SeleniumSetMethods.WaitOnPage(secdelay5);
                    IssueInvoicePg.IssueInvoiceButton().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    IssueInvoicePg.BusinessName().Click();
                    IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+cash02payer");
                    IssueInvoicePg.SelectBusiness().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                    IssueInvoicePg.CreateInvoice().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    IssueInvoicePg.InvoiceReferenceCreate().SendKeys(invnum[i] + "@" + randnumber2);
                    IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                    IssueInvoicePg.LineItemAmount().SendKeys("100");
                    IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                    SeleniumSetMethods.WaitOnPage(secdelay1);
                    IssueInvoicePg.BillzyCashBTN().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    IssueInvoicePg.AcceptTCBTN().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    IssueInvoicePg.SurchargeCheckbox().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    IssueInvoicePg.SendInvoiceBTN().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay5);

                }

                SeleniumSetMethods.WaitOnPage(secdelay5);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("External1");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("Scen2INVCASHREQEXTCARD@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPage SendPg = new SendPage(WebDriver);
                SendPg.SearchInvoiceSent().SendKeys("Scen2INVCASHREQCARD@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool CashReqIcon = SendPg.CashRequestedIcon().Displayed;
                String CashReqTxt = SendPg.SearchedInvoiceCashStatus().Text;
                Assert.IsTrue(CashReqIcon == true && CashReqTxt.Contains("Cash requested"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SIVPage SIVPG1 = new SIVPage(WebDriver);
                string invnumber1 = SIVPG1.InvNumber().Text;
                string invoicenumber1 = invnumber1.Substring(invnumber1.IndexOf("Invoice ")).Replace("Invoice ", "");
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("Scen2INVCASHREQBANK@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                String CashReqTxt1 = SendPg.SearchedInvoiceCashStatus().Text;
                Assert.IsTrue(CashReqTxt1.Contains("Cash requested"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber2 = SIVPG1.InvNumber().Text;
                string invoicenumber2 = invnumber2.Substring(invnumber2.IndexOf("Invoice ")).Replace("Invoice ", "");
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("Scen2INVCASHREQMAP@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                String CashReqTxt2 = SendPg.SearchedInvoiceCashStatus().Text;
                Assert.IsTrue(CashReqTxt2.Contains("Cash requested"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber3 = SIVPG1.InvNumber().Text;
                string invoicenumber3 = invnumber3.Substring(invnumber3.IndexOf("Invoice ")).Replace("Invoice ", "");
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("Scen2INVCASHREQEXTCARD@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                String CashReqTxt4 = SendPg.SearchedInvoiceCashStatus().Text;
                Assert.IsTrue(CashReqTxt4.Contains("Cash requested"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber4 = SIVPG1.InvNumber().Text;
                string invoicenumber4 = invnumber4.Substring(invnumber4.IndexOf("Invoice ")).Replace("Invoice ", "");
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                addrecord(invoicenumber1, "approved", "FactorFox.csv");
                addrecord(invoicenumber2, "approved", "FactorFox.csv");
                addrecord(invoicenumber3, "approved", "FactorFox.csv");
                addrecord(invoicenumber4, "approved", "FactorFox.csv");
                SeleniumSetMethods.WaitOnPage(secdelay2);


                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("billzydemo+financial-controller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                string cashapprove1 = HomePg.FFApproved().Text;
                bool approvebtn1 = HomePg.Approvebtn().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(cashapprove1.Contains("Pending Approval") && approvebtn1 == true);
                SeleniumSetMethods.WaitOnPage(secdelay5);

                HomePg.Uploadfactorfox().SendKeys(@"C:\Users\Selenium\Desktop\SeleniumRegressionSuite_Bamboo\bin\Debug\netcoreapp3.1\FactorFox.csv");
                SeleniumSetMethods.WaitOnPage(secdelay7);
                IAlert alert = WebDriver.SwitchTo().Alert();
                alert.Accept();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                HomePg.FCLogout().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);


                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+cash02payer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);

                ReceivedPage recpg = new ReceivedPage(WebDriver);
                recpg.SearchInvoiceReceived().SendKeys(invoicenumber1);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                recpg.PAY().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                //Proceed to payment
                PayNowPage PNPg = new PayNowPage(WebDriver);
                PNPg.CcDropDown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PNPg.CardRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PNPg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PNPg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                recpg.SearchInvoiceReceived().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                recpg.SearchInvoiceReceived().Clear();
                recpg.SearchInvoiceReceived().SendKeys(invoicenumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                recpg.PAY().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                PNPg.CcDropDown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PNPg.CardRow03().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PNPg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PNPg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://accounts.google.com/signin/v2/identifier?service=mail&passive=true&rm=false&continue=https%3A%2F%2Fmail.google.com%2Fmail%2F&ss=1&scc=1&ltmpl=default&ltmplcache=2&emr=1&osid=1&flowName=GlifWebSignIn&flowEntry=ServiceLogin");

                GMAILPage gmailpg = new GMAILPage(WebDriver);

                DateTime duedate1 = DateTime.Today.AddDays(90);
                string SentPgDueDate = duedate1.ToString("dd MMM yyyy");
                gmailpg.Username().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Username().SendKeys("madcowtesting10@gmail.com");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.UserNext().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                gmailpg.Password().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.PasswordNext().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                gmailpg.Search().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Search().SendKeys("Scen2INVCASHREQEXTCARD@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag4 = WebDriver.FindElement(By.TagName("body"));
                bool Content42 = bodyTag4.Text.Contains("has sent you an invoice via billzy.");
                bool Content44 = bodyTag4.Text.Contains("Scen2INVCASHREQEXTCARD");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Content42 == true && Content44 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Verify().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));
                bool bpay = bodyTag.Text.Contains("The Bpay Biller Code is created via the Billzy platform, with the Biller displaying as Billzy or your Suppliers name.");
                Console.WriteLine(bodyTag);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(bpay == true);
                gmailpg.paypageverify().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                bool verifiedmsg = gmailpg.paypageverified().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(verifiedmsg == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.CardName().SendKeys("Valid");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                gmailpg.CardNumber().SendKeys("4242424242424242");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                gmailpg.Expmon().SendKeys("12");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                gmailpg.ExpYY().SendKeys("25");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                gmailpg.CVC().SendKeys("089");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                gmailpg.PAY().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                string successmsg = gmailpg.Successmsg().Text;
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Assert.IsTrue(successmsg.Contains("Successful payment"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Close();
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.profile().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.signout().Click();


                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://4impact-billzy-bobo-ui-uat.s3-ap-southeast-2.amazonaws.com/poc.html");
                Bobopg.Username().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.Username().SendKeys("madcowbiller+bobo_02@gmail.com");
                Bobopg.Password().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.Password().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.LoginBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                Bobopg.UpdateExistingBillzyInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                Bobopg.SelectBusiness().SendKeys("madcowtesting10+cash02biller");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                // invoice with Cash reqested status
                Bobopg.InputInvoice().SendKeys(invoicenumber3);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.SearchBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.MarkAsPaidEnabled().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Bobopg.MAPYes().Click();
                SeleniumSetMethods.WaitOnPage(secdelay8);
                bool Markaspaiddisabled0 = Bobopg.MarkAsPaidDisabled().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Markaspaiddisabled0 == true);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+cash02biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);

                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SendPg.SentHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SendPg.SearchInvoiceSent().SendKeys(invoicenumber1);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool CashDec1 = SendPg.CashDeclinedIcon().Displayed;
                String CashDecTxt1 = SendPg.SearchedInvoiceCashStatus().Text;
                Assert.IsTrue(CashDec1 == true && CashDecTxt1.Contains("Cash declined"));
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SendPg.SearchInvoiceSent().SendKeys(invoicenumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool CashDec2 = SendPg.CashDeclinedIcon().Displayed;
                String CashDecTxt2 = SendPg.SearchedInvoiceCashStatus().Text;
                Assert.IsTrue(CashDec2 == true && CashDecTxt2.Contains("Cash declined"));
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SendPg.SearchInvoiceSent().SendKeys(invoicenumber3);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool CashDec3 = SendPg.CashDeclinedIcon().Displayed;
                String CashDecTxt3 = SendPg.SearchedInvoiceCashStatus().Text;
                Assert.IsTrue(CashDec3 == true && CashDecTxt3.Contains("Cash declined"));

                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SendPg.SearchInvoiceSent().SendKeys(invoicenumber4);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool CashDec4 = SendPg.CashDeclinedIcon().Displayed;
                String CashDecTxt4 = SendPg.SearchedInvoiceCashStatus().Text;
                Assert.IsTrue(CashDec4 == true && CashDecTxt4.Contains("Cash declined"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("billzydemo+financial-controller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                string autodeclinelist = loginPage.finconautodeclinelist().Text;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(autodeclinelist.Contains(invoicenumber1) && autodeclinelist.Contains(invoicenumber2) && autodeclinelist.Contains(invoicenumber3) && autodeclinelist.Contains(invoicenumber4));
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string finconcashreqlist = loginPage.finconcashreqlist().Text;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                bool inv1 = finconcashreqlist.Contains(invoicenumber1);
                bool inv2 = finconcashreqlist.Contains(invoicenumber2);
                bool inv3 = finconcashreqlist.Contains(invoicenumber3);
                bool inv4 = finconcashreqlist.Contains(invoicenumber4);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(inv1 == false && inv2 == false && inv3 == false && inv4 == false);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.FCLogout().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                

            }
            finally
            {
               
               

            }

        }

        [Test]
        public void BillzyCash13_DynamicCashStateChange_Scenario3_CashApproved()
        {
            HomePage HomePg = new HomePage(WebDriver);
            LoginPage loginPage = new LoginPage(WebDriver);
            try
            {

                WebDriver.Manage().Window.Maximize();

                WebDriver.Navigate().GoToUrl("https://demo.billzy.com");
                BOBOPage Bobopg = new BOBOPage(WebDriver);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+cash02biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);
               
                //Generate two random numbers for unique customer details and invoice
                Random rand = new Random();
                DateTime dt = new DateTime();
                string dtString = dt.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber1 = rand.Next();
                Random rand2 = new Random();
                DateTime dt2 = new DateTime();
                string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber2 = rand.Next();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "90 days";


                var invnum = new List<string> { "Scen3INVCASHREQCARD", "Scen3INVCASHREQBANK", "Scen3INVCASHREQMAP" };
                for (int i = invnum.Count - 1; i >= 0; i--)
                //for (int i = 0; i < 20; i++)
                {
                  
                    //Internal Cash    Yes Requested   CC 01INTSURCASHREQCC@
                    SeleniumSetMethods.WaitOnPage(secdelay5);
                    IssueInvoicePg.IssueInvoiceButton().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    IssueInvoicePg.BusinessName().Click();
                    IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+cash02payer");
                    IssueInvoicePg.SelectBusiness().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                    IssueInvoicePg.CreateInvoice().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    IssueInvoicePg.InvoiceReferenceCreate().SendKeys(invnum[i] + "@" + randnumber2);
                    IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                    IssueInvoicePg.LineItemAmount().SendKeys("100");
                    IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                    SeleniumSetMethods.WaitOnPage(secdelay1);
                    IssueInvoicePg.BillzyCashBTN().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    IssueInvoicePg.AcceptTCBTN().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    IssueInvoicePg.SurchargeCheckbox().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    IssueInvoicePg.SendInvoiceBTN().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay5);
                  
                }

                SeleniumSetMethods.WaitOnPage(secdelay5);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("External1");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("Scen3INVCASHREQEXTCARD@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPage SendPg = new SendPage(WebDriver);
                SendPg.SearchInvoiceSent().SendKeys("Scen3INVCASHREQCARD@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool CashReqIcon = SendPg.CashRequestedIcon().Displayed;
                String CashReqTxt = SendPg.SearchedInvoiceCashStatus().Text;
                Assert.IsTrue(CashReqIcon == true && CashReqTxt.Contains("Cash requested"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SIVPage SIVPG1 = new SIVPage(WebDriver);
                string invnumber1 = SIVPG1.InvNumber().Text;
                string invoicenumber1 = invnumber1.Substring(invnumber1.IndexOf("Invoice ")).Replace("Invoice ", "");
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("Scen3INVCASHREQBANK@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                String CashReqTxt1 = SendPg.SearchedInvoiceCashStatus().Text;
                Assert.IsTrue(CashReqTxt1.Contains("Cash requested"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber2 = SIVPG1.InvNumber().Text;
                string invoicenumber2 = invnumber2.Substring(invnumber2.IndexOf("Invoice ")).Replace("Invoice ", "");
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SendPg.SearchInvoiceSent().SendKeys("Scen3INVCASHREQMAP@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                String CashReqTxt2 = SendPg.SearchedInvoiceCashStatus().Text;
                Assert.IsTrue(CashReqTxt2.Contains("Cash requested"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber3 = SIVPG1.InvNumber().Text;
                string invoicenumber3 = invnumber3.Substring(invnumber3.IndexOf("Invoice ")).Replace("Invoice ", "");
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("Scen3INVCASHREQEXTCARD@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                String CashReqTxt4 = SendPg.SearchedInvoiceCashStatus().Text;
                Assert.IsTrue(CashReqTxt4.Contains("Cash requested"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber4 = SIVPG1.InvNumber().Text;
                string invoicenumber4 = invnumber4.Substring(invnumber4.IndexOf("Invoice ")).Replace("Invoice ", "");
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                addrecord(invoicenumber1, "approved", "FactorFox.csv");
                addrecord(invoicenumber2, "approved", "FactorFox.csv");
                addrecord(invoicenumber3, "approved", "FactorFox.csv");
                addrecord(invoicenumber4, "approved", "FactorFox.csv");
                SeleniumSetMethods.WaitOnPage(secdelay2);


                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("billzydemo+financial-controller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                string cashapprove1 = HomePg.FFApproved().Text;
                bool approvebtn1 = HomePg.Approvebtn().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(cashapprove1.Contains("Pending Approval") && approvebtn1 == true);
                SeleniumSetMethods.WaitOnPage(secdelay5);

                HomePg.Uploadfactorfox().SendKeys(@"C:\Users\Selenium\Desktop\SeleniumRegressionSuite_Bamboo\bin\Debug\netcoreapp3.1\FactorFox.csv");
                SeleniumSetMethods.WaitOnPage(secdelay7);
                IAlert alert = WebDriver.SwitchTo().Alert();
                alert.Accept();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SeleniumSetMethods.WaitOnPage(secdelay7);

                

                var invset1 = new List<string> { invoicenumber1, invoicenumber2, invoicenumber3, invoicenumber4 };
                for (int i = invset1.Count - 1; i >= 0; i--)
                {
                    IWebElement ApproveButton1 = WebDriver.FindElement(By.XPath("//td[text()=\"" + invset1[i] + "\"]/../td/button[text()=\"approve\"]"));
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    ApproveButton1.Click();
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    HomePg.Cashratesubmit().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay5);
                    IAlert alert1 = WebDriver.SwitchTo().Alert();
                    alert1.Accept();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    Console.WriteLine(i);
                }

                SeleniumSetMethods.WaitOnPage(secdelay5);
                HomePg.FCLogout().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+cash02payer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                ReceivedPage recpg = new ReceivedPage(WebDriver);
                recpg.SearchInvoiceReceived().SendKeys(invoicenumber1);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                recpg.PAY().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                //Proceed to payment
                PayNowPage PNPg = new PayNowPage(WebDriver);
                PNPg.CcDropDown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PNPg.CardRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PNPg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PNPg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                recpg.SearchInvoiceReceived().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                recpg.SearchInvoiceReceived().Clear();
                recpg.SearchInvoiceReceived().SendKeys(invoicenumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                recpg.PAY().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                PNPg.CcDropDown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PNPg.CardRow03().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PNPg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PNPg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://accounts.google.com/signin/v2/identifier?service=mail&passive=true&rm=false&continue=https%3A%2F%2Fmail.google.com%2Fmail%2F&ss=1&scc=1&ltmpl=default&ltmplcache=2&emr=1&osid=1&flowName=GlifWebSignIn&flowEntry=ServiceLogin");

                GMAILPage gmailpg = new GMAILPage(WebDriver);

                DateTime duedate1 = DateTime.Today.AddDays(90);
                string SentPgDueDate = duedate1.ToString("dd MMM yyyy");
                gmailpg.Username().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Username().SendKeys("madcowtesting10@gmail.com");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.UserNext().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                gmailpg.Password().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.PasswordNext().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                gmailpg.Search().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Search().SendKeys("Scen3INVCASHREQEXTCARD@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                gmailpg.SearchButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag4 = WebDriver.FindElement(By.TagName("body"));
                bool Content42 = bodyTag4.Text.Contains("has sent you an invoice via billzy.");
                bool Content44 = bodyTag4.Text.Contains("Scen3INVCASHREQEXTCARD");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Content42 == true && Content44 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Verify().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));
                bool bpay = bodyTag.Text.Contains("The Bpay Biller Code is created via the Billzy platform, with the Biller displaying as Billzy or your Suppliers name.");
                Console.WriteLine(bodyTag);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(bpay == true);
                gmailpg.paypageverify().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                bool verifiedmsg = gmailpg.paypageverified().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(verifiedmsg == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.CardName().SendKeys("Valid");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                gmailpg.CardNumber().SendKeys("4242424242424242");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                gmailpg.Expmon().SendKeys("12");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                gmailpg.ExpYY().SendKeys("25");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                gmailpg.CVC().SendKeys("089");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                gmailpg.PAY().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                string successmsg = gmailpg.Successmsg().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(successmsg.Contains("Successful payment"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Close();
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.profile().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.signout().Click();


                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://4impact-billzy-bobo-ui-uat.s3-ap-southeast-2.amazonaws.com/poc.html");
                Bobopg.Username().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.Username().SendKeys("madcowbiller+bobo_02@gmail.com");
                Bobopg.Password().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.Password().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.LoginBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                Bobopg.UpdateExistingBillzyInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                Bobopg.SelectBusiness().SendKeys("madcowtesting10+cash02biller");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                // invoice with Cash reqested status
                Bobopg.InputInvoice().SendKeys(invoicenumber3);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.SearchBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.MarkAsPaidEnabled().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Bobopg.MAPYes().Click();
                SeleniumSetMethods.WaitOnPage(secdelay8);
                bool Markaspaiddisabled0 = Bobopg.MarkAsPaidDisabled().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Markaspaiddisabled0 == true);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+cash02biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);

                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SendPg.SentHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SendPg.SearchInvoiceSent().SendKeys(invoicenumber1);
                SeleniumSetMethods.WaitOnPage(secdelay8);
                bool CashDec1 = SendPg.CashDeclinedIcon().Displayed;
                String CashDecTxt1 = SendPg.SearchedInvoiceCashStatus().Text;
                Assert.IsTrue(CashDec1 == true && CashDecTxt1.Contains("Cash declined"));
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SendPg.SearchInvoiceSent().SendKeys(invoicenumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool CashDec2 = SendPg.CashDeclinedIcon().Displayed;
                String CashDecTxt2 = SendPg.SearchedInvoiceCashStatus().Text;
                Assert.IsTrue(CashDec2 == true && CashDecTxt2.Contains("Cash declined"));
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SendPg.SearchInvoiceSent().SendKeys(invoicenumber3);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool CashDec3 = SendPg.CashDeclinedIcon().Displayed;
                String CashDecTxt3 = SendPg.SearchedInvoiceCashStatus().Text;
                Assert.IsTrue(CashDec3 == true && CashDecTxt3.Contains("Cash declined"));

                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SendPg.SearchInvoiceSent().SendKeys(invoicenumber4);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool CashDec4 = SendPg.CashDeclinedIcon().Displayed;
                String CashDecTxt4 = SendPg.SearchedInvoiceCashStatus().Text;
                Assert.IsTrue(CashDec4 == true && CashDecTxt4.Contains("Cash declined"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("billzydemo+financial-controller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                string autodeclinelist = loginPage.finconautodeclinelist().Text;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(autodeclinelist.Contains(invoicenumber1) && autodeclinelist.Contains(invoicenumber2) && autodeclinelist.Contains(invoicenumber3) && autodeclinelist.Contains(invoicenumber4));
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string finconcashreqlist = loginPage.finconcashreqlist().Text;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                bool inv1 = finconcashreqlist.Contains(invoicenumber1);
                bool inv2 = finconcashreqlist.Contains(invoicenumber2);
                bool inv3 = finconcashreqlist.Contains(invoicenumber3);
                bool inv4 = finconcashreqlist.Contains(invoicenumber4);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(inv1 == false && inv2 == false && inv3 == false && inv4 == false);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.FCLogout().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
            }
            finally
            {
               

            }

        }
        /*[Test]
        public void BillzyCash14_DynamicCashStateChange_Scenario4_CashApprovedAfterCDRGeneration()
        {
            HomePage HomePg = new HomePage(WebDriver);
            LoginPage loginPage = new LoginPage(WebDriver);
            try
            {

                WebDriver.Manage().Window.Maximize();

                WebDriver.Navigate().GoToUrl("https://demo.billzy.com");
                BOBOPage Bobopg = new BOBOPage(WebDriver);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+cash02biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay7);
                IssueInvoicePage IssueInvoicePg = new IssueInvoicePage(WebDriver);

                //Generate two random numbers for unique customer details and invoice
                Random rand = new Random();
                DateTime dt = new DateTime();
                string dtString = dt.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber1 = rand.Next();
                Random rand2 = new Random();
                DateTime dt2 = new DateTime();
                string dtString2 = dt2.ToString("MM/dd/yyyy HH:mm:ss");
                int randnumber2 = rand.Next();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                String PaymentTerms = "90 days";


                var invnum = new List<string> { "Scen4INVCASHREQCARD", "Scen4INVCASHREQBANK", "Scen4INVCASHREQMAP" };
                for (int i = invnum.Count - 1; i >= 0; i--)
                //for (int i = 0; i < 20; i++)
                {

                    //Internal Cash    Yes Requested   CC 01INTSURCASHREQCC@
                    SeleniumSetMethods.WaitOnPage(secdelay5);
                    IssueInvoicePg.IssueInvoiceButton().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    IssueInvoicePg.BusinessName().Click();
                    IssueInvoicePg.BusinessName().SendKeys("madcowtesting10+cash02payer");
                    IssueInvoicePg.SelectBusiness().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                    IssueInvoicePg.CreateInvoice().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    IssueInvoicePg.InvoiceReferenceCreate().SendKeys(invnum[i] + "@" + randnumber2);
                    IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                    IssueInvoicePg.LineItemAmount().SendKeys("100");
                    IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                    SeleniumSetMethods.WaitOnPage(secdelay1);
                    IssueInvoicePg.BillzyCashBTN().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    IssueInvoicePg.AcceptTCBTN().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    IssueInvoicePg.SurchargeCheckbox().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    IssueInvoicePg.SendInvoiceBTN().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay5);

                }

                SeleniumSetMethods.WaitOnPage(secdelay5);
                IssueInvoicePg.IssueInvoiceButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.BusinessName().Click();
                IssueInvoicePg.BusinessName().SendKeys("External1");
                IssueInvoicePg.SelectBusiness().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.PaymentTerms().SendKeys(PaymentTerms);
                IssueInvoicePg.CreateInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.InvoiceReferenceCreate().SendKeys("Scen4INVCASHREQEXTCARD@" + randnumber2);
                IssueInvoicePg.Description().SendKeys("Test Invoice issued");
                IssueInvoicePg.LineItemAmount().SendKeys("100");
                IssueInvoicePg.Message().SendKeys("Test invoice has been sent");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                IssueInvoicePg.BillzyCashBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.AcceptTCBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SurchargeCheckbox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IssueInvoicePg.SendInvoiceBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                SendPage SendPg = new SendPage(WebDriver);
                SendPg.SearchInvoiceSent().SendKeys("Scen4INVCASHREQCARD@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                bool CashReqIcon = SendPg.CashRequestedIcon().Displayed;
                String CashReqTxt = SendPg.SearchedInvoiceCashStatus().Text;
                Assert.IsTrue(CashReqIcon == true && CashReqTxt.Contains("Cash requested"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SIVPage SIVPG1 = new SIVPage(WebDriver);
                string invnumber1 = SIVPG1.InvNumber().Text;
                string invoicenumber1 = invnumber1.Substring(invnumber1.IndexOf("Invoice ")).Replace("Invoice ", "");
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("Scen4INVCASHREQBANK@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                String CashReqTxt1 = SendPg.SearchedInvoiceCashStatus().Text;
                Assert.IsTrue(CashReqTxt1.Contains("Cash requested"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber2 = SIVPG1.InvNumber().Text;
                string invoicenumber2 = invnumber2.Substring(invnumber2.IndexOf("Invoice ")).Replace("Invoice ", "");
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("Scen4INVCASHREQMAP@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                String CashReqTxt2 = SendPg.SearchedInvoiceCashStatus().Text;
                Assert.IsTrue(CashReqTxt2.Contains("Cash requested"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber3 = SIVPG1.InvNumber().Text;
                string invoicenumber3 = invnumber3.Substring(invnumber3.IndexOf("Invoice ")).Replace("Invoice ", "");
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().SendKeys("Scen4INVCASHREQEXTCARD@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                String CashReqTxt4 = SendPg.SearchedInvoiceCashStatus().Text;
                Assert.IsTrue(CashReqTxt4.Contains("Cash requested"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyRefResult().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                string invnumber4 = SIVPG1.InvNumber().Text;
                string invoicenumber4 = invnumber4.Substring(invnumber4.IndexOf("Invoice ")).Replace("Invoice ", "");
                SIVPG1.ReturnBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                addrecord(invoicenumber1, "approved", "FactorFox.csv");
                addrecord(invoicenumber2, "approved", "FactorFox.csv");
                addrecord(invoicenumber3, "approved", "FactorFox.csv");
                addrecord(invoicenumber4, "approved", "FactorFox.csv");
                SeleniumSetMethods.WaitOnPage(secdelay2);


                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("billzydemo+financial-controller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                string cashapprove1 = HomePg.FFApproved().Text;
                bool approvebtn1 = HomePg.Approvebtn().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(cashapprove1.Contains("Pending Approval") && approvebtn1 == true);
                SeleniumSetMethods.WaitOnPage(secdelay5);

                HomePg.Uploadfactorfox().SendKeys(@"C:\Users\BillzyAdmin\OneDrive - Billzy\BillzyTestSuite\BillzyAutomationTestSuite\bin\Debug\netcoreapp3.0\FactorFox.csv");
                SeleniumSetMethods.WaitOnPage(secdelay10);
                IAlert alert = WebDriver.SwitchTo().Alert();
                alert.Accept();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SeleniumSetMethods.WaitOnPage(secdelay7);

                

                var invset1 = new List<string> { invoicenumber1, invoicenumber2, invoicenumber3, invoicenumber4 };
                for (int i = invset1.Count - 1; i >= 0; i--)
                {
                    IWebElement ApproveButton1 = WebDriver.FindElement(By.XPath("//td[text()=\"" + invset1[i] + "\"]/../td/button[text()=\"approve\"]"));
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    ApproveButton1.Click();
                    SeleniumSetMethods.WaitOnPage(secdelay3);
                    HomePg.Cashratesubmit().Click();
                    SeleniumSetMethods.WaitOnPage(secdelay5);
                    IAlert alert1 = WebDriver.SwitchTo().Alert();
                    alert1.Accept();
                    SeleniumSetMethods.WaitOnPage(secdelay2);
                    Console.WriteLine(i);
                }

                SeleniumSetMethods.WaitOnPage(secdelay5);
                HomePg.FCLogout().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);

                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+cash02payer@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                ReceivedPage recpg = new ReceivedPage(WebDriver);
                recpg.SearchInvoiceReceived().SendKeys(invoicenumber1);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                recpg.PAY().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                //Proceed to payment
                PayNowPage PNPg = new PayNowPage(WebDriver);
                PNPg.CcDropDown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PNPg.CardRow01().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PNPg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PNPg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                recpg.SearchInvoiceReceived().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                recpg.SearchInvoiceReceived().Clear();
                recpg.SearchInvoiceReceived().SendKeys(invoicenumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                recpg.ActionsMenu().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                recpg.PAY().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                PNPg.CcDropDown().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PNPg.CardRow03().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PNPg.ConfirmPaymentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                PNPg.DoneBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://accounts.google.com/signin/v2/identifier?service=mail&passive=true&rm=false&continue=https%3A%2F%2Fmail.google.com%2Fmail%2F&ss=1&scc=1&ltmpl=default&ltmplcache=2&emr=1&osid=1&flowName=GlifWebSignIn&flowEntry=ServiceLogin");

                GMAILPage gmailpg = new GMAILPage(WebDriver);

                DateTime duedate1 = DateTime.Today.AddDays(90);
                string SentPgDueDate = duedate1.ToString("dd MMM yyyy");
                gmailpg.Username().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Username().SendKeys("madcowtesting10@gmail.com");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.UserNext().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                gmailpg.Password().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.PasswordNext().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                gmailpg.Search().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Search().SendKeys("Scen4INVCASHREQEXTCARD@" + randnumber2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchOption().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.SearchButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                new Actions(WebDriver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                IWebElement bodyTag4 = WebDriver.FindElement(By.TagName("body"));
                bool Content42 = bodyTag4.Text.Contains("has sent you an invoice via billzy.");
                bool Content44 = bodyTag4.Text.Contains("Scen4INVCASHREQEXTCARD");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Content42 == true && Content44 == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.Verify().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
                IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));
                bool bpay = bodyTag.Text.Contains("The Bpay Biller Code is created via the Billzy platform, with the Biller displaying as Billzy or your Suppliers name.");
                Console.WriteLine(bodyTag);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(bpay == true);
                gmailpg.paypageverify().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
                bool verifiedmsg = gmailpg.paypageverified().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(verifiedmsg == true);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.CardName().SendKeys("Valid");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                gmailpg.CardNumber().SendKeys("4242424242424242");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                gmailpg.Expmon().SendKeys("12");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                gmailpg.ExpYY().SendKeys("25");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                gmailpg.CVC().SendKeys("089");
                SeleniumSetMethods.WaitOnPage(secdelay1);
                gmailpg.PAY().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                string successmsg = gmailpg.Successmsg().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(successmsg.Contains("Successful payment"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Close();
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.profile().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                gmailpg.signout().Click();


                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://4impact-billzy-bobo-ui-uat.s3-ap-southeast-2.amazonaws.com/poc.html");
                Bobopg.Username().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.Username().SendKeys("madcowbiller+bobo_02@gmail.com");
                Bobopg.Password().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.Password().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.LoginBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                Bobopg.UpdateExistingBillzyInvoice().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);

                Bobopg.SelectBusiness().SendKeys("madcowtesting10+cash02biller");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                // invoice with Cash reqested status
                Bobopg.InputInvoice().SendKeys(invoicenumber3);
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Bobopg.SearchBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Bobopg.MarkAsPaidEnabled().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                Bobopg.MAPYes().Click();
                SeleniumSetMethods.WaitOnPage(secdelay8);
                bool Markaspaiddisabled0 = Bobopg.MarkAsPaidDisabled().Displayed;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(Markaspaiddisabled0 == true);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowtesting10+cash02biller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);

                HomePg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SendPg.SentHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);
                SendPg.SearchInvoiceSent().SendKeys(invoicenumber1);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool CashDec1 = SendPg.CashDeclinedIcon().Displayed;
                String CashDecTxt1 = SendPg.SearchedInvoiceCashStatus().Text;
                Assert.IsTrue(CashDec1 == true && CashDecTxt1.Contains("Cash declined"));
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SendPg.SearchInvoiceSent().SendKeys(invoicenumber2);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool CashDec2 = SendPg.CashDeclinedIcon().Displayed;
                String CashDecTxt2 = SendPg.SearchedInvoiceCashStatus().Text;
                Assert.IsTrue(CashDec2 == true && CashDecTxt2.Contains("Cash declined"));
                SeleniumSetMethods.WaitOnPage(secdelay2);

                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SendPg.SearchInvoiceSent().SendKeys(invoicenumber3);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool CashDec3 = SendPg.CashDeclinedIcon().Displayed;
                String CashDecTxt3 = SendPg.SearchedInvoiceCashStatus().Text;
                Assert.IsTrue(CashDec3 == true && CashDecTxt3.Contains("Cash declined"));

                SendPg.SearchInvoiceSent().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.SearchInvoiceSent().Clear();
                SendPg.SearchInvoiceSent().SendKeys(invoicenumber4);
                SeleniumSetMethods.WaitOnPage(secdelay5);
                bool CashDec4 = SendPg.CashDeclinedIcon().Displayed;
                String CashDecTxt4 = SendPg.SearchedInvoiceCashStatus().Text;
                Assert.IsTrue(CashDec4 == true && CashDecTxt4.Contains("Cash declined"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                loginPage.UserNameTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().Clear();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("billzydemo+financial-controller@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay10);
                string autodeclinelist = loginPage.finconautodeclinelist().Text;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(autodeclinelist.Contains(invoicenumber1) && autodeclinelist.Contains(invoicenumber2) && autodeclinelist.Contains(invoicenumber3) && autodeclinelist.Contains(invoicenumber4));
                SeleniumSetMethods.WaitOnPage(secdelay3);
                string finconcashreqlist = loginPage.finconcashreqlist().Text;
                SeleniumSetMethods.WaitOnPage(secdelay3);
                bool inv1 = finconcashreqlist.Contains(invoicenumber1);
                bool inv2 = finconcashreqlist.Contains(invoicenumber2);
                bool inv3 = finconcashreqlist.Contains(invoicenumber3);
                bool inv4 = finconcashreqlist.Contains(invoicenumber4);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                Assert.IsTrue(inv1 == false && inv2 == false && inv3 == false && inv4 == false);
                SeleniumSetMethods.WaitOnPage(secdelay3);
                HomePg.FCLogout().Click();
                SeleniumSetMethods.WaitOnPage(secdelay3);
            }
            finally
            {
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com");

            }

        }*/

    }
}


