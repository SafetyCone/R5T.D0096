using System;

using R5T.T0064;


namespace R5T.D0096
{
    [ServiceDefinitionMarker]
    public interface IHumanOutput : IServiceDefinition
    {
        void Write(string text);
    }
}