using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BillzyAutomationTestSuite
{
    public class Tests
    {
        protected IWebDriver WebDriver;
        public int secdelay1 = 1;
        public int secdelay2 = 2;
        public int secdelay3 = 3;
        public int secdelay4 = 4;
        public int secdelay5 = 5;
        public int secdelay6 = 6;
        public int secdelay8 = 8;
        public int secdelay10 = 10;
        public int secdelay9 = 9;
        public int secdelay7 = 7;

        [SetUp]
        public void Setup()
        {
            WebDriver = new ChromeDriver();
        }

        [TearDown]
        public void Cleanup()
        {
            WebDriver.Quit();
        }
    }
}