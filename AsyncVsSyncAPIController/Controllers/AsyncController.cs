using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AsyncVsSyncAPIController.Controllers
{
    [RoutePrefix("async")]
    public class AsyncController : ApiController
    {
        private readonly HttpClient httpClient = new HttpClient();
        private const string googleUrl = "https://www.google.com";

        // Notice that I did not use Using on my async service, this is done on purpose,
        // since the HttpClient and WebClient will cause requests to fail in an async environment.
        [Route("getgooglepagelength")]
        public async Task<IHttpActionResult>GetGooglePageLength()
        {
            var googleData = await httpClient.GetStringAsync(new Uri(googleUrl));

            return Ok(googleData.Length);
        }
    }
}