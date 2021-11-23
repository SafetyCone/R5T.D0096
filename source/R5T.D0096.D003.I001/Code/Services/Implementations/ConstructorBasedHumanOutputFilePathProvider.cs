using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.D0096.D003.I001
{
    [ServiceImplementationMarker]
    public class ConstructorBasedHumanOutputFilePathProvider : IHumanOutputFilePathProvider, IServiceImplementation
    {
        private string HumanOutputFilePath { get; }


        public ConstructorBasedHumanOutputFilePathProvider(
            string humanOutputFilePath)
        {
            this.HumanOutputFilePath = humanOutputFilePath;
        }

        public Task<string> GetHumanOutputFilePath()
        {
            return Task.FromResult(this.HumanOutputFilePath);
        }
    }
}
