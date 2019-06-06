using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KanbanBoardCore
{
    public interface ITaskRepository : ITransactable
    {
        Task<List<ProjectTask>> GetByProject(int projectID);

        Task<List<ProjectTaskView>> GetByDueDate(string userName, int days);

        Task<List<ProjectTask>> GetAllTasks(string userName, bool includeCompleted);

        Task<ProjectTask> GetTask(int taskID);

        Task SaveTask(ProjectTask task);

        Task<List<Priority>> GetPriority();

        Task<List<ProjectStage>> GetStages(int projectID);

    }
}
