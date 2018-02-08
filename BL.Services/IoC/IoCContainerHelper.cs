using Autofac;
using BL.CORE;
using BL.Services.Repositories;
using DL.DataContext.Model;

namespace BL.Services.IoC
{
    public static class IoCContainerHelper
    {
        private static readonly IContainer Container;

        static IoCContainerHelper()
        {
            var builder = new ContainerBuilder();
            builder.Register<IDataContextFactory<FootBallTeamsContext>>(x => new DefaultDataContextFactory<FootBallTeamsContext>()).InstancePerLifetimeScope();
            builder.Register<ITeamRepository>(x => new TeamRepository(x.Resolve<IDataContextFactory<FootBallTeamsContext>>())).SingleInstance();
            builder.Register<ITournamentRepository>(x => new TournamentRepository(x.Resolve<IDataContextFactory<FootBallTeamsContext>>())).SingleInstance();
            builder.Register<IUnitOfWork>(x => new UnitOfWork<FootBallTeamsContext>(x.Resolve<IDataContextFactory<FootBallTeamsContext>>())).SingleInstance();

            Container = builder.Build();
        }

        public static ContainerBuilder BuilderHelper(this ContainerBuilder builder)
        {

            builder.Register<IDataContextFactory<FootBallTeamsContext>>(x => new DefaultDataContextFactory<FootBallTeamsContext>()).InstancePerLifetimeScope();
            builder.Register<ITeamRepository>(x => new TeamRepository(x.Resolve<IDataContextFactory<FootBallTeamsContext>>())).SingleInstance();
            builder.Register<ITournamentRepository>(x => new TournamentRepository(x.Resolve<IDataContextFactory<FootBallTeamsContext>>())).SingleInstance();
            builder.Register<IUnitOfWork>(x => new UnitOfWork<FootBallTeamsContext>(x.Resolve<IDataContextFactory<FootBallTeamsContext>>())).SingleInstance();

            return builder;
        }
        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}
