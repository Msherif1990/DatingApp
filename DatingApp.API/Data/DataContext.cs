using System;
using System.IO;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DatingApp.API.Data
{
    public class DataContext : DbContext
    {       
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Value> Values { get; set; }
    }


    public class DbContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            // Get environment
            // string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            // Build config
            // IConfiguration config = new ConfigurationBuilder()
            //     .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../EfDesignDemo.Web"))
            //     .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //     .AddJsonFile($"appsettings.{environment}.json", optional: true)
            //     .AddEnvironmentVariables()
            //     .Build();

            // Get connection string
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();           
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-KCNQPOJ\\SQLEXPRESS;Database=datingapp;Trusted_Connection=True;");
            return new DataContext(optionsBuilder.Options);
        }
    }


}