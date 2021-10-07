using LeaveAppApi.Context.Model;
using LeaveAppApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveAppApi.Context
{
    public class DatabaseContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        //public DbSet<Role> Roles { get; set; }


        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }
    }


    
}
