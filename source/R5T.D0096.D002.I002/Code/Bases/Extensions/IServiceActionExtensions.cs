using System;

using R5T.T0062;
using R5T.T0063;

using R5T.D0096.D001;


namespace R5T.D0096.D002.I002
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="ConsoleHumanOutputSinkProvider"/> implementation of <see cref="IHumanOutputSinkProvider"/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IHumanOutputSinkProvider> AddConsoleHumanOutputSinkProviderAction(this IServiceAction _,
            IServiceAction<IHumanOutputSynchronicityProvider> humanOutputSynchronicityProviderAction)
        {
            var serviceAction = _.New<IHumanOutputSinkProvider>(services => services.AddConsoleHumanOutputSinkProvider(
                humanOutputSynchronicityProviderAction));

            return serviceAction;
        }
    }
}
