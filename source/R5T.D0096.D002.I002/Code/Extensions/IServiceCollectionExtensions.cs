using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.T0063;

using R5T.D0096.D001;


namespace R5T.D0096.D002.I002
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="ConsoleHumanOutputSinkProvider"/> implementation of <see cref="IHumanOutputSinkProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddConsoleHumanOutputSinkProvider(this IServiceCollection services,
            IServiceAction<IHumanOutputSynchronicityProvider> humanOutputSynchronicityProviderAction)
        {
            services
                .Run(humanOutputSynchronicityProviderAction)
                .AddSingleton<IHumanOutputSinkProvider, ConsoleHumanOutputSinkProvider>();

            return services;
        }
    }
}