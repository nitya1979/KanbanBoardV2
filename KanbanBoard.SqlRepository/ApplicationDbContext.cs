using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KanbanBoard.SqlRepository
{
    public class ApplicationDbContext : IdentityDbContext<UserEntity, KanbanRoles, string>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
             
        }
       
        public DbSet<Project> Project { get; set; }

        public DbSet<ProjectStage> ProjectStage { get; set; }

        public DbSet<ProjectTask> ProjectTask { get; set; }
    }

}
