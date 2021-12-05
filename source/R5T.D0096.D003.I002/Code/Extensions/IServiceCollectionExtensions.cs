using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.D0048;
using R5T.T0063;


namespace R5T.D0096.D003.I002
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="HumanOutputFilePathProvider"/> implementation of <see cref="IHumanOutputFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddHumanOutputFilePathProvider(this IServiceCollection services,
            IServiceAction<IHumanOutputFileNameProvider> humanOutputFileNameProviderAction,
            IServiceAction<IOutputFilePathProvider> outputFilePathProviderAction)
        {
            services
                .Run(humanOutputFileNameProviderAction)
                .Run(outputFilePathProviderAction)
                .AddSingleton<IHumanOutputFilePathProvider, HumanOutputFilePathProvider>();

            return services;
        }
    }
}