using Autofac;
using Milieu.ClientModels.Database.Repos;
using Milieu.Relational.Database.Repos;

namespace MilieuFourthWPF
{
    public static class AddReposExtension
    {
        public static ContainerBuilder AddRepos(this ContainerBuilder builder)
        {
            builder.RegisterType<ClientRepository>().As<IClientRepo>().InstancePerLifetimeScope();

            return builder;
        }
    }
}
