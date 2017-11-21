using AutoMapper;
using KanbanBoardCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace KanbanBoard.SqlRepository
{
    public class SqlProjectRepository : IProjectRepository, IDisposable
    {
        ApplicationDbContext _dbContext = null;
        public SqlProjectRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose()
        {
            if (_dbContext != null)
                _dbContext.Dispose();

        }

        public Task<List<KanbanBoardCore.Project>> GetAllProjects(string userName)
        {
            return Task.Factory.StartNew(() => 
            {
                var dbProjList =  _dbContext.Project.Where(p => p.CreatedBy == userName).ToList();

                List<KanbanBoardCore.Project> projectList = new List<KanbanBoardCore.Project>();
                foreach (var dbproj in dbProjList)
                {
                    projectList.Add(Mapper.Map<KanbanBoardCore.Project>(dbproj));
                }

                return projectList;
            });
        }

        public Task<List<KanbanBoardCore.Project>> GetAllProjects(string userName, DateTime fromDate, DateTime toDate, int pageNo, int count)
        {

            return Task.Factory.StartNew(() =>
            {
                var dbProjList = _dbContext.Project
                                           .Where(p => p.CreatedBy == userName && p.DueDate >= fromDate && p.DueDate <= toDate)
                                           .Skip(pageNo * count)
                                           .Take(count);

                List<KanbanBoardCore.Project> projectList = new List<KanbanBoardCore.Project>();
                foreach (var dbproj in dbProjList)
                {
                    projectList.Add(Mapper.Map<KanbanBoardCore.Project>(dbproj));
                }

                return projectList;
            });
        }

        public Task<List<KanbanBoardCore.ProjectStage>> GetAllStages(int projectID)
        {
            return Task.Factory.StartNew(() =>
            {
                List<KanbanBoardCore.ProjectStage> stages = new List<KanbanBoardCore.ProjectStage>();

                foreach (var dbStage in _dbContext.ProjectStage.Where(s => s.ProjectID == projectID).ToList())
                {
                    stages.Add(Mapper.Map<KanbanBoardCore.ProjectStage>(dbStage));
                }

                return stages;
            });
        }

        public Task<KanbanBoardCore.Project> GetProject(int projectID)
        {
            return Task.Factory.StartNew(() =>
            {
                var dbProj = _dbContext.Project.Where(p => p.ProjectID == projectID).FirstOrDefault();

                if (dbProj != null)
                    return Mapper.Map<KanbanBoardCore.Project>(dbProj);
                else
                    return null;
                
            });
            
        }

        public Task SaveProject(KanbanBoardCore.Project project)
        {
            return Task.Factory.StartNew(() =>
            {
                Project dbProject = Mapper.Map<Project>(project);
                
                if (project.ProjectID == 0)
                {
                    dbProject.CreateDate = DateTime.Now;
                    _dbContext.Project.Add(dbProject);
                }
                else
                {
                    dbProject.ModifyDate = DateTime.Now;
                    _dbContext.Entry<Project>(dbProject).State = EntityState.Modified;
                }

                _dbContext.SaveChanges(true);
                

                project.ProjectID = dbProject.ProjectID;

               //_dbContext.Dispose();
            });
        }

        public Task SaveStage(KanbanBoardCore.ProjectStage stage)
        {
           
            return Task.Factory.StartNew(() =>
            {
                ProjectStage dbStage = Mapper.Map<ProjectStage>(stage);

                if (dbStage.StageID == 0)
                {
                    dbStage.CreateDate = DateTime.Now;
                    _dbContext.ProjectStage.Add(dbStage);
                }
                else
                {
                    dbStage.ModifyDate = DateTime.Now;
                    _dbContext.ProjectStage.Attach(dbStage);
                }
                _dbContext.SaveChanges();

                stage.StageID = dbStage.StageID;
            });
        }
    }   
}
