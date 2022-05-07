using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowProjectFebuarybatch2022.Extensions
{
    public static class CustomExtensions 
    {
        /// <summary>
        /// This method allow to click an element via javascript
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="element"></param>
        public static void ClickViaJs(this IWebElement element, IWebDriver driver)
        {
            ((IJavaScriptExecutor)driver)
                .ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            element.Click();
        }

        /// <summary>
        /// This is a method to click element via js 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="driver"></param>
        public static void ClickElementViaJs(this IWebElement element, IWebDriver driver)
        {
            ((IJavaScriptExecutor)driver)
                .ExecuteScript("arguments[0].click();", element);
        }

        /// <summary>
        /// This method allows for scrolling into view of element and enter text
        /// </summary>
        /// <param name="element"></param>
        /// <param name="driver"></param>
        /// <param name="value"></param>
        public static void Entertxt(this IWebElement element, IWebDriver driver, string value)
        {
            ((IJavaScriptExecutor)driver)
                .ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            element.SendKeys(value);
        }

        /// <summary>
        /// method which allow for entering text without scrolling
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void Entertxt(this IWebElement element, string value)
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            element.SendKeys(value);
        }

        public static IWebElement FindMyElement(this IWebDriver driver,locator locator, string element)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            if (locator == locator.id)
            {
                return wait.Until(x => x.FindElement(By.Id(element)));
            }
            else if(locator == locator.name)
            {
                return wait.Until(x => x.FindElement(By.Name(element)));
            }
            else if (locator == locator.xpath)
            {
                return wait.Until(x => x.FindElement(By.XPath(element)));
            }
            return FindMyElement(driver,locator, element);
        }

        public static (IWebElement single, IList<IWebElement> multiple) GetMyElement(this IWebDriver driver, By element1)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            return (wait.Until(x=>x.FindElement(element1)), 
                wait.Until(x => x.FindElements(element1)));
        }
    }

    public enum locator
    {
        id,
        name,
        xpath
    }
}
