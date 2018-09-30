using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace KanbanBoard.SqlRepository
{
    public class ApplicationDdbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {


        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionBuilder.UseSqlServer(@"Data Source=localhost\SQLexpress,1433;Initial Catalog=Kanban_Dev;User ID=sa;Password=e58@t4Ie");

            return new ApplicationDbContext(optionBuilder.Options);
        }
    }
}
