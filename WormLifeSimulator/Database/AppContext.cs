﻿using Microsoft.EntityFrameworkCore;

namespace WormLifeSimulator
{
    public class AppContext: DbContext
    {

        public DbSet<WorldBehevior> WorldBeheviors { get; set; }
        public DbSet<FoodStep> FoodSteps { get; set; }

        public AppContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(@"Server=localhost;Port=5432;Database=SimulatorBehevior;Username=postgres;Password=admin");
            }
            //TODO вынести в конфиг файл
            //TODO положить базу в докер
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<WorldBehevior>()
                .HasIndex(u => u.Name)
                .IsUnique();
        }
    }
}
