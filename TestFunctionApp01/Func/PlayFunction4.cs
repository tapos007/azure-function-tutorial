using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace TestFunctionApp01.Func
{
    public class PlayFunction4
    {
        [FunctionName("PlayFunction4")]
        public void Run([ServiceBusTrigger("ac-queue")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
