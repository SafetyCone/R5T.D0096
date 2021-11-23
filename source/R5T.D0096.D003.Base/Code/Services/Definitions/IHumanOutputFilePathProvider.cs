using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.D0096.D003
{
    [ServiceDefinitionMarker]
    public interface IHumanOutputFilePathProvider : IServiceDefinition
    {
        Task<string> GetHumanOutputFilePath();
    }
}
