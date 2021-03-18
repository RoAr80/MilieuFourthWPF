using Microsoft.EntityFrameworkCore;
using Milieu.Models.Account.ClientSide;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milieu.Models.ClientSide.Database
{
    public class ClientDbContext : DbContext
    {
        public DbSet<LoginCredentialsDataModel> LoginCredentials { get; set; }

        public ClientDbContext(DbContextOptions<ClientDbContext> options) : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginCredentialsDataModel>()
                .HasAlternateKey(a => a.Email);

            modelBuilder.Entity<LoginCredentialsDataModel>()
                .HasIndex(b => b.LastEntry);
        }
        
    }
}
