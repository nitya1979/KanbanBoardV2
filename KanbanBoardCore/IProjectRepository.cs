using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KanbanBoardCore
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllProjects(string userName);

        Task<List<Project>> GetAllProjects(string userName, DateTime fromDate, DateTime toDate, int pageNo, int count);

        Task<List<ProjectStage>> GetAllStages(int projectID);

        Task<Project> GetProject(int projectID);

        Task SaveProject(Project project);

        Task SaveStage(ProjectStage stage);
        
    }
}
