using System;
using Automation.Configuration;
using Automation.Core.SeleniumUtility;
using BoDi;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using WebUI.Automation.Pages;
using WebUI.Automation.WebDriver;

namespace WebUI.Automation.Tests.SetupTearDown
{
	[Binding]
	public class BeforeAfterScenario
	{
		private readonly IObjectContainer _objectContainer;

		private readonly WebDriverFactory _webDriverFactory = new WebDriverFactory();
		private Options _options;
		private IExtendedWebDriver _webDriver;

		public BeforeAfterScenario(IObjectContainer objectContainer)
		{
			switch (Settings.Target)
			{
				case "Chrome":
				case "IE":
				case "Firefox":
					_objectContainer = objectContainer;
					break;
				default:
					throw new PlatformNotSupportedException(
						$"Your target '{Settings.Target}' is not supported");
			}
		}

		[BeforeScenario(Order = 0)]
		public void BeforeScenario()
		{
			RegisterOptions();
			RegisterWebDriver();
			_webDriver.MaximiseWindow();
		}

		[AfterScenario(Order = 0)]
		public void AfterScenarioCloseWebDriver()
		{
			DisposeWebDriver();
		}

		private void RegisterOptions()
		{
			_options = new Options {SiteUri = Settings.SiteUrl};
			_objectContainer.RegisterInstanceAs(_options);
		}

		private void RegisterWebDriver()
		{
			var webDriver = _webDriverFactory.Create(Settings.Target);
			_webDriver =
				new ExtendedWebDriver(webDriver, new ExtendedWebDriverOptions {Timeout = Settings.PageTimeout});
			_objectContainer.RegisterInstanceAs(_webDriver);
			_objectContainer.RegisterInstanceAs<IWebDriver>(_webDriver);
		}

		private void DisposeWebDriver()
		{
			_webDriver.Close();
			_webDriver.Quit();
			_webDriver.Dispose();
		}
	}
}