using System;
using System.IO;
using System.Reflection;

namespace WebUI.Automation.Tests.Helpers
{
	public class FileHelper
	{
		public static string GetAssemblyDirectoryName()
		{
			var codeBase = Assembly.GetExecutingAssembly().CodeBase;
			var uri = new UriBuilder(codeBase);
			var path = Uri.UnescapeDataString(uri.Path);
			return Path.GetDirectoryName(path);
		}
	}
}