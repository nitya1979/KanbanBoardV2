using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace KanbanBoardCore
{
    public class ProjectService
    {
        private IProjectRepository _repository = null;

        public ProjectService(IProjectRepository repository)
        {
            this._repository = repository;

        }
        public async Task<List<Project>> GetAllProjects(string userName)
        {
           return await _repository.GetAllProjects(userName);
        }

        public async Task<List<Project>> GetAllProjects(string userName, DateTime fromDate, DateTime toDate, int pageNo, int count)
        {
            return await _repository.GetAllProjects(userName, fromDate, toDate, pageNo, count);
            
        }

        public async Task<Project> GetProject(int projectID)
        {
            return await _repository.GetProject(projectID);
        }

        public async Task SaveProject(Project project)
        {
            try
            {
                var isNewProject = project.ProjectID == 0;
                _repository.BeginTranaction();

                await _repository.SaveProject(project);

                if (isNewProject)
                {
                    ProjectStage backLog = new ProjectStage { StageName = "Backlog", Order = 1, ProjectID=project.ProjectID, CreatedBy = project.CreatedBy };
                    ProjectStage inProgress = new ProjectStage { StageName = "InProgress", Order = 2, ProjectID = project.ProjectID, CreatedBy = project.CreatedBy };
                    ProjectStage completed = new ProjectStage { StageName = "Completed", Order = 3, ProjectID = project.ProjectID, CreatedBy = project.CreatedBy };

                    await _repository.SaveStage(backLog);
                    await _repository.SaveStage(inProgress);
                    await _repository.SaveStage(completed);
                }

                _repository.CommitTransaction();
            }
            catch(Exception ex)
            {
                _repository.RollbackTransaction();
                throw;
            }


        }

        public async Task SaveStage(ProjectStage stage)
        {
            await _repository.SaveStage(stage);
        }


    }
}
