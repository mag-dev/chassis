﻿using Autofac;
using Chassis.Features;
using Chassis.Types;

namespace Chassis.Startup
{
    public class StartupFeature : Feature
    {
        public override void RegisterComponents(ContainerBuilder builder, TypePool pool)
        {
            builder.RegisterType<StartupBootstrapper>()
                .InstancePerLifetimeScope()
                .AsSelf();

            var actions = pool.FindImplementorsOf<IStartupStep>();

            foreach (var action in actions)
            {
                builder.RegisterType(action)
                    .As<IStartupStep>()
                    .AsSelf();
            }

            var webActions = pool.FindImplementorsOf<IWebApiStartupStep>();

            foreach (var action in webActions)
            {
                builder.RegisterType(action)
                    .As<IWebApiStartupStep>()
                    .AsSelf();
            }
        }
    }
}
