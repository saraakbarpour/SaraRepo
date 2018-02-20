using System;
using Automation.Core.SeleniumUtility;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace WebUI.Automation.Pages
{
	public class ToastComponent : PageComponent
	{
		public ToastComponent(IExtendedWebDriver webDriver) : base(webDriver)
		{
		}

		[FindsBy(How = How.Id, Using = "toast-container")]
		public IWebElement ToastContainer { get; set; }

		[FindsBy(How = How.CssSelector, Using = "#toast-container .toast")]
		public IWebElement Toast { get; set; }

		public void VerifyToastMessage(string expectedMessage)
		{
			try
			{
				WebDriver.Wait(driver => Toast.FindElement(By.CssSelector(".toast-message > div")).Text.Equals(expectedMessage));
			}
			catch (WebDriverTimeoutException)
			{
				throw new ArgumentException($"Expected toast to display: \"{expectedMessage}\"");
			}
		}
	}
}