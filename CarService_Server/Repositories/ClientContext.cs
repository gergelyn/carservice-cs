using System;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using CarService_Server.Models;

namespace CarService_Server.Repositories
{
    public class ClientContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=localhost;user=root;password=;database=CarServiceDb";

            var serverVersion = new MySqlServerVersion(new Version(8, 0, 26));

            optionsBuilder.UseMySql(connectionString, serverVersion);
        }
        
    }
}
