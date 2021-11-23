using System;
using System.Threading.Tasks;

using R5T.T0064;

using R5T.D0096.T001;


namespace R5T.D0096
{
    [ServiceDefinitionMarker]
    public interface IHumanOutputSinkProvider : IDisposable, IServiceDefinition
    {
        Task<IHumanOutputSink> GetHumanOutputSink();
    }
}
