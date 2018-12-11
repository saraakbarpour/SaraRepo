using Automation.Configuration;
using WebUI.Automation.Tests.ApiClient;
using WebUI.Automation.Tests.Resources;

namespace WebUI.Automation.Tests.Helpers
{
	public class ConsumerHelper
	{
		public void AddConsumer(string email, string password, string fullName)
		{
			var payload = new AddConsumerResource
			{
				Email = email,
				Password = password,
				FullName = fullName
			};
			BaseApiClient.PostAsync(null, $"{Settings.SiteUrl}{Constants.AddConsumerApiUrl}", payload)
				.Wait(Constants.ApiCallDelay);
		}
	}
}