using Microsoft.EntityFrameworkCore;
using TDHRC.Models;

namespace TDHRC.Context
{
    public class ApplicationDbContext : DbContext
    {


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Publications> Publications { get; set; }
        public DbSet<Blogs> Blogs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Admin>().ToTable("Admin");

            //data seeding
            modelBuilder.Entity<Admin>().HasData(
                               new Admin
                               {
                                   Id = "A-001",
                                   Email = "admin@gmail.com",
                                   Password = "admin",
                                   Username = "admin",
                               });
        }

       


    }
}
