using System;
using System.IO;
using System.Threading.Tasks;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace TestFunctionApp01.Func
{
    public class PlayFunction2
    {
        private readonly ICustomerService _customerService;

        public PlayFunction2(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [FunctionName("PlayFunction2")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]
            HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Customer Service code started");

            var customers = _customerService.GetCustomersData();
            log.LogInformation("Customer Service code ended");
            return new OkObjectResult(customers);
        }
    }
}