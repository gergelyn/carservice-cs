using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CarService_Server.Models;

namespace CarService_Server.Repositories
{
    public class ClientContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public ClientContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Configuration.GetConnectionString("WebApiDatabase");
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<Client> Clients { get; set; }
    }
}
