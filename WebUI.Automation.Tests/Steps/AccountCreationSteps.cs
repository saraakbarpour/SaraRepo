using Automation.Core.SeleniumUtility;
using TechTalk.SpecFlow;
using WebUI.Automation.Pages;

namespace WebUI.Automation.Tests.Steps
{
	[Binding]
	public class AccountCreationSteps : StandardStepsBase
	{
		public AccountCreationSteps(IExtendedWebDriver webDriver, Options options) : base(webDriver, options)
		{
		}
	}
}