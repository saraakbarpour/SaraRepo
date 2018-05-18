using System.IO;
using OpenPop.Mime;
using OpenPop.Pop3;

namespace WebUI.Automation.Tests.Helpers
{
	public class OpenPopHelper
	{
		private const string EmailFileExtension = ".eml";
		private const string GmailPop3Server = "pop.gmail.com";
		private const int GmailPop3Port = 995;
		private const bool GmailPopSslRequired = true;

		public static Pop3Client CreatePop3Client(string pop3Server, int pop3Port, bool useSsl,
			string username, string password)
		{
			var client = new Pop3Client();
			client.Connect(pop3Server, pop3Port, useSsl);
			client.Authenticate(username, password);
			return client;
		}

		public static Pop3Client CreatePop3Client(string username, string password)
		{
			return CreatePop3Client(GmailPop3Server, GmailPop3Port, GmailPopSslRequired, username, password);
		}

		public static void SaveMessage(Message message, string fileName)
		{
			var filePath = Path.Combine(FileHelper.GetAssemblyDirectoryName(),
				$"{fileName}{EmailFileExtension}");
			var file = new FileInfo(filePath);
			message.Save(file);
		}
	}
}