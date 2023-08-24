﻿using GaussClub.Models;
using Microsoft.EntityFrameworkCore;

namespace GaussClub.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<University> Universities { get; set; }
    }
}
