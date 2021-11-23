using System;
using System.Threading.Tasks;

using R5T.Magyar;

using R5T.D0081;
using R5T.T0064;


namespace R5T.D0096.D001.I002
{
    [ServiceImplementationMarker]
    public class HumanOutputSynchronicityProvider : IHumanOutputSynchronicityProvider, IServiceImplementation
    {
        private IExecutionSynchronicityProvider ExecutionSynchronicityProvider { get; }


        public HumanOutputSynchronicityProvider(
            IExecutionSynchronicityProvider executionSynchronicityProvider)
        {
            this.ExecutionSynchronicityProvider = executionSynchronicityProvider;
        }

        public async Task<Synchronicity> GetHumanOutputSynchronicity()
        {
            var output = await this.ExecutionSynchronicityProvider.GetExecutionSynchronicity();
            return output;
        }
    }
}
