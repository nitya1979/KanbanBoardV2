using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KanbanBoard.SqlRepository
{
    public class ApplicationDbContext : IdentityDbContext<UserEntity, KanbanRoles, string>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
             
        }
       
        public DbSet<DbProject> Project { get; set; }

        public DbSet<DbProjectStage> ProjectStage { get; set; }

        public DbSet<DbProjectTask> ProjectTask { get; set; }
    }

}
