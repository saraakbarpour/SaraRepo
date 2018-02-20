using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace WebUI.Automation.Pages
{
	public static class SearchContextExtensions
	{
		public static IWebElement FindElementByDataAuto(this ISearchContext element, string dataAuto)
		{
			return element.FindElement(By.CssSelector($"[data-auto='{dataAuto}']"));
		}

		public static ReadOnlyCollection<IWebElement> FindElementsByDataAuto(this ISearchContext element, string dataAuto)
		{
			return element.FindElements(By.CssSelector($"[data-auto='{dataAuto}']"));
		}
	}
}