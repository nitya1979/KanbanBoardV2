using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KanbanBoardCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace KanbanBoard.SqlRepository
{
    public class SqlTaskRepository : ITaskRepository
    {
        ApplicationDbContext _dbContext = null;
        IDbContextTransaction _transaction = null;

        public SqlTaskRepository(ApplicationDbContext context)
        {
            this._dbContext = context;
        }

        public void BeginTranaction()
        {
            this._transaction = _dbContext.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (_transaction != null)
            {
                this._transaction.Commit();
                this._transaction = null;
            }
        }

        public Task<List<ProjectTask>> GetAllTasks(string userName, bool includeCompleted)
        {
            return Task.Factory.StartNew(()=>{

                var dbTasks = _dbContext.ProjectTask.ToList();

                return GetTaskFromDb(dbTasks);
            });
        }

        public Task<List<ProjectTaskView>> GetByDueDate(string userName, int days)
        {
            return Task.Factory.StartNew(() =>
            {

                var dbTasks = _dbContext.ProjectTask
                                        .Join( _dbContext.ProjectStage, t => t.StageID, s => s.StageID, (t,s)=>new {t, s})
                                        .Join (_dbContext.Project, s => s.s.ProjectID, p=> p.ProjectID, (s, p)=>new {s,p})
                                        .Join ( _dbContext.Priorities, t=> t.s.t.PriorityID, pr => pr.PriorityID, (t, pr)=>new {t,pr})
                                        .Where(t => t.t.s.t.CreatedBy == userName 
                                               && t.t.s.t.DueDate <= DateTime.Today.AddDays(days)
                                               && t.t.s.t.CompletionDate == DateTime.MinValue)
                                        .Select( s => new ProjectTaskView {
                    TaskID = s.t.s.t.TaskID,
                    Summary = s.t.s.t.Summary,
                    Description = s.t.s.t.Description,
                    PriorityID = s.t.s.t.PriorityID,
                    PriorityName = s.pr.PriorityName,
                    StageID = s.t.s.t.StageID,
                    StageName = s.t.s.s.StageName,
                    ProjectID = s.t.s.s.ProjectID,
                    ProjectName = s.t.p.ProjectName,
                    DueDate = s.t.s.t.DueDate,
                    CompletionDate = s.t.s.t.CompletionDate

                })
                                        .ToList();

                return dbTasks;
            });
        }

        private List<ProjectTask> GetTaskFromDb(List<DbProjectTask> dbProjectTasks)
        {
            List<ProjectTask> tasks = new List<ProjectTask>();

            foreach (var dbtask in dbProjectTasks)
            {
                tasks.Add(Mapper.Map<ProjectTask>(dbtask));
            }

            return tasks;
        }
        public Task<List<ProjectTask>> GetByProject(int projectID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Priority>> GetPriority()
        {
            return Task.Factory.StartNew(() =>
            {
                List<Priority> lstPriority = new List<Priority>();
                foreach(DbPriority prt in _dbContext.Priorities)
                {
                    lstPriority.Add(Mapper.Map<Priority>(prt));
                }

                return lstPriority;
            });
        }

        public Task<List<ProjectStage>> GetStages(int projectID)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectTask> GetTask(int taskID)
        {
            return Task.Factory.StartNew(() =>
            {
                if (taskID == 0)
                    throw new ArgumentException("Task ID must be greater than 0");

                var dbTask = _dbContext.ProjectTask.Where(t => t.TaskID == taskID).SingleOrDefault();

                var task = Mapper.Map<ProjectTask>(dbTask);

                return task;
            });
        }

        public void RollbackTransaction()
        {
            throw new NotImplementedException();
        }

        public Task SaveTask(ProjectTask task)
        {
            return Task.Factory.StartNew(() =>
            {
                if (task == null)
                    throw new ArgumentNullException(nameof(task), "Project task is provide null.");

                if (task.TaskID == 0)
                {
                    DbProjectTask dbProjectTask = Mapper.Map<DbProjectTask>(task);

                    this._dbContext.ProjectTask.Add(dbProjectTask);
                }
                else
                {
                    DbProjectTask dbProjectTask = _dbContext.ProjectTask.Where(t => t.TaskID == task.TaskID).Single();

                    dbProjectTask.Summary = task.Summary;
                    dbProjectTask.Description = task.Description;
                    dbProjectTask.PriorityID = task.PriorityID;
                    dbProjectTask.StageID = task.StageID;
                    dbProjectTask.DueDate = task.DueDate;

                    _dbContext.Update(dbProjectTask);
                }

                this._dbContext.SaveChanges();
            });


        }
    }
}
