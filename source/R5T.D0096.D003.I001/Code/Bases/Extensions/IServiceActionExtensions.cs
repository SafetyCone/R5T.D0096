using System;

using R5T.T0062;
using R5T.T0063;


namespace R5T.D0096.D003.I001
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="ConstructorBasedHumanOutputFilePathProvider"/> implementation of <see cref="IHumanOutputFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IHumanOutputFilePathProvider> AddConstructorBasedHumanOutputFilePathProviderAction(this IServiceAction _,
            string humanOutputFilePath)
        {
            var serviceAction = _.New<IHumanOutputFilePathProvider>(services => services.AddConstructorBasedHumanOutputFilePathProvider(
                humanOutputFilePath));

            return serviceAction;
        }
    }
}
