using System;
using System.Configuration;

namespace Automation.Configuration
{
	public static class Settings
	{
		public static string ConnectionString
			=> ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

		public static Uri SiteUrl => new Uri(ConfigurationManager.AppSettings["SiteUrl"]);
		public static string Target => ConfigurationManager.AppSettings["Target"];

		public static TimeSpan PageTimeout
			=> new TimeSpan(0, 0, Convert.ToInt32(ConfigurationManager.AppSettings["PageTimeOut"]));
	}
}