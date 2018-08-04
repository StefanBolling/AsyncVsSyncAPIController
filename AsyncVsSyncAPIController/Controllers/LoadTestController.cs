using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AsyncVsSyncAPIController.Controllers
{
    [RoutePrefix("loadtest")]
    public class LoadTestController : ApiController
    {
        private const string syncLocalUrl = "http://localhost:50137/sync/getgooglepagelength";
        private const string asyncLocalUrl = "http://localhost:50137/async/getgooglepagelength";

        [Route("sync/{numberOfPageLoads}")]
        public IHttpActionResult GetSyncLoadTime(int numberOfPageLoads)
        {
            var startTime = DateTime.Now;
            GetDataFromServiceAndDoNothingWithIt(numberOfPageLoads, syncLocalUrl);
            var executionTime = DateTime.Now - startTime;

            return Ok(executionTime.TotalSeconds);
        }

        [Route("async/{numberOfPageLoads}")]
        public IHttpActionResult GetAsyncLoadTime(int numberOfPageLoads)
        {
            var startTime = DateTime.Now;
            GetDataFromServiceAndDoNothingWithIt(numberOfPageLoads, asyncLocalUrl);
            var executionTime = DateTime.Now - startTime;

            return Ok(executionTime.TotalSeconds);
        }

        private static void GetDataFromServiceAndDoNothingWithIt(int numberOfPageLoads, string url)
        {
            Parallel.For(0, numberOfPageLoads, index =>
            {
                using (var httpClient = new HttpClient())
                {
                    var googleDataVariableForDebuggingUse = httpClient.GetStringAsync(url).Result;
                }
            });
        }
    }
}