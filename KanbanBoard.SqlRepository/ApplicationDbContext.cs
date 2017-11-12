using JetBrains.Annotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KanbanBoard.SqlRepository
{
    public class ApplicationDbContext : IdentityDbContext<UserEntity, KanbanRoles, string>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
             
        }

        protected ApplicationDbContext()
        {
        }

        public DbSet<UserDetail> UserDetail { get; set; }
    }

}
