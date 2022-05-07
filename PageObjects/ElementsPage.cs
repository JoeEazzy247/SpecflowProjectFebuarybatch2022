using OpenQA.Selenium;
using SpecflowProjectFebuarybatch2022.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowProjectFebuarybatch2022.PageObjects
{
    public class ElementsPage
    {
        IWebDriver driver;
        public ElementsPage(IWebDriver _driver)
        {
            driver = _driver;
        }


        private IWebElement headertxt => 
            driver.FindMyElement(locator.xpath,$"//div[@class='main-header']");
        private IWebElement textBoxMenu =>
            driver.FindMyElement(locator.xpath,"//*[@id='item-0'][.='Text Box']");


        public string getElementsHeaderTxt() => headertxt.Text;
        public void clickTextBoxMenu() => textBoxMenu.ClickViaJs(driver);
    }
}
