using System;

using R5T.T0062;
using R5T.T0063;

using R5T.D0096.D001;
using R5T.D0096.D003;


namespace R5T.D0096.D002.I003
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="FileHumanOutputSinkProvider"/> implementation of <see cref="IHumanOutputSinkProvider"/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IHumanOutputSinkProvider> AddFileHumanOutputSinkProviderAction(this IServiceAction _,
            IServiceAction<IHumanOutputFilePathProvider> humanOutputFilePathProviderAction,
            IServiceAction<IHumanOutputSynchronicityProvider> humanOutputSynchronicityProviderAction)
        {
            var serviceAction = _.New<IHumanOutputSinkProvider>(services => services.AddFileHumanOutputSinkProvider(
                humanOutputFilePathProviderAction,
                humanOutputSynchronicityProviderAction));

            return serviceAction;
        }
    }
}
