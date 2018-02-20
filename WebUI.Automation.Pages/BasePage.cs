﻿using Automation.Core.SeleniumUtility;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace WebUI.Automation.Pages
{
	public abstract class BasePage
	{
		protected BasePage(IExtendedWebDriver webDriver)
		{
			WebDriver = webDriver;
			Toast = new ToastComponent(WebDriver);
			WarningDialog = new WarningDialogComponent(WebDriver);

			WebDriver.WaitUntilPageIsLoaded();
			PageFactory.InitElements(WebDriver, this);
		}

		public WarningDialogComponent WarningDialog { get; set; }

		[FindsBy(How = How.CssSelector, Using = "[data-auto='PageTitle']")]
		public IWebElement PageTitle { get; set; }

		public string PageTitleName { get; set; }

		protected IWebElement LoadingOverlay => WebDriver.FindElementByDataAuto("LoadingOverlay");

		protected IExtendedWebDriver WebDriver { get; }
		public ToastComponent Toast { get; }

		public virtual bool VerifyPage()
		{
			WebDriver.WaitUntilElementExists(PageTitle);

			return PageTitle.Text.Equals(PageTitleName);
		}

		public void WaitForLoadingToComplete()
		{
			WebDriver.Wait(driver => !LoadingOverlay.Displayed);
		}
	}
}