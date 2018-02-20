using Automation.Core.Reports;
using TechTalk.SpecFlow;

namespace WebUI.Automation.Tests.SetupTearDown
{
	[Binding]
	public class BeforeAfterTestRun
	{
		[BeforeTestRun(Order = 0)]
		public static void BeforeTestRun()
		{
			// TODO:
		}

		[AfterTestRun(Order = 0)]
		public static void AfterTestRun()
		{
			ReportUtility.CopyReportJavascriptFiles();
		}
	}
}