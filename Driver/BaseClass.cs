using Gauge.CSharp.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace UIAutomationChallenge.Driver
{
    class BaseClass
    {
        public static IWebDriver driver;
        protected static readonly string BaseUrl = Environment.GetEnvironmentVariable("APP_BASEURL");

        public void SendKeys(By locator, string text)
        {
            WaitUntilElementToBeClickable(locator);
            IWebElement element = driver.FindElement(locator);
            element.Clear();
            element.SendKeys(text);
        }

        public void Click(By locator)
        {
            WaitUntilElementToBeClickable(locator);
            IWebElement element = driver.FindElement(locator);
            element.Click();
        }

        public void SelectByValue(By locator, string text){
            IWebElement element = driver.FindElement(locator);
            var selectElement = new SelectElement(element);
            selectElement.SelectByValue(text);
        }

        public void SelectByText(By locator, string text){
            IWebElement element = driver.FindElement(locator);
            var selectElement = new SelectElement(element);
            selectElement.SelectByText(text);
        }

        public string GetVisibleText(By locator)
        {
            WaitUntilElementToBeClickable(locator);
            IWebElement element = driver.FindElement(locator);
            return element.Text;
        }

        public void SwitchToIFrame(string frameId)
        {
            driver.SwitchTo().Frame(frameId);
        }

        public void WaitUntilElementToBeClickable(By locator)
        {   
            new WebDriverWait(driver, TimeSpan.FromSeconds(15)).Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public void FluentWaitForElementToBeVisible(By locator)
        {   
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element to be searched not found";
            fluentWait.Until(x => x.FindElement(locator));
        }

        public void AssertContains(string text, string textToBeFind, string message)
        {
            WriteMessage("Expected: " + text + "  Contains: " + textToBeFind + " - Checking the assertion...");
            Assert.IsTrue(text.Contains(textToBeFind), message);
        }

         public void AssertTrue(Boolean booleanValue, string message)
        {
            WriteMessage("Expected: True  Actual: " + booleanValue + " - Checking the assertion...");
            Assert.IsTrue(booleanValue, message);
        }

        public void AreEqual(string expected, string actual, string message)
        {
            WriteMessage("Expected: " + expected + "  Actual: " + actual + "  - Checking the assertion...");
            Assert.AreEqual(expected, actual, message);
        }

        public void AreEqual(int expected, int actual, string message)
        {
            WriteMessage("Expected: " + expected + "  Actual: " + actual + "  - Checking the assertion...");
            Assert.AreEqual(expected, actual, message);
        }

        public void WriteMessage(string message)
        {
            Console.WriteLine(message);
            GaugeMessages.WriteMessage(message);
        }

        public void NavigateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

    }

}
