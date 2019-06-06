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

        public DbSet<DbPriority> Priorities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
//            builder.Entity<DbQuadrant>().HasData(
//                new DbQuadrant{ QuadrantID = 1, QuadrantName="Urgent And Important", CreatedBy="system", CreateDate=DateTime.Now},
//                new DbQuadrant{ QuadrantID = 2, QuadrantName="Urgent But Not Important", CreatedBy = "system", CreateDate = DateTime.Now},
//                new DbQuadrant{ QuadrantID = 3, QuadrantName="Not Urgent But Important", CreatedBy = "system", CreateDate = DateTime.Now},
//                new DbQuadrant{ QuadrantID = 4, QuadrantName="Not Urgent And Not Important", CreatedBy = "system", CreateDate = DateTime.Now}
//            );

            builder.Entity<DbPriority>().HasData(
                new { PriorityID = 1, PriorityName = "Critical", CreatedBy = "system", CreateDate = new DateTime(2018, 9, 30) },
                new { PriorityID = 2, PriorityName = "Hight", CreatedBy = "system", CreateDate = new DateTime(2018, 9, 30) },
                new { PriorityID = 3, PriorityName = "Medium", CreatedBy = "system", CreateDate = new DateTime(2018, 9, 30) },
                new { PriorityID = 4, PriorityName = "Low", CreatedBy = "system", CreateDate = new DateTime(2018, 9, 30) }
            );
        }
    }

}
