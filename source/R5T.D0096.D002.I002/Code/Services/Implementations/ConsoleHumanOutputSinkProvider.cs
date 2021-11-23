using System;
using System.Threading.Tasks;

using R5T.T0064;

using R5T.D0096.D001;
using R5T.D0096.T001;


namespace R5T.D0096.D002.I002
{
    [ServiceImplementationMarker]
    public class ConsoleHumanOutputSinkProvider : IHumanOutputSinkProvider, IServiceImplementation
    {
        private IHumanOutputSynchronicityProvider HumanOutputSynchronicityProvider { get; }

        private IHumanOutputSink HumanOutputSink { get; set; }


        public ConsoleHumanOutputSinkProvider(
            IHumanOutputSynchronicityProvider humanOutputSynchronicityProvider)
        {
            this.HumanOutputSynchronicityProvider = humanOutputSynchronicityProvider;
        }

        private async Task PerformFirstTimeSetup()
        {
            var synchronicity = await this.HumanOutputSynchronicityProvider.GetHumanOutputSynchronicity();

            if (synchronicity.IsSynchronous())
            {
                this.HumanOutputSink = new SynchronousConsoleHumanOutputSink();
            }
            else
            {
                this.HumanOutputSink = new AsynchronousConsoleHumanOutputSink();
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

            GC.SuppressFinalize(this);
        }
    }
}
