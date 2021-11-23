using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.T0063;

using R5T.D0096.D001;
using R5T.D0096.D003;


namespace R5T.D0096.D002.I003
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="FileHumanOutputSinkProvider"/> implementation of <see cref="IHumanOutputSinkProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddFileHumanOutputSinkProvider(this IServiceCollection services,
            IServiceAction<IHumanOutputFilePathProvider> humanOutputFilePathProviderAction,
            IServiceAction<IHumanOutputSynchronicityProvider> humanOutputSynchronicityProviderAction)
        {
            services
                .Run(humanOutputFilePathProviderAction)
                .Run(humanOutputSynchronicityProviderAction)
                .AddSingleton<IHumanOutputSinkProvider, FileHumanOutputSinkProvider>();

            return services;
        }
    }
}