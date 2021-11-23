using System;
using System.IO;
using System.Threading.Tasks;

using R5T.T0064;

using R5T.D0096.D001;
using R5T.D0096.D003;
using R5T.D0096.T001;


namespace R5T.D0096.D002.I003
{
    [ServiceImplementationMarker]
    public class FileHumanOutputSinkProvider : IHumanOutputSinkProvider, IServiceImplementation
    {
        private IHumanOutputFilePathProvider HumanOutputFilePathProvider { get; set; }
        private IHumanOutputSynchronicityProvider HumanOutputSynchronicityProvider { get; }

        private TextWriter TextWriter { get; set; }
        private IHumanOutputSink HumanOutputSink { get; set; }


        public FileHumanOutputSinkProvider(
            IHumanOutputFilePathProvider humanOutputFilePathProvider,
            IHumanOutputSynchronicityProvider humanOutputSynchronicityProvider)
        {
            this.HumanOutputFilePathProvider = humanOutputFilePathProvider;
            this.HumanOutputSynchronicityProvider = humanOutputSynchronicityProvider;
        }

        private async Task PerformFirstTimeSetup()
        {
            var synchronicity = await this.HumanOutputSynchronicityProvider.GetHumanOutputSynchronicity();
            var humanOutputFilePath = await this.HumanOutputFilePathProvider.GetHumanOutputFilePath();

            this.TextWriter = new StreamWriter(humanOutputFilePath);

            if (synchronicity.IsSynchronous())
            {
                this.HumanOutputSink = new SynchronousFileHumanOutputSink(this.TextWriter);
            }
            else
            {
                this.HumanOutputSink = new AsynchronousFileHumanOutputSink(this.TextWriter);
            }
        }

        private async Task EnsureIsSetup()
        {
            var isSetup = this.HumanOutputSink is object;
            if (!isSetup)
            {
                await this.PerformFirstTimeSetup();
            }
        }

        public async Task<IHumanOutputSink> GetHumanOutputSink()
        {
            await this.EnsureIsSetup();

            return this.HumanOutputSink;
        }

        public void Dispose()
        {
            this.HumanOutputSink?.Dispose();

            this.TextWriter?.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
