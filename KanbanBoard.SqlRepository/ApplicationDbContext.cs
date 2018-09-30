using System;
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

        public DbSet<DbQuadrant> Quadrants{ get ; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<DbQuadrant>().HasData(
                new DbQuadrant{ QuadrantID = 1, QuadrantName="Urgent And Important", CreatedBy="system", CreateDate=DateTime.Now},
                new DbQuadrant{ QuadrantID = 2, QuadrantName="Urgent But Not Important", CreatedBy = "system", CreateDate = DateTime.Now},
                new DbQuadrant{ QuadrantID = 3, QuadrantName="Not Urgent But Important", CreatedBy = "system", CreateDate = DateTime.Now},
                new DbQuadrant{ QuadrantID = 4, QuadrantName="Not Urgent And Not Important", CreatedBy = "system", CreateDate = DateTime.Now}
            );
        }
    }

}
