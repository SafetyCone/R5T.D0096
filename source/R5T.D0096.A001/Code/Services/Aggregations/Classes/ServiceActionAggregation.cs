using System;
using R5T.D0096.D001;
using R5T.T0063;


namespace R5T.D0096.A001
{
    public class ServiceActionAggregation : IServiceActionAggregation
    {
        public IServiceAction<IHumanOutputSinkProvider> ConsoleHumanOutputSinkProviderAction { get; set; }
        public IServiceAction<IHumanOutputSinkProvider> FileHumanOutputSinkProviderAction { get; set; }
        public IServiceAction<IHumanOutput> HumanOutputAction { get; set; }
        public IServiceAction<IHumanOutputSynchronicityProvider> HumanOutputSynchronicityProviderAction { get; set; }
    }
}