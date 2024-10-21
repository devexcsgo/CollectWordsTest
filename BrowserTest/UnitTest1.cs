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
        private static readonly string DriverDirectory = "C:\\Webdrivers";
        private static IWebDriver _driver;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _driver = new ChromeDriver(DriverDirectory);
        }

        [ClassCleanup]
        public static void TearDown()
        {
            //_driver.Dispose();
        }

        [TestMethod]
        public void TestMethod1()
        {
            //_driver.Navigate().GoToUrl("http://localhost:5503/index.htm");
            _driver.Navigate().GoToUrl("file:///C:/users/gympc/desktop/3sem/CollectWords/index.html");
            Assert.AreEqual("CollectWords", _driver.Title);

            IWebElement inputElement1 = _driver.FindElement(By.Id("wordInput"));
            inputElement1.SendKeys("abc");

            IWebElement saveButton = _driver.FindElement(By.Id("saveButton"));
            saveButton.Click();

            IWebElement showButton = _driver.FindElement(By.Id("showButton"));
            showButton.Click();

            IWebElement resultElement = _driver.FindElement(By.Id("output"));
            Assert.AreEqual("abc", resultElement.Text);

            inputElement1.Clear();
            inputElement1.SendKeys("def");
            saveButton.Click();
            showButton.Click();
            Assert.AreEqual("abc,def", resultElement.Text);

            IWebElement clearButton = _driver.FindElement(By.Id("clearButton"));
            clearButton.Click();
            showButton.Click();
            Assert.AreEqual("empty", resultElement.Text);
        }
    }
}