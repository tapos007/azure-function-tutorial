using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BLL.ViewModel;
using DLL.Models;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public interface IAppTaskService
    {

        Task<List<AppTask>> GetAllTasks();
        Task<AppTask> GetTask(int id);
        Task<AppTask> InsertTask(string info);
        Task<AppTask> DeleteTask(int id);
    }

    public class AppTaskService : IAppTaskService
    {
        private readonly ApplicationDbContext _context;

        public AppTaskService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<AppTask>> GetAllTasks()
        {
            return await _context.AppTasks.ToListAsync();
        }

        public async Task<AppTask> GetTask(int id)
        {
            var resut = await _context.AppTasks.FirstOrDefaultAsync(x => x.Id == id);
            return resut;
        }

        public async Task<AppTask> InsertTask(string info)
        {
            var input = JsonSerializer.Deserialize<CreateTaskModel>(info);
            var task = new AppTask()
            {
                Description = input.Description,
                IsDone = false,
                CreatedOn = input.CreatedOn
            };
            var result = await _context.AppTasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return task;

        }

        public async Task<AppTask> DeleteTask(int id)
        {
            var result = await _context.AppTasks.FirstOrDefaultAsync(x=>x.Id == id);
             _context.AppTasks.Remove(result);
            await _context.SaveChangesAsync();
            return result;
        }
    }
}