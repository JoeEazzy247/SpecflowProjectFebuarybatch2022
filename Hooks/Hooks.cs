using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecflowProjectFebuarybatch2022.Drivers;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace SpecflowProjectFebuarybatch2022.Hooks
{
    [Binding]
    public sealed class Hooks : DriverHelper
    {
        IObjectContainer container;
        public Hooks(IObjectContainer _container)
        {
            container = _container;
        }

        [BeforeScenario()]
        public void FirstBeforeScenario()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            container.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }
    }
}