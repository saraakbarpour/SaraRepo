using TechTalk.SpecFlow;

namespace WebUI.Automation.Tests.SetupTearDown
{
	[Binding]
	public class BeforeAfterFeature
	{
		[BeforeFeature(Order = 0)]
		public static void BeforeFeature()
		{
		}

		[AfterFeature(Order = 0)]
		public static void AfterFeature()
		{
		}
	}
}