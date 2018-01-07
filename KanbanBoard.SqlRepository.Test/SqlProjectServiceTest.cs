using FizzWare.NBuilder;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Transactions;
using Xunit;
using core = KanbanBoardCore;
namespace KanbanBoard.SqlRepository.Test
{
    public class SqlProjectServiceTest
    {
        //IMapper mapper = null;
        SqlProjectRepository _projectRepository = null;

        static SqlProjectServiceTest()
        {
            MapperConfig.InitializeMapping();
        }
        public SqlProjectServiceTest()
        {

            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite(connection);

            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {
                context.Database.EnsureCreated();
            }

            ApplicationDbContext dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new SqlMapperConfiguraiton());
                //cfg.ForAllMaps((map, exp) => exp.ForAllOtherMembers(opt => opt.Ignore()));
            });

            _projectRepository = new SqlProjectRepository(new ApplicationDbContext(optionsBuilder.Options));
        }
        [Fact]
        public async Task New_Project_Success_Test()
        {
            core.Project project = Builder<core.Project>.CreateNew().With(p => p.ProjectID = 0).Build();
            //project.ProjectName = null;
            await _projectRepository.SaveProject(project);

            Assert.NotEqual<int>(0, project.ProjectID);

        }

        [Fact]
        public async Task New_Project_Name_Null_Fail_Test()
        {
            var project = Builder<core.Project>.CreateNew().With(p => p.ProjectID = 0)
                                                           .With(p => p.ProjectName = null)
                                                           .Build();

           await Assert.ThrowsAsync<DbUpdateException>(()=> _projectRepository.SaveProject(project));
           
        }

        [Fact]
        public async Task Get_Project_Success_Test()
        {
            var project = Builder<core.Project>.CreateNew().With(p => p.ProjectID =0).Build();
            project.ProjectName = "NewProject";
            await _projectRepository.SaveProject(project);
            
            var extProject = await _projectRepository.GetProject(project.ProjectID);
        
            Assert.IsType(typeof(core.Project), extProject);
            Assert.Equal<string>("NewProject", extProject.ProjectName);
        }

        [Fact]
        public async Task New_Projec_Stage_Fail_Test()
        {
            core.ProjectStage stage = Builder<core.ProjectStage>.CreateNew().With(s => s.StageID = 0).Build();
            await Assert.ThrowsAsync<DbUpdateException>(()=> _projectRepository.SaveStage(stage));
        }

        [Fact]
        public async Task Empty_Stage_Name_Fail_Test()
        {
            var project = Builder<core.Project>.CreateNew().With(p => p.ProjectID = 0).Build();
            project.ProjectName = "NewProject";
            await _projectRepository.SaveProject(project);
            core.ProjectStage stage = Builder<core.ProjectStage>.CreateNew()
                                                                .With(s => s.StageID = 0)
                                                                .With( s=> s.StageName = null)
                                                                .Build();
            stage.ProjectID = project.ProjectID;
            await Assert.ThrowsAsync<DbUpdateException>(() => _projectRepository.SaveStage(stage));
            Assert.Equal<int>(0, stage.StageID);
        }
        [Fact]
        public async Task New_Project_Stage_Success_Test()
        {
            var project = Builder<core.Project>.CreateNew().With(p => p.ProjectID = 0).Build();
            project.ProjectName = "NewProject";
            try
            {
                _projectRepository.BeginTranaction();
                await _projectRepository.SaveProject(project);
                core.ProjectStage stage = Builder<core.ProjectStage>.CreateNew().With(s => s.StageID = 0).Build();
                stage.ProjectID = project.ProjectID;
                await _projectRepository.SaveStage(stage);
                _projectRepository.CommitTransaction();
                Assert.NotEqual<int>(0, stage.StageID);
            }
            catch
            {
                _projectRepository.RollbackTransaction();
            }

            var prj = await _projectRepository.GetProject(project.ProjectID);
            Assert.NotEqual<int>(0, prj.ProjectID);
        }
    }
}
