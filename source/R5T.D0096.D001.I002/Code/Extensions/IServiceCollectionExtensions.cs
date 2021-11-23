using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.D0081;
using R5T.T0063;


namespace R5T.D0096.D001.I002
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="HumanOutputSynchronicityProvider"/> implementation of <see cref="IHumanOutputSynchronicityProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddHumanOutputSynchronicityProvider(this IServiceCollection services,
            IServiceAction<IExecutionSynchronicityProvider> executionSynchronicityProviderAction)
        {
            services
                .Run(executionSynchronicityProviderAction)
                .AddSingleton<IHumanOutputSynchronicityProvider, HumanOutputSynchronicityProvider>();

            return services;
        }
    }
}