using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AsyncVsSyncAPIController.Controllers
{
    [RoutePrefix("async")]
    public class AsyncController : ApiController
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private const string url = "http://www.bing.com/";

        // Notice that I did not use Using on my async service, this is done on purpose,
        // since the HttpClient and WebClient will cause requests to fail in an async environment.
        [Route("getpagecontentlength")]
        public async Task<IHttpActionResult>GetPageContentLength()
        {
            var pageContentLength = 0;
            var pageData = await httpClient.GetStringAsync(new Uri(url));
            await Task.Factory.StartNew(() => pageContentLength = pageData.Length);

            return Ok(pageContentLength);
        }
    }
}