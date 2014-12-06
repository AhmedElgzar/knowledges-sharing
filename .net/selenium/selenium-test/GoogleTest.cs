using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace selenium_test
{
    /// <summary>
    /// Summary description for GoogleTest
    /// </summary>
    [TestClass]
    public class GoogleTest
    {               
        [TestMethod]
        public void SearchTest()
        {
            //Navigate to google
            var driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://google.com");

            //type text
            var searchbox = driver.FindElementById("gbqfq");
            searchbox.SendKeys("selenium");
            //click search
            var searchBtn = driver.FindElementById("gbqfb");
            searchBtn.Click();

            //check results
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementExists(By.Id("rso"))); //rso is list of results id
                var list = driver.FindElementById("rso");

                //find selenium website
                var results = list.FindElements(By.ClassName("vurls"));
                foreach (var result in results)
                {
                    if (result.Text == "www.seleniumhq.org/")
                    {
                        //website found
                        Assert.IsTrue(true);
                        driver.Quit();
                        return;
                    }
                }
                //website not found
                Assert.IsTrue(false);
            }
            catch (WebDriverTimeoutException e)
            {
                Assert.Fail("No results found");
            }
            //I am lazy to close windows :)
            driver.Quit();
        }
    }
}
