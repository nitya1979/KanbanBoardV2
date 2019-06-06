using AutoMapper;
using KanbanBoardCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
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
        IDbContextTransaction _transacton = null;
        public SqlProjectRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void BeginTranaction()
        {
            this._transacton = this._dbContext.Database.BeginTransaction();
            
        }

        public void CommitTransaction()
        {
            if( this._transacton != null)
            {
                this._transacton.Commit();
                this._transacton = null;
            }
                
        }

        public void Dispose()
        {
            if (_dbContext != null)
                _dbContext.Dispose();

        }

        public Task<KanbanCollection<Project>> GetAllProjects(string userName)
        {
            return Task.Factory.StartNew(() => 
            {
                var count = _dbContext.Project.Where(p => p.CreatedBy == userName).Count();

                var dbProjList =  _dbContext.Project.Where(p => p.CreatedBy == userName)
                                                    .OrderByDescending(k => k.DueDate)
                                                    .ToList();

                List<Project> projectList = new List<Project>();
                foreach (var dbproj in dbProjList)
                {
                    projectList.Add(Mapper.Map<Project>(dbproj));
                }

                return new KanbanCollection<Project>(projectList, count);
            });
        }

        public Task<KanbanCollection<Project>> GetAllProjects(string userName, int pageNo, int count)
        {
            //TODO: fix paging logic
            return Task.Factory.StartNew(() =>
            {
                var totalCount = _dbContext.Project.Where(p => p.CreatedBy == userName).Count();

                var dbProjList = _dbContext.Project
                                           .Where(p => p.CreatedBy == userName)
                                           .OrderByDescending( k => k.DueDate)
                                           .Skip(pageNo * count)
                                           .Take(count);

                List<Project> projectList = new List<Project>();
                foreach (var dbproj in dbProjList)
                {
                    projectList.Add(Mapper.Map<Project>(dbproj));
                }

                return new KanbanCollection<Project>( projectList, totalCount);
            });
        }

        public Task<List<ProjectStage>> GetAllStages(int projectID)
        {
            return Task.Factory.StartNew(() =>
            {
                List<ProjectStage> stages = new List<ProjectStage>();

                foreach (var dbStage in _dbContext.ProjectStage.Where(s => s.ProjectID == projectID).ToList())
                {
                    stages.Add(Mapper.Map<ProjectStage>(dbStage));
                }

                return stages;
            });
        }

        public Task<List<Project>> GetImportant(string userName, int count)
        {
            return Task.Factory.StartNew(() =>
            {
                List<DbProject> dbProjects = _dbContext.Project.Where(p => p.CreatedBy == userName && p.CompletionDate == null)
                                                       .OrderBy(p => p.QuadrantID)
                                                       .ThenBy(p => p.DueDate).Take(count).ToList();

                List<Project> projects = new List<Project>();

                foreach(var dbp in dbProjects)
                {
                    projects.Add(Mapper.Map<Project>(dbp));
                }

                return projects;
            });
             
        }

        public Task<Project> GetProject(int projectID)
        {
            return Task.Factory.StartNew(() =>
            {
                var dbProj = _dbContext.Project.Where(p => p.ProjectID == projectID).FirstOrDefault();

                if (dbProj != null)
                    return Mapper.Map<Project>(dbProj);
                else
                    return null;
                
            });
            
        }

        public Task<List<Quadrant>> GetQuadrants()
        {
            return Task.Factory.StartNew(() =>
            {
                List<Quadrant> quadrants = new List<Quadrant>();
                foreach(var dbq in _dbContext.Quadrants.ToList())
                {
                    quadrants.Add(Mapper.Map<Quadrant>(dbq));

                }

                return quadrants;
            });
        }

        public void RollbackTransaction()
        {
            if(this._transacton != null)
            {
                this._transacton.Rollback();
                this._transacton = null;
            }
        }

        public Task SaveProject(Project project)
        {
            return Task.Factory.StartNew(() =>
            {
                DbProject dbProject = null;

                if (project.ProjectID == 0)
                {
                    dbProject = Mapper.Map<DbProject>(project);
                    dbProject.CreateDate = DateTime.Now;
                    _dbContext.Project.Add(dbProject);
                }
                else
                {
                    dbProject = _dbContext.Project.Where(p => p.ProjectID == project.ProjectID).FirstOrDefault();

                    dbProject.ModifyDate = DateTime.Now;
                    dbProject.ModifiedBy = project.ModifiedBy;
                    dbProject.ProjectName = project.ProjectName;
                    dbProject.Description = project.Description;
                    dbProject.QuadrantID = project.QuadrantID;
                    dbProject.StartDate = project.StartDate;
                    dbProject.DueDate = project.DueDate;
                    dbProject.CompletionDate = project.CompletionDate;

                    _dbContext.Update(dbProject);//.State = EntityState.Modified;
                }

                _dbContext.SaveChanges(true);
                

                project.ProjectID = dbProject.ProjectID;

               //_dbContext.Dispose();
            });
        }

        public Task SaveStage(ProjectStage stage)
        {
           
            return Task.Factory.StartNew(() =>
            {
                DbProjectStage dbStage = Mapper.Map<DbProjectStage>(stage);

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
