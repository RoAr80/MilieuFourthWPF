using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace Milieu.Relational.Database
{
    /// <summary>
    /// Это чудо поможет сделать миграцию
    /// </summary>
    public class ClientDbContextFactory : IDesignTimeDbContextFactory<ClientDbContext>
    {        

        public ClientDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ClientDbContext>();

            //optionsBuilder.UseSqlite(DI.Configuration.GetConnectionString("ClientDataBaseConnection"));

            return new ClientDbContext(optionsBuilder.Options);
        }
    }
}
