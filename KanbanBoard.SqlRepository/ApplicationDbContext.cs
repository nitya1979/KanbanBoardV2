using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KanbanBoard.SqlRepository
{
    public class ApplicationDbContext : IdentityDbContext<UserEntity, KanbanRoles, string>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
             
        }
        public DbSet<UserDetail> UserDetail { get; set; }

        public DbSet<Project> Project { get; set; }

        public DbSet<ProjectStage> ProjectStage { get; set; }

        public static ApplicationDbContext GetApplicationDbContext()
        {
            DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            optionsBuilder.UseSqlite("Filename=./kanban.db");

            return new ApplicationDbContext(optionsBuilder.Options);
        }

        public DbSet<ProjectTask> ProjectTask { get; set; }
    }

}
