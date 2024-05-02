﻿using APP.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace APP.Infrustructure.Data
{
    public class APPDbContext:DbContext
    {
        public APPDbContext(DbContextOptions<APPDbContext> options):base(options) 
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        DbSet<Employee> Employees { get; set; }
        DbSet<Department> Departments { get; set; }
    }
}
