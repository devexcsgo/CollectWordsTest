using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Edge;

namespace collectWordsTest
{
    [TestClass]
    public class UnitTest1
    {
        // Sti til ChromeDriver eksekverbar fil
        private static readonly string DriverDirectory = "C:/seleniumDrivers/chromedriver-win64/chromedriver.exe";
        // WebDriver instans
        private static IWebDriver _driver;

        // Initialiserer WebDriver f�r nogen tests k�res
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _driver = new ChromeDriver(DriverDirectory);
        }

        // Rydder op efter alle tests er k�rt
        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose(); // skal bruges til at frigive ressourcer
        }

        // Testmetode der tester forskellige funktionaliteter p� en lokal HTML-side
        [TestMethod]
        public void TestMethod1()
        {
            // Navigerer til den lokale HTML-side
            _driver?.Navigate().GoToUrl("file:///C:/javatest/CollectWords/index.html");
            // Tjekker at sidens titel er "CollectWords"
            Assert.AreEqual("CollectWords", _driver.Title);

            // Finder input elementet og indtaster "Test1"
            IWebElement inputElement1 = _driver.FindElement(By.Id("wordInput"));
            inputElement1.SendKeys("Test1");

            // Finder og klikker p� gem-knappen
            IWebElement saveButton = _driver.FindElement(By.Id("saveButton"));
            saveButton.Click();

            // Finder og klikker p� vis-knappen
            IWebElement showButton = _driver.FindElement(By.Id("showButton"));
            showButton.Click();

            // Finder resultat elementet og tjekker at teksten er "Test1"
            IWebElement resultElement = _driver.FindElement(By.Id("output"));
            Assert.AreEqual("Test1", resultElement.Text);

            // Rydder input, indtaster "Test2", og gentager gem og vis handlingerne
            inputElement1.Clear();
            inputElement1.SendKeys("Test2");
            saveButton.Click();
            showButton.Click();
            // Tjekker at resultatet nu indeholder "Test1, Test2"
            Assert.AreEqual("Test1, Test2", resultElement.Text);

            // Finder og klikker p� ryd-knappen, og tjekker at resultatet er "empty"
            IWebElement clearButton = _driver.FindElement(By.Id("clearButton"));
            clearButton.Click();
            showButton.Click();
            Assert.AreEqual("empty", resultElement.Text);
        }
    }
}