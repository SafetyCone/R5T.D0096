using System;
using System.Threading.Tasks;

using R5T.D0048;
using R5T.D0096.D003;
using R5T.T0064;


namespace R5T.D0096.D003.I002
{
    [ServiceImplementationMarker]
    public class HumanOutputFilePathProvider : IHumanOutputFilePathProvider, IServiceImplementation
    {
        private IHumanOutputFileNameProvider HumanOutputFileNameProvider { get; }
        private IOutputFilePathProvider OutputFilePathProvider { get; }


        public HumanOutputFilePathProvider(
            IHumanOutputFileNameProvider humanOutputFileNameProvider,
            IOutputFilePathProvider outputFilePathProvider)
        {
            this.HumanOutputFileNameProvider = humanOutputFileNameProvider;
            this.OutputFilePathProvider = outputFilePathProvider;
        }

        public async Task<string> GetHumanOutputFilePath()
        {
            var humanOutputFileName = await this.HumanOutputFileNameProvider.GetHumanOutputFileName();

            var output = await this.OutputFilePathProvider.GetOutputFilePath(humanOutputFileName);
            return output;
        }
    }
}
