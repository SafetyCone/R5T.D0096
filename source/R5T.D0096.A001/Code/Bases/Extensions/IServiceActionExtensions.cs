using System;

using R5T.Magyar;

using R5T.D0081;
using R5T.T0062;
using R5T.T0063;

using R5T.D0096.D001.I002;
using R5T.D0096.D002.I002;
using R5T.D0096.D002.I003;
using R5T.D0096.D003;
using R5T.D0096.I001;


namespace R5T.D0096.A001
{
    public static class IServiceActionExtensions
    {
        public static IServiceActionAggregation AddHumanOutputActions(this IServiceAction _,
            IServiceAction<IExecutionSynchronicityProvider> executionSynchronicityProviderAction,
            IServiceAction<IHumanOutputFilePathProvider> humanOutputFilePathProviderAction)
        {
            var humanOutputSynchronicityProviderAction = _.AddHumanOutputSynchronicityProviderAction(
                   executionSynchronicityProviderAction);
            var consoleHumanOutputSinkProviderAction = _.AddConsoleHumanOutputSinkProviderAction(
                humanOutputSynchronicityProviderAction);
            var fileHumanOutputSinkProvider = _.AddFileHumanOutputSinkProviderAction(
                humanOutputFilePathProviderAction,
                humanOutputSynchronicityProviderAction);

            var humanOutputAction = _.AddHumanOutputAction(EnumerableHelper.From(
                consoleHumanOutputSinkProviderAction,
                fileHumanOutputSinkProvider));

            var output = new ServiceActionAggregation
            {
                ConsoleHumanOutputSinkProviderAction = consoleHumanOutputSinkProviderAction,
                FileHumanOutputSinkProviderAction = fileHumanOutputSinkProvider,
                HumanOutputAction = humanOutputAction,
                HumanOutputSynchronicityProviderAction = humanOutputSynchronicityProviderAction,
            };

            return output;
        }
    }
}
