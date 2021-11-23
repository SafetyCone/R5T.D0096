using System;

using R5T.T0063;

using R5T.D0096.D001;


namespace R5T.D0096.A001
{
    public interface IServiceActionAggregationIncrement
    {
        IServiceAction<IHumanOutputSinkProvider> ConsoleHumanOutputSinkProviderAction { get; set; }
        IServiceAction<IHumanOutputSinkProvider> FileHumanOutputSinkProviderAction { get; set; }
        IServiceAction<IHumanOutput> HumanOutputAction { get; set; }
        IServiceAction<IHumanOutputSynchronicityProvider> HumanOutputSynchronicityProviderAction { get; set; }
    }
}