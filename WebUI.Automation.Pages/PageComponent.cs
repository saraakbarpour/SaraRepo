using Automation.Core.SeleniumUtility;
using OpenQA.Selenium.Support.PageObjects;

namespace WebUI.Automation.Pages
{
	public class PageComponent
	{
		public PageComponent(IExtendedWebDriver webDriver)
		{
			WebDriver = webDriver;
			PageFactory.InitElements(webDriver, this);
		}

		public IExtendedWebDriver WebDriver { get; set; }
	}
}