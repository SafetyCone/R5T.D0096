using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0064;

using R5T.D0096.T001;


namespace R5T.D0096.I001
{
    [ServiceImplementationMarker]
    public class HumanOutput : IHumanOutput, IServiceImplementation
    {
        #region Static

        private static void PerformFirstTimeSetup(HumanOutput humanOutput)
        {
            SyncOverAsyncHelper.ExecuteSynchronously(async () =>
            {
                // Choose parallel async.
                var gettingHumanOutputSinks = humanOutput.HumanOutputSinkProviders
                    .Select(x => x.GetHumanOutputSink())
                    ;

                await Task.WhenAll(gettingHumanOutputSinks);

                humanOutput.HumanOutputSinks = gettingHumanOutputSinks
                    .Select(x => x.Result)
                    ;
            });
        }

        private static void EnsureSetup(HumanOutput humanOutput)
        {
            var isSetup = humanOutput.HumanOutputSinks is object;
            if (!isSetup)
            {
                HumanOutput.PerformFirstTimeSetup(humanOutput);
            }
        }

        #endregion


        private IEnumerable<IHumanOutputSinkProvider> HumanOutputSinkProviders { get; }
        private IEnumerable<IHumanOutputSink> HumanOutputSinks { get; set; }


        public HumanOutput(
            IEnumerable<IHumanOutputSinkProvider> humanOutputSinkProviders)
        {
            this.HumanOutputSinkProviders = humanOutputSinkProviders;
        }

        public void Write(string text)
        {
            // Ensure first-time setup.
            HumanOutput.EnsureSetup(this);

            foreach (var sink in this.HumanOutputSinks)
            {
                sink.Write(text);
            }
        }
    }
}
