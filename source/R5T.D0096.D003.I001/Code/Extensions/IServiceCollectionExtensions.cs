using System;

using Microsoft.Extensions.DependencyInjection;


namespace R5T.D0096.D003.I001
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="ConstructorBasedHumanOutputFilePathProvider"/> implementation of <see cref="IHumanOutputFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddConstructorBasedHumanOutputFilePathProvider(this IServiceCollection services,
            string humanOutputFilePath)
        {
            services.AddSingleton<IHumanOutputFilePathProvider>(sp => new ConstructorBasedHumanOutputFilePathProvider(
                humanOutputFilePath));

            return services;
        }
    }
}