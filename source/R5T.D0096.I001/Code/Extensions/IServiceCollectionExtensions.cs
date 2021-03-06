using System;
using System.Collections.Generic;

using Microsoft.Extensions.DependencyInjection;

using R5T.T0063;


namespace R5T.D0096.I001
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="HumanOutput"/> implementation of <see cref="IHumanOutput"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddHumanOutput(this IServiceCollection services,
            IEnumerable<IServiceAction<IHumanOutputSinkProvider>> humanOutputSinkProviderActions)
        {
            services
                .Run(humanOutputSinkProviderActions)
                .AddSingleton<IHumanOutput, HumanOutput>()
                ;

            return services;
        }
    }
}