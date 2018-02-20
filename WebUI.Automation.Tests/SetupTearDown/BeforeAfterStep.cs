using System;
using System.IO;
using Automation.Configuration;
using Automation.Core.SeleniumUtility;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace WebUI.Automation.Tests.SetupTearDown
{
	[Binding]
	public class BeforeAfterStep
	{
		private readonly IWebDriver _webDriver;

		public BeforeAfterStep(IWebDriver webDriver)
		{
			_webDriver = webDriver;
		}

		[AfterStep(Order = 0)]
		public void AfterStep()
		{
			SaveScreenshot();
		}

		private void SaveScreenshot()
		{
			var directory = Directory.GetCurrentDirectory();
			var screenshotfileName = Path.GetFileNameWithoutExtension(Path.GetTempFileName()) + Constants.PngFileExt;
			var screenshotFilePath = Path.Combine(directory, Constants.ReportFolderName, screenshotfileName);
			_webDriver.SaveScreenshot(screenshotFilePath);
			Console.WriteLine($"SCREENSHOT[ {screenshotfileName} ]SCREENSHOT");
		}
	}
}