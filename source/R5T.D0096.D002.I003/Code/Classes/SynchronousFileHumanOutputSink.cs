using System;
using System.IO;

using R5T.D0096.T001;


namespace R5T.D0096.D002.I003
{
    public class SynchronousFileHumanOutputSink : IHumanOutputSink
    {
        private TextWriter TextWriter { get; }


        public SynchronousFileHumanOutputSink(
            TextWriter textWriter)
        {
            this.TextWriter = textWriter;
        }

        public void Dispose()
        {
            // Do nothing. Let the creator/owner of the output stream handle its disposal.

            GC.SuppressFinalize(this);
        }

        public void Write(string text)
        {
            this.TextWriter.Write(text);
            this.TextWriter.Flush(); // Immediately flush.
        }
    }
}
