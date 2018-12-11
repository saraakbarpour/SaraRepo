using System.Net;

namespace WebUI.Automation.Tests.Resources
{
	public class HttpResponseInfo
	{
		public HttpStatusCode StatusCode { get; set; }
		public string StatusDescription { get; set; }
		public string Content { get; set; }
	}
}