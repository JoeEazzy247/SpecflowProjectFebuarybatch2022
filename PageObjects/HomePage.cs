using OpenQA.Selenium;
using SpecflowProjectFebuarybatch2022.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowProjectFebuarybatch2022.PageObjects
{
    public class HomePage
    {
        IWebDriver driver;
        public HomePage(IWebDriver _driver)
        {
            driver = _driver;
        }

        //1. Properties
        //private IWebElement elements(string nameAlias) => driver.FindElement(
        //        By.XPath($"//div[@class='card mt-4 top-card'][.='{nameAlias}']"));

        //private IWebElement elements(string nameAlias) =>
        //    driver.FindMyElement(locator.xpath, $"//div[@class='card mt-4 top-card'][.='{nameAlias}']");

        private IWebElement elements(string nameAlias) =>
            driver.GetMyElement(By.XPath($"//div[@class='card mt-4 top-card'][.='{nameAlias}']")).single;

        //2. Methods or functions
        public void NavigateToSite(string url) => driver.Navigate().GoToUrl(url);
        public void clickElements(string element) => elements(element).ClickViaJs(driver);
    }
}
