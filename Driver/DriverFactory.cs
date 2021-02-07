using Gauge.CSharp.Lib.Attribute;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using WebDriverManager.DriverConfigs.Impl;

namespace UIAutomationChallenge.Driver
{
    class DriverFactory : BaseClass
    {
        [BeforeSuite]
        public void Setup()
        {
            string browser = Environment.GetEnvironmentVariable("browser");

            switch (browser)
            {
                case "IE":
                    new WebDriverManager.DriverManager().SetUpDriver(new InternetExplorerConfig());
                    driver = new InternetExplorerDriver();
                    break;
                case "FIREFOX":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;
                case "CHROME":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());            
                    driver = new ChromeDriver();
                    break;
            }   
        }

        [AfterSuite]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
