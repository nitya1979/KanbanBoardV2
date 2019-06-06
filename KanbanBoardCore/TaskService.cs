using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KanbanBoardCore
{
    public class TaskService
    {
        ITaskRepository taskRepository = null;

        public TaskService(ITaskRepository taskRepository_)
        {
            this.taskRepository = taskRepository_;
        }

        public async Task<List<Priority>> GetPriorities()
        {
            return await taskRepository.GetPriority();
        }

        public async Task SaveTask(ProjectTask task)
        {
            await taskRepository.SaveTask(task);
        }

        public async Task<ProjectTask> GetTask(int taskId)
        {
            return await taskRepository.GetTask(taskId);
        }

        public async Task<List<ProjectTaskView>> GetTasks(string userName, int days)
        {
            return await taskRepository.GetByDueDate(userName, days);
        }
    }
}
