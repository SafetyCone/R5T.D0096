using System;

using R5T.D0048;
using R5T.T0062;
using R5T.T0063;


namespace R5T.D0096.D003.I002
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="HumanOutputFilePathProvider"/> implementation of <see cref="IHumanOutputFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IHumanOutputFilePathProvider> AddHumanOutputFilePathProviderAction(this IServiceAction _,
            IServiceAction<IHumanOutputFileNameProvider> humanOutputFileNameProviderAction,
            IServiceAction<IOutputFilePathProvider> outputFilePathProviderAction)
        {
            var serviceAction = _.New<IHumanOutputFilePathProvider>(services => services.AddHumanOutputFilePathProvider(
                humanOutputFileNameProviderAction,
                outputFilePathProviderAction));

            return serviceAction;
        }
    }
}
