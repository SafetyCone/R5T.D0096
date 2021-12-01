using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.D0096.D003
{
    [ServiceDefinitionMarker]
    public interface IHumanOutputFileNameProvider : IServiceDefinition
    {
        Task<string> GetHumanOutputFileName();
    }
}
