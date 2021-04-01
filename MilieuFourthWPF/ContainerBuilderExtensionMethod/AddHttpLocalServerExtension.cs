using Autofac;

namespace MilieuFourthWPF
{
    public static class AddHttpLocalServerExtension
    {
        public static ContainerBuilder AddHttpLocalServer(this ContainerBuilder builder)
        {
            builder.RegisterType<HttpServer>().SingleInstance();

            return builder;
        }
    }
}
