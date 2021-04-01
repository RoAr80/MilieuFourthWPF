using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Milieu.Relational.Database;

namespace MilieuFourthWPF
{
    public static class AddLocalDbContextExtension
    {
        public static ContainerBuilder AddLocalDbContext(this ContainerBuilder builder, IConfiguration configuration)
        {
            builder.Register(c =>
            {
                var opt = new DbContextOptionsBuilder<ClientDbContext>();
                opt.UseSqlite(configuration.GetConnectionString("ClientDataBaseConnection"));

                return new ClientDbContext(opt.Options);
            }).AsSelf();

            return builder;
        }
    }
}
