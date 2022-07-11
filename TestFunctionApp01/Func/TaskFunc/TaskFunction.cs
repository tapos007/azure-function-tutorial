using System;
using System.IO;
using System.Threading.Tasks;
using BLL.Services;
using BLL.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace TestFunctionApp01.Func.TaskFunc
{
    public class TaskFunction
    {
        private readonly IAppTaskService _appTaskService;

        public TaskFunction(IAppTaskService appTaskService)
        {
            _appTaskService = appTaskService;
        }

        [FunctionName("CreateTask")]
        public async Task<IActionResult> CreateTask(
            [HttpTrigger(AuthorizationLevel.Anonymous,  "post", Route = null)]
            HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Insert Task Work Started");
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            
            var tasks = await _appTaskService.InsertTask(requestBody);

            log.LogInformation("Insert Task Work Ended");

            return new OkObjectResult(tasks);
        }

        [FunctionName("GetTasks")]
        public async Task<IActionResult> GetTasks(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "task")]
            HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Get insert Task Work Started");

            var tasks = await _appTaskService.GetAllTasks();

            log.LogInformation("Get all Task Work Ended");

            return new OkObjectResult(tasks);
        }


        [FunctionName("GetTaskById")]
        public async Task<IActionResult> GetTaskById(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "task/{id}")]
            HttpRequest req,
            ILogger log, int id)
        {
            log.LogInformation("Get a Task Work Started");

            var tasks = await _appTaskService.GetTask(id);

            log.LogInformation("Get a Task Work Ended");

            return new OkObjectResult(tasks);
        }

        [FunctionName("DeleteTask")]
        public async Task<IActionResult> DeleteTask(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "task/{id}")]
            HttpRequest req,
            ILogger log, int id)
        {
            log.LogInformation("Delete Task Work Started");

            var tasks = await _appTaskService.DeleteTask(id);

            log.LogInformation("Delete Task Work Ended");

            return new OkObjectResult(tasks);
        }

        
    }
}