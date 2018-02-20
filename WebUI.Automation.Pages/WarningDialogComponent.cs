using System;
using System.Threading;
using Automation.Core.SeleniumUtility;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace WebUI.Automation.Pages
{
	public class WarningDialogComponent : PageComponent
	{
		public WarningDialogComponent(IExtendedWebDriver webDriver) : base(webDriver)
		{
		}

		[FindsBy(How = How.ClassName, Using = "ngdialog")]
		public IWebElement Dialog { get; set; }

		[FindsBy(How = How.CssSelector, Using = ".ngdialog .pop-up-message")]
		public IWebElement Message { get; set; }

		[FindsBy(How = How.CssSelector, Using = "[data-auto=ConfirmDialogOkButton]")]
		public IWebElement OkButton { get; set; }

		[FindsBy(How = How.CssSelector, Using = "[data-auto=ConfirmDialogCancelButton]")]
		public IWebElement CancelButton { get; set; }

		public void ClickOkButton()
		{
			OkButton.Click();
			Thread.Sleep(400);
		}

		public void ClickCancelButton()
		{
			CancelButton.Click();
			Thread.Sleep(400);
		}

		public void WaitUntilVisible()
		{
			WebDriver.Wait(driver => Dialog.Displayed);
		}

		public void VerifyMessage(string expectedMessage)
		{
			try
			{
				WebDriver.Wait(driver => Message.Text.Equals(expectedMessage));
			}
			catch (WebDriverTimeoutException)
			{
				throw new ArgumentException($"Expected warning dialog to display: \"{expectedMessage}\"");
			}
		}
	}
}