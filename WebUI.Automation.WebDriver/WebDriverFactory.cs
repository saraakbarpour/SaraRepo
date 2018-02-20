using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;

namespace WebUI.Automation.WebDriver
{
	public class WebDriverFactory
	{
		private string _key;

		private IWebDriver _webDriver;

		public IWebDriver Create(string key)
		{
			if (_key == key && _webDriver != null) return _webDriver;

			_key = key;
			_webDriver = DoCreate(key);
			return _webDriver;
		}

		private IWebDriver DoCreate(string key)
		{
			switch (key)
			{
				case "Firefox":
					var profile = new FirefoxProfile {AcceptUntrustedCertificates = true};
					return new FirefoxDriver(profile);
				case "Internet Explorer":
				case "IE":
					var ieOptions = new InternetExplorerOptions {IntroduceInstabilityByIgnoringProtectedModeSettings = true};
					return new InternetExplorerDriver(ieOptions);
				case "Chrome":
					var chromeOptions = new ChromeOptions();
					chromeOptions.AddExcludedArgument("ignore-certificate-errors");
					chromeOptions.AddUserProfilePreference("credentials_enable_service", false);
					chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
					return new ChromeDriver(chromeOptions);
				case "Safari":
					return new SafariDriver();
			}

			throw new ArgumentException("Invalid browser key", nameof(key));
		}
	}
}