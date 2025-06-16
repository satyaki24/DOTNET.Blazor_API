﻿using Microsoft.EntityFrameworkCore;
using Project.DataModel;

namespace Project.API.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
