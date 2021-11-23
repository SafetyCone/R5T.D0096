using System;

using R5T.D0096.T001;


namespace R5T.D0096.D002.I002
{
    public class SynchronousConsoleHumanOutputSink : IHumanOutputSink
    {
        public void Dispose()
        {
            // Nothing to dispose.

            GC.SuppressFinalize(this);
        }

        public void Write(string text)
        {
            // Use the thread-safe exclusive usage context.
            Instances.Console.Write(text);
        }
    }
}
