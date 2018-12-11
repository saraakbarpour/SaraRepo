using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebUI.Automation.Tests.Resources;

namespace WebUI.Automation.Tests.ApiClient
{
	public class BaseApiClient
	{
		public BaseApiClient()
		{
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
		}

		public static async Task<HttpResponseInfo> PostAsync(string token, string url, object inputModel,
			string contentType = "application/json")
		{
			var body = JsonConvert.SerializeObject(inputModel);

			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

				var response = await client.PostAsync(url, new StringContent(body, Encoding.UTF8, contentType));

				return new HttpResponseInfo
				{
					StatusCode = response.StatusCode,
					StatusDescription = response.ReasonPhrase,
					Content = response.Content.ReadAsStringAsync().Result
				};
			}
		}
	}
}