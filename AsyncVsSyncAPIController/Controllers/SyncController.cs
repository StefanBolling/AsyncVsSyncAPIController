using System.Net.Http;
using System.Web.Http;

namespace AsyncVsSyncAPIController.Controllers
{
    [RoutePrefix("sync")]
    public class SyncController : ApiController
    {
        private const string url = "http://www.bing.com/";

        [Route("getpagecontentlength")]
        public IHttpActionResult GetPageContentLength()
        {
            using (var httpClient = new HttpClient())
            {
                var pageData = httpClient.GetStringAsync(url).Result;
                return Ok(pageData.Length);
            }
        }
    }
}