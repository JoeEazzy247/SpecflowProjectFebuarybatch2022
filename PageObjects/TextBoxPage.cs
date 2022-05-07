using OpenQA.Selenium;
using SpecflowProjectFebuarybatch2022.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowProjectFebuarybatch2022.PageObjects
{
    public class TextBoxPage
    {
        IWebDriver driver;
        public TextBoxPage(IWebDriver _driver)
        {
            driver = _driver;
        }

        //1. Properties
        private IWebElement headertxt =>
            driver.FindMyElement(locator.xpath,$"//div[@class='main-header']");
        private IWebElement fullName => 
            driver.FindMyElement(locator.id, "userName");
        private IWebElement email => 
            driver.FindMyElement(locator.id, "userEmail");
        private IWebElement currentAddress => 
            driver.FindMyElement(locator.id, "currentAddress");
        private IWebElement permanentAddress => 
            driver.FindMyElement(locator.id, "permanentAddress");


        //2. Method or function
        public string getTextBoxHeaderTxt() => headertxt.Text;
        public void EnterFullName(string value) => fullName.SendKeys(value);
        public void EnterEmail(string value)=> email.SendKeys(value);
        public void EnterCurrentAndParmanentAddress(string caddress, string paddress)
        {
            //currentAddress.SendKeys(caddress);
            //permanentAddress.SendKeys(paddress);

            currentAddress.Entertxt(caddress);
            permanentAddress.Entertxt(paddress);
        }
    }
}
