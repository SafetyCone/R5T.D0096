using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.D0096.D003.I001
{
    [ServiceImplementationMarker]
    public class ConstructorBasedHumanOutputFileNameProvider : IHumanOutputFileNameProvider, IServiceImplementation
    {
        private string HumanOutputFileName { get; }


        public ConstructorBasedHumanOutputFileNameProvider(
            [NotServiceComponent] string humanOutputFileName)
        {
            this.HumanOutputFileName = humanOutputFileName;
        }

        public Task<string> GetHumanOutputFileName()
        {
            return Task.FromResult(this.HumanOutputFileName);
        }
    }
}
