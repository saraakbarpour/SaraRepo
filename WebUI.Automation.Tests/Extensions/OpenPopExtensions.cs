using System;
using System.Collections.Generic;
using System.Linq;
using OpenPop.Mime;
using OpenPop.Pop3;

namespace WebUI.Automation.Tests.Extensions
{
	public static class OpenPopExtensions
	{
		public static Pop3Client GetMessages(this Pop3Client client, out List<Message> allMessages)
		{
			var messageCount = client.GetMessageCount();
			allMessages = new List<Message>(messageCount);

			for (var i = messageCount; i > 0; i--)
				allMessages.Add(client.GetMessage(i));

			return client;
		}

		public static Pop3Client GetMessages(this Pop3Client client,
			string fromAddress, string subject, string name, DateTime dateSent, out List<Message> allMessages)
		{
			allMessages = new List<Message>();
			var messageCount = client.GetMessageCount();
			for (var messageNumber = messageCount; messageNumber > 0; messageNumber--)
			{
				var messageHeader = client.GetMessageHeaders(messageNumber);

				Console.WriteLine($"Processing Email {messageNumber} - " +
				$"From:{messageHeader.From.Address}," +
				$"To: {messageHeader.To.First().DisplayName}," +
				$"Date: {messageHeader.DateSent:dd/MM/yyyy HH:mm:ss:ffff (K)}");

				if (messageHeader.From.Address.Equals(fromAddress) &&
					messageHeader.To.First().DisplayName.Equals(name) &&
					messageHeader.Subject.Equals(subject) &&
					messageHeader.DateSent >= dateSent &&
					messageHeader.DateSent < dateSent.AddMinutes(2))
				{
					allMessages.Add(client.GetMessage(messageNumber));
				}
			}
			return client;
		}
	}
}
