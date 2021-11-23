using System;

using R5T.D0096.A001;


namespace System
{
    public static class IServiceActionAggregationIncrementExtensions
    {
        public static T FillFrom<T>(this T aggregation,
            IServiceActionAggregationIncrement other)
            where T : IServiceActionAggregationIncrement
        {
            aggregation.ConsoleHumanOutputSinkProviderAction = other.ConsoleHumanOutputSinkProviderAction;
            aggregation.FileHumanOutputSinkProviderAction = other.FileHumanOutputSinkProviderAction;
            aggregation.HumanOutputAction = other.HumanOutputAction;
            aggregation.HumanOutputSynchronicityProviderAction = other.HumanOutputSynchronicityProviderAction;

            return aggregation;
        }
    }
}