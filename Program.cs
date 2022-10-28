using System;
using log4net;
using log4net.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace tesk2_itechart
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            // Configuring log4net
            BasicConfigurator.Configure();
            
            // Creating a Logger
            ILog logger =  LogManager.GetLogger(typeof(Program));
            
            // Initiliazing Chrome Driver
            var webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();
            
            // Setting Page Load Timeout
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(25);
            
            // Navigating to a page
            webDriver.Navigate().GoToUrl($"https://www.google.com/");
            
            // Writing the search query
            var searchField = webDriver.FindElement(By.Name("q"));
            searchField.SendKeys("Hello World");
            
            // Clicking Google Search button
            var searchBtn = webDriver.FindElement(By.Name("btnK"));
            searchBtn.Click();
            
            // Logging the endresult
            logger.Info(webDriver.Title);
            
        }
    }
}