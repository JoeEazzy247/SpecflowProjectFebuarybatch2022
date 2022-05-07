using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecflowProjectFebuarybatch2022.Drivers;
using SpecflowProjectFebuarybatch2022.PageObjects;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
//using TechTalk.SpecFlow.Assist

namespace SpecflowProjectFebuarybatch2022.StepDefinitions
{
    [Binding]
    public class DemoQatestStepDefinitions 
    {
        string url => "http://demoqa.com";
        HomePage homePage;
        ElementsPage elementsPage;
        TextBoxPage textBoxPage;
        ScenarioContext scenarioContext;
        public DemoQatestStepDefinitions(IObjectContainer container)
        {
            homePage = container.Resolve<HomePage>();
            elementsPage = container.Resolve<ElementsPage>();
            textBoxPage = container.Resolve<TextBoxPage>();
            scenarioContext = container.Resolve<ScenarioContext>();
        }

        [Given(@"I am on demoqa\.com")]
        public void GivenIAmOnDemoqa_Com()
        {
            homePage.NavigateToSite(url);
        }

        [When(@"I click '(.*)'")]
        public void WhenIClickElements(string nameAlias)
        {
            homePage.clickElements(nameAlias);
        }

        [Then(@"I am on (.*) page")]
        public void ThenIAmOnElementsPage(string expectedValue)
        {
            string actualValue = elementsPage.getElementsHeaderTxt();

            Assert.AreEqual(expectedValue, actualValue);
        }

        [When(@"I click textbox menu")]
        public void WhenIClickTextboxMenu()
        {
            elementsPage.clickTextBoxMenu();
        }

        [When(@"I enter firstname (.*)")]
        public void WhenIEnterFirstname(string fName)
        {
            textBoxPage.EnterFullName(fName);
        }

        [When(@"I enter email (.*)")]
        public void WhenIEnterEmail(string email)
        {
            textBoxPage.EnterEmail(email);
        }

        [When(@"I enter address details")]
        public void WhenIEnterAddressDetails(Table table)
        {
            var currentAddress = table.Rows[0]["currentAddress"];
            var parmanentAddress = table.Rows[0]["parmanentAddress"];

            textBoxPage
                .EnterCurrentAndParmanentAddress(currentAddress, parmanentAddress);
            
            Thread.Sleep(5000);
        }

        [When(@"I enter the following address details")]
        public void WhenIEnterTheFollowingAddressDetails(Table table)
        {
            //Basic Method 0
            //var currentAddress = table.Rows[0]["currentAddress"];
            //var parmanentAddress = table.Rows[0]["parmanentAddress"];

            //Method 1: Using CreateInstance
            //var tableinfo = table.CreateInstance<tableInfo>();

            //Method 2: Using Create dynamic instance
            //dynamic tableinfo = table.CreateDynamicInstance();

            //Method 3: Using generated properties on the fly
            //var tableinfo = 
            //    table.CreateInstance<(string currentAddress, string parmanentAddress)>();

            //Method 4
            //var tableinfo = new Dictionary<string, string>();
            //var info = table.Rows[0]["currentAddress"];
            //var info2 = table.Rows[0]["parmanentAddress"];
            //tableinfo.Add("currentAddress", info);
            //tableinfo.Add("parmanentAddress", info2);

            //Method 5
            scenarioContext.Add("currentAddress", table.Rows[0]["currentAddress"]);
            scenarioContext.Add("parmanentAddress", table.Rows[0]["parmanentAddress"]);
            //var info = table.Rows[0]["currentAddress"];
            //var info2 = table.Rows[0]["parmanentAddress"];

            //tableinfo.Add("currentAddress", info);
            //tableinfo.Add("parmanentAddress", info2);

            textBoxPage
                .EnterCurrentAndParmanentAddress(
                scenarioContext.Get<string>("currentAddress"), 
                scenarioContext.Get<string>("parmanentAddress"));
        }
        public class tableInfo
        {
            public string currentAddress { get; set; }
            public string parmanentAddress { get; set; }
        }
    }
}
