using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using BillzyAutomationTestSuite;
using BillzyAutomationTestSuite.PageObjects;
using BillzyAutomationTestSuite.Scripts;

namespace BillzyAutomationTestSuite.Scripts
{
    [TestFixture]
    [Parallelizable]
    class RegSuite_CSV_Export_Upload_PDF_Path : Tests
    {

        [Test]
        public void Export01_UploadPDFPath_UNPAID_CSVExport()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {
                


                //###Login to biller account
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);
                SendPage SendPg = new SendPage(WebDriver);
                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                ExportModalPage ExportMlPg = new ExportModalPage(WebDriver);

                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowbiller+uploadpdf_invoice_02@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay8);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                //testInfo = 'Export Modal for Sent - Outstanding - Billzy Export CSV'
                SendPg.SentOutstandingBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SearchInvoiceSent().SendKeys("Upload_PDF-");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SelectExportFormat().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyExport().Click();
                SeleniumSetMethods.WaitOnPage(secdelay8);

                string ExportModalTitle = ExportMlPg.ExportModalTitle().Text;
                string ExportMessage = ExportMlPg.ExportMessage().Text;
                bool icon = ExportMlPg.ExportDownloadIcon().Displayed;
                string hyperlink = ExportMlPg.HereHypherLink().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(ExportModalTitle.Contains("Export") && ExportMessage.Contains("Your download should start automatically. ") && icon == true && hyperlink.Contains("here"));
                ExportMlPg.ExportDownloadIcon().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                ExportMlPg.ExportCloseBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                // Validating the CSV report
                string exportlink = SendPg.ExportCSVFile().GetAttribute("href");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string CSVLink = exportlink.Substring(exportlink.IndexOf("https://4impact-export-data-uat.s3.ap-southeast-2.amazonaws.com/")).Replace("https://4impact-export-data-uat.s3.ap-southeast-2.amazonaws.com/", "");
                string csvfilename = CSVLink.Substring(0, CSVLink.LastIndexOf(".") + 1);
                string text = File.ReadAllText(@"C:\Users\Selenium\Downloads\" + csvfilename + "csv");
                Assert.IsTrue(text.Contains("Status,To,Invoice Number,Due,Amount,Billzy Column\nVIEWED,billzyBiz-415339,Upload_PDF-01,2024-01-01,100.00,\nUNVIEWED,billzyBiz-415339,Upload_PDF-02,2024-01-01,198.00,Offer sent\nUNVIEWED,billzyBiz-415339,Upload_PDF-03,2024-01-01,300.00,Cash requested\nUNVIEWED,External Payer,Upload_PDF-04,2024-01-01,400.00,Cash requested\nUNVIEWED,External Payer,Upload_PDF-05,2024-01-01,500.00"));
                Assert.IsTrue(text.Contains("Upload_PDF-01") && text.Contains("Upload_PDF-02") && text.Contains("Upload_PDF-03") && text.Contains("Upload_PDF-04") && text.Contains("Upload_PDF-05"));

                SeleniumSetMethods.WaitOnPage(secdelay4);
                //testInfo = 'Export Modal for Sent - Outstanding - MYOB CSV'
                SendPg.SelectExportFormat().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.MYOB().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                ExportMlPg.AccountNumber().SendKeys("031982");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ExportMlPg.NextBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string ExportModalTitle1 = ExportMlPg.ExportModalTitle().Text;
                string ExportMessage1 = ExportMlPg.ExportMessage().Text;
                bool icon1 = ExportMlPg.ExportDownloadIcon().Displayed;
                string hyperlink1 = ExportMlPg.HereHypherLink().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(ExportModalTitle1.Contains("Export") && ExportMessage1.Contains("Your download should start automatically. ") && icon1 == true && hyperlink1.Contains("here"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ExportMlPg.ExportDownloadIcon().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ExportMlPg.ExportCloseBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                // Validating the CSV report
                string exportlink1 = SendPg.ExportCSVFile().GetAttribute("href");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string CSVLink1 = exportlink1.Substring(exportlink1.IndexOf("https://4impact-export-data-uat.s3.ap-southeast-2.amazonaws.com/")).Replace("https://4impact-export-data-uat.s3.ap-southeast-2.amazonaws.com/", "");
                string csvfilename1 = CSVLink1.Substring(0, CSVLink1.LastIndexOf(".") + 1);
                string MYOBText = File.ReadAllText(@"C:\Users\Selenium\Downloads\" + csvfilename1 + "txt");
                Assert.IsTrue(MYOBText.Contains("Co./Last Name,Invoice #,Date,Description,Account Number,Amount,Tax Code,Tax Amount,Sale Status,Terms - Payment is Due,           - Balance Due Days,Amount Paid,Inc-Tax Amount"));
                Assert.IsTrue(MYOBText.Contains("billzyBiz-415339,10214716,17/10/2018,,031982,90.91,GST,9.09,I,2,15,0.0,100.00") && MYOBText.Contains("billzyBiz-415339,10214724,17/10/2018,,031982,181.82,GST,18.18,I,2,15,0.0,200.00") && MYOBText.Contains("billzyBiz-415339,10214732,17/10/2018,,031982,272.73,GST,27.27,I,2,15,0.0,300.00") && MYOBText.Contains("External Payer,10214740,17/10/2018,,031982,363.64,GST,36.36,I,2,15,0.0,400.00") && MYOBText.Contains("External Payer,10214757,17/10/2018,,031982,454.54,GST,45.46,I,2,15,0.0,500.00"));

                //testInfo = 'Export Modal for Sent - Outstanding - XERO CSV'

                SendPg.SelectExportFormat().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.XERO().Click();


                SeleniumSetMethods.WaitOnPage(secdelay5);
                string ExportModalTitle2 = ExportMlPg.ExportModalTitle().Text;
                string ExportMessage2 = ExportMlPg.ExportMessage().Text;
                bool icon2 = ExportMlPg.ExportDownloadIcon().Displayed;
                string hyperlink2 = ExportMlPg.HereHypherLink().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(ExportModalTitle2.Contains("Export") && ExportMessage2.Contains("Your download should start automatically. ") && icon2 == true && hyperlink2.Contains("here"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ExportMlPg.ExportDownloadIcon().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ExportMlPg.ExportCloseBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SeleniumSetMethods.WaitOnPage(secdelay2);

                // Validating the CSV report
                string exportlink2 = SendPg.ExportCSVFile().GetAttribute("href");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string CSVLink2 = exportlink2.Substring(exportlink2.IndexOf("https://4impact-export-data-uat.s3.ap-southeast-2.amazonaws.com/")).Replace("https://4impact-export-data-uat.s3.ap-southeast-2.amazonaws.com/", "");
                string csvfilename2 = CSVLink2.Substring(0, CSVLink2.LastIndexOf(".") + 1);

                string XEROText = File.ReadAllText(@"C:\Users\Selenium\Downloads\" + csvfilename2 + "csv");
                Assert.IsTrue(XEROText.Contains("ContactName,EmailAddress,POAddressLine1,POCity,POPostalCode,POCountry,InvoiceNumber,Reference,InvoiceDate,DueDate,Description,Quantity,UnitAmount,AccountCode,TaxType,TaxAmount"));
                Assert.IsTrue(XEROText.Contains("billzyBiz-415339,madcowpayer+UploadPDF_Invoice_02@gmail.com,415339 Testing St.,Brisbane,4000,AU,INV10214716,Upload_PDF-01,17/10/2018,01/01/2024,Exported from pay.billzy.com,1,100.00,,GST,0.00\nbillzyBiz-415339,madcowpayer+UploadPDF_Invoice_02@gmail.com,415339 Testing St.,Brisbane,4000,AU,INV10214724,Upload_PDF-02,17/10/2018,01/01/2024,Exported from pay.billzy.com,1,200.00,,GST,0.00\nbillzyBiz-415339,madcowpayer+UploadPDF_Invoice_02@gmail.com,415339 Testing St.,Brisbane,4000,AU,INV10214732,Upload_PDF-03,17/10/2018,01/01/2024,Exported from pay.billzy.com,1,300.00,,GST,0.00\nExternal Payer,null,,,,,INV10214740,Upload_PDF-04,17/10/2018,01/01/2024,Exported from pay.billzy.com,1,400.00,,GST,0.00\nExternal Payer,null,,,,,INV10214757,Upload_PDF-05,17/10/2018,01/01/2024,Exported from pay.billzy.com,1,500.00,,GST,0.00"));


                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();

                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowpayer+uploadpdf_invoice_02@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("Upload_PDF-");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                //testInfo = 'Export Modal for Sent - Outstanding - Billzy Export CSV'
                Recpg.SelectExportFormat().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.BillzyExport().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);

                string rExportModalTitle = ExportMlPg.ExportModalTitle().Text;
                string rExportMessage = ExportMlPg.ExportMessage().Text;
                bool ricon = ExportMlPg.ExportDownloadIcon().Displayed;
                string rhyperlink = ExportMlPg.HereHypherLink().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(rExportModalTitle.Contains("Export") && rExportMessage.Contains("Your download should start automatically. ") && ricon == true && rhyperlink.Contains("here"));
                ExportMlPg.ExportDownloadIcon().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                ExportMlPg.ExportCloseBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                // Validating the CSV report
                string exportlink3 = SendPg.ExportCSVFile().GetAttribute("href");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string CSVLink3 = exportlink3.Substring(exportlink3.IndexOf("https://4impact-export-data-uat.s3.ap-southeast-2.amazonaws.com/")).Replace("https://4impact-export-data-uat.s3.ap-southeast-2.amazonaws.com/", "");
                string csvfilename3 = CSVLink3.Substring(0, CSVLink3.LastIndexOf(".") + 1);
                string CSV2 = File.ReadAllText(@"C:\Users\Selenium\Downloads\" + csvfilename3 + "csv");
                Assert.IsTrue(CSV2.Contains("Status,Verified,From,Invoice Number,Due,Amount,Billzy Column\nVIEWED,NOT VERIFIED,billzyBiz-380887,Upload_PDF-01,2024-01-01,100.00,\nUNVIEWED,NOT VERIFIED,billzyBiz-380887,Upload_PDF-02,2024-01-01,198.00,Offer received\nUNVIEWED,NOT VERIFIED,billzyBiz-380887,Upload_PDF-03,2024-01-01,300.00,"));
                
                //testInfo = 'Export Modal for Sent - Outstanding - MYOB CSV'
                Recpg.SelectExportFormat().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.MYOB().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ExportMlPg.AccountNumber().SendKeys("031982");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ExportMlPg.NextBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string rExportModalTitle1 = ExportMlPg.ExportModalTitle().Text;
                string rExportMessage1 = ExportMlPg.ExportMessage().Text;
                bool ricon1 = ExportMlPg.ExportDownloadIcon().Displayed;
                string rhyperlink1 = ExportMlPg.HereHypherLink().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(rExportModalTitle1.Contains("Export") && rExportMessage1.Contains("Your download should start automatically. ") && ricon1 == true && rhyperlink1.Contains("here"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ExportMlPg.ExportDownloadIcon().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ExportMlPg.ExportCloseBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                // Validating the CSV report
                string exportlink4 = SendPg.ExportCSVFile().GetAttribute("href");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string CSVLink4 = exportlink4.Substring(exportlink4.IndexOf("https://4impact-export-data-uat.s3.ap-southeast-2.amazonaws.com/")).Replace("https://4impact-export-data-uat.s3.ap-southeast-2.amazonaws.com/", "");
                string csvfilename4 = CSVLink4.Substring(0, CSVLink4.LastIndexOf(".") + 1);
                string MYOB2 = File.ReadAllText(@"C:\Users\Selenium\Downloads\" + csvfilename4 + "txt");
                Assert.IsTrue(MYOB2.Contains("Co./Last Name,Date,Supplier Invoice #,Description,Account Number,Amount,Tax Code,Tax Amount,Purchase Status,Terms - Payment is Due,           - Balance Due Days,Amount Paid,Inc-Tax Amount"));
                Assert.IsTrue(MYOB2.Contains("billzyBiz-380887,17/10/2018,Upload_PDF-03,,031982,272.73,GST,27.27,B,2,15,0.0,300.00") && MYOB2.Contains("billzyBiz-380887,17/10/2018,Upload_PDF-02,,031982,181.82,GST,18.18,B,2,15,0.0,200.00") && MYOB2.Contains("billzyBiz-380887,17/10/2018,Upload_PDF-03,,031982,272.73,GST,27.27,B,2,15,0.0,300.00"));
                

                //testInfo = 'Export Modal for Sent - Outstanding - XERO CSV'

                Recpg.SelectExportFormat().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.XERO().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);


                string rExportModalTitle2 = ExportMlPg.ExportModalTitle().Text;
                string rExportMessage2 = ExportMlPg.ExportMessage().Text;
                bool ricon2 = ExportMlPg.ExportDownloadIcon().Displayed;
                string rhyperlink2 = ExportMlPg.HereHypherLink().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(rExportModalTitle2.Contains("Export") && rExportMessage2.Contains("Your download should start automatically. ") && ricon2 == true && rhyperlink2.Contains("here"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ExportMlPg.ExportDownloadIcon().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ExportMlPg.ExportCloseBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                // Validating the CSV report
                string exportlink5 = SendPg.ExportCSVFile().GetAttribute("href");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string CSVLink5 = exportlink5.Substring(exportlink5.IndexOf("https://4impact-export-data-uat.s3.ap-southeast-2.amazonaws.com/")).Replace("https://4impact-export-data-uat.s3.ap-southeast-2.amazonaws.com/", "");
                string csvfilename5 = CSVLink5.Substring(0, CSVLink5.LastIndexOf(".") + 1);
                string XERO2 = File.ReadAllText(@"C:\Users\Selenium\Downloads\" + csvfilename5 + "csv");
                Assert.IsTrue(XERO2.Contains("ContactName,EmailAddress,POAddressLine1,POCity,POPostalCode,POCountry,InvoiceNumber,Reference,InvoiceDate,DueDate,Description,Quantity,UnitAmount,AccountCode,TaxType,TaxAmount\nbillzyBiz-380887,madcowbiller+UploadPDF_Invoice_02@gmail.com,Testing St.,Brisbane,4000,AU,INV10214716,Upload_PDF-01,17/10/2018,01/01/2024,Exported from pay.billzy.com,1,100.00,,GST,0.00\nbillzyBiz-380887,madcowbiller+UploadPDF_Invoice_02@gmail.com,Testing St.,Brisbane,4000,AU,INV10214724,Upload_PDF-02,17/10/2018,01/01/2024,Exported from pay.billzy.com,1,200.00,,GST,0.00\nbillzyBiz-380887,madcowbiller+UploadPDF_Invoice_02@gmail.com,Testing St.,Brisbane,4000,AU,INV10214732,Upload_PDF-03,17/10/2018,01/01/2024,Exported from pay.billzy.com,1,300.00,,GST,0.00"));
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
        public void Export02_UploadPDFPath_PAIDHistory_CSVExport()
        {
            HomePage HomePg = new HomePage(WebDriver);
            try
            {
                //###Login to biller account
                WebDriver.Manage().Window.Maximize();
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/home");
                LoginPage loginPage = new LoginPage(WebDriver);
                SendPage SendPg = new SendPage(WebDriver);
                ReceivedPage Recpg = new ReceivedPage(WebDriver);
                ExportModalPage ExportMlPg = new ExportModalPage(WebDriver);

                loginPage.UserNameTextBox().Click();
                loginPage.UserNameTextBox().SendKeys("madcowbiller+uploadpdf_invoice_02@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");

                loginPage.LoginButton().Click();
                SeleniumSetMethods SetMethods = new SeleniumSetMethods(WebDriver);
                SeleniumSetMethods.WaitOnPage(secdelay8);
                SendPg.SentBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                //testInfo = 'Export Modal for Sent - History - Billzy Export CSV'
                SendPg.SentHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SearchInvoiceSent().SendKeys("Upload_PDF_P");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                SendPg.SelectExportFormat().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.BillzyExport().Click();
                SeleniumSetMethods.WaitOnPage(secdelay8);

                string ExportModalTitle = ExportMlPg.ExportModalTitle().Text;
                string ExportMessage = ExportMlPg.ExportMessage().Text;
                bool icon = ExportMlPg.ExportDownloadIcon().Displayed;
                string hyperlink = ExportMlPg.HereHypherLink().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(ExportModalTitle.Contains("Export") && ExportMessage.Contains("Your download should start automatically. ") && icon == true && hyperlink.Contains("here"));
                ExportMlPg.ExportDownloadIcon().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                ExportMlPg.ExportCloseBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                // Validating the CSV report
                string exportlink = SendPg.ExportCSVFile().GetAttribute("href");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string CSVLink = exportlink.Substring(exportlink.IndexOf("https://4impact-export-data-uat.s3.ap-southeast-2.amazonaws.com/")).Replace("https://4impact-export-data-uat.s3.ap-southeast-2.amazonaws.com/", "");
                string csvfilename = CSVLink.Substring(0, CSVLink.LastIndexOf(".") + 1);
                string text = File.ReadAllText(@"C:\Users\Selenium\Downloads\" + csvfilename + "csv");
                Assert.IsTrue(text.Contains("Status,To,Invoice Number,Completed,Amount,Billzy Column\nPAID,External Payer,Upload_PDF_P-09,2018-10-18,900.00,Cash requested\nPAID,External Payer,Upload_PDF_P-10,2018-10-18,1000.00,\nPAID,billzyBiz-415339,Upload_PDF_P-06,2018-10-18,600.00,\nPAID,billzyBiz-415339,Upload_PDF_P-07,2018-10-18,690.00,Paid 1901 day(s) earlier\nPAID,billzyBiz-415339,Upload_PDF_P-08,2018-10-18,800.00,Cash requested"));
                Assert.IsTrue(text.Contains("Upload_PDF_P-09") && text.Contains("Upload_PDF_P-06") && text.Contains("Upload_PDF_P-07") && text.Contains("Upload_PDF_P-08") && text.Contains("Upload_PDF_P-10"));

                //testInfo = 'Export Modal for Sent - History - MYOB CSV'
                SendPg.SelectExportFormat().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.MYOB().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                ExportMlPg.AccountNumber().SendKeys("031982");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ExportMlPg.NextBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string ExportModalTitle1 = ExportMlPg.ExportModalTitle().Text;
                string ExportMessage1 = ExportMlPg.ExportMessage().Text;
                bool icon1 = ExportMlPg.ExportDownloadIcon().Displayed;
                string hyperlink1 = ExportMlPg.HereHypherLink().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(ExportModalTitle1.Contains("Export") && ExportMessage1.Contains("Your download should start automatically. ") && icon1 == true && hyperlink1.Contains("here"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ExportMlPg.ExportDownloadIcon().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ExportMlPg.ExportCloseBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                // Validating the CSV report
                string exportlink1 = SendPg.ExportCSVFile().GetAttribute("href");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string CSVLink1 = exportlink1.Substring(exportlink1.IndexOf("https://4impact-export-data-uat.s3.ap-southeast-2.amazonaws.com/")).Replace("https://4impact-export-data-uat.s3.ap-southeast-2.amazonaws.com/", "");
                string csvfilename1 = CSVLink1.Substring(0, CSVLink1.LastIndexOf(".") + 1);
                string MYOBText = File.ReadAllText(@"C:\Users\Selenium\Downloads\" + csvfilename1 + "txt");
                Assert.IsTrue(MYOBText.Contains("Co./Last Name,Invoice #,Date,Description,Account Number,Amount,Tax Code,Tax Amount,Sale Status,Terms - Payment is Due,           - Balance Due Days,Amount Paid,Inc-Tax Amount\nExternal Payer,10214799,18/10/2018,,031982,818.18,GST,81.82,I,2,14,900.00,900.00\n\n\nExternal Payer,10214807,18/10/2018,,031982,909.09,GST,90.91,I,2,14,1000.00,1000.00\n\n\nbillzyBiz-415339,10214765,18/10/2018,,031982,545.45,GST,54.55,I,2,14,600.00,600.00\n\n\nbillzyBiz-415339,10214773,18/10/2018,,031982,636.36,GST,63.64,I,2,14,700.00,700.00\n\n\nbillzyBiz-415339,10214781,18/10/2018,,031982,727.27,GST,72.73,I,2,14,800.00,800.00\n\n"));
                Assert.IsTrue(MYOBText.Contains("10214799") && MYOBText.Contains("10214807") && MYOBText.Contains("10214765") && MYOBText.Contains("10214773") && MYOBText.Contains("10214781"));


                //testInfo = 'Export Modal for Sent - History - XERO CSV'

                SendPg.SelectExportFormat().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                SendPg.XERO().Click();


                SeleniumSetMethods.WaitOnPage(secdelay5);
                string ExportModalTitle2 = ExportMlPg.ExportModalTitle().Text;
                string ExportMessage2 = ExportMlPg.ExportMessage().Text;
                bool icon2 = ExportMlPg.ExportDownloadIcon().Displayed;
                string hyperlink2 = ExportMlPg.HereHypherLink().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(ExportModalTitle2.Contains("Export") && ExportMessage2.Contains("Your download should start automatically. ") && icon2 == true && hyperlink2.Contains("here"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ExportMlPg.ExportDownloadIcon().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ExportMlPg.ExportCloseBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                // Validating the CSV report
                string exportlink2 = SendPg.ExportCSVFile().GetAttribute("href");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string CSVLink2 = exportlink2.Substring(exportlink2.IndexOf("https://4impact-export-data-uat.s3.ap-southeast-2.amazonaws.com/")).Replace("https://4impact-export-data-uat.s3.ap-southeast-2.amazonaws.com/", "");
                string csvfilename2 = CSVLink2.Substring(0, CSVLink2.LastIndexOf(".") + 1);

                string XEROText = File.ReadAllText(@"C:\Users\Selenium\Downloads\" + csvfilename2 + "csv");
                Assert.IsTrue(XEROText.Contains("ContactName,EmailAddress,POAddressLine1,POCity,POPostalCode,POCountry,InvoiceNumber,Reference,InvoiceDate,DueDate,Description,Quantity,UnitAmount,AccountCode,TaxType,TaxAmount\nExternal Payer,null"));
                Assert.IsTrue(XEROText.Contains("INV10214799,Upload_PDF_P-09,18/10/2018,01/01/2024,Exported from pay.billzy.com,1,900.00,,GST,0.00\nExternal Payer,null,,,,,INV10214807,Upload_PDF_P-10,18/10/2018,01/01/2024,Exported from pay.billzy.com,1,1000.00,,GST,0.00\nbillzyBiz-415339,madcowpayer+UploadPDF_Invoice_02@gmail.com,415339 Testing St.,Brisbane,4000,AU,INV10214765,Upload_PDF_P-06,18/10/2018,01/01/2024,Exported from pay.billzy.com,1,600.00,,GST,0.00\nbillzyBiz-415339,madcowpayer+UploadPDF_Invoice_02@gmail.com,415339 Testing St.,Brisbane,4000,AU,INV10214773,Upload_PDF_P-07,18/10/2018,01/01/2024,Exported from pay.billzy.com,1,700.00,,GST,0.00\nbillzyBiz-415339,madcowpayer+UploadPDF_Invoice_02@gmail.com,415339 Testing St.,Brisbane,4000,AU,INV10214781,Upload_PDF_P-08,18/10/2018,01/01/2024,Exported from pay.billzy.com,1,800.00,,GST,0.00"));


                SeleniumSetMethods.WaitOnPage(secdelay2);
                HomePg.SignOutBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                loginPage.UserNameTextBox().Click();

                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.UserNameTextBox().SendKeys("madcowpayer+uploadpdf_invoice_02@gmail.com");
                loginPage.PasswordTextBox().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.PasswordTextBox().SendKeys("Cognito1");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                loginPage.LoginButton().Click();
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.ReceivedBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.ReceivedHistoryBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                Recpg.SearchInvoiceReceived().SendKeys("Upload_PDF_P");
                SeleniumSetMethods.WaitOnPage(secdelay3);
                SeleniumSetMethods.WaitOnPage(secdelay4);
                //testInfo = 'Export Modal for Received - History - Billzy Export CSV'
                Recpg.SelectExportFormat().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.BillzyExport().Click();
                SeleniumSetMethods.WaitOnPage(secdelay7);

                string rExportModalTitle = ExportMlPg.ExportModalTitle().Text;
                string rExportMessage = ExportMlPg.ExportMessage().Text;
                bool ricon = ExportMlPg.ExportDownloadIcon().Displayed;
                string rhyperlink = ExportMlPg.HereHypherLink().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(rExportModalTitle.Contains("Export") && rExportMessage.Contains("Your download should start automatically. ") && ricon == true && rhyperlink.Contains("here"));
                ExportMlPg.ExportDownloadIcon().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                ExportMlPg.ExportCloseBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                // Validating the CSV report
                string exportlink3 = SendPg.ExportCSVFile().GetAttribute("href");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string CSVLink3 = exportlink3.Substring(exportlink3.IndexOf("https://4impact-export-data-uat.s3.ap-southeast-2.amazonaws.com/")).Replace("https://4impact-export-data-uat.s3.ap-southeast-2.amazonaws.com/", "");
                string csvfilename3 = CSVLink3.Substring(0, CSVLink3.LastIndexOf(".") + 1);
                string CSV2 = File.ReadAllText(@"C:\Users\Selenium\Downloads\" + csvfilename3 + "csv");
                Assert.IsTrue(CSV2.Contains("Status,Verified,From,Invoice Number,Completed,Amount,Billzy Column\nPAID,NOT VERIFIED,billzyBiz-380887,Upload_PDF_P-06,2018-10-18,600.00,\nPAID,NOT VERIFIED,billzyBiz-380887,Upload_PDF_P-08,2018-10-18,800.00,\nPAID,NOT VERIFIED,billzyBiz-380887,Upload_PDF_P-07,2018-10-18,690.00,You saved $10.00"));

                //testInfo = 'Export Modal for Received - History - MYOB CSV'
                Recpg.SelectExportFormat().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.MYOB().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ExportMlPg.AccountNumber().SendKeys("031982");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ExportMlPg.NextBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);
                string rExportModalTitle1 = ExportMlPg.ExportModalTitle().Text;
                string rExportMessage1 = ExportMlPg.ExportMessage().Text;
                bool ricon1 = ExportMlPg.ExportDownloadIcon().Displayed;
                string rhyperlink1 = ExportMlPg.HereHypherLink().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(rExportModalTitle1.Contains("Export") && rExportMessage1.Contains("Your download should start automatically. ") && ricon1 == true && rhyperlink1.Contains("here"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ExportMlPg.ExportDownloadIcon().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ExportMlPg.ExportCloseBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                // Validating the CSV report
                string exportlink4 = SendPg.ExportCSVFile().GetAttribute("href");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string CSVLink4 = exportlink4.Substring(exportlink4.IndexOf("https://4impact-export-data-uat.s3.ap-southeast-2.amazonaws.com/")).Replace("https://4impact-export-data-uat.s3.ap-southeast-2.amazonaws.com/", "");
                string csvfilename4 = CSVLink4.Substring(0, CSVLink4.LastIndexOf(".") + 1);
                string MYOB2 = File.ReadAllText(@"C:\Users\Selenium\Downloads\" + csvfilename4 + "txt");
                Assert.IsTrue(MYOB2.Contains("Co./Last Name,Date,Supplier Invoice #,Description,Account Number,Amount,Tax Code,Tax Amount,Purchase Status,Terms - Payment is Due,           - Balance Due Days,Amount Paid,Inc-Tax Amount"));
                Assert.IsTrue(MYOB2.Contains("billzyBiz-380887,18/10/2018,Upload_PDF_P-06,,031982,545.45,GST,54.55,B,2,14,600.00,600.00\n\nbillzyBiz-380887,18/10/2018,Upload_PDF_P-07,,031982,636.36,GST,63.64,B,2,14,700.00,700.00\n\nbillzyBiz-380887,18/10/2018,Upload_PDF_P-08,,031982,727.27,GST,72.73,B,2,14,800.00,800.00"));

                //testInfo = 'Export Modal for Received - History - XERO CSV'

                Recpg.SelectExportFormat().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Recpg.XERO().Click();
                SeleniumSetMethods.WaitOnPage(secdelay5);


                string rExportModalTitle2 = ExportMlPg.ExportModalTitle().Text;
                string rExportMessage2 = ExportMlPg.ExportMessage().Text;
                bool ricon2 = ExportMlPg.ExportDownloadIcon().Displayed;
                string rhyperlink2 = ExportMlPg.HereHypherLink().Text;
                SeleniumSetMethods.WaitOnPage(secdelay2);
                Assert.IsTrue(rExportModalTitle2.Contains("Export") && rExportMessage2.Contains("Your download should start automatically. ") && ricon2 == true && rhyperlink2.Contains("here"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ExportMlPg.ExportDownloadIcon().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);
                ExportMlPg.ExportCloseBTN().Click();
                SeleniumSetMethods.WaitOnPage(secdelay2);

                // Validating the CSV report
                string exportlink5 = SendPg.ExportCSVFile().GetAttribute("href");
                SeleniumSetMethods.WaitOnPage(secdelay2);
                string CSVLink5 = exportlink5.Substring(exportlink5.IndexOf("https://4impact-export-data-uat.s3.ap-southeast-2.amazonaws.com/")).Replace("https://4impact-export-data-uat.s3.ap-southeast-2.amazonaws.com/", "");
                string csvfilename5 = CSVLink5.Substring(0, CSVLink5.LastIndexOf(".") + 1);
                string XERO2 = File.ReadAllText(@"C:\Users\Selenium\Downloads\" + csvfilename5 + "csv");
                Assert.IsTrue(XERO2.Contains("ContactName,EmailAddress,POAddressLine1,POCity,POPostalCode,POCountry,InvoiceNumber,Reference,InvoiceDate,DueDate,Description,Quantity,UnitAmount,AccountCode,TaxType,TaxAmount\nbillzyBiz-380887,madcowbiller+UploadPDF_Invoice_02@gmail.com,Testing St.,Brisbane,4000,AU,INV10214765,Upload_PDF_P-06,18/10/2018,01/01/2024,Exported from pay.billzy.com,1,600.00,,GST,0.00\nbillzyBiz-380887,madcowbiller+UploadPDF_Invoice_02@gmail.com,Testing St.,Brisbane,4000,AU,INV10214773,Upload_PDF_P-07,18/10/2018,01/01/2024,Exported from pay.billzy.com,1,700.00,,GST,0.00\nbillzyBiz-380887,madcowbiller+UploadPDF_Invoice_02@gmail.com,Testing St.,Brisbane,4000,AU,INV10214781,Upload_PDF_P-08,18/10/2018,01/01/2024,Exported from pay.billzy.com,1,800.00,,GST,0.00"));
                SeleniumSetMethods.WaitOnPage(secdelay2);
                WebDriver.Navigate().GoToUrl("https://demo.billzy.com/received");
                SeleniumSetMethods.WaitOnPage(secdelay4);
                HomePg.SignOutBTN().Click();
            }
            finally
            {
                
            }


        }
    }
}
