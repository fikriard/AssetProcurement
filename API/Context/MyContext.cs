using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> dbContext) : base(dbContext)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<AssetCategory> AssetCategory { get; set; }
        public DbSet<AssetHistory> AssetHistory { get; set; }
        public DbSet<AssetLocation> AssetLocation { get; set; }
        public DbSet<AssetSubmission> AssetSubmission { get; set; }
        public DbSet<YearsProcurement> YearsProcurement { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Jobs> Jobs { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
    }
}
