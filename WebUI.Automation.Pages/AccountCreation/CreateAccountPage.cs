using System;
using Automation.Core.SeleniumUtility;

namespace WebUI.Automation.Pages.AccountCreation
{
	public class CreateAccountPage : BasePage
	{
		public CreateAccountPage(IExtendedWebDriver webDriver, Options options) : base(webDriver)
		{
			PageUrl = new Uri(options.SiteUri, "Account/Create").ToString();
		}
	}
}