using System;
using System.Threading.Tasks;

using R5T.Magyar;

using R5T.T0064;


namespace R5T.D0096.D001
{
    [ServiceDefinitionMarker]
    public interface IHumanOutputSynchronicityProvider : IServiceDefinition
    {
        Task<Synchronicity> GetHumanOutputSynchronicity();
    }
}