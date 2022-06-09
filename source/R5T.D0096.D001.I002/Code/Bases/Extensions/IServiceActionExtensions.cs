using System;

using R5T.D0081;
using R5T.T0062;
using R5T.T0063;


namespace R5T.D0096.D001.I002
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="HumanOutputSynchronicityProvider"/> implementation of <see cref="IHumanOutputSynchronicityProvider"/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IHumanOutputSynchronicityProvider> AddHumanOutputSynchronicityProviderAction(this IServiceAction _,
            IServiceAction<IExecutionSynchronicityProvider> executionSynchronicityProviderAction)
        {
            var serviceAction = _.New<IHumanOutputSynchronicityProvider>(services => services.AddHumanOutputSynchronicityProvider(
                executionSynchronicityProviderAction));

            return serviceAction;
        }
    }
}
