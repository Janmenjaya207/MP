using Autofac;
using MP_MB_MD.Core.Interfaces;
using MP_MB_MD.Core.Services;

namespace MP_MB_MD.Core
{
    public class DefaultCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ToDoItemSearchService>()
                .As<IToDoItemSearchService>().InstancePerLifetimeScope();
        }
    }
}
