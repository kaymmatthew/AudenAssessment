using AudenAssessment.Drivers;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace AudenAssessment.Hooks
{
    [Binding]
    public sealed class Hooks : DriverHelper
    {
        IObjectContainer objectContainer;
        public Hooks(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var options = new ChromeOptions();
            options.AddArguments("--start-maximized", "--incognito");
            new DriverManager().SetUpDriver(new ChromeConfig());
            browser = new ChromeDriver(options);
            objectContainer.RegisterInstanceAs<IWebDriver>(browser);
            browser.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
            browser.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(10);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (browser != null)
            {
                browser.Close();
                browser.Quit();
            }
            browser = null;
        }
    }
}
