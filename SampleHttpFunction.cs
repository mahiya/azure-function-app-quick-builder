using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SampleAzureFunction
{
    public class SampleHttpFunction
    {
        public SampleHttpFunction(IConfiguration config, BlobServiceClient blobServiceClient)
        {
        }

        [FunctionName("SampleHttpFunction")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req,
            ILogger log)
        {
            return new OkObjectResult("OK");
        }
    }
}
