using Automation.Core.SeleniumUtility;
using OpenQA.Selenium.Support.PageObjects;

namespace WebUI.Automation.Pages
{
	public abstract class BasePage
	{
		protected BasePage(IExtendedWebDriver webDriver)
		{
			WebDriver = webDriver;
			WebDriver.WaitUntilPageIsLoaded();
			PageFactory.InitElements(WebDriver, this);
		}

		public string PageUrl { get; set; }

		protected IExtendedWebDriver WebDriver { get; }

		public virtual bool VerifyPage()
		{
			try
			{
				WebDriver.WaitUntilUrlMatches(PageUrl);
			}
			catch
			{
				return false;
			}

			return true;
		}
	}
}