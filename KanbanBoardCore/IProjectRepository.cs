using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KanbanBoardCore
{
    public interface IProjectRepository : ITransactable
    {
        Task<KanbanCollection<Project>> GetAllProjects(string userName);

        Task<KanbanCollection<Project>> GetAllProjects(string userName, int pageNo, int count);

        Task<List<ProjectStage>> GetAllStages(int projectID);

        Task<Project> GetProject(int projectID);

        Task SaveProject(Project project);

        Task SaveStage(ProjectStage stage);

        Task<List<Quadrant>> GetQuadrants();

        Task<List<Project>> GetImportant(string userName, int count);
    }
}
