using System;
using System.Collections.Generic;

using R5T.T0062;
using R5T.T0063;


namespace R5T.D0096.I001
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="HumanOutput"/> implementation of <see cref="IHumanOutput"/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IHumanOutput> AddHumanOutputAction(this IServiceAction _,
            IEnumerable<IServiceAction<IHumanOutputSinkProvider>> humanOutputSinkProviderActions)
        {
            var serviceAction = _.New<IHumanOutput>(services => services.AddHumanOutput(
                humanOutputSinkProviderActions));

            return serviceAction;
        }
    }
}
