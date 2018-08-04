using System.Net.Http;
using System.Web.Http;

namespace AsyncVsSyncAPIController.Controllers
{
    [RoutePrefix("sync")]
    public class SyncController : ApiController
    {
        private const string googleUrl = "https://www.google.com";

        [Route("getgooglepagelength")]
        public IHttpActionResult GetGooglePageLength()
        {
            using (var httpClient = new HttpClient())
            {
                var googleData = httpClient.GetStringAsync(googleUrl).Result;
                return Ok(googleData.Length);
            }
        }
    }
}