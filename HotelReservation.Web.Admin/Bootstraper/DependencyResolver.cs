namespace HotelReservation.Web.Admin.Bootstraper
{
    using Autofac;
    using HotelReservation.Data.Context;
    using HotelReservation.Data.Repositories;
    using Microsoft.AspNetCore.Hosting;

    public class DependencyResolver : Module
    {
        private readonly IHostingEnvironment _env;

        public DependencyResolver(IHostingEnvironment env)
        {
            _env = env;
        }

        protected override void Load(ContainerBuilder builder)
        {
            LoadModules(builder);
        }

        private void LoadModules(ContainerBuilder builder)
        {
            builder.RegisterType<ReservationContext>().InstancePerLifetimeScope();

            builder.RegisterType<RoomRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<MealRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<SeasonRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
