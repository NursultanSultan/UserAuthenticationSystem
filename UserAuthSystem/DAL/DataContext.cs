﻿using Microsoft.EntityFrameworkCore;
using UserAuthSystem.Entities;

namespace UserAuthSystem.DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }

    
}
