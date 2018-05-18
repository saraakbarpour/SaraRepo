using System;
using System.Diagnostics;
using System.Threading;

namespace WebUI.Automation.Tests.Helpers
{
	public class TestWaiter
	{
		public bool WaitFor(Func<bool> condition, int maxWaitTimeInMilliSeconds)
		{
			var startTime = DateTime.Now;

			Console.ForegroundColor = ConsoleColor.Cyan;

			WriteToOutput("Starts polling...");

			var result = condition();

			while (!result && DateTime.Now.Subtract(startTime).TotalMilliseconds < maxWaitTimeInMilliSeconds)
			{
				Thread.Sleep(TimeSpan.FromSeconds(5));
				WriteToOutput("Waiting for the condition to be true...");
				result = condition();
			}

			return result;
		}

		private void WriteToOutput(string msg)
		{
			Debug.WriteLine($"[{DateTime.Now:yy/MM/dd hh:mm:ss tt}] [TestWaiter] : {msg}");
		}
	}
}