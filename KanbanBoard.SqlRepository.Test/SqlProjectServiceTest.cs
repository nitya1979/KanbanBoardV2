using AutoMapper;
using FizzWare.NBuilder;
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

        public SqlProjectServiceTest()
        {
             MapperConfig.InitializeMapping();

            _projectRepository = new SqlProjectRepository(ApplicationDbContext.GetApplicationDbContext());
        }
        [Fact]
        public async Task CreateProjectSuccessTest()
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                core.Project project = Builder<core.Project>.CreateNew().With(p => p.ProjectID = 0).Build();

                await _projectRepository.SaveProject(project);

                Assert.Equal<int>(0, project.ProjectID);
            }
            
        }

    }
}
