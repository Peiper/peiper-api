﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class Test
    {
        public string Var1 { get; set; }
        public string Var2 { get; set; }
    }
    public class DbPsqlContext : DbContext
    {
        public DbPsqlContext(DbContextOptions<DbContext> options) : base(options) { }

        public DbSet<Test> TestData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>().ToTable("test");
        }
    }
}