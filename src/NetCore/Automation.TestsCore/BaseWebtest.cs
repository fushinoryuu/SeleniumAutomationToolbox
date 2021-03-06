using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Automation.SeleniumCore;
using Automation.SeleniumCore.Utils;
using Automation.FrameworkCore.Pages;
using Automation.FrameworkCore.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Automation.TestsCore
{
    [TestFixture, Parallelizable]
    public abstract class BaseWebtest
    {
        protected IConfigurationRoot Configuration { get; }
        protected IRunSelenium Runner;
        protected IHomePage HomePage;

        protected BaseWebtest()
        {
            // Load config file
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
        }

        [SetUp]
        public void Setup()
        {
            Runner = new RunSelenium(Configuration);
            HomePage = new HomePage(Runner);
        }

        [TearDown]
        public void Teardown()
        {
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;

            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (testStatus)
            {
                case TestStatus.Passed:
                    Console.WriteLine("Good Job!");
                    break;
                default:
                    Runner.TakeAndSaveScreenshot(Configuration, TestContext.CurrentContext.Test.Name);
                    break;
            }

            Runner.Cleanup();
        }
    }
}